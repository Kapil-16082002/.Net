✅🔥What is Stack Unwinding in C#?
When an exception is thrown in C#, the CLR (Common Language Runtime) traverse(searches) the call stack for a matching catch block.
During this search, it removes (unwinds) stack frames one by one until it finds a matching catch block(handler).

Unlike C++, local objects are NOT destroyed immediately, because they are managed by the Garbage Collector.
Instead:
Local variables go out of scope.
finally blocks execute during unwinding.
Objects implementing IDisposable should be cleaned up via using or finally.



✅ Why is Stack Unwinding Necessary?
When an exception is thrown, program control immediately transfers to the nearest catch block (or the exception handler, if one exists). 
However, before transferring control, all local objects (those created within scopes being unwound) need to be properly destroyed and cleaned up, to avoid:

1.Memory Leaks:
Any dynamically allocated resources must be freed during stack unwinding.
2.Resource Leaks:
Files, handles, or database connections must be closed or released during stack unwinding.
3.Undefined Behavior:
Proper destruction ensures program behaves safely and consistently even during abnormal termination.


✅🔥 throw Keyword
Used to manually create exceptions.
throw new Exception();
Example:
int age = -5;
if(age<0)
{
    throw new Exception("Invalid Age");
}


✅Built-in Exceptions:
throw new DivideByZeroException();
throw new ArgumentException();
throw new InvalidOperationException();
throw new InvalidCastException();
throw new FileNotFoundException();


==================================================================================================================

✅🔥 Example 1: Unhandled Exception
using System;
class Test
{
    string name;
    public Test(string n)
    {
        name = n;
        Console.WriteLine("Constructor: " + name);
    }
}
class Program
{
    static void FunctionC()
    {
        Test c = new Test("C");
        throw new Exception("Exception from C");
    }
    static void FunctionB()
    {
        Test b = new Test("B");
        FunctionC();
    }
    static void FunctionA()
    {
        Test a = new Test("A");
        FunctionB();
    }
    static void Main()
    {
        FunctionA();
    }
}
Output:
Constructor: A
Constructor: B
Constructor: C
Unhandled Exception...
Notice:
Unlike C++, there are no destructor messages.Because objects are managed by the Garbage Collector, not destroyed immediately during unwinding.


✅🔥 How CLR Unwind  above scenerio?
✅Step 1: Program starts from Main()
Call Stack
+-------------+
| Main        |
+-------------+
Main calls: FunctionA();


✅Step 2: Entered FunctionA
Cal  Stack
+-------------+
| FunctionA   |
+-------------+
| Main        |
+-------------+
Test a = new Test("A");  // Object A is created.
Output: Constructor: A


✅Step 3: FunctionA calls FunctionB
Call Stack:
+-------------+
| FunctionB   |
+-------------+
| FunctionA   |
+-------------+
| Main        |
+-------------+
Test b = new Test("B"); // Object B is created.
Output: Constructor: B



✅Step 4: FunctionB calls FunctionC
Call Stack:
+-------------+
| FunctionC   |
+-------------+
| FunctionB   |
+-------------+
| FunctionA   |
+-------------+
| Main        |
+--------------
Test c = new Test("C");  // Object C is created.
Output: Constructor: C



✅Step 5: Exception is thrown
throw new Exception("Exception from C");
The CLR immediately stops executing the remaining statements in FunctionC.
The CLR now starts stack unwinding.
Current stack:
+-------------+
| FunctionC   | ← Exception occurs here
+-------------+
| FunctionB   |
+-------------+
| FunctionA   |
+-------------+
| Main        |
+-------------+


✅Step 6: CLR searches for a catch block
The CLR checks: FunctionC , Is there a catch here? No, So it removes the FunctionC stack frame.
Stack becomes:
+-------------+
| FunctionB   |
+-------------+
| FunctionA   |
+-------------+
| Main        |
+-------------+
Program control immediately transfer to the FunctionB i.e Leave FunctionC
Notice:
The local variable 'c'  disappears because its stack frame is gone.
But the heap object itself is not immediately destroyed.
Heap:A,B,C
All three objects still exist on the managed heap until the Garbage Collector decides they are unreachable and reclaims them.
This is a major difference from C++.


✅Step 7: CLR checks FunctionB, same process as Step 6.
Stack becomes:
+-------------+
| FunctionA   |
+-------------+
| Main        |
+-------------+


✅Step 8: CLR checks FunctionA
Stack becomes:
+-------------+
| Main        |
+-------------+

✅Step 9: CLR checks Main , No catch handler
CLR removes Main. Leave Main
Stack becomes empty.
So the runtime terminates the program and prints:


The CLR searched every active stack frame:
FunctionC
↓
FunctionB
↓
FunctionA
↓
Main
No catch block exists.
Unhandled Exception:
System.Exception: Exception from C


✅🔥Why are there no destructor messages like C++?
In C++, local objects are destroyed immediately during stack unwinding:
Constructor A
Constructor B
Constructor C

Destructor C
Destructor B
Destructor A
because objects live directly on the stack.

In C#, local variables (a, b, c) are just references stored on the stack, while the actual objects live on the managed heap. 
When stack frames are removed, only the references disappear. 
The objects remain in memory until the Garbage Collector later determines they are unreachable and reclaims them.


/*Complete Stack unwinding:
CLR stack unwinding in C# means that when an exception is thrown, the CLR walks back through the call stack, removing one stack frame at a time while searching for a matching catch block. 
Local reference variables disappear as their stack frames are popped, but heap objects are not destroyed immediately because memory management is handled by the Garbage Collector rather than deterministic destructors. 
If no handler is found, the CLR reports an unhandled exception and terminates the process.*/


===================================================================================================================

✅🔥 Where is Cleanup Done in C# ?
In C++, cleanup happens through destructors.
In C#, cleanup happens through finally blocks.
Example:
using System;
class Program
{
    static void FunctionC()
    {
        try
        {
            Console.WriteLine("FunctionC");
            throw new Exception("Error");
        }
        finally
        {
            Console.WriteLine("Cleanup C");
        }
    }
    static void FunctionB()
    {
        try
        {
            Console.WriteLine("FunctionB");
            FunctionC();
        }
        finally
        {
            Console.WriteLine("Cleanup B");
        }
    }
    static void FunctionA()
    {
        try
        {
            Console.WriteLine("FunctionA");

            FunctionB();
        }
        finally
        {
            Console.WriteLine("Cleanup A");
        }
    }
    static void Main()
    {
        FunctionA();
    }
}
This is the C# equivalent of C++ destructor calls during stack unwinding.
Instead of destructors, finally blocks execute.

====================================================================================================================

Example 2: Catch Exists in FunctionA
using System;
class Program
{
    static void FunctionC()
    {
        try
        {
            Console.WriteLine("FunctionC");
            throw new Exception("Exception");
        }
        finally
        {
            Console.WriteLine("Cleanup C");
        }
    }
    static void FunctionB()
    {
        try
        {
            Console.WriteLine("FunctionB");
            FunctionC();
        }
        finally
        {
            Console.WriteLine("Cleanup B");
        }
    }
    static void FunctionA()
    {
        try
        {
            Console.WriteLine("FunctionA");
            FunctionB();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Cleanup A");
        }
    }
    static void Main()
    {
        FunctionA();
        Console.WriteLine("Program Continues...");
    }
}
Output:
FunctionA
FunctionB
FunctionC
Cleanup C
Cleanup B
Exception
Cleanup A
Program Continues...












