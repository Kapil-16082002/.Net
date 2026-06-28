✅🔥AggregateException Class:
AggregateException Class allows multiple exceptions to be grouped into a single exception object.
It is introduced primarily for Task Parallel Library (TPL), multithreading, and async programming.


✅🔥Why Was AggregateException Introduced ?
Normally, a method throws only one exception.
Example: throw new Exception("Error"); // One exception object → One error.


But consider parallel programming:  All tasks run simultaneously.
Task1 throwws → Exception A
Task2 throwws → Exception B
Task3 throwws → Exception C

Now a question arises: Which exception should be thrown? Because there are multiple exceptions.
To solve this problem, .NET created: AggregateException
which can store:
   Exception A
   Exception B
   Exception C
inside one exception object.


using System;
class Program
{
    static void Main()
    {
        try
        {
            throw new AggregateException(
                new Exception("Error 1"),
                new Exception("Error 2"),
                new Exception("Error 3"));
        }
        catch (AggregateException ex)
        {
            foreach (Exception e in ex.InnerExceptions)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
Output:
Error 1
Error 2
Error 3

===================================================================================================================

✅🔥 Real Use Case: Tasks
Suppose two tasks fail.

using System;
using System.Threading.Tasks;
class Program
{
    static void Main()
    {
        Task t1 = Task.Run(() =>
        {
            throw new Exception("Task1 Failed");
        });
        Task t2 = Task.Run(() =>
        {
            throw new Exception("Task2 Failed");
        });
        try
        {
            Task.WaitAll(t1, t2);
        }
        catch (AggregateException ex)
        {
            foreach (var e in ex.InnerExceptions)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
Output:
Task1 Failed
Task2 Failed

✅ Why AggregateException Here?
Because:
Task1  throws → Exception
Task2  throws → Exception
Both Tasks failed.
The runtime cannot throw two exceptions separately. So it wraps them into:AggregateException





