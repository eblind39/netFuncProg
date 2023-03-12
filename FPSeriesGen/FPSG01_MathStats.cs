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
        FindMark();
        ArrayDominator();
        MinCurrencyBills();
        MovingAverages();
        CummulativeSum();
        LSystemGrammar();
        AlgaeGrowth();
        KochCurve();
        SierpinskiTriangle();
        Fibonacci();
        Permutations();
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

    private static void LSystemGrammar()
    {
        string algae = "A";

        Func<string, string> transformA = x => x.Replace("A", "AB");
        Func<string, string> marksBs = x => x.Replace("B", "[B]");
        Func<string, string> transformB = x => x.Replace("[B]", "A");

        int length = 7;
        Enumerable.Range(1, length).ToList()
            .ForEach(k => algae = transformB(transformA(marksBs(algae))));

        Console.WriteLine($">>> Algae at 7th iteration: {algae}");
    }

    private static void AlgaeGrowth()
    {
        Console.WriteLine($">>> Algae growth in each iteration");

        string algae = "A";

        Func<string, string> transformA = x => x.Replace("A", "B");
        Func<string, string> marksBs = x => x.Replace("B", "[B]");
        Func<string, string> transformB = x => x.Replace("[B]", "A");

        int length = 7;
        IEnumerable<KeyValuePair<int, string>> result = Enumerable.Range(1, length)
            .Select(k => new KeyValuePair<int, string>(
                k, algae = transformB(transformA(marksBs(algae)))
            ));

        foreach (KeyValuePair<int, string> rslt in result)
            Console.WriteLine($"{rslt.Key}\n\n{rslt.Value}");
    }

    private static void KochCurve()
    {
        string koch = "F";

        Func<string, string> transform = x => x.Replace("F", "F+F-F-F+F");

        int length = 3;

        // Initialize the location and direction of the turtle
        string command = @"home
        setxy 10 340
        right 90
        ";

        // Finish it in the next line so a new line appers in the command
        command += Enumerable.Range(1, length)
            .Select(k => koch = transform(koch))
            .Last()
            .Replace("F", "forward 15")
            .Replace("+", Environment.NewLine + "Left 90" +
                    Environment.NewLine)
            .Replace("-", Environment.NewLine + "Right 90" +
                    Environment.NewLine);

        Console.WriteLine(">>> Koch Curve: ", command.ToString());
    }

    private static void SierpinskiTriangle()
    {
        string sierpinskiTriangle = "A";

        Func<string, string> transformA = x => x.Replace("A", "B-A-B");
        Func<string, string> markBs = x => x.Replace("B", "[B]");
        Func<string, string> transformB = x => x.Replace("[B]", "A+B+A");

        int length = 6;

        Enumerable.Range(1, length)
            .ToList()
            .ForEach(k => sierpinskiTriangle =
                transformB(markBs(sierpinskiTriangle)));

        sierpinskiTriangle
            .Replace("A", "forward 5" + Environment.NewLine)
            .Replace("B", "forward 5" + Environment.NewLine)
            .Replace("+", "left 60" + Environment.NewLine)
            .Replace("-", "right 60" + Environment.NewLine);

        Console.WriteLine(">>> Sierpinski Triangle: LOGO commands for drawing the <-");
        Console.WriteLine(sierpinskiTriangle);
    }

    private static void Fibonacci()
    {
        Console.WriteLine(">>> Fibonacci Numbers");
        List<ulong> fibonacciNumbers = new List<ulong>();
        Enumerable.Range(0, 200)
            .ToList()
            .ForEach(k =>
                fibonacciNumbers.Add(k <= 1 ? 1 :
                fibonacciNumbers[k - 2] + fibonacciNumbers[k - 1]));

        int counter = 0;
        fibonacciNumbers.ForEach(k =>
        {
            if (counter <= 10)
                Console.WriteLine($"Fib Number: {k}");
            counter++;
        });
    }

    private static HashSet<string> GeneratePartialPermutation(string word)
    {
        return new HashSet<string>(Enumerable.Range(0, word.Length)
            .Select(i => word.Remove(i, 1).Insert(0, word[i].ToString())));
    }

    private static void Permutations()
    {
        Console.WriteLine(">>> Pwermutations");
        HashSet<string> perms = GeneratePartialPermutation("abc");

        Enumerable.Range(0, 2)
            .ToList()
            .ForEach
            (
                c =>
                {
                    Enumerable.Range(0, perms.Count())
                        .ToList()
                        .ForEach
                        (
                            i => GeneratePartialPermutation(perms.ElementAt(i))
                                .ToList().ForEach(p => perms.Add(p))
                        );

                    Enumerable.Range(0, perms.Count())
                    .ToList()
                    .ForEach
                    (
                        i => GeneratePartialPermutation(new string
                            (perms.ElementAt(i).ToCharArray()
                            .Reverse().ToArray())
                        )
                        .ToList().ForEach(p => perms.Add(p))
                    );
                });
        var result = perms.OrderBy(p => p);

        result.ToList().ForEach(x => Console.WriteLine($"item: {x}"));
    }
}