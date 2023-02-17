using MotoApp.Components.DataProviders;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;
using MotoApp.Data.Repositories.Extensions;

namespace MotoApp;

internal class App : IApp
{
    private readonly IRepository<Employee> _employeesRepository;
    private readonly IRepository<Car> _carsRepository;
    private readonly ICarsProvider _carsProvider;

    public App(IRepository<Employee> employeesRepository,
        IRepository<Car> carsRepository,
        ICarsProvider carsProvider)
    {
        _employeesRepository = employeesRepository;
        _carsRepository = carsRepository;
        _carsProvider = carsProvider;

        _employeesRepository.ItemAdded += OnEmployeeAdded;
        _employeesRepository.ItemRemoved += OnEmployeeRemoved;
        _employeesRepository.ItemsSaved += OnItemsSaved;
    }

    public void Run()
    {
        Console.WriteLine("Run() method");

        var employees = new[]
        {
            new Employee { FirstName = "Liz" },
            new Employee { FirstName = "Scarlett" },
            new Manager { FirstName = "Greg" }
        };
        _employeesRepository.AddBatch(employees);

        // cars
        var cars = GenerateCars();

        foreach (var car in cars)
        {
            _carsRepository.Add(car);
        }

        Console.WriteLine("\n--- GetUniqueCarColors()");
        foreach (var color in _carsProvider.GetUniqueCarColors())
        {
            Console.WriteLine(color);
        }

        Console.WriteLine("\n--- GetMinPriceOfAllCars()");
        Console.WriteLine(_carsProvider.GetMinPriceOfAllCars());

        Console.WriteLine("\n--- GetSpecificColumns()");
        foreach (var car in _carsProvider.GetSpecificColumns())
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\n--- AnonymusClass()");
        Console.WriteLine(_carsProvider.AnonymusClass());
    
        Console.WriteLine("\n--- OrderByName()");
        foreach (var car in _carsProvider.OrderByName())
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\n--- OrderByNameDesc()");
        foreach (var car in _carsProvider.OrderByNameDesc())
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\n--- OrderByColorAndName()");
        foreach (var car in _carsProvider.OrderByColorAndName())
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\n--- OrderByColorAndNameDesc()");
        foreach (var car in _carsProvider.OrderByColorAndNameDesc())
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\n--- FilterCars()");
        foreach (var car in _carsProvider.FilterCars(3100))
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\n--- WhereStartsWith()");
        foreach (var car in _carsProvider.WhereStartsWith("Audi RS"))
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\n--- WhereStartsWithAndCostIsGreaterThan()");
        foreach (var car in _carsProvider.WhereStartsWithAndCostIsGreaterThan("Audi A", 2000))
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\n--- WhereColorIs()");
        foreach (var car in _carsProvider.WhereColorIs("Green"))
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\n--- FirstByColor()");
        Console.WriteLine(_carsProvider.FirstByColor("Silver"));

        Console.WriteLine("\n--- FirstOrDefaultByColor()");
        Console.WriteLine(_carsProvider.FirstOrDefaultByColor("Gold"));

        Console.WriteLine("\n--- FirstOrDefaultByColorWithDefault()");
        Console.WriteLine(_carsProvider.FirstOrDefaultByColorWithDefault("Gold"));

        Console.WriteLine("\n--- LastByColor()");
        Console.WriteLine(_carsProvider.LastByColor("Green"));

        Console.WriteLine("\n--- SingleById()");
        Console.WriteLine(_carsProvider.SingleById(7));

        Console.WriteLine("\n--- SingleOrDefaultById()");
        Console.WriteLine(_carsProvider.SingleOrDefaultById(77));

        Console.WriteLine("\n--- TakeCars(howMany)");
        foreach (var car in _carsProvider.TakeCars(7))
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\n--- TakeCars(range)");
        foreach (var car in _carsProvider.TakeCars(6..8))
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\n--- TakeCarsWhileNameStartsWith()");
        foreach (var car in _carsProvider.TakeCarsWhileNameStartsWith("Audi A3"))
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\n--- SkipCars()");
        foreach (var car in _carsProvider.SkipCars(22))
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\n--- SkipCarsWhileNameStartsWith()");
        foreach (var car in _carsProvider.SkipCarsWhileNameStartsWith("Audi A3"))
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\n--- DistinctAllColors()");
        foreach (var car in _carsProvider.DistinctAllColors())
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\n--- DistinctByColors()");
        foreach (var car in _carsProvider.DistinctByColors())
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\n--- ChunkCars()");
        foreach (var chunk in _carsProvider.ChunkCars(5))
        {
            Console.WriteLine("_________________________________");
            foreach (var car in chunk)
            {
                Console.WriteLine(car);
            }
        }
    }

