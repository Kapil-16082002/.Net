✅🔥 Serialization:
Serialization is the process of converting an object into a stream of bytes or a text format (such as JSON or XML) 
, so that it can be stored, transferred, or reconstructed later.

Object
   ↓
Serialization
   ↓
JSON / XML / Binary / Byte Stream


✅🔥 What is Deserialization?
Deserialization is the reverse process.
JSON / XML / Binary
       ↓
Deserialization
       ↓
Object

----------------------------------------------------

✅🔥 Why Do We Need Serialization?
Suppose we have a C# object.
Employee emp = new Employee()
{
    Id = 1,
    Name = "John",
    Salary = 50000
};
Memory representation:
RAM
Employee Object
-----------------------
Id -----> 1
Name ---> "John"
Salary -> 50000
-----------------------
This object only exists inside your program(RAM).

Now imagine you want to:
   Save it to a file
   Send it over the internet
   Send it to another application
   Store it in Redis
   Send it through an API
   Save it in a database as JSON
Another application can not understand a C# object ? No.
  Java application doesn't understand C# objects.
  Python application doesn't understand C# objects.
  JavaScript application doesn't understand C# objects.
They can only understand JSON.
So we need something that converts C# Object into JSON. That "something" is called a JSON Serialization Library.

❌ Without Serialization
Employee emp = new Employee();
Save(emp);   // ❌ Impossible
Because the file system or network cannot understand a C# object.


✅🔥 Types of Serialization in .NET
There are mainly three types that you'll encounter conceptually:
  JSON Serialization ⭐⭐⭐⭐⭐ (Most Used)
  XML Serialization ⭐⭐⭐
  Binary Serialization ⭐ (Legacy / Obsolete for most scenarios)

==================================================================================================================

✅🔥JSON?
JSON stands for: JavaScript Object Notation
Despite its name, JSON is language-independent and is supported by almost every programming language.
Example:
{
    "Id": 101,
    "Name": "Kapil",
    "Salary": 50000
}
Notice:
   Uses key-value pairs
   Text format
   Human-readable
   Lightweight


JSON (Most Common in Modern Applications)
JSON is the default data format for exchanging data in modern software.
Used in:
✅ REST APIs / ASP.NET Core Web APIs
✅ Frontend applications (React, Angular, Vue)
✅ Mobile apps (Android, iOS, Flutter)
✅ Microservices communication
✅ Cloud services (Azure, AWS, Google Cloud)
✅ Configuration files (appsettings.json)
✅ NoSQL databases (e.g., document databases)
✅ Message queues (RabbitMQ, Kafka, etc.)
----------------------------------------------------------

✅🔥 Why JSON ?
Suppose we have a C# object. This object only exists inside your program(RAM).
Employee emp = new Employee()
{
    Id = 1,
    Name = "John",
    Salary = 50000
};
Memory representation:
RAM
Employee Object
-----------------------
Id -----> 1
Name ---> "John"
Salary -> 50000
-----------------------

Now imagine you want to:
   Save it to a file
   Send it over the internet
   Send it to another application
   Store it in Redis
   Send it through an API
   Save it in a database as JSON
Another application can not understand a C# object ? No.
  Java application doesn't understand C# objects.
  Python application doesn't understand C# objects.
  JavaScript application doesn't understand C# objects.
They can only understand JSON.
So we need something that converts C# Object into JSON. That "something" is called a JSON Serialization Library.

===================================================================================================================

✅🔥  JSON library:
A JSON library is simply a translator. The library reads the object. Then converts it into JSON.
C# Object
      ↑
      |
JSON Library
      |
      ↓
JSON Text
It knows how to:
  Read objects
  Convert properties
  Convert collections
  Convert nested objects
  Convert arrays
  Convert dictionaries
  Convert dates
  Convert enums
  Convert null values

Two Major JSON Libraries in .NET
.NET
│
├── System.Text.Json
└── Newtonsoft.Json

✅🔥 A) System.Text.Json (Recommended)
Built into .NET Core 3.0+ and .NET 5/6/7/8/9.
Namespace: using System.Text.Json;
Pros:
  Fast
  Lightweight
  Built into .NET
  Low memory usage
✅🔥 B) Newtonsoft.Json (Json.NET)
Historically the most popular JSON library.
Namespace: using Newtonsoft.Json;
Pros:
  Very feature-rich
  Excellent backward compatibility
  Still widely used in legacy projects


✅🔥 Basic Serialization:
using System;
class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
}
using System;
using System.Text.Json;
class Program
{
    static void Main()
    {
        Employee emp = new Employee
        {
            Id = 1,
            Name = "John"
        };
        string json = JsonSerializer.Serialize(emp);
        Console.WriteLine(json);
    }
}
Output: {"Id":1,"Name":"John"}
What happens internally?
Object:
Id = 1
Name = John
↓
Reflection reads public properties.
↓
Creates JSON
{
    "Id":1,
    "Name":"John"
}
---------------------------------------------

✅ Deserialization:
using System;
using System.Text.Json;
class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
}
class Program
{
    static void Main()
    {
        string json =n @"{""Id"":1,""Name"":""John""}";
        Employee emp = JsonSerializer.Deserialize<Employee>(json);
        Console.WriteLine(emp.Name);
    }
}
Internally:
JSON
{
    "Id":1,
    "Name":"John"
}
↓
Reflection
↓
Creates Employee object
↓
Assigns properties


✅🔥 Which should you use?
✅Choose System.Text.Json when:
    You're building a new .NET 5/6/7/8/9 application.
    You want the best performance and low memory usage.
    You're developing ASP.NET Core Web APIs.
    You don't need advanced legacy behaviors.

✅Choose Newtonsoft.Json when:
    You're maintaining an existing application that already uses it.
    You rely on advanced serialization features or custom converters that are difficult to migrate.
    You need compatibility with older .NET Framework projects.

==================================================================================================================

✅🔥 Ignoring Properties:
Sometimes you don't want to serialize a property.
using System.Text.Json.Serialization;
class Employee
{
    public int Id { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
}
Output:
{
    "Id":1
}
The Password property is omitted.
-------------------------------------------------

✅🔥Custom Property Names:
using System.Text.Json.Serialization;
class Employee
{
    [JsonPropertyName("employee_id")]
    public int Id { get; set; }
}
Output:
{
   "employee_id":1
}
==================================================================================================================

| JSON                         | XML                                    |
| ---------------------------- | -------------------------------------- |
| Lightweight                  | More verbose                           |
| Faster to parse              | Slower to parse                        |
| Smaller file size            | Larger file size                       |
| Easy to read and write       | More complex syntax                    |
| Less memory usage            | More memory usage                      |
| Native support in JavaScript | Requires XML parser                    |
| Preferred for REST APIs      | Mostly used in SOAP and legacy systems |


✅🔥 Key Advantages of JSON:
1. Lightweight:
JSON uses fewer characters than XML, reducing data size.
JSON
{
  "Id": 1,
  "Name": "John"
}
XML
<Employee>
    <Id>1</Id>
    <Name>John</Name>
</Employee>

2. Faster Parsing
   JSON is parsed more quickly, improving application performance.

3. Smaller Payload
   Less data is transmitted over the network, reducing bandwidth usage.

4. Easy to Read and Write
   JSON has a simple and clean syntax, making it easier for developers.

5. Lower Memory Usage
   JSON parsers generally consume less memory than XML parsers.

6. Native JavaScript Support
   JSON maps directly to JavaScript objects, making it ideal for web applications.
   Better for REST APIs







































