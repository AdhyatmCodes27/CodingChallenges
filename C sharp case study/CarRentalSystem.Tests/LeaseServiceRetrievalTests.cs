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
    public class LeaseServiceRetrievalTests
    {
        [Test]
        public void FindLeaseById_Should_Return_Lease_Successfully()
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

            var leases = new List<Lease>
            {
                new Lease { LeaseID = 1, VehicleID = 1, CustomerID = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), Type = "Daily" }
            };

            var leaseRepository = new LeaseRepository(vehicles, customers);
            var leaseService = new LeaseService(leaseRepository);

            // Act
            var lease = leaseService.FindLeaseById(1);

            // Assert
            Assert.IsNotNull(lease);
           // Assert.AreEqual(1, lease.LeaseID);
        }
    }
}
