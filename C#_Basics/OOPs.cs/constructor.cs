✅🔥 Constructor
A constructor is a special member function that is automatically called when an object of a class is created.
Its main purpose is to initialize the object's data (fields/properties).

Student s = new Student();

When new Student() executes:
  Memory is allocated for the object.
  Fields get default values.
  Constructor is automatically called.
  Object reference is returned.


✅🔥 Why Do We Need Constructors?
Without constructors:
class Student
{
    public string Name;
    public int Age;
}
Student s = new Student();
s.Name = "Kapil"; // Initialization happens after object creation.
s.Age = 22;  // Initialization happens after object creation.


Using constructors:
class Student
{
    public string Name;
    public int Age;
    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
Student s = new Student("Kapil", 22);// Object is initialized at the time of creation.

---------------------------------------------------------------------

✅🔥Properties of Constructors
     Constructor name must be the same as the class name.
     Constructors have no return type, not even void.
     Constructors are called automatically.
     A constructor can be overloaded.
     Constructors can have access modifiers.
     Constructors cannot be inherited, virtual, abstract, or override.
     Constructors can call other constructors using this() or base-class constructors using base().

✅ Types of Constructors in C#
     Default Constructor
     Parameterized Constructor
     Copy Constructor
     Static Constructor
     Private Constructor
     Constructor Overloading
     Constructor Chaining
     Base Class Constructor Calling

==================================================================================================================
✅🔥1. Default Constructor
A default constructor is a constructor that takes no parameters. 
If no constructor is defined, C# provides a default constructor automatically.

using System;
class Student
{
    public Student()
    {
        Console.WriteLine("Default Constructor");
    }
}
class Program
{
    static void Main()
    {
        Student s = new Student();
    }
}
Output: Default Constructor

But, if you define any constructor, the compiler does not generate the default constructor.
Example:
class Student
{
    public Student(int x)
    {

    }
}
Student s = new Student();// Compilation Error:No constructor takes 0 arguments

===================================================================================================================

✅🔥2. Parameterized Constructor:
A parameterized constructor allows passing arguments to initialize an object with specific values.
class Employee
{
    public int Id;
    public string Name;
    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
Employee e = new Employee(101, "Kapil");

=================================================================================================================

✅🔥3. Copy Constructor
A copy constructor is used to create a new object from an existing object.
C# does not automatically provide a copy constructor. We create it manually.

class Student
{
    public string Name;
    public Student(string name)
    {
        Name = name;
    }
    public Student(Student s)
    {
        Name = s.Name;
    }
}
Student s1 = new Student("Kapil");
Student s2 = new Student(s1);
Console.WriteLine(s2.Name);
==================================================================================================================

✅🔥4.Static Constructor
A Static Constructor is a special constructor that is used to initialize static members of a class.
It is executed automatically by the CLR (Common Language Runtime) only once during the lifetime of the application, before the class is used for the first time.

✅Properties of Static Constructor:
| Property                    | Description                                 |
| --------------------------- | ------------------------------------------- |
| No parameters               | Cannot accept arguments                     |
| No access modifier          | Cannot be `public`, `private`, etc.         |
| Cannot be overloaded        | Only one static constructor is allowed      |
| Executes only once          | Runs once for the entire application domain |
| Called automatically        | CLR invokes it automatically                |
| Cannot be called explicitly | `Student.Student()` is invalid              |
| Initializes static members  | Primary purpose                             |


✅Why Do We Need a Static Constructor? 
Suppose a class has static fields that require initialization.
Example:
class Student
{
    public static string CollegeName;
}
You want every Student object to use the same college name.
Instead of initializing it repeatedly in every instance constructor, you can initialize it once using a static constructor.
using System;
class Student
{
    static Student()
    {
        Console.WriteLine("Static Constructor");
    }
    public Student()
    {
        Console.WriteLine("Instance Constructor");
    }
}
class Program
{
    static void Main()
    {
        Student s1 = new Student();
        Student s2 = new Student();
    }
}
Output:
Static Constructor
Instance Constructor
Instance Constructor
//The static constructor executes only once, while the instance constructor executes every time an object is created.

--------------------------------------------------------------------

✅🔥Static Constructor Initializes Static Fields
using System;
class Student
{
    public static string College;
    static Student()
    {
        College = "IIT Delhi";
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine(Student.College);
    }
}
// No object is created, yet the static constructor runs because the static member is accessed.

---------------------------------------------------------------------

| Static Constructor          | Instance Constructor          |
| --------------------------- | ----------------------------- |
| Uses `static` keyword       | No `static` keyword           |
| Executes once               | Executes for every object     |
| Initializes static members  | Initializes instance members  |
| Called automatically        | Called during object creation |
| No parameters               | Can have parameters           |
| Cannot have access modifier | Can have access modifiers     |
| Cannot be overloaded        | Can be overloaded             |

==================================================================================================================

✅🔥 Private Constructor in C# 
A Private Constructor is a constructor that is declared using the private access modifier.
It prevents objects of the class from being created outside the class.
It is mainly used to:
      Prevent object creation
      Control object creation
      Implement the Singleton Design Pattern
      Create utility classes containing only static members

✅Why Do We Need a Private Constructor?
Normally, when a constructor is public:
class Student
{
    public Student()
    {
    }
}
Anyone can create objects:
     Student s1 = new Student();
     Student s2 = new Student();
     Student s3 = new Student();



✅Sometimes we want to prevent this.
For example:
   Singleton classes
   Factory classes
   Utility classes
   Classes that should never be instantiated
A private constructor achieves this.
using System;
class Student
{
    private Student()
    {
        Console.WriteLine("Private Constructor");
    }
}
class Program
{
    static void Main()
    {
        Student s = new Student();
    }
}
===================================================================================================================

✅🔥What is Constructor Overloading ?
When a class contains more than one constructor with different parameter lists, it is called constructor overloading.
Each constructor initializes the object differently depending on the arguments passed.
Same constructor name + Different parameter list = Constructor Overloading

✅How does the Compiler Select the Constructor?
The compiler matches the constructor based on
   Number of arguments
   Data types of arguments
   Order of arguments


using System;
class Student
{
    string name;
    int age;

