using CrazyZoo.Core.Events;
using CrazyZoo.Core.Models;

namespace CrazyZoo.Core.Repositories;

public abstract class AnimalRepositoryBase<T>
    : Repository<T>
    where T : Animal
{
    public event EventHandler<AnimalEventArgs>? AnimalAdded;

    public event EventHandler<AnimalEventArgs>? AnimalRemoved;

    public event EventHandler<AnimalEventArgs>? CrazyActionPerformed;

    public event EventHandler<AnimalReactionEventArgs>? ReactionGenerated;

    public void AddAnimal(T animal)
    {
        Add(animal);

        AnimalAdded?.Invoke(
            this,
            new AnimalEventArgs(animal));

        foreach (var other in items)
        {
            if (other != animal)
            {
                ReactionGenerated?.Invoke(
                    this,
                    new AnimalReactionEventArgs(
                        other,
                        $"{other.Name} welcomes {animal.Name}"));
            }
        }
    }

    public void RemoveAnimal(T animal)
    {
        foreach (var other in items)
        {
            if (other != animal)
            {
                ReactionGenerated?.Invoke(
                    this,
                    new AnimalReactionEventArgs(
                        other,
                        $"{other.Name} says goodbye to {animal.Name}"));
            }
        }

        Remove(animal);

        AnimalRemoved?.Invoke(
            this,
            new AnimalEventArgs(animal));
    }

    public void PerformCrazyAction(T animal)
    {
        animal.CrazyAction();

        CrazyActionPerformed?.Invoke(
            this,
            new AnimalEventArgs(animal));

        foreach (var other in items)
        {
            if (other != animal)
            {
                ReactionGenerated?.Invoke(
                    this,
                    new AnimalReactionEventArgs(
                        other,
                        $"{other.Name} reacts to {animal.Name}'s crazy action"));
            }
        }
    }
}