using MotoApp.Data.Entities;

namespace MotoApp.Data.Repositories;

internal interface IReadRepository<out T> where T : class, IEntity
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
}