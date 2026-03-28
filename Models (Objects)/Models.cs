namespace FlightSystem.Models
{
    public class Flight
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Date { get; set; }
        public int Price { get; set; }
    }
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

}