// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Functional Programming!");

Func<int, int> f = x => x + 1;  // describing f(x) = x + 1
Func<int, int> g = x => x + 2;  // describing g(x) = x + 2
Func<Func<int, int>, Func<int, int>, int, int> fog = (f1, g1, x) => f1.Invoke(g1.Invoke(x));
Console.WriteLine(fog.Invoke(f, g, 2));

Func<string, int, bool> evn = (s, x) => string.Equals(s, "even") && (x%2==0);
Func<string, int, bool> odd = (s, x) => string.Equals(s, "odd") && !(x%2==0);
Console.WriteLine($">>> Even? {evn.Invoke("even", 6)}");
Console.WriteLine($">>> Odd? {odd.Invoke("odd", 9)}");

Console.WriteLine(">>> By using Method Syntax");
Func<string, string> selector = s => s.ToString().ToUpper();
string[] words = new string[] { "orange", "elephant", "monkey", "kangaroo" };
IEnumerable<string> aWords = words.Select(selector);
foreach(string s in aWords) Console.Write($"{s} ");

Console.WriteLine("\n>>> By using Lambda Expression");
IEnumerable<string> bWords = words.Select(s => s.ToString().ToUpper());
foreach(string s in bWords) Console.Write($"{s} ");

Console.WriteLine("\n>>> int[] to int?[]");
Func<int, int?> toNi = x => (int?)x;
int[] myInts = new int[] {1, 2, 3, 4};
IEnumerable<int?> myNullInts = myInts.Select(toNi);
foreach(int? ni in myNullInts) Console.Write($"{ni} ");