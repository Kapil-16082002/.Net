✅🔥Garbage Collector (GC) is the .NET runtime's automatic memory-management system.
It identifies managed objects that are no longer reachable and reclaims their memory.


✅🔥 Managed Code:
Code that executes under the control of the CLR is called managed code.
Managed code is not limited to C# classes that use objects. 
Any .NET code that executes under the CLR is generally considered managed code.


The CLR provides services such as:
   Automatic memory management
   Exception handling
   Type safety
   Language interoperability
Your C# code normally runs as managed code

--------------------------------------------------------------

✅🔥 Unmanaged Code:
Unmanaged code executes outside the direct control of the CLR.
Examples include native code written using:
   C
   C++
   Windows APIs
   COM
Your material describes unmanaged resources such as:
   File handles
   Database connections
   COM objects
   Native resources
-----------------------------------------------------------------

✅🔥 Managed Objects:
Managed objects are objects whose memory is managed by the .NET GC.
For example:
class Animal
{
    public string Name;
}
Animal a = new Animal();
The Animal object is a managed object.

Other common managed objects include:
   string  
   arrays
   class instances
   List<T>
   Dictionary<TKey,TValue>
The material explains that managed objects are allocated on the managed heap and are handled by the GC.

------------------------------------------------------------------

✅🔥 How Does GC Know What to Collect ?
The key is to understand that GC tracks object reachability, not simply whether a variable is null.

What is a GC Root?
A GC Root is a reference/location that the CLR considers a starting point when determining which objects are still alive.

Conceptually:
GC Roots
   │
   ├── Local variables
   ├── Static fields
   ├── Active method references
   ├── Runtime/JIT references
   └── Other runtime-managed roots
            │
            ▼
         Object A
            │
            ▼
         Object B

The GC starts from these roots and follows references.
Any object that can be reached is considered reachable/alive.

✅Simple Example:
class Animal
{
    public string Name;
}
Animal a = new Animal();
Animal b = new Animal();
a = null;

After: a = null;
we have: 
object a ──► null
object b ───────────────► Animal #2


Animal #1
    ↑
    │
 No reachable reference

Therefore:
Animal #1 → Eligible for GC
Animal #2 → Still reachable

✅Important:
Animal #1 is eligible for collection, but it is not necessarily collected immediately.
The GC decides when to perform a collection.
a = null
   ↓
Object may no longer be reachable
   ↓
Object becomes eligible for GC
   ↓
GC may collect it later

---------------------------------------------------------

✅🔥 GC Generations:
GC divides managed objects into generations based on how long they have survived.
NET traditionally uses three generations:
              Managed Heap
                  │
        ┌─────────┴─────────┐
        │                   │
      Gen 0                Gen 1                Gen 2
   Short-lived          Medium-lived          Long-lived
      objects              objects              objects


✅🔥 Why Does .NET Have Generations ?
Suppose an application creates:
for (int i = 0; i < 1_000_000; i++)
{
    MyClass obj = new MyClass();
}
A huge number of objects may be created. But many of them become useless very quickly.
There is no reason for the GC to repeatedly spend a lot of time examining long-lived objects when most of newly allocated objects are becoming useless.

---------------------------------------------------------

✅🔥 How Can You See an Object's Generation ?
.NET provides: GC.GetGeneration(object)
class MyClass{}
class Program
{
    static void Main()
    {
        MyClass obj = new MyClass();
        Console.WriteLine(GC.GetGeneration(obj));
    }
}
A newly allocated object will normally be reported as: Gen 0
So: GC.GetGeneration(obj) returns the object's current generation.

--------------------------------------------------------------


✅🔥Generation 0:
Gen 0 contains newly allocated, short-lived objects.
Example:
for (int i = 0; i < 1000000; i++)
{
    MyClass obj = new MyClass();
}
When you create an object:
MyClass obj = new MyClass();
the object is initially allocated in the youngest generation, Gen 0.



✅🔥 Why Is Gen 0 Collected Frequently ?
Consider:
for (int i = 0; i < 1_000_000; i++)
{
    MyClass obj = new MyClass();
}
Many objects are created. Many of these objects quickly become unreachable(unreachable).


Important Interview Point: Surviving Does Not Mean "Used a Lot"
When we say: "Object survived Gen 0"
we mean: The object was still reachable when a Gen 0 collection occurred.

============================================================================

✅🔥 Generation 1:
Gen 1 is essentially a middle generation.
If an object survives a Gen 0 collection, it can be promoted to Gen 1.
It contains objects that have survived Gen 0 collection(s).

