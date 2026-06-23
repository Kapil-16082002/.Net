✅🔥Generics in C#
Generics allow you to write classes, methods, interfaces, delegates, and collections that work with different data types while maintaining type safety, performance, and code reusability.
Instead of writing separate code for int, double, string, etc., you write the code once and specify the type when using it.


✅🔥Why Were Generics Introduced?
1✅. Before Generics, collections stored data as object.

Example:
using System;
using System.Collections;
class Program
{
    static void Main()
    {
        ArrayList list = new ArrayList();
        list.Add(10);
        list.Add("Kapil");
        int x = (int)list[0];
        Console.WriteLine(x);
    }
}
Problems:
1. No Type Safety
list.Add("Kapil");
int x = (int)list[1];// Runtime Error: InvalidCastException
The compiler cannot detect the mistake.




2✅. Boxing and Unboxing
ArrayList list = new ArrayList();
list.Add(10);
Here 10 is an int. But ArrayList stores object.
So: int → object, Boxing occurs.

Later:
int x = (int)list[0]; Unboxing occurs.
Both operations slow down performance


=================================================

✅🔥Solution: Generics
using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        numbers.Add(10);
        numbers.Add(20);
        int x = numbers[0];
        Console.WriteLine(x);
    }
}
Benefits:
✔ Compile-time type checking
✔ No casting
✔ No boxing/unboxing
✔ Better performance

===================================================================================================================

✅🔥Generic Class:
A Generic Class is a class that works with any data type.
Instead of creating separate classes for int, string, double, etc., we create one class and provide the data type when creating the object.

Most Common Generic Classes in .NET
List<T>
Dictionary<TKey,TValue>
Queue<T>
Stack<T>
HashSet<T>
LinkedList<T>
Nullable<T>
Task<T>
Lazy<T>


✅ Why Do We Need Generic Classes ?
Suppose we want a class that stores a value.
❌Without Generic : For int
class IntContainer
{
    public int Value;
}
IntContainer c = new IntContainer();
c.Value = 100;
Console.WriteLine(c.Value);


❌For string
class StringContainer
{
    public string Value;
}
StringContainer c = new StringContainer();
c.Value = "Kapil";
Console.WriteLine(c.Value);


⚠️Problem: Code duplication.
IntContainer
StringContainer
DoubleContainer
StudentContainer
EmployeeContainer
...
Need a separate class for every type.

===========================================
✅🔥Solution:
using System;
class Container<T>
{
    public T Value;
}
class Program
{
    static void Main()
    {
        Container<int> c1 = new Container<int>();
        c1.Value = 100;

        Container<string> c2 = new Container<string>();
        c2.Value = "Kapil";

        Container<double> c3 = new Container<double>();
        c3.Value = 99.99;

        Console.WriteLine(c1.Value);
        Console.WriteLine(c2.Value);
        Console.WriteLine(c3.Value);
    }
}
======================================

✅🔥 Generic Class with Constructor
using System;
class Container<T>
{
    public T Value;
    public Container(T value)
    {
        Value = value;
    }
}
class Program
{
    static void Main()
    {
        Container<string> c = new Container<string>("Kapil");
        Console.WriteLine(c.Value);
    }
}
Output: Kapil

================================================

✅🔥 Generic Class with Multiple Type Parameters
Sometimes one type parameter is not enough.

using System;
class Pair<T1,T2>
{
    public T1 First;
    public T2 Second;
}
class Program
{
    static void Main()
    {
        Pair<int,string> p = new Pair<int,string>();
        p.First = 101;
        p.Second = "Kapil";=
        Console.WriteLine(p.First); // 101
        Console.WriteLine(p.Second);// Kapil
    }
}
================================================

✅🔥Generic Class with Three Type Parameters
class Data<T1,T2,T3>
{
    public T1 A;
    public T2 B;
    public T3 C;
}

===================================================================================================================

✅🔥Generic Constraints in C# (For Generic Classes)
A Generic Constraint restricts the types that can be used as a type argument (T) in a generic class.
Without constraints, T can be any type.
class Box<T>
{
    public T Value;
}
Box<int> b1 = new Box<int>();
Box<string> b2 = new Box<string>();
Box<double> b3 = new Box<double>();
Sometimes we want to allow only specific kinds of types.
That's where constraints come in.

Syntax:
class MyClass<T>
    where T : constraint    //where keyword specifies constraints.
{
}
=====================================================================================================================

✅🔥1. new() Constraint
The new() constraint tells the compiler that the generic type parameter must have a public parameterless constructor (a constructor with no arguments).
This allows the generic class or method to create objects of the generic type using: new T()
Without the new() constraint, the compiler does not know whether T has a default constructor, so object creation is not allowed.


Important Rule:
new() must always be the last constraint.
Correct: where T : class, IDisposable, new()
❌Wrong: where T : new(), class



/* 
Interview One-Liner
The new() generic constraint guarantees that the type parameter has a public parameterless constructor, allowing generic code to safely create objects using new T() at compile time and runtime.
*/





✅Why Do We Need new() Constraint ?
Consider a generic class:
class Factory<T>
{
    public T Create()
    {
        return new T();   // Compile Error
    }
}
Compiler Error: Cannot create an instance of the variable type 'T'
because it does not have the new() constraint. Why?
The compiler only knows that T is some type.
It could be:
    int
    string
    Employee
    Student
Some of the/se types may not have a parameterless constructor.
So C# prevents: new T(), unless you explicitly guarantee it using the new() constraint.

Syntax
class Factory<T>
    where T : new()
{
}
Meaning: "T must have a public parameterless constructor."
Now new T() becomes legal.

---------------------------------------------------------

Example 1: Creating Objects Inside a Generic Class
One common use of new() is implementing a factory.

using System;
class Employee
{
    public Employee()
    {
        Console.WriteLine("Employee Created");
    }
}
class ObjectFactory<T>
    where T : new()
{
    public T GetObject()
    {
        return new T();
    }
}
class Program
{
    static void Main()
    {
        ObjectFactory<Employee> factory = new ObjectFactory<Employee>();
        Employee e = factory.GetObject();
    }
}
Output: Employee Created