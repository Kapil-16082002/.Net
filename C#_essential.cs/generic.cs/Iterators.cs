✅🔥 What is an Iterator?
An Iterator is a method, property, or get accessor that allows you to iterate through a collection one element at a time without exposing the internal implementation of the collection.
Instead of returning the entire collection at once, an iterator returns one item at a time.


✅🔥 Why Do We Need Iterators ?
Suppose you have one million numbers.

✅Without an iterator:
List<int> numbers = new List<int>();
for(int i=1;i<=1000000;i++)
{
    numbers.Add(i);
}
The whole list is created in memory.


✅With an iterator:
yield return 1;
yield return 2;
yield return 3;
...
Only the current value exists while iterating.
Memory usage is much lower.

-----------------------------------------------------

✅🔥 Before Iterators
Before yield: we manually implemented IEnumerator.
After yield:
Same logic: Compiler generates the entire enumerator automatically.
class Numbers
{
    public IEnumerable<int> GetNumbers()
    {
        yield return 1;
        yield return 2;
        yield return 3;
    }
}
------------------------------------------------------

✅🔥What is yield?
yield is a keyword that tells the compiler:
"Pause this method here, return the current value, and continue from this point the next time iteration resumes."
It is used only in iterator methods.

✅ Types of yield:
yield return
yield break


1. yield return:
Returns one value.

Example:
using System;
using System.Collections.Generic;
class Program
{
    static IEnumerable<int> GetNumbers()
    {
        yield return 10;
        yield return 20;
        yield return 30;
    }
    static void Main()
    {
        foreach(var number in GetNumbers())
        {
            Console.WriteLine(number);
        }
    }
}
Output:
10
20
30

✅🔥How It Works Internally:
GetNumbers()
↓
yield return 10
↓
Pause
↓
Next iteration
↓
yield return 20
↓
Pause
↓
Next iteration
↓
yield return 30
↓
Finished

------------------------------------------------

✅🔥 yield break
Terminates iteration immediately.
Example:
using System.Collections.Generic;
class Program
{
    static IEnumerable<int> GetNumbers()
    {
        yield return 1;
        yield return 2;
        yield break;
        yield return 3;
    }
}
Output:
1
2
3 is never returned.
==================================================================================================================

✅🔥Iterator Example

Generate numbers from 1 to 5.
using System;
using System.Collections.Generic;
class Program
{
    static IEnumerable<int> GenerateNumbers()
    {
        for(int i=1;i<=5;i++)
        {
            yield return i;
        }
    }
    static void Main()
    {
        foreach(var n in GenerateNumbers())
        {
            Console.WriteLine(n);
        }
    }
}
Output:
1
2
3
4
5
-------------------------------------------------------------

✅🔥 Iterator Returning Objects
class Employee
{
    public int Id;
    public string Name;
}

static IEnumerable<Employee> GetEmployees()
{
    yield return new Employee
    {
        Id = 1,
        Name = "John"
    };

    yield return new Employee
    {
        Id = 2,
        Name = "Alice"
    };
}
==================================================================================================================

✅🔥 What is Lazy Evaluation?
Lazy Evaluation is a technique where an operation is not executed immediately. 
Instead, it is delayed until its result is actually needed.
In simple words: Don't do the work now. Wait until someone asks for the result.
using System;
using System.Collections.Generic;
class Program
{
    static IEnumerable<int> Numbers()
    {
        Console.WriteLine("Generating 1");
        yield return 1;

        Console.WriteLine("Generating 2");
        yield return 2;

        Console.WriteLine("Generating 3");
        yield return 3;
    }
    static void Main()
    {
        IEnumerable<int> result = Numbers();
        Console.WriteLine("Iterator Created");
    }
}
What do you think the output is ?
Many beginners think:
Generating 1
Generating 2
Generating 3
Iterator Created
❌ Wrong.
Output: Iterator Created
/* 
IEnumerable<int> result = Numbers();
Numbers() will not execute immediately. Instead, C# creates an iterator object.

✅When does execution actually begin?
When we enumerate.
foreach(var n in result)
{
    Console.WriteLine(n);
}
Now the iterator starts running.
*/

---------------------------------------------------------------

✅🔥 What is Deferred Execution?
Deferred Execution means delaying the execution of a method or query until its result is actually enumerated or requested.
In simple words: The code is prepared now, but it doesn't run until someone asks for the data.

The word deferred means:
Postponed
Delayed
Not executed immediately


✅ Real Life Example:
Imagine Netflix. When you open Netflix, does it download every movie?
No.

Open Netflix
↓
Show Movie List
↓
Click Movie
↓
Start Downloading
↓
Play
Downloading is deferred until needed.



✅🔥 Deferred Execution with Iterators
using System;
using System.Collections.Generic;
class Program
{
    static IEnumerable<int> GetNumbers()
    {
        Console.WriteLine("Method Started");
        yield return 1;
        yield return 2;
    }
    static void Main()
    {
        var numbers = GetNumbers();
        Console.WriteLine("Iterator Created");
    }
}
What happens? Many beginners think Output will be:
Method Started
Iterator Created
Wrong ❌
Actual Output: Iterator Created

✅When does execution actually start?
Only when foreach(var n in numbers) will be executed.


==============================================================================================================

✅🔥Types of Iterators
From an interview perspective, iterators are commonly classified as:

1.✅🔥 Iterator Method
IEnumerable<int> GetNumbers()
{
    yield return 1;
}

2.✅🔥 Iterator Property
IEnumerable<int> Numbers
{
    get
    {
        yield return 1;
    }
}
3.✅🔥 Generic Iterator:
Returns:
IEnumerable<T>
IEnumerator<T>

Example:
IEnumerable<string> GetNames()
{
    yield return "John";
}
4. Non-Generic Iterator

Returns:
IEnumerable
IEnumerator

Example:
using System.Collections;
IEnumerable GetNumbers()
{
    yield return 1;
    yield return 2;
}
Generic iterators are preferred because they are type-safe.

===============================================================================================================

✅🔥 Restrictions of yield:
You cannot use yield in these situations:

✅1. Constructors
❌ Invalid:
class Sample
{
    public Sample()
    {
        yield return 1;
    }
}
---------------------------------
✅2. catch Block
❌ Invalid:
try
{
}
catch
{
    yield return 1;
}
----------------------------------
✅3. finally Block
❌ Invalid:
finally
{
    yield return 1;
}
----------------------------------
4. Methods Returning void
❌ Invalid:
void Test()
{
    yield return 1;
}





















































