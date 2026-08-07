✅🔥🚀 What is Enum?
🔥 Enum = Giving meaningful names to numbers.
Enum (Enumeration) is a data type(value type) that allows you create a list of predefined named values.
Instead of remembering numbers like 0, 1, 2, you can use meaningful names like Red, Yellow, Green.

Real-Life Example: Think of a traffic signal:
Without names: Hard to remember.
0 = Red
1 = Yellow
2 = Green

With Enum:
enum TrafficSignal
{
    Red,
    Yellow,
    Green
}
Now you can write:
TrafficSignal signal = TrafficSignal.Green;
which is much easier to understand.



Why Use Enum?
✅ Improves readability
            OrderStatus status = OrderStatus.Pending;
            instead of int status = 0;
✅ Avoids magic numbers
✅ Reduces mistakes
✅ Makes code easier to maintain
--------------------------------------------------------

❌ Problem Without Enum
Suppose you are developing an order management system.
using System;
class Program
{
    static void Main()
    {
        int status = 1;
        if(status == 1)
        {
            Console.WriteLine("Order is Processing");
        }
    }
}
⚠️ Problem
Looking at: int status = 1;
Nobody knows:
0 = Pending
1 = Processing
2 = Completed
3 = Cancelled
The code is difficult to understand.


✅ Solution Using Enum
using System;
enum OrderStatus
{
    Pending,
    Processing,
    Completed,
    Cancelled
}
class Program
{
    static void Main()
    {
        OrderStatus status = OrderStatus.Processing;
        if(status == OrderStatus.Processing)
        {
            Console.WriteLine("Order is Processing");
        }
    }
}
Output:
Order is Processing

===============================================================================================================

✅🔥🚀 Default Values of Enum:
using System;
enum Color
{
    Red,
    Green,
    Blue
}
class Program
{
    static void Main()
    {
        Console.WriteLine((int)Color.Red);
        Console.WriteLine((int)Color.Green);
        Console.WriteLine((int)Color.Blue);
    }
}
Output
0
1
2
Compiler automatically assigns:
Red   = 0
Green = 1
Blue  = 2

-------------------------------------------------------

✅🔥🚀 Explicit Values
using System;
enum OrderStatus
{
    Pending = 10,
    Processing = 20,
    Completed = 30,
    Cancelled = 40
}
class Program
{
    static void Main()
    {
        Console.WriteLine((int)OrderStatus.Pending);
        Console.WriteLine((int)OrderStatus.Completed);
    }
}
Output:
10
30
---------------------------------------------------

✅🔥🚀 Auto Increment Behavior
using System;
enum Numbers
{
    One = 100,
    Two,
    Three,
    Four
}
class Program
{
    static void Main()
    {
        Console.WriteLine((int)Numbers.One);
        Console.WriteLine((int)Numbers.Two);
        Console.WriteLine((int)Numbers.Three);
        Console.WriteLine((int)Numbers.Four);
    }
}
Output
100
101
102
103


enum Numbers
{
    One,        // 0
    Two = 100,  // 100
    Three,      // 101
    Four        // 102
}
===============================================================================================================

✅🔥🚀 Underlying Type:
By default: Underlying type is int
enum Color
{
    Red,
    Green,
    Blue
}

------------------------------------------
✅ Changing Underlying Type
using System;
enum Days : byte
{
    Monday,
    Tuesday,
    Wednesday
}
class Program
{
    static void Main()
    {
        Console.WriteLine((byte)Days.Monday);
        Console.WriteLine((byte)Days.Wednesday);
    }
}
Output:
0
2
-------------------------------------------------

✅🔥🚀 Enum to Integer Conversion
using System;
enum Status
{
    Pending = 10,
    Processing = 20
}
class Program
{
    static void Main()
    {
        Status s = Status.Processing;
        int value = (int)s;
        Console.WriteLine(value);
    }
}
Output: 20

--------------------------------------------

✅🔥🚀 Integer to Enum Conversion:
using System;
enum Status
{
    Pending = 10,
    Processing = 20
}
class Program
{
    static void Main()
    {
        int value = 20;
        Status s = (Status)value;
        Console.WriteLine(s);
    }
}
Output:
Processing
------------------------------------------------

⚠️✅🔥 Dangerous Conversion
using System;
enum Status
{
    Pending = 10,
    Processing = 20
}
class Program
{
    static void Main()
    {
        Status s = (Status)999;

        Console.WriteLine(s);
    }
}
Output:
999
Why? Because Enum does NOT validate values automatically.

------------------------------------------------------------

✅🔥🚀 Enum To String
using System;
enum Status
{
    Pending,
    Processing
}
class Program
{
    static void Main()
    {
        Status s = Status.Pending;
        Console.WriteLine(s);
        Console.WriteLine(s.ToString());
    }
}
Output
Pending
Pending
--------------------------------------------------------------

✅🔥🚀 String To Enum
using System;
enum Status
{
    Pending,
    Processing
}
class Program
{
    static void Main()
    {
        Status s =  Enum.Parse<Status>("Processing");
        Console.WriteLine(s);
    }
}
Output:
Processing

✅ Safe Conversion Using TryParse
using System;
enum Status
{
    Pending,
    Processing
}
class Program
{
    static void Main()
    {
        if(Enum.TryParse("Processing", out Status result))
        {
            Console.WriteLine(result);
        }
    }
}

-------------------------------------------------
🚀 Getting All Enum Values
using System;
enum Status
{
    Pending,
    Processing,
    Completed
}
class Program
{
    static void Main()
    {
        foreach(Status item in Enum.GetValues(typeof(Status)))
        {
            Console.WriteLine(item);
        }
    }
}
Output:
Pending
Processing
Completed
---------------------------------------------------------
🚀 Getting All Names
using System;
enum Status
{
    Pending,
    Processing,
    Completed
}
class Program
{
    static void Main()
    {
        string[] names =
            Enum.GetNames(typeof(Status));

        foreach(string name in names)
        {
            Console.WriteLine(name);
        }
    }
}
🔥 Most Important Interview Difference: Enum vs Struct ?




