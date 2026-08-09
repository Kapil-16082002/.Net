
✅🔥📌 What is Type Conversion ?
Type Conversion is the process of converting a value from one data type to another data type.

Examples:
int     → double
double  → int
string  → int
int     → string
float   → double


🎯 Why Do We Need Type Conversion ?
Suppose:
int age = 25;
double salary = 50000.75;

Sometimes we need:
✅ Store an int inside a double
✅ Convert user input (string) to int
✅ Convert numeric values to strings for display
That's where type conversion is used.

-------------------------------------------------------------------------

🚀 Types of Type Conversion
1. Implicit Conversion
2. Explicit Conversion (Casting)
3. Parse()
4. Convert Class


✅1️⃣ Implicit Type Conversion
Conversion performed automatically by the compiler.
No data loss occurs.
Usually Conversion happens from: Smaller Type to Larger Type

using System;
class Program
{
    static void Main()
    {
        int numInt = 500;
        double numDouble = numInt;

        Console.WriteLine("Int Value: " + numInt);
        Console.WriteLine("Double Value: " + numDouble);

        Console.WriteLine(numInt.GetType());   //  System.Int32
        Console.WriteLine(numDouble.GetType()); // System.Double
    }
}
int x = 100;
double y = x;
🚀 Why No Data Loss? Because:
int      = 4 Bytes
double   = 8 Bytes
The destination type is larger.

===================================================================================================================

✅🔥2️⃣ Explicit Type Conversion (Casting)
Explicit Type Conversion (Casting) means you manually tell the compiler to convert one data type into another.
Required when:
Larger Type
      ↓
Smaller Type
Data loss may occur.

| Source Type | Can be Explicitly Converted To                                      |
| ----------- | ------------------------------------------------------------------- |
| `byte`      | `short`, `int`, `long`, `float`, `double`, `decimal`, `char`, etc.  |
| `sbyte`     | `byte`, `short`, `int`, `long`, `float`, `double`, `decimal`, etc.  |
| `short`     | `byte`, `char`, `int`, `long`, `float`, `double`, `decimal`, etc.   |
| `ushort`    | `byte`, `short`, `int`, `long`, `float`, `double`, `decimal`, etc.  |
| `int`       | `byte`, `short`, `char`, `long`, `float`, `double`, `decimal`, etc. |
| `uint`      | `byte`, `short`, `int`, `long`, `float`, `double`, `decimal`, etc.  |
| `long`      | `byte`, `short`, `int`, `float`, `double`, `decimal`, etc.          |
| `ulong`     | `byte`, `short`, `int`, `long`, `float`, `double`, `decimal`, etc.  |
| `float`     | `byte`, `short`, `int`, `long`, `double`, `decimal`, etc.           |
| `double`    | `byte`, `short`, `int`, `long`, `float`, `decimal`, etc.            |
| `decimal`   | `byte`, `short`, `int`, `long`, `float`, `double`, etc.             |
| `char`      | `int`, `byte`, `short`, `long`, etc.                                |


using System;
class Program
{
    static void Main()
    {
        double numDouble = 1.99;
        int numInt = (int)numDouble;
        Console.WriteLine("Double Value: " + numDouble);
        Console.WriteLine("Int Value: " + numInt);
    }
}
Output
Double Value: 1.99
Int Value: 1

⚠️ Data Loss Example
using System;

class Program
{
    static void Main()
    {
        long number = 5000000000;

        int result = (int)number;

        Console.WriteLine(result);
    }
}
Output: Unexpected Value
Reason:
long = 8 Bytes
int  = 4 Bytes
Data cannot fit.
===================================================================================================================

✅🔥 What is Parse()?

Parse() is a static method used to convert a string representation of a value into its actual data type.
Example:
string str = "123";
int num = int.Parse(str);
Console.WriteLine(num);

Output: 123
Here:
"123"  (string)
   ↓ Parse()
123    (int)


✅🔥Exceptions Thrown by Parse()
1. FormatException: if Input format is invalid.
int.Parse("Hello");
Error: FormatException

2. OverflowException: if Number exceeds range.
int.Parse("999999999999999");
Error:OverflowException
Because: Int32 Max Value = 2147483647


3. ArgumentNullException: if Input is null.
string str = null;
int.Parse(str);
Error: ArgumentNullException



✅🔥Common Parse Methods
int.Parse()
int age = int.Parse("25");
Result: 25

double.Parse()
double salary = double.Parse("12345.67");
Result: 12345.67

float.Parse()
float value = float.Parse("12.5");

decimal.Parse()
decimal amount = decimal.Parse("999.99");

bool.Parse()
bool result = bool.Parse("true");
Output: True

