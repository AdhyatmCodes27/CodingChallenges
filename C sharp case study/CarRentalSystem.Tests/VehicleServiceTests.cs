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
    public class VehicleServiceTests
    {
        [Test]
        public void AddCar_Should_Add_Car_Successfully()
        {
            // Arrange
            var vehicles = new List<Vehicle>();
            var vehicleRepository = new VehicleRepository(vehicles);
            var vehicleService = new VehicleService(vehicleRepository);
            var newVehicle = new Vehicle { VehicleID = 1, Make = "Toyota", Model = "Camry", Year = 2022, DailyRate = 50, Status = "available" };

            // Act
            vehicleService.AddCar(newVehicle);

            // Assert
            var addedCar = vehicleService.FindCarById(1);
            Assert.IsNotNull(addedCar);
            Assert.AreEqual(1, addedCar.VehicleID);
            Assert.AreEqual("Toyota", addedCar.Make);
        }
    }
}