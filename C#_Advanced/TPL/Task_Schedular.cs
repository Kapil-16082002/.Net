✅🔥 What is Task Scheduling?
Task Scheduling is the process of deciding:
   Which thread will execute a task
   When the task should execute
   In what order tasks should execute
   On which scheduler the task should run

✅🔥 Real-Life Example
Suppose you work in a company.

Employees = Threads
Manager = TaskScheduler
Work = Tasks

Employee 1
Employee 2
Employee 3
        ↑
      Manager
(Task Scheduler)
Receives Tasks
↓
Assigns work to employees
The scheduler acts exactly like a manager.

-------------------------------------------------------
✅🔥 Why do we need Task Scheduling?

Imagine creating 500 Tasks.
for(int i=0;i<500;i++)
{
    Task.Run(() =>
    {
        Console.WriteLine("Working");
    });
}
Should .NET create 500 threads? No.
That would consume huge memory and cause context switching.
Instead,
500 Tasks
↓
Task Scheduler
↓
Uses Thread Pool
↓
10–20 Worker Threads
↓
Executes all tasks efficiently. This is why TaskScheduler exists.

------------------------------------------------------------------

✅🔥 Execution Flow
Task.Run()
↓
Creates Task object
↓
Passes Task
↓
TaskScheduler
↓
Chooses Worker Thread
↓
ThreadPool Thread
↓
Task Starts
==================================================================================================================

✅🔥 TaskScheduler Class
TaskScheduler is an abstract class responsible for scheduling and executing Tasks.
Namespace: using System.Threading.Tasks;
Declaration: public abstract class TaskScheduler
Since it is abstract, you can not write: TaskScheduler scheduler = new TaskScheduler();// ❌ Invalid

.NET provides implementations like:
   TaskScheduler.Default
   TaskScheduler.FromCurrentSynchronizationContext()
   Custom Scheduler

✅ Important Members
✅1. Default: Returns default scheduler.
     TaskScheduler.Default

✅2. Current: Returns currently executing scheduler.
     TaskScheduler.Current

✅3. FromCurrentSynchronizationContext()
     Creates scheduler using UI thread.

✅4. TaskScheduler.FromCurrentSynchronizationContext()
    Mostly used in:
         WinForms
         WPF
✅5. QueueTask(): Used in custom scheduler.
     protected abstract void QueueTask(Task task);

✅6. TryExecuteTask(): Executes task manually.
      protected bool TryExecuteTask(Task task);

✅ 7. GetScheduledTasks() Returns queued tasks.
       protected abstract IEnumerable<Task> GetScheduledTasks();

Example:
Console.WriteLine(TaskScheduler.Current);
Console.WriteLine(TaskScheduler.Default);
Output:
System.Threading.Tasks.ThreadPoolTaskScheduler
System.Threading.Tasks.ThreadPoolTaskScheduler
=============================================================================================================


✅🔥Default TaskScheduler:
The Default TaskScheduler is the scheduler provided by .NET that executes Tasks using the Thread Pool.

Whenever you write: Task.Run(...) or Task.Factory.StartNew(...) ,without specifying a scheduler,the Default Scheduler is used.

Example:
Task task = Task.Run(() =>
{
    Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");
});
task.Wait();

============================================================================================================

✅🔥Current Scheduler:
TaskScheduler.Current returns the scheduler associated with the currently executing Task.
   It depends on where your code is running.
   If the code is not inside a Task, Current is usually the default scheduler.
   If the code is inside a Task created on a custom scheduler, Current refers to that custom scheduler.

===========================================================================================================

✅🔥Custom TaskScheduler
A Custom TaskScheduler allows you to define how Tasks are queued and executed instead of relying on the default Thread Pool scheduler.
You might create one to:
   Limit concurrency (e.g., only 2 tasks at a time)
   Enforce FIFO/LIFO ordering
   Run tasks on a dedicated thread
   Prioritize certain tasks

Implementation:
using System.Collections.Generic;
using System.Threading.Tasks;
public class SimpleTaskScheduler : TaskScheduler
{
    protected override IEnumerable<Task>? GetScheduledTasks()
    {
        return null;
    }
    protected override void QueueTask(Task task)
    {
        Thread thread = new Thread(() =>
        {
            TryExecuteTask(task);
        });
        thread.Start();
    }
    protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
    {
        return TryExecuteTask(task);
    }
}
var scheduler = new SimpleTaskScheduler();
TaskFactory factory = new TaskFactory(scheduler);
Task task = factory.StartNew(() =>
{
    Console.WriteLine("Running on custom scheduler");
    Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");
});
task.Wait();












