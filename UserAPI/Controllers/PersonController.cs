using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;
using UserAPI.DataContext;
using MongoDB.Driver;

namespace UserAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMongoDatabase _database;

        public PersonController(IMongoDatabase database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
        }

        [HttpGet]
        public JsonResult Get()
        {
            var collection = _database.GetCollection<Person>("Persons");
            var result = collection.Find(_ => true).ToList();
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public JsonResult GetPersonById(int id)
        {
            var collection = _database.GetCollection<Person>("Persons");
            var person = collection.Find(p => p.id == id).FirstOrDefault();

            if (person == null)
            {
                return new JsonResult(404);
            }

            return new JsonResult(Ok(person));
        }

        // Post entries 
        [HttpPost]
        public JsonResult CreatePerson(Person person)
        {
            var collection = _database.GetCollection<Person>("Persons");

            if (person.id == 0)
            {
                collection.InsertOne(person);
                return new JsonResult(Ok(person));
            }
            else
            {
                var existingPerson = collection.Find(p => p.id == person.id).FirstOrDefault();
                if (existingPerson == null)
                {
                    collection.InsertOne(person);
                    return new JsonResult(Ok(person));
                }
                return new JsonResult(409);
            }
        }

        [HttpPut("{id}")]
        public JsonResult UpdatePerson(int id, Person updatedPerson)
        {
            var collection = _database.GetCollection<Person>("Persons");
            var filter = Builders<Person>.Filter.Eq(p => p.id, id);
            var update = Builders<Person>.Update
                .Set(p => p.name, updatedPerson.name)
                .Set(p => p.email, updatedPerson.email)
                .Set(p => p.password, updatedPerson.password);

            var result = collection.UpdateOne(filter, update);

            if (result.ModifiedCount == 0)
            {
                return new JsonResult(404);
            }

            return new JsonResult(200);
        }

        //Delete entries by id
        [HttpDelete("{id}")]
        public JsonResult DeletePerson(int id)
        {
            var collection = _database.GetCollection<Person>("Persons");
            var result = collection.DeleteOne(p => p.id == id);

            if (result.DeletedCount == 0)
            {
                return new JsonResult(404);
            }

            return new JsonResult(204);
        }
    }
}
