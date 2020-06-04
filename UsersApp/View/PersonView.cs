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
            this.LoadFromController();
        }

        public void SaveChanges()
        {
            bool wasSuccesful = true;
            foreach(PersonDTO personDTO in peopleDTOs)
            {
                if (personDTO.IsToRemove())
                {
                    personController.Remove(personDTO);
                    continue;
                }

                ValidationResponse validation = PersonDTOValidator.IsValid(personDTO);
                if (validation.valid)
                {
                    if (personDTO.id == PersonDTO.NEW_PERSON_ID)
                        personController.Add(personDTO);
                    else if (personDTO.IsEdited())
                        personController.Update(personDTO);
                }
                else
                {
                    wasSuccesful = false;
                    ShowInvalidPerson(personDTO, validation.message);
                }
            }
            if (wasSuccesful)
                this.ReloadFromController();
        }

        public void EditedPerson(int indexInTable)
        {
            peopleDTOs[indexInTable].SetEditedTrue();
        }

        public void RemovePerson(int indexInTable)
        {
            peopleDTOs[indexInTable].SetToRemove();
        }

        private void ShowInvalidPerson(PersonDTO personDTO, String errorMessage)
        {
            MessageBox.Show("Person \"" + personDTO.firstName + " " + personDTO.lastName + "\" has following error:\n" + errorMessage, "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void CancelChanges()
        {
            this.ReloadFromController();
        }

        private void LoadFromController()
        {
            personController.GetPeople().ForEach(item => peopleDTOs.Add(item));
        }

        private void ReloadFromController()
        {
            peopleDTOs.Clear();
            this.LoadFromController();
        }

        public void SaveUserData()
        {
            personController.SaveUserData();
        }

        public void ReloadUserData()
        {
            personController.ReloadUserData();
            this.ReloadFromController();
        }
    }
}
