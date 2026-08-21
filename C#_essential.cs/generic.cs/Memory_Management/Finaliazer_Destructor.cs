✅🔥Finalizer / Destructor:

A finalizer is a special method in C# that gives an object an opportunity to perform cleanup before the object's memory is reclaimed by the Garbage Collector.
The syntax looks like a destructor:
class MyClass
{
    ~MyClass()
    {
        // cleanup code
    }
}
In C#, this is called a finalizer. You may hear it called a destructor, but technically, in modern C#, it is a finalizer.


Notice: ~MyClass()
The name must be the same as the class.
It has:
    No return type 
    No access modifier  // public ~MyClass()   // ❌
    No parameters       // ~MyClass(int x)     // ❌
    ~ before the class name

----------------------------------------------------------------

✅🔥 Why Do We Need a Finalizer?
Normally, the Garbage Collector handles managed memory automatically.
Example:
class Animal
{
    public string Name;
}
Animal animal = new Animal();
The CLR/GC knows how to reclaim the memory occupied by the Animal object when it becomes unreachable.
Animal object
     ↓
becomes unreachable
     ↓
GC eventually collects it
     ↓
managed memory reclaimed



But suppose your object owns an unmanaged resource.
Examples:
   Native memory
   Operating-system handles
   Native file handles
   Native sockets/resources
   Certain OS-level resources
   Handles returned by native APIs
The GC does not directly know how to release those resources.
Example:
C# object
   │
   ├── managed data → GC can manage
   │
   └── native resource → GC doesn't directly manage


--------------------------------------------------------------

✅🔥 You Can not Call a Finalizer Yourself
Suppose:
class MyClass
{
    ~MyClass()
    {
        Console.WriteLine("Finalizer");
    }
}
MyClass obj = new MyClass();
obj.~MyClass();    // ❌ Invalid
The finalizer is invoked by the runtime/finalization mechanism, not directly by your application code.

You don't control exactly when it runs.

--------------------------------------------------------------

✅🔥 When Does a Finalizer Run?
Consider:
class MyClass
{
    ~MyClass()
    {
        Console.WriteLine("Finalizer executed");
    }
}
static void Main()
{
    MyClass obj = new MyClass();
    obj = null;
}
After: obj = null; the object may become unreachable:
GC Root
   │
   ▼
obj
   │
   X
   │
   ▼
MyClass object

But because the object has a finalizer, the GC cannot simply reclaim its memory immediately.
Conceptually:
Object becomes unreachable
          ↓
       Finalizable
          ↓
Finalization process
          ↓
Finalizer executes
          ↓
Object can eventually be reclaimed

This is the key difference.

-------------------------------------------------------

✅🔥 Normal Object vs Finalizable Object
Object without finalizer
class Animal
{
}
Conceptually:
Animal becomes unreachable
          ↓
     GC can reclaim
          ↓
       Memory free


✅Object with finalizer:
class Animal
{
    ~Animal()
    {
    }
}
Conceptually:
Animal becomes unreachable
          ↓
Finalization required
          ↓
Finalizer gets opportunity to run
          ↓
Later GC can reclaim memory

------------------------------------

Finalization Queu



