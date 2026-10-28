using CrazyZoo.Core.Models;

namespace CrazyZoo.Core.Repositories;

public interface IRepository<T>
    where T : Animal
{
    void Add(T item);

    void Remove(T item);


    T? Find(Func<T, bool> predicate);
}

