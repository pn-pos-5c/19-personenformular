using Persons.DTOs;
using Persons.Services;

namespace Persons.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonsController : ControllerBase
{
    private readonly PersonsService personsService;

    public PersonsController(PersonsService personsService)
    {
        this.personsService = personsService;
    }

    [HttpGet]
    public IActionResult GetPersons()
    {
        return Ok(personsService.GetPersons());
    }

    [HttpGet("{id}")]
    public IActionResult GetPerson(int id)
    {
        if (id < 0) return BadRequest("Invalid id");

        var person = personsService.GetPerson(id);
        if (person == null) return BadRequest("Invalid id");

        return Ok(person);
    }

    [HttpPost]
    public IActionResult AddPerson([FromBody] PersonDto personDto)
    {
        var person = personsService.AddPerson(personDto);
        if (person == null) return BadRequest("Invalid person");

        return Ok(person);
    }
}
