throw rethrows the current exception while preserving the original stack trace.
throw ex throws the exception again from the current location and resets the stack trace. 
Therefore, throw is preferred for exception propagation.

throw vs throw ex
| Statement   | Stack Trace                    |
| ----------- | ------------------------------ |
| `throw;`    | Preserves original stack trace |  Rethrow current exception
| `throw ex;` | Resets stack trace             |  Throw exception object again
Because of this, throw; is almost always preferred.

/* 
✅🔥Why is throw ex dangerous?
Because it destroys the original stack trace, making it difficult to identify where the exception actually occurred.

✅🔥Can throw be used outside a catch block?
No.
throw; must be inside a catch.

✅🔥Can throw ex be used outside a catch block?
Yes, if ex is a valid exception object.
Exception ex = new Exception("Error");
throw ex;
This is valid.

*/











✅🔥Case 1: Using throw;
using System;
class Program
{
    static void FunctionC()
    {
        throw new Exception("Exception from C");
    }
    static void FunctionB()
    {
        try
        {
            FunctionC();
        }
        catch (Exception ex)
        {
            Console.WriteLine("FunctionB caught exception");
            throw;      // Preserve stack trace
        }
    }
    static void FunctionA()
    {
        FunctionB();
    }
    static void Main()
    {
        try
        {
            FunctionA();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("\nStack Trace:");
            Console.WriteLine(ex.StackTrace);
        }
    }
}
Output:
FunctionB caught exception
Exception from C
Stack Trace:
at FunctionC()
at FunctionB()
at FunctionA()
at Main()
Notice:
The exception clearly shows: FunctionC as the original source. This is what we want.



✅🔥 What Happens Internally?
Exception occurs in FunctionC
↓
FunctionB catches it
↓
throw
↓
CLR rethrows SAME exception object
↓
Original stack trace preserved  // No information is lost.

===================================================================================================================


✅🔥 Case 2: Using throw ex;
using System;
class Program
{
    static void FunctionC()
    {
        throw new Exception("Exception from C");
    }
    static void FunctionB()
    {
        try
        {
            FunctionC();
        }
        catch (Exception ex)
        {
            Console.WriteLine("FunctionB caught exception");
            throw ex;     // BAD
        }
    }
    static void FunctionA()
    {
        FunctionB();
    }
    static void Main()
    {
        try
        {
            FunctionA();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("\nStack Trace:");
            Console.WriteLine(ex.StackTrace);
        }
    }
}
Output:
FunctionB caught exception
Exception from C

Stack Trace:
at FunctionB()
at FunctionA()
at Main()

Notice: FunctionC() is gone! The original source of the exception is lost.




/*
✅ Using throw:
FunctionC throw Exception
    |
    | 
    ▼
FunctionB catches Exception

throw;

    ▼

Main receives it

Stack Trace:
FunctionC
FunctionB
FunctionA
Main
// Original history preserved.




✅Using throw ex:
FunctionC throw exception
↓
FunctionB catches it
↓
throw ex , CLR treats it as a new throw point.
↓
Main receives it

Stack Trace:
FunctionB
FunctionA
Main
Original history lost.

*/








