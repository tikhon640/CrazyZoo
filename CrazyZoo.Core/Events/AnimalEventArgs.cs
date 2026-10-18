using CrazyZoo.Core.Models;

namespace CrazyZoo.Core.Events;

public class AnimalEventArgs : EventArgs
{
    public Animal Animal { get; }

    public AnimalEventArgs(Animal animal)
    {
        Animal = animal;
    }
}