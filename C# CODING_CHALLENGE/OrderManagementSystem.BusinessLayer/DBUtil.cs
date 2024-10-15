using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OrderManagementSystem.BusinessLayer
{
    public static class DBUtil
    {
        public static SqlConnection getDBConnection()
        {
            string connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OMS;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionstring);
            try
            {
                conn.Open(); // Open the connection
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Could not establish a connection: " + ex.Message);
                return null; // Return null if connection fails
            }
            return conn; // Return the open connection
        }
    }
}