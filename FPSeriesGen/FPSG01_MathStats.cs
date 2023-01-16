using FunctionalProgramming.Models;
namespace FunctionalProgramming.SeriesGeneration;

public class MathStatistics
{
    public static void RunSamples()
    {
        DotProductVectors();
        PythagoreanTriplets();
        IEnumAndLists();
        WeightedSum();
        PercentileCalc();
    }

    static private void DotProductVectors()
    {
        Console.WriteLine(">>> dot product of two vectors");
        // dot product of two vectors
        int[] v1 = new int[]{ 1, 2, 3 }; // First vector
        int[] v2 = new int[]{ 3, 2, 1 }; // Second vector

        IEnumerable<int> dotprod = v1.Zip(v2, (a, b) => a * b);
        foreach(int res in dotprod) Console.WriteLine($"{res}");
    }

    static private void PythagoreanTriplets()
    {
        Console.WriteLine(">>> Pythagorean Triplets");

        IEnumerable<RightTringle> pts = Enumerable.Range(2, 10)
            .Select(c => new RightTringle{
                            Length = 2 * c,
                            Height = c * c - 1,
                            Hypotenuse = c * c + 1
                        }).ToList<RightTringle>();

        Console.WriteLine("SeedVal\t\t Length\t\t Height\t\t Hypotenuse:");
        foreach(RightTringle pt in pts) 
            Console.WriteLine($"{pt.Length/2}\t\t {pt.Length}\t\t {pt.Height}\t\t {pt.Hypotenuse}");
    }

    static private void IEnumAndLists()
    {
        Console.WriteLine(">>> IEnumerable and Lists");

        Func<int, bool> greatherThanTwo = x => x > 2;
        List<int> numbers = new() { 1, 2, 3, 4, 5};
        IEnumerable<bool> gtt = numbers.Select(greatherThanTwo);
        numbers.Add(6);
        foreach(bool bval in gtt) Console.WriteLine($"Greather Than Two? {bval.ToString()} ");

        IEnumerable<int?> wnmbrs = numbers.Zip(gtt, (a, b) => (int?)(b ? a : null));
        foreach(int? num in wnmbrs) Console.WriteLine($"Curr val: {num}");
    }

    private static void WeightedSum()
    {
        int[] values = new int[]{ 1, 2, 3 };
        int[] weights = new int[] { 3, 2 , 1 };

        int WSum = values.Zip(weights, (value, weight) => value * weight).Sum();

        Console.WriteLine($"\n>>> Weighted Sum: {WSum}");
    }

    private static void PercentileCalc()
    {
        Console.WriteLine($"\n>>> Percentile Calc");
        int[] nums = new int[]{ 20, 15, 31, 34, 35, 40, 50, 90, 99, 100 };
        IEnumerable<KeyValuePair<int, double>> percentiles = nums
        .ToLookup(k => k, k => nums.Where(n => n < k))
        .Select(k => new KeyValuePair<int, double>(k.Key, 100*((double)k.First().Count() / (double)nums.Length)));

        foreach(KeyValuePair<int, double> prct in percentiles)
            Console.WriteLine($"{prct.Key}\t\t{prct.Value}");
    }
}