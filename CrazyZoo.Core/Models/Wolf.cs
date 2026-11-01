namespace CrazyZoo.Core.Models;

public class Wolf : Animal
{
    public Wolf(string name)
        : base(name, 100)
    {
    }

    public override string NormalAction()
    {
        Energy -= 10;
        return $"{Name} hunts";
    }

    public override string CrazyAction()
    {
        Energy += 15;
        return $"{Name} howls at the moon";
    }
}