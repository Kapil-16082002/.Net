
✅🔥🚀 const Keyword in C#:
A constant (const) is a variable whose value cannot be changed after it is declared.
Once assigned, its value remains fixed for the entire lifetime of the program.

Syntax: const dataType variableName = value;
Example:
const double PI = 3.14159;
Console.WriteLine(PI);


✅📌 Why do we use const ?
Suppose your application uses the value of π in many places.

Without const:
double area = 3.14159 * r * r;
double circumference = 2 * 3.14159 * r;
If π changes everywhere (or you typed it incorrectly), maintenance becomes difficult.


📌 Compile-Time Optimization:
Example: const int x = 5;
Console.WriteLine(x + 10);

Compiler optimizes:5 + 10
No variable lookup needed.
Hence constants improve performance slightly.


✅📌Which is better: const or readonly?
Use const for values that will never change.
Use readonly when the value is determined at runtime but should remain immutable afterward.

-------------------------------------------------------------------------------

✅📌 Hidden Concept: Compile-Time Constant

A const value must be known at compile time.
Allowed: const int x = 10;
Allowed: const string name = "Kapil";
Allowed: const bool flag = true;

❌Not allowed:
int x = 10;
const int y = x;
Compiler Error. Because x is determined at runtime.

------------------------------------------------------------------------------

✅📌 Can we modify a constant ?
No.
const int MaxAge = 100;
MaxAge = 200;
Compiler Error:The left-hand side of an assignment must be a variable.
Because constants are immutable.
-------------------------------------------------------------------------------

✅📌 Which Types Can Be const?

Allowed:
const int age = 25;
const double pi = 3.14;
const char grade = 'A';
const bool flag = true;
const string name = "Kapil";

❌Not allowed: const DateTime today = DateTime.Now;
Because: DateTime.Now is determined at runtime.

❌Not allowed: const Employee emp = new Employee();
Objects cannot be const.
Object creation happens at runtime. But const requires compile-time values.

-------------------------------------------------------------------------------

✅📌 const Variables are Implicitly Static
Compiler internally treats constants as: Static Compile-Time Constants
Example:
class Demo
{
    public const int Age = 25;
}
Access: no need to create object, Console.WriteLine(Demo.Age);

-------------------------------------------------------------------------------

✅📌 Why Should We Use const ?
1. Prevents accidental modification
const int Days = 7;
Nobody can change it.

2. Better readability
Instead of: salary * 12
Use:salary * MonthsInYear
Much clearer.

3. Better maintainability : Only update value once.
4. Compiler optimization: Compiler substitutes the value directly.
5. Expresses intent: Shows that value will never change.


------------------------------------------------------------------------

✅📌 When Should We NOT Use const?
Don't use const if the value can change in the future.

Example: const double GST = 18;
Suppose government changes GST to 20%.
Now every compiled application must be rebuilt.
This creates maintenance issues.

Better:
public static readonly double GST = 18;
Can be initialized at runtime.