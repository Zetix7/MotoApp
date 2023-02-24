using MotoApp.Components.CsvReader.Models;

namespace MotoApp.Components.CsvReader;

public interface ICsvReader
{
    List<Car> ProcessCars(string pathName);
    List<Manufacturer> ProcessManufacturers(string pathName);
    void GroupManufacturerByCountry();
    void GroupCarByManufacturers();
    void JoinCarsAndManufacturers();
    void JoinAndGroupCarsAndManufacturers();
}
