using System;
using System.Text.RegularExpressions;
using UsersApp.DTO;

namespace UsersApp.Validation
{
    class PersonDTOValidator
    {
        public static ValidationResponse IsValid(PersonDTO personDTO)
        {
            if (String.IsNullOrEmpty(personDTO.firstName))
                return new ValidationResponse(false, "Missing first name");
            if (String.IsNullOrEmpty(personDTO.lastName))
                return new ValidationResponse(false, "Missing last name");
            if (String.IsNullOrEmpty(personDTO.streetName))
                return new ValidationResponse(false, "Missing street name");
            if (String.IsNullOrEmpty(personDTO.houseNumber))
                return new ValidationResponse(false, "Missing house number");
            if (String.IsNullOrEmpty(personDTO.postalCode))
                return new ValidationResponse(false, "Missing postal code");
            if (!IsPostalCodeValid(personDTO.postalCode))
                return new ValidationResponse(false, "Invalid postal code (should be like xx-xxx)");
            if (String.IsNullOrEmpty(personDTO.town))
                return new ValidationResponse(false, "Missing town");
            if (String.IsNullOrEmpty(personDTO.phoneNumber))
                return new ValidationResponse(false, "Missing phone number");
            if (!IsPhoneNumberValid(personDTO.phoneNumber))
                return new ValidationResponse(false, "Invalid phone number");
            if (personDTO.birthdate == null)
                return new ValidationResponse(false, "Missing birth date");
            if (!IsBirthDateValid(personDTO.birthdate))
                return new ValidationResponse(false, "Birth date cannot be from the future");

            return new ValidationResponse(true, "OK");
        }

        private static bool IsPhoneNumberValid(String phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"(?<!\w)(\(?(\+|00)?48\)?)?[ -]?\d{3}[ -]?\d{3}[ -]?\d{3}(?!\w)");
        }

        private static bool IsPostalCodeValid(String postalCode)
        {
            return Regex.IsMatch(postalCode, @"\d{2}-\d{3}$");
        }

        private static bool IsBirthDateValid(DateTime birthdate)
        {
            return birthdate < DateTime.Now;
        }
    }
}
