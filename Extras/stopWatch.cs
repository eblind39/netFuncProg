using System.Diagnostics;

namespace Features.Extras;

public class StopWatchFeat
{
    public static void RunStopWatch()
    {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // ... This takes 10 seconds to finish.
        for (int i = 0; i < 400; i++)
        {
            System.Threading.Thread.Sleep(1);
        }

        // Stop.
        stopwatch.Stop();

        // Write hours, minutes and seconds.
        Console.WriteLine("Time elapsed: {0:hh\\:mm\\:ss}", stopwatch.Elapsed);
    }
}