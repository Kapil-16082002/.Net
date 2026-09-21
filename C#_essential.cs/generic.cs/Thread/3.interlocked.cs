
✅🔥Interlocked Class:
The Interlocked class provides atomic(indivisible) operations on shared variables.
That means no two threads can interfere with each other during a read-modify-write operation.

✅Namespace: using System.Threading;
It ensures that reads and writes to a variable are atomic — i.e., they happen completely or not at all.

✅Usage:
Interlocked is especially useful when multiple threads need to perform operations such as incrementing, decrementing, adding, exchanging, or comparing-and-exchanging a shared value.


✅🔥 Why Do We Need Interlocked ?
Consider this code:
int counter = 0;
counter++; // counter = counter + 1
It looks like one operation, but internally it is approximately:

1. Read counter
2. Add 1
3. Write counter
So: counter++ is actually a read-modify-write operation.
When multiple threads execute it simultaneously, a race condition can occur.

✅🔥 Solution:
Using Interlocked.Increment()
Instead of: counter++;
we can use: Interlocked.Increment(ref counter);

Now the increment is performed atomically.

Thread 1 ──► Increment ──► 1
Thread 2 ──► Increment ──► 2
The operation cannot be interrupted by another thread in the middle of its read-modify-write process.



✅🔥 Why was Interlocked introduced : To overcome the Race Condition problem
Full code:
using System;
using System.Threading;
class Program
{
    static int count = 0;
    static void Increment_method()
    {
        for (int i = 0; i < 100000; i++)
        {
            Interlocked.Increment(ref count);
        }
    }
    static void Main()
    {
        Thread t1 = new Thread(Increment_method);
        Thread t2 = new Thread(Increment_method);
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
        Console.WriteLine("Final Count = " + count);
    }
}
Interlocked methods ?
1. Interlocked.Increment()   // Increments a variable atomically.
2. Interlocked.Decrement()   // Decrements a variable atomically.
3. Interlocked.Add()         // Adds a value atomically. Interlocked.Add(ref counter, value);

4. Interlocked.Read()       // Interlocked.Read() can atomically read a long value only. Interlocked.Read(ref value);
// This is extremely useful when multiple threads need to replace a shared value safely.
//Important: Exchange() Returns the Old Value
int number = 10;
int oldValue = Interlocked.Exchange(ref number, 50);
Console.WriteLine("Old value = " + oldValue);
Console.WriteLine("New value = " + number);

Why is Interlocked so fast?
Why doesn't Interlocked require lock?