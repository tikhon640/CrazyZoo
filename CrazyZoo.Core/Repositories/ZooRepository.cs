using CrazyZoo.Core.Events;
using CrazyZoo.Core.Models;

namespace CrazyZoo.Core.Repositories;

public class ZooRepository : Repository<Animal>
{
    public event EventHandler<AnimalEventArgs>? AnimalAdded;

    public event EventHandler<AnimalEventArgs>? AnimalRemoved;

    public event EventHandler<CrazyActionEventArgs>? CrazyActionPerformed;

    public void AddAnimal(Animal animal)
    {
        Add(animal);

        AnimalAdded?.Invoke(
            this,
            new AnimalEventArgs(animal));
    }

    public void RemoveAnimal(Animal animal)
    {
        Remove(animal);

        AnimalRemoved?.Invoke(
            this,
            new AnimalEventArgs(animal));
    }

    public void PerformCrazyAction(Animal animal)
    {
        string result = animal.CrazyAction();

        CrazyActionPerformed?.Invoke(
            this,
            new CrazyActionEventArgs(
                animal,
                result));
    }
}