using CarRentalSystem.BusinessLayer.Repository;
using CarRentalSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.BusinessLayer.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        // Constructor injecting the repository
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // Adds a new customer
        public void AddCustomer(Customer customer)
        {
            _customerRepository.AddCustomer(customer);
        }

        // Removes a customer by their customerID
        public void RemoveCustomer(int customerID)
        {
            _customerRepository.RemoveCustomer(customerID);
        }

        // Lists all customers
        public List<Customer> ListCustomers()
        {
            return _customerRepository.ListCustomers();
        }

        // Finds a customer by their ID
        public Customer FindCustomerById(int customerID)
        {
            return _customerRepository.FindCustomerById(customerID);
        }

    }
}