Conceptually:
             New objects
                  │
                  ▼
               Gen 0
                  │
          survives collection
                  │
                  ▼
               Gen 1

✅ Why is Gen 1 useful ?
Because not every object is:
   Very short-lived
        OR
   Very long-lived
There are objects that live for an intermediate amount of time.
Gen 1 provides a buffer between short-lived and long-lived objects.

----------------------------------------------

✅🔥 Why Not Promote Directly from Gen 0 to Gen 2 ?
Imagine an object that survives one Gen 0 collection.
It might still die shortly afterward.

Conceptually:
Create object
     ↓
Gen 0
     ↓
survives first collection
     ↓
Gen 1
     ↓
later becomes garbage
If it were immediately promoted to Gen 2, the GC would consider it part of the long-lived generation.

===============================================================================================================

✅🔥Generation 2:
Gen 2 contains objects that have survived long enough to be considered long-lived.

Conceptually:
Gen 0
  │
  │ survives
  ▼
Gen 1
  │
  │ survives
  ▼
Gen 2

-----------------------------------

✅🔥 Can a Gen 2 Object Become Gen 1?
No.
Promotion is conceptually one-way: Gen 0 → Gen 1 → Gen 2
Once an object reaches Gen 2, it remains in the older generation until it is eventually collected.


-----------------------------------
✅🔥 Static Objects reference and Gen 2:
A static reference can keep an object alive for a long time, so such an object may eventually be promoted to Gen 2 if it survives enough collections.

-----------------------------------

✅🔥 Very Important: GC Doesn't Always Collect Only One Generation
Gen 0 collection primarily focuses on Gen 0.
A Gen 1 collection conceptually includes: Gen 0 + Gen 1
A Gen 2 collection is commonly referred to as a full collection and involves the older generations as well.

Conceptually:

Gen 0 GC
└── Gen 0


Gen 1 GC
├── Gen 0
└── Gen 1


Gen 2 GC
├── Gen 0
├── Gen 1
└── Gen 2

-----------------------------------------

✅🔥 Why Gen 0 GC Is Fast ?
Gen 0 contains objects that survived for short time. Therefore, they occupied less amount of memory.

Suppose you have:
Gen 0 → 10 MB
Gen 1 → 50 MB
Gen 2 → 500 MB
If most newly created objects are short-lived, checking Gen 0 is much cheaper than repeatedly examining the entire managed heap.

Instead of: Scan 560 MB
the GC can often focus primarily on the young generation. That's one of the major benefits of generational GC.


-----------------------------------------

✅🔥 Gen 2 Collection Is More Expensive:
Gen 2 contains objects that have survived previous collections. Therefore, it can contain a significant amount of memory.

=============================================================================================================

✅🔥GC.Collect() 
GC.Collect()  is used to explicitly request the .NET Garbage Collector to perform a garbage collection.
The key word is request. It does not mean "delete this object immediately."
class MyClass
{
    public int[] arr = new int[1024 * 1024];
}
class Program
{
    static void Main()
    {
        MyClass obj = new MyClass();
        obj = null; // obj's object is now eligible for GC
        GC.Collect();
    }
}
✅🔥 When does an object become eligible ?
Example:
MyClass obj = new MyClass();
obj = null;
GC.Collect();

Initially:
obj
 |
 v
+----------+
| MyClass  |
+----------+


After: obj = null;
there is no reference from obj:
obj → null
+----------+
| MyClass  |<-- unreachable : Now the object is eligible for collection.
+----------+

---------------------------------------------

✅🔥 GC.Collect() can collect different generations
You can simply write: GC.Collect();

or specify a generation:
GC.Collect(0); // This requests collection up to Generation 0.
GC.Collect(1); // Requests collection up to Generation 1.
GC.Collect(2); // Requests collection up to Generation 2.

You can also use: 
GC.Collect(GC.MaxGeneration);
For the usual .NET GC configuration, GC.MaxGeneration is commonly 2.


----------------------------------------------

✅🔥 Why shouldn't we normally call GC.Collect() ?

The GC is optimized to determine when collection is beneficial.
If you repeatedly do:
for (int i = 0; i < 10000; i++)
{
    MyClass obj = new MyClass();
    GC.Collect(); // ❌ Bad idea
}
Here, you're forcing the runtime to perform collections unnecessarily.
This can cause:
   additional CPU overhead
   application pauses
   reduced performance
   unnecessary GC work
   objects being promoted unnecessarily in some scenarios



