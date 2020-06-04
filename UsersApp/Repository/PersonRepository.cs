using System;
using System.Collections.Generic;
using System.Linq;
using UsersApp.Exceptions;
using UsersApp.Model;
using UsersApp.Model.XML;
using UsersApp.Session;

namespace UsersApp.Repository
{
    class PersonRepository 
    {
        private List<Person> people = new List<Person>();

        public void Add(Person person)
        {
            person.id = this.FindFreeId();
            people.Add(person);
        }

        public void AddAll(ICollection<Person> people)
        {
            foreach (Person person in people)
                this.Add(person);
        }

        public bool Remove(Person person)
        {
            try
            {
                Person toRemove = this.GetPersonById(person.id);
                return people.Remove(toRemove);
            }
            catch (PersonNotFoundException)
            {
                return false;
            }
        } 

        public bool Update(Person person)
        {
            try
            {
                Person toEdit = this.GetPersonById(person.id);
                this.SetFields(toEdit, person);
                return true;
            }
            catch (PersonNotFoundException)
            {
                return false;
            }
        }

        public Person GetPersonById(Int64 id)
        {
            try 
            { 
                return people.First(item => item.id.Equals(id));
            } 
            catch (InvalidOperationException)
            {
                throw new PersonNotFoundException();
            }
        }

        public List<Person> GetPeople()
        {
            return new List<Person>(people);
        }


        private void SetFields(Person destination, Person source)
        {
            destination.firstName = source.firstName;
            destination.lastName = source.lastName;
            destination.streetName = source.streetName;
            destination.houseNumber = source.houseNumber;
            destination.apartmentNumber = source.apartmentNumber;
            destination.postalCode = source.postalCode;
            destination.town = source.town;
            destination.phoneNumber = source.phoneNumber;
            destination.birthdate = source.birthdate;
        }

        public void ReloadDataOfCurrentUser()
        {
            people.Clear();
            String filename = UserSession.GetInstance().currentUser.filepath;
            LoadFromFile(filename);
        }

        public void SaveDataOfCurrentUser()
        {
            String filename = UserSession.GetInstance().currentUser.filepath;
            SaveToFile(filename);
        }

        private void SaveToFile(String filename)
        {
            PersonXML.WriteToFile(people, filename);
        }

        private void LoadFromFile(String filename)
        {
            this.AddAll(PersonXML.ReadFromFile(filename));
        }

        private Int64 FindFreeId()
        {
            Int64[] blockedIds = new Int64[people.Count()];
            for (int i = 0; i < people.Count(); ++i)
            {
                blockedIds[i] = people[i].id;
            }

            Array.Sort(blockedIds);
            if (blockedIds.Length == 0)
                return 0;
            for (int i = 0; i < blockedIds.Length; ++i)
            {
                if (i == blockedIds.Length - 1)
                    return blockedIds[i] + 1;
                else if (blockedIds[i] + 1 != blockedIds[i+1])
                    return blockedIds[i] + 1;
            }

            return 0;
        }
    }
}
