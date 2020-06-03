using System;
using System.Collections.Generic;
using UsersApp.DTO;
using UsersApp.Model;
using UsersApp.Repository;
using UsersApp.Transformer;

namespace UsersApp.Controller
{
    public class PersonController
    {
        private readonly PersonRepository personRepository = new PersonRepository(); //TODO wstrzykiwanie zaleznosci

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
            Person person = personRepository.GetPersonById(id);
            return PersonTransformer.CreatePersonDTO(person);
        }

        public List<PersonDTO> GetPeople()
        {
            List<Person> people = personRepository.GetPeople();
            return people.ConvertAll(item => PersonTransformer.CreatePersonDTO(item));
        }

    }
}
