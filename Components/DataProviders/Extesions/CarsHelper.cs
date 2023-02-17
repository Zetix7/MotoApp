using MotoApp.Data.Entities;

namespace MotoApp.Components.DataProviders.Extesions;

internal static class CarsHelper
{
    public static IEnumerable<Car> ColorIs(this IEnumerable<Car> query, string color)
    {
        return query.Where(x => x.Color == color);
    }
}
