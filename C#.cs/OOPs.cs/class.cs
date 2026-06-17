
✅🔥# CLASS
1. A Class is a user-defined data type that has data members and member functions.
   Data members are the data variables and member functions are the functions.
2. A class is a blueprint or template for creating objects.


✅Real-life Example: Think of a Car blueprint.
The blueprint contains:
Color
Engine
Speed
Model
Start()
Stop()
But the blueprint itself is not a real car. Only when the factory manufactures a car does it become a real object.


class ClassName
{
    // Members
}
-------------------------------------------------------------

✅🔥Nested Class
class Outer
{
    public class Inner
    {
        public void Show()
        {
            Console.WriteLine("Inner");
        }
    }
}
Outer.Inner obj = new Outer.Inner();
obj.Show();

-----------------------------------------------------------

✅🔥Static Class vs Normal Class

Normal class Need object.
class MathUtility{}
MathUtility m = new MathUtility();


Static class:
static class MathUtility
{
}

No need to object. We can Use directly,  MathUtility.Method();
------------------------------------------------------------

✅🔥Partial Class: 
A partial class allows you to split a single class definition across multiple files.
The compiler combines all the partial definitions into one class during compilation.

Important Rules
✔ All partial declarations must have the same class name.
✔ All parts must be marked partial.
✔ All parts must be in the same namespace.


File1:
partial class Student
{
    public int Age;
}

File2:
partial class Student
{
    public string Name;
}

The compiler internally treats it as:
class Student
{
    public int Age;

    public string Name;
}
So there is only one Student class, not two separate classes.
--------------------------------------------------------------

✅🔥Sealed Class
A Sealed Class is a class that cannot be inherited by another class.
It is declared using the sealed keyword.

sealed class Employee
{
}
Once a class is marked as sealed, no other class can derive from it.


✅Why Do We Need a Sealed Class?
Suppose you create a class that contains important business logic or security-related functionality, and you do not want anyone to modify its behavior through inheritance.
In such cases, mark the class as sealed.
It tells the compiler: "This class is final. No class can inherit from it."


✅Properties:
Sealed Class Can Have Constructors
Sealed Class Can Have Properties
Sealed Class Can Implement Interfaces
Sealed Class Can Inherit Another Class



✅Difference Between sealed class and sealed method
sealed class:  Entire class cannot be inherited.
sealed method: The class can still be inherited, but Show() cannot be overridden further.


✅Advantages of Sealed Classes
Prevents inheritance.
Protects business logic from modification.
Improves API safety.
Can allow minor runtime optimizations.
Makes class behavior predictable.


====================================================================================================================

✅🔥# OBJECTS
1. An object is an instance of a class. It holds the actual data and can use the methods and variables defined by the class.
2. Multiple objects can be created from the same class, each with different data.

Objects represent real-world entities with:
Identity: A unique reference in memory.
State: The data (attribute values) associated with the object.
Behavior: Defined by the methods in the class.

Object Lifecycle
The object lifecycle includes:
Creation: Memory is allocated, and the constructor is invoked.
Usage: The object can call methods and modify attributes.
Destruction: Memory is released when the object goes out of scope. Optionally, a destructor (~class_name()) is invoked.



#Note: When a class is defined, no memory is allocated 
but when it is instantiated (i.e. an object is created) memory is allocated.

using System;
class Student
{
    public string Name;
    public int Age;
}
class Program
{
    static void Main()
    {
        Student s = new Student();
        s.Name = "Kapil";
        s.Age = 22;
        Console.WriteLine(s.Name);  // Kapil
        Console.WriteLine(s.Age);   // 22
    }
}
✅🔥Default Values
When an object is created: Student s = new Student();
Fields get default values.
| Type   | Default |
| ------ | ------- |
| int    | 0       |
| double | 0       |
| bool   | false   |
| char   | '\0'    |
| string | null    |
| object | null    |


class Student
{
    public int Age;
    public bool Passed;
    public string Name;
}
Student s = new Student();
Console.WriteLine(s.Age); //   0
Console.WriteLine(s.Passed); // false
Console.WriteLine(s.Name); // nothing(null)


==================================================================================================================
✅🔥Anonymous Object:
Anonymous object allows you to create an object without explicitly creating a class.
Almost always anonymous objects are declared using var. Because the type name is compiler-generated, cannot be written by the programmer
Syntax
var obj = new
{
    Property1 = value1,
    Property2 = value2,
    Property3 = value3
};


✅Instead of writing:
class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
}
you can simply write:
var student = new
{
    Name = "Kapil",
    Age = 22
};
Console.WriteLine(student.Name); // Kapil
Compiler generates an anonymous class automatically.
The compiler automatically generates a class behind the scenes, which is why it is called an Anonymous Object.



✅🔥Why Anonymous Objects were Introduced?  Suppose you only need an object temporarily.
Without Anonymous Object:
class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
}
Need to create an entire class just for two values.
Anonymous objects solve this:
var s = new
{
    Name = "Kapil",
    Age = 22
};

----------------------------------------------------

✅🔥How Compiler Creates It

