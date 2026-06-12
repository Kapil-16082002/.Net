✅🔥🚀 using System.Runtime.InteropServices.Marshalling;

What is object type in C# ?
The object type is the base type of every data type in C#.
i.e Every type in C# (value type or reference type) ultimately derives from System.Object.

The following two declarations are identical:
object obj;
System.Object obj;


✅🔥Why can object store everything?
Because: Every Type inherits from System.Object, So every type can be treated as an object.
That means:
int derives from object
double derives from object
string derives from object
class derives from object
struct derives from object


✅🔥Why was object introduced?
Suppose a method should accept any kind of data.
Without object: Need multiple methods.
void PrintInt(int x){}
void PrintString(string s){}
void PrintDouble(double d){}


Instead:
void Print(object obj)
{
    Console.WriteLine(obj);
}
Now it accepts everything.


✅🔥Object is the Root of CTS: Everything ultimately inherits from System.Object.
                System.Object
                     ▲
         -------------------------
         |                       |
     Value Types           Reference Types
         |                       |
 int float bool          string array class
 decimal char            interface delegate
 struct enum             user-defined class


✅🔥Types that can be assigned to object
1. Value Types
object obj = 10; // int
object obj = 10.5; // float
object obj = true; // bool
object obj = 'A';  // char


2. Reference Types
object obj = "Hello"; // string 
object obj = new int[] {1,2,3}; // Arrays

class Employee{}
Employee emp = new Employee();  // class 
object obj = emp;

-----------------------------------------------------------------------------------------------------------------

✅🔥Object Arrays
One of the biggest uses of object is storing multiple types in one array.
Example:
using System;
class Program
{
    static void Main()
    {
        object[] arr ={ 100, 3.14, "kapil",true};
        foreach(object x in arr)
        {
            Console.WriteLine( $"Type={x.GetType()} Value={x}");
        }
    }
}
Output:
Type=System.Int32 Value=100
Type=System.Double Value=3.14
Type=System.String Value=Kapil
Type=System.Boolean Value=True

====================================================================================================================

✅🔥 Why Object Arrays Are Slow in C#
/*Because value types stored in object[] are boxed, creating heap allocations. 
Reading them requires unboxing, and the scattered heap objects reduce CPU cache efficiency while increasing garbage collection overhead.
*/
There are three major reasons:
1. Boxing
2. Unboxing
3. Heap allocations and garbage collection

✅🔥Reason 1: Boxing
Boxing is the process of converting a value type into an object (reference type) by copying the value into a new object on the managed heap.

Example:
int x = 10;
object obj = x;    // Boxing
Suppose we have: 
object[] numbers = new object[3];
numbers[0] = 10;
numbers[1] = 20;
numbers[2] = 30;
The array stores only references, not integers.
Here, 10 is an int (value type) but array expects object (reference type). So CLR performs Boxing.
Instead of storing 10 directly into stack, CLR creates a heap object containing 10.Every integer stored becomes a separate object.
This is called Boxing.

Internal Memory: 3 integers create 3 heap objects.
+--------+--------+--------+
| Ref1   | Ref2   | Ref3   |
+--------+--------+--------+

      |        |        |
      V        V        V
Heap
+----+
|10  |
+----+

+----+
|20  |
+----+

+----+
|30  |
+----+
3 integers create 3 heap objects.
This requires:
     Memory allocation
     Copying value
     Object header creation
     GC tracking
All these cost time.


Compare with int[] arr
int[] arr = {10,20,30};
Memory: Contiguous memory allocation happen
+----+----+----+
|10  |20  |30  |
+----+----+----+
No boxing.
No heap objects.
No references.
Much faster.

---------------------------------------------------------------------

✅🔥Reason 2: Unboxing
Unboxing extracts the value type from a boxed object and requires an explicit cast.
Suppose:
object[] arr = {10,20,30};
int x = (int)arr[0]; // unboxing
What happens? The integer stored inside object must be extracted. This is called Unboxing.

Heap Object
+------+
| 10   |
+------+
↓ extracted
10 // Copied to Stack

object[] arr = {10,20,30};
int sum = 0;
for(int i=0;i<arr.Length;i++)
{
    sum += (int)arr[i]; 
    sum += arr[i];//error,because arr[i] is of type object and sum is of type int.Operator `+=' cannot be applied to operands of type `int' and `object'

}
Unboxing requires:
    Type checking
    Casting
    Copying value
So Extra CPU work.

------------------------------------------------------------

✅🔥Reason 3: Garbage Collection Pressure
Example:
for(int i=0;i<1000000;i++)
{
    object x = i;
}
Every boxed integer creates an object. In this case, One million boxed objects are created.
Heap memory usage will increse and Garbage Collector must clean them. GC takes CPU time. Program slows down.

-------------------------------------------------------------

✅🔥Reason 4: Poor Cache Locality

Case 1: int[] (Excellent Cache Locality)
Suppose:
int[] arr = {10,20,30,40,50};

Memory looks like this:
Address
1000 → 10
1004 → 20
1008 → 30
1012 → 40
1016 → 50
Everything is stored continuously.
+----+----+----+----+----+
|10  |20  |30  |40  |50  |
+----+----+----+----+----+
Suppose CPU wants 10. It loads an entire cache line (typically 64 bytes).
Cache Line:
+-------------------------------+
|10|20|30|40|50|....remaining...|
+-------------------------------+
Even though CPU requested only 10, it automatically gets: 10,20,30,40,50 already inside cache.

Next loop iterations don't access RAM again.
for(int i=0;i<arr.Length;i++)
{
    Console.WriteLine(arr[i]);
}
Iteration:
Read 10 ✔ Cache
Read 20 ✔ Already in cache
Read 30 ✔ Already in cache
Read 40 ✔ Already in cache
Read 50 ✔ Already in cache
Very few cache misses.
Performance is excellent.


Case 2: object[] (Poor Cache Locality)
Suppose:
object[] arr ={10,20, 30, 40, 50};
The array stores only references, not integers.
Stack

arr
 │
 ▼
+------+------+------+------+------+
|Ref1 |Ref2 |Ref3 |Ref4 |Ref5 |
+------+------+------+------+------+
Heap:
Ref1 ---> 10
Ref2 ---> 20
Ref3 ---> 30
Ref4 ---> 40
Ref5 ---> 50
Elements are completely scattered not contiguous.
For Accessing each element first we to go to reference(i.e stores address of element), then we will get element placed at that address.
Also cache misses will increase becauses CPU cache loads nearby memory.
Example:
Address
5000 → 10
5004 → another object
5008 → another object
But next object is actually at 12000, CPU cannot predict that, this will causes cache misses.
-------------------------------------------------------------------------------------------------

✅🔥 When Should You Use object[] ?
Use it when storing different types together.
Example: object[] data = {100, "kapil", 99.5, true};


When Should You Avoid object[]?
Avoid this: object[] numbers ={ 1, 2, 3, 4, 5};
Use:        int[] numbers ={ 1, 2, 3, 4, 5};
Better:
No boxing.
No unboxing.
Better memory usage.
Faster execution.
-------------------------------------------------------------------------------------------------

✅🔥Does storing reference types in object[] cause boxing?
Answer:No
Reference types (such as string or custom classes) are already objects, so assigning them to an object[] only stores their references. 
Boxing occurs only for value types like int, double, bool, or struct.