    public Student()
    {
        name = "Unknown";
        age = 0;
    }
    public Student(string n)
    {
        name = n;
        age = 0;
    }
    public Student(string n, int a)
    {
        name = n;
        age = a;
    }
    public void Display()
    {
        Console.WriteLine(name + " " + age);
    }
}
class Program
{
    static void Main()
    {
        Student s1 = new Student();
        Student s2 = new Student("Kapil");
        Student s3 = new Student("Kapil",22);

        s1.Display();
        s2.Display();
        s3.Display();
    }
}
===================================================================================================================

✅🔥What is Constructor Chaining?
Constructor chaining is the process where one constructor calls another constructor of the same class or base class.
When a constructor calls another constructor in the same class, it uses the this() keyword.
Constructor A
      │
      ▼
Constructor B
      │
      ▼
Object Initialized
Instead of repeating initialization code in every constructor, one constructor delegates the work to another.

--------------------------------------------------------------------------------------------------------------------

✅Why is Constructor Chaining Needed ?
The main purpose of constructor chaining is to avoid duplicate code and centralize object initialization.
Suppose a Student class has three constructors.
Without chaining:
class Employee
{
    string name;
    int salary;
    public Employee()
    {
        name = "Unknown";
        salary = 25000;
    }
    public Employee(string n)
    {
        name = n;
        salary = 25000;
    }
    public Employee(string n,int s)
    {
        name = n;
        salary = s;
    }
} // Notice salary = 25000 , is repeated.

With chaining:
class Employee
{
    string name;
    int salary;
    public Employee()
        : this("Unknown")
    {
    }
    public Employee(string n)
        : this(n,25000)
    {
    }
    public Employee(string n,int s)
    {
        name = n;
        salary = s;
    }
} // Now initialization exists in only one place.

---------------------------------------------------------

✅🔥 Rules of Constructor Chaining
Rule 1:  Use this() to call another constructor of the same class.
Rule 2:  this() must be the first statement.
public Student()
{
    Console.WriteLine("Hi"); // Compilation Error.
    this("Kapil");
}
Rule 3: Only one constructor can be called directly.
✔Correct:
: this("Kapil")

❌Wrong:
: this("Kapil"), this(10)


Rule 4: Circular constructor calls are illegal.
Wrong:
class Demo
{
    public Demo()
        : this(10)
    {
    }
    public Demo(int x)
        : this()
    {
    }
} // Compiler Error: Constructor cycle detected.
Workflow:
Demo()
↓
Demo(int)
↓
Demo()
↓
Demo(int)
↓
Infinite Loop

==================================================================================================================

✅🔥 Base Class Constructor Calling in C# (base())
When a class inherits from another class, the derived class constructor can call the base class constructor using the base() keyword.
This ensures that the base class is initialized first, followed by the derived class.

✅Why is Base Constructor Calling Needed?
Suppose we have a base class Person and a derived class Student.
A Student is also a Person, so before initializing the Student part, the Person part must be initialized.
Person
  ↑
  │
Student
When a Student object is created:
Base class (Person) is initialized.
Derived class (Student) is initialized.
This is exactly what base() is used for.


✅Example:
using System;
class Person
{
    public string Name;
    public Person(string name)
    {
        Name = name;
    }
}
class Student : Person
{
    public int Age;
    public Student(string name, int age)
        : base(name)
    {
        Age = age;
    }
    public void Display()
    {
        Console.WriteLine(Name);
        Console.WriteLine(Age);
    }
}
class Program
{
    static void Main()
    {
        Student s = new Student("Kapil", 22);  // Kapil
        s.Display();  // 22
    }
}

--------------------------------------------------------------------------------------------------------

✅🔥Why Must Base Constructor Execute First?

Suppose:
class Person
{
    public string Name;
    public Person(string name)
    {
        Name = name;
    }
}
If Person isn't initialized first, then Name would remain uninitialized.
Since Student inherits Person, the base part must exist before the derived part.