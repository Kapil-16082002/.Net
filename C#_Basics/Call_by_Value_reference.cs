
✅🔥 Call by Value and Call by Reference n C#

C# passes parameters by value by default. 7
When we explicitly use ref, out, or certain other mechanisms, we can pass a variable by reference.

There is also an important distinction between:
   passing a value type by value
   passing a value type by reference
   passing a reference type by value
   passing a reference type by reference

--------------------------------------------------

✅🔥 Call by Value:
Call by value means that a copy of the argument's value is passed to the method parameter.
If we make any changes to the parameter,  that changes would not reflect to the original value.

Example:
using System;
class Program
{
    static void Change(int x)
    {
        x = 100;
    }
    static void Main()
    {
        int a = 10;
        Console.WriteLine("Before method call: " + a);
        Change(a);
        Console.WriteLine("After method call: " + a);
    }
}
Output:
Before method call: 10
After method call: 10

----------------------------------------------------------------------

✅🔥 Call by Reference:
Now suppose we want the method to modify the caller's variable.

We use: ref
Example:
static void Change(ref int x)
{
    x = 100;
}
static void Main()
    {
        int a = 10;
        Change(ref a);
        Console.WriteLine(a); // 100
    }

✅ Why Did a Change ?
Because x is not receiving a copy of a.
Instead, x refers to the same storage location as a.

Conceptually:
a
 \
  \
   ---> same storage location
  /
 /
x

✅🔥 Important Rule of ref:
1. When using ref, you must use ref in both places.

Method declaration: static void Change(ref int x)
Method call:        Change(ref number);


2. ref Requires Initialization:
Wrong:
int number;
Change(ref number);  // Wrong, because ref requires the variable to already have a value.

Correct:
int number = 100;
Change(ref number);

===================================================================================================================

✅🔥 Reference Type Passed by Value:
Many developers say: "Classes are reference types, so they are passed by reference."
This statement is not correct.
The correct statement is: Reference-type variables are passed by value by default.

class Person
{
    public string Name;
}
static void Change(Person p)
{
    p.Name = "Rahul";
}
Person person = new Person();
person.Name = "Kapil";
Change(person);
Console.WriteLine(person.Name); // Rahul


/*✅ Important:
Why Did It Change If It Was Passed by Value ?
Because the reference was copied, not the object.

Before method call:
person
   |
   v
+----------------+
| Name = Kapil   |
+----------------+

Inside method:
person --------\
                \
                 ---> same Person object
                /
p --------------/


p.Name = "Rahul";
Both references see:
+----------------+
| Name = Rahul   |
+----------------+
*/
===================================================================================================================

✅🔥 Reference Type Passed by Reference:
static void Change(ref Person p) // by using ref method is allowed to change the caller’s reference variable itself.
{
    p = new Person();
    p.Name = "Rahul";
}
Person person = new Person();
person.Name = "Kapil";
Change(ref person);
Console.WriteLine(person.Name);  // Rahul

=================================================================================================================

✅🔥 out Parameter:
out is another way of passing a variable by reference.

static void Change(ref int number)
{
    number = 100;
}
int number = 50;
Change(ref number); // updated number=100;



✅Example:
static void GetNumber(out int number)
{
    number = 100;
}
static void Main()
{
    int value;//in case of Ref: The variable does not need to be initialized.But method must assign a value before returning.
    GetNumber(out value);
    Console.WriteLine(value); // 100
}

================================================================================================================


✅🔥 in Parameter:

in passes an argument by reference but makes it read-only inside the method.
using System;
class Program
{
    static void Display(in int number)
    {
        Console.WriteLine(number);
        // number = 100;  // ERROR
    }
    static void Main()
    {
        int value = 50;
        Display(in value);
    }
}
Why Use in?
in can be useful when you want:
   reference passing
   without copying a large value type
   while preventing modification inside the method













































