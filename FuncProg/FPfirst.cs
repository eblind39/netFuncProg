using FunctionalProgramming.Models;

namespace FunctionalProgramming.Init;

public class FPInit
{
    public static void RunFPInit()
    {
        List<Models.Person> persons = new List<Models.Person>
        {
            new Models.Person{Name="Ernst", Age=21, Products="1,2"},
            new Models.Person{Name="Alvison", Age=23, Products="1,3"},
            new Models.Person{Name="Alvison", Age=23, Products="1,3"},
            new Models.Person{Name="Ernst", Age=21, Products="1,2"}
        };

        IQueryable<Models.Person> distinctPersons = persons.AsQueryable().DistinctBy(x => new {
            x.Name,
            x.Age,
            x.Products
        }).Select(x => new Models.Person{
            Name = x.Name,
            Age = x.Age,
            Products = x.Products
        });

        string filterProd = "10,3";
        var lstProds = filterProd.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList().Where(x => x.ToString() != ",");

        foreach(var prd in lstProds)
            Console.WriteLine(prd);


        distinctPersons = distinctPersons.Where(x => x.Products.Split(',', StringSplitOptions.RemoveEmptyEntries).Any(p => filterProd.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList().Contains(p)));

        List<Models.Person> result = distinctPersons.ToList();

        Console.WriteLine("Distinct persons:");

        foreach (Models.Person person in result)
            Console.WriteLine($"{person.Name}, {person.Age}, {person.Products}");

        List<int?> Ids = "1,2,3".Split(',').Select(n => (int?)Convert.ToInt32(n)).ToList();
        int? myVal = 2;
        Console.WriteLine(Ids.Contains(myVal) ? "Found" : "Not Found");
    }
}