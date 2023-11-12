using Microsoft.EntityFrameworkCore;
using Mosha.StatePattern;
using Mosha.StatePattern.Test.Models.Models;
using System.Reflection.Emit;

namespace Test;

public class MyContext : DbContext
{
    public DbSet<Person> Pepole { set; get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"DataSource=Test.db");
    }

}
