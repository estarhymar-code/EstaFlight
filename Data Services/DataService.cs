using Microsoft.Data.SqlClient;
using FlightSystem.Models;

namespace FlightSystem.DataServices
{
    public class DataService
    {
        private string connectionString = "Server=.\\SQLEXPRESS;Database=FlightDB1;Trusted_Connection=True;TrustServerCertificate=True;";

        public User Login(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT Username, Role FROM Users WHERE Username=@u AND Password=@p";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new User
                        {
                            Username = reader["Username"].ToString(),
                            Role = reader["Role"].ToString()
                        };
                    }
                }
            }

            return null;
        }

        public List<Flight> GetFlights()
        {
            List<Flight> flights = new List<Flight>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT [From], [To], [Date], Price FROM Flights";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        flights.Add(new Flight
                        {
                            From = reader["From"].ToString(),
                            To = reader["To"].ToString(),
                            Date = reader["Date"].ToString(),
                            Price = (int)reader["Price"]
                        });
                    }
                }
            }

            return flights;
        }

        public void AddFlight(string from, string to, string date, int price)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Flights ([From], [To], [Date], Price) VALUES (@f, @t, @d, @p)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@f", from);
                    cmd.Parameters.AddWithValue("@t", to);
                    cmd.Parameters.AddWithValue("@d", date);
                    cmd.Parameters.AddWithValue("@p", price);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}