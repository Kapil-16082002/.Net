✅🔥📌 What is a Static Variable?
A static variable is a class variable that is shared among all objects of the class.
It belongs to the class, not individual objects.
It gets memory allocation only once and retains(persists) its value across all objects.


🔥 Why do we use static?
Suppose every employee has a different name but all employees belong to the same company.
Should every object store "EPAM"? ❌ No.
Only one copy is enough. That's why we use static.

Example:
Suppose we have 10,000 employees.
Creating 10,000 objects:
Memory:
The company name is duplicated 10,000 times.
❌ Waste of memory.


❌ Without Static
using System;
class Employee
{
    public string Name;
    public string Company = "Google";
}
class Program
{
    static void Main()
    {
        Employee e1 = new Employee();
        Employee e2 = new Employee();
        Employee e3 = new Employee();

        Console.WriteLine(e1.Company);
        Console.WriteLine(e2.Company);
        Console.WriteLine(e3.Company);
    }
}
🧠 Problem:
Each object contains its own copy.
e1 -> Name | Company
e2 -> Name | Company
e3 -> Name | Company

Memory:
Object 1
 ├─ Name
 └─ Company

Object 2
 ├─ Name
 └─ Company

Object 3
 ├─ Name
 └─ Company
❌ Company is duplicated.


✅ Better Solution Using Static
using System;
class Employee
{
    public string Name;
    public static string Company = "Google";
}
class Program
{
    static void Main()
    {
        Employee e1 = new Employee();
        Employee e2 = new Employee();
        Employee e3 = new Employee();
        Console.WriteLine(Employee.Company);
    }
}

==================================================================================================================

✅🔥📌 Types of Static Members
✅ Static Variable
✅ Static Method
✅ Static Constructor
✅ Static Class


✅🔥📌 Static Method:
A static method belongs to the class itself, not to any object of the class.
You can call it directly using the class name without creating an object.
class Calculator
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
}
Console.WriteLine(Calculator.Add(10, 20)); // No object creation
Output: 30


✅🔥📌When Should You Use Static Methods?

Use static methods when:
1. No Object Data Needed
Math.Sqrt()
2. Common Operations
Convert.ToInt32()


✅🔥📌Static Method vs Instance Method
Instance Method: Belongs to an object.
class Employee
{
    public string Name;
    public void Display()
    {
        Console.WriteLine(Name);
    }
}
Employee emp = new Employee();
emp.Name = "Kapil"; // Here the method needs object data (Name).
emp.Display();

Output: Kapil

---------------------------------------------------------------

✅🔥📌 Static Method Cannot Access Non-Static Members Directly
Because static methods belong to the class, while non-static members belong to objects.
if we create multiple objects then multiple objects may have different values for instance members, the compiler cannot determine which object's member should be accessed.
Therefore, an object reference is required to access non-static members from a static method.


📌 Rule:
✅ A static method can directly access only:
Static variables
Static methods

❌ A static method cannot directly access:
Instance variables (non-static variables)
Instance methods (non-static methods)


class Employee
{
    public string Name = "Kapil";
    public static void Show()
    {
        Console.WriteLine(Name);
    }
}
Compiler Error: An object reference is required


✅Correct Way: Pass an object.
class Employee
{
    public string Name = "Kapil";
    public static void Show(Employee emp)
    {
        Console.WriteLine(emp.Name);
    }
}
----------------------------------------------------------------

✅🔥📌Can Static Methods Be Overloaded ? ✅Yes

class Calculator
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
    public static double Add(double a, double b)
    {
        return a + b;
    }
}
Usage:
Calculator.Add(10,20);
Calculator.Add(10.5,20.5);

----------------------------------------------------------------

✅🔥📌Can Static Methods Be Overridden?
❌ No
Reason:
Overriding requires runtime polymorphism.
Static methods belong to class, Not to object.

-------------------------------------------------------------

✅🔥📌Can Static Methods Be Virtual?
❌ No
Invalid:
public static virtual void Show()
{
}
Compiler Error.
Reason:
virtual → runtime dispatch
static  → compile-time binding
Both concepts conflict.

------------------------------------------------------------

✅🔥📌Can Static Methods Use this?
❌ No

Invalid:
public static void Show()
{
    Console.WriteLine(this.Name);
}
Reason:
this = current object
Static methods have no object.
------------------------------------------------------------

✅🔥📌Can Constructor Be Static?
✅ Yes

class Employee
{
    static Employee()
    {
        Console.WriteLine("Static Constructor");
    }
}
Runs:
Only once
when the class is first loaded.

--------------------------------------------------------------

