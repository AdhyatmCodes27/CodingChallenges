using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entity
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double DailyRate { get; set; }
        public string Status { get; set; } // Available, NotAvailable
        public int PassengerCapacity { get; set; }
        public double EngineCapacity { get; set; }
    }
}
