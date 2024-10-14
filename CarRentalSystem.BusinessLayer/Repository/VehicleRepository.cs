using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.Entity;

namespace CarRentalSystem.BusinessLayer.Repository
{
    public class VehicleRepository: IVehicleRepository
    {
        
        private List<Vehicle> cars = new List<Vehicle>();

        public VehicleRepository(List<Vehicle> vehicles)
        {
        }

        public void AddCar(Vehicle car)
        {
            cars.Add(car);
        }

        public void RemoveCar(int carID)
        {
            var car = FindCarById(carID);
            if (car != null)
            {
                cars.Remove(car);
            }
        }

        public List<Vehicle> ListAvailableCars()
        {
            return cars.Where(c => c.Status == "available").ToList();
        }

        public List<Vehicle> ListRentedCars()
        {
            return cars.Where(c => c.Status == "notAvailable").ToList();
        }

        public Vehicle FindCarById(int carID)
        {
            var car = cars.FirstOrDefault(c => c.VehicleID == carID);
            if (car == null)
            {
                throw new Exception($"Car with ID {carID} not found.");
            }
            return car;
        }
    }
}
