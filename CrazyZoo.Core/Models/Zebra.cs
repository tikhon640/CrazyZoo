namespace CrazyZoo.Core.Models;

public class Zebra : Animal
{
    public Zebra(string name) : base(name, 100)
    {
    }

    public override string NormalAction()
    {
        Energy -= 10;
        return $"{Name} sööb rohtu";
    }

    public override string CrazyAction()
    {
        Energy += 10;
        return $"{Name} värvis triibud vikerkaarevärviliseks";
    }
}