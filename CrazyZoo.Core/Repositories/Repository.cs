namespace CrazyZoo.Core.Repositories;

public class Repository<T> : IRepository<T>
{
    private readonly List<T> items = new();

    public void Add(T item)
    {
        items.Add(item);
    }

    public void Remove(T item)
    {
        items.Remove(item);
    }

    public IEnumerable<T> GetAll()
    {
        return items;
    }

    public T? Find(Func<T, bool> predicate)
    {
        return items.FirstOrDefault(predicate);
    }
}