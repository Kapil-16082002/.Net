✅🔥 What is Reflection?
Reflection is a feature of .NET that allows a program to examine and interact with its own metadata at runtime.
Namespace: using System.Reflection;
Using Reflection, we can:
    Get information about classes
    Get methods
    Get properties
    Get fields
    Get constructors
    Create objects dynamically
    Invoke methods dynamically
    Retrieve custom attributes
    Simple Definition
Reflection is the process of inspecting the metadata of assemblies, types, and members at runtime.


✅🔥What is Retrieving Attributes?
Retrieving Attributes means reading the metadata stored by attributes at runtime using Reflection APIs.
When an attribute is applied to a class, method, or property, the compiler stores it inside the assembly metadata. Reflection allows us to access that metadata whenever we need it.


✅How Reflection Works Internally:
Source Code -> Compiler -> Assembly (.dll/.exe) -> Metadata -> Reflection APIs -> Read Attributes -> Application Uses Metadata


✅ Important Reflection Classes
| Class           | Purpose                                          |
| --------------- | ------------------------------------------------ |
| Type            | Represents information about a type              |
| Assembly        | Represents an assembly                           |
| MemberInfo      | Base class for methods, properties, fields, etc. |
| MethodInfo      | Information about methods                        |
| PropertyInfo    | Information about properties                     |
| FieldInfo       | Information about fields                         |
| ConstructorInfo | Information about constructors                   |
| ParameterInfo   | Information about parameters                     |


✅Reflection APIs Used with Attributes
The most commonly used methods are:
| Method                  | Purpose                       |
| ----------------------- | ----------------------------- |
| GetCustomAttributes()   | Returns all attributes        |
| GetCustomAttribute<T>() | Returns a specific attribute  |
| IsDefined()             | Checks if an attribute exists |
| GetType()               | Gets type information         |
| typeof()                | Gets Type object              |


------------------------------------------------------------
✅🔥 Example 1 – Getting Type Information
using System;
class Employee{}
class Program
{
    static void Main()
    {
        Type type = typeof(Employee);
        Console.WriteLine(type.Name);
        Console.WriteLine(type.FullName);
    }
}
Output:
Employee
Employee
Explanation:
Type type = typeof(Employee);// returns a Type object containing metadata about the Employee class.
The Type class is the starting point for most Reflection operations.

------------------------------------------------------------

✅🔥 Example 2 – Retrieve a Custom Attribute
✅Step 1: Create the Attribute
using System;
public class DeveloperAttribute : Attribute
{
    public string Name { get; }
    public string Company { get; set; }
    public DeveloperAttribute(string name)
    {
        Name = name;
    }
}
✅Step 2: Apply the Attribute

[Developer("Kapil", Company = "EPAM")]
public class Employee
{
}

✅Step 3: Read the Attribute
using System;
using System.Reflection;
class Program
{
    static void Main()
    {
        Type type = typeof(Employee);  // Gets the metadata of the Employee class.
        DeveloperAttribute attribute = (DeveloperAttribute)Attribute.GetCustomAttribute(type,typeof(DeveloperAttribute));
        Console.WriteLine($"Developer : {attribute.Name}");
        Console.WriteLine($"Company   : {attribute.Company}");
    }
}
Output:
Developer : Kapil
Company   : EPAM

---------------------------------------------------

✅🔥 GetCustomAttributes()
Returns all attributes applied to a program element.
using System;
[Serializable]
[Obsolete]
public class Employee
{
}

Retrieve them:

using System;
using System.Reflection;
class Program
{
    static void Main()
    {
        Type type = typeof(Employee);
        object[] attributes = type.GetCustomAttributes(false);
        foreach (object attribute in attributes)
        {
            Console.WriteLine(attribute.GetType().Name);
        }
    }
}
Output:
SerializableAttribute
ObsoleteAttribute
--------------------------------------------------

✅🔥 GetCustomAttributes<T>()
Modern C# provides a generic version.

DeveloperAttribute attribute =  type.GetCustomAttribute<DeveloperAttribute>();
No casting is required.

Complete Example:
DeveloperAttribute attribute = typeof(Employee).GetCustomAttribute<DeveloperAttribute>();
Console.WriteLine(attribute.Name);
Much cleaner than using Attribute.GetCustomAttribute.


---------------------------------------------------------

✅🔥 IsDefined()
Checks whether a specific attribute exists.
Returns: true or false
Example:
using System;
[Serializable]
public class Employee
{
}
class Program
{
    static void Main()
    {
        bool exists = typeof(Employee).IsDefined(typeof(SerializableAttribute),false);
        Console.WriteLine(exists);
    }
}
Output: True

----------------------------------------------------------

✅🔥 Reading Method Attributes
Reflection isn't limited to classes.

Suppose:
using System;
class Employee
{
    [Obsolete]
    public void Display()
    {

    }
}
Retrieve:
MethodInfo method = typeof(Employee).GetMethod("Display");
bool result = method.IsDefined( typeof(ObsoleteAttribute),false);
Console.WriteLine(result);
Output: True
-------------------------------------------------------------

✅🔥 Reading Property Attributes:
using System.ComponentModel.DataAnnotations;
class Employee
{
    [Required]
    public string Name { get; set; }
}
Reflection:
PropertyInfo property = typeof(Employee).GetProperty("Name");
bool exists = property.IsDefined( typeof(RequiredAttribute),false);
Console.WriteLine(exists);

----------------------------------------------------------------

✅🔥 Reading Multiple Custom Attributes

Suppose:
[Developer("Kapil")]
[Developer("Rahul")]
public class Employee
{
}

Read:
DeveloperAttribute[] developers = typeof(Employee).GetCustomAttributes<DeveloperAttribute>().ToArray();
foreach (DeveloperAttribute developer in developers)
{
    Console.WriteLine(developer.Name);
}
Output:
Kapil
Rahul

Note: This works only if the attribute was declared with:
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]












