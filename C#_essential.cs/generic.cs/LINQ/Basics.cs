✅🔥 What is LINQ?
LINQ stands for Language Integrated Query.
It is a feature in C# that allows you to query, filter, sort, group, transform, and manipulate data using a consistent syntax, regardless of whether the data comes from:
   Arrays
   Lists
   Dictionaries
   XML
   Databases (SQL Server)
   Entity Framework
   Objects in memory
Instead of writing loops (for, foreach) to process data manually, LINQ lets you express what you want rather than how to do it.



✅🔥 Why Was LINQ Introduced ?
Suppose you have 10,000 employees.
You want:
Employees whose salary > 50,000
Employees from the IT department
Sort by salary
Select only Name and Salary

Without LINQ:
   Multiple loops
   Temporary lists
   Sorting manually
   More code
With LINQ:
var result = employees
            .Where(e => e.Department == "IT")
            .Where(e => e.Salary > 50000)
            .OrderBy(e => e.Salary)
            .Select(e => new
            {
                e.Name,
                e.Salary
            });
more Readable and maintainable.

✅🔥 Two Ways to Write LINQ:
  1. Query Syntax
  2. Method Syntax
// Query Syntax is translated by the compiler into Method Syntax, so Method Syntax is the actual implementation.



✅🔥What is Method Syntax in LINQ?

✅Method Syntax uses extension methods provided by the Enumerable class and lambda expressions.
General syntax: collection.MethodName(parameters);

numbers.Where(n => n > 5)
       .OrderBy(n => n)
       .Select(n => n);
Each method returns another enumerable, allowing you to chain methods together.


✅Query Syntax Equivalent
var result =
    from n in numbers
    where n > 15
    select n;

using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 1,2,3,4,5,6 };
        var evenNumbers =
            from n in numbers
            where n % 2 == 0
            select n;
        foreach (var n in evenNumbers)
        {
            Console.WriteLine(n);
        }
    }
}
=================================================================================================================

✅🔥Example 1: Where() - Filtering
Where() is used to filter data.
var result = employees.Where(emp => emp.Salary > 55000);
foreach (var emp in result)
{
    Console.WriteLine($"{emp.Name} {emp.Salary}");
}
Query Syntax:
var result =
    from emp in employees
    where emp.Salary > 55000
    select emp;

Compiler converts it into: employees.Where(emp => emp.Salary > 55000);


----------------------------------------------------------------------------

✅🔥2. Select()

Select() transforms each element into another form.
It answers: "What should I return from each record?"

Method Syntax:
var result = numbers.Select(n => n * 10);
foreach(var num in result)
{
    Console.WriteLine(num);
}


Query Syntax:
var result =
    from n in numbers
    select n * 10;

-----------------------------------------------------------------------------

✅🔥 OrderBy()
Sorts in ascending order.
Method Syntax:
var result = numbers.OrderBy(n => n);
foreach(var item in result)
{
    Console.WriteLine(item);
}

Query Syntax:
var result =
from n in numbers
orderby n
select n;

----------------------------------------------------------------------------

✅🔥 OrderByDescending()

Method Syntax:
var result = numbers.OrderByDescending(n => n);

Query Syntax:
var result =
from n in numbers
orderby n descending
select n;

-------------------------------------------------------------------------------

✅🔥 ThenBy()
Suppose we have objects.
class Student
{
    public string Name { get; set; }
    public string Department { get; set; }
    public int Age { get; set; }
}
List<Student> students =
new List<Student>()
{
new Student{Name="Kapil",Department="IT",Age=23},
new Student{Name="Rahul",Department="CSE",Age=20},
new Student{Name="Amit",Department="IT",Age=21},
new Student{Name="Neha",Department="CSE",Age=22}
};


Method Syntax:
var result = students.OrderBy(s=>s.Department)
                      .ThenBy(s=>s.Age);  // .ThenByDescending(s=>s.Age);

