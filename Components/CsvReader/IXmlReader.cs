namespace MotoApp.Components.CsvReader;

public interface IXmlReader
{
    void CreateCarsXmlFile();
    void CreateManufacturersXmlFile();
    void ReadCarsXmlFile();
    void ReadManufacturersXmlFile();
    void CreateManufacturersAndCarsJoinedXmlFile();
}
