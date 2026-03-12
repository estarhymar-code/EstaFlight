using System.Collections.Generic;
using FlightSystem.Models;
using FlightSystem.DataServices;

namespace FlightSystem.AppServices
{
    public class FlightAppService
    {
        private FlightDataService dataService = new FlightDataService();

        public void AddFlight(string from, string to, string date, int price)
        {
            Flight flight = new Flight
            {
                From = from,
                To = to,
                Date = date,
                Price = price
            };

            dataService.AddFlight(flight);
        }

        public List<Flight> GetFlights()
        {
            return dataService.GetFlights();
        }
    }
}
