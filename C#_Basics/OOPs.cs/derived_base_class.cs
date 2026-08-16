
🔥 Golden rule: When a derived-class object is created, the base-class constructor executes first, followed by the derived-class constructor.
Let's start from the simplest inheritance example.
using System;
class Animal
{
    public Animal()
    {
        Console.WriteLine("Animal constructor");
    }
    public void Eat()
    {
        Console.WriteLine("Animal is eating");
    }
}
class Dog : Animal
{
    public Dog()
    {
        Console.WriteLine("Dog constructor");
    }
    public void Bark()
    {
        Console.WriteLine("Dog is barking");
    }
}
class Program
{
    static void Main()
    {
        Dog dog = new Dog();
        dog.Eat();
        dog.Bark();
    }
}
Output:
   Animal constructor
   Dog constructor
   Animal is eating
   Dog is barking
Now let's understand why.
Constructor Flow:

This line:Dog dog = new Dog(); 
means: Create a Dog object. But Dog inherits from Animal.
Animal
   ↑
   |
  Dog
Therefore, before the Dog object is completely ready, the Animal part must be initialized.
The constructor flow is:

----------------------------------------------------------------------------------------

✅🔥 Why base-class (Animal) portion should be initialize before derived class (Dog)
✅The key reason is:
A Dog IS an Animal, so the Animal state must be valid before the Dog can safely add its own state and behavior on top of it.
Let's create some actual state in Animal:
class Animal
{
    public int age;
    public Animal()
    {
        age = 10;
    }
}
class Dog : Animal
{
    public Dog()
    {
        Console.WriteLine(age);
    }
}
Here: If the Dog constructor executed before the Animal constructor
Dog constructor starts
        ↓
Dog accesses age
        ↓
But Animal initialization hasn't happened
        ↓
Animal state may not be ready

That would be dangerous.
C# therefore guarantees the base constructor executes first.

------------------------------------------------------------------------

✅🔥 How to initialized all fields of base claass by derived class constructor ?
Using base(...):
base(...) in C# is used in a derived class constructor to call a constructor of the base (parent) class.

using System;
class Animal
{
    protected string name;
    protected string s;
    public Animal(string name, string s)
    {
        this.name = name;
        this.s = s;
        Console.WriteLine("Animal constructor");
    }
    public void Eat()
    {
        Console.WriteLine(name + " is eating");
    }
}
class Dog : Animal
{
    private string ss;
    public Dog(string name, string s, string ss) : base(name, s)
    {
        this.ss = ss;
        Console.WriteLine("Dog constructor");
    }

    public void Bark()
    {
        Console.WriteLine(name + " is barking");
    }
}
class Program
{
    static void Main()
    {
        Dog dog = new Dog("Tommy", "AnimalData", "DogData");
        dog.Eat();
        dog.Bark();
    }
}