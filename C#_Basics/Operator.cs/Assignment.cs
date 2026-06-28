✅🔥Assignment operators are used to assign values to variables.

The most common assignment operator is =.
int x = 10;
It means: Store the value 10 into variable x.



✅🔥1. Bitwise OR (|)
Rule: If at least one bit is 1, the result is 1.
| A | B | A | B |
| - | - | ----- |
| 0 | 0 | 0     |
| 0 | 1 | 1     |
| 1 | 0 | 1     |
| 1 | 1 | 1     |


✅🔥2. Bitwise XOR (^)
Rule:
If both bits are different, the result is 1.
If both bits are same, the result is 0.
| A | B | A ^ B |
| - | - | ----- |
| 0 | 0 | 0     |
| 0 | 1 | 1     |
| 1 | 0 | 1     |
| 1 | 1 | 0     |


✅🔥3. Left Shift Assignment (<<=)   Multiply by 2
✅🔥4. Right Shift Assignment (>>=)  Division by 2
✅🔥5.Unsigned Right Shift Assignment (>>>=)  introduced in C# 11.
It shifts all bits of a number to the right and fills the leftmost bits with 0, regardless of whether the number is positive or negative.


✅Why was >>> introduced?
Before C# 11, C# only had the signed right shift (>>) operator.
x >> n
For signed integers (int, long), >> preserves the sign bit.
         Positive numbers → left side filled with 0
         Negative numbers → left side filled with 1
This is called Arithmetic Right Shift.
Sometimes programmers want to ignore the sign and simply shift bits logically.
For that purpose, >>> (Unsigned Right Shift) was added.


✅Memory Representation:
Suppose: int x = -8;
Binary representation (32-bit): 11111111 11111111 11111111 11111000
Notice the leading 1 (sign bit). representing -ve number
Using Signed Right Shift (>>)
int x = -8;
x >>= 2;
Console.WriteLine(x); // Output: -2
Binary: 
11111111 11111111 11111111 11111000
>> 2
11111111 11111111 11111111 11111110
Result:  -2  , The left side was filled with 1s.


Using Unsigned Right Shift (>>>=)
int x = -8;
x >>>= 2;
Console.WriteLine(x); // Output: 1073741822 Although the original number was negative, after an unsigned shift the bit pattern represents a large positive number.
Original: 
11111111 11111111 11111111 11111000
>> 2
00111111 11111111 11111111 11111110
Left side is filled with 0s.

| **Operator** | **Meaning**                     | **Equivalent Expression** | **Small Code**                                |
| ------------ | ------------------------------- | ------------------------- | --------------------------------------------- |
| `=`          | Assign                          | `x = y`                   | `int x; x = 10; Console.WriteLine(x);`        |
| `+=`         | Add and assign                  | `x = x + y`               | `int x = 10; x += 5; Console.WriteLine(x);`   |
| `-=`         | Subtract and assign             | `x = x - y`               | `int x = 10; x -= 5; Console.WriteLine(x);`   |
| `*=`         | Multiply and assign             | `x = x * y`               | `int x = 10; x *= 5; Console.WriteLine(x);`   |
| `/=`         | Divide and assign               | `x = x / y`               | `int x = 20; x /= 5; Console.WriteLine(x);`   |
| `%=`         | Modulus and assign              | `x = x % y`               | `int x = 17; x %= 5; Console.WriteLine(x);`   |
| `&=`         | Bitwise AND and assign          | `x = x & y`               | `int x = 12; x &= 10; Console.WriteLine(x);`  |
| `\|=`        | Bitwise OR and assign           | `x = x \| y`              | `int x = 12; x \|= 10; Console.WriteLine(x);` |
| `^=`         | Bitwise XOR and assign          | `x = x ^ y`               | `int x = 12; x ^= 10; Console.WriteLine(x);`  |
| `<<=`        | Left shift and assign           | `x = x << y`              | `int x = 5; x <<= 2; Console.WriteLine(x);`   |
| `>>=`        | Right shift and assign          | `x = x >> y`              | `int x = 20; x >>= 2; Console.WriteLine(x);`  |
| `>>>=`       | Unsigned right shift and assign | `x = x >>> y`             | `int x = -8; x >>>= 1; Console.WriteLine(x);` |



✅🔥🔷 Compound Assignment vs Type Conversion:
In C#: Compound assignment operators like +=, -=, *=, /= perform an implicit cast automatically (if possible).
But:
Normal assignment (=) does NOT automatically narrow types.

✅🔴 Case 1: Normal Assignment (Fails)
byte x = 10;
x = x + 20;   // ❌ Error, Cannot implicitly convert type 'int' to 'byte'
Why error happens?
x is byte
20 is int (default numeric type)
(x+ 20) → (byte + int) → result is int

But:
int → byte is a narrowing conversion
C# does NOT allow implicit narrowing


✅🔴 Correct version (Explicit Cast needed)
byte x = 10;
x = (byte)(x + 20);   // ✅ Works
Binary idea (simplified)
10 + 20 = 30 (int)
cast to byte → 30 fits → OK




🟢 Case 2: Compound Assignment (Works)
byte x = 10;
x += 20;   // ✅ Works fine
Why does this work?
Internally C# treats it like: x = (byte)(x + 20);

So compiler silently does:
Evaluate x + 20 → int
Explicitly cast result back to byte
Assign it to x