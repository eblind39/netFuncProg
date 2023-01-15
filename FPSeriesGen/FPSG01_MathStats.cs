using FunctionalProgramming.Models;
namespace FunctionalProgramming.SeriesGeneration;

public class MathStatistics
{
    public static void RunSamples()
    {
        DotProductVectors();
        PythagoreanTriplets();
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

        IEnumerable<RightTringle> pts = Enumerable.Range(2, 4)
            .Select(c => new RightTringle{
                            Length = 2 * c,
                            Height = c * c - 1,
                            Hypotenuse = c * c + 1
                        });

        Console.WriteLine("Length\t\t Height\t\t Hypotenuse:");
        foreach(RightTringle pt in pts) 
            Console.WriteLine($"{pt.Length}\t\t {pt.Height}\t\t {pt.Hypotenuse}");
    }
}