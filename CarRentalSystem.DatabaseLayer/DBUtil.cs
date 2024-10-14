using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CarRentalSystem.DatabaseLayer
{
    public static class DBUtil
    {
        public static SqlConnection getDBConnection()
        {
            SqlConnection conn;
            string connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Car;Integrated Security=True";
            conn = new SqlConnection();
            conn.ConnectionString = connectionstring;
            return conn;
        }

        public static class PropertyUtil
        {
            // Reads the property file and returns a dictionary of key-value pairs
            private static Dictionary<string, string> LoadProperties(string filePath)
            {
                var properties = new Dictionary<string, string>();

                // Read each line of the file
                foreach (var line in File.ReadAllLines(filePath))
                {
                    // Ignore comments and empty lines
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                        continue;

                    // Split by '=' to get the key-value pair
                    var parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        properties[parts[0].Trim()] = parts[1].Trim();
                    }
                }

                return properties;
            }

            // Method to build the connection string from the property file
            public static string GetPropertyString(string filePath)
            {
                var properties = LoadProperties(filePath);

                // Ensure all required properties are present
                if (!properties.ContainsKey("hostname") || !properties.ContainsKey("dbname") ||
                    !properties.ContainsKey("username") || !properties.ContainsKey("password") ||
                    !properties.ContainsKey("port"))
                {
                    throw new Exception("Missing required database connection details in properties file.");
                }

                // Construct the connection string
                string connectionString = $"Data Source={properties["hostname"]},{properties["port"]};" +
                                          $"Initial Catalog={properties["dbname"]};" +
                                          $"User ID={properties["username"]};" +
                                          $"Password={properties["password"]};";

                return connectionString;
            }




        }
    }
}



//Server name - (localdb)\MSSQLLocalDB