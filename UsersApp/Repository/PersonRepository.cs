using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Model;

namespace UsersApp.Repository
{
    class PersonRepository 
    {
        private LinkedList<Person> people = new LinkedList<Person>();

        public void Add(Person person)
        {
            person.id = people.Count;
            people.AddLast(person);
        }

        public bool Remove(Person person)
        {
            return people.Remove(person);
        } 

        public void Update(Person person)
        {
            Person toRemove = people.First(item => item.id.Equals(person.id));
            this.Remove(toRemove);
            this.Add(person); //TODO do poprawy ten element
        }

        public Person GetPersonById(Int64 id)
        {
            return people.First(item => item.id.Equals(id));
        }

        public LinkedList<Person> GetPeople()
        {
            return new LinkedList<Person>(people);
        }
    }
}
