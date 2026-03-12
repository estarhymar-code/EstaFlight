using System;
using FlightSystem.AppServices;

namespace FlightSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightAppService flightService = new FlightAppService();

            while (true)
            {
                Console.WriteLine("\n1 Add Flight");
                Console.WriteLine("2 View Flights");
                Console.WriteLine("0 Exit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("From: ");
                    string from = Console.ReadLine();

                    Console.Write("To: ");
                    string to = Console.ReadLine();

                    Console.Write("Date: ");
                    string date = Console.ReadLine();

                    Console.Write("Price: ");
                    int price = int.Parse(Console.ReadLine());

                    flightService.AddFlight(from, to, date, price);
                }
                else if (choice == "2")
                {
                    var flights = flightService.GetFlights();

                    foreach (var f in flights)
                    {
                        Console.WriteLine($"{f.From} -> {f.To} | {f.Date} | ₱{f.Price}");
                    }
                }
                else if (choice == "0")
                {
                    break;
                }
            }
        }
    }
}