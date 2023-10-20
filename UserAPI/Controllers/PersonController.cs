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

        private List<Person> persons = new List<Person>
        {
            new Person {name = "Alex", email = "Alex@mail.com", id = 1, password = "examplepassword1234" },
            new Person {name = "Joel", email = "Joel@mail.com", id = 2, password = "joels-weak-password9070" }
        };

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(persons);
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonById(int id)
        {
            var person = persons.FirstOrDefault(p => p.id == id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // Post entries 
        [HttpPost]
        public IActionResult CreatePerson([FromBody] Person newPerson)
        {
            if (newPerson == null)
            {
                return BadRequest("Invalid data"); // Return a bad request if the data is invalid
            }

            // Generate a new unique ID (in a real application, you might use a database-generated ID)
            int nextId = persons.Max(p => p.id) + 1;
            newPerson.id = nextId;

            // Add the new person to the list
            persons.Add(newPerson);

            // Return a 201 Created response with the newly created person
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