Query Syntax
var result =
from s in students
orderby s.Department, s.Age    // s.Age descending
select s;
-----------------------------------------------------------

✅🔥 SelectMany()
List<List<int>> data =
new List<List<int>>
{
    new List<int>{1,2},
    new List<int>{3,4},
    new List<int>{5,6}
};
Without SelectMany:
[
 [1,2],
 [3,4],
 [5,6]
]
Using SelectMany:
var result = data.SelectMany(x=>x);
foreach(var item in result)
{
    Console.WriteLine(item);
}
Output:
1
2
3
4
5
6
What is x => x?
Each x is an inner list.
x
↓
[1,2]
Return that list.
SelectMany() automatically flattens all returned collections into one sequence.



Query Syntax:
There is no direct SelectMany() keyword, but you can achieve the same result using multiple from clauses:
var result =
    from list in data
    from number in list
    select number;
The compiler translates this into a call to SelectMany().

----------------------------------------------------------

✅🔥 1. Any()?

Any() checks whether at least one element satisfies a condition.

Think of it like: "Is there any number greater than 5?"
If at least one exists, it returns true.
Method Syntax:
bool result = numbers.Any(n => n > 5);
Console.WriteLine(result);


Query Syntax:
There is no direct query syntax for Any().
Instead, you write a query and then call Any():
var query =
    from n in numbers
    where n > 5
    select n;
bool result = query.Any(); // True

------------------------------------------------------

✅🔥 2. All()
Checks whether every element satisfies the condition.
Method Syntax:
bool result = numbers.All(n => n > 0);
Console.WriteLine(result); // True


Query Syntax: No direct query syntax.
var query =
    from n in numbers
    select n;
bool result = query.All(n => n > 0);
-----------------------------------------------------

✅🔥 Contains()
Checks whether the collection contains a specific value.
Method Syntax:
bool result = numbers.Contains(4);
Console.WriteLine(result); // True


Query Syntax:
No direct query syntax.
var query =
    from n in numbers
    select n;
bool result = query.Contains(4);

-----------------------------------------------------

✅🔥 Count()
Returns the number of elements.
LongCount(): Same as Count() but returns a long (Int64) instead of an int. Useful for very large collections (more than 2,147,483,647 elements).

Method Syntax:
int count = numbers.Count();
Console.WriteLine(count);

Count with condition: int count = numbers.Count(n => n > 3);

Query Syntax:
var query =
    from n in numbers
    where n > 3
    select n;
int count = query.Count();

--------------------------------------------------------

✅🔥 Sum()
Adds all numbers.

Method Syntax:
int total = numbers.Sum();
Console.WriteLine(total);


Query Syntax:
var query =
    from n in numbers
    select n;
int total = query.Sum();
---------------------------------------------------

✅🔥Average()
Returns the average.
Method Syntax:
double avg = numbers.Average();
Console.WriteLine(avg);


Query Syntax:
var query =
    from n in numbers
    select n;
double avg = query.Average();
----------------------------------------------

✅🔥 Min()
Returns the smallest value.
Method Syntax:
int smallest = numbers.Min();
Console.WriteLine(smallest);


Query Syntax:
var query =
    from n in numbers
    select n;
int smallest = query.Min();

--------------------------------------------------

✅🔥Max()
Returns the largest value.

Method Syntax:
int largest = numbers.Max();
Console.WriteLine(largest);

Query Syntax:
var query =
    from n in numbers
   select n;
int largest = query.Max();


✅🔥 Aggregate()
It combines all elements into one final value using custom logic.

Example 1 – Sum using Aggregate()
int result = numbers.Aggregate((x, y) => x + y);
Console.WriteLine(result);

Query Syntax:
There is no direct query syntax.
var query =
    from n in numbers
    select n;
int result = query.Aggregate((x, y) => x + y);




Example 2 – Product of All Numbers
int product = numbers.Aggregate((x, y) => x * y);
Console.WriteLine(product);










































