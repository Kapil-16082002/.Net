✅🔥  ParallelLoopState?
ParallelLoopState is a helper class provided by the Task Parallel Library that allows you to control the execution of a parallel loop while it is running.
It enables you to:
  Break a loop
  Stop a loop
  Check whether the loop should stop
  Determine where the loop was broken
Namespace: using System.Threading.Tasks;


Method Signature:
Parallel.For(
    int from,
    int to,
    Action<int, ParallelLoopState> body
);

-------------------------------------------------------

✅🔥 Why Do We Need ParallelLoopState?
"I've found what I need. Don't execute any more unnecessary iterations."

Suppose you have an array of 100 employee IDs, and you want to find Employee ID = 1050.
int[] employeeIds = { ... }; // 100 employee IDs
Parallel.For(0, employeeIds.Length, i =>
{
    if (employeeIds[i] == 1050)
    {
        Console.WriteLine($"Employee found at index {i}");
    }
});
Imagine the employee is found at iteration 20.
That means:
Iteration 0  → Not Found
Iteration 1  → Not Found
...
Iteration 19 → Not Found
Iteration 20 → ✓ Found , At this point, you already have the answer.

Question:
Should the loop continue checking:
Iteration 21
Iteration 22
...
Iteration 99

No, because you've already found what you were looking for.
Continuing to execute the remaining iterations would: 
   Waste CPU time
   Consume unnecessary system resources
   Reduce performance
This is why ParallelLoopState exists.

----------------------------------------------------------------

✅🔥 How do we get ParallelLoopState ?
Normal loop:
Parallel.For(0, 10, i =>
{

});

Loop with state:
Parallel.For(0, 10,(i, state) => {});

Notice: state -->> ParallelLoopState object.
TPL automatically provides it. You never create it manually.

-------------------------------------------------------------------

✅🔥 Important Members of ParallelLoopState:
    Break()
    Stop()
    IsStopped
    ShouldExitCurrentIteration
    LowestBreakIteration


✅🔥 Break():
Break() tells the parallel loop:
"Do not start iterations whose index is greater than the current iteration."
It is mainly useful for ordered loops.

Important:
Break does NOT Immediately stop ALL running iterations.
Already-running iterations continue.
Only future iterations with a higher index are prevented from executing.


Example:
using System;
using System.Threading.Tasks;
ParallelLoopResult result = Parallel.For(0, 10, (i, state) =>
{
    Console.WriteLine($"Processing {i}");
    if (i == 5)
    {
        Console.WriteLine("Break called");
        state.Break();
    }
});
Possible Output:
Processing 0
Processing 1
Processing 2
Processing 5

Break called

Processing 3
Processing 4
Sometimes you may also see: Processing 6. if iteration 6 had already started before Break() was called.



✅🔥LowestBreakIteration?
LowestBreakIteration is a property of ParallelLoopResult that returns the smallest iteration index that called state.Break().
Suppose multiple iterations call Break().
Example:
Iteration 12 calls Break()
Iteration 5 calls Break()
Iteration 9 calls Break()
Then,
LowestBreakIteration = 5
because 5 is the smallest iteration number that requested a break.

ParallelLoopResult result = Parallel.For(0, 20,
    (i, state) =>
    {
        if (i == 5)
        {
            state.Break();
        }
    });
Console.WriteLine(result.LowestBreakIteration); // 5


=================================================================================================================

✅🔥 Stop():
Stop() is a method of the ParallelLoopState class used with Parallel.For() and Parallel.ForEach().
Stop() requests that the parallel loop stop executing as soon as possible by preventing any new iterations from being scheduled. 
Iterations that are already running are allowed to complete.

In simple words:
"Stop() tells the scheduler: 'No more new iterations are needed. Stop the loop as soon as possible.'"

Example:
Parallel.For(0, 20, (i, state) =>
{
    Console.WriteLine($"Iteration {i}");
    if (i == 5)
    {
        Console.WriteLine("Stop Requested");
        state.Stop();
    }
});
| Feature                              | `Stop()`                  | `Break()`                                                               |
| ------------------------------------ | ------------------------- | ----------------------------------------------------------------------- |
| Considers iteration order?           | ❌ No                      | ✅ Yes                                                                   |
| Stops scheduling new iterations?     | ✅ Yes                     | ✅ Yes (only iterations after the break point)                           |
| Already-running iterations continue? | ✅ Yes                     | ✅ Yes                                                                   |
| Typical use case                     | Cancel all remaining work | Stop after reaching a particular iteration or finding the required item |

===============================================================================================================

✅🔥 IsStopped is a read-only property of the ParallelLoopState class.
It is used inside Parallel.For() and Parallel.ForEach() to determine whether state.Stop() has already been called by any iteration.
IsStopped returns a Boolean value (true or false) indicating whether Stop() has been called on the current parallel loop.
Return Type: bool

Example:
Parallel.For(0, 20, (i, state) =>
{
    if (state.IsStopped) return;
    Console.WriteLine(i);
    if (i == 5) state.Stop();
});


✅🔥Why Do We Need IsStopped?
We know that calling: 
state.Stop(); does not immediately stop all currently running iterations.Some iterations may already be executing on other threads.
Although Stop() prevents new iterations from starting, iterations 8, 10, and 12 are already running.

These iterations can check: state.IsStopped
If it returns true, they can exit immediately instead of doing unnecessary work.


===========================================================================================================
✅🔥 MaxDegreeOfParallelism:
MaxDegreeOfParallelism specifies the maximum number of concurrent operations that a parallel loop (Parallel.For, Parallel.ForEach) or a Parallel.Invoke can execute at the same time.
It is a property of the ParallelOptions class.
public int MaxDegreeOfParallelism { get; set; }


ParallelOptions options = new ParallelOptions()
{
    MaxDegreeOfParallelism = 4
};
Parallel.For(0, 100, options, i =>
{
    Console.WriteLine(i);
});

✅Special Values:
+ve number(like 4) -->> Use at most 4 concurrent tasks.
-1 -->> Unlimited tasks (TPL will decide)
0 -->>  Not Allowed, ArgumentOutOfRangeException


✅Why do we need MaxDegreeOfParallelism?
Suppose your computer has 8 CPU cores.
Now imagine this code:
Parallel.For(1, 1000, i =>
{
    Console.WriteLine(i);
});
You never specified
2 threads
4 threads
8 threads
16 threads
So who decides? Answer: TPL Scheduler.
It usually chooses a number based on
   CPU cores
   ThreadPool availability
   System load
   Work stealing algorithm
Sometimes this is perfect.
Sometimes you want control.
That's why MaxDegreeOfParallelism exists.



















