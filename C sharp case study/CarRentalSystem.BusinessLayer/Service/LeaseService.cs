using CarRentalSystem.BusinessLayer.Repository;
using CarRentalSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.BusinessLayer.Service
{
    public class LeaseService: ILeaseService
    {
        private readonly ILeaseRepository _leaseRepository;

        // Constructor injecting the repository
        public LeaseService(ILeaseRepository leaseRepository)
        {
            _leaseRepository = leaseRepository;
        }

        // Creates a new lease for a customer with a vehicle
        public Lease CreateLease(int customerID, int vehicleID, DateTime startDate, DateTime endDate)
        {
            // Call the repository method to create the lease
            return _leaseRepository.CreateLease(customerID, vehicleID, startDate, endDate);
        }

        // Handles the return of a vehicle by leaseID
        public Lease ReturnCar(int leaseID)
        {
            // Call the repository method to return the car
            return _leaseRepository.ReturnCar(leaseID);
        }

        // Lists all active leases
        public List<Lease> ListActiveLeases()
        {
            // Call the repository method to list active leases
            return _leaseRepository.ListActiveLeases();
        }

        // Lists the history of all leases
        public List<Lease> ListLeaseHistory()
        {
            // Call the repository method to list lease history
            return _leaseRepository.ListLeaseHistory();
        }

        public object FindLeaseById(int v)
        {
            throw new NotImplementedException();
        }
    }
}
