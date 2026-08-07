
✅🔥🚀 Structure (struct) in C#
A Structure (struct) is a user-defined value type data_type that groups related variables together into a single unit.
Think of a struct as a lightweight class that is stored by value instead of by reference.
Unlike classes:
✅ Value Type
✅ Copied by Value
✅ Cannot participate in inheritance
✅ Implicit default constructor always exists



✅🔥🚀 Built-in Structs in C#
Many types you use daily are structs.
Example: int x = 10;
Actually: System.Int32  And Int32 is a struct.
int
double
decimal
bool
char
DateTime
Guid
TimeSpan

----------------------------------------------------------------------------------------------------------------

✅ Why Do We Need Structures?
❌Without struct: These variables are separate.
int employeeId = 101;
string employeeName = "Kapil";
double salary = 850000;


With struct:  Now all employee-related data is grouped together.
struct Employee
{
    public int Id;
    public string Name;
    public double Salary;
}


📌 When to Use Struct?
Use struct when:
✅ Object is small
✅ Represents single value
✅ Immutable preferred
✅ No inheritance required

===============================================================================================================

✅🔥 Value Copy Behavior:
struct Point
{
    public int X;
    public int Y;
}
Point p1;
p1.X = 10;
p1.Y = 20;
Point p2 = p1;  // Entire data is copied.
Memory:
p1 → [10,20]
p2 → [10,20]


Now if we Modify p2:
p2.X = 999;

Result:
p1.X = 10
p2.X = 999
✅ Independent copies



❌ Class Behavior:
class Point
{
    public int X;
}
Point p1 = new Point();
Point p2 = p1;// Both refer to same object.
p2.X = 999;

Result:
p1.X = 999
p2.X = 999

==================================================================================================================

✅⚠️ Special Rules for Struct Constructors:
Struct constructors are different from class constructors.

Rule 1: All Fields Must Be Initialized
struct Employee
{
    public int Id;
    public string Name;

    public Employee(int id)
    {
        Id = id;

        // ❌ Error, Name not initialized
        // Name = "";
    }
}
❌Compiler Error: Field 'Name' must be fully assigned before control is returned


Rule 2: Struct Cannot Have Field Initializers Without Constructor
❌ Older C# versions:
struct Employee
{
    public int Id = 1;
}
Not allowed.
Modern C# allows it with appropriate constructors.


Rule 3: Struct Always Has a Default Constructor
Even if you don't write one.
struct Employee
{
    public int Id;
    public string Name;
}
Employee emp = new Employee();

Compiler automatically creates:
Id = 0;
Name = null;

===================================================================================================================

✅🔥Types of Constructors in Struct
1️⃣ Implicit Default Constructor: Created automatically by CLR.
Example:
struct Employee
{
    public int Id;       // by default value = 0
    public string Name;  // by default value = null
}
Usage:
Employee emp = new Employee();
Console.WriteLine(emp.Id);  // 0
Console.WriteLine(emp.Name); // null

---------------------------------------------------

✅2️⃣ Explicit Parameterized Constructor
A parameterized constructor allows passing arguments to initialize an object with specific values.

struct Employee
{
    public int Id;
    public string Name;
    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
Usage:
Employee emp = new Employee(101, "Kapil");
Output:
101
Kapil

-------------------------------------------------------
✅2️⃣ Primary Constructor (C# 12)

struct Employee(int id, string name)
{
    public int Id = id;
    public string Name = name;
}
Usage: 
Employee emp = new Employee(101, "Kapil");
Compiler Generates Equivalent to:

struct Employee
{
    public int Id;
    public string Name;

    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
-------------------------------------------------------

✅3️⃣ Explicit Parameterless Constructor (C# 10+)

Before C# 10: ❌ Not allowed
struct Employee
{
    public Employee()  // Compiler Error
    {
    }
}
After C# 10: ✅ Allowed
struct Employee
{
    public int Id;
    public string Name;

    public Employee()
    {
        Id = -1;
        Name = "Unknown";
    }
}
Usage:
Employee emp = new Employee();
Output:
-1
Unknown
-----------------------------------------

✅4️⃣ Copy Constructor
A struct can accept another struct.
A copy constructor is used to create a new object as a copy of an existing object.

struct Employee
{
    public int Id;
    public string Name;
    public Employee(Employee other)
    {
        Id = other.Id;
        Name = other.Name;
    }
}
Usage:
Employee e1 = new Employee(1, "Kapil");
Employee e2 = new Employee(e1);

But Struct Already Copies Automatically
Employee e2 = e1;

This automatically copies all fields.
Therefore copy constructors are rarely needed.
------------------------------------------------------

✅5️⃣ Constructor Chaining:
Constructor Chaining is a technique where one constructor calls another constructor of the same class or the base class.

struct Employee
{
    public int Id;
    public string Name;
    public Employee(int id) : this(id, "Unknown")
    {
    }
    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
Usage:
Employee emp = new Employee(10);
Output:
10
Unknown

==================================================================================================================
🚀 Properties in Struct
🚀 Readonly Struct
🚀 Immutable Struct (Best Practice)
🚀 Boxing and Unboxing
🚀 Struct Can Implement Interfaces
❌ Struct Cannot Inherit Another Struct/Class
❌ Destructor Not Allowed
🚀 Nullable Struct
