using OrderManagementSystem.BusinessLayer.Repository;
using OrderManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.BusinessLayer.MyExceptions;
using System.Data.SqlClient;

namespace OrderManagementSystem.BusinessLayer
{
    public class OrderProcessor: IOrderManagementRepository
    {

        private List<User> users = new List<User>(); 
        private List<Products> products = new List<Products>(); 
        private List<Order> orders = new List<Order>(); 

        // n order for a user with a list of products
        public void CreateOrder(User user, List<Products> products)
        {
            //  if user exists in the database
            using (SqlConnection conn = DBUtil.getDBConnection())
            {
                //  if the user exists
                string userCheckQuery = "SELECT COUNT(*) FROM Users WHERE UserId = @UserId";
                using (SqlCommand userCheckCmd = new SqlCommand(userCheckQuery, conn))
                {
                    userCheckCmd.Parameters.AddWithValue("@UserId", user.UserId);
                    int userCount = (int)userCheckCmd.ExecuteScalar();

                    if (userCount == 0)
                    {
                        throw new UserNotFoundException("User not found. Please create a user first.");
                    }
                }

                // Create order and insert into database
                string orderQuery = "INSERT INTO Orders (UserId, OrderDate) OUTPUT INSERTED.OrderId VALUES (@UserId, @OrderDate)";
                int newOrderId;

                using (SqlCommand orderCmd = new SqlCommand(orderQuery, conn))
                {
                    orderCmd.Parameters.AddWithValue("@UserId", user.UserId);
                    orderCmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);

                    // get the new order ID
                    newOrderId = (int)orderCmd.ExecuteScalar();
                }

                // Insert associated products for the order
                foreach (var product in products)
                {
                    string orderProductQuery = "INSERT INTO OrderProducts (OrderId, ProductId) VALUES (@OrderId, @ProductId)";
                    using (SqlCommand orderProductCmd = new SqlCommand(orderProductQuery, conn))
                    {
                        orderProductCmd.Parameters.AddWithValue("@OrderId", newOrderId);
                        orderProductCmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                        orderProductCmd.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Order created successfully with Order ID: " + newOrderId);
            }
        }


        // Cancel an existing order
        public void CancelOrder(int userId, int orderId)
        {
            using (SqlConnection conn = DBUtil.getDBConnection())
            {
                // Check if the order exists
                string orderCheckQuery = "SELECT COUNT(*) FROM Orders WHERE OrderId = @OrderId AND UserId = @UserId";
                using (SqlCommand orderCheckCmd = new SqlCommand(orderCheckQuery, conn))
                {
                    orderCheckCmd.Parameters.AddWithValue("@OrderId", orderId);
                    orderCheckCmd.Parameters.AddWithValue("@UserId", userId);
                    int orderCount = (int)orderCheckCmd.ExecuteScalar();

                    if (orderCount == 0)
                    {
                        throw new OrderNotFoundException("Order not found for the given user ID.");
                    }
                }

                // Delete the order
                string cancelOrderQuery = "DELETE FROM Orders WHERE OrderId = @OrderId AND UserId = @UserId";
                using (SqlCommand cancelOrderCmd = new SqlCommand(cancelOrderQuery, conn))
                {
                    cancelOrderCmd.Parameters.AddWithValue("@OrderId", orderId);
                    cancelOrderCmd.Parameters.AddWithValue("@UserId", userId);
                    cancelOrderCmd.ExecuteNonQuery();
                }

                Console.WriteLine("Order canceled successfully.");
            }
        }


        //  new product by an admin user
        public void CreateProduct(User user, Products product)
        {
            if (user.Role != "Admin")
            {
                throw new UnauthorizedAccessException("Only admins can create products.");
            }

            // Establish database connection
            using (SqlConnection conn = DBUtil.getDBConnection())
            {
                if (conn == null)
                {
                    throw new Exception("Database connection could not be established.");
                }

                string query = "INSERT INTO Products (ProductName, Description, Price, QuantityInStock, Type) VALUES (@ProductName, @Description, @Price, @QuantityInStock, @Type)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                   
                    cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                    cmd.Parameters.AddWithValue("@Description", product.Description);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@QuantityInStock", product.QuantityInStock);
                    cmd.Parameters.AddWithValue("@Type", product.Type);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Product created successfully.");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error while creating product: " + ex.Message);
                    }
                }
            }
        }


        // Create a new user
        public void CreateUser(User user)
        {
            users.Add(user);
            Console.WriteLine("User created successfully.");
        }

        // Get all products
        public List<Products> GetAllProducts()
        {
            List<Products> productsList = new List<Products>();
            using (SqlConnection conn = DBUtil.getDBConnection())
            {
                string query = "SELECT * FROM Products";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products product = new Products
                            {
                                ProductId = reader["ProductId"] != DBNull.Value ? Convert.ToInt32(reader["ProductId"]) : 0,
                                ProductName = reader["ProductName"] != DBNull.Value ? reader["ProductName"].ToString() : string.Empty,
                                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty,
                                Price = reader["Price"] != DBNull.Value ? Convert.ToDouble(reader["Price"]) : 0.0,
                                QuantityInStock = reader["QuantityInStock"] != DBNull.Value ? Convert.ToInt32(reader["QuantityInStock"]) : 0,
                                Type = reader["Type"] != DBNull.Value ? reader["Type"].ToString() : string.Empty
                            };
                            productsList.Add(product);
                        }
                    }
                }
            }
            return productsList;
        }



        // all products ordered by a specific user
        public List<Order> GetOrderByUser(int userId)
        {
            List<Order> userOrders = new List<Order>();

            using (SqlConnection conn = DBUtil.getDBConnection())
            {
               
                string query = "SELECT * FROM Orders WHERE UserId = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order
                            {
                                OrderId = (int)reader["OrderId"],
                                UserId = (int)reader["UserId"],
                                OrderDate = (DateTime)reader["OrderDate"]
                            };
                            userOrders.Add(order);
                        }
                    }
                }
            }

            return userOrders; 
        }













    }
}
