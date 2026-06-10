✅🔥C# Identifiers
All C# variables must be identified with unique names.
These unique names are called identifiers.

Identifiers can be short names (like x and y) or more descriptive names (age, sum, totalVolume).
Note: It is recommended to use descriptive names in order to create understandable and maintainable code:

Example: Get your own C# Server
int minutesPerHour = 60; // Good
int m = 60;  // OK, but not so easy to understand what m actually is

===================================================================================================================


✅🔥🚀C# Variables:
Variables are containers for storing data values.

In C#, there are different types of variables (defined with different keywords), for example:
int - stores integers (whole numbers), without decimals, such as 123 or -123
double - stores floating point numbers, with decimals, such as 19.99 or -19.99
char - stores single characters, such as 'a' or 'B'. Char values are surrounded by single quotes
string - stores text, such as "Hello World". String values are surrounded by double quotes
bool - stores values with two states: true or false

Examples:
int myNum = 5;
double myDoubleNum = 5.99D;
char myLetter = 'D';
bool myBool = true;
string myText = "Hello";

====================================================================================================================

✅🔥Implicitly typed local variables(var)

An implicitly typed local variable is a local variable whose data type is automatically determined by the C# compiler based on the assigned value.
It is declared using the var keyword.
var number = 100;
Here, you did not write int, but the compiler automatically infers:
Example:
using System;
class Program
{
    static void Main()
    {
        var number = 100;
        Console.WriteLine(number);    // 100
        Console.WriteLine(number.GetType()); // System.Int32
    }
}
The compiler converts: var number = 100; into int number = 100; before compilation.



✅🔥🚀 var Works with Complex Types
Suppose:
var list = new List<int>();
Compiler converts it into: List<int> list = new List<int>();

🚀 Example with Collections
using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        var numbers = new List<int>();
        numbers.Add(10);
        numbers.Add(20);
        foreach(var item in numbers)
        {
            Console.WriteLine(item);
        }
    }
}
🚀 Example with LINQ:
Without var:
IEnumerable<int> result = numbers.Where(x => x > 5);

With var:
var result = numbers.Where(x => x > 5);
Cleaner and easier to read.




✅🧠 How Does var Work?
Suppose you write: var x = 100;
Compiler sees: 100
Compiler knows: 100 is Int32
Compiler internally converts: int x = 100;
So var exists only during compilation. After compilation, there is no var.



✅🧠🚀 var is NOT dynamic
var x = 10;
x = "Kapil"; // ❌ Compile Time Error
Because compiler inferred: int x = 10;
So later: x = "Kapil"; becomes int x = "Kapil"; which is invalid. ❌



🚀 var Requires Initialization

var x; //❌ Invalid, Compiler Error, Because compiler cannot determine the type.

✅ Valid
var x = 10; //Compiler immediately knows:x is int


🚀Cannot Assign null Initially
var x = null;//❌ Error, Compiler cannot determine the type from null.
✅ Correct:
string x = null;
or
var x = (string)null;

--------------------------------------------------------------------------

🚀 Where Can var Be Used?
✅ Local Variables
var x = 100;

✅ Inside Loops
foreach(var item in numbers)
{
    Console.WriteLine(item);
}

✅ LINQ Queries
var result = numbers.Where(x => x > 10);

✅ Anonymous Types
var person =
    new
    {
        Name = "Kapil",
        Age = 24
    };
Compiler creates an anonymous type automatically.

----------------------------------------------------------------

❌✅ Where var Cannot Be Used?
1.❌ Class Fields
class Employee
{
    var x = 10;
}
Compiler Error.

2.❌ Method Parameters
void Print(var x)
{
}
Not allowed.

❌ Return Type
var GetData()
{
}
Not allowed.
====================================================================================================================

✅🔥📌 What is dynamic?
The dynamic keyword tells the compiler:
"Do not perform type checking at compile time. Determine the type at runtime."
Unlike var, whose type is fixed at compile time, dynamic defers type resolution until the program is running.

🎯 Syntax:
dynamic variableName = value;

Example:
dynamic x = 100;
The compiler does not permanently treat x as int.

Example:
using System;
class Program
{
    static void Main()
    {
        dynamic value = 100;
        Console.WriteLine(value);

        value = "Kapil Papa jii";
        Console.WriteLine(value);

        value = true;
        Console.WriteLine(value);
    }
}
-------------------------------------------------------

✅🔥📌 Can dynamic cause runtime exceptions ?✅ Yes.
Example:
dynamic x = 10;
x.Print();// Compiles successfully but throws a runtime exception because int has no Print() method.


class ExampleClass
{
    public ExampleClass() { }
    public ExampleClass(int v) { }

    public void exampleMethod1(int i) { }
    public void exampleMethod2(string str) { }
}
static void Main(string[] args)
{
    ExampleClass ec = new ExampleClass();
    ec.exampleMethod1(10, 4); //  will give compiler error

    dynamic dynamic_ec = new ExampleClass();
    dynamic_ec.exampleMethod1(10, 4); // will not give compiler error but causes a run-time exception.


    dynamic_ec.someMethod("some argument", 7, null); // will not give compiler error but causes a run-time exception.
    dynamic_ec.nonexistentMethod(); // will not give compiler error but causes a run-time exception.
}



🚀 Advantages of dynamic:
✅ 1. Flexible: Can store any type.
             dynamic value = 100;
             value = "Kapil";
             value = true;
✅ 2. Useful with Reflection: Reduces manual casting.
✅ 3. Convenient for Unknown Data: Useful when object structure is not known until runtime.
✅ 4. Easier COM Interoperability: Works well with Office automation and legacy COM components.


❌ Disadvantages of dynamic
❌ 1. No Compile-Time Type Checking
dynamic x = 10;
x.UnknownMethod();// Compiles successfully. Fails at runtime.

❌ 2. Slower Performance: Runtime binding introduces overhead.


Explore:
🚀 Using dynamic with Methods
🚀 dynamic with Anonymous Types
🚀 dynamic with JSON
🚀 dynamic with Reflection
🚀 dynamic vs object
| Feature               | object          | dynamic         |
| --------------------- | --------------- | --------------- |
| Base Type             | `System.Object` | `System.Object` |
| Compile-time Checking | ✅ Yes           | ❌ No         |
| Runtime Checking      | Limited         | ✅ Yes          |
| Casting Required      | Usually         | Usually No      |
| Performance           | Faster          | Slower          |

==================================================================================================================




