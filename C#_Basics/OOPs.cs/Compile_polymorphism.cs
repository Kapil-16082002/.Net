
✅🔥 The word “polymorphism” means having many forms.
Poly  = Many
Morphism = Forms
we can define polymorphism as the ability of a message to be displayed in more than one form.
  A real-life example of polymorphism is a person who at the same time can have different characteristics.
  A man at the same time is a father, a husband, and an employee.
  So the same person showing different behavior in different situations. This is called polymorphism.


✅ Simple Real-Life Example
Imagine a Payment system.
You have:
Payment
   |
   +---- CreditCard
   |
   +---- UPI
   |
   +---- Cash

All of them have: Pay()
But:
CreditCard.Pay() → Processing credit card payment
UPI.Pay()        → Processing UPI payment
Cash.Pay()       → Processing cash payment

The caller can simply say: payment.Pay(); without needing to know exactly which payment implementation is being used.

-------------------------------------------------------------

                    Polymorphism
                         |
             +-----------+-----------+
             |                       |
             v                       v
       Compile-Time              Runtime
       Polymorphism             Polymorphism
             |                       |
             v                       v
       Method Overloading      Method Overriding
       Operator Overloading   Virtual/Override


✅🔥Compile-Time Polymorphism ?
The compiler determines which method or operator implementation should be used at compile time.

✅ Method Overloading:
Method overloading means having multiple methods:
   with the same name
   in the same class
   but with different parameter lists

✅ Method Signature includes:
   Method name
    +
   Number of parameters
    +
   Parameter types
    +
   Parameter modifiers such as ref/out/in

Overloading Based on Number of Parameters
Overloading Based on Parameter Type
Overloading Based on Parameter Order


For example:
using System;
class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }
    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}
class Program
{
    static void Main()
    {
        Calculator calculator = new Calculator();
        int result1 = calculator.Add(10, 20);
        int result2 = calculator.Add(10, 20, 30);

        Console.WriteLine("Result 1: " + result1); // Result 1: 30
        Console.WriteLine("Result 2: " + result2); // Result 2: 60
    }
}
✅Why Do We Need Method Overloading ?

Suppose we want to add two numbers and three numbers. Without overloading, we could write:
AddTwoNumbers(10, 20);
AddThreeNumbers(10, 20, 30);

But with method overloading, we can use the same meaningful method name:
Add(10, 20);
Add(10, 20, 30);
The compiler determines which Add() should be called.
This makes the API easier to understand and use.


✅ How Does the Compiler Know Which Method to Call ?
Consider: calculator.Add(10, 20);
The compiler sees:
   Method name → Add
   Arguments    → int, int
It searches for a matching method: Add(int, int), so compiler will select it.

/*
✅ Why is it called Compile-Time Polymorphism?
The important point is that the compiler can determine the method based on the method signature and arguments available at compile time.


✅Can We Overload Based Only on Return Type ? NO
because the compiler cannot distinguish which method should be called from an invocation such as Add(10, 20).
Compiler sees only:
   Method name → Add
   Arguments    → int, int


✅ Can We Overload static and Non-Static Methods?

You cannot overload a method merely by changing static.
    public void Display(int x){}
    public static void Display(int x){}
The parameter lists are identical:
   Display(int)
   Display(int)
Changing only static does not make a valid overload


✅ Can We Overload Based on Access Modifier ?
No.
This is invalid:
class Test
{
    public void Display(int x){}
    private void Display(int x){}
}
The parameter lists are identical.
Changing: public to private doesn't create a valid overload.


✅ Can we Overload Based on ref and out ?
Yes, Parameter modifiers can also participate in overload signatures.




✅ Can We Overload Constructors?
Yes.
class Student
{
    public Student() {Console.WriteLine("Default constructor");}
    public Student(string name) {Console.WriteLine("Name: " + name);}
    public Student(string name, int age)
    {
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Age: " + age);
    }
}
class Program
{
    static void Main()
    {
        Student s1 = new Student();
        Student s2 = new Student("Kapil");
        Student s3 = new Student("Kapil", 23);
    }
}


✅ Overloading with ref and out:
Parameter modifiers can also participate in overload signatures.
class Test
{
    public void Display(int x)     { Console.WriteLine("Normal parameter");}
    public void Display(ref int x) { Console.WriteLine("ref parameter");   }
    
}
*/
====================================================================================================================

