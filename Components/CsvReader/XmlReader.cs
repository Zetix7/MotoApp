using System.Xml.Linq;

namespace MotoApp.Components.CsvReader;

public class XmlReader : IXmlReader
{
    private readonly ICsvReader _csvReader;

    public XmlReader(ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }

    public void CreateCarsXmlFile()
    {
        var records = _csvReader.ProcessCars(@"Resources\Files\fuel.csv");

        var cars = new XElement("Cars", records.Select(x =>
            new XElement("Car",
                new XAttribute("Manufacturer", x.Manufacturer),
                new XAttribute("Name", x.Name),
                new XAttribute("Combined", x.Combined))));

        var carsDocument = new XDocument(cars);
        carsDocument.Save("fuel.xml");
    }

    public void CreateManufacturersXmlFile()
    {
        var records = _csvReader.ProcessManufacturers(@"Resources\Files\manufacturers.csv");

        var manufacturers = new XElement("Manufacturers", records.Select(x =>
            new XElement("Manufacturer",
                new XAttribute("Name", x.Name),
                new XAttribute("Year", x.Year),
                new XAttribute("Country", x.Country))));

        var carsDocument = new XDocument(manufacturers);
        carsDocument.Save("manufacturers.xml");
    }

    public void ReadCarsXmlFile()
    {
        var records = XDocument.Load("fuel.xml");

        var cars = records.Element("Cars")?
            .Elements("Car")
            .Where(x => x.Attribute("Manufacturer")?.Value == "Audi")
            .Select(x => new
            {
                Manufacturer = x.Attribute("Manufacturer")?.Value,
                Name = x.Attribute("Name")?.Value
            }).OrderBy(x=>x.Manufacturer).ThenBy(x=>x.Name);

        foreach (var car in cars!)
        {
            Console.WriteLine($"{car.Manufacturer} {car.Name}");
        }
        Console.WriteLine();
    }

    public void ReadManufacturersXmlFile()
    {
        var records = XDocument.Load("manufacturers.xml");

        var manufacturers = records
            .Element("Manufacturers")?
            .Elements("Manufacturer")
            .Select(x => new
            {
                Country = x.Attribute("Country")?.Value
            }).Distinct();

        foreach (var manufacturer in manufacturers!)
        {
            Console.WriteLine($"{manufacturer.Country}");
        }
        Console.WriteLine();
    }

    public void CreateManufacturersAndCarsJoinedXmlFile()
    {
        var cars = _csvReader.ProcessCars(@"Resources\Files\fuel.csv");
        var manufacturers = _csvReader.ProcessManufacturers(@"Resources\Files\manufacturers.csv");

        var gruopJoin = manufacturers.GroupJoin(
            cars,
            x => x.Name,
            x => x.Manufacturer,
            (manufacturer, cars) => new
            {
                Manufacturer = manufacturer,
                Cars = cars,
            });

        var xmlData = new XElement("Manufacturers", gruopJoin.Select(x=> 
            new XElement("Manufacturer", 
                new XAttribute("Name", x.Manufacturer.Country),
                new XAttribute("Country", x.Manufacturer.Country),
                new XElement("Cars", x.Cars.Select(x=> 
                    new XElement("Car", 
                        new XAttribute("Model", x.Name),
                        new XAttribute("Combined", x.Combined))),
                    new XAttribute("Country", x.Manufacturer.Country),
                    new XAttribute("CombinedSum", x.Cars.Sum(x=>x.Combined))))));

        var xmlDocument = new XDocument(xmlData);
        xmlDocument.Save("manufacturerscars.xml");
    }
}
