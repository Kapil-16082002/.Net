✅🔥Generic Methods
A Generic Method is a method that defines its own type parameter(s), allowing the same method to work with different data types while maintaining type safety.
Instead of writing separate methods for int, double, string, etc., we write one generic method.


✅🔥Why Do We Need Generic Methods?
Without generics:
public static void PrintInt(int value)
{
    Console.WriteLine(value);
}
public static void PrintString(string value)
{
    Console.WriteLine(value);
}
public static void PrintDouble(double value)
{
    Console.WriteLine(value);
}
Problems:
Code duplication
Hard to maintain
Need a new method for every type

Generic Method Solution
public static void Print<T>(T value)
{
    Console.WriteLine(value);
}

Usage:
Print<int>(10);     //  Print(10);  
Print<string>("Kapil");// Print("Kapil");
Print<double>(99.5); // Print(99.5);

Type Inference: Most of the time, C# automatically determines the type.
Instead of: Show<int>(100);
you can write: Show(100);
Compiler infers: T = int
Example:
Show(10);
Show("Hello");
Show(5.5);

---------------------------------------------------------

✅🔥 Example 2: Generic Method Returning a Value
public static T GetValue<T>(T value)
{
    return value;
}
Usage:
int num = GetValue(100);
string name = GetValue("Kapil");


✅🔥 Example 3: Multiple Generic Parameters:
A method can have multiple type parameters.

public static void Print<T1, T2>(T1 value1, T2 value2)
{
    Console.WriteLine($"First: {value1}");
    Console.WriteLine($"Second: {value2}");
}

Print<int, string>(100, "Kapil"); // Print(100, "Kapil");

------------------------------------------------------------

✅🔥Example 4: Generic Method Inside a Generic Class
class Repository<T>
{
    public void Show(T item)
    {
        Console.WriteLine(item);
    }
    public void Print<U>(U value)
    {
        Console.WriteLine(value);
    }
}
Repository<int> repo = new();
repo.Show(100);
repo.Print("Kapil");
repo.Print(true);

------------------------------------------------------------------

✅🔥Example 5: Generic Method Inside a Non-Generic Class
class Utility
{
    public void Print<T>(T value)
    {
        Console.WriteLine(value);
    }
}
Utility utility = new();
utility.Print(100);
utility.Print("Hello");

=====================================================================================================================

✅🔥Generic Method Constraints:
Constraints allow you to restrict the types that can be used as generic type arguments and let the compiler safely access members of those types.
Without constraints, T is treated as an unknown type.

✅🔥Why Do We Need Constraints?
Consider this generic method:
public static void PrintId<T>(T obj)
{
    Console.WriteLine(obj.Id);
}
Compiler Error: 'T' does not contain a definition for 'Id'
The compiler doesn't know whether every possible T has an Id. Constraints solve this.





✅🔥 Interface Constraint in Generic Methods (C#)
An interface constraint in generics forces the type parameter to implement a specific interface.

Syntax:
where T : IInterfaceName
This means: “T must be a type that implements this interface.”


✅🔥Why Do We Need Interface Constraints?
Without constraints, generic methods are blind to what operations are available on T.
Example problem:
public void PrintLength<T>(T item)
{
    Console.WriteLine(item.Length); // ERROR
}
Why error? Because T could be anything:
    int
    double
    Employee
    DateTime
Not all types have .Length, So compiler rejects it.



✅🔥Example 1: Using I  Enumerable<T>
Problem: Find count of items

❌ Without constraint:
public void PrintCount<T>(T data)
{
    Console.WriteLine(data.Count()); // ERROR
}
Solution:
using System.Collections.Generic;
using System.Linq;
public class Helper
{
    public void PrintCount<T>(T collection) where T : IEnumerable<int>
    {
        Console.WriteLine(collection.Count());
    }
}
Helper h = new Helper();
h.PrintCount(new List<int> { 1, 2, 3, 4 });

Why it works? Because: List<int> → implements IEnumerable<int>
So compiler guarantees: collection.Count() is valid.



✅🔥Another Example:
public interface IEntity
{
    int Id { get; set; }
}
public class Student : IEntity
{
    public int Id { get; set; }
}
public static void PrintId<T>(T obj)
    where T : IEntity
{
    Console.WriteLine(obj.Id);
}

Usage: Student student = new Student
{
    Id = 101
};
PrintId(student); // 101


Why Needed?
Without: where T : IEntity
the compiler cannot guarantee that Id exists.

===========================================================================

Base Class Constraint ?
class Constraint ?
struct Constraint ?



