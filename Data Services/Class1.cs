using System.Collections.Generic;
using FlightSystem.Models;

namespace FlightSystem.DataServices
{
    public class FlightDataService
    {
        private List<Flight> flights = new List<Flight>();

        public void AddFlight(Flight flight)
        {
            flights.Add(flight);
        }

        public List<Flight> GetFlights()
        {
            return flights;
        }
    }
}
