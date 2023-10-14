using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mosha.StatePatter.Test.Model.Deal;
using Mosha.StatePatter.Test.Model.Deal.Enums;
using Mosha.StatePatter.Test.Model.Deal.States.Interface;
using Mosha.StatePatter.Test.Model.Deal.States.Rule;
using Mosha.StatePattern;

namespace Mosha.StatePatter.Test.Db;

public class MyContext : DbContext
{
    public DbSet<Deal> Deals { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Deal>().OwnsOne<StateBehavior<IDealState, DealStateEnum, DealStateRule>>("State");
        base.OnModelCreating(modelBuilder);
    }
}

