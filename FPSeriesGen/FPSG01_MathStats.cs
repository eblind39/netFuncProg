namespace FunctionalProgramming.SeriesGeneration;

public class MathStatistics
{
    public static void RunSamples()
    {
        // product of two vectors
        int[] v1 = new int[]{ 1, 2, 3 }; // First vector
        int[] v2 = new int[]{ 3, 2, 1 }; // Second vector

        // dot product of two vectors
        IEnumerable<int> dotprod = v1.Zip(v2, (a, b) => a * b);
        foreach(int res in dotprod) Console.WriteLine($"{res}");
    }
}