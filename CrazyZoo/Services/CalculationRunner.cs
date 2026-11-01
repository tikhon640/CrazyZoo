using System.Diagnostics;
using CrazyZoo.Core.Models;

namespace CrazyZoo.Services;

public class CalculationRunner
{
    private readonly CalculationService calculationService = new();

    public async Task<List<CalculationResult>> RunSequential(
        IEnumerable<Animal> animals,
        int workload,
        CancellationToken token)
    {
        var results = new List<CalculationResult>();

        foreach (var animal in animals)
        {
            token.ThrowIfCancellationRequested();

            var result = await Task.Run(() =>
                calculationService.CalculateAnimal(
                    animal,
                    workload,
                    token));

            results.Add(result);
        }

        return results;
    }

    public async Task<List<CalculationResult>> RunParallel(
        IEnumerable<Animal> animals,
        int workload,
        CancellationToken token)
    {
        var tasks = animals.Select(animal =>
            Task.Run(() =>
                calculationService.CalculateAnimal(
                    animal,
                    workload,
                    token)));

        var results = await Task.WhenAll(tasks);

        return results.ToList();
    }
}