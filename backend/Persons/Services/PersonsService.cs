using Persons.DTOs;
using System.Text.RegularExpressions;

namespace Persons.Services
{
    public class PersonsService
    {
        private readonly PersonsContext db;
        private readonly Regex adressRegex = new(@"^([A-Z])-(\d{4})\s(\w+),\s(\w+)\s(\d+)$");

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
            var person = db.Persons.Include(x => x.Adress).Include(x => x.Adress.City).FirstOrDefault(x => x.Id == id);
            if (person == null) return null;

            return GetPersonResponseDto(person);
        }

        public PersonResponseDto AddPerson(PersonDto personDto)
        {
            Match match = adressRegex.Match(personDto.Adress);

            var person = db.Persons.Add(new Person
            {
                Adress = new Adress
                {
                    City = new City
                    {
                        CountryCode = match.Groups[1].Value,
                        PostalCode = int.Parse(match.Groups[2].Value),
                        Name = match.Groups[3].Value
                    },
                    StreetName = match.Groups[4].Value,
                    StreetNr = int.Parse(match.Groups[5].Value)
                },
                Born = personDto.Born,
                Firstname = personDto.Firstname,
                Lastname = personDto.Lastname,
                Tel = personDto.Tel
            });

            db.SaveChanges();

            return GetPersonResponseDto(person.Entity);
        }

        private static PersonResponseDto GetPersonResponseDto(Person person)
        {
            return new PersonResponseDto
            {
                Id = person.Id,
                Adress = $"{person.Adress.City.CountryCode}-{person.Adress.City.PostalCode} {person.Adress.City.Name}, {person.Adress.StreetName} {person.Adress.StreetNr}",
                Born = person.Born,
                Firstname = person.Firstname,
                Lastname = person.Lastname,
                Tel = person.Tel
            };
        }
    }
}
