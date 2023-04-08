using FunctionalProgramming.Models;
namespace FunctionalProgramming.SeriesGeneration;

public partial class MathStatistics
{
    public static void RunSamples()
    {
        LSystemGrammar();
        AlgaeGrowth();
        KochCurve();
        SierpinskiTriangle();
        Fibonacci();
        Permutations();
        PowerSet();
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

    public static void PowerSet()
    {
        string word = "abc";
        HashSet<string> perms = GeneratePartialPermutation(word);
        Enumerable.Range(0, word.length).ToList().ForEach(x =>
            Enumerable.Range(0, word.length)
            .ToList()
            .ForEach(z =>
                {
                    perms.Add(perms.ElementAt(x).Substring(0, z));
                    perms.Add(perms.ElementAt(x).Substring(z + 1));
                }
            ));
        
        perms.Select(p => new string(p.ToCharArray()
            .OrderBy(x => x)
            .ToArray()
            .Distinct()
            .OrderBy(p => p.Length)
        ));
    }
}