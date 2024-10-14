using CarRentalSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
//using CarRentalSystem.Entity;

namespace CarRentalSystem.BusinessLayer.Repository
{
    public interface IVehicleRepository
    {
  
        void AddCar(Vehicle car);       
        void RemoveCar(int carID);
        List<Vehicle> ListAvailableCars();
        List<Vehicle> ListRentedCars();
        Vehicle FindCarById(int carID);
    }
}
