✅🔥 What is a Race Condition ?
A race condition occurs in multithreaded programming when two or more threads access shared data simultaneously, 
 and the outcome of the program depends on the order in which the threads execute.
This unpredictability can lead to inconsistent or unintended results.
Example:
Imagine two threads incrementing a shared counter variable without any synchronization. 
Since both threads run concurrently without coordination, they may interrupt each other, leading to incorrect results.

using System;
using System.Threading;
class Program
{
    static int count = 0;
    static void Increment()
    {
        for (int i = 0; i < 100000; i++)
        {
            count++; // shared resource
        }
    }
    static void Main()
    {
        Thread t1 = new Thread(Increment);
        Thread t2 = new Thread(Increment);
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
        Console.WriteLine("Final Count = " + count);
    }
}
Expected Output:200000
But
Actual Output (random):
Final Count = 173421
or
Final Count = 198234
or
Final Count = 185000


✅Whats happening here?
counter is a shared resource.
Two threads (t1, t2) are incrementing it.
Without the mutex, both threads could try to update counter at the same time, causing incorrect results (like skipped increments).

count++ is NOT a single operation
It has 3 steps:
1. Read value from memory
2. Increment value
3. Write back to memory

If two threads execute this simultaneously:
Thread 1: reads 100
Thread 2: reads 100
Thread 1: writes 101
Thread 2: writes 101  ❌ (lost update)


==================================================================================================================

✅🔥 Synchronization:
Thread Synchronization is the mechanism used to control the access of a shared resource by multiple thtread 
so that only one thread (or a limited number of threads) can access it at a time, ensuring data consistency and preventing race conditions.


✅🔥 Synchronization Techniques to Prevent Race Conditions:
To prevent race conditions in multithreaded programs, synchronization mechanisms are used. 
These techniques ensure that only one thread accesses the critical section (shared data) at a time.
Without synchronization, race conditions, data corruption, or unexpected behavior could occur.
// A section of code where shared resources are accessed is called Critical Section.


✅🔥Types of Synchronization
1. Process-level
      Mutex
2. Thread-level
      lock
      Monitor
      Interlocked
3. Resource-level
      Semaphore
      ReaderWriterLockSlim

keep
===============================================================================================================

✅🔥 1. lock Keyword
🔒 What is lock in C#?
lock(obj)
{
    // critical section
}
Meaning: Only one thread at a time is allowed to execute this block.


✅🧱 What is lock object(synchronization object) ?
static object lockObj = new object();
Why needed ?
Because lock needs a shared reference object to synchronize threads.
✔ Same object = same lock
❌ Different objects = no synchronization

-------------------------------------------------------------
⚠️ Important Rules of lock:
1. Lock must use reference type
lock (new object()) ❌ WRONG
Because if every thread gets a new lock → no synchronization


2. Never lock on public objects
Bad practice:
lock(this) ❌
lock("string") ❌
lock(typeof(Program)) ❌
Why? Because external code may also lock them → deadlock risk


3. Always use private object
private static object lockObj = new object();


/*🧠 How lock works internally?
lock is internally based on: 👉 Monitor.Enter() and Monitor.Exit()

C# converts this:
lock(lockObj)
{
    count++;
}
into something like:
Monitor.Enter(lockObj);
try
{
    count++;
}
finally
{
    Monitor.Exit(lockObj);
}*/
Full code using Lock():
using System;
using System.Threading;
class Program
{
    static int count = 0;
    static object lockObj = new object();
    static void Increment()
    {
        for (int i = 0; i < 100000; i++)
        {
            lock (lockObj)
            {
                count++;
            }
        }
    }
    static void Main()
    {
        Thread t1 = new Thread(Increment);
        Thread t2 = new Thread(Increment);
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
        Console.WriteLine("Final Count = " + count);
    }
}
How lock works internally?
Thread 1 → enters lock → executes
Thread 2 → WAIT
Thread 1 → exits lock
Thread 2 → enters lock

Important points:
lock is monitor-based internally
only one thread allowed
ensures mutual exclusion

================================================================================================================


✅🔥 What is Monitor?
The Monitor class is a synchronization mechanism provided by .NET that ensures only one thread can execute a critical section at a time.
It belongs to: using System.Threading;
Namespace: System.Threading

Basic Syntax:
Monitor.Enter(lockObject);
try
{
    // Critical Section
}
finally
{
    Monitor.Exit(lockObject);
}



