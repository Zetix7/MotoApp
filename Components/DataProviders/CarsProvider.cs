using MotoApp.Components.DataProviders.Extesions;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;
using System.Text;

namespace MotoApp.Components.DataProviders;

internal class CarsProvider : ICarsProvider
{
    private IRepository<Car> _carsRepository;

    public CarsProvider(IRepository<Car> carsRepository)
    {
        _carsRepository = carsRepository;
    }

    public List<string> GetUniqueCarColors()
    {
        var cars = _carsRepository.GetAll();
        return cars.Select(x => x.Color).Distinct().ToList();
    }

    public decimal GetMinPriceOfAllCars()
    {
        var cars = _carsRepository.GetAll();
        return cars.Select(x => x.Cost).Min();
    }

    public List<Car> GetSpecificColumns()
    {
        var cars = _carsRepository.GetAll();
        return cars.Select(x => new Car
        {
            Id = x.Id,
            Name = x.Name,
            Type = x.Type,
        }).ToList();
    }

    public string AnonymusClass()
    {
        var cars = _carsRepository.GetAll();
        var anonymysClass = cars.Select(x => new
        {
            ProductID = x.Id,
            ProductName = x.Name,
            ProductType = x.Type,
        });

        var sb = new StringBuilder(1024);
        foreach (var car in anonymysClass)
        {
            sb.AppendLine($"Product ID: {car.ProductID}");
            sb.AppendLine($"\tProduct Name: {car.ProductName}");
            sb.AppendLine($"\tProduct Cost: {car.ProductType}");
            sb.AppendLine();
        }

        return sb.ToString();
    }

    public List<Car> OrderByName()
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderBy(x => x.Name).ToList();
    }

    public List<Car> OrderByNameDesc()
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderByDescending(x => x.Name).ToList();
    }

    public List<Car> OrderByColorAndName()
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderBy(x => x.Color).ThenBy(x => x.Name).ToList();
    }

    public List<Car> OrderByColorAndNameDesc()
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderByDescending(x => x.Color).ThenByDescending(x => x.Name).ToList();
    }

    public List<Car> FilterCars(decimal minPrice)
    {
        var cars = _carsRepository.GetAll();
        return cars.Where(x => x.Cost > minPrice).ToList();
    }

    public List<Car> WhereStartsWith(string prefix)
    {
        var cars = _carsRepository.GetAll();
        return cars.Where(x => x.Name.StartsWith(prefix)).ToList();
    }

    public List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost)
    {
        var cars = _carsRepository.GetAll();
        return cars.Where(x => x.Name.StartsWith(prefix) && x.Cost > cost).ToList();
    }

    public List<Car> WhereColorIs(string color)
    {
        var cars = _carsRepository.GetAll();
        return cars.ColorIs(color).ToList();
    }

    public Car FirstByColor(string color)
    {
        var cars = _carsRepository.GetAll();
        return cars.First(x => x.Color == color);
    }

    public Car? FirstOrDefaultByColor(string color)
    {
        var cars = _carsRepository.GetAll();
        return cars.FirstOrDefault(x => x.Color == color);
    }

    public Car FirstOrDefaultByColorWithDefault(string color)
    {
        var cars = _carsRepository.GetAll();
        return cars.FirstOrDefault(x => x.Color == color, new Car { Id = -1, Name = "NOT FOUND" });
    }

    public Car LastByColor(string color)
    {
        var cars = _carsRepository.GetAll();
        return cars.Last(x => x.Color == color);
    }

    public Car SingleById(int id)
    {
        var cars = _carsRepository.GetAll();
        return cars.Single(x => x.Id == id);
    }

    public Car? SingleOrDefaultById(int id)
    {
        var cars = _carsRepository.GetAll();
        return cars.SingleOrDefault(x => x.Id == id);
    }

    public List<Car> TakeCars(int howMany)
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderBy(x => x.Name).Take(howMany).ToList();
    }

    public List<Car> TakeCars(Range range)
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderBy(x => x.Name).Take(range).ToList();
    }

    public List<Car> TakeCarsWhileNameStartsWith(string prefix)
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderBy(x => x.Name).TakeWhile(x => x.Name.StartsWith(prefix)).ToList();
    }

    public List<Car> SkipCars(int howMany)
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderBy(x => x.Name).Skip(howMany).ToList();
    }

    public List<Car> SkipCarsWhileNameStartsWith(string prefix)
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderBy(x => x.Name).SkipWhile(x => x.Name.StartsWith(prefix)).ToList();
    }

    public List<string> DistinctAllColors()
    {
        var cars = _carsRepository.GetAll();
        return cars.Select(x => x.Color).Distinct().OrderBy(x => x).ToList();
    }

    public List<Car> DistinctByColors()
    {
        var cars = _carsRepository.GetAll();
        return cars.DistinctBy(x => x.Color).OrderBy(x => x.Color).ToList();
    }

    public List<Car[]> ChunkCars(int size)
    {
        var cars = _carsRepository.GetAll();
        return cars.Chunk(size).ToList();
    }
}
