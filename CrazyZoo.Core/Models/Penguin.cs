using CrazyZoo.Core.Interfaces;

namespace CrazyZoo.Core.Models;

public class Penguin : Animal, ISwimmable
{
    public Penguin(string name)
        : base(name, 100)
    {
    }

    public override string NormalAction()
    {
        Energy -= 10;
        return $"{Name} sööb kala";
    }

    public string Swim()
    {
        Energy -= 5;
        return $"{Name} ujub basseinis";
    }

    public override string CrazyAction()
    {
        Energy += 20;
        return $"{Name} korraldas pingviinide diskoteegi";
    }
}
