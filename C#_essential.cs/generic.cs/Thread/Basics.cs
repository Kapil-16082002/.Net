Thread and Task difference ?

✅🔥 A thread is a smallest (lightweight) unit of execution inside a process.
Multiple threads can run concurrently within a single process and share memory (like global variables or heap memory). 
This makes threading fast but also risky due to race conditions.
🔹 Thread Example:
Suppose there is one employee in the office:
That employee is doing multiple tasks at the same time:

1.Writing a report 📝
2.Responding to emails 📧
3.Attending a call 📞
Each of these tasks is a THREAD.



✅🔥 Multithreading in C++ refers to the ability of a program to execute multiple threads concurrently.
| Term            | Meaning                                               |
| --------------- | ----------------------------------------------------- |
| **Concurrency** | Tasks are in progress at the same time (interleaving) |
| **Parallelism** | Tasks run at the exact same time on multiple cores    |



✅🔥Process:  A process is an independent program in execution.
Multiple processes can run concurrently on a system, but they generally operate independently of one another.
Key Features of a Process:
1.Independent Memory Space: Each process has its own separate memory space (address space).
2.Inter-process Communication (IPC):
Since processes run in separate memory spaces, they must communicate via mechanisms such as pipes, sockets, shared memory, or message queues.



✅🔥 1. Synchronous Programming
In synchronous programming, tasks are executed sequentially, one after the other.
The program waits for a task to finish before moving on to the next.
If a task takes a long time (e.g., a file download or database query), the thread executing it is blocked, stopping the programs progression until the task is complete.

✅🔥2. Asynchronous Programming
In asynchronous programming, tasks can be executed concurrently or in parallel, depending on the system, without waiting for each task to finish before starting the next one. 
When a task is initiated (e.g., downloading a file), it runs in the background, and the program can proceed without being blocked.



---------------------------------------------------------------------

✅🔥Foreground vs Background Threads
✅ Foreground Thread:
    Keeps the application alive.
    The process does not exit until all foreground threads finish.
Example:
Thread thread = new Thread(Print);
thread.IsBackground = false;// (Default for Thread.)

✅Background Thread:
    Does not keep the application alive.
    Ends automatically when all foreground threads finish.
Example:
Thread thread = new Thread(Print);
thread.IsBackground = true;

--------------------------------------------------------------------

| Process                      | Thread                          |
| ---------------------------- | ------------------------------- |
| Independent program          | Execution path within a process |
| Own memory                   | Shares process memory           |
| Heavyweight                  | Lightweight                     |
| Expensive creation           | Faster creation                 |
| Contains one or more threads | Cannot exist without a process  |


| Thread                           | Task                                                           |
| -------------------------------- | -------------------------------------------------------------- |
| Represents an OS thread          | Represents an asynchronous unit of work                        |
| Expensive to create              | Lightweight abstraction                                        |
| Manual management                | Managed by the Task Scheduler                                  |
| Less flexible                    | Supports continuations, cancellation, composition, async/await |
| Suitable for low-level threading | Recommended for most modern applications                       |


==================================================================================================================
✅🔥 Why Do We Need Threads?
Suppose you have:
Download File
↓
Read Database
↓
Generate PDF
↓
Send Email


✅ Without threads: Everything executes one after another. Total time taken will be large
Download
↓
Database
↓
PDF
↓
Email


✅ Using multiple threads:
Download
Database
PDF
Email
They can run concurrently (depending on CPU cores and scheduling).

================================================================================================================

✅🔥 Creating a Thread
Basic Syntax:
Thread t = new Thread(MethodName);
t.Start();

✅ Explanation:
Thread t → t is a variable that stores Thread object reference.
new Thread(Print) → Creates a Thread object in memory and stores the method(print) that should run on that thread.
Start() → starts execution on a new thread
Both threads run concurrently


Internally, Thread Start() is designed like this:
public void Start()  // No parameter
or
public void Start(object parameter)// Only one parameter(object) can be passed.




✅🔥 Thread Lifecycle (VERY IMPORTANT FOR INTERVIEWS)

You should understand states:
New → Ready → Running → Waiting → Terminated

Key methods:
Start()
Sleep()
Join()
Abort() ❌ (obsolete, avoid)
--------------------------------------------------------
Basic Example:

using System;
using System.Threading
class Program
{
    static void Print()
    {
        Console.WriteLine("Worker Thread");
    }
    static void Main()
    {
        Thread thread = new Thread(Print);
        thread.Start();
        Console.WriteLine("Main Thread");
    }
}
Output:
Main Thread
Worker Thread
or
Worker Thread
Main Thread
Execution order is not deterministic.

---------------------------------------------------------

✅🔥 Creating a Thread using ThreadStart Delegate
Syntax:
public delegate void ThreadStart();// ThreadStart is a built-in delegate defined in System.Threading.
Key Point:
It points to a method that takes no parameters
Returns void
Used by Thread class to execute code in a new thread


✅ When you write: Thread t = new Thread(MyMethod);
Internally, it is:
      ThreadStart ts = new ThreadStart(MyMethod);
      Thread t = new Thread(ts);


using System;
using System.Threading;
class Program
{
    static void Print()
    {
        Console.WriteLine("Child Thread is running");
    }
    static void Main()
    {
        // Step 1: Create delegate
        ThreadStart ts = new ThreadStart(Print);

        // Step 2: Create thread
        Thread t = new Thread(ts);
        Console.WriteLine("Main Thread started");

        // Step 3: Start thread
        t.Start();
        Console.WriteLine("Main Thread finished work");
    }
}
---------------------------------------------------------
✅🔥ParameterizedThreadStart:
using System;
using System.Threading;
class Program
{
    static void Print(object value)
    {
        Console.WriteLine(value);
    }
    static void Main()
    {
        Thread thread = new Thread(Print);
        thread.Start(100);
    }
}
Drawback: The parameter type is object. You need casting. It is not type-safe.
static void Print(object value)
{
    int number = (int)value; // casting
}
-----------------------------------------------------------------------------

✅🔥 Using an Anonymous Method
using System;
using System.Threading;
class Program
{
    static void Main()
    {
        Thread thread =
            new Thread(delegate ()
            {
                Console.WriteLine("Anonymous Thread");
            });
        thread.Start();
    }
}
-----------------------------------------------------------------------------

✅🔥 Using a Lambda Expression
using System;
using System.Threading;
class Program
{
    static void Main()
    {
        Thread thread =
            new Thread(() =>
            {
                Console.WriteLine("Lambda Thread");
            });
        thread.Start();
    }
}

-------------------------------------------------------

✅🔥Using Task (Recommended in Modern .NET)
The Task Parallel Library (TPL) is the preferred API for most concurrent work.

using System;
using System.Threading.Tasks;
class Program
{
    static void Main()
    {
        Task task = new Task(() =>
        {
            Console.WriteLine("Task Running");
        });
        task.Start();
        task.Wait();
    }
}
--------------------------------------------------------------
✅🔥 Using Task.Run()
using System;
using System.Threading.Tasks;
class Program
{
    static void Main()
    {
        Task.Run(() =>
        {
            Console.WriteLine("Running...");
        });
        Console.ReadLine();
    }
}




























