using System;
using System.Collections.ObjectModel;
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
            this.LoadDataFromController();
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
                this.ReloadDataFromController();
        }

        public void SetEditedPersonId(int indexInTable)
        {
            peopleDTOs[indexInTable].SetEditedTrue();
        }

        public void SetRemovePersonId(int indexInTable)
        {
            peopleDTOs[indexInTable].SetToRemove();
        }

        public void CancelChanges()
        {
            this.ReloadDataFromController();
        }

        private void LoadDataFromController()
        {
            personController.GetPeople().ForEach(item => peopleDTOs.Add(item));
        }

        private void ReloadDataFromController()
        {
            peopleDTOs.Clear();
            this.LoadDataFromController();
        }

        public void SaveUserData()
        {
            personController.SaveUserData();
        }

        public void ReloadUserData()
        {
            personController.ReloadUserData();
            this.ReloadDataFromController();
        }

        private void ShowInvalidPerson(PersonDTO personDTO, String errorMessage)
        {
            MessageBox.Show("Person \"" + personDTO.firstName + " " + personDTO.lastName + "\" has following error:\n" + errorMessage, "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
