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

✅🔥Delegate Syntax:
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

============================================================================================

✅🔥 There are 3 main types of delegates in C#:
✅1. Custom (User-defined) Delegates
   This is the traditional delegate where you define your own signature.
   Syntax:
   public delegate returnType DelegateName(parameters);


✅2. Built-in Generic Delegates
C# provides ready-made delegates in System namespace:
     1. Action
     2. Func
     3. Predicate
✅3. Multicast Delegates: A multicast delegate can hold references to multiple methods.

===================================================================================================================


✅🔥Multicast Delegates:
A Multicast Delegate is a delegate that can hold references to multiple methods at the same time.
When the delegate is invoked, all the methods in its invocation list are executed in the order they were added.


✅Normal Delegate:
public delegate void Notify();
static void Method1()
{
    Console.WriteLine("Method1");
}
Notify del = Method1;
del();



✅Multicast Delegate
public delegate void Notify();
static void Method1()
{
    Console.WriteLine("Method1");
}
static void Method2()
{
    Console.WriteLine("Method2");
}
Notify del = Method1;
del += Method2;
del();
Output:
  Method1
  Method2


✅🔥 Why Do We Need Multicast Delegates?
Suppose a user places an order. After placing an order, we may need to:
    Save order to database
    Send email
    Send SMS
    Write log
❌Without multicast delegates:
    SaveOrder();
    SendEmail();
    SendSMS();
    WriteLog();
✔With multicast delegates:
orderPlaced();
All handlers execute automatically.
This is exactly how Events work internally.

-----------------------------------------------------

✅🔥Adding Multiple Methods
using System;
public delegate void MyDelegate();
class Program
{
    static void A()
    {
        Console.WriteLine("A");
    }
    static void B()
    {
        Console.WriteLine("B");
    }
    static void C()
    {
        Console.WriteLine("C");
    }
    static void Main()
    {
        MyDelegate del = A;
        del += B;
        del += C;
        del();
    }
}
-----------------------------------------------------

✅🔥Removing Methods
Use -=
using System;
public delegate void MyDelegate();
class Program
{
    static void A()
    {
        Console.WriteLine("A");
    }
    static void B()
    {
        Console.WriteLine("B");
    }
    static void Main()
    {
        MyDelegate del = A;
        del += B;
        del -= B;  // Method B is removed.
        del();
    }
}
-----------------------------------------------------

✅🔥Example with Parameters
Multicast delegates can also have parameters.

using System;
public delegate void Calculator(int number);
class Program
{
    static void Square(int x)
    {
        Console.WriteLine($"Square = {x * x}");
    }
    static void Cube(int x)
    {
        Console.WriteLine($"Cube = {x * x * x}");
    }
    static void Main()
    {
        Calculator calc = Square;
        calc += Cube;
        calc(5);
    }
}
Output:
Square = 25
Cube = 125
---------------------------------------------------------

✅🔥 Multicast Delegate with Return Type: Return value type will be of last method type.
public delegate int Calculate();
static int A()
{
    return 10;
}
static int B()
{
    return 20;
}
int result = del();
Console.WriteLine(result); // 20 only not 10


✅ Note: Why only 20?
Both methods execute:
A() -> 10
B() -> 20
But only the return value of the last method is returned.
Therefore multicast delegates are usually used with: void


==================================================================================================================

✅🔥What is Action ?
Action is a built-in generic delegate in C# used to represent a method that:
    ✔ Performs an operation
    ❌ But Does NOT return any value (void)
It is defined in System namespace.
It can take 0 to 16 input parameters and is commonly used for-
  callbacks, 
  logging, 
  event handling, 
  lambda expressions
  eliminating the need for custom void delegates.



✅🔥 Key Features of Action:
✔ 1. No return value: Always returns void.

✔ 2. Supports multiple parameters
Action<int>
Action<int, string>
Action<int, int, int>

✔ 3. Can use Lambda expressions
Action<int> square = x => Console.WriteLine(x * x);

✔ 4. Can refer to methods
Action<string> print = DisplayMethod;




✅ Why do we need Action?
Before Action, we used custom delegates for every void method:

❌ Without Action:
public delegate void PrintMessage(string message);
public delegate void Log(int id, string message);
Problem:
Too many delegate definitions
Not reusable
Hard to maintain

✔ Action solves this
Now we can use one built-in delegate:
   Action<string>
   Action<int, string>
   Action<int, int, int>

--------------------------------------------------------

✅🔥Example 1: Simple Action (1 parameter)
using System;
class Program
{
    static void Main()
    {
        Action<string> print = message =>
        {
            Console.WriteLine("Message: " + message);
        };
        print("Hello Kapil");
    }
}
Output: Message: Hello Kapil

------------------------------------------------------

✅🔥Example 2: Action with Multiple Parameters
using System;
class Program
{
    static void Main()
    {
        Action<int, int> add = (a, b) =>
        {
            Console.WriteLine("Sum: " + (a + b));
        };
        add(10, 20);
    }
}

------------------------------------------------------

