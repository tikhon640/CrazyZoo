using CrazyZoo.Core.Interfaces;

namespace CrazyZoo.Core.Models;

public class Lion : Animal, IClimb
{
    public Lion(string name)
        : base(name, 100)
    {
    }

    public override string NormalAction()
    {
        Energy -= 15;
        return $"{Name} möirgab";
    }

    public string Climb()
    {
        Energy -= 10;
        return $"{Name} ronib kivile";
    }

    public override string CrazyAction()
    {
        Energy += 25;
        return $"{Name} hakkas loomaaia giidiks";
    }
}