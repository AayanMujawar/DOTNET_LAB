using MySql.Data.MySqlClient;
using System;

class Program
{
    static void Main()
    {
        string connectionString = "server=localhost;user=root;password=manager;database=testdb;";

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                Console.WriteLine("Connected Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
