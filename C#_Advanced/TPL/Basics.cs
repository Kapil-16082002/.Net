✅🔥 What is TPL?
TPL (Task Parallel Library) is a library introduced in .NET Framework 4.0 that simplifies writing parallel and asynchronous programs.
It provides a high-level abstraction over threads.
Instead of creating and managing threads manually, developers create Tasks, and TPL manages the execution.


✅ Without TPL:
Developer
    ↓
Create Thread
Start Thread
Manage Thread
Join Thread
Handle Exceptions
Destroy Thread
    ↓
Lots of work


✅ With TPL
Developer
↓
Create Task
↓
TPL handles everything
↓
ThreadPool
↓
OS Threads
So you work with Tasks, not Threads.

-------------------------------------------------

✅🔥Real-world Example:
Suppose you're downloading:
File A
File B
File C
Without TPL:
Thread1 → Download A
Thread2 → Download B
Thread3 → Download C
You must manage all threads.


With TPL:
Task A
Task B
Task C
↓
TPL schedules them
↓
ThreadPool Threads



✅🔥Namespaces in TPL
Most commonly used namespace:
1. using System.Threading.Tasks;
Contains
   Task
   Task<T>
   Parallel
   ParallelLoopState
   TaskFactory
   TaskScheduler

2. using System.Threading;
Contains
   Thread
   ThreadPool
   CancellationToken
   Monitor
   Mutex
  SemaphoreSlim
3. using System.Collections.Concurrent;
Contains
   ConcurrentDictionary
   ConcurrentQueue
   ConcurrentStack
   BlockingCollection


------------------------------------------------------------

| Feature            | Thread           | Task                   |
| ------------------ | ---------------- | ---------------------- |
| Represents         | Execution thread | Unit of work           |
| Namespace          | System.Threading | System.Threading.Tasks |
| Lightweight        | ❌                | ✔                      |
| Uses ThreadPool    | ❌                | ✔ Usually              |
| Return Value       | ❌                | ✔ Task<T>              |
| Continuation       | ❌                | ✔                      |
| Exception Handling | Hard             | Easy                   |
| Cancellation       | Manual           | Built-in               |
| Recommended        | Rarely           | Yes                    |

===============================================================================================================

✅🔥 Why Need of TPL?
Suppose your application performs:
   Image Processing
   Database Query
   File Reading
   API Calls
   PDF Generation
✅ Without TPL:
Everything executes one after another.
Read File
↓
Generate PDF
↓
Compress File
↓
Upload File
Total time taken will be the sum of time taken by each task to completion.

✅ With TPL:
Independent operations execute simultaneously.
Read File      Generate PDF
↓
Compress
↓
Upload
↓
Parallel Execution
Total time taken will be Max of time taken by each task to completion.

===============================================================================================================

✅🔥 Evolution of Parallel Programming in .NET
Stage 1 — Thread Class
Problems:
   Expensive
   Manual management
   Difficult synchronization
   Poor scalability

Stage 2 — ThreadPool
Problems:
   No return value
   No continuation
   Difficult error handling

Stage 3 — Task Parallel Library (.NET 4)
Tasks solved:
  ✔ Return values
  ✔ Waiting
  ✔ Continuations
  ✔ Exception handling
  ✔ Cancellation
  ✔ Parallel loops

Stage 4 — async/await (.NET 4.5)
Now asynchronous programming became much easier.

===============================================================================================================

✅🔥 TPL (Task Parallel Library) Architecture
Every time you write:
Task.Run(() =>
{
    Console.WriteLine("Hello");
});
Many things run together behind the scenes to execute your code efficiently.
The architecture looks like this:
                Your Code
                     │
                     ▼
              Task.Run(...)
                     │
                     ▼
               Task Object
                     │
                     ▼
             Task Scheduler
                     │
                     ▼
               ThreadPool
                     │
                     ▼
              Worker Thread
                     │
                     ▼
               CPU Executes
✅Stage 1:
Task.Run(() =>
{
    Console.WriteLine("Hello");
});
What happens here?
Your application only creates a Task request. It does not create a thread.


✅Stage 2:Task.Run()
This is the entry point into TPL.
Task.Run(() =>
{
    Console.WriteLine("Hello");
});
Internally, Task.Run():
  Creates a Task object.
   Stores your delegate (lambda).
   Queues it to the Task Scheduler.


✅Stage 3:Task Object
Task object represents work that should execute sometime in the future.
Example:
Task task = Task.Run(() =>
{
    Console.WriteLine("Running...");
});
The task object contains information such as:
   What code to execute
   Current status
   Exceptions (if any)
   Result (for Task<T>)
   Continuations
   Cancellation information


✅Stage 4: Task Scheduler
This is the brain of TPL.
The scheduler decides:
    Which thread should execute the task?
    When should it execute?
    Should it execute immediately?
    Is a ThreadPool thread available?


==================================================================================================================

✅🔥 Benefits of TPL (Task Parallel Library):
✅ 1. Better Performance 🚀
TPL can execute multiple tasks simultaneously by utilizing multiple CPU cores, reducing the total execution time for CPU-intensive work.
Core 1 → Task A
Core 2 → Task B
Core 3 → Task C


✅ 2. Automatic Thread Management ⚙️
You don't need to manually create, start, or manage threads.
Simply write: Task.Run(SomeMethod);
TPL automatically:
     Creates the task
     Chooses a thread
     Executes the task
     Cleans up resources


✅ 3. Thread Reuse 🔄
TPL uses the ThreadPool, which maintains reusable worker threads.
Instead of:
Create Thread -> Execute Work -> Destroy Thread
It does:
Reuse Existing Thread -> Execute Work -> Return Thread to Pool


✅ 4. Easy Exception Handling ⚠️
Exceptions thrown inside tasks can be caught using try-catch with AggregateException.
try
{
    Task.Run(() =>
    {
        throw new Exception("Something went wrong!");
    }).Wait();
}
catch (AggregateException ex)
{
    Console.WriteLine(ex.InnerException?.Message);
}


✅ 5. Continuations ⏭️
You can automatically execute another task after the first task completes using ContinueWith().
Task.Run(() =>
{
    Console.WriteLine("First");
})
.ContinueWith(t =>
{
    Console.WriteLine("Second");
});


✅ 6.Cancellation Support 🛑
TPL allows tasks to be cancelled gracefully using CancellationToken.
CancellationTokenSource cts = new();
Task.Run(() =>
{
    while (!cts.Token.IsCancellationRequested)
    {
        Console.WriteLine("Running...");
    }
    Console.WriteLine("Task Cancelled");
}, cts.Token);
Thread.Sleep(1000);
cts.Cancel();











































