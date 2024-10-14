using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.BusinessLayer.Repository;
using CarRentalSystem.BusinessLayer.Service;
using CarRentalSystem.Entity;
using NUnit.Framework;

namespace CarRentalSystem.Tests
{
    [TestFixture]
    public class LeaseServiceCreationTests
    {
        [Test]
        public void CreateLease_Should_Create_Lease_Successfully()
        {
            // Arrange
            var vehicles = new List<Vehicle>
            {
                new Vehicle { VehicleID = 1, Make = "Toyota", Model = "Camry", Year = 2022, DailyRate = 50, Status = "available" }
            };
            var customers = new List<Customer>
            {
                new Customer { CustomerID = 1, FirstName = "John", LastName = "Doe" }
            };

            var leaseRepository = new LeaseRepository(vehicles, customers);
            var leaseService = new LeaseService(leaseRepository);

            // Act
            var lease = leaseService.CreateLease(1, 1, DateTime.Now, DateTime.Now.AddDays(5));

            // Assert
            Assert.IsNotNull(lease);
            Assert.AreEqual(1, lease.CustomerID);
            Assert.AreEqual(1, lease.VehicleID);
        }
    }
}