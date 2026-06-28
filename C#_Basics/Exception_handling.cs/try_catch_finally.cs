
| **Keyword**   | **Purpose**         | **Short Explanation**                                                                                                 |
| ------------- | ------------------- | --------------------------------------------------------------------------------------------------------------------- |
| **`try`**     | Contains risky code | Encloses code that might throw an exception. If an exception occurs, control transfers to the matching `catch` block. |
| **`catch`**   | Handles exception   | Catches and handles the exception thrown from the `try` block, preventing the program from crashing.                  |
| **`finally`** | Always executes     | Executes whether an exception occurs or not. Commonly used to release resources like files or database connections.   |
| **`throw`**   | Throws exception    | Explicitly throws a new exception or rethrows the current exception to the caller.                                    |
| **`when`**    | Exception filter    | Adds a condition to a `catch` block so it handles the exception only if the condition evaluates to `true`.            |


✅🔥 Order of catch Blocks
Always keep
Specific Exception at top
↓
General Exception at botttom


✔Example:
catch(DivideByZeroException)
{
}
catch(Exception)
{
}

❌Wrong:
catch(Exception)
{

}
catch(DivideByZeroException)
{

} // compilation Error. Because Exception catches everything first.

=======================================================================================================================

✅🔥try-catch-finally in C# (Detailed Explanation)
try → Contains code that may cause an exception.
catch → Handles the exception.
finally → Executes cleanup code, whether an exception occurs or not.
✅🔥Syntax:
try
{
    // Risky code
}
catch (Exception ex)
{
    // Handle exception
}
finally
{
    // Cleanup code
}

            try
             |
   --------------------
   |                  |
No Exception     Exception Occurs
   |                  |
   |               catch
   |                  |
   --------------------
             |
          finally
             |
         Program Continues

-----------------------------------------------------
✅🔥finally Block:
The finally block always must executes, whether:
    Exception occurs
    Exception does not occur
    return statement is executed inside try
    catch executes successfully
Its primary purpose is resource cleanup.
During program execution, we acquire resources such as:
     Files is opened
     Database connections is active
     Network sockets is there 
     memory resources in used
     Locks
     Streams
These resources should always be released.
Even if an exception occurs, cleanup must happen.



Example: finally Executes Even After return
using System;
class Program
{
    static int Test()
    {
        try
        {
            return 10;
        }
        finally   // A try block can be without catch, finally Without catch
        {
            Console.WriteLine("Finally Executed");
        }
    }
    static void Main()
    {
        Console.WriteLine(Test());
    }
}
Output:
Finally Executed
10
Even though return executes, finally runs first.



























































































































































































































































