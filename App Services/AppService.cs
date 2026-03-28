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
    }
}