✅🔥Example 3: Action using Method Reference
using System;
class Program
{
    static void Display(string msg)
    {
        Console.WriteLine(msg);
    }
    static void Main()
    {
        Action<string> action = Display;
        action("Hello from method reference");
    }
}

----------------------------------------------------

✅🔥Example 4: Action in Real-world Logging
using System;

class Program
{
    static void LogMessage(string message)
    {
        Console.WriteLine($"LOG: {message}");
    }

    static void Main()
    {
        Action<string> logger = LogMessage;

        logger("System started");
        logger("User logged in");
    }
}
==================================================================================================================

✅🔥Func Delegate
Func is a built-in generic delegate that represents a method that:
✔ Accepts zero or more input parameters
✔ Returns a value
It is available in the System namespace.


✅🔥 Why Do We Need Func?
Before Func, we had to create custom delegates for every method that returned a value.
The last type parameter is always the return type.

❌ Without Func:
public delegate int AddDelegate(int a, int b);
public delegate string UpperDelegate(string text);
public delegate bool CheckDelegate(int number);
 
❌ Problems:
Too many delegate definitions
Code duplication
Hard to maintain


✔ With Func
Func<int, int, int>
Func<string, string>
Func<int, bool>
One built-in delegate handles all these cases.

------------------------------------------------------


✅🔥Examples: One Parameter
Func<int, string>
Meaning:
int  -> input
string -> return value

Equivalent to: string Method(int value)



✅🔥Two Parameters
Func<int, int, int>
Meaning:
int, int -> inputs
int -> return value

Equivalent to: int Add(int a, int b)

----------------------------------------------------


✅🔥 Example 1: Simple Func
using System;
class Program
{
    static void Main()
    {
        Func<int, int> square = x => x * x;
        Console.WriteLine(square(5));
    }
}

---------------------------------------------------

✅🔥 Example 2: Func with Two Parameters
using System;
class Program
{
    static void Main()
    {
        Func<int, int, int> add = (a, b) => a + b;
        Console.WriteLine(add(10, 20));
    }
}
---------------------------------------------------

✅🔥 Example 3: Method Reference with Func

Instead of lambda, Func can point to a method.
using System;
class Program
{
    static int Multiply(int a, int b)
    {
        return a * b;
    }
    static void Main()
    {
        Func<int, int, int> operation = Multiply;
        Console.WriteLine(operation(5, 4));
    }
}
--------------------------------------------------------
✅🔥 Example 4: Func in LINQ 
Consider:
var numbers = new List<int>
{
    1,2,3,4,5
};
var result = numbers.Where(x => x % 2 == 0);

Internally:
Where(Func<int, bool> predicate)
The lambda: x => x % 2 == 0 , is converted into: Func<int, bool>

====================================================================================================================

✅🔥 Predicate Delegate
Predicate<T> is a built-in generic delegate that represents a method that:
✔ Accepts exactly one parameter of type T
✔ Returns a bool (true or false)
It is defined in the System namespace.



✅🔥 Why Do We Need Predicate?
Suppose we want to check whether a number is even.
Without Predicate:
For int:     public delegate bool CheckNumber(int number);
For strings: public delegate bool CheckString(string text);
For students:public delegate bool CheckStudent(Student student);
❌Problems:
Multiple delegate definitions
Code duplication
Hard to maintain


✔With Predicate:
Predicate<int>
Predicate<string>
Predicate<Student>
One generic delegate works for all types.


Syntax:
Predicate<T> Equivalent to: bool Method(T value)

------------------------------------------------------

✅🔥 Example 1: Check Even Number
using System;
class Program
{
    static void Main()
    {
        Predicate<int> isEven = number => number % 2 == 0;
        Console.WriteLine(isEven(10));
        Console.WriteLine(isEven(7));
    }
}
-----------------------------------------------------

✅🔥Example 2: Method Reference

Instead of lambda: Predicate<int> isEven = x => x % 2 == 0;
We can use a method.

using System;
class Program
{
    static bool IsEven(int number)
    {
        return number % 2 == 0;
    }
    static void Main()
    {
        Predicate<int> predicate = IsEven;
        Console.WriteLine(predicate(20));
    }
}
---------------------------------------------------

✅🔥Example 3: Student Validation
public class Student
{
    public string Name { get; set; }
    public int Marks { get; set; }
}
using System;
class Program
{
    static void Main()
    {
        Predicate<Student> isPassed = student => student.Marks >= 40;
        Student s1 = new Student
        {
            Name = "Kapil",
            Marks = 80
        };
        Student s2 = new Student
        {
            Name = "John",
            Marks = 30
        };
        Console.WriteLine(isPassed(s1));
        Console.WriteLine(isPassed(s2));
    }
}
-------------------------------------------------

✅🔥 Predicate with List<T>.Find()
One of the most common uses.

using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        List<int> numbers =
        [
            5,10,15,20,25
        ];

        int result = numbers.Find(x => x > 12);
        Console.WriteLine(result);
    }
}
Internally: Find(Predicate<T> match)


























































