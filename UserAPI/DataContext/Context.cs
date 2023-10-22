using Microsoft.EntityFrameworkCore;
using UserAPI.Models;

namespace UserAPI.DataContext;

public class ApiContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
    {

    }
}