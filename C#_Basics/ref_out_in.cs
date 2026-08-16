✅🔥 ref vs out vs in in C#:
All three are parameter modifiers that allow a method to work with a variable by reference.

The easiest way to remember them is:
ref  → Read + Write
out  → Write
in   → Read-only



✅🔥 1. ref
ref means the method receives a reference to an existing variable.
Rules:
The variable must be initialized before passing it.
The method can read its current value.
The method can modify its value.

using System;
class Program
{
    static void Double(ref int number)
    {
        number = number * 2;
    }
    static void Main()
    {
        int x = 10;
        Double(ref x);
        Console.WriteLine(x);  // 20
    }
}
-------------------------------------------------------

✅🔥 out
out is primarily used when a method needs to return a value through a parameter.
Rules:
The variable does NOT need to be initialized before passing it.
The method must assign a value before returning.
The method cannot use the out parameter's previous value because there isn't one that is required to be initialized.


static void GetNumber(out int number)
    {
        number = 100;
    }
static void Main()
    {
        int x;
        GetNumber(out x);
        Console.WriteLine(x); // 100
    }

Classic out example: TryParse()
   string input = "123";
   bool success = int.TryParse(input, out int number);
   Console.WriteLine(success); // True
   Console.WriteLine(number); // 123


TryParse() returns two pieces of information:
  return value → true/false
  out value    → parsed number
That's why out is very commonly used with TryParse().


-------------------------------------------------------


























