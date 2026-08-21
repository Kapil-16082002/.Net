✅🔥C# Properties — get and set:

A property is a class member that provides controlled access to a value.
Field  → stores data
Property → controls access to that data


GET → return value
SET → Store this value


General syntax:
access_modifier type PropertyName
{
    get
    {
        // return value
    }
    set
    {
        // assign value
    }
}

class Student
{
    private int marks;
    public int Marks
    {
        get
        {
            return marks;
        }
        set
        {
            marks = value;
        }
    }
}
Student s = new Student();
s.Marks = 90;              // set executes
Console.WriteLine(s.Marks); // get executes

--------------------------------------------------

✅🔥 Property With Only get
You can create a read-only property:

class Student
{
    private int marks = 90;
    public int Marks
    {
        get
        {
            return marks;
        }
    }
}
Student s = new Student();
Console.WriteLine(s.Marks);
// s.Marks = 100; // ❌  Because there is no set.

--------------------------------------------------------

✅🔥 Property With Only set

C# also allows a property with only a setter:
class Student
{
    private int marks;
    public int Marks
    {
        set
        {
            marks = value;
        }
    }
}
Student s = new Student();
s.Marks = 90;

But:
Console.WriteLine(s.Marks); ❌ is impossible because there is no getter.
This pattern is rare in normal application code, but it is valid C#.

------------------------------------------------------------

✅🔥 Auto-Implemented Property
If you don't need custom logic, use:

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
}
Student s = new Student();
s.Name = "Kapil";
s.Age = 23;
Console.WriteLine(s.Name);
Console.WriteLine(s.Age);

---------------------------------------------------------------

✅🔥 Auto-Property With private set
Very common:

class Employee
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
Employee e = new Employee(101, "Kapil");
Console.WriteLine(e.Id);
Console.WriteLine(e.Name);

// e.Id = 500; // ❌
// e.Name = "Rahul"; // ❌
------------------------------------------------

✅🔥 Read-Only Auto-Property
You can omit the setter completely:

class Employee
{
    public int Id { get; }
    public Employee(int id)
    {
        Id = id;
    }
}
Employee e = new Employee(101);
Console.WriteLine(e.Id);
// e.Id = 200; // ❌
Output: 101
This is useful when the value should be established during construction and then not changed.

===============================================================================================================

✅🔥 Important Difference: { get; } vs { get; private set; }

{ get; } — means read-only from the outside and cannot be assigned through the property after initialization.
{ get; private set; } -  means readable from outside, but assignable from inside the class.


Example:
class Animal
{
    public string Name { get; }
    public Animal(string name)
    {
        Name = name; // inside the constructor is allowed.
    }
}
class Program
{
    static void Main()
    {
        Animal a = new Animal("Dog");
        Console.WriteLine(a.Name);
        // a.Name = "Cat";   // ❌ Compilation error
    }
}
Name can be read from outside
There is no set accessor. The property can be assigned during initialization/constructor
After initialization, you cannot normally assign a new value

-----------------------------------------------

✅🔥 { get; private set; } — Public read, private write
class Animal
{
    public string Name { get; private set; }
    public Animal(string name)
    {
        Name = name;
    }
    public void ChangeName(string newName)
    {
        Name = newName;      // ✅ changes Allowed
    }
}
Animal a = new Animal("Dog");
Console.WriteLine(a.Name);  // ✅
a.Name = "Cat";             // ❌
a.ChangeName("Cat");        // ✅
Console.WriteLine(a.Name);  // Cat






