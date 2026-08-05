
🔄 How .NET Code Executes  ?
🚀 Strong and Weak Assemblies in .NET Framework  ?

================================================================================================================

✅🔥 Difference Between .NET Core and .NET Framework
| Feature                   | .NET Framework                      | .NET Core                                   |
| ------------------------- | ----------------------------------- | ------------------------------------------- |
| **First Release**         | 2002                                | 2016                                        |
| **Current Status**        | Legacy (maintenance only)           | Modern platform (continued as .NET 5+)      |
| **Operating System**      | Windows only                        | Windows, Linux, macOS                       |
| **Open Source**           | ❌ No                                | ✅ Yes                                       |
| **Performance**           | Good                                | Faster and optimized                        |
| **Application Types**     | Windows Desktop, ASP.NET, WCF       | Web, Cloud, Console, Desktop, Microservices |
| **Deployment**            | Machine-wide installation           | Self-contained or Framework-dependent       |
| **Cloud Support**         | Limited                             | Excellent (Azure, Docker, Kubernetes)       |
| **Side-by-Side Versions** | ❌ No                               | ✅ Yes                                       |
| **CLI Support**           | Limited                             | `dotnet` CLI                                |
| **NuGet Packages**        | Supported                           | Supported (more modular)                    |
| **Microservices**         | Not ideal                           | Excellent                                   |
| **Containers (Docker)**   | Limited                             | Excellent                                   |
| **Future Development**    | Bug fixes and security updates only | Active development                          |



✅🔥 Why is .NET Framework NOT Platform Independent ?
The .NET Framework was introduced in 2002, when Microsoft's primary focus was the Windows operating system.
The .NET Framework is Windows-only because it was built on top of Windows-specific technologies such as Win32 APIs, COM, the Windows Registry, Windows Forms, WPF, and IIS. 
Since these components are available only on Windows, applications built with the .NET Framework can run only on Windows.

.NET Core was redesigned with cross-platform support in mind. 
It uses the CoreCLR runtime and a cross-platform Base Class Library, allowing the same application to run on Windows, Linux, and macOS without changing the code. 
Instead of relying on Windows-specific components, it uses platform-independent abstractions and technologies like the Kestrel web server.




==================================================================================================================

✅🔥 What is CLR (Common Language Runtime) ?
CLR (Common Language Runtime) is the execution engine of the .NET Framework.
It manages the execution of .NET applications and provides services such as memory management, security, exception handling, and garbage collection.
Think of the CLR as the "engine" that runs your .NET programs.

CLR Loads the Program:
When you run the application, the CLR:
  Loads the assembly
  Verifies the IL
  Manages memory
  Checks security
  Handles exceptions

How CLR Works:
When you write a C# program, it is not executed directly by the operating system.
Instead, the process is:
C# Source Code (.cs)
        │
        ▼
C# Compiler (csc)    // The C# compiler converts the code into IL (Intermediate Language)
        │
        ▼
IL (Intermediate Language)  
        │
        ▼
CLR
        │
   JIT Compiler
        │
        ▼
Machine Code
        │
        ▼
CPU Executes

===================================================================================================================

✅🔥🧠 What is CTS (Common Type System) in .NET ?
CTS (Common Type System) is a set of rules in .NET that defines how data types are declared, used, and managed by the CLR.
Its purpose is to ensure that all .NET languages (C#, VB.NET, F#, etc.) understand the same data types, allowing them to work together seamlessly.

CTS Classifications:
CTS divides types into two categories:
1. Value Types
2. Reference Types

Why is CTS needed ?
Different programming languages have different names for the same data type.
Although the names differ, internally they all map to the same CTS types.

| C#       | VB.NET    | CTS Type         |
| -------- | --------- | ---------------- |
| `int`    | `Integer` | `System.Int32`   |
| `string` | `String`  | `System.String`  |
| `bool`   | `Boolean` | `System.Boolean` |
Example:
C#:
int age = 25;
Internally: System.Int32 age = 25;

VB.NET:
Dim age As Integer = 25
Internally it is also: System.Int32

Therefore, C# and VB.NET can exchange data without any conversion.

===================================================================================================================

✅🔥🧠 What is CLS (Common Language Specification) ?

CLS (Common Language Specification) is a subset of CTS.
It defines a set of rules that every .NET language should follow so that code written in one language can be used by another language.
CTS defines all possible .NET types.
CLS defines only the types and features that every .NET language is guaranteed to support.

Example:
✅CLS-compliant:
public int Salary;
int (System.Int32) is supported by all CLS-compliant languages.


✅Not CLS-compliant:
public uint Salary;
Why?
uint (System.UInt32) is not supported by every .NET language, so exposing it publicly is not CLS-compliant.

=================================================================================================================


✅🔥 What is GAC (Global Assembly Cache) in .NET ?
The Global Assembly Cache (GAC) is a central repository in Windows where shared .NET assemblies (DLLs) are stored.
Instead of each application keeping its own copy of a shared assembly, multiple applications can use the same assembly from the GAC.


✅Why is GAC Needed?
Imagine you have a logging library named Company.Logging.dll that is used by 20 different applications.
Without GAC:
Application A
 └── Company.Logging.dll

Application B
 └── Company.Logging.dll

Application C
 └── Company.Logging.dll

Problems:
   Duplicate copies of the same DLL
   Wasted disk space
   Difficult to update every application
    Version conflicts (DLL Hell)


✅ With GAC:
          Global Assembly Cache (GAC)
                  │
      Company.Logging.dll
                  │
    ┌─────────────┼─────────────┐
    ▼             ▼             ▼
Application A  Application B  Application C

✅Characteristics of GAC
    Stores shared assemblies.
    Available to all .NET applications on the machine.
    Supports side-by-side versioning.
    Prevents DLL Hell (version conflicts).
    Available only on Windows.


✅🔥 What Assemblies Can Be Installed in the GAC ?
Only Strong-Named Assemblies can be installed.
A Strong Name consists of:
   Assembly Name
   Version
   Culture
   Public Key
   Digital Signature
Example:
   Company.Logging,
   Version=1.0.0.0,
   Culture=neutral,
   PublicKeyToken=31bf3856ad364e35


✅🔥Why is a Strong Name Required ?
A strong name uniquely identifies an assembly.
Without it, two DLLs with the same name could cause conflicts.













