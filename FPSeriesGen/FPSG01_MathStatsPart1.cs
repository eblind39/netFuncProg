using FunctionalProgramming.Models;
namespace FunctionalProgramming.SeriesGeneration;

public partial class MathStatistics
{
    public static void RunSamples()
    {
        DotProductVectors();
        PythagoreanTriplets();
        IEnumAndLists();
        WeightedSum();
        PercentileCalc();
        FindMark();
        ArrayDominator();
        MinCurrencyBills();
        MovingAverages();
        CummulativeSum();
    }

    static private void DotProductVectors()
    {
        Console.WriteLine(">>> dot product of two vectors");
        // dot product of two vectors
        int[] v1 = new int[] { 1, 2, 3 }; // First vector
        int[] v2 = new int[] { 3, 2, 1 }; // Second vector

        IEnumerable<int> dotprod = v1.Zip(v2, (a, b) => a * b);
        foreach (int res in dotprod) Console.WriteLine($"{res}");
    }

    static private void PythagoreanTriplets()
    {
        Console.WriteLine(">>> Pythagorean Triplets");

        IEnumerable<RightTringle> pts = Enumerable.Range(2, 10)
            .Select(c => new RightTringle {
                Length = 2 * c,
                Height = c * c - 1,
                Hypotenuse = c * c + 1
            }).ToList<RightTringle>();

        Console.WriteLine("SeedVal\t\t Length\t\t Height\t\t Hypotenuse:");
        foreach (RightTringle pt in pts)
            Console.WriteLine($"{pt.Length / 2}\t\t {pt.Length}\t\t {pt.Height}\t\t {pt.Hypotenuse}");
    }

    static private void IEnumAndLists()
    {
        Console.WriteLine(">>> IEnumerable and Lists");

        Func<int, bool> greatherThanTwo = x => x > 2;
        List<int> numbers = new() { 1, 2, 3, 4, 5 };
        IEnumerable<bool> gtt = numbers.Select(greatherThanTwo);
        numbers.Add(6);
        foreach (bool bval in gtt) Console.WriteLine($"Greather Than Two? {bval.ToString()} ");

        IEnumerable<int?> wnmbrs = numbers.Zip(gtt, (a, b) => (int?)(b ? a : null));
        foreach (int? num in wnmbrs) Console.WriteLine($"Curr val: {num}");
    }

    private static void WeightedSum()
    {
        int[] values = new int[] { 1, 2, 3 };
        int[] weights = new int[] { 3, 2, 1 };

        int WSum = values.Zip(weights, (value, weight) => value * weight).Sum();

        Console.WriteLine($"\n>>> Weighted Sum: {WSum}");
    }

    private static void PercentileCalc()
    {
        Console.WriteLine($"\n>>> Percentile Calc");

        int[] nums = new int[] { 20, 15, 31, 34, 35, 40, 50, 90, 99, 100 };
        IEnumerable<KeyValuePair<int, double>> percentiles = nums
        .ToLookup(k => k, k => nums.Where(n => n < k))
        .Select(k => new KeyValuePair<int, double>(k.Key, 100 * ((double)k.First().Count() / (double)nums.Length)));

        foreach (KeyValuePair<int, double> prct in percentiles)
            Console.WriteLine($"{prct.Key}\t\t{prct.Value}");
    }

    private static void FindMark()
    {
        Console.WriteLine($"\n>>> Find Mark");

        int[] marks = new int[] { 20, 15, 31, 34, 50, 40, 90, 99, 100 };

        IEnumerable<MarksRank> markranks =
            marks
            .ToLookup(k => k, k => marks.Where(n => n >= k))
            .Select(k => new MarksRank {
                Marks = k.Key,
                Rank = 10 * ((double)k.First().Count() / (double)marks.Length)
            });

        foreach (MarksRank mrnk in markranks)
            Console.WriteLine($"{mrnk.Marks}\t\t{mrnk.Rank}");
    }

    private static void ArrayDominator()
    {
        int[] intarr = new int[] { 3, 4, 3, 2, 3, -1, 3, 3 };
        int dominator = intarr.ToLookup(a => a).First(a => a.Count() > intarr.Length / 2).Key;

        Console.WriteLine($">>> Array Dominator: {dominator}");
    }

    private static void MinCurrencyBills()
    {
        Console.WriteLine($"\n>>> Min Currency Bills");

        // these are available currencies
        int[] curvals = new int[] { 1000, 500, 200, 100, 50, 20, 10, 5, 1 };

        int amount = 2548;
        int tmpAmount = amount;

        Dictionary<int, int> map = new Dictionary<int, int>();

        curvals.OrderByDescending(c => c)
            .ToList()
            .ForEach(c => { map.Add(c, amount / c); amount = amount % c; });

        IEnumerable<KeyValuePair<int, int>> dominations = map.Where(m => m.Value != 0);

        Console.WriteLine($"For: {tmpAmount}");
        foreach (KeyValuePair<int, int> curval in dominations)
            Console.WriteLine($"{curval.Key}\t\t\t{curval.Value}");
    }

    private static void MovingAverages()
    {
        Console.WriteLine($"\n>>> Moving Averages");

        List<double> numbers = new List<double>() { 1, 2, 3, 4 };
        List<double> movingAvgs = new List<double>();

        // moving window is of length 4.
        int windowSize = 2;

        Enumerable.Range(0, numbers.Count - windowSize + 1)
            .ToList()
            .ForEach(k => movingAvgs.Add(numbers.Skip(k).Take(windowSize).Average()));

        // listing moving averages
        foreach (double mvgavg in movingAvgs)
            Console.WriteLine($"{mvgavg}");
    }

    private static void CummulativeSum()
    {
        Console.WriteLine($"\n>>> Cummulative Sum");

        List<KeyValuePair<int, int>> cumSums = new List<KeyValuePair<int, int>>();
        IEnumerable<int> range = Enumerable.Range(1, 10);
        range.ToList().ForEach(k => cumSums.Add(
            new KeyValuePair<int, int>(k, range.Take(k).Sum())));

        foreach (KeyValuePair<int, int> csum in cumSums)
            Console.WriteLine($"{csum.Key}\t\t{csum.Value}");
    }
}