using CrazyZoo.Core.Models;

namespace CrazyZoo.Core.Events;

public class AnimalReactionEventArgs : EventArgs
{
    public Animal SourceAnimal { get; }

    public string Message { get; }

    public AnimalReactionEventArgs(
        Animal sourceAnimal,
        string message)
    {
        SourceAnimal = sourceAnimal;
        Message = message;
    }
}
