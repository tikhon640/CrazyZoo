namespace CrazyZoo.Core.Models;

public class Elephant : Animal
{
    public Elephant(string name) : base(name, 100)
    {
    }

    public override string NormalAction()
    {
        Energy -= 10;
        return $"{Name} sööb maapähkleid";
    }

    public override string CrazyAction()
    {
        Energy += 10;
        return $"{Name} pritsib kõiki veega";
    }
}
