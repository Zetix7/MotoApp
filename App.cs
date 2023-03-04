using MotoApp.Components.CsvReader;
using MotoApp.Data;
using MotoApp.Data.Entities;

namespace MotoApp;

public class App : IApp
{
    private readonly ICsvReader _csvReader;
    private readonly MotoAppDbContext _motoAppDbContext;

    public App(ICsvReader csvReader, MotoAppDbContext motoAppDbContext)
    {
        _csvReader = csvReader;
        _motoAppDbContext = motoAppDbContext;
        _motoAppDbContext.Database.EnsureCreated();
    }

    public void Run()
    {
        //InsertCarsToDatabase();
        //ReadCarsFromDatabase();
        ReadGroupCarsByManufacturerFromDatabase();
        //UpdateFirstCarByManufacturerInDatabase("Alfa Romeo");
        //RemoveLastCarByManufacturerFromDatabase("Volvo");
    }

    private void RemoveLastCarByManufacturerFromDatabase(string manufacturer)
    {
        var car = _motoAppDbContext.Cars.OrderBy(x => x.Manufacturer).ThenBy(x=>x.Id).LastOrDefault();
        _motoAppDbContext.Cars.Remove(car);
        _motoAppDbContext.SaveChanges();
    }

    private void UpdateFirstCarByManufacturerInDatabase(string manufacturer)
    {
        var car = _motoAppDbContext.Cars.FirstOrDefault(x => x.Manufacturer == manufacturer);
        car.Manufacturer = "ALFA ROMEO";
        _motoAppDbContext.SaveChanges();
    }

    private void ReadGroupCarsByManufacturerFromDatabase()
    {
        var groups = _motoAppDbContext.Cars.GroupBy(x => x.Manufacturer).Select(x => new
        {
            Manufacturer = x.Key,
            Cars = x.OrderBy(x=>x.Name).ToList()
        }).OrderBy(x=>x.Manufacturer).ToList();

        foreach (var group in groups)
        {
            Console.WriteLine($"{group.Manufacturer} combined: {group.Cars.Sum(x=>x.Combined)}");

            foreach (var car in group.Cars)
            {
                Console.WriteLine($"\t{car.Name} combined: {car.Combined} / {group.Cars.Sum(x => x.Combined)}");
            }
        }
    }

    private void ReadCarsFromDatabase()
    {
        var cars = _motoAppDbContext.Cars.ToList();

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Manufacturer} {car.Name} combined: {car.Combined}");
        }
    }

    private void InsertCarsToDatabase()
    {
        var cars = _csvReader.ProcessCars(@"Resources\Files\fuel.csv");

        foreach (var car in cars)
        {
            _motoAppDbContext.Cars.Add(new Car
            {
                Year = car.Year,
                Manufacturer = car.Manufacturer,
                Name = car.Name,
                Displacement = car.Displacement,
                Cylinders = car.Cylinders,
                City = car.City,
                Highway = car.Highway,
                Combined = car.Combined,
            });
        }

        _motoAppDbContext.SaveChanges();
    }
}
