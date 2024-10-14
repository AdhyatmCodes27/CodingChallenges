using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.Entity;

namespace CarRentalSystem.DatabaseLayer
{
    public class CarRentalService
    {

        //public void GetAvailableCarDetails()
        //{
        //    // Use 'using' statement for automatic disposal of the connection and command.
        //    try
        //    {
        //        using (var conn = DBUtil.getDBConnection())
        //        {
        //            conn.Open();

        //            // Define the query to fetch employee details (assuming the table is Employee).
        //            string query = "SELECT VehicleID, Make, Model, DailyRate, Status, PassengerCapacity FROM Vehicle";

        //            using (SqlCommand cmd = new SqlCommand(query, conn))
        //            {
        //                using (SqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    Console.WriteLine("Vehicle ID\tMake\t\tModel\t\t\tDailyRate\t\tStatus\t\tPassengerCapacity");

        //                    // Reading and displaying the employee details from the query.
        //                    while (reader.Read())
        //                    {
        //                        Console.WriteLine(
        //                            $"{reader["VehicleID"]}\t\t{reader["Make"]}\t\t{reader["Model"]}\t\t" +
        //                            $"{reader["DailyRate"]}\t\t{reader["Status"]}\t\t{reader["PassengerCapacity"]}");
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        // Handle database exceptions, such as connection errors or query issues.
        //        Console.WriteLine("An error occurred while fetching available car  details: " + ex.Message);
        //    }

        //}


        public void GetCar()
        {
            try
            {
                var conn = DBUtil.getDBConnection();
                conn.Open();

                // SQL query to get the employee with the maximum salary
                string query = "SELECT VehicleID, Make, Model, DailyRate, Status, PassengerCapacity FROM Vehicle WHERE VehicleID=6";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine($"\nCar with: (ID: {reader["VehicleID"]}) {reader["Make"]} {reader["Model"]} , is {reader["Status"]} ");
                        }
                    }
                }

                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error while retrieving car: " + ex.Message);
            }
        }


    }
}
