namespace CrazyZoo.Core.Models;

public class CalculationResult
{
    public string AnimalName { get; set; } = "";

    public string Status { get; set; } = "";

    public double Result { get; set; }

    public TimeSpan Duration { get; set; }
}
