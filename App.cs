using MotoApp.Components.CsvReader;
using MotoApp.Components.CsvReader.Models;
using System.Xml;
using System.Xml.Linq;

namespace MotoApp;

internal class App : IApp
{
    private readonly ICsvReader _csvReader;
    private readonly IXmlReader _xmlReader;

    public App(ICsvReader csvReader, IXmlReader xmlReader)
    {
        _csvReader = csvReader;
        _xmlReader = xmlReader;
    }

    public void Run()
    {
        _csvReader.GroupManufacturerByCountry();
        _csvReader.GroupCarByManufacturers();
        _csvReader.JoinCarsAndManufacturers();
        _csvReader.JoinAndGroupCarsAndManufacturers();
        _xmlReader.CreateCarsXmlFile();
        _xmlReader.CreateManufacturersXmlFile();
        _xmlReader.ReadCarsXmlFile();
        _xmlReader.ReadManufacturersXmlFile();
        _xmlReader.CreateManufacturersAndCarsJoinedXmlFile();
    }
}
