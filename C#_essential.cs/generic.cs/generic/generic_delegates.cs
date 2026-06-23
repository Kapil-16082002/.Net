✅🔥Generic Delegates
A Generic Delegate is a delegate that can work with any data type using type parameters (T), making it reusable, type-safe, and flexible.
Instead of creating multiple delegates for different types, we define one generic delegate.


✅🔥Why Do We Need Generic Delegates?

❌ Without Generic Delegates
public delegate void IntPrinter(int value);
public delegate void StringPrinter(string value);
public delegate void DoublePrinter(double value);
Problems:
Code duplication
Hard to maintain
Not scalable
Every new type requires a new delegate


Solution: Generic Delegate
✔ One delegate for all types
public delegate void Printer<T>(T value);// Now it works for any type.


---------------------------------------------------------

✅🔥Example 1: Basic Generic Delegate
using System;
public delegate void Printer<T>(T value);
class Program
{
    static void PrintInt(int value)
    {
        Console.WriteLine("Int: " + value);
    }
    static void PrintString(string value)
    {
        Console.WriteLine("String: " + value);
    }
    static void Main()
    {
        Printer<int> intPrinter = PrintInt;
        Printer<string> stringPrinter = PrintString;
        intPrinter(100);
        stringPrinter("Kapil");
    }
}

----------------------------------------------------

✅🔥Example 2: Generic Delegate with Lambda

We can directly use lambda expressions.
using System;
public delegate void Printer<T>(T value);
class Program
{
    static void Main()
    {
        Printer<int> p1 = x => Console.WriteLine(x * 2);
        Printer<string> p2 = x => Console.WriteLine(x.ToUpper());
        p1(10);
        p2("kapil");
    }
}

--------------------------------------------------

Example 3: Generic Delegate with Return Type
public delegate T Transformer<T>(T value);

class Program
{
    static int Square(int x)
    {
        return x * x;
    }

    static string Upper(string s)
    {
        return s.ToUpper();
    }

    static void Main()
    {
        Transformer<int> t1 = Square;
        Transformer<string> t2 = Upper;

        Console.WriteLine(t1(5));
        Console.WriteLine(t2("kapil"));
    }
}
-------------------------------------------------


Example 4: Generic Delegate with Multiple Parameters
public delegate TResult Calculator<T1, T2, TResult>(T1 a, T2 b);
class Program
{
    static int Add(int a, int b)
    {
        return a + b;
    }
    static string Concat(string a, string b)
    {
        return a + b;
    }
    static void Main()
    {
        Calculator<int, int, int> calc1 = Add;
        Calculator<string, string, string> calc2 = Concat;
        Console.WriteLine(calc1(10, 20));
        Console.WriteLine(calc2("Kapil ", "Papa jii"));
    }
}
=================================================================================================================

✅🔥 Built-in Generic Delegates in C#
C# already provides generic delegates:

1. Func<T>
Used when method RETURNS a value.
Func<int, int, int> add = (a, b) => a + b;
Console.WriteLine(add(10, 20));


2. Action<T>
Used when method RETURNS void.
Action<string> print = x => Console.WriteLine(x);
print("Hello Kapil");


3. Predicate<T>
Returns only bool.

Predicate<int> isEven = x => x % 2 == 0;
Console.WriteLine(isEven(10));
Console.WriteLine(isEven(7));


