using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using UserAPI.Models;
using MongoDB.Driver;

namespace UserAPI.DataContext;

public class MongoDbContext : DbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("mongodb://localhost:27017"));
        _database = client.GetDatabase("UserAPI");
    }

    public IMongoCollection<Person> Persons => _database.GetCollection<Person>("Persons");
}
