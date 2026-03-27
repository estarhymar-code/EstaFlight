using System;
using FlightSystem.AppServices;
using FlightSystem.DataServices;
using FlightSystem.Models;

namespace FlightSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            AppService app = new AppService();

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            var user = app.Login(username, password);

            if (user == null)
            {
                Console.WriteLine("Invalid login");
                return;
            }

            Console.WriteLine("Welcome " + user.Username);

            if (user.Role == "Admin")
            {
                Console.WriteLine("Add a flight");

                Console.Write("From: ");
                string from = Console.ReadLine();

                Console.Write("To: ");
                string to = Console.ReadLine();

                Console.Write("Date: ");
                string date = Console.ReadLine();

                Console.Write("Price: ");
                int price = int.Parse(Console.ReadLine());

                app.AddFlight(from, to, date, price);
            }

            Console.WriteLine("\nFlights:");

            foreach (var f in app.GetFlights())
            {
                Console.WriteLine($"{f.From} -> {f.To} | {f.Date} | ₱{f.Price}");
            }
        }
    }
}
