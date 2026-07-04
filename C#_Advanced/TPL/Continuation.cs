✅🔥What is a Task Continuation?
A Task Continuation is a task that is scheduled to execute automatically after another task completes.
A continuation allows one task to automatically start after another task completes.



✅Real-Life Analogy: Imagine making tea.
Step 1: Boil Water
↓
Step 2: Add Tea Powder
↓
Step 3: Add Milk
↓
Step 4: Serve

You cannot add tea powder before the water boils.
Each step depends on the previous one. This is exactly how Task Continuations work.

----------------------------------------------------------------

✅ Why do we need Task Continuations?
✅Without continuations:
Task task = Task.Run(() =>
{
    Console.WriteLine("Downloading file...");
});
task.Wait();
Console.WriteLine("Processing file...");
Problems:
    Blocks the current thread.
    Reduces responsiveness.
    Hard to build long asynchronous workflows.


✅With continuations:
Task.Run(() =>
{
    Console.WriteLine("Downloading file...");
})
.ContinueWith(t =>
{
    Console.WriteLine("Processing file...");
});
The next task is automatically scheduled after the first one finishes.


===============================================================================================================

✅🔥 ContinueWith();
ContinueWith() creates a new task that starts automatically after the current task completes.
The original task is called the antecedent task.
The newly created task is called the continuation task.

Return Type: returns another Task (or Task<TResult>).
This allows multiple continuations to be chained.

Syntax:
Task ContinueWith(
    Action<Task> continuationAction
)
OR
Task<TResult> ContinueWith<TResult>(
    Func<Task, TResult> continuationFunction
)

Example:
using System;
using System.Threading;
using System.Threading.Tasks;
class Program
{
    static void Main()
    {
        Task task = Task.Run(() =>
        {
            Console.WriteLine("Downloading file...");
            Thread.Sleep(2000);
            Console.WriteLine("Download completed.");
        });
        Task continuation = task.ContinueWith(t =>
        {
            Console.WriteLine("Processing downloaded file...");
        });
        continuation.Wait();
    }
}
Task 1:
Downloading File
↓
Completed
↓
ContinueWith()
↓
Task 2
Process File

------------------------------------------------------

✅🔥 ContinueWith() with Task<TResult>
The continuation can access the previous task's result.
using System;
using System.Threading.Tasks;
class Program
{
    static void Main()
    {
        Task<int> task = Task.Run(() =>
        {
            return 100;
        });
        Task continuation = task.ContinueWith(t =>
        {
            Console.WriteLine($"Result = {t.Result}");
        });

        continuation.Wait();
    }
}
Output: Result = 100

---------------------------------------------------------

✅🔥 Why use ContinueWith instead of Wait()?
Using Wait():
    task.Wait();
    Process();
The current thread is blocked until the task completes.

Using ContinueWith():
       task.ContinueWith(t =>
       {
            Process();
       });
The continuation is scheduled to run after the task finishes, without explicitly blocking the current thread to wait for completion.


==================================================================================================================

✅🔥 Common Continuation Options:

| Option                | Meaning                                                 |
| --------------------- | ------------------------------------------------------- |
| None                  | Always execute                                          |
| OnlyOnRanToCompletion | Run only if the previous task succeeded                 |
| OnlyOnFaulted         | Run only if the previous task threw an exception        |
| OnlyOnCanceled        | Run only if the task was canceled                       |
| NotOnFaulted          | Skip if the previous task failed                        |
| NotOnCanceled         | Skip if the previous task was canceled                  |
| ExecuteSynchronously  | Allow the continuation to execute inline if appropriate |


✅🔥 Example – OnlyOnRanToCompletion
Task<int> task = Task.Run(() =>
{
    return 50;
});
task.ContinueWith(t =>
{
    Console.WriteLine($"Value = {t.Result}");
},
TaskContinuationOptions.OnlyOnRanToCompletion
);
Console.ReadLine();
Output: Value = 50


---------------------------------------------------------------------------

✅🔥 If the first task throws an exception, the continuation will not execute.
Example – OnlyOnFaulted
Task task = Task.Run(() =>
{
    throw new Exception("Something went wrong.");
});

