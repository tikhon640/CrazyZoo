using CrazyZoo.Core.Interfaces;

namespace CrazyZoo.Core.Models;

public class Tiger : Animal, IClimb
{
    public Tiger(string name)
        : base(name, 100)
    {
    }

    public override string NormalAction()
    {
        Energy -= 10;
        return $"{Name} jookseb kiiresti";
    }

    public string Climb()
    {
        Energy -= 5;
        return $"{Name} ronib puu otsa";
    }

    public override string CrazyAction()
    {
        Energy += 20;
        return $"{Name} mängib peitust külastajatega";
    }
}
