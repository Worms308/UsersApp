using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UsersApp.Controller;
using UsersApp.DTO;
using UsersApp.Validation;

namespace UsersApp.View
{
    class PersonView
    {
        public ObservableCollection<PersonDTO> peopleDTOs { get; }
        private PersonController personController = new PersonController();

        public PersonView()
        {
            peopleDTOs = new ObservableCollection<PersonDTO>();

            PersonDTO newPerson = new PersonDTO()
            {
                firstName = "Mariusz",
                lastName = "Nowak",
                streetName = "Wiejska",
                houseNumber = "123a",
                apartmentNumber = "a321",
                postalCode = "01-001",
                town = "Warszawa",
                phoneNumber = "123456789",
                birthdate = new DateTime(1996, 06, 02)
            };
            personController.Add(newPerson);

            PersonDTO newPerson2 = new PersonDTO()
            {
                firstName = "Jan",
                lastName = "Kowalski",
                streetName = "Wiejska",
                houseNumber = "123a",
                postalCode = "01-001",
                town = "Warszawa",
                phoneNumber = "123456789",
                birthdate = new DateTime(1996, 06, 02)
            };
            personController.Add(newPerson2);
        }

        public void SaveChanges()
        {
            foreach(PersonDTO personDTO in peopleDTOs)
            {
                ValidationResponse validation = PersonDTOValidator.isValid(personDTO);
                if (validation.valid)
                {
                    if (personDTO.IsEdited())
                        personController.Update(personDTO);
                    if (personDTO.id == PersonDTO.NEW_PERSON_ID)
                        personController.Add(personDTO);
                }
                else
                {
                    ShowInvalidPerson(personDTO, validation.message);
                }
                    
            }
        }

        private void ShowInvalidPerson(PersonDTO personDTO, String errorMessage)
        {
            MessageBox.Show("Person \"" + personDTO.firstName + " " + personDTO.lastName + "\" has following error:\n" + errorMessage, "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void CancelChanges()
        {
            peopleDTOs.Clear();
            personController.GetPeople().ForEach(item => peopleDTOs.Add(item));
        }

    }
}
