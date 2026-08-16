
✅🔥 Casting: Moving between a base-class reference and a derived-class reference.

1. Upcasting — implicit casting
class Animal
{
    public virtual void Speak()
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
    public void Bark()
    {
        Console.WriteLine("Bark method");
    }
}
Dog dog = new Dog();
animal.Speak();  //Dog barks
Animal animal = dog; // upcasting
It is called upcasting because we are moving from a derived type to a base type.

Important:
Through the Animal reference, you can access only members available in Animal:
   animal.Speak();   // ✅
   animal.Bark();    // ❌
Even though the actual object is a Dog.

-------------------------------------------------

✅🔥 Explicit Downcasting
Now suppose:
Animal animal = new Dog();
Dog dog = (Dog)animal;  // explicitly cast
dog.Speak(); // Dog barks
dog.Bark();

This is downcasting:
Animal
   ↓
 Dog

--------------------------------------------------

✅🔥Why is downcasting explicit ?
Because not every Animal is a Dog.

For example:           Animal animal = new Cat();
Now this is dangerous: Dog dog = (Dog)animal;

----------------------------------------------------

✅🔥 as operator : Another way of downcasting is using as.

Animal animal = new Dog();
Dog dog = animal as Dog;
If the object really is a Dog, you get the reference.
animal → Dog
          ↓
       dog reference
Then:
if (dog != null)
{
    dog.Bark();
}
Output: Bark method


✅🔥 What if the cast is invalid?
Suppose:
Animal animal = new Cat();
Dog dog = animal as Dog;
Instead of throwing an exception, as returns: null

-----------------------------------------------------

✅🔥is operator + pattern matching
Modern C# provides an even cleaner way.

Animal animal = new Dog();
if (animal is Dog dog)
{
    dog.Bark();
}
Output: Bark method

✅ Here:  animal is Dog dog
does two things:
   Checks whether animal actually refers to a Dog
   If yes, creates the dog variable containing the cast reference
Conceptually:
animal
  ↓
Is it Dog?
  ↓
YES
  ↓
dog reference created

---------------------------------------------

✅🔥 is without pattern matching
You can also write:

Animal animal = new Dog();
if (animal is Dog)
{
    Dog dog = (Dog)animal;
    dog.Bark();
}
This works, but modern C# generally prefers:
if (animal is Dog dog)
{
    dog.Bark();
}
because the type check and cast are combined.

--------------------------------------------------


✅🔥 GetType() and typeof()
You can also inspect the runtime type:

Animal animal = new Dog();
if (animal.GetType() == typeof(Dog))
{
    Dog dog = (Dog)animal;
    dog.Bark();
}
GetType() returns the actual runtime type of the object.

For: Animal animal = new Dog();
we get: animal.GetType() → Dog
 
typeof(Dog) is compile-time type information.
animal.GetType() tells you the actual runtime type of the object.