task.ContinueWith(t =>
{
    Console.WriteLine("Error handled.");
    Console.WriteLine(t.Exception?.InnerException?.Message);
},
TaskContinuationOptions.OnlyOnFaulted
);
Console.ReadLine();

Output:
Error handled.
Something went wrong.
---------------------------------------------------------------


✅🔥Example – NotOnFaulted
Task task = Task.Run(() =>
{
    Console.WriteLine("Task completed successfully.");
});
task.ContinueWith(t =>
{
    Console.WriteLine("Continuation executed.");
},
TaskContinuationOptions.NotOnFaulted
);
Console.ReadLine();
// The continuation runs because the task did not fail.

---------------------------------------------------------------

✅🔥 ContinueWhenAll()
ContinueWhenAll() creates a continuation task that executes only after all specified tasks have completed 
, (whether they completed successfully, faulted, or were canceled).

Syntax:
Task.Factory.ContinueWhenAll(
    Task[] tasks,
    Action<Task[]> continuation
);


✅ Why do we need it?
Suppose you download:
    Image
    Audio
    Video
Processing should begin only after all downloads finish.
Without ContinueWhenAll():
task1.Wait();
task2.Wait();
task3.Wait();
Console.WriteLine("All completed.");
This blocks the calling thread.


✅ With ContinueWhenAll():=
Task.Factory.ContinueWhenAll(tasks, completedTasks =>
{
    Console.WriteLine("All tasks completed.");
});

Example:
using System;
using System.Threading;
using System.Threading.Tasks;
class Program
{
    static void Main()
    {
        Task t1 = Task.Run(() =>
        {
            Thread.Sleep(1000);
            Console.WriteLine("Task 1 completed.");
        });
        Task t2 = Task.Run(() =>
        {
            Thread.Sleep(2000);
            Console.WriteLine("Task 2 completed.");
        });
        Task t3 = Task.Run(() =>
        {
            Thread.Sleep(1500);
            Console.WriteLine("Task 3 completed.");
        });
        Task all = Task.Factory.ContinueWhenAll(
            new[] { t1, t2, t3 },
            tasks =>
            {
                Console.WriteLine("All tasks finished.");
            });
        all.Wait();
    }
}
Output (completion order may vary)
Task 1 completed.
Task 3 completed.
Task 2 completed.
All tasks finished.

Execution Flow:
Task1 ──┐
         │
Task2 ──┼────► ContinueWhenAll()
         │
Task3 ──┘
The continuation starts only after every task has completed

===============================================================================================================

✅🔥ContinueWhenAny():
ContinueWhenAny() creates a continuation task that starts as soon as any one of the specified tasks completes.
Syntax:
Task.Factory.ContinueWhenAny(
    Task[] tasks,
    Action<Task> continuation
);
Why do we need it?
Suppose:
Three servers contain the same data.
Whichever server responds first should be used.
There is no need to wait for the remaining servers.

Example:
using System;
using System.Threading;
using System.Threading.Tasks;
class Program
{
    static void Main()
    {
        Task t1 = Task.Run(() =>
        {
            Thread.Sleep(3000);
            Console.WriteLine("Task 1 finished.");
        });
        Task t2 = Task.Run(() =>
        {
            Thread.Sleep(1000);
            Console.WriteLine("Task 2 finished.");
        });
        Task t3 = Task.Run(() =>
        {
            Thread.Sleep(2000);
            Console.WriteLine("Task 3 finished.");
        });
        Task any = Task.Factory.ContinueWhenAny(
            new[] { t1, t2, t3 },
            completedTask =>
            {
                Console.WriteLine("First completed task triggered the continuation.");
            });
        any.Wait();
    }
}
Output:
Task 2 finished.
First completed task triggered the continuation.
Task 1 and Task 3 continue running unless you cancel them explicitly.



| Feature              | ContinueWhenAll()                      | ContinueWhenAny()      |
| -------------------- | -------------------------------------- | ---------------------- |
| Starts after         | All tasks complete                     | First task completes   |
| Waits for every task | Yes                                    | No                     |
| Receives             | `Task[]`                               | `Task`                 |
| Typical use          | Combine results after all work is done | Use the fastest result |


















