using MotoApp.Components.CsvReader.Models;
using System.Globalization;

namespace MotoApp.Components.CsvReader.Extensions;

public static class ManufacturerExtensions
{
    public static IEnumerable<Manufacturer> ToManufacturer(this IEnumerable<string> source)
    {
        foreach (var line in source)
        {
            var columns = line.Split(',');

            yield return new Manufacturer
            {
                Name = columns[0],
                Country = columns[1],
                Year = int.Parse(columns[2], CultureInfo.InvariantCulture),
            };
        }
    }
}
