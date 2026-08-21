
✅🔥 Access Modifiers in C# — Complete Guide
Access modifier controls visibility/accessibility of a class, method, field, property, constructor, etc.


✅Access Modifiers
│
├── public
├── private
├── protected
├── internal
├── protected internal
└── private protected
There is also a related concept: file, for restricting a top-level type to the same source file.


| Modifier             | Same Class | Derived Class |  Same Assembly | Other Assembly |
| -------------------- | ---------: | ------------: | -------------: | -------------: |
| `private`            |          ✅ |             ❌ |              ❌ |              ❌ |
| `protected`          |          ✅ |             ✅ |             ❌* |             ❌* |
| `internal`           |          ✅ |             ✅ |              ✅ |              ❌ |
| `public`             |          ✅ |             ✅ |              ✅ |              ✅ |
| `protected internal` |          ✅ |             ✅ |              ✅ |             ✅* |
| `private protected`  |          ✅ |            ✅* |             ✅* |              ❌ |
| `file`               |          — |                — |   Same file only |               ❌ |


✅🔥 Default Accessibility Table:
| Declaration         | Default    |
| ------------------- | ---------- |
| Top-level class     | `internal` |
| Top-level interface | `internal` |
| Top-level struct    | `internal` |
| Class field         | `private`  |
| Class method        | `private`  |
| Class property      | `private`  |
| Class constructor   | `private`  |
| Class nested type   | `private`  |

===============================================================================================================

✅🔥 What Is an Assembly ?
An assembly is essentially a compiled .NET unit such as:
   MyApplication.dll
   MyLibrary.dll
   MyApplication.exe

✅🔥 public:
public means: The member/type can be accessed from anywhere where the containing type is accessible.

✅🔥private
private means: Accessible only within the containing type.
Why Use private? private is heavily used for encapsulation.

✅🔥protected means: Accessible inside the containing class and its derived classes.

------------------------------------------------------------

✅🔥internal means: Accessible anywhere within the same assembly.

Suppose:
Assembly A
    Animal.cs
Assembly B
    Program.cs

Assembly A:
internal class Animal
{
    internal void Eat()
    {
        Console.WriteLine("Eating");
    }
}
Assembly B:
Animal animal = new Animal(); // ❌
Not accessible. Why? Because Animal is internal, and Assembly B is a different assembly

------------------------------------------------------------

✅🔥protected internal
means:Accessible from the same assembly OR from a derived class in another assembly.
protected internal
        =
protected OR internal
Same assembly ? YES → allowed
Different assembly + derived class ? YES → allowed
Different assembly + unrelated class ? NO → not allowed


class Animal
{
    protected internal void Eat()
    {
        Console.WriteLine("Eating");
    }
}
class Program
{
    static void Main()
    {
        Animal animal = new Animal();
        animal.Eat(); // ✅
    }
}
Why? Because Program is in the same assembly.

------------------------------------------------------------

✅🔥 protected internal — Derived Class in Another Assembly
Suppose Assembly A contains:
public class Animal
{
    protected internal void Eat()
    {
        Console.WriteLine("Eating");
    }
}
Assembly B contains
public class Dog : Animal
{
    public void Test()
    {
        Eat(); // ✅
    }
}
This works because Dog is a derived class.
-------------------------------------------------

✅🔥 private protected:
Accessible from the same assembly OR from a derived class in same assembly.

protected internal vs private protected:
|                                    | `protected internal` | `private protected` |
| ---------------------------------- | -------------------- | ------------------- |
| Same assembly                      | ✅                    | ✅                   |
| Derived class same assembly        | ✅                    | ✅                   |
| Derived class different assembly   | ✅                    | ❌                   |
| Unrelated class same assembly      | ✅                    | ❌                   |
| Unrelated class different assembly | ❌                    | ❌                   |

====================================================================================

✅🔥 file Access Modifier:
Modern C# also supports: file for a top-level type.
It means: The type is accessible only within the source file in which it is declared.

file class Helper
{
    public static void Show()
    {
        Console.WriteLine("Hello");
    }
}
In the same .cs file:
class Program
{
    static void Main()
    {
        Helper.Show();
    }
}
Output: Hello
But another source file cannot access that file type.

-------------------------------------------------------

✅🔥 Important Restriction of file:
file is used for top-level types.
It means: The type is accessible only within the source file in which it is declared.

For example:
file class Animal {}
You don't normally use:
class Animal
{
    file void Eat() // ❌
    {
    }
}
file is about restricting a top-level type to its source file

---------------------------------------------------------

✅🔥Access Modifiers for Classes:
A top-level class can generally be:

public class Animal{}
or:
internal class Animal{}
or:
file class Animal{}


But you cannot make a top-level class:
private class Animal{}// ❌
or:
protected class Animal{} // ❌













