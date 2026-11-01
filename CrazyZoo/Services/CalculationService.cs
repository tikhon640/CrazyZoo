using System.Diagnostics;
using CrazyZoo.Core.Models;

namespace CrazyZoo.Services;

public class CalculationService
{
    public CalculationResult CalculateAnimal(
        Animal animal,
        int workload,
        CancellationToken token)
    {
        var stopwatch = Stopwatch.StartNew();

        try
        {
            // Uncomment for error handling demonstration:
            // if (animal.Name == "Tiger")
            // {
            //     throw new Exception("Test failure");
            // }

            double result = 0;

            for (int i = 0; i < workload; i++)
            {
                token.ThrowIfCancellationRequested();

                result += Math.Sqrt(i);
            }

            stopwatch.Stop();

            return new CalculationResult
            {
                AnimalName = animal.Name,
                Status = "Success",
                Result = result,
                Duration = stopwatch.Elapsed
            };
        }
        catch (OperationCanceledException)
        {
            stopwatch.Stop();

            return new CalculationResult
            {
                AnimalName = animal.Name,
                Status = "Cancelled",
                Result = 0,
                Duration = stopwatch.Elapsed
            };
        }
        catch (Exception ex)
        {
            stopwatch.Stop();

            return new CalculationResult
            {
                AnimalName = animal.Name,
                Status = $"Failed: {ex.Message}",
                Result = 0,
                Duration = stopwatch.Elapsed
            };
        }
    }
}