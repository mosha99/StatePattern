


using System.Text.Json;
using Mosha.StatePatter.Test.Db;
using Mosha.StatePatter.Test.Model.Deal;

MyContext DB = new();

await DB.Database.EnsureCreatedAsync();

if (!DB.Deals.Any())
{
    await DB.AddAsync(new Deal()
    {
        DealerName = "Moein",
    });

    await DB.SaveChangesAsync();
}

Deal deal = DB.Deals.First();

Print(deal);

deal.Confirm();

await DB.SaveChangesAsync();

deal = DB.Deals.First();

Print(deal);


void Print(object item)
{
    Console.WriteLine(JsonSerializer.Serialize(item, new JsonSerializerOptions() { WriteIndented = true }));
}