DateTime.Parse()
DateTime date = DateTime.Parse("2026-06-08");

================================================================================================================

✅🔥🚀 TryParse()
Instead of: int.Parse() 
we Use: int.TryParse()

Synatx:
bool variableName = DataType.TryParse(stringValue, out DataType result);
bool success = int.TryParse(input, out int num);
where:
TryParse → Attempts to convert a string.
input → String to convert.
out int num → Stores the converted integer if successful.
success → true if conversion succeeded, otherwise false.

Example:
string input = "123";
bool success = int.TryParse(input, out int num);
Console.WriteLine(success); // true
Console.WriteLine(num);     // 123


Which is Better?
Parse():  Use when: Input is guaranteed to be valid.
TryParse(): Use when: Input may be invalid.

int num = int.Parse("ABC"); // Exception❌
bool success = int.TryParse("ABC", out int num); // false , No Exception thrown

==================================================================================================================

✅🔥 Convert Class in C#
The Convert class is a built-in .NET class that provides methods to convert a value from one data type to another.
It belongs to the namespace: using System;
Convert Class Contains Static Methods to avoid creation of object everytime.

| Method                 | Converts To |
| ---------------------- | ----------- |
| `Convert.ToBoolean()`  | `bool`      |
| `Convert.ToByte()`     | `byte`      |
| `Convert.ToSByte()`    | `sbyte`     |
| `Convert.ToChar()`     | `char`      |
| `Convert.ToInt16()`    | `short`     |
| `Convert.ToUInt16()`   | `ushort`    |
| `Convert.ToInt32()`    | `int`       |
| `Convert.ToUInt32()`   | `uint`      |
| `Convert.ToInt64()`    | `long`      |
| `Convert.ToUInt64()`   | `ulong`     |
| `Convert.ToSingle()`   | `float`     |
| `Convert.ToDouble()`   | `double`    |
| `Convert.ToDecimal()`  | `decimal`   |
| `Convert.ToString()`   | `string`    |
| `Convert.ToDateTime()` | `DateTime`  |


What Happens if Conversion Fails?

Example:
string s = "ABC";
int x = Convert.ToInt32(s);

Runtime Exception: System.FormatException
because "ABC" is not a valid integer.


---------------------------------------------
1. string → int
using System;
class Program
{
    static void Main()
    {
        string s = "100";
        int num = Convert.ToInt32(s);
        Console.WriteLine(num);
    }
}
Output: 100

-------------------------------------------------
2. int → string

int x = 50;
string s = Convert.ToString(x);
Console.WriteLine(s);
Output: 50

--------------------------------------------------
3. double → int

double d = 12.8;
int x = Convert.ToInt32(d);
Console.WriteLine(x);
Output: 13

⭐ Interview Point:
Convert.ToInt32() rounds to the nearest integer, while explicit casting truncates the decimal part.

double d = 12.8;
int a = (int)d;              // 12
int b = Convert.ToInt32(d);  // 13

------------------------------------------------------
4. bool → int

bool flag = true;
int x = Convert.ToInt32(flag);
Console.WriteLine(x);
Output: 1

Similarly,
bool flag = false;
Console.WriteLine(Convert.ToInt32(flag));
Output: 0

--------------------------------------------------------
5. int → bool
Console.WriteLine(Convert.ToBoolean(0)); // false
Console.WriteLine(Convert.ToBoolean(1)); // true
Console.WriteLine(Convert.ToBoolean(10));// true
0 → false
Any non-zero number → true

-----------------------------------------------------------
6. char → int
char ch = 'A';
int value = Convert.ToInt32(ch);
Console.WriteLine(value); // 65

----------------------------------------------------------
7. int → char
int value = 66;
char ch = Convert.ToChar(value);
Console.WriteLine(ch); // B

---------------------------------------------------------
8. string → bool
string s = "true";
bool flag = Convert.ToBoolean(s);
Console.WriteLine(flag); // True

-----------------------------------------------------------
9. string → double
string s = "12.56";
double d = Convert.ToDouble(s);
Console.WriteLine(d); // 12.56

------------------------------------------------------------
10. string → DateTime
string date = "06/09/2026";
DateTime d = Convert.ToDateTime(date);
Console.WriteLine(d);


| Explicit Cast              | `Convert.ToInt32()`                      |
| -------------------------- | ---------------------------------------- |
| `(int)12.9` → `12`         | `Convert.ToInt32(12.9)` → `13`           |
| Cannot convert `string`    | Can convert numeric strings              |
| Cannot convert `bool`      | Can convert `bool` (`true`→1, `false`→0) |
| Mainly numeric conversions | Supports many built-in conversions       |



