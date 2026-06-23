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
❌Without constraints, T can be any type.
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



✅Why Do We Need Constraints?
Suppose we want to call a method on T.
public class Printer<T>
{
    public void Print()
    {
        T obj = new T(); // Error
        obj.Display();   // Error
    }
}
Compiler errors occur because:
Compiler doesn't know whether T has a parameterless constructor.
Compiler doesn't know whether T has a Display() method.
Constraints solve this problem.
=====================================================================================================================
Types of constraint:
    new()
    Class Constraint
    Interface Constraint
    Struct Constraint
    Base Class 



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

=================================================================================================================

✅🔥 The class constraint tells the compiler that the generic type parameter must be a reference type.

Syntax:
class Repository<T> where T : class
{
}
where T : class
means: "T can only be a reference type."



✅🔥Why do we need class Constraint?
Without constraints, the compiler knows nothing about T.
T could be:
   int
   double
   string
   Employee
   DateTime
both value types and reference types.
Sometimes we need operations that only make sense for reference types, such as:
    Checking for null
    Returning null
    Using reference equality
    Working with ORM entities (Entity Framework)
    Repository patterns
The class constraint guarantees that T is a reference type.




✅Example 1: Without Constraint❌
public class Repository<T>
{
    public T Find()
    {
        return null; // Compilation Error
    }
}
Why Error?

Because compiler doesn't know whether T is:
  int
  double
  DateTime
And Value types cannot be null. Therefore return null; is not allowed.



✅Example 2: With class Constraint
public class Repository<T>
    where T : class
{
    public T Find()
    {
        return null;
    }
}
Now compiler knows: T must be a reference type and  returning null is perfectly valid.



=================================================================================================================

✅🔥 Generic struct Constraint

The struct constraint tells the compiler: "The generic type parameter T must be a value type."
Syntax:
class Calculator<T> where T : struct
{
}
where T : struct , means T can only be a value type.


✅🔥Why Do We Need struct Constraint?
❌Without constraints:
class Example<T>
{
}
The compiler doesn't know whether T is:
int
double
string
Employee
DateTime
Sometimes we want our generic class to work only with value types.

Examples:
   Mathematical calculations
   Numeric processing
   Game development
   Financial applications
   Coordinate systems
   Generic algorithms for structs
That's where: 
where T : struct helps.


✅🔥 Example 1: Restricting to Value Types
class Storage<T>
    where T : struct
{
}
✔ Valid:
Storage<int> s1 = new();
Storage<double> s2 = new();
Storage<DateTime> s3 = new();

❌Invalid: Storage<string> s4 = new();
Error: The type 'string' must be a non-nullable value type
--------------------------------------------------------------

✅🔥Example 2: Nullable Value Types
One major reason for struct constraint is creating generic nullable wrappers.

Consider: Nullable<int> number = 10;
Actually: int? number = 10;

Internally .NET defines Nullable like this:
public struct Nullable<T>
    where T : struct
{
    private bool hasValue;
    private T value;
}

Notice: where T : struct
Why? Because Nullable only makes sense for value types.
Valid:
  int?
  double?
  DateTime?

----------------------------------------------------------
Important Feature: Guaranteed Parameterless Constructor
All value types automatically have a parameterless constructor.
Therefore:
class Factory<T> where T : struct
{
    public T Create()
    {
        return new T();
    }
}
Usage:
Factory<DateTime> factory = new();
DateTime dt = factory.Create();
Console.WriteLine(dt);
Output: 01/01/0001 00:00:00

====================================================================================================================


✅🔥A Base Class Constraint restricts a generic type parameter so that it must inherit from a specific base class.
Syntax:
class Repository<T> where T : Employee
{
}
This means: "T must be Employee or a class derived from Employee."


✅🔥Why Do We Need a Base Class Constraint?
Without constraints, the compiler knows nothing about T.
class Repository<T>
{
    public void Print(T obj)
    {
        // Compiler doesn't know what members T has
    }
}
The compiler cannot access any properties or methods because T could be anything:
int
string
DateTime
Employee
Customer
Sometimes we want to guarantee that T contains certain members. A base class constraint gives that guarantee.


✅🔥Example Without Base Class Constraint
class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
}
class Repository<T>
{
    public void Print(T obj)
    {
        Console.WriteLine(obj.Name);
    }
}
Compilation Error: 'T' does not contain a definition for 'Name'
Because compiler doesn't know whether T has a Name property.


Example With Base Class Constraint
class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
}
class Repository<T>
    where T : Employee
{
    public void Print(T obj)
    {
        Console.WriteLine(obj.Name);
    }
}
Now compiler knows: T is Employee or derived from Employee
So accessing:
   obj.Name
   obj.Id
is perfectly valid.

-----------------------------------------------------------

✅🔥 Scenario: Company Management System

Every employee in a company has:
   Id
   Name
   CalculateSalary()
Different employee types calculate salary differently.


Base Class:
public abstract class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public abstract double CalculateSalary();
}

Derived Classes:
public class Developer : Employee
{
    public int HoursWorked { get; set; }

    public override double CalculateSalary()
    {
        return HoursWorked * 1000;
    }
}

Manager:
public class Manager : Employee
{
    public double MonthlySalary { get; set; }

    public override double CalculateSalary()
    {
        return MonthlySalary;
    }
}

❌Without Base Class Constraint , Suppose we create a generic class:
public class Payroll<T>
{
    public void GenerateSalarySlip(T employee)
    {
        Console.WriteLine(employee.Name);
        Console.WriteLine(employee.CalculateSalary());
    }
}
Compilation Error:
T does not contain a definition for Name
T does not contain a definition for CalculateSalary
Because compiler thinks: T could be anything
 int
 string
 DateTime
 Customer
 Employee
So it cannot guarantee that:
    employee.Name
    employee.CalculateSalary()
exist or not.


✅With Base Class Constraint, where T : Employee
public class Payroll<T> where T : Employee
{
    public void GenerateSalarySlip(T employee)
    {
        Console.WriteLine($"Id: {employee.Id}");
        Console.WriteLine($"Name: {employee.Name}");
        Console.WriteLine($"Salary: {employee.CalculateSalary()}");
    }
}
Now compiler knows: T is Employee or derived from Employee
Therefore:
  employee.Id
  employee.Name
  employee.CalculateSalary()





=======================================
Interface constraints