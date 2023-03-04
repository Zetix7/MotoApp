using MotoApp.Components.CsvReader.Extensions;
using MotoApp.Components.CsvReader.Models;

namespace MotoApp.Components.CsvReader;

public class CsvReader : ICsvReader
{
    public List<Car> ProcessCars(string pathName)
    {
        if (!File.Exists(pathName))
        {
            return new List<Car>();
        }

        var cars = File.ReadAllLines(pathName).Skip(1).Where(x => x.Length > 1).ToCar();

        return cars.ToList();
    }

    public List<Manufacturer> ProcessManufacturers(string pathName)
    {
        if(!File.Exists(pathName))
        {
            return new List<Manufacturer>();
        }

        var manufacturers = File.ReadAllLines(pathName).Where(x => x.Length > 1).ToManufacturer();

        return manufacturers.ToList();
    }

    public void GroupCarByManufacturers()
    {
        var cars = ProcessCars(@"Resources\Files\fuel.csv");
        var carGroup = cars.GroupBy(x => x.Manufacturer).Select(x => new
        {
            Manufacturer = x.Key,
            Count = x.Count(),
            Max = x.Max(x => x.Combined),
            Average = x.Average(x => x.Combined),
        });

        foreach (var group in carGroup)
        {
            Console.WriteLine($"Manufacturer: {group.Manufacturer}");
            Console.WriteLine($"\tCount: {group.Count}");
            Console.WriteLine($"\tMax: {group.Max}");
            Console.WriteLine($"\tAverage: {group.Average:n2}");
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public void GroupManufacturerByCountry()
    {
        var manufacturers = ProcessManufacturers(@"Resources\Files\manufacturers.csv");

        var manufacturerGroup = manufacturers.GroupBy(x => x.Country).Select(x => new
        {
            Country = x.Key,
            Count = x.Count(),
        });

        foreach (var group in manufacturerGroup)
        {
            Console.WriteLine($"{group.Count} manufacturers in {group.Country}");
        }
        Console.WriteLine();
    }

    public void JoinCarsAndManufacturers()
    {
        var cars = ProcessCars(@"Resources\Files\fuel.csv");
        var manufacturers = ProcessManufacturers(@"Resources\Files\manufacturers.csv");

        var join = manufacturers.Join(
            cars,
            x => x.Name,
            x => x.Manufacturer,
            (manufacturer, car) => new
            {
                Manufacturer = manufacturer.Name,
                Name = car.Name,
                Country = manufacturer.Country,
                Combined = car.Combined,
            });

        foreach (var group in join)
        {
            Console.WriteLine($"{group.Manufacturer} {group.Name}");
            Console.WriteLine($"\tCountry: {group.Country}");
            Console.WriteLine($"\tCombined: {group.Combined}");
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public void JoinAndGroupCarsAndManufacturers()
    {
        var cars = ProcessCars(@"Resources\Files\fuel.csv");
        var manufacturers = ProcessManufacturers(@"Resources\Files\manufacturers.csv");

        var groupJoin = manufacturers.GroupJoin(
            cars,
            x => new { x.Name, x.Year },
            x => new { Name = x.Manufacturer, x.Year },
            (manufacturer, cars) => new
            {
                Manufacturer = manufacturer,
                Cars = cars,
            });

        foreach (var group in groupJoin)
        {
            Console.WriteLine($"Manufacturer: {group.Manufacturer.Name}");
            Console.WriteLine($"\tCount of cars: {group.Cars.Count()}");
            Console.WriteLine($"\tMax combined cars: {group.Cars.Max(x => x.Combined)}");
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
