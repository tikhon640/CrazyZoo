using CrazyZoo.Core.Models;

namespace CrazyZoo.Core.Repositories;

public class Repository<T> : IRepository<T>
    where T : Animal
{

    public void Add(T item)
    {
        items.Add(item);
    }

    public void Remove(T item)
    {
        items.Remove(item);
    }

    {
    }

    public T? Find(Func<T, bool> predicate)
    {
        return items.FirstOrDefault(predicate);
    }
}