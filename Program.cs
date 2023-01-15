using FunctionalProgramming.Init;
using FunctionalProgramming.Second;
using FunctionalProgramming.SeriesGeneration;

namespace FunctionalProgramming.Main;

public class FProg
{
    public static void Main(string[] args)
    {
        ConsoleKeyInfo ki = Console.ReadKey();
        if (ki.Key == ConsoleKey.D1) Console.WriteLine("Console read was NumPad1");
        FPInit.RunFPInit();
        FPSecond.RunFPSecond();
        MathStatistics.RunSamples();
    }
}