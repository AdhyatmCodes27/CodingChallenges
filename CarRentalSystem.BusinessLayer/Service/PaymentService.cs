using CarRentalSystem.BusinessLayer.Repository;
using CarRentalSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.BusinessLayer.Service
{
    public class PaymentService: IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        // Constructor with dependency injection of the PaymentRepository
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        // Records a payment for a given lease
        public void RecordPayment(Lease lease, double amount)
        {
            // Call the repository method to record the payment
            _paymentRepository.RecordPayment(lease, amount);
        }

    }
}
