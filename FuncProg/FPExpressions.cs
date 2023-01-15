using System.Linq.Expressions;

namespace FunctionalProgramming.Expressions;

public class FPExpressions
{
    public static void FPExpressionSample()
    {
        Console.WriteLine(">>> Expressions Sample");
        var prm = Expression.Parameter(typeof(string));
        var toUpper = typeof(string).GetMethod("ToUpper", Type.EmptyTypes);

        if (toUpper != null) Expression.Call(prm, toUpper);
    }
}