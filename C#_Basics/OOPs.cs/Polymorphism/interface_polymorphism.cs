
✅🔥 What is an Interface ?
An interface is a contract/type abstraction that specifies what a class must provide.
interface IAnimal
{
    void Speak();
}
This says: Any concrete class that implements IAnimal must provide Speak().


Important:
If an interface contains a property, then a concrete class implementing the interface must provide an implementation for that property.

But there is an important exception: the class itself can be abstract.
An abstract class implementing the interface does not have to implement every interface member immediately:
interface IAnimal
{
    string Name { get; set; }
    int Age { get; set; }
}
abstract class Animal : IAnimal
{
    public string Name { get; set; }

    // Age not implemented yet
}
class Dog : Animal  //Then a concrete derived class must complete the remaining member:
{
    public int Age { get; set; }
}
Now Dog is concrete and has implemented everything required by IAnimal.

------------------------------------------------------------------------

✅🔥 If you don't define a concrete derived class:
interface IAnimal
{
    string Name { get; set; }
    int Age { get; set; }
}
abstract class Animal : IAnimal
{
    public string Name { get; set; }

    // Age is not implemented
}
If you don't define a concrete derived class, there is no problem at compile time, as long as the class implementing the interface is itself abstract.
This compiles successfully.
Why? Because Animal is abstract, so C# allows it to leave IAnimal.Age unimplemented.



✅🔥 But what happens if there is no concrete class (Dog) ?
Nothing happens by itself.

You simply have:
IAnimal
   ↓
abstract Animal

There is no concrete class.
You cannot create an object of either:
   IAnimal animal = new IAnimal();   // ❌
   Animal animal = new Animal();     // ❌
because:
   IAnimal is an interface → cannot instantiate
   Animal is abstract → cannot instantiate
So your program can compile, but there is no object that can actually be created from these types.

Why does C# allow this ?
Because an abstract class is allowed to say:
"I am not ready to be instantiated yet. I'll leave some interface members for a future derived class to implement."

===================================================================================================================

✅🔥 Interface Reference: IAnimal animal = new Dog();
Example:
using System;
interface IAnimal
{
    void Speak();
}
class Dog : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Dog barks");
    }
}
class Program
{
    static void Main()
    {
        IAnimal animal = new Dog();
        animal.Speak();
    }
}
Output: Dog barks


✅ Why Does Dog.Speak() Execute ?
This is the heart of interface polymorph8sm.

Look at: IAnimal animal = new Dog();
There are two types:
   Reference type = IAnimal
   Object type    = Dog
Think:
IAnimal animal
      |
      ↓
+-------------+
|  Dog object |
+-------------+
Then: animal.Speak();
The interface says: IAnimal → Speak() but actual object is Dog and Dog class implementing Speak()
Therefore the runtime executes: Dog.Speak()

-------------------------------------------------------

✅🔥 Interface Is Not a Class:
You cannot do: IAnimal animal = new IAnimal();
This is invalid.
A constructor exists to initialize an object, but an interface cannot be instantiated and therefore has no object whose state it needs to initialize.

--------------------------------------------------------

✅🔥 Very important interview distinction:
Suppose:
interface IAnimal
{
    void Speak();
}
class Dog : IAnimal
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
Now:
IAnimal animal = new Dog();
Some beginners think: "First IAnimal is created and then Dog is created." That's wrong.
There is only one object:
                Reference
                   |
                   ↓
             +-----------+
animal ----> | Dog object|
             +-----------+
IAnimal is simply the reference type. The actual object is: Dog
Therefore:
new Dog()
   ↓
Dog constructor
   ↓
Dog object created

===================================================================================================================

✅🔥 A Class Can Implement Multiple Interfaces:
A C# class cannot inherit from multiple classes:
class Dog : Animal, Mammal // ❌ two classes
{
}

But it can implement multiple interfaces:
class Dog : IAnimal, IMovable, ITrainable
{
}

