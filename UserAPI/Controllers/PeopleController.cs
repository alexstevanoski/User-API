using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

[Route("api/people")]
[ApiController]
public class PeopleController : ControllerBase
{
    private List<Person> _people = new List<Person>
    {
        new Person { Id = 1, Name = "Alex", Surname = "Ste."},
        new Person { Id = 1, Name = "Joel", Surname = "Mei." }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Person>> Get()
    {
        return Ok(_people);
    }

    [HttpGet("{Id}")]
    public ActionResult<Person> Get(int id)
    {
        var person = _people.FirstOrDefault(x => x.Id == id);
        if (person == null) { return NotFound(); }
        return Ok(person);
    }

    [HttpPost]
    public ActionResult<Person> Post(Person person)
    {
        person.Id = _people.Max(x => x.Id) + 1;
        _people.Add(person);
        return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
    }

    [HttpDelete("{id")]
    public ActionResult Delete(int id)
    {
        var person = _people.FirstOrDefault(x => x.Id == id);
        if (person == null) { return NotFound(); };
        _people.Remove(person);
        return NoContent();
    }
}