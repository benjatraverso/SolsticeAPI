namespace Solstice.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Contact
    {
        public double Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public string Country { get; set; }
        public int CountryCode { get; set; }
        public string State { get; set; }
        public int StateCode { get; set; }
        public string City { get; set; }
        public int CityCode { get; set; }
        public string Street { get; set; }
        public string AppartmentNumber { get; set; }
        public string AdditionalInfo { get; set; }
    }
}