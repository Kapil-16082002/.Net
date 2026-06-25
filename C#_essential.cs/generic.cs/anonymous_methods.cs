✅🔥What is an Anonymous Method? ❌   ✔
An Anonymous Method is a method without a name.
Normally, when using delegates, we create a separate method:
delegate void PrintDelegate(string message);
class Program
{
    static void Print(string msg)
    {
        Console.WriteLine(msg);
    }
    static void Main()
    {
        PrintDelegate pd = Print;
        pd("Hello");
    }
}
Here Print() is a named method.


❌Problem:
Suppose the method is used only once. Creating a separate method feels unnecessary.
static void Print(string msg)
{
    Console.WriteLine(msg);
}
Why create this method if it's never reused? This is where Anonymous Methods help.

-------------------------------------------------------------------

✅🔥Anonymous Method Syntax:
delegate(parameter_list)
{
    // code
};
General form:
DelegateType variable = delegate(parameters)
{
    // implementation
};

Example:
using System;
delegate void PrintDelegate(string message);
class Program
{
    static void Main()
    {
        PrintDelegate pd = delegate(string message) // expecting string type argument
        {
            Console.WriteLine(message);
        };
        pd("Hello Kapil"); // pass argument here
    }
}

-------------------------------------------------

✅🔥Anonymous Method with Parameters
delegate int AddDelegate(int a, int b);
class Program
{
    static void Main()
    {
        AddDelegate add = delegate(int x, int y)
        {
            return x + y;
        };
        Console.WriteLine(add(10, 20));
    }
}
------------------------------------------------

✅🔥Anonymous Method Returning Value
delegate bool CheckNumber(int number);

class Program
{
    static void Main()
    {
        CheckNumber check = delegate(int n)
        {
            return n % 2 == 0;
        };

        Console.WriteLine(check(10));
    }
}
Output:True

----------------------------------------------------

✅🔥Anonymous Method with Multiple Statements
delegate void Process(int n);
class Program
{
    static void Main()
    {
        Process p = delegate(int number)
        {
            Console.WriteLine("Processing...");
            Console.WriteLine($"Number = {number}");
            Console.WriteLine("Completed");
        };
        p(100);
    }
}



















