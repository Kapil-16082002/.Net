
✅🔥What is a Tuple(ValueTuple) ?
A Tuple is a collection that groups multiple data types into one object-like value.
// Tuple vs System.Tuple ???????
Basic Syntax:
(type1, type2) variable_Name = (value1, value2);
Example:
(string, int, double) student = ("Kapil", 23, 92.5);
Console.WriteLine(student.Item1); // Kapil
Console.WriteLine(student.Item2); // 23
Console.WriteLine(student.Item3); // 92.5


Instead of creating a class:
class Student
{
    public string Name;
    public int Age;
    public double Marks;
}

var t = (1,2,3,4,5,6,7,8,9,10);
Console.WriteLine(t.Item10);
Output: 10

----------------------------------------------------------------------------------------------------------

✅🔥 Named Tuple:
Instead of Item1, Item2 , we can use meaningful names.
(double Sum, int Count) t = (4.5, 3);
Console.WriteLine(t.Sum);
Console.WriteLine(t.Count);

Basic Tuple Example:
class Program
{
    static (int min, int max) Find(int[] arr)
    {
        return (arr.Min(), arr.Max());
    }
    static void Main()
    {
        int[] nums = { 20, 50, 10, 90, 30 };
        var result = Find(nums);
        Console.WriteLine(result.min);
        Console.WriteLine(result.max);
    }
}
/* 
Before C# 7: Old tuple
Tuple<int, int> t = Tuple.Create(10, 20);
Console.WriteLine(t.Item1);
Console.WriteLine(t.Item2);

*/
-----------------------------------------------------------------------------------------------------------------

✅🔥 Tuple is Mutable

Tuple fields can be changed.

(string Name, int Age) student = ("Kapil", 23);
student.Name = "Rahul";
student.Age = 25;
Console.WriteLine(student.Name);  // Rahul
Console.WriteLine(student.Age);   // 25

Unlike immutable System.Tuple.

-----------------------------------------------------------------------------------------------------------------

✅🔥Tuple Deconstruction:

One of the best features introduced with C# 7.0 Tuples is Tuple Deconstruction.
It allows you to split a tuple into individual variables in a single statement.
Instead of accessing tuple elements using:
result.Item1
result.Item2
result.Item3
or
result.min
result.max



Suppose a method returns multiple values:
static (int Min, int Max) Find()
{
    return (10, 50);
}
Without deconstruction: // Here, we first store the tuple in result and then access its members.
var result = Find();
Console.WriteLine(result.Min); // 10
Console.WriteLine(result.Max); // 50


With Deconstruction // The tuple is automatically broken into two variables.
static (int Min, int Max) Find()
{
    return (10, 50);
}
static void Main()
{
    (int min, int max) = Find();
    Console.WriteLine(min);
    Console.WriteLine(max);
}
----------------------------------------------------------------------------------------------------------------

✅🔥Tuple Assignment

Tuples can be assigned.
(int,double) t1 = (10,3.14);
(double A,double B) t2 = (0,0);
t2 = t1;
Console.WriteLine($"A = {t2.A}, B = {t2.B}");
Output:
A=10. B=3.14

================================================================================================================

✅🔥Why Were Tuples Introduced in C#?
Tuples were introduced to return multiple values from a method without creating a separate class or using out parameters.
They make the code shorter, cleaner, and easier to read.

The Problem Before Tuples:
Suppose you have an array and want to return:
    Minimum value
    Maximum value
A method can return only one object. 
So before tuples, developers used two common approaches:
    1. Create a separate class/struct
    2. Use out parameters
Both have drawbacks.



✅🔥1. Create a separate class/struct
class Result
{
    public int Min;
    public int Max;
}
class Program
{
    static Result Find(int[] arr)
    {
        Result r = new Result();
        r.Min = arr.Min();
        r.Max = arr.Max();
        return r;
    }

    static void Main()
    {
        int[] nums = { 20, 50, 10, 90, 30 };
        Result result = Find(nums);
        Console.WriteLine($"Min = {result.Min}");
        Console.WriteLine($"Max = {result.Max}");
    }
}
Memory Representation:
Stack:
result
   |
   V
Heap
+----------------+
| Result Object  |
|----------------|
| Min = 10       |
| Max = 90       |
+----------------+
A separate object is created on the heap.
Problems:
Need an extra class
More boilerplate code
More maintenance
More heap allocations (if class)
For small temporary values, this feels unnecessary.



✅🔥 2: Use out Parameters
class Program
{
    static void Find(int[] arr, out int min, out int max)
    {
        min = arr.Min();
        max = arr.Max();
    }
    static void Main()
    {
        int[] nums = { 20, 50, 10, 90, 30 };
        Find(nums, out int minimum, out int maximum);
        Console.WriteLine(minimum);
        Console.WriteLine(maximum);
    }
}
Memory Representation
Caller Stack
minimum
maximum

        ↑
        |

Method writes values
No extra object is created.

==============================================================================================================

✅🔥 ValueTuple is Faster
ValueTuple is a struct.

Stack
+----------------+
| x = 10         |
| y = 20         |
+----------------+
No extra heap allocation.
No garbage collection pressure.
Better performance.


Advantages of Tuples
✅ Return multiple values from a method
✅ No need to create temporary classes
✅ Cleaner than out parameters
✅ Easy deconstruction into variables
✅ Better readability with named elements
✅ ValueTuple is a value type, so it avoids unnecessary heap allocations in many scenarios
✅ Excellent for short-lived groups of related values