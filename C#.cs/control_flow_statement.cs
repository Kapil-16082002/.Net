✅🔥🚀 Control Flow Statements in C#
A Control Flow Statement determines the order in which statements are executed in a program.
By default, a C# program executes statements from top to bottom (Sequential Execution).


✅📌 Types of Control Flow Statements
│
├── 1. Selection Statements
│      ├── if
│      ├── if-else
│      ├── else-if ladder
│      ├── nested if
│      └── switch
│
├── 2. Iteration Statements (Loops)
│      ├── for
│      ├── while
│      ├── do-while
│      └── foreach
│
├── 3. Jump Statements
│      ├── break
│      ├── continue
│      ├── return
│      └── goto
│
└── 4. Exception Handling
       ├── try
       ├── catch
       ├── finally
       └── throw
=================================================================================================================

✅🔥1️⃣ Selection Statements
Selection statements execute code based on a condition.

✅A. if Statement: Executes code only when the condition is true.

Syntax:
if(condition)
{
    // code
}
Example:
int age = 20;
if(age >= 18)
{
    Console.WriteLine("Eligible to vote");
}
Output:
Eligible to vote
Internal Working

Condition?
    │
 ┌──┴──┐
True  False
 │       │
Execute Skip

------------------------------------------------------

✅B. if-else Statement Used when we have two choices.

Syntax:
if(condition)
{
}
else
{
}
Example:
int age = 16;
if(age >= 18)
{
    Console.WriteLine("Adult");
}
else
{
    Console.WriteLine("Minor");
}
Output: Minor

------------------------------------------------------

✅C. else-if Ladder: Used for multiple conditions.

int marks = 82;
if(marks >= 90)
{
    Console.WriteLine("Grade A");
}
else if(marks >= 75)
{
    Console.WriteLine("Grade B");
}
else if(marks >= 60)
{
    Console.WriteLine("Grade C");
}
else
{
    Console.WriteLine("Fail");
}
------------------------------------------------------
✅D. Nested if
if inside another if.

int age = 22;
bool hasLicense = true;
if(age >= 18)
{
    if(hasLicense)
    {
        Console.WriteLine("Can drive");
    }
}
----------------------------------------------------------
✅E. switch Statement: Used instead of multiple if-else statements.
A switch statement is a selection (decision-making) statement used to execute one block of code from multiple possible choices based on the value of an expression.

Syntax:
switch(expression)
{
    case value:
        break;

    default:
        break;
}
Example:
int day = 3;
switch(day)
{
    case 1:
        Console.WriteLine("Monday");
        break;
    case 2:
        Console.WriteLine("Tuesday");
        break;
    case 3:
        Console.WriteLine("Wednesday");
        break;
    default:
        Console.WriteLine("Invalid");
        break;
}
Output: Wednesday
switch(day)

      │
      ▼
 Is day == 1 ?
      │
      ❌
      ▼
 Is day == 2 ?
      │
      ❌
      ▼
 Is day == 3 ?
      │
      ✅
      ▼
Print "Wednesday"
      │
      ▼
break
      │
      ▼
Exit switch













