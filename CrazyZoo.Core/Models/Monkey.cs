using CrazyZoo.Core.Interfaces;

namespace CrazyZoo.Core.Models;

public class Monkey : Animal, IClimb, IFly
{
    public Monkey(string name)
        : base(name, 100)
    {
    }

    public override string NormalAction()
    {
        Energy -= 10;
        return $"{Name} sööb banaani";
    }

    public string Climb()
    {
        Energy -= 5;
        return $"{Name} ronib puu otsa";
    }

    public string Fly()
    {
        Energy -= 7;
        return $"{Name} lendas õhupalliga";
    }

    public override string CrazyAction()
    {
        Energy += 15;
        return $"{Name} varastas telefoni ja tegi selfi";
    }
}