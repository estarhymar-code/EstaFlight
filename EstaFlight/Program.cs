using System;

namespace FlightSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string adminUser = "admin";
            string adminPass = "admin123";
            string normalUser = "user";
            string userPass = "user123";

            string[] from = { "MNL", "MNL", "MNL", "CEB", "MNL" };
            string[] to = { "CEB", "CEB", "DVO", "DVO", "CEB" };
            string[] date = { "08/04/2026", "08/04/2026", "09/04/2026", "08/04/2026", "08/04/2026" };
            string[] time = { "08:00 AM", "01:30 PM", "05:45 PM", "09:00 AM", "07:15 PM" };
            int[] price = { 2500, 3200, 4500, 2800, 2100 };

            while (true)
            {
                Console.WriteLine("\n==== Flight Booking System ====");
                Console.Write("From: ");
                string searchFrom = Console.ReadLine();

                Console.Write("To: ");
                string searchTo = Console.ReadLine();

                Console.Write("Departure Date (dd/mm/yyyy): ");
                string searchDate = Console.ReadLine();

                Console.Write("Round Trip? (y/n): ");
                string roundTrip = Console.ReadLine();

                Console.WriteLine("\nSort by price?");
                Console.WriteLine("1 Cheapest First");
                Console.WriteLine("2 Highest First");
                Console.Write("Choose: ");
                string sortChoice = Console.ReadLine();

                for (int i = 0; i < price.Length - 1; i++)
                {
                    for (int j = 0; j < price.Length - i - 1; j++)
                    {
                        bool swap = false;

                        if (sortChoice == "1" && price[j] > price[j + 1])
                            swap = true;
                        else if (sortChoice == "2" && price[j] < price[j + 1])
                            swap = true;

                        if (swap)
                        {
                            int tempPrice = price[j];
                            price[j] = price[j + 1];
                            price[j + 1] = tempPrice;

                            string tempFrom = from[j];
                            from[j] = from[j + 1];
                            from[j + 1] = tempFrom;

                            string tempTo = to[j];
                            to[j] = to[j + 1];
                            to[j + 1] = tempTo;

                            string tempDate = date[j];
                            date[j] = date[j + 1];
                            date[j + 1] = tempDate;

                            string tempTime = time[j];
                            time[j] = time[j + 1];
                            time[j + 1] = tempTime;
                        }
                    }
                }

                Console.WriteLine("\nAvailable Flights:\n");

                bool found = false;

                for (int i = 0; i < from.Length; i++)
                {
                    if (from[i] == searchFrom &&
                        to[i] == searchTo &&
                        date[i] == searchDate)
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("Route: " + from[i] + " -> " + to[i]);
                        Console.WriteLine("Date: " + date[i]);
                        Console.WriteLine("Time: " + time[i]);
                        Console.WriteLine("Price: ₱" + price[i]);
                        Console.WriteLine("--------------------------------\n");

                        found = true;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("No flights found.");
                }

                if (roundTrip.ToLower() == "y")
                {
                    Console.Write("\nReturn Date (dd/mm/yyyy): ");
                    string returnDate = Console.ReadLine();

                    Console.WriteLine("\nReturn Flights:\n");

                    for (int i = 0; i < from.Length; i++)
                    {
                        if (from[i] == searchTo &&
                            to[i] == searchFrom &&
                            date[i] == returnDate)
                        {
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("Route: " + from[i] + " -> " + to[i]);
                            Console.WriteLine("Date: " + date[i]);
                            Console.WriteLine("Time: " + time[i]);
                            Console.WriteLine("Price: ₱" + price[i]);
                            Console.WriteLine("--------------------------------\n");
                        }
                    }
                }

                Console.Write("\nSearch again? (y/n): ");
                if (Console.ReadLine().ToLower() != "y")
                    break;
            }
        }
    }
}