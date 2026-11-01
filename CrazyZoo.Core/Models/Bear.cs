using CrazyZoo.Core.Interfaces;

namespace CrazyZoo.Core.Models;

public class Bear : Animal, IClimb
{
    public Bear(string name)
        : base(name, 100)
    {
    }

    public override string NormalAction()
    {
        Energy -= 10;
        return $"{Name} eats honey";
    }

    public string Climb()
    {
        Energy -= 5;
        return $"{Name} climbs a tree";
    }

    public override string CrazyAction()
    {
        Energy += 20;
        return $"{Name} rides a bicycle";
    }
}