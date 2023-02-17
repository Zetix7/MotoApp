using Microsoft.Extensions.DependencyInjection;
using MotoApp;
using MotoApp.Components.DataProviders;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
services.AddSingleton<IRepository<Car>, ListRepository<Car>>();
services.AddSingleton<ICarsProvider, CarsProvider>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();

//using MotoApp.Data;
//using MotoApp.Entities;
//using MotoApp.Repositories.Extensions;
//using MotoApp.Ropositories;

//var employeeRepository = new SqlRepository<Employee>(new MotoContext(), EmployeeAdded);
//employeeRepository.ItemAdded += OnEmployeeAdded;
//employeeRepository.ItemRemoved += OnEmployeeRemoved;
//employeeRepository.SavedChanges += OnChangesSaved;

//AddEmployees(employeeRepository);
//WriteToConsole(employeeRepository);

//static void AddEmployees(IRepository<Employee> employeeRepository)
//{
//    var employees = new [] 
//    {
//        new Employee { FirstName = "Liz" },
//        new Employee { FirstName = "Scarlett" },
//        new Manager { FirstName = "Greg" }
//    };
//    employeeRepository.AddBatch(employees);
//}

//static void WriteToConsole(IReadRepository<IEntity> repository)
//{
//    foreach (var item in repository.GetAll())
//    {
//        Console.WriteLine(item);
//    }
//}

//static void EmployeeAdded(Employee employee)
//{
//    Console.WriteLine($"[Callback] {employee.FirstName} added");
//}

//static void OnEmployeeAdded(object? sender, Employee employee)
//{
//    Console.WriteLine($"[Event] Employee added -> {employee.FirstName} from {sender?.GetType().Name}");
//}

//static void OnEmployeeRemoved(object? sender, Employee employee)
//{
//    Console.WriteLine($"[Event] Employee removed -> {employee.FirstName} from {sender?.GetType().Name}");
//}

//static void OnChangesSaved(object? sender, EventArgs args)
//{
//    Console.WriteLine($"[Event] Changes saved in {sender?.GetType().Name}");
//}

//public List<Car> GenerateCars()
//{
//    return new List<Car>
//    {
//        new Car{ Id = 101, Name = "Audi A3", Color = "Black", Cost = 1000.99m, Type = "Sportback" },
//        new Car{ Id = 102, Name = "Audi A4", Color = "White", Cost = 1200.99m, Type = "Avant" },
//        new Car{ Id = 103, Name = "Audi A5", Color = "Silver", Cost = 1799.99m, Type = "Liftback" },
//        new Car{ Id = 104, Name = "Audi A6", Color = "Blue", Cost = 1899.99m, Type = "Sedan" },
//        new Car{ Id = 105, Name = "Audi A7", Color = "Green", Cost = 2199.99m, Type = "Liftback" },
//        new Car{ Id = 106, Name = "Audi A8", Color = "Blue", Cost = 2699.99m, Type = "Sedan" },
//        new Car{ Id = 107, Name = "Audi A3", Color = "Red", Cost = 1199.99m, Type = "Sedan" },
//        new Car{ Id = 108, Name = "Audi A8", Color = "Black", Cost = 2399.99m, Type = "Sedan" },
//        new Car{ Id = 109, Name = "Audi S3", Color = "Red", Cost = 1399.99m, Type = "Sportback" },
//        new Car{ Id = 110, Name = "Audi S4", Color = "Silver", Cost = 1699.99m, Type = "Avant" },
//        new Car{ Id = 111, Name = "Audi S5", Color = "Green", Cost = 1899.99m, Type = "Liftback" },
//        new Car{ Id = 112, Name = "Audi S6", Color = "Blue", Cost = 2099.99m, Type = "Avant" },
//        new Car{ Id = 113, Name = "Audi S7", Color = "Black", Cost = 2499.99m, Type = "Liftback" },
//        new Car{ Id = 114, Name = "Audi S8", Color = "Silver", Cost = 2899.99m, Type = "Sedan" },
//        new Car{ Id = 115, Name = "Audi RS3", Color = "Red", Cost = 2099.99m, Type = "Sportback" },
//        new Car{ Id = 116, Name = "Audi RS3", Color = "Blue", Cost = 2199.99m, Type = "Sedan" },
//        new Car{ Id = 117, Name = "Audi RS4", Color = "Green", Cost = 2499.99m, Type = "Avant" },
//        new Car{ Id = 118, Name = "Audi RS5", Color = "Red", Cost = 2899.99m, Type = "Liftback" },
//        new Car{ Id = 119, Name = "Audi RS6", Color = "Yellow", Cost = 3099.99m, Type = "Avant" },
//        new Car{ Id = 120, Name = "Audi RS7", Color = "Silver", Cost = 3399.99m, Type = "Liftback" },
//        new Car{ Id = 121, Name = "Audi R8", Color = "Red", Cost = 3799.99m, Type = "Coupe" },
//        new Car{ Id = 122, Name = "Audi TT", Color = "Black", Cost = 2799.99m, Type = "Coupe" },
//        new Car{ Id = 123, Name = "Audi TTS", Color = "Blue", Cost = 2899.99m, Type = "Coupe" },
//        new Car{ Id = 124, Name = "Audi TTRS", Color = "Red", Cost = 2999.99m, Type = "Coupe" },
//    };
//  }