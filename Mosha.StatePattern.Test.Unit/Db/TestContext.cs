using Microsoft.EntityFrameworkCore;
using Mosha.StatePattern.Test.Models.Models;

namespace Mosha.StatePattern.Test.Unit.Db;

public class TestDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("TestDb");
        base.OnConfiguring(optionsBuilder);
    }
}