✅ Without Try Catch Block:
using System;
using System.Threading;
class Program
{
    static object lockObj = new object();
    static void Print()
    {
        Monitor.Enter(lockObj); // acquired the lock
        Console.WriteLine("Inside Critical Section");
        Monitor.Exit(lockObj); // released the lock
    }
    static void Main()
    {
        Thread t1 = new Thread(Print);
        Thread t2 = new Thread(Print);
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
    }
}
✅Problem:
Suppose after Monitor.Enter(lockObj) ,Exception is thrown , 
    resources(lock) will not released
    All threads wait forever. This causes a deadlock.
Therefore:
Always use Try, Catch block Even if an exception occurs,
finally always executes
↓
Monitor.Exit()
↓
Lock released


✅Complete Example:
using System;
using System.Threading;
class Program
{
    static int count = 0;
    static object lockObj = new object();
    static void Increment()
    {
        for (int i = 0; i < 100000; i++)
        {
            Monitor.Enter(lockObj);
            try
            {
                count++;
            }
            finally
            {
                Monitor.Exit(lockObj);
            }
        }
    }
    static void Main()
    {
        Thread t1 = new Thread(Increment);
        Thread t2 = new Thread(Increment);
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
        Console.WriteLine(count);
    }
}
-----------------------------------------------
✅🔥What is Monitor.TryEnter()?
TryEnter() attempts to acquire the lock.
If successful: Return true
If not: Return false
It does not block second thread indefinitely (unless you use the timeout overload).


Problem with lock and Monitor.Enter():
Suppose two threads are trying to acquire the same lock.

                lockObj
                   │
                   ▼
            Critical Section

Thread 1
    │
    ▼
Lock Acquired
    │
    ▼
Working...
    │
    ▼
Still Working...



Thread 2:
Arrives
↓
Cannot enter
↓
Wait
↓
Wait
↓
Wait
↓
Thread 2 waits indefinitely, Until Thread 1 releases the lock


Code:
using System;
using System.Threading;
class Program
{
    static object lockObj = new object();
    static void Main()
    {
        if (Monitor.TryEnter(lockObj))
        {
            try
            {
                Console.WriteLine("Lock Acquired");
            }
            finally
            {
                Monitor.Exit(lockObj);
            }
        }
        else
        {
            Console.WriteLine("Could not acquire lock");
        }
    }
}
------------------------------------------------------------------

✅🔥Monitor.Wait() :
Monitor.Wait() temporarily releases the lock, puts the current thread into the waiting state, and waits until another thread signals it using Monitor.Pulse() or Monitor.PulseAll().
Important Rule:
You must own the lock before calling Wait().
Correct:
lock(lockObj)
{
    Monitor.Wait(lockObj);
}

❌Wrong: Monitor.Wait(lockObj);
This throws SynchronizationLockException Because the current thread does not own the lock.


-------------------------------------------------
✅🔥 Why release the lock?
Imagine Thread A did NOT release the lock. And Producer wants to add data.
Producer
↓
Needs Lock
↓
Cannot Get Lock
↓
Blocked
Consumer is waiting.
Producer is blocked.
Nobody can continue.
Deadlock.
Therefore: Wait() automatically releases the lock.
-----------------------------------------------------

✅ Monitor.Pulse()
   Pulse() wakes one waiting thread.


✅ Monitor.PulseAll()
   Wakes all waiting threads.


Complete Example:
using System;
using System.Collections.Generic;
using System.Threading;
class Program
{
    static Queue<int> queue = new Queue<int>();
    static object lockObj = new object();
    static void Consumer()
    {
        lock(lockObj)
        {
            while(queue.Count == 0)
            {
                Console.WriteLine("Queue Empty. Consumer Waiting...");
                Monitor.Wait(lockObj);
            }
            int value = queue.Dequeue();
            Console.WriteLine($"Consumed {value}");
        }
    }
    static void Producer()
    {
        Thread.Sleep(2000);
        lock(lockObj)
        {
            queue.Enqueue(100);
            Console.WriteLine("Produced 100");
            Monitor.Pulse(lockObj);
        }
    }
    static void Main()
    {
        Thread consumer = new Thread(Consumer);
        Thread producer = new Thread(Producer);

        consumer.Start();
        producer.Start();

        consumer.Join();
        producer.Join();
    }
}










