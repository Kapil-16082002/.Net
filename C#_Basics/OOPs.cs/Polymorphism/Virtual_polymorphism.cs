// new and Method Hiding

✅🔥 What is Run-Time Polymorphism ?
The method that will actually execute is determined at runtime, based on the actual object being referred to.
It is mainly achieved through method overriding in C#. 

✅🔥 How Many Ways Can We Achieve Run-Time Polymorphism ?
In normal C# object-oriented programming, the main mechanisms are:

Run-Time Polymorphism:
│
├── 1. Method Overriding using virtual + override
│
├── 2. Abstract class + abstract method
│
├── 3. Interface-based polymorphism
│
└── 4. Interface default implementations
    (advanced/modern C# scenario)


✅🔥 The Most Important Concept:

Before looking at different ways, understand this pattern:
For example:
Animal animal = new Dog();
There are two different things here:

Animal animal = new Dog();
│       │        │
│       │        └── Actual object
│       └────────── Reference variable
└────────────────── Reference type

====================================================================================================================

✅🔥 First Way: virtual and override
using System;
class Animal
{
    public Animal()
    {
        Console.WriteLine("Animal constructor");
    }
    public virtual void Speak()
    {
        Console.WriteLine("Animal speaks");
    }
}
class Dog : Animal
{
    public Dog()
    {
        Console.WriteLine("Dog constructor");
    }
    public override void Speak()
    {
        Console.WriteLine("Dog barks");
    }
}
class Program
{
    static void Main()
    {
        Animal animal = new Dog();
        animal.Speak();

        Animal animal = new Dog();
        animal.Speak();
    }
}
Output:
   Animal constructor
   Dog constructor
   Dog barks

   Animal constructor
   Dog constructor
   Dog barks

Operation 1 — Object creation: new Dog()
Constructor flow:
new Dog()
    ↓
Animal constructor
    ↓
Dog constructor
    ↓
Dog object created


Operation 2 — Method call
animal.Speak(); Because Speak() is virtual:
animal
  ↓
actual object = Dog
  ↓
Dog.Speak()


✅🔥 Both objects are actually Dog objects, so in both cases Dog.Speak() executes ?
Speak() is declared as: public virtual void Speak() in Animal.
And Dog overrides it:
public override void Speak()
{
    Console.WriteLine("Dog barks");
}
Because Speak() is virtual/override, C# uses runtime dispatch.
Therefore the runtime looks for actual object stored behind this reference not not merely the reference type.?"
So although the reference is: Animal animal the actual object is: new Dog()
So it executes: Dog.Speak()

-----------------------------------------------------

✅🔥 What Happens If We Don't Use virtual ?
using System;
class Animal
{
    public Animal()
    {
        Console.WriteLine("Animal constructor");
    }
    public void Speak()
    {
        Console.WriteLine("Animal speaks");
    }
}
class Dog : Animal
{
    public Dog()
    {
        Console.WriteLine("Dog constructor");
    }
    public void Speak()
    {
        Console.WriteLine("Dog barks");
    }
}
class Program
{
    static void Main()
    {
        Animal animal = new Dog();
        animal.Speak();
    }
}
Output:
   Animal constructor
   Dog constructor
   Animal speaks
Why?
Because Speak() isn't virtual.
The Dog method is hiding the base method; it isn't overriding it.

----------------------------------------------------------------------

✅🔥 new Keyword — Method Hiding in C#:
new does not create runtime polymorphism. It tells the compiler:
"I know that the derived class has a member with the same name as the inherited member, and I intentionally want to hide the inherited member.
Rule: With method hiding, the method is selected based on the reference/compile-time type, not the runtime object type.

using System;
class Animal
{
    public Animal()
    {
        Console.WriteLine("Animal constructor");
    }
    public void Speak()
    {
        Console.WriteLine("Animal speaks");
    }
}
class Dog : Animal
{
    public Dog()
    {
        Console.WriteLine("Dog constructor");
    }
    public new void Speak()
    {
        Console.WriteLine("Dog barks");
    }
}
class Program
{
    static void Main()
    {
        Animal animal = new Dog();
        animal.Speak();

        Dog dog = new Dog();
        dog.Speak();
    }
}
Output:
Animal constructor
Dog constructor
Animal speaks

Animal constructor
Dog constructor
Dog barks


✅🔥 Why does animal.Speak() call Animal.Speak()? //  Animal speaks
Rule: With method hiding, the method is selected based on the reference/compile-time type, not the runtime object type.

Look at:
Animal animal = new Dog();
animal.Speak(); // Animal speaks

There are two different types involved:
   Reference type = Animal
   Object type    = Dog

Diagram:
Animal animal
      |
      ↓
+----------------+
|    Dog object  |
+----------------+
But because Speak() is not virtual, C# does not perform virtual runtime dispatch.
Whenever compiler sees: animal.Speak();
The compiler asks:"What is the compile-time type of animal?" i.e Animal , Therefore it selects: Animal.Speak()

✅🔥 What happens with Dog dog? 
Dog dog = new Dog();
dog.Speak();
Here:
Reference type = Dog
Object type    = Dog

The compiler looks at Dog and finds: public new void Speak()
Therefore: Dog.Speak() executes.

-------------------------------------------------------------------

✅🔥 Why use new ?
Suppose you don't write new:
class Dog : Animal
{
    public void Speak()
    {
        Console.WriteLine("Dog barks");
    }
}
The compiler will warn you that Dog.Speak() hides the inherited Animal.Speak().

You can explicitly tell the compiler:
public new void Speak()
This says: "Yes, I know I'm hiding the inherited method. This is intentional."
So new is often used to explicitly acknowledge method hiding.

==================================================================================================================

✅🔥 Rules of Method Overriding in C#:

1. Base method must be virtual, abstract, or already override
2. The overriding method must be in a derived class.
3. Method signature must match
       method name
       parameter types
       parameter order
       number of parameters
4. Return Type Must Be Compatible in Method Overriding
5. Accessibility cannot be changed
6. Properties can be overridden
6. private methods, static, fields, Constructor cannot be overridden Because Constructors are not inherited, so they cannot be overridden.
7. sealed override prevents further overriding
    sealed means: Override is allowed here, but no further derived class can override it.
class Animal
{
    public virtual void Speak() { }
}
class Dog : Animal
{
    public sealed override void Speak()
    {
        Console.WriteLine("Dog");
    }
}
class Puppy : Dog
{
    public override void Speak() // ❌
    {
    }
}
8. Base method can be abstract
An abstract method has no implementation in the base class, so a concrete derived class must override it.


================================================================================================================

✅🔥 static cannot be overridden
Overriding is based on runtime polymorphism, but static members belong to the type/class, not to an object.
class Animal
{
    public static void Speak() // // ❌, Speak() belongs to the class, not to an object.
    {
        Console.WriteLine("Animal speaks");
    }
}
class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Dog barks");
    }
}
Animal a = new Dog();
a.Speak();
You call it using: Animal.Speak(); But There is no object involved.

