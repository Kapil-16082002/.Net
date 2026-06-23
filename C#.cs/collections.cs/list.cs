✅🔥 What is List<T>?
Definition:
It is a dynamic array, meaning it can grow or shrink automatically at runtime.
Namespace:
using System.Collections.Generic;

List<T> is a strongly typed, resizable collection that stores elements of the same type.
T = Type (int, string, Student, etc.)

List<int> list = new List<int>();
List<int> list = new List<int>(10); // default value 0
int[] arr = { 1, 2, 3 };
List<int> list = new List<int>(arr);



✅🔥Why List<T> instead of Array?
Array problems:
int[] arr = new int[3];
Fixed size ❌
Cannot grow/shrink dynamically ❌
No built-in add/remove ❌


List<T> advantages:
     Dynamic size ✔
     Built-in methods ✔
     Type-safe ✔
     Easy manipulation ✔

using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        numbers.Add(10);
        numbers.Add(20);
        numbers.Add(30);
        foreach (int n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}
✅🔥 Internal Working 
List uses an internal array
When capacity is full:
→ new array is created (usually double size)
→ old data copied
Capacity Growth:
4 → 8 → 16 → 32 ...

==================================================================================================================

✅ 1. Add() — Add single element

class Program
{
    static void Main()
    {
        List<int> list = new List<int>();
        list.Add(10);   // Adds 10
        list.Add(20);   // Adds 20
        list.Add(30);   // Adds 30
        foreach (int x in list)
        {
            Console.WriteLine(x);
        }

        // Output:
        // 10
        // 20
        // 30
    }
}
------------------------------------------------------------

✅ 2. AddRange() — Add multiple elements
Use case: Add multiple values at once.

using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        List<int> list = new List<int>();
        list.AddRange(new int[] { 40, 50, 60 });
        foreach (int x in list)
        {
            Console.WriteLine(x);
        }
        // Output:
        // 40
        // 50
        // 60
    }
}
-----------------------------------------------------------

✅ 3. Insert() — Insert at specific index
Use case: Insert value at a position.

class Program
{
    static void Main()
    {
        List<int> list = new List<int>() { 10, 30, 40 };
        list.Insert(1, 20);  // Insert 20 at index 1
        foreach (int x in list)
        {
            Console.WriteLine(x);
        }
        // Output:
        // 10
        // 20
        // 30
        // 40
    }
}
----------------------------------------------------------------

✅ 4. Remove() — Remove by value
Use case: Remove first matching value.

class Program
{
    static void Main()
    {
        List<int> list = new List<int>() { 10, 20, 30, 20 };
        list.Remove(20);  // removes first 20
        foreach (int x in list)
        {
            Console.WriteLine(x);
        }
        // Output:
        // 10
        // 30
        // 20
    }
}
---------------------------------------------------------------

✅ 5. RemoveAt() — Remove by index
Use case: Remove element at position.

class Program
{
    static void Main()
    {
        List<int> list = new List<int>() { 10, 20, 30 };
        list.RemoveAt(1);  // removes index 1 (20)
        foreach (int x in list)
        {
            Console.WriteLine(x); // 10, 30
        }
    }
}
-------------------------------------------------------------

✅ 6. RemoveRange() — Remove multiple elements
Use case: Delete block of items.

class Program
{
    static void Main()
    {
        List<int> list = new List<int>() { 10, 20, 30, 40, 50 };
        list.RemoveRange(1, 2); // remove 20, 30
        foreach (int x in list)
        {
            Console.WriteLine(x); // 10 , 40 , 50
        }
    }
}
---------------------------------------------------------------

✅ 7. Clear() — Remove all elements
Use case: Reset list.

class Program
{
    static void Main()
    {
        List<int> list = new List<int>() { 1, 2, 3 };
        list.Clear();
        Console.WriteLine(list.Count); // 0
    }
}
---------------------------------------------------------
✅ 8. Contains() — Check existence
Use case: Check if element exists.

class Program
{
    static void Main()
    {
        List<int> list = new List<int>() { 10, 20, 30 };
        Console.WriteLine(list.Contains(20)); // true
        Console.WriteLine(list.Contains(50)); // false
    }
}
-------------------------------------------------------------

✅ 9. IndexOf() — Find index
Use case: Find position of element.

class Program
{
    static void Main()
    {
        List<int> list = new List<int>() { 10, 20, 30 };
        Console.WriteLine(list.IndexOf(20)); // 1
    }
}
----------------------------------------------------------------

✅ 10. Count — Number of elements
Use case: Get size of list.

class Program
{
    static void Main()
    {
        List<int> list = new List<int>() { 10, 20, 30 };
        Console.WriteLine(list.Count);  // 3
    }
}
-------------------------------------------------------------------
✅ 11. Sort() — Sort elements
Use case: Arrange data.

class Program
{
    static void Main()
    {
        List<int> list = new List<int>() { 30, 10, 20 };
        list.Sort();
        foreach (int x in list)
        {
            Console.WriteLine(x); // 10, 20, 20
        }
    }
}
-----------------------------------------------------------------
✅ 12. Reverse() — Reverse list
Use case: Reverse order.

class Program
{
    static void Main()
    {
        List<int> list = new List<int>() { 10, 20, 30 };
        list.Reverse();
        foreach (int x in list)
        {
            Console.WriteLine(x); // 30, 20, 10
        }
    }
}
-------------------------------------------------------------
✅ 13. Exists() — Check condition
Use case: Check rule.
class Program
{
    static void Main()
    {
        List<int> list = new List<int>() { 10, 20, 30 };
        Console.WriteLine(list.Exists(x => x > 25)); // True
    }
}

------------------------------------------------------------------

✅ 13. Find() — First match
Use case: Find first condition match.
class Program
{
    static void Main()
    {
        List<int> list = new List<int>() { 5, 10, 15, 20 };
        int result = list.Find(x => x > 10);
        Console.WriteLine(result); // 15
    }
}
-------------------------------------------------------------------

✅ 14. FindAll() — All matches
Use case: Filter data.

class Program
{
    static void Main()
    {
        List<int> list = new List<int>() { 5, 10, 15, 20 };
        List<int> result = list.FindAll(x => x > 10);
        foreach (int x in result)
        {
            Console.WriteLine(x);
        }
    }
}
--------------------------------------------------------------------
✅ 16. ForEach() — Loop action
Use case: Apply operation on each element.

class Program
{
    static void Main()
    {
        List<int> list = new List<int>() { 10, 20, 30 };
        list.ForEach(x => Console.WriteLine(x)); // 10, 20, 30
    }
}

