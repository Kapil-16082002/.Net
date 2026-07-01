✅🔥 What is XML?
XML stands for: eXtensible Markup Language
XML is a text-based markup language used to store and exchange structured data.
Example:
<Employee>
    <Id>1</Id>
    <Name>John</Name>
</Employee>


Unlike JSON:
{
   "Id":1,
   "Name":"John"
}
XML uses tags instead of key-value pairs.



XML (Still Used in Enterprise & Legacy Systems)
XML is mainly used where structured documents, validation, or legacy compatibility is required.
Used in:
✅ SOAP Web Services
✅ Banking and financial systems
✅ Healthcare systems
✅ Government applications
✅ Legacy .NET configuration (Web.config)
✅ Microsoft Office documents (.docx, .xlsx, .pptx)
✅ Android layout files
✅ Project files (.csproj)
✅ RSS feeds

--------------------------------------------------

✅🔥 What is XML Serialization?
XML Serialization is the process of converting a C# object into XML.

Object:
Employee Object
Id = 1
Name = John
Salary = 50000
↓
Serialize
↓
<Employee>
    <Id>1</Id>
    <Name>John</Name>
    <Salary>50000</Salary>
</Employee>

---------------------------------------------------

✅🔥3. What is XML Deserialization?
XML Deserialization is the process of converting a XML into C# object.
XML
↓
<Employee>
    <Id>1</Id>
    <Name>John</Name>
</Employee>
↓
Deserialize
↓
Employee Object
Id = 1
Name = John

----------------------------------------------------

✅🔥 Why do we need XML Serialization?
Imagine two systems.
.NET Banking System
↓
Internet
↓
Java Banking System

The Java application cannot understand a C# object in memory.
Instead:
Employee Object
↓
XML
↓
Internet
↓
Java Object
XML acts as a common language.

--------------------------------------------------------

✅🔥 XML Serialization Libraries
There are several XML-related libraries in .NET, each with a different purpose.
| Library                                  | Purpose                                                         |
| ---------------------------------------- | --------------------------------------------------------------- |
| `System.Xml.Serialization.XmlSerializer` | Serialize and deserialize objects to and from XML (most common) |
| `System.Xml.Linq` (LINQ to XML)          | Read, create, and modify XML documents manually                 |
| `System.Xml.XmlDocument`                 | Traditional DOM-based XML manipulation                          |
| `System.Xml.XmlReader`                   | Fast, forward-only XML reading                                  |
| `System.Xml.XmlWriter`                   | Efficient XML writing                                           |


Code Example:
using System;
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
}
using System;
using System.IO;
using System.Xml.Serialization;
class Program
{
    static void Main()
    {
        Employee emp =
            new Employee
            {
                Id = 1,
                Name = "John"
            };
        XmlSerializer serializer = new XmlSerializer(typeof(Employee));
        using (FileStream fs = new FileStream("emp.xml", FileMode.Create))
        {
            serializer.Serialize(fs, emp);
        }
        Console.WriteLine("XML Created");
    }
}
Generated file:
<?xml version="1.0"?>
<Employee>
   <Id>1</Id>
   <Name>John</Name>
</Employee>


✅🔥 What happens internally ?
Object:
Id = 1
Name = John
↓
Reflection reads public members.
↓
Creates XML elements.
↓
Writes to file or stream.

------------------------------------------------------

✅🔥 XML Deserialization:
using System;
using System.IO;
using System.Xml.Serialization;

class Program
{
    static void Main()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Employee));
        using (FileStream fs = new FileStream("emp.xml", FileMode.Open))
        {
            Employee emp = (Employee)serializer.Deserialize(fs);
            Console.WriteLine(emp.Name);
        }
    }
}
----------------------------------------------

✅🔥 Serializing Multiple Objects
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
}
class Program
{
    static void Main()
    {
        List<Employee> employees =
            new List<Employee>
            {
                new Employee{Id=1,Name="John"},
                new Employee{Id=2,Name="Alice"}
            };
        XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
        using(FileStream fs = new FileStream("employees.xml", FileMode.Create))
        {
            serializer.Serialize(fs, employees);
        }
    }
}
===========================================================================

✅🔥 XML Serialization Attributes:
[XmlRoot]: Changes the root element.

using System.Xml.Serialization;
[XmlRoot("Staff")]
public class Employee
{
    public int Id { get; set; }
}
Output:
<Staff>
   <Id>1</Id>
</Staff>

---------------------------------------------

✅🔥 [XmlElement] : Changes the element name.
public class Employee
{
    [XmlElement("EmployeeId")]
    public int Id { get; set; }
}
Output:
<Employee>

   <EmployeeId>1</EmployeeId>

</Employee>
---------------------------------------------

✅🔥 [XmlAttribute]: Stores a property as an XML attribute instead of an element.
public class Employee
{
    [XmlAttribute]
    public int Id { get; set; }
    public string Name { get; set; }
}

Output:
<Employee Id="1">
   <Name>John</Name>
</Employee>
-----------------------------------------------

✅🔥[XmlIgnore]: Excludes a property.

public class Employee
{
    public int Id { get; set; }
    [XmlIgnore]
    public string Password { get; set; }
}
Output:
<Employee>
   <Id>1</Id>
</Employee>




















