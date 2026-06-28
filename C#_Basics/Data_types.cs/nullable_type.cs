✅🔥Nullable value types:
A Nullable Value Type allows a value type to contain:
A value
OR 
null
Syntax:
Nullable<int> x = null;     OR
int? x = null;
Both are identical.Internally int? x; is converted by compiler into Nullable<int> x;



✅🔥Why were Nullable Types introduced ?
Before C# 2.0, value types could never contain null.
int age = null;// Compiler Error: Cannot convert null to 'int'
-----------------------------------------------------------------------------------------------------------


✅🔥Memory Representation:
Nullable is actually defined approximately as:
public struct Nullable<T>
{
    private bool hasValue;
    private T value;
} // stored on stack (typically for local variables)
/*
Normal value type: int x = 10;
Memory:
Stack
+---------+
| x = 10  |  The value  10 itself is stored. */
+---------+


Nullable with value: int? x = 10;
Memory:
Stack
+------------------------+
| HasValue = true        |
| Value = 10             |
+------------------------+


Nullable with null: int? x = null;
Memory:
Stack
+------------------------+
| HasValue = false       |
| Value = undefined      |
+------------------------+

-----------------------------------------------------------------------------------------------------------------

✅🔥 Nullable with Value:
int? age = 25;
Console.WriteLine(age); // Output: 25
Console.WriteLine(age.Value); // Output: 25
Console.WriteLine(age.HasValue); // Output: true


✅🔥 Nullable without Value:
⚠️❌Danger
int? age = null;
Console.WriteLine(age.Value);// Runtime Exception, InvalidOperationException, Nullable object must have a value.
Console.WriteLine(age.GetValueOrDefault());  // Safer alternative.

-------------------------------------------------------------------------------------------------------------------

✅🔥Null Coalescing Operator (??): Returns first non-null value.

int? age = null;
int x = age ?? 50;
Console.WriteLine(x); // Output: 50


int? age = 20;
int x = age ?? 50;
Console.WriteLine(x); // Output: 20

-----------------------------------------------------------------------------------------------------------------

✅🔥 Boxing Nullable vs Normal Boxing

int x = 10;
object obj = x;      // Boxing

What happens internally?

Stack
x = 10
Boxing
  |
  V
Heap: A new object is created on the heap containing the integer value.
+------------+
| Object     |
|------------|
| int = 10   |
+------------+


✅🔥 Case 1: Boxing a Nullable That Has a Value
int? num = 10;
object obj = num;

❌Many people think the entire Nullable<int> structure gets boxed: Wrong.
The CLR checks: HasValue == true ? Since it is true, only the underlying int value is boxed.

Internally:
Stack
num
hasValue = true
value = 10
  Boxing
    |
    V
Heap: The boxed object contains an Int32, not a Nullable<int>.
+------------+
| Object     |
|------------|
| int = 10   |
+------------+
Proof
int? num = 10;
object obj = num;
Console.WriteLine(obj); // 10
Console.WriteLine(obj.GetType()); //  System.Int32
Notice:
System.Int32 not System.Nullable<Int32> , This surprises many interview candidates.



✅🔥Case 2: Boxing a Nullable That Has No Value
int? num = null;
object obj = num;

Now:HasValue == false, CLR does not create any heap object. No boxing object exists.
Instead: obj = null


Memory: Stack
num
hasValue = false
↓
object obj
null
No boxing object exists.


Example:
int? num = null;
object obj = num;
Console.WriteLine(obj == null);
Output: True
No heap allocation occurred.



✅🔥Key Interview Rule to Remember
Nullable<T> Boxing Rules

HasValue == true
        ↓
Box the underlying value (T)

HasValue == false
        ↓
Return null
This CLR optimization avoids boxing the entire Nullable<T> structure, reduces memory usage,
===================================================================================================================

Interview Questions
✅🔥Q1. What happens when a Nullable<int> is boxed?
Answer:
If HasValue is true, the CLR boxes the underlying int value, not the Nullable<int> structure.
If HasValue is false, the result of boxing is simply null.


✅🔥Q2. What is the type of a boxed Nullable<int> with value 10?
int? x = 10;
object obj = x;
Console.WriteLine(obj.GetType());
Output:System.Int32
The boxed object is an Int32, not Nullable<Int32>.


✅🔥Q3. Does boxing a null nullable allocate memory?
int? x = null;
object obj = x;
Answer:No. obj becomes null, and no heap allocation is performed.


✅🔥Q4. Is Nullable<T> itself a reference type?

Answer:No. Nullable<T> is a value type (struct) that contains:
HasValue
Value
Only when boxed with a value does the CLR create a heap object for the underlying value type.