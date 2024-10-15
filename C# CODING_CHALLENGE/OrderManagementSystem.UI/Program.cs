using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.BusinessLayer;
using OrderManagementSystem.Entity;
using OrderManagementSystem.BusinessLayer.MyExceptions;
using OrderManagementSystem.BusinessLayer.Repository;

namespace OrderManagementSystem.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderProcessor orderProcessor = new OrderProcessor();
            string userChoice;

            do
            {
                Console.WriteLine("Order Management System");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Create Product");
                Console.WriteLine("3. Cancel Order");
                Console.WriteLine("4. Get All Products");
                Console.WriteLine("5. Get Orders by User");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        CreateUser(orderProcessor);
                        break;
                    case "2":
                        CreateProduct(orderProcessor);
                        break;
                    case "3":
                        CancelOrder(orderProcessor);
                        break;
                    case "4":
                        GetAllProducts(orderProcessor);
                        break;
                    case "5":
                        GetOrderByUser(orderProcessor);
                        break;
                    case "6":
                        Console.WriteLine("Exiting the system. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (userChoice != "6");
        }

        static void CreateUser(OrderProcessor orderProcessor)
        {
            //  create a user
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter Role (Admin/User): ");
            string role = Console.ReadLine();

            // Create User object and call method from OrderProcessor
            User newUser = new User { Username = username, Password = password, Role = role };
            orderProcessor.CreateUser(newUser); 
            Console.WriteLine("User created successfully.");
        }

        static void CreateProduct(OrderProcessor orderProcessor)
        {
            //  create a product
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Price: ");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Quantity in Stock: ");
            int quantityInStock = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Type (Electronics/Clothing): ");
            string type = Console.ReadLine();

            // 
            Products newProduct = new Products
            
            {                                       
                ProductName = productName,
                Description = description,
                Price = price,
                QuantityInStock = quantityInStock,
                Type = type
            };



            User newUser = new User
            {
              


            };
            orderProcessor.CreateProduct(newUser, newProduct); // Implement this method in OrderProcessor
            Console.WriteLine("Product created successfully.");
        }

        static void CancelOrder(OrderProcessor orderProcessor)
        {
            //  cancel an order
            Console.Write("Enter User ID: ");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Order ID: ");
            int orderId = Convert.ToInt32(Console.ReadLine());

            // Call method from OrderProcessor to cancel the order
            orderProcessor.CancelOrder(userId, orderId); 
            Console.WriteLine("Order cancelled successfully.");
        }

        static void GetAllProducts(OrderProcessor orderProcessor)
        {
            //  retrieve and display all products
            var products = orderProcessor.GetAllProducts(); 
            Console.WriteLine("Available Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ProductId}, Name: {product.ProductName}, Price: {product.Price}, Quantity: {product.QuantityInStock}");
            }
        }

        static void GetOrderByUser(OrderProcessor orderProcessor)
        {
            Console.Write("Enter User ID: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            var orders = orderProcessor.GetOrderByUser(userId); // This should now work
            Console.WriteLine("Orders for User ID " + userId + ":");

            if (orders.Count == 0)
            {
                Console.WriteLine("No orders found for this user.");
            }
            else
            {
                foreach (var order in orders)
                {
                    Console.WriteLine($"Order ID: {order.OrderId}, Order Date: {order.OrderDate}");
                }
            }
        }

    }
}
