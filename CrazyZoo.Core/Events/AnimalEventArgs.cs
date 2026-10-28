using CrazyZoo.Core.Models;

namespace CrazyZoo.Core.Events;

public class AnimalEventArgs : EventArgs
{
    public Animal SourceAnimal { get; }

    public AnimalEventArgs(Animal sourceAnimal)
    {
        SourceAnimal = sourceAnimal;
    }
}
