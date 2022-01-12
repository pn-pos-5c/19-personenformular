using Persons.DTOs;

namespace Persons.Services
{
    public class PersonsService
    {
        private readonly PersonsContext db;

        public PersonsService(PersonsContext db)
        {
            this.db = db;
        }

        public List<PersonResponseDto> GetPersons()
        {
            return db.Persons.Include(x => x.Adress).Include(x => x.Adress.City).Select(person => GetPersonResponseDto(person)).ToList();
        }

        public PersonResponseDto GetPerson(int id)
        {
            var person = db.Persons.FirstOrDefault(x => x.Id == id);
            if (person == null) return null;

            return GetPersonResponseDto(person);
        }

        private static PersonResponseDto GetPersonResponseDto(Person person)
        {
            return new PersonResponseDto
            {
                Id = person.Id,
                Adress = $"{person.Adress.City.CountryCode}-{person.Adress.City.PostalCode} {person.Adress.City.Name}, {person.Adress.StreetName} {person.Adress.StreetNr}",
                AdressId = person.AdressId,
                Born = person.Born,
                Firstname = person.Firstname,
                Lastname = person.Lastname,
                Tel = person.Tel
            };
        }
    }
}
