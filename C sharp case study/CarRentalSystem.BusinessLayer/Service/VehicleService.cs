using CarRentalSystem.BusinessLayer.Repository;
using CarRentalSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.BusinessLayer.Service
{
    public class VehicleService : IVehicleService
    {
        IVehicleRepository _vehicleRepository;

        // Constructor injecting the repository
        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        // Adds a new car
        public void AddCar(Vehicle car)
        {
            _vehicleRepository.AddCar(car);
        }

        // Removes a car by its carID
        public void RemoveCar(int carID)
        {
            _vehicleRepository.RemoveCar(carID);
        }

        // Lists all available cars
        public List<Vehicle> ListAvailableCars()
        {
            return _vehicleRepository.ListAvailableCars();
        }

        // Lists all rented cars
        public List<Vehicle> ListRentedCars()
        {
            return _vehicleRepository.ListRentedCars();
        }

        // Finds a car by its ID, throws an exception if not found
        public Vehicle FindCarById(int carID)
        {
            return _vehicleRepository.FindCarById(carID);
        }
    }
}
