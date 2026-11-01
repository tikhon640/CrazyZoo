namespace CrazyZoo.Core.Models;

public class Fox : Animal
{
    public Fox(string name)
        : base(name, 100)
    {
    }

    public override string NormalAction()
    {
        Energy -= 10;
        return $"{Name} searches for food";
    }

    public override string CrazyAction()
    {
        Energy += 15;
        return $"{Name} performs magic tricks";
    }
}