using System.Linq.Expressions;

namespace FunctionalProgramming.Expressions;

public class FPExpressions
{
    public static void FPExpressionSample()
    {
        Console.WriteLine(">>> Expressions Sample");
        var prm = Expression.Parameter(typeof(string));
        var toUpper = typeof(string).GetMethod("ToUpper", Type.EmptyTypes);

        if (toUpper != null) {
            var body = Expression.Call(prm, toUpper);
            var lambda = Expression.Lambda(body, prm);
            var result = lambda.Compile().DynamicInvoke("ernst");
            Console.WriteLine($"Expression Call result: {result?.ToString()}");
        }
    }
}