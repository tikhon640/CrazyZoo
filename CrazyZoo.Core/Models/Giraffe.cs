namespace CrazyZoo.Core.Models;

public class Giraffe : Animal
{
    public Giraffe(string name) : base(name, 100)
    {
    }

    public override string NormalAction()
    {
        Energy -= 10;
        return $"{Name} sööb puulehti";
    }

    public override string CrazyAction()
    {
        Energy += 10;
        return $"{Name} laulab ooperit";
    }
}
