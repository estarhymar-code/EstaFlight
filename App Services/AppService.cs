using FlightSystem.DataServices;
using FlightSystem.Models;

namespace FlightSystem.AppServices
{
    public class AppService
    {
        private DataService data = new DataService();

        public User Login(string username, string password)
        {
            return data.Login(username, password);
        }

        public List<Flight> GetFlights()
        {
            return data.GetFlights();
        }

        public void AddFlight(string from, string to, string date, int price)
        {
            data.AddFlight(from, to, date, price);
        }

        public void DeleteFlight(string from, string to)
        {
            data.DeleteFlight(from, to);
        }

        public void AddUser(string username, string password, string role)
        {
            data.AddUser(username, password, role);
        }

        public void DeleteUser(string username)
        {
            data.DeleteUser(username);
        }

        public List<User> GetUsers()
        {
            return data.GetUsers();
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return data.ChangePassword(username, oldPassword, newPassword);
        }
    }
}