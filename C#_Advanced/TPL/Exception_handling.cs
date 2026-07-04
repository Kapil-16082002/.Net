✅🔥 Why Exception Handling is Different in TPL?
Synchronous Code:
Consider a normal method:
using System;
class Program
{
    static void Divide()
    {
        int x = 10;
        int y = 0;
        Console.WriteLine(x / y);
    }
    static void Main()
    {
        try
        {
            Divide();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.GetType().Name);
        }
    }
}
Output: DivideByZeroException
Flow: Method Starts -> Exception Occurs -. Exception Immediately Propagates -> Catch Block Executes


✅🔥 TPL Behavior:
Now consider a Task.
Task task = Task.Run(() =>
{
    int x = 10;
    int y = 0;
    Console.WriteLine(x / y);
});
Did the exception immediately reach the caller? No.
Flow:Task Starts -> Exception Occurs -> Task Stores Exception -> Task Ends (Faulted) -> Caller Observes Task -> Exception Re-thrown

-----------------------------------------------

✅🔥Task States:
A Task can end in three different ways.
Task Created
↓
Running
↓
Completed Successfully
Status = RanToCompletion
      OR
Exception Occurs
Status = Faulted
      OR
Cancellation Requested
Status = Canceled

=================================================================================================================

✅🔥 AggregateException:
AggregateException is a special exception class used by TPL to wrap one or more exceptions thrown by Tasks.
Namespace: using System.Threading.Tasks;


✅AggregateException provides two important properties:
InnerExceptions → Returns all exceptions
InnerException → Returns only the first exception


✅ Why AggregateException ?
Suppose two Tasks throw exceptions simultaneously.
Which exception should be thrown ?
Example:
Task1 -> DivideByZeroException
Task2 -> InvalidOperationException
Only one exception can be thrown at a time.


Therefore .NET wraps them into
AggregateException
↓
Contains:
DivideByZeroException
InvalidOperationException




Why do we need InnerExceptions?
Imagine three tasks running simultaneously.
Task1
↓ throw
DivideByZeroException

Task2
↓ throw
InvalidOperationException

Task3
↓ throw
NullReferenceException
If .NET threw only one exception, DivideByZeroException then InvalidOperationException and NullReferenceException would be lost.
To preserve every error, TPL creates AggregateException.

-----------------------------------------------------------

✅🔥 1. InnerExceptions:
InnerExceptions is a property of AggregateException.
It returns a collection containing every exception that occurred during parallel task execution.

Syntax: public ReadOnlyCollection<Exception> InnerExceptions { get; }
Return Type: ReadOnlyCollection<Exception>

| Feature     | Description                                    |
| ----------- | ---------------------------------------------- |
| Property    | `AggregateException.InnerExceptions`           |
| Return Type | `ReadOnlyCollection<Exception>`                |
| Contains    | All exceptions                                 |
| Can Iterate | Yes (`foreach`)                                |
| Can Modify  | No                                             |
| Used For    | Inspecting every exception from parallel tasks |

/* Why ReadOnlyCollection?
Suppose three tasks failed(throwing exceptions). The runtime records all three failures.
If the collection were writable, someone could accidentally do:
ex.InnerExceptions.Clear();
OR
ex.InnerExceptions.RemoveAt(0);
Now the original failure information would be lost.
To prevent this, .NET returns a ReadOnlyCollection<Exception> so the list cannot be modified. 
You can inspect every exception safely without changing the runtime's recorded errors. */

// Why do we need InnerExceptions  : Reason same as above.
Code Example:
using System;
using System.Threading.Tasks;
class Program
{
    static void Main()
    {
        Task t1 = Task.Run(() =>
        {
            throw new DivideByZeroException("Division failed");
        });
        Task t2 = Task.Run(() =>
        {
            throw new InvalidOperationException("Invalid operation");
        });
        Task t3 = Task.Run(() =>
        {
            throw new NullReferenceException("Object is null");
        });
        try
        {
            Task.WaitAll(t1, t2, t3);
        }
        catch (AggregateException ex)
        {
            Console.WriteLine("Number of Exceptions : " + ex.InnerExceptions.Count);
            foreach (Exception e in ex.InnerExceptions)
            {   Console.WriteLine("--------------------------------");
                Console.WriteLine("Type : " + e.GetType().Name);
                Console.WriteLine("Message : " + e.Message);
/* 
    catch (AggregateException ex)
{
    Console.WriteLine(ex.InnerExceptions[0].Message);
    Console.WriteLine(ex.InnerExceptions[1].Message);
    Console.WriteLine(ex.InnerExceptions[2].Message);
}
*/
            }
        }
    }
}
Number of Exceptions : 3
--------------------------------
Type : DivideByZeroException
Message : Division failed

--------------------------------
Type : InvalidOperationException
Message : Invalid operation

--------------------------------
Type : NullReferenceException
Message : Object is null

--------------------------------------------------------------------------

✅🔥 InnerException:
InnerException is a property inherited from the base Exception class.
For an AggregateException, it returns only the first exception in the InnerExceptions collection.
Syntax: public Exception? InnerException { get; }
Return Type:
Exception
OR
null //if no inner exception exists.


✅🔥 Why do we need InnerException ?
Sometimes you only care about the primary or first failure.
Instead of writing ex.InnerExceptions[0]
you can simply use ex.InnerException
This is more convenient when you don't need to inspect every exception.

using System;
using System.Threading.Tasks;
class Program
{
    static void Main()
    {
        Task t1 = Task.Run(() =>
        {
            throw new DivideByZeroException("Division Error");
        });
        Task t2 = Task.Run(() =>
        {
            throw new InvalidOperationException("Invalid Operation");
        });
        try
        {
            Task.WaitAll(t1, t2);
        }
        catch (AggregateException ex)
        {
            Console.WriteLine(ex.InnerException.GetType().Name);
            Console.WriteLine(ex.InnerException.Message);
        }
    }
}
Possible Output:  Only the first exception is shown, even though another task also failed.
DivideByZeroException
Division Error

------------------------------------------------------------

✅🔥Relationship between InnerException and InnerExceptions

If InnerExceptions contains:
InnerExceptions
[
 DivideByZeroException,
 InvalidOperationException,
 NullReferenceException
]
then ex.InnerException is effectively equivalent to ex.InnerExceptions[0] and returns: DivideByZeroException






