using CarRentalSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.BusinessLayer.Service
{
    public interface IVehicleService
    {   
        
        void AddCar(Vehicle car);    
        void RemoveCar(int carID);      
        List<Vehicle> ListAvailableCars();
        List<Vehicle> ListRentedCars();        
        Vehicle FindCarById(int carID);
    
    }
}

