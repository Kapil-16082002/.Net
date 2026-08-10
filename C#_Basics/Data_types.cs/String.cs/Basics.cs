
✅🔥 What is a String?
A string in C# represents a sequence of characters.
For example:
string name = "Kapil";
Here: K a p i l      is a sequence of characters.

The string type is actually an alias for the .NET System.String class. 
The source also describes string as an object representing a sequence of characters and notes that operations such as concatenation, comparison, substring, searching, trimming, and replacement can be performed on it.
Simple example:
using System;
class Program
{
    static void Main()
    {
        string name = "Kapil";
        Console.WriteLine(name);
    }
}

---------------------------------------------------

✅🔥 string is a Reference Type:
Consider a class:
class Person
{
    public string Name;
}
Person p1 = new Person();
p1.Name = "Kapil";

Person p2 = p1;
p2.Name = "Rahul";

Console.WriteLine(p1.Name); //  Rahul
Console.WriteLine(p2.Name); //  Rahul


Why? Because: Both variables refer to the same object.
p1 ----\
        \
         ---> Person object
        /
p2 ----/


✅🔥 But String is Special
Now look at:
string s1 = "Kapil";
string s2 = s1;
s2 = "Rahul";
Console.WriteLine(s1);  //  Kapil
Console.WriteLine(s2);  // Rahul

At first this may look confusing.
If string is a reference type, why didn't changing s2 change s1?
The answer is: Strings are Immutable

//  Mutable: Something that can be changed after creation.
//  Immutable: Something that cannot be changed after creation.


----------------------------------------------------------------

✅🔥 String Immutability:

Consider:
string str = "DotNet";
str = "Tutorials";

You might think:
Memory
+-------------+
| DotNet      |
+-------------+
       ↑
      str

Then:
+-------------+
| Tutorials   |
+-------------+
       ↑
      str

But conceptually, what happens is:
First:
str
 |
 v
+----------+
| "DotNet"  |
+----------+


Second:
str
 |
 v
+-------------+
| "Tutorials" |
+-------------+
"DotNet" object is no longer referenced by str.
The original string isn't modified. A new string object/value is produced, and str now refers to it.

--------------------------------------------------------------

✅🔥 null vs Empty String:
string a = null;
string b = "";

a: null
means: a doesn't reference a string object.

b: ""
means: b references an empty string.

Example:
string a = null;
string b = "";
Console.WriteLine(a == null);  //  true
Console.WriteLine(b == null); //   false



--------------------------------------------------------------

✅🔥 Can We Modify a Character of a String ? No. but in C++ string is mutable, can be changed
No.
This will produce a compilation error:
string name = "Kapil";
name[0] = 'R';
You cannot directly modify a character because String is immutable.


Solution:
string name = "Kapil";
char[] chars = name.ToCharArray();
chars[0] = 'R';
name = new string(chars);
Console.WriteLine(name);

----------------------------------------------------------------

✅🔥 string vs String
lowercase string is an alias for capitalized String.

You can write:
string name = "Kapil";
or:
System.String name = "Kapil";
Both represent the same underlying .NET
























































