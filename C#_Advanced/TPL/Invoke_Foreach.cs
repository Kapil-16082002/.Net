✅🔥 What is Parallel Programming?
Parallel Programming is a programming technique in which multiple independent operations execute simultaneously on multiple CPU cores to complete work faster.
Instead of doing one task after another, several tasks are executed at the same time.

✅Imagine you have four independent jobs.
✅ Without Parallel Programming
Job1
↓
Job2
↓
Job3
↓
Job4
One finishes, then next starts. Task will execute sequentially.

✅ With Parallel Programming
Core 1 → Job1
Core 2 → Job2
Core 3 → Job3
Core 4 → Job4
All execute simultaneously.

-------------------------------------------------

✅🔥 Why Parallel Programming?
Modern CPUs don't have just one processor.
Example:
   Intel i5
       ↓
     Core 1
     Core 2
     Core 3
     Core 4
If your program uses only one core...
  Core1 = Busy
  Core2 = Idle
  Core3 = Idle
  Core4 = Idle
75% CPU power is wasted.
Parallel Programming utilizes all available cores.

--------------------------------------------------

✅🔥Parallel Class:
Namespace: using System.Threading.Tasks;
The Parallel class provides methods to execute operations concurrently on multiple processors.
Important methods:
    Parallel.Invoke()
    Parallel.For()
    Parallel.ForEach()

===================================================================================================================   

✅🔥 Parallel.Invoke()
Parallel.Invoke() executes multiple independent methods in parallel.
Parallel.Invoke internally creates Tasks. You don't create them manually.
Syntax:
Parallel.Invoke(
    Action1,
    Action2,
    Action3
);
Syntax: public static void Invoke(...)
Return Type: Void


✅🔥Method Signature: public static void Invoke(params Action[] actions)
Example:
using System;
using System.Threading;
using System.Threading.Tasks;
class Program
{
    static void Main()
    {
        Parallel.Invoke(
            PrintA,
            PrintB,
            PrintC
        );
        Console.WriteLine("Finished");
    }
    static void PrintA()
    {
        Console.WriteLine($"A : Thread {Thread.CurrentThread.ManagedThreadId}");
    }
    static void PrintB()
    {
        Console.WriteLine($"B : Thread {Thread.CurrentThread.ManagedThreadId}");
    }
    static void PrintC()
    {
        Console.WriteLine($"C : Thread {Thread.CurrentThread.ManagedThreadId}");
    }
}
Possible Output: Output order is NOT guaranteed.
A : Thread 4
C : Thread 6
B : Thread 5
Finished

----------------------------------------------

✅🔥Parallel.Invoke is BLOCKING" mean?
The thread that calls Parallel.Invoke() stops and waits until all the supplied methods have finished executing.
Only after every method completes does the program continue with the next statement.

Main Thread
    │
    ▼
Calls Parallel.Invoke()
    │
    ├── Task 1 starts
    ├── Task 2 starts
    └── Task 3 starts
          │
          ▼
Wait until ALL tasks finish
          │
          ▼
Parallel.Invoke() returns
          │
          ▼
Console.WriteLine("Done")

| `Parallel.Invoke()`                                     | `Task.Run()`                                                                       |
| ------------------------------------------------------- | ---------------------------------------------------------------------------------- |
| **Blocking**                                            | **Non-blocking**                                                                   |
| Waits for all operations to finish before returning     | Returns immediately after scheduling the task                                      |
| Next statement executes only after all methods complete | Next statement executes immediately unless you explicitly call `Wait()` or `await` |

================================================================================================================

✅🔥Parallel Loops
Suppose you need to process 10,000 images.
Normal loop:
Image1
↓
Image2
↓
Image3
↓
...
↓
Image10000
Only one CPU core works.


✅Parallel Loop:
Core1 → Image1
Core2 → Image2
Core3 → Image3
Core4 → Image4
Many images are processed simultaneously.
This is exactly why Microsoft introduced Parallel.For and Parallel.ForEach.



✅🔥 Parallel.For()
Parallel.For() executes iterations of a for loop in parallel using multiple threads from the ThreadPool.
Instead of one iteration after another, multiple iterations execute simultaneously.
Namespace: using System.Threading.Tasks;
Return Type: ParallelLoopResult

Method Signature:
public static ParallelLoopResult For(
    int fromInclusive,
    int toExclusive,
    Action<int> body
);

| Parameter     | Type        | Description                      |
| ------------- | ----------- | -------------------------------- |
| fromInclusive | int         | Starting index (included)        |
| toExclusive   | int         | Ending index (excluded)          |
| body          | Action<int> | Code executed for each iteration |

✅Example 1:
using System;
using System.Threading;
using System.Threading.Tasks;
class Program
{
    static void Main()
    {
        Parallel.For(0, 5, i =>
        {
            Console.WriteLine( $"Iteration {i}, Thread {Thread.CurrentThread.ManagedThreadId}");
            });
    }
}
Possible Output:  Order is NOT guaranteed.
Iteration 0 Thread 4
Iteration 2 Thread 6
Iteration 1 Thread 5
Iteration 4 Thread 7
Iteration 3 Thread 6


✅Example 2: (Using Local Variable)
Parallel.For(1, 6, i =>
{
    int square = i * i;
    Console.WriteLine($"{i}² = {square}");
});
Possible Output:
3² = 9
1² = 1
5² = 25
2² = 4
4² = 16
====================================================================================================================

✅🔥 Parallel.ForEach()
Parallel.ForEach() executes iterations of a collection in parallel.
Return Type: ParallelLoopResult
Instead of:
foreach
↓
Item1
↓
Item2
↓
Item3


It becomes:
Core1 → Item1
Core2 → Item2
Core3 → Item3



✅ Method Signature:
public static ParallelLoopResult ForEach<TSource>(
    IEnumerable<TSource> source,
    Action<TSource> body
);
| Parameter | Type           | Description             |
| --------- | -------------- | ----------------------- |
| source    | IEnumerable<T> | Collection              |
| body      | Action<T>      | Executes for every item |

✅Example:
List<string> names = new()
{
    "Kapil",
    "Rahul",
    "Amit",
    "John"
};
Parallel.ForEach(names, name =>
{
    Console.WriteLine(
        $"{name} Thread {Thread.CurrentThread.ManagedThreadId}");
});
Possible Output:
   Kapil Thread 4
   John Thread 6
   Rahul Thread 5
   Amit Thread 4



✅Example:
List<string> cities =
[
    "Delhi",
    "Mumbai",
    "Hyderabad",
    "Chennai"
];
Parallel.ForEach(cities, city =>
{
    Console.WriteLine($"{city} = {city.Length}");
});



✅🔥When Should You Use Parallel.For ?
✔ Large numeric loops
✔ Matrix multiplication
✔ Scientific calculations
✔ AI algorithms
✔ Image processing
✔ Video encoding


✅🔥When Should You Use Parallel.ForEach ?
✔ Collections
✔ Lists
✔ Arrays
✔ Dictionaries
✔ Files
✔ Images

✅🔥When NOT to Use
Avoid
❌ Small loops (parallel overhead may be higher than the work)
❌ Database operations
❌ HTTP requests
❌ File downloads
❌ Web API calls
These are I/O-bound operations and should use async/await.







