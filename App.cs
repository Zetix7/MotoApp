using MotoApp.Components.CsvReader;

namespace MotoApp;

internal class App : IApp
{
    private readonly ICsvReader _csvReader;

    public App(ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }

    public void Run()
    {
        var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
        var manufacturers = _csvReader.ProcessCars("Resources\\Files\\manufacturers.csv");
    }
}
