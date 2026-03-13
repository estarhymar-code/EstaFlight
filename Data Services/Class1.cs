using System.Collections.Generic;
using FlightSystem.Models;

namespace FlightSystem.DataServices
{
    public class DataService
    {
        public List<Flight> Flights = new List<Flight>();
        public List<User> Users = new List<User>()
        {
            new User { Username = "admin", Password = "123", Role = "Admin" },
            new User { Username = "user", Password = "123", Role = "User" }
        };
    }
}
