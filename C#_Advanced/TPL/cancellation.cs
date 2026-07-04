✅🔥 using System.Security.Permissions;

Why Cancellation:
Cancellation is a mechanism that allows a running or pending task to stop its execution gracefully when cancellation is requested.
Instead of forcefully killing a thread, .NET sends a cancellation request, and the task checks for it periodically.

Why do we need Cancellation?
Suppose you're downloading a 5 GB file.
Download Started -> 20% -> 40% -> User clicks Cancel Then:
✅Without cancellation:
Task -> continues downloading -> Consumes CPU -> Consumes Network -> Consumes Memory -> Finishes after several minutes

✅With Cancellation
Download Started -> User clicks Cancel -> Cancellation Requested -> Task Notices Request -> Stops Gracefully -> Resources Released


------------------------------------------------------------------------------------------------------------------

✅🔥 Why not simply kill the thread?
Suppose a thread is writing data into a database.
Write Record -> Write Address -> Write Salary -> Thread Killed -> Database becomes inconsistent.
Example:
Employee Name Saved
Salary NOT Saved
Address Half Saved
Very dangerous.
That's why .NET avoids forcefully terminating threads.


Cancellation Example:
using System;
using System.Threading;
using System.Threading.Tasks;
class Program
{
    static void Main()
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        Task task = Task.Run(() =>
        {
            for(int i = 1; i <= 20; i++)
            {
                if(cts.Token.IsCancellationRequested)
                {
                    Console.WriteLine("Task Cancelled");
                    return;
                }
                Console.WriteLine(i);
                Thread.Sleep(500);
            }

        }, cts.Token);

        Thread.Sleep(3000);
        cts.Cancel();
        task.Wait();
    }
}
Possible Output:
1
2
3
4
5
6
Task Cancelled
-------------------------------------------------------------------------

✅🔥 CancellationTokenSource
A CancellationTokenSource (CTS) is an object responsible for creating CancellationToken instances and requesting cancellation.
Think of it as the controller.
CancellationTokenSource -> Creates Token -> Later -> Cancel() -> Token Receives Request -> Task Stops

✅Important Members:
✅1. Token: Returns the associated CancellationToken.
CancellationToken token = cts.Token;

✅2. Cancel(): Requests cancellation immediately.]
cts.Cancel();

✅3. CancelAfter(): Requests cancellation automatically after a specified time.
cts.CancelAfter(5000);

✅4. Dispose()
Releases resources used by the source.
cts.Dispose();



✅ Code Example:
CancellationTokenSource cts = new CancellationTokenSource();
Console.WriteLine("Running...");
Thread.Sleep(2000);
cts.Cancel();
Console.WriteLine(cts.Token.IsCancellationRequested);


--------------------------------------------------------------------------

✅🔥 CancellationToken
A CancellationToken is a lightweight structure that carries a cancellation request from a CancellationTokenSource to one or more tasks.
Think of it as a messenger that tells a task: "Someone requested cancellation."
It does not cancel the task itself.
It only reports whether cancellation has been requested.

✅Important Point:
A CancellationToken is read-only.
It cannot request cancellation.
Only CancellationTokenSource can.

✅Architecture:
CancellationTokenSource -> Creates -> CancellationToken -> Passed to Tasks -> Tasks Read Token ->Continue OR Stop.

✅Properties:
✅1. IsCancellationRequested
Returns: bool
if(token.IsCancellationRequested)
{
    Console.WriteLine("Stopping...");
    return;
}
✅2. CanBeCanceled
Returns whether this token supports cancellation.
Console.WriteLine(token.CanBeCanceled);

✅3. WaitHandle
Returns a wait handle that becomes signaled when cancellation occurs.
Useful with older synchronization APIs.

CancellationTokenSource cts = new CancellationTokenSource();
CancellationToken token = cts.Token;
Console.WriteLine(token.CanBeCanceled);
Console.WriteLine(token.IsCancellationRequested);

---------------------------------------------------------------

✅🔥 Cooperative Cancellation:
Cooperative Cancellation means the task periodically checks whether cancellation has been requested and stops itself voluntarily.
The runtime does not force the task to stop.

CancellationTokenSource cts = new CancellationTokenSource();
Task task = Task.Run(() =>
{
    for(int i = 1; i <= 100; i++)
    {
        if(cts.Token.IsCancellationRequested)
        {
            Console.WriteLine("Stopping...");
            return;
        }
        Console.WriteLine(i);
        Thread.Sleep(200);
    }
}, cts.Token);
Thread.Sleep(1500);
cts.Cancel();
task.Wait();
-------------------------------------------------------------

✅🔥ThrowIfCancellationRequested()
ThrowIfCancellationRequested() checks whether cancellation has been requested.
If not: Continue Execution
If yes: It throws an OperationCanceledException.

Signature: void ThrowIfCancellationRequested()
Return Type: void

✅ Why use it ?
Instead of writing:
if(token.IsCancellationRequested)
{
    return;
}
Use: token.ThrowIfCancellationRequested();


Example:
CancellationTokenSource cts = new CancellationTokenSource();
Task task = Task.Run(() =>
{
    for(int i = 1; i <= 20; i++)
    {
        cts.Token.ThrowIfCancellationRequested();
        Console.WriteLine(i);
        Thread.Sleep(300);
    }
}, cts.Token);
Thread.Sleep(2500);
cts.Cancel();
try
{
    task.Wait();
}
catch(AggregateException ex)
{
    Console.WriteLine(ex.InnerException?.GetType().Name);
}