Conceptually:
Animal
  ↓
Speak()

not:
Animal object
  ↓
Speak()
Therefore, there is no object on which runtime polymorphism can operate.


✅🔥 Very important interview example
Look at this:
class Animal
{
    public static void Speak()
    {
        Console.WriteLine("Animal");
    }
}
class Dog : Animal
{
    public static void Speak()
    {
        Console.WriteLine("Dog");
    }
}
class Program
{
    static void Main()
    {
        Animal animal = new Dog();
        a.Speak();
    }
}
Output: Animal
Many beginners expect: Dog

The compiler sees: animal as an Animal reference, and Speak() is static.
Therefore: Animal.Speak() is selected.
The actual object: new Dog() doesn't participate in static method dispatch.


----------------------------------------------------------------------------
✅🔥 Return Type Must Be Compatible in Method Overriding:
There are two important cases:
   Same return type — always valid.
   Covariant return type — a more derived reference type can be returned in C#.

1. First understand the normal rule:
Consider:
using System;
class Animal
{
    public virtual Animal GetAnimal()
    {
        Console.WriteLine("Animal.GetAnimal()");
        return new Animal();
    }
}
class Dog : Animal
{
    public override Animal GetAnimal()
    {
        Console.WriteLine("Dog.GetAnimal()");
        return new Animal();
    }
}
class Program
{
    static void Main()
    {
        Animal a = new Dog();  // Dog.GetAnimal()
        Animal result = a.GetAnimal();
        Console.WriteLine(result.GetType().Name); // Animal
    }
}
Here:
   Base method: Animal GetAnimal()
   Derived method: Animal GetAnimal()
Both return Animal. Therefore, this is valid.

---------------------------------------------------

✅🔥 Can we change the return type to Dog?
Yes — if the return type is covariant.
class Animal
{
    public virtual Animal GetAnimal()
    {
        return new Animal();
    }
}
class Dog : Animal
{
    public override Dog GetAnimal()
    {
        return new Dog();
    }
}
class Program
{
    static void Main()
    {
        Animal a = new Dog();
        Animal result = a.GetAnimal(); // Dog.GetAnimal()
        Console.WriteLine(result.GetType().Name); // dog
    } 
}
This is valid C#. Why?
Because: Dog IS-A Animal, So Dog is compatible with Animal.
This feature is called covariant return types.

🔥Notice something interesting.
The variable is: Animal result, but the actual object returned is: Dog 
because: public override Dog GetAnimal() 
so returns a Dog.
















