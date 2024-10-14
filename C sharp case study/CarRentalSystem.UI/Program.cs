using CarRentalSystem.BusinessLayer.MyExceptions;
using CarRentalSystem.BusinessLayer.Repository;
using CarRentalSystem.BusinessLayer.Service;
using CarRentalSystem.DatabaseLayer;
using CarRentalSystem.Entity;
using System;
using System.Collections.Generic;
using static CarRentalSystem.DatabaseLayer.DBUtil;

namespace CarRentalSystem.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create in-memory collections for vehicles and customers
                var vehicles = new List<Vehicle>
                {
                    new Vehicle { VehicleID = 1, Make = "Toyota", Model = "Camry", Year = 2020, DailyRate = 50, Status = "available", PassengerCapacity = 5, EngineCapacity = 2.5 },
                    new Vehicle { VehicleID = 2, Make = "Honda", Model = "Civic", Year = 2021, DailyRate = 40, Status = "available", PassengerCapacity = 5, EngineCapacity = 1.8 }
                };

                var customers = new List<Customer>
                {
                    new Customer { CustomerID = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "1234567890" },
                    new Customer { CustomerID = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PhoneNumber = "0987654321" }
                };

                // Create repository instances
                IVehicleRepository vehicleRepository = new VehicleRepository(vehicles);
                ICustomerRepository customerRepository = new CustomerRepository(customers);
                ILeaseRepository leaseRepository = new LeaseRepository(vehicles, customers);
                IPaymentRepository paymentRepository = new PaymentRepository();

                // Create service instances
                IVehicleService vehicleService = new VehicleService(vehicleRepository);
                ICustomerService customerService = new CustomerService(customerRepository);
                ILeaseService leaseService = new LeaseService(leaseRepository);
                IPaymentService paymentService = new PaymentService(paymentRepository);

                // Simulate business operations:

                // 1. List available cars
                //Console.WriteLine("Available Cars:");
                //foreach (var car in vehicleService.ListAvailableCars())
                //{
                //    Console.WriteLine($"Car ID: {car.VehicleID}, Make: {car.Make}, Model: {car.Model}, Daily Rate: {car.DailyRate}");
                //}

                // 2. Add a new lease
                Console.WriteLine("\nCreating a new lease...");
                Lease lease = leaseService.CreateLease(1, 1, DateTime.Now, DateTime.Now.AddDays(5)); // Lease for 5 days
                Console.WriteLine($"Lease Created: Lease ID: {lease.LeaseID}, Customer ID: {lease.CustomerID}, Vehicle ID: {lease.VehicleID}, Start Date: {lease.StartDate}, End Date: {lease.EndDate}");

                // 3. Record a payment for the lease
                Console.WriteLine("\nRecording a payment...");
                paymentService.RecordPayment(lease, 250); // Payment of $250 for the lease
                Console.WriteLine("Payment recorded successfully.");

                // 4. Return the car after lease ends
                Console.WriteLine("\nReturning the car...");
                Lease returnedLease = leaseService.ReturnCar(lease.LeaseID);
                Console.WriteLine($"Car with Vehicle ID {returnedLease.VehicleID} returned successfully.");

                // 5. List all active leases (should be empty now since the car is returned)
                Console.WriteLine("\nActive Leases:");
                var activeLeases = leaseService.ListActiveLeases();
                if (activeLeases.Count == 0)
                {
                    Console.WriteLine("No active leases.");
                }

                // 6. List the full lease history
                Console.WriteLine("\nLease History:");
                foreach (var l in leaseService.ListLeaseHistory())
                {
                    Console.WriteLine($"Lease ID: {l.LeaseID}, Customer ID: {l.CustomerID}, Vehicle ID: {l.VehicleID}, Start Date: {l.StartDate}, End Date: {l.EndDate}");
                }

                // End of simulation
                Console.WriteLine("\nSimulation complete.");

                // DATABASE CONNECTION

                string propertiesFilePath = "C:\\Users\\Adhyatm\\Desktop\\dbconfig.properties.txt";
                string connectionString = PropertyUtil.GetPropertyString(propertiesFilePath);
                Console.WriteLine("\nConnection String: " + connectionString);

                // Call service to interact with DB (example usage)
                CarRentalService carrentalServiceDb = new CarRentalService();
                carrentalServiceDb.GetCar();


                Console.WriteLine("Enter Car ID to search:");

                int vehicleID = int.Parse(Console.ReadLine());
                foreach (var car in vehicleService.ListAvailableCars())
                {
                    Console.WriteLine($"Car ID: {car.VehicleID}, Make: {car.Make}, Model: {car.Model}, Daily Rate: {car.DailyRate}");
                }
                //var car = vehicleService.ListAvailableCars();
                //Console.WriteLine($"Car Found: {car.Make} {car.Model}");


                Console.WriteLine("Enter Customer ID to search:");
                int customerID = int.Parse(Console.ReadLine());
                var customer = customerService.FindCustomerById(customerID);
                Console.WriteLine($"Customer Found: {customer.FirstName} {customer.LastName}");

            }
            catch (CarNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (LeaseNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (CustomerNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }


            Console.ReadKey();  
        }
    }
}
