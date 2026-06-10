✅🔥 Loops in C#

A Loop is a programming construct that repeats a block of code multiple times until a specified condition becomes false.
Without loops, you would have to write the same code repeatedly.
❌ Without Loop
Console.WriteLine(1);
Console.WriteLine(2);
Console.WriteLine(3);
Console.WriteLine(4);
Console.WriteLine(5);

📌 Types of Loops in C#
Loops
│
├── for Loop
├── while Loop
├── do-while Loop
├── foreach Loop
└── Nested Loops

----------------------------------------------------------------------

✅🔥1️⃣ for Loop
The for loop is used when the number of iterations is known in advance.

Syntax:
for(initialization; condition; increment/decrement)
{
    // code
}
Example:
for(int i = 1; i <= 5; i++)
{
    Console.WriteLine(i);
}

Infinite for Loop:
for(;;)
{
    Console.WriteLine("Hello");
}
---------------------------------------------------------------------
✅2️⃣ while Loop
The while loop executes as long as the condition remains true.
Used when the number of iterations is unknown.

Syntax:
while(condition)
{
    // code
}
int i = 1;
while(i <= 5)
{
    Console.WriteLine(i);

    i++;
}

Infinite while Loop:
while(true)
{
    Console.WriteLine("Running");
}
---------------------------------------------------------------------------
✅3️⃣ do-while Loop

The do-while loop executes the body first and checks the condition afterward.
It always executes at least one time.

do
{
}
while(condition);

Example:
int i = 1;
do
{
    Console.WriteLine(i);
    i++;
}
while(i <= 5);
----------------------------------------------------------------------------

✅4️⃣ foreach Loop
Used for traversing collections.
The variable is read-only i.e can not modify data
     Arrays
     Lists
     Dictionaries
     Queues
     Stacks
Syntax:
foreach(data_type variable in collection)
{
}
Example with Array:
string[] names = {"Kapil", "Rahul", "Aman"};
foreach(string name in names)
{
    Console.WriteLine(name);
}


