using UsersApp.DTO;
using UsersApp.Model;

namespace UsersApp.Transformer
{
    public class PersonTransformer
    {
        private PersonTransformer()
        {

        }

        public static Person CreatePerson(PersonDTO dto)
        {
            Person entity = new Person();
            entity.id = dto.id;

            entity.firstName = dto.firstName;
            entity.lastName = dto.lastName;
            entity.streetName = dto.streetName;
            entity.houseNumber = dto.houseNumber;
            entity.apartmentNumber = dto.apartmentNumber;
            entity.postalCode = dto.postalCode;
            entity.town = dto.town;
            entity.phoneNumber = dto.phoneNumber;
            entity.birthdate = dto.birthdate;
            return entity;
        }

        public static PersonDTO CreatePersonDTO(Person entity)
        {
            PersonDTO dto = new PersonDTO(entity.id);
            dto.firstName = entity.firstName;
            dto.lastName = entity.lastName;
            dto.streetName = entity.streetName;
            dto.houseNumber = entity.houseNumber;
            dto.apartmentNumber = entity.apartmentNumber;
            dto.postalCode = entity.postalCode;
            dto.town = entity.town;
            dto.phoneNumber = entity.phoneNumber;
            dto.birthdate = entity.birthdate;
            return dto;
        }
    }
}
