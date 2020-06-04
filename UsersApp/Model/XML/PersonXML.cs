using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UsersApp.Model.XML
{
    public class PersonXML
    {
        private static XmlWriterSettings xmlWriterSettings = new XmlWriterSettings()
        {
            Indent = true,
            IndentChars = "\t",
            NewLineOnAttributes = true
        };

        public static List<Person> ReadFromFile(String filename)
        {
            List<Person> people = new List<Person>();
            using (XmlReader reader = XmlReader.Create("profiles\\" + filename))
            {
                ReadPeople(people, reader);
            }
            return people;
        }

        public static void WriteToFile(List<Person> people, String filename)
        {
            using (XmlWriter writer = XmlWriter.Create("profiles\\" + filename, xmlWriterSettings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("People");

                WritePeople(people, writer);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private static void ReadPeople(List<Person> people, XmlReader reader)
        {
            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Person"))
                {
                    Person person = new Person();
                    ReadPerson(reader, person);
                    people.Add(person);
                }
            }
        }

        private static void ReadPerson(XmlReader reader, Person person)
        {
            while (reader.NodeType != XmlNodeType.EndElement && reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element))
                {
                    FillPersonField(reader, person);
                }
            }
        }

        private static void FillPersonField(XmlReader reader, Person person)
        {
            if (reader.Name == "FirstName")
                person.firstName = reader.ReadElementContentAsString();
            else if (reader.Name == "LastName")
                person.lastName = reader.ReadElementContentAsString();
            else if (reader.Name == "StreetName")
                person.streetName = reader.ReadElementContentAsString();
            else if (reader.Name == "HouseNumber")
                person.houseNumber = reader.ReadElementContentAsString();
            else if (reader.Name == "ApartmentNumber")
                person.apartmentNumber = reader.ReadElementContentAsString();
            else if (reader.Name == "PostalCode")
                person.postalCode = reader.ReadElementContentAsString();
            else if (reader.Name == "Town")
                person.town = reader.ReadElementContentAsString();
            else if (reader.Name == "PhoneNumber")
                person.phoneNumber = reader.ReadElementContentAsString();
            else if (reader.Name == "LastName")
                person.lastName = reader.ReadElementContentAsString();
            else if (reader.Name == "BirthDate")
                person.birthdate = DateTime.Parse(reader.ReadElementContentAsString());
        }

        private static void WritePeople(List<Person> people, XmlWriter writer)
        {
            foreach (Person person in people)
            {
                WritePerson(person, writer);
            }
        }

        private static void WritePerson(Person person, XmlWriter writer)
        {
            writer.WriteStartElement("Person");

            writer.WriteStartElement("FirstName");
            writer.WriteString(person.firstName);
            writer.WriteEndElement();
            writer.WriteStartElement("LastName");
            writer.WriteString(person.lastName);
            writer.WriteEndElement();
            writer.WriteStartElement("StreetName");
            writer.WriteString(person.streetName);
            writer.WriteEndElement();
            writer.WriteStartElement("HouseNumber");
            writer.WriteString(person.houseNumber);
            writer.WriteEndElement();
            if (person.apartmentNumber != null)
            {
                writer.WriteStartElement("ApartmentNumber");
                writer.WriteString(person.apartmentNumber);
                writer.WriteEndElement();
            }
            writer.WriteStartElement("PostalCode");
            writer.WriteString(person.postalCode);
            writer.WriteEndElement();
            writer.WriteStartElement("Town");
            writer.WriteString(person.town);
            writer.WriteEndElement();
            writer.WriteStartElement("PhoneNumber");
            writer.WriteString(person.phoneNumber);
            writer.WriteEndElement();
            writer.WriteStartElement("BirthDate");
            writer.WriteString(person.birthdate.ToShortDateString());
            writer.WriteEndElement();

            writer.WriteEndElement();
        }
    }
}
