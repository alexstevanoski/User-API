using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Linq;
using System.Xml.Linq;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private List<Person> persons = new List<Person> { new Person( "test", "testmail", 1, "testpass")};

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(persons);
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonById(int id)
        {
            var Person = persons.FirstOrDefault(p => p.id == id);

            if (Person == null)
            {
                return NotFound();
            }

            return Ok(Person);
        }

        // Post entries 
        [HttpPost]
        public IActionResult CreatePerson([FromBody] Person newPerson)
        {
            if (newPerson == null)
            {
                return BadRequest("Invalid data");
            }

            // Generate a unique ID (replace with a more robust method in a production app)
            int nextId = persons.Count + 1;
            newPerson.id = nextId;

            persons.Add(newPerson);

            return CreatedAtAction("GetPersonById", new { id = newPerson.id }, newPerson);
        }

        //Delete entries by id
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            var personToDelete = persons.FirstOrDefault(p => p.id == id);

            if (personToDelete == null)
            {
                return NotFound(); // Person with the specified Id was not found
            }

            // Remove the person from the list
            persons.Remove(personToDelete);

            return NoContent(); // Return a 204 No Content response
        }
    }   
}
