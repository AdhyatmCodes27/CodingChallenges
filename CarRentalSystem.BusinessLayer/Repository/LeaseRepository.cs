using CarRentalSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.BusinessLayer.Repository
{
    public class LeaseRepository: ILeaseRepository
    {
        // Simulating an in-memory list of leases
        private List<Lease> leases = new List<Lease>();

        // Simulating an in-memory list of cars and customers for reference
        private List<Vehicle> vehicles;
        private List<Customer> customers;


        // Constructor with dependency injection of vehicles and customers
        public LeaseRepository(List<Vehicle> vehicles, List<Customer> customers)
        {
            this.vehicles = vehicles;
            this.customers = customers;
        }

        // Creates a new lease for a customer with a vehicle
        public Lease CreateLease(int customerID, int vehicleID, DateTime startDate, DateTime endDate)
        {
            var customer = customers.FirstOrDefault(c => c.CustomerID == customerID);
            var vehicle = vehicles.FirstOrDefault(v => v.VehicleID == vehicleID && v.Status == "available");

            if (customer == null)
                throw new Exception($"Customer with ID {customerID} not found.");

            if (vehicle == null)
                throw new Exception($"Vehicle with ID {vehicleID} is either not found or not available.");

            // Change the vehicle status to rented
            vehicle.Status = "notAvailable";

            // Create new lease and add it to the list of leases
            var newLease = new Lease
            {
                LeaseID = leases.Count + 1,
                CustomerID = customerID,
                VehicleID = vehicleID,
                StartDate = startDate,
                EndDate = endDate,
                Type = startDate.AddDays(30) > endDate ? "Daily" : "Monthly"
            };

            leases.Add(newLease);

            return newLease;
        }

        // Handles the return of a vehicle by leaseID, returns lease info
        public Lease ReturnCar(int leaseID)
        {
            var lease = leases.FirstOrDefault(l => l.LeaseID == leaseID);

            if (lease == null)
                throw new Exception($"Lease with ID {leaseID} not found.");

            // Find the associated vehicle and mark it as available
            var vehicle = vehicles.FirstOrDefault(v => v.VehicleID == lease.VehicleID);
            if (vehicle != null)
                vehicle.Status = "available";

            return lease;
        }

        // Lists all active leases (leases that are currently ongoing)
        public List<Lease> ListActiveLeases()
        {
            // Assuming active leases are those whose end date is still in the future
            return leases.Where(l => l.EndDate > DateTime.Now).ToList();
        }

        // Lists the history of all leases
        public List<Lease> ListLeaseHistory()
        {
            return leases.ToList();
        }
    }
}
