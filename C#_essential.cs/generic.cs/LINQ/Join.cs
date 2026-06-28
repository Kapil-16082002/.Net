✅🔥Grouping vs Joining
Grouping means: Divide one collection into multiple groups based on a common key.
Example: Suppose we have students.
Kapil  CSE
Rahul  IT
Amit   CSE
Neha   IT
Priya  ECE


After GroupBy() : One collection becomes multiple groups.
CSE
------
Kapil
Amit

IT
------
Rahul
Neha

ECE
------
Priya
----------------------------------------------------

✅ Joining:
Joining means: Combine two different collections based on a common key.
Return Type: IEnumerable<IGrouping<TKey,TElement>>

Students:
   Id Name
   1 Kapil
   2 Rahul
   3 Amit

Departments:
   Id Department
   1 CSE
   2 IT
   3 ECE

After Join:
    Kapil  CSE
    Rahul  IT
    Amit   ECE
Two collections become one result.

===================================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public int Age { get; set; }
}
class Department
{
    public int Id { get; set; }
    public string DepartmentName { get; set; }
}


// Create Student List
List<Student> students = new List<Student>() 
{
    new Student{ Id=1, Name="Kapil", Department="CSE", Age=23 },
    new Student{ Id=2, Name="Rahul", Department="IT", Age=21 },
    new Student{ Id=3, Name="Amit", Department="CSE", Age=22 },
    new Student{ Id=4, Name="Neha", Department="IT", Age=20 },
    new Student{ Id=5, Name="Priya", Department="ECE", Age=24 }
};
// Create Department List
List<Department> departments = new List<Department>()
{
    new Department{ Id=1, DepartmentName="CSE"},
    new Department{ Id=2, DepartmentName="IT"},
    new Department{ Id=3, DepartmentName="ECE"}
};
--------------------------------------------------------------

✅🔥 1. GroupBy()
GroupBy divides one collection into multiple groups.
Return type: IEnumerable<IGrouping<TKey,TElement>>


var result = students.GroupBy(s => s.Department); // Group using Department.
foreach(var group in result)
{
    Console.WriteLine(group.Key);
    foreach(var student in group)
    {
        Console.WriteLine(student.Name);
    }
}
Query Syntax:
var result =
from s in students
group s by s.Department;

--------------------------------------------------------------


✅🔥2. ToLookup()
It also groups data. Looks almost identical to GroupBy.
students.ToLookup(s=>s.Department); // Output same as GroupBy
Query Syntax ❌ No query syntax exists.

GroupBy
↓
Deferred Execution
var group = students.GroupBy(s=>s.Department);
Nothing happens yet.
Execution starts only when foreach(...) runs.


ToLookup
↓
Immediate Execution
var lookup = students.ToLookup(s=>s.Department);
Immediately creates all groups.


| GroupBy                                         | ToLookup                  |
| ----------------------------------------------- | ------------------------- |
| Deferred Execution                              | Immediate Execution       |
| Returns IEnumerable                             | Returns ILookup           |
| Can change if source changes before enumeration | Snapshot at creation time |

--------------------------------------------------------------------------------

✅🔥 Join                                                                    

var result =
students.Join
(
departments,

student=>student.Id,
department=>department.Id,

(student,department)=>new
{
student.Name,
department.DepartmentName
}
);
foreach(var item in result)
{
Console.WriteLine(item.Name+" "+item.DepartmentName);
}
Output:
Kapil CSE
Amit CSE
Rahul IT
Neha IT



✅Query Syntax:
var result =
from s in students
join d in departments
on s.Id equals d.Id
select new
{
s.Name,
d.DepartmentName
};


✅SQL:
SELECT * FROM Students
INNER JOIN Departments ON Students.Id=Departments.Id

-----------------------------------------------------------

✅🔥GroupJoin()
This is similar to SQL Left Join grouping.
Join gives: One department -> One student
GroupJoin gives: One department -> Many students


var result =
departments.GroupJoin
(
students,
d=>d.DepartmentName,
s=>s.Department,
(d,studentGroup)=>new
{
Department=d.DepartmentName,
Students=studentGroup
}
);
foreach(var dept in result)
{
      Console.WriteLine(dept.Department);
      foreach(var student in dept.Students)
      {
          Console.WriteLine(student.Name);
       }
}
CSE
Kapil
Amit

IT
Rahul
Neha

ECE
Priya



Query Syntax:

var result =
from d in departments
join s in students
on d.DepartmentName equals s.Department
into studentGroup
select new
{
Department=d.DepartmentName,
Students=studentGroup
};
------------------------------------------------------------






























