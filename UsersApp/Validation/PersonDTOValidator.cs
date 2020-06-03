using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UsersApp.DTO;

namespace UsersApp.Validation
{
    class PersonDTOValidator
    {
        public static ValidationResponse isValid(PersonDTO personDTO)
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
            if (!isPostalCodeValid(personDTO.postalCode))
                return new ValidationResponse(false, "Invalid postal code (should be like xx-xxx)");
            if (String.IsNullOrEmpty(personDTO.town))
                return new ValidationResponse(false, "Missing town");
            if (String.IsNullOrEmpty(personDTO.phoneNumber))
                return new ValidationResponse(false, "Missing phone number");
            if (!isPhoneNumberValid(personDTO.phoneNumber))
                return new ValidationResponse(false, "Invalid phone number");
            if (personDTO.birthdate == null)
                return new ValidationResponse(false, "Missing birth date");

            return new ValidationResponse(true, "OK");
        }

        private static bool isPhoneNumberValid(String phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"(?<!\w)(\(?(\+|00)?48\)?)?[ -]?\d{3}[ -]?\d{3}[ -]?\d{3}(?!\w)");
        }

        private static bool isPostalCodeValid(String postalCode)
        {
            return Regex.IsMatch(postalCode, @"\d{2}-\d{3}$");
        }
    }
}
