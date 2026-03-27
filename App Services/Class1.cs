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
            var users = data.GetUsers();

            return users.FirstOrDefault(u =>
                u.Username == username && u.Password == password
            );
        }
        public void AddFlight(string from, string to, string date, int price)
        {
            var flights = data.GetFlights();

            flights.Add(new Flight
            {
                From = from,
                To = to,
                Date = date,
                Price = price
            });
            data.SaveFlights(flights);
        }

        public List<Flight> GetFlights()
        {
            return data.GetFlights();
        }
    }
}
