using MotoApp.Data.Entities;

namespace MotoApp.Data.Repositories;

internal class ListRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    protected readonly List<T> _items = new();

    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;
    public event EventHandler<EventArgs>? ItemsSaved;

    public IEnumerable<T> GetAll() => _items.ToList();

    public T? GetById(int id) => _items.Single(item => item.Id == id);

    public void Add(T item)
    {
        item.Id = _items.Count + 1;
        _items.Add(item);
        ItemAdded?.Invoke(this, item);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
        ItemRemoved?.Invoke(this, item);
    }

    public void Save()
    {
        foreach (var item in _items)
        {
            Console.WriteLine(item);
        }
        ItemsSaved?.Invoke(this, new EventArgs());
    }
}
