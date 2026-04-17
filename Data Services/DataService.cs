using Microsoft.Data.SqlClient;
using FlightSystem.Models;

namespace FlightSystem.DataServices
{
    public class DataService
    {
        private string connectionString = "Server=.\\SQLEXPRESS;Database=FlightDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // LOGIN
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

        // GET FLIGHTS
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

        // ADD FLIGHT
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

        // DELETE FLIGHT
        public void DeleteFlight(string from, string to)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM Flights WHERE [From]=@f AND [To]=@t";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@f", from);
                    cmd.Parameters.AddWithValue("@t", to);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ADD USER
        public void AddUser(string username, string password, string role)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Users (Username, Password, Role) VALUES (@u, @p, @r)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);
                    cmd.Parameters.AddWithValue("@r", role);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // DELETE USER
        public void DeleteUser(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM Users WHERE Username=@u";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // CHANGE PASSWORD
        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username=@u AND Password=@p";

                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@u", username);
                    checkCmd.Parameters.AddWithValue("@p", oldPassword);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                        return false;
                }

                string updateQuery = "UPDATE Users SET Password=@newPass WHERE Username=@u";

                using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@newPass", newPassword);
                    updateCmd.Parameters.AddWithValue("@u", username);

                    updateCmd.ExecuteNonQuery();
                }
            }

            return true;
        }
    }
}