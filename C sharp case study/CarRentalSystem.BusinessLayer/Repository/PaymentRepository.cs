using CarRentalSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.BusinessLayer.Repository
{
    public class PaymentRepository: IPaymentRepository
    {
        // Simulating an in-memory list of payments
        private List<Payment> payments = new List<Payment>();

        // Records a payment for a given lease
        public void RecordPayment(Lease lease, double amount)
        {
            // Create a new Payment object
            var newPayment = new Payment
            {
                PaymentID = payments.Count + 1,  // Auto-incrementing the payment ID
                LeaseID = lease.LeaseID,
                PaymentDate = DateTime.Now,      // Current date and time for payment
                Amount = amount
            };

            // Add the payment to the list
            payments.Add(newPayment);
        }
    }
}
