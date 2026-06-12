✅🔥🚀 What is readonly?
A readonly field is a field whose value:
Can be assigned only once
Can be assigned:
     At declaration
     Inside the constructor
Cannot be modified after object creation
Syntax:
readonly int age;
or
readonly int age = 25;



const            = Compile-Time Constant
readonly         = Runtime Constant (Per Object)
static readonly  = Runtime Constant (Shared by All Objects)

-------------------------------------------------------

✅🔥📌 Initialization Options
A readonly field can be initialized in only two places.
Option 1: At Declaration
class Demo
{
    readonly int Age = 25;
}
Option 2: Inside Constructor
class Demo
{
    readonly int Age;
    public Demo()
    {
        Age = 25;
    }
}
Flow:
Object Created
       ↓
Constructor Called
       ↓
Readonly Assigned
       ↓
Object Ready
After constructor completes:Readonly Field Locked


✅🔥📌Can readonly be assigned multiple times?
Inside constructor? Yes.
public Demo()
{
    Age = 20;
    Age = 25;
}
Last assignment wins.
---------------------------------------------------------

✅🔥🚀Why was readonly introduced ?

Suppose an Employee's ID should never change after the object is created.
❌Without readonly:
class Employee
{
    public int Id;
}
Employee emp = new Employee();
emp.Id = 1001;
emp.Id = 2000; // Accidentally changed , This can create bugs.


With readonly:
class Employee
{
    public readonly int Id;
    public Employee(int id)
    {
        Id = id;
    }
}
Employee emp = new Employee(1001);
emp.Id = 2000; // Error
Object becomes safer.
-----------------------------------------------------------------

✅🔥📌 Runtime Constant
readonly is a runtime constant. Because its value can be determined during runtime.
Example:
✔Valid.
class Demo
{
    readonly DateTime CreatedOn;
    public Demo()
    {
        CreatedOn = DateTime.Now;
    }
}

❌Invalid.
const DateTime CreatedOn = DateTime.Now;
Because const requires compile-time values.

----------------------------------------------------------------------

✅🔥📌 readonly vs static readonly
readonly: Each object gets its own copy(Different values).

class Employee
{
    public readonly int Id;
    public Employee(int id)
    {
        Id = id;
    }
}
Object 1:
Id = 101

Object 2:
Id = 102



✅ static readonly: is shared among all objects of the class. It belongs to the class, not individual objects.

class Company
{
    public static readonly string Name =
        "ABC Ltd";
}
Every object shares same value.
Memory:
Class Level
      │
      ▼
 "ABC Ltd"
Only one copy.

---------------------------------------------------------------------
✅🔥📌 Important Note: 
readonly makes the object mutable(change). 
The reference(address) will remain same 

Example:
class Employee
{
    public string Name;
}
readonly Employee emp = new Employee();
This means: Reference Cannot Change and Object can Change.
✔ Valid: emp.Name = "Kapil"; The object can still change.
❌Invalid: emp = new Employee(); The reference cannot change.


Example:
readonly List<int> numbers = new List<int>();
✔ Valid:Because List object changes.
numbers.Add(10);
numbers.Add(20);
