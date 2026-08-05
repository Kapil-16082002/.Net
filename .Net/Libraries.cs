✅🔥📚 Common and Important Libraries in .NET
.NET provides a rich set of built-in libraries called the Base Class Library (BCL) and the Framework Class Library (FCL). 
These libraries contain thousands of reusable classes that help developers build applications without writing everything from scratch.

✅BCL and FCL in .NET:
FCL (Framework Class Library)
│
├── BCL (Base Class Library)
├── ASP.NET
├── ADO.NET
├── Windows Forms
├── WPF
├── WCF (.NET Framework)
├── LINQ
└── Other Framework Libraries

✅🔥What is BCL (Base Class Library) ?
The Base Class Library (BCL) is the core library of .NET that provides the fundamental classes needed by almost every .NET application.
It includes classes for:
   Strings
   Collections
   File handling
   Input/Output
   Exception handling
   Threading
   Networking
   Reflection
   Mathematics
   Dates and Times
Think of the BCL as the foundation of .NET.


✅🔥






✅🔥1. System:
The System namespace is the root namespace of .NET.
It contains fundamental classes used in almost every application.
Common Classes:
   Console
   Math
   DateTime
   TimeSpan
   Random
   Environment

✅🔥2. System.Collections
Provides non-generic collections.
Common Classes:
   ArrayList
   Hashtable
   Queue
   Stack

✅🔥3. System.Collections.Generic ⭐
Provides type-safe collections.
Common Classes:
   List<T>
   Dictionary<TKey, TValue>
   HashSet<T>
   Queue<T>
   Stack<T>
   LinkedList<T>


✅🔥4. System.Linq ⭐
LINQ (Language Integrated Query) allows querying collections using SQL-like syntax.
Common Methods:
   Where()
   Select()
   OrderBy()
   GroupBy()
   First()
   Any()
   Count()

✅🔥5. System.IO ⭐
Used for file and directory operations.
Common Classes:
  File
  Directory
  FileInfo
  DirectoryInfo
  Path
  StreamReader
  StreamWriter

✅🔥6. System.Text
Provides classes for text processing.
Common Classes:
  StringBuilder
  Encoding

✅🔥7. System.Text.Json 
Used for JSON serialization and deserialization.

✅🔥8. System.Threading
Common Classes:
   Thread
   Monitor
   Mutex

✅🔥 System.Xml
Used to read and write XML files.
   Common Classes
   XmlReader
   XmlWriter
   XmlDocument


✅🔥10. System.Threading.Tasks ⭐
Supports asynchronous programming using Tasks.
Common Classes:
  Task
  Task<T>

✅🔥11. Microsoft.AspNetCore.*

The ASP.NET Core libraries are used to build web applications and REST APIs.

Common Namespaces:
   Microsoft.AspNetCore.Mvc
   Microsoft.AspNetCore.Builder
   Microsoft.AspNetCore.Http
   Microsoft.AspNetCore.Routing


✅🔥 System.Reflection ⭐
Allows inspection of assemblies, classes, methods, and properties at runtime.
Example:
Type t = typeof(string);
Console.WriteLine(t.FullName);















