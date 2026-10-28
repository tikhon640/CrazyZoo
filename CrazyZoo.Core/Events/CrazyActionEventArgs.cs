using CrazyZoo.Core.Models;

namespace CrazyZoo.Core.Events;

public class CrazyActionEventArgs : EventArgs
{
    public Animal Animal { get; }

    public string Message { get; }

    public CrazyActionEventArgs(
        Animal animal,
        string message)
    {
        Animal = animal;
        Message = message;
    }
}
