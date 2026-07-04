✅🔥Asynchronous Programming?
Asynchronous Programming is a programming model in which a method starts an operation and does not block the calling thread while waiting for the operation to complete.
Instead of waiting, the calling thread is free to perform other work. When the operation finishes, execution resumes.


✅🔥 In asynchronous programming, tasks can be executed concurrently or in parallel, depending on the system, without waiting for each task to finish before starting the next one. 
When a task is initiated (e.g., downloading a file), it runs in the background, and the program can proceed without being blocked.



-------------------------------------------------------------

✅🔥 TPL and Async
TPL provides:
Task
Task<T>
↓
Foundation of Async/Await
Every async method returns a Task or Task<T> (or ValueTask in some scenarios).


✅🔥 1. Task-based Asynchronous Pattern (TAP)
The Task-based Asynchronous Pattern (TAP) is the recommended asynchronous programming model in modern .NET.

In TAP:
Asynchronous operations return Task or Task<T>
Completion, exceptions, and cancellation are represented by the Task
async and await work with these tasks

Return Types:
1.No Result,  Task
Example:
public async Task SaveFileAsync()
{
}
2. Returns a Result: Task<T>
Example:
public async Task<int> CalculateAsync()
{
    return 100;
}


✅🔥 Example:
using System;
using System.Threading.Tasks;
class Program
{
    static async Task DownloadAsync()
    {
        Console.WriteLine("Downloading...");
        await Task.Delay(3000);
        Console.WriteLine("Download Complete");
    }
    static async Task Main()
    {
        Console.WriteLine("Start");
        await DownloadAsync();
        Console.WriteLine("End");
    }
}
| Type      | Purpose                                                                |
| --------- | ---------------------------------------------------------------------- |
| `Task`    | Represents an asynchronous operation that does not produce a result    |
| `Task<T>` | Represents an asynchronous operation that produces a value of type `T` |

static async Task<int> AddAsync()
{
    await Task.Delay(1000);
    return 20 + 30;
}
int result = await AddAsync();
Console.WriteLine(result);

---------------------------------------------------------------------------
✅🔥 async Keyword
The async keyword tells the compiler that a method contains one or more await expressions and should be transformed into an asynchronous method.
async does not create a new thread. It simply enables the use of await inside the method.

Syntax:
async Task Method()
{
}
✅ What does async do?
When the compiler sees
async Task DownloadAsync()
{
    await Task.Delay(3000);
}
it transforms the method into a state machine.



✅ Does async make code asynchronous? No.
Consider:
static async Task DemoAsync()
{
    Console.WriteLine("Hello");
}
No await exists.
The compiler issues a warning because the method executes synchronously.


---------------------------------------------------------------------------------

✅🔥 await Keyword:
The await keyword pauses an asynchronous method until the awaited Task completes without blocking the current thread.
This is the key difference from Wait() or Result, which block.
Example:
using System;
using System.Threading.Tasks;
class Program
{
    static async Task Main()
    {
        Console.WriteLine("Before");
        await Task.Delay(3000);
        Console.WriteLine("After");
    }
}

✅Example with Task<T>
static async Task<int> SquareAsync(int number)
{
    await Task.Delay(1000);
    return number * number;
}
static async Task Main()
{
    int result = await SquareAsync(5);
    Console.WriteLine(result);
}
-----------------------------------------------------------------------------------

✅🔥 Async State Machine
When the compiler encounters an async method, it automatically generates a hidden state machine.
This state machine:
   Tracks execution progress
   Saves local variables
   Remembers where execution paused
   Resumes execution after the awaited task completes
You never write this state machine yourself.


✅Why is it needed?
Without a state machine:
   Local variables would be lost
   Execution location would be forgotten
   Resuming would not be possible
The compiler handles all of this automatically.











