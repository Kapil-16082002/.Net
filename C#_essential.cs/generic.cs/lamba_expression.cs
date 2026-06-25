✅🔥Lambda Expressions:
A Lambda Expression is a concise way to write anonymous functions (functions without names) in C#.
It allows you to write inline code blocks that can be passed as arguments, assigned to delegates, or used in LINQ queries.

✅Syntax:
(parameters) => expression
or
(parameters) =>
{
    // statements
}
The => operator is called the Lambda Operator and is read as "goes to".

----------------------------------------------------------------------

✅🔥 Why Do We Need Lambda Expressions?
Before Lambda Expressions, developers used:
    1. Normal Methods
    2. Anonymous Methods
Example Using Normal Method
using System;
delegate int Calculate(int a, int b);
class Program
{
    static int Add(int a, int b)
    {
        return a + b;
    }
    static void Main()
    {
        Calculate calc = Add;
        Console.WriteLine(calc(10, 20));
    }
}
Using Anonymous Method
Calculate calc = delegate(int a, int b)
{
    return a + b;
};
Still verbose.


✅🔥 Using Lambda:
Calculate calc = (a, b) => a + b;
Much shorter and more readable.

=================================================================================================================

✅🔥 Relationship Between Anonymous Methods and Lambda Expressions
Anonymous Method:
delegate(int x)
{
    return x * x;
};
Equivalent Lambda:
x => x * x
Lambda Expressions were introduced in C# 3.0 primarily to support LINQ.

===========================================================================================================

✅🔥 A lambda expression with no parameters uses empty parentheses () before the => operator.
// => lambda opeartor
Syntax
() => expression

or

() =>
{
    // multiple statements
}

✅🔥Example 1: No Parameter, No Return Value
using System;
class Program
{
    static void Main()
    {
        Action greet = () =>
        {
            Console.WriteLine("Hello, Welcome to C#");
        };
        greet();
    }
}
Output:
Hello, Welcome to C#
Explanation:
Action represents a method that returns void.
() means no input parameters.
=> separates parameters from the method body.
greet() executes the lambda.

Equivalent normal method:
static void Greet()
{
    Console.WriteLine("Hello, Welcome to C#");
}
--------------------------------------------------------

✅🔥Example 2: No Parameter, Returns a Value
using System;
class Program
{
    static void Main()
    {
        Func<int> getNumber = () => 100;

        Console.WriteLine(getNumber());
    }
}
Output: 100
Func<int> means:
    No parameters
    Returns int
    Lambda body returns 100.
Equivalent method:
static int GetNumber()
{
    return 100;
}
------------------------------------------------------------

✅🔥Example 4: Lambda Assigned to Delegate
using System;
delegate void PrintMessage();
class Program
{
    static void Main()
    {
        PrintMessage msg = () =>
        {
            Console.WriteLine("Custom Delegate Lambda");
        };

        msg();
    }
}
Output: Custom Delegate Lambda
-------------------------------------------------------------

✅🔥Example 5: Multi-line Lambda with No Parameters
using System;
class Program
{
    static void Main()
    {
        Func<int> calculate = () =>
        {
            int a = 10;
            int b = 20;
            return a + b;
        };
        Console.WriteLine(calculate());
    }
}
---------------------------------------------------------

✅🔥Lambda with LINQ:
This is where Lambda Expressions are heavily used.

Without Lambda:
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
List<int> result = numbers.FindAll(IsEven);
static bool IsEven(int n)
{
    return n % 2 == 0;
}
With Lambda:
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
var result = numbers.Where(n => n % 2 == 0);
foreach (var item in result)
{
    Console.WriteLine(item);
}
-----------------------------------------------------------

✅🔥Lambda Capturing Variables (Closures)
A Lambda can access variables outside its scope.
int multiplier = 10;
Func<int, int> multiply = x => x * multiplier;
Console.WriteLine(multiply(5));

Here the lambda captures the variable multiplier.
This feature is called Closure.

------------------------------------------------------------

✅🔥Lambda Type Inference:
Compiler automatically determines parameter types.

Func<int, int, int> add = (x, y) => x + y;
Compiler understands:
x -> int
y -> int
No need to write: (int x, int y) => x + y    , unless required.

---------------------------------------------------------------































