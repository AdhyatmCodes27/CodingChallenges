using CarRentalSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.BusinessLayer.Repository
{
    public interface IPaymentRepository
    {
        // Records a payment for a given lease
        void RecordPayment(Lease lease, double amount);
    }
}
