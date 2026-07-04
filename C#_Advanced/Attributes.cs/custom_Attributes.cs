✅🔥 What is a Custom Attribute?
A Custom Attribute is a user-defined class that inherits from the System.Attribute class and is used to attach custom metadata to program elements such as classes, methods, properties, parameters, or assemblies.

Simple Definition:
A Custom Attribute is an attribute created by the programmer to store application-specific metadata that can later be accessed using Reflection.


✅🔥Why Do We Need Custom Attributes ?
The .NET Framework provides many predefined attributes, but every application has different business requirements.
For example:
Suppose you are developing:
    Hospital Management System
    Banking Software
    Employee Management System
    Student Management System
You may want to store additional information such as:
Author Name
Version
Last Modified Date
Department
Permission Level
Database Table Name
API Version
Role Required
None of these are available as predefined attributes. Therefore, we create Custom Attributes.

------------------------------------------------------------------------

✅🔥 How to Create a Custom Attribute
Creating a custom attribute is very simple.
There are only three steps.
Step 1 : Create a class
Step 2:  Inherit from Attribute // Without inheriting from Attribute, the compiler will not recognize it as an attribute.
Step 3:  Apply the attribute

✅Example:
using System;
public class DeveloperAttribute : Attribute
{
}
Explanation:
DeveloperAttribute inherits Attribute class . Now it becomes a valid C# Attribute.


✅ Example 1 — Simple Custom Attribute:
using System;
public class DeveloperAttribute : Attribute
{
}
[Developer]
public class Employee
{
}
class Program
{
    static void Main()
    {
        Console.WriteLine("Employee Class");
    }
}

-------------------------------------------------
✅🔥Naming Convention:

Every attribute class ends with Attribute. Example: DeveloperAttribute
But When using it, You may write
[Developer] instead of [DeveloperAttribute] Both are exactly the same.

-------------------------------------------------

✅🔥Positional Parameters:
A Positional Parameter is a value passed through the constructor of an attribute.

It is:
   Mandatory (if required by the constructor)
   Written first
   Passed in order
Example 2:
using System;
public class DeveloperAttribute : Attribute
{
    public string Name;
    public DeveloperAttribute(string name)
    {
        Name = name;
    }
}
[Developer("Kapil")]
public class Employee
{

}
Explanation:
Constructor DeveloperAttribute(string name) expects one argument.Therefore,[Developer("Kapil")] passes Name = Kapil


-------------------------------------------------

✅ Multiple Positional Parameters
using System;
public class DeveloperAttribute : Attribute
{
    public string Name;
    public int Age;
    public DeveloperAttribute(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
[Developer("Kapil",25)]
public class Employee
{

}
--------------------------------------------------

✅🔥 Named Parameters:
A Named Parameter is a public property or field that can be assigned while applying the attribute.
Unlike constructor parameters,

Named parameters are:
   Optional
   Can appear in any order
   Written after positional parameters

Example:
using System;
public class DeveloperAttribute : Attribute
{
    public string Name;
    public string Company { get; set; }
    public string Version { get; set; }
    public DeveloperAttribute(string name)
    {
        Name = name;
    }
}
[Developer("Kapil", Company="EPAM", Version="2.0")]
public class Employee
{

}
Here, Constructor parameter Kapil is positional.
Properties: Company , Version are named parameters.


Complete code:
using System;
public class DeveloperAttribute : Attribute
{
    public string Name { get; }
    public string Company { get; set; }
    public string Version { get; set; }
    public DeveloperAttribute(string name)
    {
        Name = name;
    }
}
[Developer( "Kapil", Company = "EPAM", Version = "1.0")]
public class Employee
{
}
class Program
{
    static void Main()
    {
        Console.WriteLine("Employee Class");
    }
}


Constructor vs Property:
| Constructor Parameter      | Property                            |
| -------------------------- | ----------------------------------- |
| Positional Parameter       | Named Parameter                     |
| Mandatory                  | Optional                            |
| Constructor initializes it | Assigned after object creation      |
| Order matters              | Order does not matter               |
| Written first              | Written after positional parameters |






















