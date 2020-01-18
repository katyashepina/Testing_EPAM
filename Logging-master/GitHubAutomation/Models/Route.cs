using System;

namespace TestAutomation.Models
{
    public class Route
    {
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Route(string departureCity, string arrivalCity, string email, string phoneNumber)
        {
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
