✅🔥using System.Xml;

Task.Wait():
Task.Wait() is used to block the current thread until the task completes.
👉It forces synchronous waiting on an asynchronous task.
Return Type: void()
Syntax:
task.Wait();

Example:
Task task = Task.Run(() =>
{
    Thread.Sleep(2000);
    Console.WriteLine("Task Completed");
});
task.Wait();
Console.WriteLine("Main Thread Continues");
Output:
Task Completed
Main Thread Continues
✔ Important Concept: Wait() → Blocks main thread. So CPU is idle while waiting.
✔ Interview Point:   Wait() converts async execution into blocking execution.

===============================================================================

✅🔥 Task.WaitAll()
Task.WaitAll() waits until ALL tasks are completed.
Task.WaitAll(task1, task2, task3);
Return Type: void()

Task t1 = Task.Run(() =>
{
    Thread.Sleep(1000);
    Console.WriteLine("Task 1 done");
});
Task t2 = Task.Run(() =>
{
    Thread.Sleep(2000);
    Console.WriteLine("Task 2 done");
});
Task t3 = Task.Run(() =>
{
    Thread.Sleep(1500);
    Console.WriteLine("Task 3 done");
});
Task.WaitAll(t1, t2, t3); // The current thread(main thread) will pause (block) until ALL the specified tasks (t1, t2, t3) are completed.
Console.WriteLine("All Tasks Completed");

✔ Output:
Task 1 done
Task 3 done
Task 2 done
All Tasks Completed

✅🚨 Important Note
If any task:
throws exception → AggregateException is thrown
never completes → WaitAll blocks forever
is canceled → still considered completed

============================================================================

✅🔥 Task.WaitAny()
Task.WaitAny() waits until ANY ONE task completes first.
Return type: WaitAny → returns index of first completed task
Syntax:
Task.WaitAny(task1, task2, task3);

✔ Example:
Task t1 = Task.Run(() =>
{
    Thread.Sleep(3000);
    Console.WriteLine("Task 1 done");
});
Task t2 = Task.Run(() =>
{
    Thread.Sleep(1000);
    Console.WriteLine("Task 2 done");
});
Task t3 = Task.Run(() =>
{
    Thread.Sleep(2000);
    Console.WriteLine("Task 3 done");
});
int firstCompleted = Task.WaitAny(t1, t2, t3);
Console.WriteLine("First completed task index: " + firstCompleted);

Output:
Task 2 done
First completed task index: 1


| Feature      | Wait             | WaitAll          | WaitAny        |
| ------------ | ---------------- | ---------------- | -------------- |
| Waits for    | One task         | All tasks        | First task     |
| Blocking     | Yes              | Yes              | Yes            |
| Return value | void             | void             | index of task  |
| Use case     | Single task sync | Batch completion | Fastest result |
































