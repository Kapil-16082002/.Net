
✅🔥 What is an Abstract Class ?
An abstract class is a class declared using the abstract keyword:
It is generally designed to be a base class.

abstract class Animal
{
}
You cannot create an object directly from it:
Animal animal = new Animal();   // ERROR

Why ?
Because Animal is abstract and abstract class is considered as partially defined class(incomplete class)
Animal
 ├── common things → can be implemented
 └── incomplete things → derived classes must implement

---------------------------------------------------------------------

✅🔥 What is an Abstract Method?

An abstract method is declared with: abstract and does not have a method body.
Every concrete derived class must provide its own implementation of this method."
Example:
public abstract void Speak(); // Notice, There is no { }
public abstract void Speak() 
{
    Console.WriteLine("Hello"); // ❌ not allowed
}

-----------------------------------------------------------------------

✅🔥 Abstract class vs abstract method
Abstract class:
abstract class Animal
{
}
Means: Animal cannot be instantiated directly. It may or may not contain abstract members.


Abstract method:
public abstract void Speak();
Means: This method has no implementation here. A concrete derived class must provide the implementation.
abstract method can only exist inside an abstract class.

----------------------------------------------------------------------

✅🔥Important clarification: It is not necessary, Abstract class always have to contain an abstract method.
abstract class Animal
{
    public void Eat()  // not virtual
    {
        Console.WriteLine("Animal Eating");
    }
}
class Dog : Animal
{
    public new void Eat()
    {
        Console.WriteLine("Dog Eating"); 
    }
} //There is no abstract method, but you still cannot do:
Animal a = new Animal();   // ❌
Dog d = new Dog();        // ✅
Animal a = new Dog();  // ✅ Animal is abstract but still you can use Animal as a reference type. Because the actual object being created is Dog, which is concrete.

Why?
Because the abstract keyword on the class itself means:
This class is incomplete/intended to be a base class and cannot be instantiated directly.
So don't tell the interviewer: "We cannot create an abstract class object because it contains abstract methods." That's not always true.


✅🔥NOTE:  Now the interesting part: Eat()
abstract class Animal
{
    public void Eat() // not virtual
    {
        Console.WriteLine("Animal Eating");
    }
}
class Dog : Animal
{
    public void Eat()
    {
        Console.WriteLine("Dog Eating");
    }
}
What happens here ?
Animal a = new Dog();
a.Eat();// Animal Eating
Notice that Eat() is not virtual. Therefore, Dog.Eat() is not overriding Animal.Eat().
It is hiding the base method.
The compiler would normally warn you and recommend: public new void Eat()


So preferably write:
class Dog : Animal
{
    public new void Eat()
    {
        Console.WriteLine("Dog Eating");
    }
}
Why?
Because Eat() is non-virtual. The compiler looks at the reference type: Animal a and resolves: Animal.Eat()
It does not dynamically dispatch to Dog.Eat().

Now:
Dog d = new Dog();
d.Eat(); // Dog Eating
Because the reference type is Dog, so the compiler selects: Dog.Eat() and output will be  Dog Eating.

====================================================================================================================

✅🔥 First Complete Example:
using System;
abstract class Animal
{
    public abstract void Speak();
}
class Dog : Animal
{
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
    }
}
Output:  Dog barks


✅🔥 Why is the output Dog barks ?
This line is the most important: Animal animal = new Dog();
There are two types here:
   Reference type = Animal
   Object type    = Dog
But Animal.Speak() is abstract, so Animal has no implementation to execute.
Runtime looks at the actual object:
Animal reference
       ↓
Dog object
       ↓
Dog.Speak()
Therefore Output: Dog barks, This is runtime polymorphism.



✅🔥Why Is override Required?
The override keyword tells the compiler: "derived class is providing the implementatio of the inherited abstract/virtual method."
if you remove override, the code will not compile.
Because when a class inherits an abstract method, the derived class must explicitly override that method.
Every concrete derived class must provide an implementation of Speak()

-------------------------------------------------------------------------

✅🔥A Concrete Class Must Implement Abstract Members:
abstract class Animal
{
    public abstract void Speak();
}
class Dog : Animal
{
}
This gives a compilation error. Because Dog is a normal/concrete class, but it hasn't implemented:
-----------------------------------------------------------------------------

✅🔥 But an Abstract Derived Class Can Leave It Unimplemented
abstract class Animal
{
    public abstract void Speak();
}
abstract class Dog : Animal
{
}
This is valid. Because Dog is also abstract. It can leave the implementation for another derived class.

For example:
class Puppy : Dog // first concrete class inheriting Dog class must implement the abstract method.
{
    public override void Speak()
    {
        Console.WriteLine("Puppy barks");
    }
}
So:
Animal (abstract)
       ↓
Dog (abstract)
       ↓
Puppy (concrete)
Eventually, the first concrete class must implement the abstract method.
-------------------------------------------------------------------------

✅🔥 An abstract class does NOT need to have at least one abstract method.
Then why make a class abstract ?
The main AIM of having abstract class is defining common behavior/properties, so that each derived class must implement those commmon behaviors.
"This class is intended to be used as a base class and should not be instantiated directly."
For example:
abstract class Animal
{
    public void Eat()
    {
        Console.WriteLine("Eating");
    }
}
Every animal(dog, cat, elephant) eat() something.
We may want every animal to inherit the common Eat() behavior, but we don't want someone to create a generic Animal object.


--------------------------------------------------------------------------

✅🔥 Abstract Class Can Have Normal Methods

An abstract class does not mean: ❌"Every method must be abstract."
An abstract class can contain:
   fields
   constructors
   normal methods
   virtual methods
   abstract methods
   properties etc.
Complete Example — Normal + Virtual + Abstract:
using System;
abstract class Animal
{
    public void Eat()
    {
        Console.WriteLine("Animal eats");
    }
    public virtual void Sleep()
    {
        Console.WriteLine("Animal sleeps");
    }
    public abstract void Speak();
}
class Dog : Animal
{
    public override void Sleep()
    {
        Console.WriteLine("Dog sleeps");
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
        animal.Eat();
        animal.Sleep();
        animal.Speak();
    }
}
Output:
Animal eats
Dog sleeps
Dog barks

------------------------------------------------------------------------

✅🔥 Virtual vs Abstract method:
abstract = must override; virtual = may override.
It is NOT necessary to override a virtual method in the derived class.

It is  necessary to override a abstract method in first concrete (non-abstract) derived class.
abstract method has no implementation. Therefore, a concrete derived class like Dog must implement it:

✅ Why use virtual then ?
Base class has default implementation. Derived classes may replace it."
We use virtual when the base class has a default implementation that is valid for general cases, 
, but derived classes may need to provide their own specialized implementation or want to change base class behavior.

Example:
using System;
class Animal
{
    public virtual void Sound() // here base class provides default implementation of sound()
    {
        Console.WriteLine("Animal makes a sound");
    }
}
class Dog : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Dog barks");
    }
}

class Lion : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Lion roars");
    }
}
class Program
{
    static void Main()
    {
        Animal animal1 = new Dog();
        Animal animal2 = new Lion();

        animal1.Sound();
        animal2.Sound();
    }
}
Here Animal class provides default implementation of sound()
But different animals have different behavior:
Animal
  |
  +---- Dog  → Sound() → Dog barks
  |
  +---- Lion → Sound() → Lion roars

Because Sound() is virtual, Dog and Lion can override it and provide their own behavior.




