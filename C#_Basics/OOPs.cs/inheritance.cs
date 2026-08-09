
✅🔥 What is Inheritance ?
Inheritance is a fundamental concept of object-oriented programming that allows one class (derived class) to inherit properties and behaviors (data members and member functions) of another class (base class). 
This promotes code reuse and helps in building a hierarchical relationship between classes.

Basic syntax:
class Parent
{
    public void Display()
    {
        Console.WriteLine("Parent");
    }
}
class Child : Parent{}
Child obj = new Child();
obj.Display();

Output:Parent // Even though Display() is defined in Parent, the Child object can access it.

---------------------------------------------------------

Inheritance represents an IS-A relationship:
   Dog IS-A Animal
   Cat IS-A Animal
   Car IS-A Vehicle
   Employee IS-A Person
Example:
class Animal
{
}
class Dog : Animal
{
}
We can say: A Dog IS-A Animal.


-----------------------------------------------------------

✅🔥 Why Do We Need Inheritance ?
1. Code Reusability: Common functionality is written once in the base class and reused in derived classes.
2. Extensibility: Existing code can be extended by creating new derived classes.
3. Polymorphism: Enables run-time polymorphism when combined with virtual functions.


----------------------------------------------------------

✅🔥 Access Modifiers and Inheritance
| Access Modifier      | Derived Class Can Access?                |
| -------------------- | ---------------------------------------- |
| `public`             | ✅ Yes                                    |
| `protected`          | ✅ Yes                                    |
| `private`            | ❌ No                                     |
| `internal`           | Depends on assembly                      |
| `protected internal` | ✅ Under specified conditions             |
| `private protected`  | ✅ Within same assembly and derived class |


-----------------------------------------------------------

✅🔥 Types of Inheritance in C#:
The common inheritance structures are:
   Single inheritance
   Multilevel inheritance
   Hierarchical inheritance
   Multiple inheritance  // C# does not support multiple inheritance through classes.
   Hybrid inheritance

✅🔥 Single Inheritance:
One derived class inherits from one base class.
A
│
▼
B
Example:
class Animal
{
    public void Eat()
    {
        Console.WriteLine("Eating");
    }
}
class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("Barking");
    }
}
-------------------------------------------------

✅🔥 Multilevel Inheritance:
A class derives from another derived class.

A
│
▼
B
│
▼
C

Example:
using System;
class Animal
{
    public void Eat()
    {
        Console.WriteLine("Animal is eating");
    }
}
class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("Dog is barking");
    }
}
class Puppy : Dog
{
    public void Play()
    {
        Console.WriteLine("Puppy is playing");
    }
}
class Program
{
    static void Main()
    {
        Puppy puppy = new Puppy();
        puppy.Eat();
        puppy.Bark();
        puppy.Play();
    }
}
Output:
Animal is eating
Dog is barking
Puppy is playing

--------------------------------------------------------

✅🔥 Hierarchical Inheritance:
One parent, multiple children.

        Animal
        /    \
       /      \
     Dog      Cat

using System;
class Animal
{
    public void Eat()
    {
        Console.WriteLine("Animal is eating");
    }
}
class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("Dog is barking");
    }
}
class Cat : Animal
{
    public void Meow()
    {
        Console.WriteLine("Cat is meowing");
    }
}
class Program
{
    static void Main()
    {
        Dog dog = new Dog();
        dog.Eat();  // Animal is eating
        dog.Bark(); // Dog is barking

        Cat cat = new Cat();
        cat.Eat();  // Animal is eating
        cat.Meow(); // Cat is meowing
    }
}
--------------------------------------------------
✅🔥 Hybrid Inheritance:
Hybrid inheritance is a combination of different inheritance types.
For example:

          Animal
          /    \
        Dog    Cat
        |
      Puppy

This combines:
Hierarchical inheritance
Multilevel inheritance
C# cannot implement arbitrary hybrid inheritance using multiple classes because it doesn't support multiple class inheritance.


-----------------------------------------------------

✅🔥 What is Multiple Inheritance ?
Multiple inheritance means that a single class inherits directly from more than one parent/base class.
For example:

       A       B
        \     /
          C

Here, C wants to inherit from both A and B.
In a language that supports multiple class inheritance, you might write:
class A
{
}
class B
{
}
class C : A, B
{
}
This is NOT allowed in C#. You'll get a compiler error similar to: Class 'C' cannot have multiple base classes
// You will get a compiler error because a C# class can have only one direct base class.


✅🔥  Why Doesn't C# Support Multiple Class Inheritance ?
The famous reason is the Diamond Problem.
Imagine:

        A
       / \
      B   C
       \ /
        D

Suppose A has:
class A
{
    public void Display()
    {
        Console.WriteLine("A");
    }
}
class B : A
{
    public void Display()
    {
        Console.WriteLine("B");
    }
}
class C : A
{
    public void Display()
    {
        Console.WriteLine("C");
    }
}
If D inherits both B and C:

        A
       / \
      B   C
       \ /
        D

and we write:
D obj = new D();
obj.Display();

Which one should execute ?
B.Display()
      OR
C.Display()
Ambiguous. C# avoids this problem by allowing only one base class.

----------------------------------------------------------------

✅🔥Solution:

But C# DOES Support Multiple Interfaces. This is the important solution.
C# allows:
class MyClass : Interface1, Interface2
{
}
So instead of: ❌ Multiple base classes , we can use: ✅ One base class + multiple interfaces

using System;
interface IB
{
    void Display();
}
interface IC
{
    void Display();
}
class D : IB, IC  // D implements both interfaces.
{
    public void Display()
    {
        Console.WriteLine("D");
    }
}
class Program
{
    static void Main()
    {
        D obj = new D();
        obj.Display();
    }
}

--------------------------------------------------------

✅🔥 But What If B and C Need Different Implementations ?

This is where explicit interface implementation becomes very useful.

Suppose:

IB → Display()
IC → Display()

and we want different implementations.













