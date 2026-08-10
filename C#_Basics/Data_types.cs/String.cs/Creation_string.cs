✅🔥 using System.Data;
using System.Xml;

String creation:

1. String literal — most common way
The simplest way is to directly assign text inside double quotes.

string name = "Kapil";
Console.WriteLine(name);

means:
   string → data type
   name → variable
  "Kapil" → string literal
The compiler/runtime creates a System.String object representing "Kapil".

---------------------------------------------------------

✅🔥 Using System.String
string is actually an alias for System.String.

Therefore, these are equivalent:
string name = "Kapil";
OR
System.String name = "Kapil";

---------------------------------------------------------

✅🔥 Using new string(...)

For example:
string name = new string("Kapil");  ❌ No.
Console.WriteLine(name);

The String class does not have a constructor that accepts another string.
new string("Kapil") is not a valid constructor in C#. So the above code will actually produce a compiler error.


✅Solution:
char[] chars = { 'K', 'a', 'p', 'i', 'l' };  
string name = new string(chars);  // creates a new String object from the characters in the character array.
Console.WriteLine(name);        // Kapil


string str = new string('A', 5);
Console.WriteLine(str);  // AAAAA


char[] chars = { 'H', 'e', 'l', 'l', 'o' }; // Creating a string from part of a char[]
string str = new string(chars, 1, 3); // start index=1 , take 3 characters
Console.WriteLine(str);  

----------------------------------------------------------

✅🔥 Creating string using char[] with ToString():
A char[] itself is not converted to its characters simply by calling ToString().

char[] chars = { 'K', 'a', 'p', 'i', 'l' };
string str = chars.ToString();
Console.WriteLine(str);
Output: System.Char[]

You might expect:  Kapil
But the output is actually something like: System.Char[]
Why?
Because chars is an array object.

Every object in C# ultimately inherits from System.Object, which provides: ToString()
For an array, ToString() does not concatenate its elements. It returns the type name of the object.

So:
chars.ToString() means approximately: "System.Char[]"




✅ chars.ToString() means 
       ↓
"Give me the string representation of this ARRAY object"
       ↓
"System.Char[]"




✅Whereas: 
new string(chars) means
       ↓
"Take the CHARACTERS stored inside this array"
       ↓
"K" + "a" + "p" + "i" + "l"
       ↓
"Kapil"
===================================================================================================================

✅🔥 String concatenation:
You can create a new string by joining strings using +

string firstName = "Kapil";
string lastName = "Solanki";
string fullName = firstName + " " + lastName;
Console.WriteLine(fullName); // Kapil Solanki



string firstName = "Kapil";
string lastName = "Solanki";
string fullName = String.Concat(firstName, " ", lastName);
Console.WriteLine(fullName);// Kapil Solanki

You can also concatenate multiple values:
string result = String.Concat("A", "B", "C", "D");
Console.WriteLine(result);
Output: ABCD


✅ string.Concat() ?
char[] chars = { 'K', 'a', 'p', 'i', 'l' };
string str = string.Concat(chars);
Console.WriteLine(str);
Output: Kapil


-----------------------------------------------------------


✅ Using String.Join()
String.Join() is useful when you have multiple strings and want to combine them using a separator.
string[] names =
{
"Kapil",
"Rahul",
"Amit"
};
string result = String.Join(", ", names);
Console.WriteLine(result); // Kapil, Rahul, Amit

The separator is:
", "
So:
Kapil
Rahul
Amit

becomes: Kapil, Rahul, Amit
------------------------------------------------

✅🔥 String interpolation:
Syntax:  $"text {variable}"

string name = "Kapil";
int age = 23;
string message = $"My name is {name} and I am {age} years old.";
Console.WriteLine(message);
Output:
My name is Kapil and I am 23 years old.

The $ tells C#: Evaluate expressions inside { }.
For example: $"Hello {name}" // Hello Kapil

--------------------------------------------------

✅🔥 String.Format()
Another way of creating formatted strings is String.Format().
string name = "Kapil";
int age = 23;
string message = String.Format(
    "My name is {0} and I am {1} years old.",
    name,
    age
);
Console.WriteLine(message);
Output: My name is Kapil and I am 23 years old.


--------------------------------------------------------

✅🔥 Verbatim string
A verbatim string is created by putting @ before the string.

string path = @"C:\Users\Kapil\Documents";
Console.WriteLine(path);
Output:  C:\Users\Kapil\Documents

Normally, backslash is an escape character.

Without @, you would write:
string path = "C:\\Users\\Kapil\\Documents";

With @:
string path = @"C:\Users\Kapil\Documents";
Much easier for Windows paths.



✅ Verbatim string with quotes
In a verbatim string, a double quote is represented by two double quotes.

