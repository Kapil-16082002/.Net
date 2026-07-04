✅🔥Attributes in C#
An Attribute is a special class in C# that is used to add additional information (metadata) to program elements
, so that the compiler, CLR, or other tools can use that information at compile time or runtime.such as:
Assembly
Class
Structure
Interface
Enum
Method
Constructor
Property
Field
Parameter
Return Value
This metadata does not change the behavior of the code directly. Instead, it provides extra information that can be read by the .NET runtime, compiler, or other programs using Reflection.


✅Real-World Uses of Custom Attributes
    Mark API versions.
    Store author information.
    Define permissions or roles.
    Configure validation rules.
    Map classes to database tables.
    Create custom logging behavior.
    Build plugin systems.
    Implement dependency injection metadata.
--------------------------------------------------------------------------

✅🔥 What is Metadata?
Before understanding Attributes, we must understand Metadata.
Metadata means: "Data about Data."
It is information that describes another piece of data.

Example:
Suppose you have a photo.
The photo itself is data.
The following information is metadata:
   File Name
   File Size
   Resolution
   Camera Model
   Date Taken
   Photo.jpg

✅🔥 Metadata in C#:
Similarly,Suppose we have a class
public class Employee
{
    public int Id;
    public string Name;
    public void Display()
    {

    }
}
The compiler automatically stores metadata such as:
Class Name = Employee
Namespace
Fields
Id
Name
Methods
Display()
Accessibility
public
Assembly Name
Version
Inheritance
etc.
This metadata is stored inside the assembly (.dll or .exe).


✅🔥 Where is Metadata Stored?
Whenever we build a C# project
Employee.cs -> Compiler -> Employee.dll(Dynamic Link Library.)

Inside the DLL:
IL Code
Metadata
Manifest

Every .NET assembly contains
IL Code
Metadata
Manifest
============================================================================================================

✅🔥 Why Are Attributes Needed?
Attributes are used to tell the compiler, CLR, or other frameworks something special about our code.

Examples:
This class can be serialized.
This method is obsolete.
This method should only run in DEBUG mode.
This class is an API Controller.
This property is required.
This method maps to an HTTP GET request.
This property is a database key.
Without Attributes, frameworks like ASP.NET Core, Entity Framework Core, xUnit, and JSON serializers would not know how to process your classes.



✅Syntax of an Attribute:
General syntax:
[AttributeName]
program_element

Example:
[Serializable]
public class Employee
{

}
-------------------------------
✅Multiple attributes:

[Serializable]
[Obsolete]
public class Employee
{

}
OR
[Serializable, Obsolete]
public class Employee
{

}
------------------------------------

✅ Where Can We Apply Attributes?
Almost everywhere.
By default, an attribute can be applied to many program elements. Often, we want to restrict where it is valid.
This is done using AttributeUsage.

Definition:
AttributeUsage is a predefined attribute that specifies:
   Where a custom attribute can be applied.
   Whether multiple instances are allowed.
   Whether derived classes inherit the attribute.

Common AttributeTargets:
| Target        | Meaning               |
| ------------- | --------------------- |
| `Assembly`    | Assembly              |
| `Module`      | Module                |
| `Class`       | Class                 |
| `Struct`      | Structure             |
| `Interface`   | Interface             |
| `Enum`        | Enumeration           |
| `Method`      | Method                |
| `Constructor` | Constructor           |
| `Property`    | Property              |
| `Field`       | Field                 |
| `Event`       | Event                 |
| `Parameter`   | Method Parameter      |
| `Delegate`    | Delegate              |
| `All`         | Every program element |


| Cannot Apply To                               | Reason                                                                                                                          |
| --------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------- |
| ❌ Local Variables                             | Local variables exist only during method execution and are not valid attribute targets.                                         |
| ❌ Statements (`if`, `for`, `while`, `switch`) | Attributes apply to declarations, not executable statements.                                                                    |
| ❌ Expressions                                 | You cannot decorate expressions like `a + b`, `x * y`, or `Method()`.                                                           |
| ❌ Operators (`+`, `-`, `*`, `/`)              | Operators themselves cannot have attributes. (However, an **operator method declaration** like `operator +` can be attributed.) |
| ❌ Namespaces                                  | C# does not allow attributes directly on namespace declarations.                                                                |
| ❌ Generic Type Arguments                      | You cannot place attributes on type arguments such as `<string>` in `List<string>`.                                             |
| ❌ Individual Parts of an Expression           | You cannot decorate variables inside an expression like `a` in `a + b`.                                                         |



✅ Example 1 – Applying an Attribute to a Class
using System;
[Serializable]
public class Employee
{
    public int Id;
    public string Name;
}
class Program
{
    static void Main()
    {
        Console.WriteLine("Employee class created.");
    }
}
Notice that the program output is still ,Employee class created.
The attribute does not directly affect program execution; it simply adds metadata that other components can inspect and use.


-------------------------------------------------------

✅ Example 2 – Applying an Attribute to a Method
using System;
class Calculator
{
    [Obsolete("Use AddNumbers() instead.")]
    public void Add()
    {
        Console.WriteLine("Old Add Method");
    }
    public void AddNumbers()
    {
        Console.WriteLine("New Add Method");
    }
}
class Program
{
    static void Main()
    {
        Calculator calculator = new Calculator();
        calculator.Add();
    }
}
Explanation:
[Obsolete] tells the compiler: "This method is outdated. Developers should use another method instead."
During compilation, you'll receive a warning like:
'Calculator.Add()' is obsolete:
'Use AddNumbers() instead.'

--------------------------------------------------------

Example 3 – Applying an Attribute to a Property
using System;
using System.ComponentModel.DataAnnotations;
public class Employee
{
    [Required]
    public string Name { get; set; }

    [Range(18,60)]
    public int Age { get; set; }
}
Here,
[Required]means: Name cannot be empty.
[Range(18,60)] means Age must be between 18 and 60









