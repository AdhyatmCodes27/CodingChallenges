using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.BusinessLayer.MyExceptions;
using CarRentalSystem.BusinessLayer.Repository;
using CarRentalSystem.BusinessLayer.Service;
using CarRentalSystem.Entity;
using NUnit.Framework;

namespace CarRentalSystem.Tests
{
    [TestFixture]
    public class ExceptionTests
    {
        [Test]
        public void FindCarById_Should_Throw_CarNotFoundException_When_Car_Not_Found()
        {
            // Arrange
            var vehicles = new List<Vehicle>();
            var vehicleRepository = new VehicleRepository(vehicles);
            var vehicleService = new VehicleService(vehicleRepository);

            // Act & Assert
            Assert.Throws<CarNotFoundException>(() => vehicleService.FindCarById(1));
        }

        [Test]
        public void FindCustomerById_Should_Throw_CustomerNotFoundException_When_Customer_Not_Found()
        {
            // Arrange
            var customers = new List<Customer>();
            var customerRepository = new CustomerRepository(customers);
            var customerService = new CustomerService(customerRepository);

            // Act & Assert
            Assert.Throws<CustomerNotFoundException>(() => customerService.FindCustomerById(1));
        }

        [Test]
        public void FindLeaseById_Should_Throw_LeaseNotFoundException_When_Lease_Not_Found()
        {
            // Arrange
            var vehicles = new List<Vehicle>();
            var customers = new List<Customer>();
            var leases = new List<Lease>();

            var leaseRepository = new LeaseRepository(vehicles, customers);
            var leaseService = new LeaseService(leaseRepository);

            // Act & Assert
            Assert.Throws<LeaseNotFoundException>(() => leaseService.FindLeaseById(1));
        }
    }
}