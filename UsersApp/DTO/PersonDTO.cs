using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp.DTO
{
    public class PersonDTO
    {
        public Int64 id { get; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String streetName { get; set; }
        public String houseNumber { get; set; }
        public String apartmentNumber { get; set; }
        public String postalCode { get; set; }
        public String town { get; set; }
        public String phoneNumber { get; set; }
        public DateTime birthdate { get; set; }
        
        public int age { get { return DateTime.Now.Year - this.birthdate.Year; } } //TODO tymczasowe obliczenia
        private bool edited;

        public PersonDTO(Int64 id)
        { 
            this.id = id;
            this.edited = false;
        }

        public bool IsEdited()
        {
            return this.edited;
        }

        public void SetEditedTrue()
        {
            this.edited = true;
        }
    }
}
