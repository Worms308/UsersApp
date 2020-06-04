using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp.DTO
{
    public class PersonDTO
    {
        public static readonly Int64 NEW_PERSON_ID = -1;
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
        
        public int age { get { return (int)((DateTime.Today - birthdate).Days / 365.25); } }

        private bool edited = false;
        private bool toRemove = false;

        public PersonDTO(Int64 id)
        { 
            this.id = id;
        }

        public PersonDTO()
        {
            this.id = NEW_PERSON_ID;
        }

        public bool IsEdited()
        {
            return this.edited;
        }

        public void SetEditedTrue()
        {
            this.edited = true;
        }

        public bool IsToRemove()
        {
            return this.toRemove;
        }

        public void SetToRemove()
        {
            this.toRemove = true;
        }
    }
}
