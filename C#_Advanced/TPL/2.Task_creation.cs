✅🔥 What is Task?
A Task in C# is an object that represents an asynchronous unit of work that can run independently, usually on a ThreadPool thread, and may or may not return a result.
Namespace: using System.Threading.Tasks;

✔ Simple Meaning:
A Task is: “A work item that runs in the background and completes later.”
Example:
Task task = Task.Run(() =>
{
    Console.WriteLine("Task is running on thread: " + Thread.CurrentThread.ManagedThreadId);
});
🧠 Simple Analogy
Thread = Worker 👷
A real person doing work physically.

Task = Job Ticket 🧾
A work request given to the system.

=======================================================================

✅🔥 Task Lifecycle:
A Task moves through different phases from creation to completion.
✔ Lifecycle Flow
Created → WaitingToRun → Running → RanToCompletion / Faulted / Canceled


✅✔ Explanation of each stage:
1. Created
Task is defined but not started.
Task task = new Task(() => Console.WriteLine("Hello"));

2. WaitingToRun
Task is scheduled but waiting for ThreadPool thread.

3. Running
Task is actively executing.

4. Completed States
| State           | Meaning               |
| --------------- | --------------------- |
| RanToCompletion | Successfully finished |
| Faulted         | Exception occurred    |
| Canceled        | Task was cancelled    |

==========================================================


✅🔥 Task States:
Task state is an enum represents the current status of a task execution.
✔ Interview insight: Most tasks never stay in "Created" because Task.Run() starts immediately.
📌 TaskStatus Enum (TPL States)
| Syntax                                    | Definition                             | Simple Meaning                                 |
| ----------------------------------------- | -------------------------------------- | ---------------------------------------------- |
| `TaskStatus.Created`                      | Task is created but not scheduled yet. | Task object exists, but not started or queued. |
| `TaskStatus.WaitingForActivation`         | Task is waiting for external trigger.  | Common in async/await before execution starts. |
| `TaskStatus.WaitingToRun`                 | Task is queued to run.                 | Waiting for a ThreadPool thread.               |
| `TaskStatus.Running`                      | Task is currently executing.           | Worker thread is running the task.             |
| `TaskStatus.WaitingForChildrenToComplete` | Parent task waiting for child tasks.   | Used in nested/attached tasks.                 |
| `TaskStatus.RanToCompletion`              | Task finished successfully.            | No errors, execution completed.                |
| `TaskStatus.Canceled`                     | Task was canceled before completion.   | Stopped using cancellation token.              |
| `TaskStatus.Faulted`                      | Task ended due to exception.           | Task failed because of error.                  |


✅ Task IDs:
Each Task gets a unique integer ID assigned by TPL.

Task task1 = Task.Run(() => Console.WriteLine("Task 1"));
Task task2 = Task.Run(() => Console.WriteLine("Task 2"));
Console.WriteLine(task1.Id);
Console.WriteLine(task2.Id);
✔ Use Case:
     Debugging
     Logging
     Tracking execution flow



✅ Task.AsyncState
Stores user-defined state object passed during task creation.
Syntax (Task constructor only):
Task task = new Task(() =>
{
    Console.WriteLine("Task executing...");
}, "My Custom State");
Console.WriteLine(task.AsyncState); // Access state
Output: My Custom State
=========================================================

✅🔥 Creating Tasks
1. Task Constructor
2. Task.Start()
3. Task.Run()
4. Task.Factory.StartNew()
5. Parallel.Invoke()



✅1. Task Constructor: Manually create a task object (NOT started automatically).
Task task = new Task(() =>
{
    Console.WriteLine("Using Task Constructor");
});
task.Start(); // mandatory

✔ Key Point:You MUST call .Start() manually.

--------------------------------------------------

✅2. Task.Start()
Used with Task constructor.

Task task = new Task(() =>
{
    Console.WriteLine("Started manually");
});
task.Start();

✔ Problem:
Easy to forget .Start() → task never runs ❌

----------------------------------------------------

✅3. Task.Run() (MOST IMPORTANT)
ask.Run is the modern recommended way to create and executes task immediately on ThreadPool.
Task task = Task.Run(() =>
{
    Console.WriteLine("Task.Run executed");
});
✔ Why it is preferred?
    Automatic start
    Uses ThreadPool
    Cleaner code
    Best for CPU-bound work
-----------------------------------------------------

✅4.Task.Factory.StartNew()
Advanced and configurable task creation API.

✔ Example
Task task = Task.Factory.StartNew(() =>
{
    Console.WriteLine("Factory Task");
});
------------------------------------------------------

✅5. Parallel.Invoke()
Runs multiple actions in parallel.
Parallel.Invoke(
    () => Console.WriteLine("Task 1"),
    () => Console.WriteLine("Task 2"),
    () => Console.WriteLine("Task 3")
);
Behavior:
Runs multiple delegates in parallel
Blocks main thread until completion
==========================================================================

✅🔥 Returning Values from Tasks:
Task<TResult>:
A Task<TResult> is a Task that returns a value of type TResult after completion.
It represents an asynchronous operation that produces a result.

/*Difference between Task and Task<TResult>?
👉 Task → no return value
👉 Task<TResult> → returns result */
Syntax:
   Task<int>
   Task<string>
   Task<Employee>
   Task<List<int>>
Example:
Task<int> task = Task.Run(() =>
{
    return 10 + 20;
});
int result = task.Result;  // Getting Result
Console.WriteLine(result);
⚠ Important: task.Result BLOCKS the main thread. If task is not completed → it waits.

















