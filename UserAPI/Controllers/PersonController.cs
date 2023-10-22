using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;
using UserAPI.DataContext;

namespace UserAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ApiContext _context;

        public PersonController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var result = _context.Persons.ToList();
            return new JsonResult(result);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetPersonById(int id)
        //{
        //    var Person = persons.FirstOrDefault(p => p.id == id);
        //
        //    if (Person == null)
        //    {
        //        return NotFound();
        //    }
        //
        //    return Ok(Person);
        //}

        // Post entries 
        [HttpPost]
        public JsonResult CreatePerson(Person person)
        {
            
            if (person.id == 0)
            {
                _context.Persons.Add(person);
                _context.SaveChanges();
                return new JsonResult(Ok(person));
            }
            else
            {
                var usersInDb = _context.Persons.Find(person.id);
                if (usersInDb == null)
                {
                    _context.Persons.Add(person);
                    _context.SaveChanges();
                    return new JsonResult(Ok(person));
                }

                return new JsonResult(409);
            }
            

        }

        //Delete entries by id
        //[HttpDelete("{id}")]
        //public IActionResult DeletePerson(int id)
        //{
        //    var personToDelete = persons.FirstOrDefault(p => p.id == id);
        //
        //    if (personToDelete == null)
        //    {
        //        return NotFound(); // Person with the specified Id was not found
        //    }
        //
        //    // Remove the person from the list
        //    persons.Remove(personToDelete);
        //
        //    return NoContent(); // Return a 204 No Content response
        //}
    }   
}
