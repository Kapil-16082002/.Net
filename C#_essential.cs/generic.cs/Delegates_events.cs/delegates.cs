✅🔥 Delegates in C#
A Delegate is a type-safe function pointer that can store the reference (address) of a method and later invoke that method.
If you've worked with function pointers in C++, delegates are the C# equivalent, but they are:
Type-safe
Object-oriented
Secure
Support multicast (calling multiple methods)



✅🔥Memory Representation:
Stack:
del
 |
 v
Heap
Delegate Object
 |
 v
Display()
A delegate object stores method references internally.



✅🔥Why Do We Need Delegates?
Normally, you call a method directly:
class Program
{
    static void Display()
    {
        Console.WriteLine("Display Method");
    }
    static void Main()
    {
        Display();
    }
}
Output: Display Method


Sometimes we want to:
    Pass methods as parameters
    Store methods in variables
    Call different methods dynamically
That's where delegates help.

-------------------------------------------------

✅🔥Delegate Syntax
delegate returnType DelegateName(parameterList);
Example: 
delegate void MyDelegate();
This delegate can store references to methods that:
Return Type : void
Parameters  : none


Basic Example:
using System;
delegate void MyDelegate();
class Program
{
    static void Display()
    {
        Console.WriteLine("Display Method");
    }
    static void Main()
    {
        MyDelegate del = Display; // Store method reference.
        del(); // del.Invoke();
    }
}
Output: Display Method
--------------------------------------------------

✅🔥 Delegate Signature Matching:
Method signature must match delegate signature.

✅🔥Delegate with Parameters:
using System;
delegate void MyDelegate(string name);
class Program
{
    static void Greet(string name)
    {
        Console.WriteLine($"Hello {name}");
    }
    static void Main()
    {
        MyDelegate del = Greet;
        del("Kapil");
    }
}
Output: Hello Kapil

--------------------------------------------------

✅🔥Delegate with Return Type:
using System;
delegate int Calculator(int a, int b);
class Program
{
    static int Add(int x, int y)
    {
        return x + y;
    }
    static void Main()
    {
        Calculator calc = Add;
        int result = calc(10, 20);
        Console.WriteLine(result); // 30
    }
}
------------------------------------------------------


using System;
delegate void Operation();
class Program
{
    static void Execute(Operation op)
    {
        op();
    }
    static void Add()
    {
        Console.WriteLine("Add");
    }
    static void Subtract()
    {
        Console.WriteLine("Subtract");
    }
    static void Main()
    {
        Execute(Add);
        Execute(Subtract);
    }
}





































