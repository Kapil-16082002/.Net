✅🔥Logical Operators:


✅1. Logical AND (&&): Returns true only if both operands are true.
✅2. Logical OR (||):  Returns true if at least one operand is true.
✅3. Logical NOT (!):  Reverses the Boolean value.
✅4. Logical AND (&):  When used with bool, & behaves like logical AND but evaluates both operands.
It returns:
true → if both operands are true
false → otherwise
| A       | B       | A & B   |
| ------- | ------- | ------- |
| `false` | `false` | `false` |
| `false` | `true`  | `false` |
| `true`  | `false` | `false` |
| `true`  | `true`  | `true`  |



✅5. Logical OR (|): When used with bool, | behaves like logical OR but evaluates both operands.
It returns:
true → if at least one operand is true
false → only if both operands are false
| A       | B       | A | B   |
| ------- | ------- | ------- |
| `false` | `false` | `false` |
| `false` | `true`  | `true`  |
| `true`  | `false` | `true`  |
| `true`  | `true`  | `true`  |


| **Operator** | **Meaning**                           | **Expression** | **Small Code**                        |
| ------------ | ------------------------------------- | -------------- | ------------------------------------- |
| `&&`         | Logical AND (Short-circuit)           | `a && b`       | `Console.WriteLine(true && false);`   |
| `||`         | Logical OR (Short-circuit)            | `a || b`       | `Console.WriteLine(true || false);`   |
| `!`          | Logical NOT                           | `!a`           | `Console.WriteLine(!true);`           |
| `&`          | Logical AND (Evaluates both operands) | `a & b`        | `Console.WriteLine(true & false);`    |
| `|`          | Logical OR (Evaluates both operands)  | `a | b`        | `Console.WriteLine(true | false);`    |
| `^`          | Logical XOR (Exclusive OR)            | `a ^ b`        | `Console.WriteLine(true ^ false);`    |

