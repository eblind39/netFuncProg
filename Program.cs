// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Functional Programming!");

Func<int, int> f = x => x + 1;  // describing f(x) = x + 1
Func<int, int> g = x => x + 2;  // describing g(x) = x + 2
Func<string, int, bool> evn = (s, x) => string.Equals(s, "even") && (x%2==0);
Func<string, int, bool> odd = (s, x) => string.Equals(s, "odd") && !(x%2==0);

Func<Func<int, int>, Func<int, int>, int, int> fog = (f1, g1, x) => f1.Invoke(g1.Invoke(x));

Console.WriteLine(fog.Invoke(f, g, 2));
Console.WriteLine(evn.Invoke("even", 6));
Console.WriteLine(odd.Invoke("odd", 9));