
using System;
using System.Collections.Generic;
using System.Linq;

List<int> numbers = new List<int>
{
    10, 25, 8, 15, 30, 7, 40, 22, 18, 5
};
List<Employee> employees = new List<Employee>
{
    new Employee { Id = 1, Name = "John", Department = "IT", Salary = 50000, Age = 28 },
    new Employee { Id = 2, Name = "Alice", Department = "HR", Salary = 45000, Age = 30 },
    new Employee { Id = 3, Name = "Bob", Department = "IT", Salary = 70000, Age = 35 },
    new Employee { Id = 4, Name = "David", Department = "Finance", Salary = 60000, Age = 40 },
    new Employee { Id = 5, Name = "Emma", Department = "IT", Salary = 55000, Age = 26 }
};

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public int Salary { get; set; }
    public int Age { get; set; }
}
-----------------------------------------------------

✅🔥1. Find Even Numbers
Method Syntax:
var result = numbers.Where(x => x % 2 == 0);

Query Syntax:
var result =
    from n in numbers
    where n % 2 == 0
    select n;

Output:
10
8
30
40
22
18
----------------------------------------------------
✅🔥2. Find Odd Numbers
Method:
var result = numbers.Where(x => x % 2 != 0);
Query
var result =
    from n in numbers
    where n % 2 != 0
    select n;

---------------------------------------------------
✅🔥3. Numbers Greater Than 20
Method
var result = numbers.Where(x => x > 20);
Query
var result =
    from n in numbers
    where n > 20
    select n;

-------------------------------------------------------

✅🔥4. Square of Every Number
Method
var result = numbers.Select(x => x * x);
Query
var result =
    from n in numbers
    select n * n;

-----------------------------------------------------------
✅🔥5. Sort Numbers (Ascending)
Method
var result = numbers.OrderBy(x => x);
Query
var result =
    from n in numbers
    orderby n
    select n;

----------------------------------------------------------   
✅🔥 6. Sort Numbers (Descending)
Method
var result = numbers.OrderByDescending(x => x);
Query
var result =
    from n in numbers
    orderby n descending
    select n;
-----------------------------------------------------------

✅🔥 7. Employees with Salary Greater Than 50000
Method:
var result =
    employees.Where(e => e.Salary > 50000);
Query:
var result =
    from e in employees
    where e.Salary > 50000
    select e;
------------------------------------------------------------

✅🔥8. Employees from IT Department
Method
var result =
    employees.Where(e => e.Department == "IT");
Query
var result =
    from e in employees
    where e.Department == "IT"
    select e;
-------------------------------------------------------------

✅🔥9. Select Only Employee Names
Method
var result =
    employees.Select(e => e.Name);
Query
var result =
    from e in employees
    select e.Name;
-------------------------------------------------------------
✅🔥10. Select Name and Salary
Method
var result =
    employees.Select(e => new
    {
        e.Name,
        e.Salary
    });
Query:
var result =
    from e in employees
    select new
    {
        e.Name,
        e.Salary
    };
----------------------------------------------------------------
11. Highest Salary Employee
Method
var employee =
    employees.OrderByDescending(e => e.Salary)
             .First();
Query
var employee =
(
    from e in employees
    orderby e.Salary descending
    select e
).First();
-----------------------------------------------------------------
12. Lowest Salary Employee
Method
var employee =
    employees.OrderBy(e => e.Salary)
             .First();
Query
var employee =
(
    from e in employees
    orderby e.Salary
    select e
).First();
-----------------------------------------------------------------
13. Count Employees
Method
int count = employees.Count();
Query
int count =
(
    from e in employees
    select e
).Count();
--------------------------------------------------------------
14. Average Salary
Method
double avg =
    employees.Average(e => e.Salary);
Query
double avg =
(
    from e in employees
    select e.Salary
).Average();
-------------------------------------------------------------
15. Sum of Salaries
Method
int total =
    employees.Sum(e => e.Salary);
Query
int total =
(
    from e in employees
    select e.Salary
).Sum();
--------------------------------------------------------------
16. Find Employee by Id
Method
var emp =
    employees.FirstOrDefault(e => e.Id == 3);
Query
var emp =
(
    from e in employees
    where e.Id == 3
    select e
).FirstOrDefault();
------------------------------------------------------------------
17. Check If Any Employee Earns More Than 60000
Method
bool exists =
    employees.Any(e => e.Salary > 60000);
Query
bool exists =
(
    from e in employees
    where e.Salary > 60000
    select e
).Any();
------------------------------------------------------------------
18. Check If All Employees Are Adults
Method
bool adults =
    employees.All(e => e.Age >= 18);
Query
bool adults =
(
    from e in employees
    select e
).All(e => e.Age >= 18);

Note: All() is an aggregate operator and has no direct query keyword equivalent, so it is called after the query.

----------------------------------------------------------------------
19. Get First Three Employees
Method
var result =
    employees.Take(3);
Query
var result =
(
    from e in employees
    select e
).Take(3);
-----------------------------------------------------------------------
20. Skip First Two Employees
Method
var result =
    employees.Skip(2);
Query
var result =
(
    from e in employees
    select e
).Skip(2);

--------------------------------------------------------------------
21. Remove Duplicate Numbers
List<int> nums = new List<int>
{
    1,2,2,3,3,4,5,5
};
Method
var result =
    nums.Distinct();
Query
var result =
(
    from n in nums
    select n
).Distinct();
------------------------------------------------------------------
22. Group Employees by Department
Method
var result =
    employees.GroupBy(e => e.Department);
Query
var result =
    from e in employees
    group e by e.Department;

----------------------------------------------------------------
23. Employees Ordered by Salary Then Name
Method
var result =
    employees.OrderBy(e => e.Salary)
             .ThenBy(e => e.Name);
Query
var result =
    from e in employees
    orderby e.Salary, e.Name
    select e;
24. Employees Between Age 25 and 35
Method
var result =
    employees.Where(e => e.Age >= 25 &&
                         e.Age <= 35);
Query
var result =
    from e in employees
    where e.Age >= 25 &&
          e.Age <= 35
    select e;
25. Top Two Highest Salaries
Method
var result =
    employees.OrderByDescending(e => e.Salary)
             .Take(2);
Query
var result =
(
    from e in employees
    orderby e.Salary descending
    select e
).Take(2);
26. Find Second Highest Salary
Method
var employee =
    employees.OrderByDescending(e => e.Salary)
             .Skip(1)
             .First();
Query
var employee =
(
    from e in employees
    orderby e.Salary descending
    select e
).Skip(1).First();
27. Get Distinct Departments
Method
var result =
    employees.Select(e => e.Department)
             .Distinct();
Query
var result =
(
    from e in employees
    select e.Department
).Distinct();
28. Multiple Conditions
Method
var result =
    employees.Where(e =>
        e.Department == "IT" &&
        e.Salary > 50000);
Query
var result =
    from e in employees
    where e.Department == "IT"
       && e.Salary > 50000
    select e;
29. Order, Filter, and Project
Method
var result =
    employees
        .Where(e => e.Salary > 45000)
        .OrderBy(e => e.Name)
        .Select(e => new
        {
            e.Name,
            e.Salary
        });
Query
var result =
    from e in employees
    where e.Salary > 45000
    orderby e.Name
    select new
    {
        e.Name,
        e.Salary
    };
30. Convert Result to List
Method
List<Employee> list =
    employees.Where(e => e.Salary > 50000)
             .ToList();
Query
List<Employee> list =
(
    from e in employees
    where e.Salary > 50000
    select e
).ToList();