✅🔥🚀 Comments in C#:
Comments are used to explain code, improve readability, and temporarily disable code during testing.
The compiler ignores comments while compiling the program.



✅1️⃣ Single-Line Comment: Used for short explanations.
Syntax:
// This is a single-line comment
Console.WriteLine("Hello");


✅2️⃣ Multi-Line Comment: Used when comments span multiple lines.
Syntax
/*
   This is a
   multi-line comment
*/
===================================================================================================================

✅🔥🎯 What is a Data Type?

A Data Type tells the compiler:
     What kind of data variable can be stored.
     How much memory to allocate.
     Which operations are allowed.
     How the value will be represented internally.
Example: int age = 25;
Here:
int  → Data Type
age  → Variable
25   → Value

The compiler knows:
Memory = 4 bytes
Type = Integer
Operations = + - * / %


✅🔥 Classification of Data Types
│
├── Value Types : store actual data directly
│     ├── int
│     ├── long
│     ├── float
│     ├── double
│     ├── decimal
│     ├── char
│     ├── bool
│     ├── enum
│     └── struct
│
├── Reference Types: store the memory address of objects
│     ├── string
│     ├── object
│     ├── class
│     ├── array
│     ├── interface
│     └── delegate
│
└── Pointer Types: store memory addresses used in unsafe code


✅🔥VALUE TYPES: Value types directly contain data.
Why Are They Called Value Types? Because variables contain values directly.
Example: int x = 10;
Memory:Stack
+------+
|  10  |
+------+
The actual value is stored.

✅ Integral Types: Used to store whole numbers.
| Type   | Size    | Range               |
| ------ | ------- | ------------------- |
| sbyte  | 1 byte  | -128 to 127         |
| byte   | 1 byte  | 0 to 255            |
| short  | 2 bytes | -32,768 to 32,767   |
| ushort | 2 bytes | 0 to 65,535         |
| int    | 4 bytes | ±2.1 billion        |
| uint   | 4 bytes | 0 to 4.2 billion    |
| long   | 8 bytes | Very large          |
| ulong  | 8 bytes | Very large positive |


✅Floating Point Types: Used for decimal numbers.
| Type    | Size     | Precision  |
| ------- | -------- | ---------- |
| float   | 4 bytes  | ~7 digits  | float price = 10.5f; Without f Compiler error
| double  | 8 bytes  | ~15 digits |
| decimal | 16 bytes | ~28 digits |


================================================================================================================

🚀 decimal Data Type in C#
decimal is a high-precision numeric data type used when accuracy is more important than speed.
decimal salary = 12345.67m;
⚠️ Notice the m at the end. It tells the compiler that the value is a decimal.

So the name decimal doesn't mean it can store only numbers with a decimal point.
🔥 Why is it called decimal then?
Because its main purpose is: ✅ Accurate representation of base-10 decimal numbers

🎯 How many digits after the decimal can decimal store? about 28–29 significant digits total.
Examples:
decimal a = 123.4567890123456789012345678m;
Here:
3 digits before decimal (123)
25 digits after decimal
Total ≈ 28 significant digits


decimal b = 0.1234567890123456789012345678m;
Here:
0 digits before decimal (leading zeros don't count)
28 significant digits after decimal


decimal c = 12345678901234567890.12345678m;
Here:
20 digits before decimal
8 digits after decimal
Total = 28 significant digits


✅Internal Representation
float / double Use: Binary Floating Point (IEEE 754) Representation
The value is stored in binary.
Some decimal numbers cannot be represented exactly in binary.
Example:
double a = 0.1;
double b = 0.2;
Console.WriteLine(a + b);
Output: 0.30000000000000004  ❌ Tiny precision error


✅decimal Uses:  a decimal-based representation.
decimal a = 0.1m;
decimal b = 0.2m;
Console.WriteLine(a + b);
Output: 0.3  ✅ Exact



✅ Can decimal store integer values also?
Yes decimal can store:
Whole numbers (integers)
Decimal/fractional numbers
Very large precise numeric values

Example:
decimal age = 25m;           // Integer value
decimal salary = 50000.75m; // Decimal value
decimal count = 1000m;      // Integer value

Decimal Used in: Because decimal provides higher precision.
    Banking
    Finance
    Accounting

✅🔥 Why Not Use float or double?  
Suppose you write:
double a = 0.1;
double b = 0.2;
Console.WriteLine(a + b);

Output: 0.30000000000000004
❌ Not exactly 0.3, This happens because double stores numbers in binary floating-point format.

=================================================================================================================