using FlightSystem.AppServices;

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

            while (true)
            {
                Console.WriteLine("\n1 View Flights");

                if (user.Role == "Admin")
                {
                    Console.WriteLine("2 Add Flight");
                    Console.WriteLine("3 Delete Flight");
                    Console.WriteLine("4 Add User");
                    Console.WriteLine("5 Delete User");
                }

                Console.WriteLine("6 Change Password");
                Console.WriteLine("0 Exit");

                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    foreach (var f in app.GetFlights())
                    {
                        Console.WriteLine($"{f.From} -> {f.To} | {f.Date} | ₱{f.Price}");
                    }
                }
                else if (choice == "2" && user.Role == "Admin")
                {
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
                    Console.Write("Username: ");
                    string u = Console.ReadLine();

                    Console.Write("Password: ");
                    string p = Console.ReadLine();

                    Console.Write("Role (Admin/User): ");
                    string r = Console.ReadLine();

                    app.AddUser(u, p, r);
                }
                else if (choice == "5" && user.Role == "Admin")
                {
                    Console.Write("Username to delete: ");
                    string u = Console.ReadLine();

                    app.DeleteUser(u);
                }
                else if (choice == "6")
                {
                    Console.Write("Old Password: ");
                    string oldPass = Console.ReadLine();

                    Console.Write("New Password: ");
                    string newPass = Console.ReadLine();

                    bool success = app.ChangePassword(user.Username, oldPass, newPass);

                    if (success)
                        Console.WriteLine("Password changed successfully!");
                    else
                        Console.WriteLine("Incorrect old password.");
                }
                else if (choice == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                }
            }
        }
    }
}