using FlightSystem.AppServices;
using FlightSystem.Models;

namespace FlightSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            AppService app = new AppService();

            while (true) 
            {
                User user = null;

                // LOGIN 
                while (user == null)
                {
                    Console.WriteLine("\n1 Login");
                    Console.WriteLine("2 Create Account");
                    Console.Write("Choose: ");
                    string firstChoice = Console.ReadLine();

                    if (firstChoice == "1")
                    {
                        Console.Write("Username: ");
                        string username = Console.ReadLine();

                        Console.Write("Password: ");
                        string password = Console.ReadLine();

                        user = app.Login(username, password);

                        if (user == null)
                            Console.WriteLine("Invalid login. Try again.");
                    }
                    else if (firstChoice == "2")
                    {
                        Console.Write("New Username: ");
                        string username = Console.ReadLine();

                        Console.Write("New Password: ");
                        string password = Console.ReadLine();

                        app.AddUser(username, password, "User");
                        Console.WriteLine("Account created!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice.");
                    }
                }

                Console.WriteLine($"\nWelcome {user.Username} ({user.Role})");

          
                while (true)
                {
                    Console.WriteLine("\n1 View Flights");

                    if (user.Role == "Admin")
                    {
                        Console.WriteLine("2 Add Flight");
                        Console.WriteLine("3 Delete Flight");
                        Console.WriteLine("4 View Users");
                        Console.WriteLine("5 Add User");
                        Console.WriteLine("6 Delete User");
                        Console.WriteLine("7 Switch User");
                    }
                    else
                    {
                        Console.WriteLine("2 Change Password");
                        Console.WriteLine("3 Switch User");
                    }

                    Console.WriteLine("0 Exit");

                    Console.Write("Choose: ");
                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        foreach (var f in app.GetFlights())
                            Console.WriteLine($"{f.From} -> {f.To} | {f.Date} | ₱{f.Price}");
                    }
                    else if (choice == "2" && user.Role == "Admin")
                    {
                        Console.Write("From: ");
                        string from = Console.ReadLine();

                        Console.Write("To: ");
                        string to = Console.ReadLine();

                        Console.Write("Date: ");
                        string date = Console.ReadLine();

                        int price;
                        Console.Write("Price: ");
                        while (!int.TryParse(Console.ReadLine(), out price))
                            Console.Write("Invalid number. Enter again: ");

                        app.AddFlight(from, to, date, price);
                    }
                    else if (choice == "3" && user.Role == "Admin")
                    {
                        Console.Write("From: ");
                        string from = Console.ReadLine();

                        Console.Write("To: ");
                        string to = Console.ReadLine();

                        app.DeleteFlight(from, to);
                    }
                    else if (choice == "4" && user.Role == "Admin")
                    {
                        foreach (var u in app.GetUsers())
                            Console.WriteLine($"{u.Username} | {u.Password} | {u.Role}");
                    }
                    else if (choice == "5" && user.Role == "Admin")
                    {
                        Console.Write("Username: ");
                        string u = Console.ReadLine();

                        Console.Write("Password: ");
                        string p = Console.ReadLine();

                        Console.Write("Role: ");
                        string r = Console.ReadLine();

                        app.AddUser(u, p, r);
                    }
                    else if (choice == "6" && user.Role == "Admin")
                    {
                        Console.Write("Username: ");
                        string u = Console.ReadLine();

                        app.DeleteUser(u);
                    }
                    else if (choice == "2" && user.Role != "Admin")
                    {
                        Console.Write("Old Password: ");
                        string oldPass = Console.ReadLine();

                        Console.Write("New Password: ");
                        string newPass = Console.ReadLine();

                        if (app.ChangePassword(user.Username, oldPass, newPass))
                            Console.WriteLine("Password changed!");
                        else
                            Console.WriteLine("Wrong password.");
                    }
                    else if ((choice == "7" && user.Role == "Admin") ||
                             (choice == "3" && user.Role != "Admin"))
                    {
                        Console.WriteLine("Logging out...");
                        break; // goes back to login
                    }
                    else if (choice == "0")
                    {
                        return; // exit program
                    }
                    else
                    {
                        Console.WriteLine("Invalid option.");
                    }
                }
            }
        }
    }
}