using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.DTO;
using UsersApp.Model;
using UsersApp.Repository;
using UsersApp.Transformer;

namespace UsersApp.Controller
{
    public class PersonController
    {
        private PersonRepository personRepository = new PersonRepository(); //TODO wstrzykiwanie zaleznosci

        public void Add(PersonDTO dto)
        {
            Person person = PersonTransformer.CreatePerson(dto);
            personRepository.Add(person);
        }

        public bool Remove(PersonDTO dto)
        {
            Person person = PersonTransformer.CreatePerson(dto);
            return personRepository.Remove(person);
        }

        public void Update(PersonDTO dto)
        {
            Person person = PersonTransformer.CreatePerson(dto);
            personRepository.Update(person);
        }

        public PersonDTO GetPersonById(Int64 id)
        {
            return null;
        }
    }
}