✅🔥 Operator Overloading:
The second major example of compile-time polymorphism is operator overloading.

Operator overloading allows giving additional meanings to the operators when they are used with user-defined data types (like objects).
For example:
we can make use of the addition operator (+) for string class to concatenate two strings.
We know that the task of this operator is to add two operands. 
So a single operator ‘+’, when placed between integer operands, adds them and when placed between string operands, concatenates them. 
Normally, operators work with built-in types:

int a = 10;
int b = 20;
int result = a + b;
The + operator knows how to add integers.


It also works with strings:
string a = "Hello ";
string b = "Kapil";
string result = a + b;
Output: Hello Kapil


✅🔥 Comolete Example:
using System;
class Box
{
    private int length;
    private int breadth;
    public Box(int l = 0, int b = 0)  // Constructor
    {
        length = l;
        breadth = b;
    }
    
    public static Box operator +(Box a, Box b)  // Operator overloading
    {
        Box temp = new Box();
        temp.length = a.length + b.length;
        temp.breadth = a.breadth + b.breadth;
        return temp;
    }

    public void Display() // Display function
    {
        Console.WriteLine( $"Length: {length}, Breadth: {breadth}");
    }
}
class Program
{
    static void Main()
    {
        Box box1 = new Box(5, 10);
        Box box2 = new Box(3, 7);

        Box box3 = box1 + box2;// C# compiler will treat like this:  Box box3 = Box.operator +(box1, box2);

        Console.Write("Box 1: ");
        box1.Display();  // Box 1: Length: 5, Breadth: 10

        Console.Write("Box 2: ");
        box2.Display();  // Box 2: Length: 3, Breadth: 7

        Console.Write("Resultant Box (Box1 + Box2): ");
        box3.Display();  // Resultant Box (Box1 + Box2): Length: 8, Breadth: 17
    }
}

/*✅🔥 The Most Important Part:
public static Box operator +(Box a, Box b)
{
    Box temp = new Box();
    temp.length = a.length + b.length;
    temp.breadth = a.breadth + b.breadth;
    return temp;
}
Let's break it down: public static Box operator +(Box a, Box b)

public: The operator must be accessible.
public static: The operator must be declared static in C#.
Box:  This is the return type. The operation: box1 + box2 , produces another Box.
operator: This keyword tells C#: "I'm defining an operator."
+   This tells C# which operator we're overloading.


✅🔥 How Does Operator Overloading Work ?
When the compiler sees: Box box3 = box1 + box2;
it only knows that:
box1 → Box
box2 → Box
But C# doesn't inherently know what + should mean for two Box objects.
Therefore the compiler effectively resolves: box1 + box2  to  Box.operator +(box1, box2)
              box1 + box2
                   │
                   ▼
        operator +(box1, box2)
                   │ Then 
          ┌────────┴────────┐
          │                 │
       box1.length       box2.length
          │                 │
          └─────── + ──────┘
                  ↓
                  8

          box1.breadth     box2.breadth
                │               │
                └────── + ──────┘
                         ↓
                        17
                         │
                         ▼
                    New Box(8,17)
                         │
                         ▼
                       box3

✅🔥 Why Must an Overloaded Operator Be static ?

Why can't we change the operator call?
You might think of something like: Box box3 = box1.operator +(box2);  // ❌
But C# doesn't allow instance operator overloads in the first place, so there is no valid syntax you can use to call your non-static operator +.
*/

✅🔥 Operators That Cannot Be Overloaded
.
::
?:
&&
||
are not overloaded directly; they can participate through the appropriate &, |, and true/false operator rules.























