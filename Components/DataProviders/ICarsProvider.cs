using MotoApp.Data.Entities;

namespace MotoApp.Components.DataProviders;

internal interface ICarsProvider
{
    // select
    List<string> GetUniqueCarColors();
    decimal GetMinPriceOfAllCars();
    List<Car> GetSpecificColumns();
    string AnonymusClass();

    // order by
    List<Car> OrderByName();
    List<Car> OrderByNameDesc();
    List<Car> OrderByColorAndName();
    List<Car> OrderByColorAndNameDesc();

    // where
    List<Car> FilterCars(decimal minPrice);
    List<Car> WhereStartsWith(string prefix);
    List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost);
    List<Car> WhereColorIs(string color);

    // first, last, single
    Car FirstByColor(string color);
    Car? FirstOrDefaultByColor(string color);
    Car FirstOrDefaultByColorWithDefault(string color);
    Car LastByColor(string color);
    Car SingleById(int id);
    Car? SingleOrDefaultById(int id);

    // take
    List<Car> TakeCars(int howMany);
    List<Car> TakeCars(Range range);
    List<Car> TakeCarsWhileNameStartsWith(string prefix);

    // skip
    List<Car> SkipCars(int howMany);
    List<Car> SkipCarsWhileNameStartsWith(string prefix);

    // distinct
    List<string> DistinctAllColors();
    List<Car> DistinctByColors();

    // chunk
    List<Car[]> ChunkCars(int size);
}
