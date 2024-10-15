using OrderManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.BusinessLayer.Repository
{
    public interface IOrderManagementRepository
    {

        // Create an order for a user with a list of products
        void CreateOrder(User user, List<Products> products);

        // Cancel an existing order
        void CancelOrder(int userId, int orderId);

        // Create a new product by an admin user
        void CreateProduct(User user, Products product);

        // Create a new user
        void CreateUser(User user);

        // Get all products
        List<Products> GetAllProducts();

        // Get all products ordered by a specific user
        List<Order> GetOrderByUser(int user);

    }
}
