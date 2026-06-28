✅🔥 Custom Exceptions in C#
A Custom Exception is a user-defined exception class that inherits from the base Exception class.
We create custom exceptions when the built-in exceptions (ArgumentException, InvalidOperationException, DivideByZeroException, etc.) do not provide enough information about the error condition in our application.
This allows developers to handle domain-specific errors based on their application logic.



✅🔥Creating its own Custom Exception class:
A custom exception is simply a class derived from Exception.

using System;
// Custom exception for division by zero
class DivisionByZeroException : Exception
{
    private string errorMsg;
    public DivisionByZeroException(string msg)  // Constructor initializes the error message
    {
        errorMsg = msg;
    }
    public override string Message // Similar to what() function in C++
    {
        get
        {
            return errorMsg;
        }
    }
}
class Program
{
    static int Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new DivisionByZeroException("Division by zero is not allowed.");
        }
        return a / b;
    }
    static void Main()
    {
        try
        {
            int result = Divide(10, 0);
            Console.WriteLine("Result = " + result);
        }
        catch (DivisionByZeroException ex)
        {
            Console.WriteLine("Custom Exception Caught:");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Exception:");
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine("Program continues...");
    }
}