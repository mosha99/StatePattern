// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Mosha.StatePatter.Test.Db;

Console.WriteLine("Hello, World!");
var context = new MyContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

var p = context.Deals.ToList();
Console.WriteLine(p.Count);

for (int i = 0; i < 10; i++)
{
    context.Deals.Add(new Mosha.StatePatter.Test.Model.Deal.Deal()
    {
        DealerName = "Deal "+i.ToString(),
        State = default,
    });
}

context.SaveChanges();
Console.WriteLine("************************");
var p2 = context.Deals.ToList();
Console.WriteLine(p.Count);
Console.WriteLine("************************");
Console.ReadKey();