using CrazyZoo.Core.Models;

namespace CrazyZoo.Core.Repositories;

public interface IRepository<T>
    where T : Animal
{
    void Add(T item);

    void Remove(T item);

    IReadOnlyCollection<T> GetAll();

    T? Find(Func<T, bool> predicate);
}
