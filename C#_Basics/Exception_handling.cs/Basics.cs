
✅🔥Exceptions basically are runtime errors and unexpected behaviour in a program, that interrupts normal flow of program.

🚗 Real Life Example: Moving Car
Imagine:
You are driving a car normally.
👉 Suddenly a dog comes in front of the car. Then you have to stop car.
So, That dog came in front of your car is an unexpected situation.



⚠️Basic Example of Exception:
✅ Example 1: Division by Zero
int a = 10;
int b = 0;
int result = a / b;   // ❌ division by zero not allowed, DivideByZeroException

The CLR (Common Language Runtime) creates an exception object and stops normal execution.
If you don’t handle the exception, program will:
will give Undefined Behavior, On most systems → Program crashes

---------------------------------------------------------------------------------------

✅🔥Why Exception Handling is Needed?

❌Without exception handling:
Start Program
      ↓
Read File
      ↓
Exception Occurred
      ↓
Program Crashes


✔ With exception handling:
Start Program
      ↓
Read File
      ↓
Exception Occurred
      ↓
Catch Exception
      ↓
Show Message
      ↓
Continue Program
Exception handling prevents application crashes and provides meaningful error messages.

------------------------------------------------------------------------------------------

✅🔥Exception Hierarchy
Every exception in .NET derives from System.Exception.
Object
   │
System.Exception
   │
 ├───────────────┐
 │               │
SystemException  ApplicationException
      │
      ├── DivideByZeroException
      ├── NullReferenceException
      ├── OverflowException
      ├── IndexOutOfRangeException
      ├── InvalidCastException
      ├── IOException
      ├── FormatException
      ├── ArithmeticException
      └── ArgumentException
----------------------------------------------------------------------------------------

✅🔥Exception Object Contains
Exception object contains information about the error that occurred during program execution. 
It is an instance of the Exception class (or one of its derived clThese properties help developers diagnose and handle errors effectively.
asses).

| Property           | Description                                                                       |
| **Source**         | Name of the application or object that caused the exception.                      |
| **Message**        | Describes what error occurred.                                                    |
| **TargetSite**     | The method where the exception was thrown.                                        |
| **StackTrace**     | Shows the sequence of method calls that led to the exception.                     |
| **InnerException** | Contains another exception that caused the current exception (if any).            |
| **HelpLink**       | URL or help file associated with the exception (optional).                        |
| **Data**           | A collection for storing additional user-defined information about the exception. |

using System;
class Program
{
    static void Main()
    {
        try
        {
            int x = 10;
            int y = 0;
            Console.WriteLine(x / y);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Message: " + ex.Message);
            Console.WriteLine("Source: " + ex.Source);
            Console.WriteLine("TargetSite: " + ex.TargetSite);
            Console.WriteLine("StackTrace: " + ex.StackTrace);
        }
    }
}
--------------------------------------------------------------------------------------------------------------------
