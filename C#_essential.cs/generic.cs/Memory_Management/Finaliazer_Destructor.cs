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

✅🔥 Normal Object vs Finalizable Object:
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

✅🔥 Finalization Queue:
When an object has a finalizer, the runtime keeps track of it so that its finalizer can eventually be executed.
The important interview point is:

Finalizers are executed by the runtime's finalization mechanism, not directly by the thread that made the object unreachable.

Object with finalizer
        │
        ▼
Finalization tracking
        │
        ▼
Object becomes unreachable
        │
        ▼
GC identifies it
        │
        ▼
Finalization mechanism
        │
        ▼
Finalizer executes

==============================================================================================================

✅🔥 IDisposable and Dispose()
For deterministic cleanup of resources, .NET provides: IDisposable
Deterministic cleanup means:
You explicitly control when a resource is released, rather than waiting for the Garbage Collector to decide when cleanup should happen.

class MyResource : IDisposable
{
    public void Dispose()
    {
        Console.WriteLine("Resource cleaned up");
    }
}
MyResource resource = new MyResource();
resource.Dispose();
Output: Resource cleaned up



✅🔥 Why Dispose() ?
This is a very important distinction:
GC Handles:  Managed memory
Dispose Handles: Resources that need deterministic release
For example:
   File handles
   Database connections
   Sockets
   Native handles

-------------------------------------------------

✅🔥 If a class contains both IDisposable and a finalizer, both can execute — but normally only one should perform the actual cleanup.
Your code is:
class MyResource : IDisposable
{
    ~MyResource()
    {
        // Finalizer
    }
    public void Dispose()
    {
        // Dispose cleanup
        GC.SuppressFinalize(this);
    }
}
The answer depends on how the object is cleaned up.

✅ 1. If you call Dispose() explicitly
MyResource resource = new MyResource();
resource.Dispose();

The flow is:
resource.Dispose()
       ↓
Dispose() executes
       ↓
GC.SuppressFinalize(this)
       ↓
Finalizer is suppressed
       ↓
Finalizer does NOT execute

So:
Dispose()       → ✅ Executes
Finalizer       → ❌ Does not execute

Why? Because: GC.SuppressFinalize(this);
tells the GC: "This object's cleanup has already been performed. Don't run its finalizer."






