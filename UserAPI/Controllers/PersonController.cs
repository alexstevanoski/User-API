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

        [HttpPost]
        public IActionResult Post(JObject payload)
        {

            return Ok(payload);
        }
    }
}
