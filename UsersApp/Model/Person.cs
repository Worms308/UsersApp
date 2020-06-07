using System;

namespace UsersApp.Model
{
    public class Person
    {
        public Int64 id { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String streetName { get; set; }
        public String houseNumber { get; set; }
        public String apartmentNumber { get; set; }
        public String postalCode { get; set; }
        public String town { get; set; }
        public String phoneNumber { get; set; }
        public DateTime birthdate { get; set; }
    }
}
