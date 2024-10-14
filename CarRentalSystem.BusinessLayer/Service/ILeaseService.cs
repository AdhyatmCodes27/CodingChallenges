using CarRentalSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.BusinessLayer.Service
{
    public interface ILeaseService
    {
        Lease CreateLease(int customerID, int carID, DateTime startDate, DateTime endDate);
        Lease ReturnCar(int leaseID);
        List<Lease> ListActiveLeases();
        List<Lease> ListLeaseHistory();
    }
}
