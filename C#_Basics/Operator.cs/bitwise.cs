✅🔥Bitwise Operators in C#
Bitwise operators work directly on the binary (bit) representation of integer values.
They perform operations bit by bit instead of on the whole number.
These operators are commonly used in:
Flags and permissions
Low-level programming
Device drivers
Networking
Cryptography
Performance optimization


✅1. Logical AND (&):  When used with bool, & behaves like logical AND but evaluates both operands.
It returns:
true → if both operands are true
false → otherwise
| A       | B       | A & B   |
| ------- | ------- | ------- |
| `false` | `false` | `false` |
| `false` | `true`  | `false` |
| `true`  | `false` | `false` |
| `true`  | `true`  | `true`  |



✅2. Logical OR (|): When used with bool, | behaves like logical OR but evaluates both operands.
It returns:
true → if at least one operand is true
false → only if both operands are false
| A       | B       | A | B   |
| ------- | ------- | ------- |
| `false` | `false` | `false` |
| `false` | `true`  | `true`  |
| `true`  | `false` | `true`  |
| `true`  | `true`  | `true`  |


✅2Bitwise XOR (^): Returns 1 only when bits are different.
| A | B | A ^ B |
| - | - | ----- |
| 0 | 0 | 0     |
| 0 | 1 | 1     |
| 1 | 0 | 1     |
| 1 | 1 | 0     |


| **Operator** | **Meaning**                   | **Expression** | **Small Code**                 |
| ------------ | ----------------------------- | -------------- | ------------------------------ |
| `&`          | Bitwise AND                   | `a & b`        | `Console.WriteLine(12 & 10);`  |
| `|`         | Bitwise OR                    | `a | b`       | `Console.WriteLine(12 | 10);` |
| `^`          | Bitwise XOR                   | `a ^ b`        | `Console.WriteLine(12 ^ 10);`  |
| `~`          | Bitwise NOT (Complement)      | `~a`           | `Console.WriteLine(~5);`       |
| `<<`         | Left Shift                    | `a << n`       | `Console.WriteLine(5 << 2);`   |
| `>>`         | Right Shift                   | `a >> n`       | `Console.WriteLine(20 >> 2);`  |
| `>>>`        | Unsigned Right Shift (C# 11+) | `a >>> n`      | `Console.WriteLine(-8 >>> 1);` |
