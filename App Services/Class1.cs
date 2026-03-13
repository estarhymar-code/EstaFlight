using System.Linq;
using System.Collections.Generic;
using FlightSystem.Models;
using FlightSystem.DataServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlightSystem.AppServices
{
    public class AppService
    {
        private DataService data = new DataService();
        public User Login(string username, string password)
        {
            return data.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);
        }
        public void AddFlight(string from, string to, string date, int price)
        {
            data.Flights.Add(new Flight
            {
                From = from,
                To = to,
                Date = date,
                Price = price
            });
        }

        public List<Flight> GetFlights()
        {
            return data.Flights;
        }
    }
}
