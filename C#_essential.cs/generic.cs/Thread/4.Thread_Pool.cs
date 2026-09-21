✅🔥 Thread vs ThreadPool in C#:
Thread and ThreadPool are both used to execute work concurrently, but they are designed for different purposes.

Thread gives you a dedicated thread that you control
while ThreadPool gives you a reusable pool of worker threads managed by the .NET runtime.



✅🔥 What Is ThreadPool ?
The ThreadPool is a collection of reusable threads managed by the .NET runtime that can execute queued work.

❌Instead of creating a new thread yourself every time:
Thread t = new Thread(DoWork);
t.Start();
you can submit work to the ThreadPool: ThreadPool.QueueUserWorkItem(DoWork);
The runtime takes care of selecting an available ThreadPool thread.

Example:
using System;
using System.Threading;
class Program
{
    static void DoWork(object? state) // ? state is allowed to contain null.
    {
        Console.WriteLine("Work is running");
    }
    static void Main()
    {
        ThreadPool.QueueUserWorkItem(DoWork);
        Thread.Sleep(500);
        Console.WriteLine("Main finished");
    }
}
/* 
void DoWork(object? state) // ? state is allowed to contain null.
Without ?:  void DoWork(object state), the nullable-reference-type analysis assumes that state should not be null.

With: object? state
the compiler knows:
state
 ├── can contain an object
 └── can contain null
*/


✅🔥 ThreadPool Queue:
The ThreadPool queue contains work items waiting to execute.
For example:
ThreadPool.QueueUserWorkItem(Work1);
ThreadPool.QueueUserWorkItem(Work2);
ThreadPool.QueueUserWorkItem(Work3);
ThreadPool.QueueUserWorkItem(Work4);



-----------------------------------------------------------

✅🔥 Why Do We Need ThreadPool? Because ThreadPool Reuses Threads


1. ✅Thread creation is extremely expensive.
Imagine your application receives 10,000 small tasks.
If you create a new thread for every task:
Task 1 → Thread 1
Task 2 → Thread 2
Task 3 → Thread 3
...
Task 10000 → Thread 10000
This can be extremely expensive.

The problem is that a thread is not just a small object created by C#.
Creating a thread involves the .NET runtime + operating system + memory + scheduler.

✅1. Every thread needs a stack to store information about its execution.
✅2. Thread t = new Thread(DoWork);
t.Start();
you're not simply creating a normal C# object.
Eventually, the runtime asks the operating system to create/manage a native execution thread.
For example, the OS needs to track things such as:
Thread
 ├── Thread identity
 ├── Execution state
 ├── Scheduling information
 ├── Stack
 ├── CPU context
 └── Other OS bookkeeping

✅3.Thread Must Be Registered With the Scheduler
The OS scheduler needs to know: "This thread exists and may need CPU time."
So a newly created thread becomes part of the system's scheduling machinery




✅2. Context Switching Becomes Expensive:
Suppose you have:
   CPU cores = 8
   Threads = 10,000
But A CPU core can execute one thread's instruction stream at a time (ignoring hardware SMT details for simplicity).
So the OS scheduler has to repeatedly decide:
Run Thread A
     ↓
Stop/Suspend A
     ↓
Run Thread B
     ↓
Stop/Suspend B
     ↓
Run Thread C
     ↓
...
This switching is called a context switch.



✅3. Every Thread Needs Stack Memory:
Each thread needs its own stack for things such as:
    Method calls
    Local variables
    Return addresses
    Execution state

























