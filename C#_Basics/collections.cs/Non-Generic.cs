✅🔥 Collections in C# (Complete Interview Explanation)

Collections in C# are data structures used to store, manage, and manipulate groups of objects.
Instead of working with single variables like:
int a = 10;
int b = 20;
int c = 30;
we use collections to store them together: List<int> numbers = new List<int>();



✅🔥 Why Do We Need Collections?
Arrays exist, so why collections? Because arrays are limited.
Problems with Arrays:

1. Fixed Size
int[] arr = new int[3];// You cannot increase size dynamically.

2. No Built-in Operations
Arrays do not provide:
     Add
     Remove
     Search
     Sort easily
3. Type Safety + Flexibility issues: // Arrays are rigid compared to modern requirements.
4. Real-world data is dynamic
Example:
     Student list
     Product list
     Employee records
     Online cart items
They change frequently.

===================================================================================================================

✅🔥Types of Collections in C#:
Non-generic collections are old-style collections in C# (before generics were introduced in .NET 2.0).
They store objects of type object, which means they can store any data type, but they are not type-safe.
Namespace:
using System.Collections;


✅ Why are they called “Non-Generic” ?
Because they use: object
So everything is stored as an object → boxing/unboxing is required.
Key Problem:
Since everything is stored as object:
❌ No type safety
❌ Performance overhead (boxing/unboxing)
❌ Runtime errors instead of compile-time errors


Main Non-Generic Collection Classes
| Collection | Description               |
| ---------- | ------------------------- |
| ArrayList  | Dynamic array             |
| Hashtable  | Key-value pair collection |
| Stack      | LIFO (Last In First Out)  |
| Queue      | FIFO (First In First Out) |
| SortedList | Sorted key-value pairs    |



✅🔥 Major Problems of Non-Generic Collections
1. No Type Safety
ArrayList list = new ArrayList();
list.Add(10);
list.Add("Hello"); // allowed (problem)


✅2. Boxing & Unboxing
Boxing:
int x = 10;
object obj = x; // boxing

Unboxing:
int y = (int)obj;
👉 This reduces performance.


✅3. Runtime Errors
int value = (int)list[1]; // runtime crash if wrong type


✅4. Poor Performance
Because:
Boxing/unboxing
Type casting
No compile-time checks

===================================================================================================================

1. ArrayList:
A dynamic array that can store any type of data.
Example:
using System;
using System.Collections;
class Program
{
    static void Main()
    {
        ArrayList list = new ArrayList();
        list.Add(10);
        list.Add("Hello");
        list.Add(3.14);
        list.Add(true);
        foreach (object item in list)
        {
            Console.WriteLine(item);
        }
    }
}
Output:
    10
    Hello
    3.14
    True
✅Problem:
You must cast when retrieving values: int num = (int)list[0];
If wrong type → runtime error.

===================================================================================================================

✅🔥 Hashtable
Stores key-value pairs, like a dictionary.
Example:
using System;
using System.Collections;
class Program
{
    static void Main()
    {
        Hashtable ht = new Hashtable();
        ht.Add(1, "Apple");
        ht.Add(2, "Banana");
        ht.Add(3, "Mango");
        foreach (DictionaryEntry item in ht)
        {
            Console.WriteLine(item.Key + " : " + item.Value);
        }
    }
}
Output:
1 : Apple
2 : Banana
3 : Mango

Problem:
No type safety for keys and values.
ht.Add("One", 100); // valid but confusing

====================================================================================================================

✅🔥 SortedList
Stores key-value pairs in sorted order of keys.
Example:
using System;
using System.Collections;
class Program
{
    static void Main()
    {
        SortedList sl = new SortedList();
        sl.Add(3, "C");
        sl.Add(1, "A");
        sl.Add(2, "B");
        foreach (DictionaryEntry item in sl)
        {
            Console.WriteLine(item.Key + " : " + item.Value);
        }
    }
}
Output:
1 : A
2 : B
3 : C





























































































