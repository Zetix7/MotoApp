using MotoApp.Data.Entities;

namespace MotoApp.Data.Repositories;

internal interface IWriteRepository<in T> where T : class, IEntity
{
    void Add(T item);
    void Remove(T item);
    void Save();
}