You write:
var student = new
{
    Name = "Kapil",
    Age = 22
};
Compiler internally creates something similar to:
class AnonymousType
{
    public string Name { get; }
    public int Age { get; }
    public AnonymousType(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
Then creates:
AnonymousType student =  new AnonymousType("Kapil",22);
This generated class has no programmer-defined name, so it is called anonymous.

----------------------------------------------------

✅Nested Anonymous Objects
Anonymous objects can contain other anonymous objects.

var student = new
{
    Name = "Kapil",
    Address = new
    {
        City = "Hyderabad",
        State = "Telangana"
    }
};
Console.WriteLine(student.Name);
Console.WriteLine(student.Address.City);
Console.WriteLine(student.Address.State);

-----------------------------------------------------

✅Anonymous Object with Array
var student = new
{
    Name = "Kapil",
    Marks = new[]{90,85,95}
};
foreach(var x in student.Marks)
{
    Console.WriteLine(x);
}
------------------------------------------------------------

✅Anonymous Objects are Immutable
Once created, their property values cannot be changed.
var obj = new
{
    X = 10
};
Cannot do: obj.X = 20;
This is one reason they are thread-safe for read operations.

--------------------------------------------------------------

✅Equality of Anonymous Objects
var a = new
{
    Name = "Kapil",
    Age = 22
};
var b = new
{
    Name = "Kapil",
    Age = 22
};
Console.WriteLine(a == b); // false
Console.WriteLine(a.Equals(b));// true
Why? == compares references.
Equals() compares property values because the compiler generates value-based equality for anonymous types of the same shape.



// --------------------------- Memory Occupied by object----------------------------------------------------------

✅🔥Key Points to Remember:
1.An empty class is one that has no data members or member functions.
class Empty {};
⭐ Now consider this:
class Test {
public:
    static int x;
    static void fun() {}
};
✔ Does this affect object size?  NO
cout << sizeof(Test) << endl; // 1

👉 So is it technically an empty class?
It behaves like an empty class in memory layout,
BUT According to C++ definition, it is NOT classified as an "empty class".
Why?
Because static members still belong to the class, even though they do NOT contribute to object size.



2.An object of this empty class will occupy 1 byte in memory:
Empty obj1, obj2;
cout << "Size of obj1: " << sizeof(obj1) << " bytes" << endl;
cout << ( &obj1 == &obj2 ? "Same address" : "Different addresses") << endl;
Output:
Size of obj1: 1 bytes
Different addresses

3. 1 Byte Memory is allocated to ensure that objects of the class have a unique address. 
Even in the case of empty classes, distinct instances (obj1 and obj2) must have different addresses.

//--------------------------------------------------------------------------------------------------------------

What if the Class has Static Members ?
Static members belong to the class itself rather than individual objects.
Therefore, they do not contribute to the size of any instance(object) of the class.

Example:
#include <iostream>
using namespace std;
class StaticTest {
    static int count;  // Static member variable
};
int StaticTest::count = 0;

int main() {
    StaticTest obj1, obj2;
    cout << "Size of static member object: " << sizeof(obj1) << " bytes" << endl;  // Still 1 byte
    return 0;
}
Output:
Size of static member object: 1 bytes.

//----------------------------------------------------------------------------------------------------------------

Empty Base Optimization (EBO)
If an empty class is used as a base class in an inheritance hierarchy, the compiler may optimize and stop the empty base class from occupying memory. 
This is called Empty Base Optimization (EBO).

Example:
#include <iostream>
using namespace std;

class Empty {};   // Empty class
class Derived : public Empty {
    int data;     // Non-empty derived class
};
int main() {
    cout << "Size of empty class: " << sizeof(Empty) << " bytes" << endl;        // 1 byte
    cout << "Size of derived class: " << sizeof(Derived) << " bytes" << endl;   // Size of int (4 bytes, EBO applied here)
    return 0;
}
Output:
Size of empty class: 1 bytes
Size of derived class: 4 bytes
Here, the empty class as a base class does not contribute to the memory used by Derived. 
This optimization avoids wasting memory and is supported by most modern C++ compilers.

✅Conclusion:
The size of an object of an empty class is 1 byte.
This is to ensure that each object has a unique memory address, as required by the C++ standard.
Static members do not contribute to object size.
Inheritance with empty base classes can use Empty Base Optimization (EBO) to eliminate unnecessary memory usage.


===================================================================================================================

Object Creation Methods in C++:
1✅. Stack Allocation (Automatic Storage)
Objects can be created directly on the stack by declaring them in a function or scope using their type.

class MyClass {
public:
    int x;
    MyClass(int val) : x(val) {}
};
int main() {
    MyClass obj(10);  // Object created on stack (automatic memory allocation)
    cout << "Value of x: " << obj.x << endl;
    return 0;
}
Key Characteristics of Stack Objects:
1.Memory is automatically allocated and deallocated.
2.Lifetime within the scope in which it is created.
3.Stored in the stack memory region.

Advantages:
Easy to use.
No need to manually deallocate memory.
Memory management is faster since stack memory has low overhead.

Disadvantages:
Objects are limited by the stack size.
Cannot be shared outside the scope in which they were created (local lifetime).

/* Dynamic Objects (Heap Memory) Objects created using new:
int* ptr = new int(10);
📌 Lifetime:
NOT tied to scope
Exists until you explicitly delete it */

//----------------------------------------------------------------------------------------------------------------

2✅. Heap Allocation (Dynamic Storage)
Objects can be created on the heap using the new operator. 
Such objects are stored dynamically, allowing manual management of their lifetime.
class MyClass {
public:
    int x;
    MyClass(int val) : x(val) {}
};
int main() {
    MyClass* obj = new MyClass(10);  // Object created on the heap
    cout << "Value of x: " << obj->x << endl;

    delete obj;  // Free memory manually
    return 0;
}
Key Characteristics of Heap Objects:

Stored in the heap memory region.
Explicitly created using new.
Must be manually destroyed using delete.

Advantages:
No lifetime restrictions (exists until you delete it).
These objects can be shared between different parts of the program.

Disadvantages:
Requires manual memory management (potential for memory leaks if delete is missed).
Slower to allocate/deallocate than stack objects due to heap overhead.