Example:
using System;
interface IAnimal
{
    void Speak();
}
interface IMovable
{
    void Move();
}
class Dog : IAnimal, IMovable
{
    public void Speak()
    {
        Console.WriteLine("Dog barks");
    }
    public void Move()
    {
        Console.WriteLine("Dog runs");
    }
}
class Program
{
    static void Main()
    {
        Dog dog = new Dog();
        dog.Speak();  // Dog barks
        dog.Move();   // Dog runs
    }
/* 
Dog dog = new Dog();
IAnimal animal = dog;
IMovable movable = dog;

There is still only one Dog object.

             Dog object
             /        \
            /          \
     IAnimal ref     IMovable ref

animal.Speak();  // Dog barks
movable.Move();  // Dog runs

This is sometimes called multiple interface views of the same object.

*/
}
==================================================================================================================

✅🔥 Interface Reference Can Access Only Interface Members:
interface IAnimal
{
    void Speak();
}
class Dog : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Dog barks");
    }
    public void Run()
    {
        Console.WriteLine("Dog runs");
    }
}
IAnimal animal = new Dog();
animal.Speak();  // Dog Barks
animal.Run();   // ❌ doesn't compile

Because the reference type is IAnimal, and IAnimal doesn't contain Run().
Even though the actual object is a Dog
Because member accessibility through a reference is determined by the compile-time type of the reference. 
Since animal is an IAnimal reference, only members declared in IAnimal are directly accessible. 
The actual object being a Dog determines runtime implementation of interface members, but it doesn't change what members the reference can access at compile time.

You can do:
Dog dog = new Dog();
dog.Run();
because the reference type is Dog.

===================================================================================================================


✅🔥 Why must normal interface implementation must be public ?
interface IAnimal
{
    void Speak();
}
class Dog : IAnimal
{
    private void Speak() // private, this does not satisfy the interface contract.
    {
        Console.WriteLine("Dog barks");
    }
}
Because private means: Speak() is accessible only by Dog class.
But the interface contract requires the member to be accessible through the interface:
IAnimal animal = new Dog();
animal.Speak();
Therefore, normal implementation is: public void Speak()


✅🔥 But what if I don't want Speak() to be publicly available through Dog ?
This is where explicit interface implementation comes in.

Instead of: public void Speak()
we write: void IAnimal.Speak()
Example:
interface IAnimal
{
    void Speak();
}
class Dog : IAnimal
{
    void IAnimal.Speak() // There is no public keyword. This is called: Explicit Interface Implementation.
    {
        Console.WriteLine("Dog barks");
    }
}
❌Now You cannot do:
Dog dog = new Dog();
dog.Speak();  // ❌ Why? Because Speak() is not exposed as a normal public member of Dog.The implementation exists, but it is accessible through the interface contract.

✅Instead:
IAnimal animal = new Dog();
animal.Speak();  // ✅
Output: Dog barks


✅🔥 Important use case: Two interfaces have the same method
interface IAnimal
{
    void Speak();
}
interface IHuman
{
    void Speak();
}
class Person : IAnimal, IHuman
{
}
We have a problem conceptually: What should Person.Speak() mean ?
Maybe the two interfaces represent completely different behaviors.
Example:
   IAnimal.Speak() → Animal-style sound
   IHuman.Speak() → Human-style communication


✅🔥Explicit implementation allows us to provide two different implementations.
class Person : IAnimal, IHuman
{
    void IAnimal.Speak()
    {
        Console.WriteLine("Animal-style speak");
    }
    void IHuman.Speak()
    {
        Console.WriteLine("Human-style speak");
    }
}
IAnimal animal = new Person();
IHuman human = new Person();
animal.Speak(); // Animal-style speak
human.Speak(); // Human-style speak

---------------------------------------------------------------------

✅🔥Interface and is
You can check whether an object implements an interface.

IAnimal animal = new Dog();
if (animal is IAnimal)
{
    Console.WriteLine("Yes"); // yes
}

--------------------------------------------------------------------