    public static List<Car> GenerateCars()
    {
        return new List<Car>
        {
            new Car{ Id = 101, Name = "Audi A3", Color = "Black", Cost = 1000.99m, Type = "Sportback" },
            new Car{ Id = 102, Name = "Audi A4", Color = "White", Cost = 1200.99m, Type = "Avant" },
            new Car{ Id = 103, Name = "Audi A5", Color = "Silver", Cost = 1799.99m, Type = "Liftback" },
            new Car{ Id = 104, Name = "Audi A6", Color = "Blue", Cost = 1899.99m, Type = "Sedan" },
            new Car{ Id = 105, Name = "Audi A7", Color = "Green", Cost = 2199.99m, Type = "Liftback" },
            new Car{ Id = 106, Name = "Audi A8", Color = "Blue", Cost = 2699.99m, Type = "Sedan" },
            new Car{ Id = 107, Name = "Audi A3", Color = "Red", Cost = 1199.99m, Type = "Sedan" },
            new Car{ Id = 108, Name = "Audi A8", Color = "Black", Cost = 2399.99m, Type = "Sedan" },
            new Car{ Id = 109, Name = "Audi S3", Color = "Red", Cost = 1399.99m, Type = "Sportback" },
            new Car{ Id = 110, Name = "Audi S4", Color = "Silver", Cost = 1699.99m, Type = "Avant" },
            new Car{ Id = 111, Name = "Audi S5", Color = "Green", Cost = 1899.99m, Type = "Liftback" },
            new Car{ Id = 112, Name = "Audi S6", Color = "Blue", Cost = 2099.99m, Type = "Avant" },
            new Car{ Id = 113, Name = "Audi S7", Color = "Black", Cost = 2499.99m, Type = "Liftback" },
            new Car{ Id = 114, Name = "Audi S8", Color = "Silver", Cost = 2899.99m, Type = "Sedan" },
            new Car{ Id = 115, Name = "Audi RS3", Color = "Red", Cost = 2099.99m, Type = "Sportback" },
            new Car{ Id = 116, Name = "Audi RS3", Color = "Blue", Cost = 2199.99m, Type = "Sedan" },
            new Car{ Id = 117, Name = "Audi RS4", Color = "Green", Cost = 2499.99m, Type = "Avant" },
            new Car{ Id = 118, Name = "Audi RS5", Color = "Red", Cost = 2899.99m, Type = "Liftback" },
            new Car{ Id = 119, Name = "Audi RS6", Color = "Yellow", Cost = 3099.99m, Type = "Avant" },
            new Car{ Id = 120, Name = "Audi RS7", Color = "Silver", Cost = 3399.99m, Type = "Liftback" },
            new Car{ Id = 121, Name = "Audi R8", Color = "Red", Cost = 3799.99m, Type = "Coupe" },
            new Car{ Id = 122, Name = "Audi TT", Color = "Black", Cost = 2799.99m, Type = "Coupe" },
            new Car{ Id = 123, Name = "Audi TTS", Color = "Blue", Cost = 2899.99m, Type = "Coupe" },
            new Car{ Id = 124, Name = "Audi TTRS", Color = "Red", Cost = 2999.99m, Type = "Coupe" },
        };
    }

    static void OnEmployeeAdded(object? sender, Employee employee)
    {
        Console.WriteLine($"[Event] Employee added -> {employee.FirstName} from {sender?.GetType().Name}");
    }

    static void OnEmployeeRemoved(object? sender, Employee employee)
    {
        Console.WriteLine($"[Event] Employee removed -> {employee.FirstName} from {sender?.GetType().Name}");
    }

    static void OnItemsSaved(object? sender, EventArgs args)
    {
        Console.WriteLine($"[Event] Changes saved in {sender?.GetType().Name}");
    }
}
