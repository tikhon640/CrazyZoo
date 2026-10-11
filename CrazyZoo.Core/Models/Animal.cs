namespace CrazyZoo.Core.Models;

public abstract class Animal
{
    private int energy;

    public string Name { get; protected set; }

    public int Energy
    {
        get => energy;
        protected set
        {
            if (value < 0)
                energy = 0;
            else if (value > 100)
                energy = 100;
            else
                energy = value;
        }
    }

    protected Animal(string name, int energy)
    {
        Name = name;
        Energy = energy;
    }

    public abstract string NormalAction();

    public abstract string CrazyAction();

    public virtual string GetInfo()
    {
        return $"{Name} | Energy: {Energy}";
    }

    public override string ToString()
    {
        return $"{Name} ({Energy})";
    }
}