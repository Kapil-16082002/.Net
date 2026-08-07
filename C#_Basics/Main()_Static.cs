
✅🔥 Why is Main() Static ?
When your program starts, no object of Program exists yet.
The .NET runtime (CLR) needs a method it can call immediately to start execution.
If Main() were an instance method, the CLR would first have to create an object of Program.

But how would it know how to create that object ?
   What if the constructor requires parameters ?
   What if there are multiple constructors ?
   What if object creation has side effects ?
To avoid these issues, the CLR simply calls a static Main() because static methods belong to the class and can be invoked without creating an object.


✅🔥 Program startup looks like this:
CLR Starts
     │
     ▼
Find Program.Main()
     │
     ▼
Call Main()
No object is needed.




✅🔥 What happens if we remove static ?
Suppose you write:
class Program
{
    void Main()
    {
    }
}
This will not be recognized as the application's entry point.
The compiler reports an error because it cannot find a valid static Main method.
Typical error: Program does not contain a static 'Main' method suitable for an entry point.

=================================================================================================================

✅🔥 Why doesn't the CLR create an object automatically ?
Imagine this class:
class Program
{
    public Program(string name)
    {
    }
    void Main()
    {
    }
}
How would the CLR know what value to pass for name ?
It can't reliably determine how to construct your object, so it requires the entry point to be static.


=================================================================================================================

✅🔥 Can we create objects inside Main()?
Yes.
class Program
{
    static void Main()
    {
        Program p = new Program();
        p.Display();
    }
    public void Display()
    {
        Console.WriteLine("Hello");
    }
}
Here:
The CLR calls the static Main().
Main() creates an object.
The object calls the instance method Display().





