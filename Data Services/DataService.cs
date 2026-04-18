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

                string query = "SELECT Username, Password, Role FROM Users WHERE Username=@u AND Password=@p";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new User
                        {
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
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
                    var reader = cmd.ExecuteReader();

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

                string query = "INSERT INTO Flights ([From],[To],[Date],Price) VALUES (@f,@t,@d,@p)";

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

        public void AddUser(string username, string password, string role)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Users (Username,Password,Role) VALUES (@u,@p,@r)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);
                    cmd.Parameters.AddWithValue("@r", role);

                    cmd.ExecuteNonQuery();
                }
            }
        }

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

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT Username, Password, Role FROM Users";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Role = reader["Role"].ToString()
                        });
                    }
                }
            }

            return users;
        }

        public bool ChangePassword(string username, string oldPass, string newPass)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string check = "SELECT COUNT(*) FROM Users WHERE Username=@u AND Password=@p";

                using (SqlCommand cmd = new SqlCommand(check, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", oldPass);

                    int count = (int)cmd.ExecuteScalar();

                    if (count == 0) return false;
                }

                string update = "UPDATE Users SET Password=@n WHERE Username=@u";

                using (SqlCommand cmd = new SqlCommand(update, conn))
                {
                    cmd.Parameters.AddWithValue("@n", newPass);
                    cmd.Parameters.AddWithValue("@u", username);

                    cmd.ExecuteNonQuery();
                }
            }

            return true;
        }
    }
}