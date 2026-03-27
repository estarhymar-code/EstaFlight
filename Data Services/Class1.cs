using System.Collections.Generic;
using System.Text.Json;
using FlightSystem.Models;

namespace FlightSystem.DataServices
{
    public class DataService
    {
        private string filePath = "flights.json";

        public List<Flight> GetFlights()
        {
            if (!File.Exists(filePath))
                return new List<Flight>();

            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<Flight>>(json);
        }
        public void SaveFlights(List<Flight> flights)
        {
            string json = JsonSerializer.Serialize(flights, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(filePath, json);
        }
        private string userFile = "users.json";

        public List<User> GetUsers()
        {
            if (!File.Exists(userFile))
                return new List<User>();

            string json = File.ReadAllText(userFile);
            return JsonSerializer.Deserialize<List<User>>(json);
        }
    }
}
