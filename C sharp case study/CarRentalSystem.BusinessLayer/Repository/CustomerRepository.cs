using CarRentalSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.BusinessLayer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> customers = new List<Customer>();

        public CustomerRepository(List<Customer> customers)
        {
            this.customers = customers;
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public void RemoveCustomer(int customerID)
        {
            var customer = FindCustomerById(customerID);
            if (customer != null)
            {
                customers.Remove(customer);
            }
        }

        public List<Customer> ListCustomers()
        {
            return customers;
        }

        public Customer FindCustomerById(int customerID)
        {
            var customer = customers.FirstOrDefault(c => c.CustomerID == customerID);
            if (customer == null)
            {
                throw new Exception($"Customer with ID {customerID} not found.");
            }
            return customer;
        }
    }
}