string message = @"He said ""Hello""";
Console.WriteLine(message);
Output: He said "Hello"

Notice: @"He said ""Hello"""
produces: He said "Hello"

================================================================================================================

✅🔥 Using StringBuilder in C#:

StringBuilder is a class in the System.Text namespace used to build and modify text efficiently.
using System.Text;

You create a StringBuilder object like this: StringBuilder sb = new StringBuilder();
Then you can add or modify characters using methods such as:
sb.Append("Hello");
sb.Append(" ");
sb.Append("Kapil");
Finally, convert the StringBuilder into a string: string result = sb.ToString();


✅ Basic Example:
using System;
using System.Text;
class Program
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Hello");
        sb.Append(" ");
        sb.Append("Kapil");

        string result = sb.ToString();
        Console.WriteLine(result);
    }
}
Output: Hello Kapil

The process is:
StringBuilder
      ↓
Append("Hello")
      ↓
"Hello"
      ↓
Append(" ")
      ↓
"Hello "
      ↓
Append("Kapil")
      ↓
"Hello Kapil"
      ↓
ToString()
      ↓
string
"Hello Kapil"

----------------------------------------------

✅🔥 Why use StringBuilder ?

The biggest reason is that string is immutable.
For example:
string text = "Hello";
text = text + " Kapil";
text = text + "!";

Every modification creates a new string object.
Conceptually:
"Hello"
   ↓
"Hello Kapil"
   ↓
"Hello Kapil!"
The old strings cannot be modified.


✅With StringBuilder, the same builder can be modified:

StringBuilder sb = new StringBuilder("Hello");
sb.Append(" Kapil");
sb.Append("!");
Console.WriteLine(sb);

-----------------------------------------------------

✅🔥 StringBuilder vs string

string name = "Kapil"; // name refers to a string object.
Whereas: 
StringBuilder sb = new StringBuilder("Kapil");
sb refers to a StringBuilder object.

| `string`                               | `StringBuilder`                   |
| -------------------------------------- | --------------------------------- |
| Immutable                              | Mutable                           |
| Cannot directly modify existing string | Can modify existing builder       |
| Good for normal text                   | Good for frequently changing text |
| `System.String`                        | `System.Text.StringBuilder`       |
| String literal can be used             | Usually created with `new`        |
| `+` can concatenate                    | `Append()` is commonly used       |

-------------------------------------------------------

✅🔥 Append() does not return a new StringBuilder

For example:
StringBuilder sb = new StringBuilder();
sb.Append("Hello");
sb.Append(" World");
The same StringBuilder is modified.

You can even chain Append() calls:
StringBuilder sb = new StringBuilder();
sb.Append("Hello")
  .Append(" ")
  .Append("Kapil");
Console.WriteLine(sb);
Output: Hello Kapil
This works because Append() returns the same StringBuilder object.

---------------------------------------------------------

✅🔥 Insert()
Inserts text at a specific index.

StringBuilder sb = new StringBuilder("Hello");
sb.Insert(5, " Kapil");
Console.WriteLine(sb);
Output: Hello Kapil

----------------------------------------------------------

✅🔥 Replace():
Replaces text.

StringBuilder sb = new StringBuilder("Hello Kapil");
sb.Replace("Kapil", "Rahul");
Console.WriteLine(sb);
Output: Hello Rahul

-----------------------------------------------------------

✅🔥 Remove()
Removes characters.

StringBuilder sb = new StringBuilder("Hello Kapil");
sb.Remove(5, 6);
Console.WriteLine(sb);
Output: Hello

Here:
Remove(5, 6) means:
    start index = 5
    number of characters = 6

-----------------------------------------------------------


✅🔥 Length
Gets or sets the number of characters.

StringBuilder sb = new StringBuilder("Hello");
Console.WriteLine(sb.Length);
Output: 5

-----------------------------------------------------------

✅🔥 Capacity
StringBuilder internally maintains a buffer with a certain capacity.

StringBuilder sb = new StringBuilder();
Console.WriteLine(sb.Capacity);
The default capacity is implementation-defined by the .NET version/runtime, so don't rely on a particular default value.

You can specify one:
StringBuilder sb = new StringBuilder(100);
This creates a builder with an initial capacity of 100 characters.

-------------------------------------------------------------

✅🔥 StringBuilder is not always better:
Don't assume: "StringBuilder is always faster than string."

For simple operations:
string name = "Kapil";
string message = "Hello " + name;

using string is perfectly fine.
StringBuilder becomes particularly useful when you're performing many modifications, especially repeatedly inside loops.



StringBuilder sb = new StringBuilder();
for (int i = 1; i <= 1000; i++)
{
    sb.Append(i);
    sb.Append(" ");
}

string result = sb.ToString();


