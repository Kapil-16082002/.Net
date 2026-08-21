
✅#Abstraction:
It is the process of hiding the complex implementation details and showing only the essential or necessary information of an object. 

how does abstraction differ from encapsulation ?

Abstraction:    Hiding implementation (logic) details.
Encapsulation:  Hiding internal data details and restricting direct access to certain parts of data using access control (e.g., `private`, `protected`).

Abstraction:  Focuses on defining **WHAT** an object does, rather than **HOW** it does it.
Encapsulation: Focuses on controlling **HOW** the internal behavior or data of an object is accessed or modified.

Abstraction:   To provide a simplified interface for the user and hide unnecessary details of the implementation.
Encapsulation: To restrict unauthorized access and protect the internal state of an object. 


✅For example, when you drive a car:
You know:
    Start()
    Accelerate()
    Brake()

You don't need to know:
    How fuel is injected
    How engine combustion happens
    How the transmission works
    How the ECU controls everything

✅ Real-Life Example:
Consider an ATM.

You see:
   Withdraw()
   Deposit()
   CheckBalance()
You don't see the internal implementation:
Validate PIN
        ↓
Connect to bank server
        ↓
Check account
        ↓
Check balance
        ↓
Process transaction
        ↓
Update database

You only interact with:
ATM
 ├── Withdraw()
 ├── Deposit()
 └── CheckBalance()
That is abstraction.

================================================================================================================

✅Abstraction in C#:
C# mainly provides abstraction through:
   1. Abstract classes: abstract class Animal{}
   2. Interfaces: interface IAnimal{}

Complete Abstract Method Example:
using System;
abstract class Animal
{
    public abstract void Speak();
}
class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Dog says: Woof");
    }
}
class Cat : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Cat says: Meow");
    }
}
class Program
{
    static void Main()
    {
        Dog d = new Dog();
        Cat c = new Cat();

        d.Speak();
        c.Speak();
    }
}
Output:
Dog says: Woof
Cat says: Meow









