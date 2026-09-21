A **Window Function** in SQL performs a calculation **across a set of rows related to the current row** **without grouping the rows into a single result**.

> **Simple definition:**
> A window function lets you calculate values (ranking, running totals, averages, etc.) while **still returning every row**.

---

# Why do we need Window Functions?

Suppose we have an `Employees` table.

| EmployeeID | Name  | Department | Salary |
| ---------- | ----- | ---------- | ------ |
| 1          | John  | IT         | 50000  |
| 2          | Alice | IT         | 60000  |
| 3          | Bob   | HR         | 45000  |
| 4          | David | HR         | 55000  |
| 5          | Emma  | IT         | 70000  |

Suppose you want to display:

* Employee Name
* Salary
* Average salary of their department

Without window functions, this requires joins or subqueries.

With window functions, it's very simple.

---

# Syntax

```sql
Function() OVER (
    PARTITION BY column
    ORDER BY column
)
```

The `OVER()` clause is what makes a function a **window function**.

---

# Components of OVER()

```sql
OVER(
    PARTITION BY ...
    ORDER BY ...
)
```

## 1. PARTITION BY

Divides rows into groups.

Think of it like **GROUP BY**, except it **doesn't collapse the rows**.

Example:

```sql
PARTITION BY Department
```

creates windows like

```
IT
----
John
Alice
Emma

HR
----
Bob
David
```

Each department is processed separately.

---

## 2. ORDER BY

Determines the order within each partition.

Example

```sql
ORDER BY Salary DESC
```

IT becomes

```
Emma 70000
Alice 60000
John 50000
```

HR becomes

```
David 55000
Bob   45000
```

---

# Example 1: Average Salary

```sql
SELECT
    Name,
    Department,
    Salary,
    AVG(Salary) OVER(PARTITION BY Department) AS AvgSalary
FROM Employees;
```

Output

| Name  | Dept | Salary | AvgSalary |
| ----- | ---- | ------ | --------- |
| John  | IT   | 50000  | 60000     |
| Alice | IT   | 60000  | 60000     |
| Emma  | IT   | 70000  | 60000     |
| Bob   | HR   | 45000  | 50000     |
| David | HR   | 55000  | 50000     |

Notice:

Every employee is still shown.

---

Compare with `GROUP BY`:

```sql
SELECT Department,
       AVG(Salary)
FROM Employees
GROUP BY Department;
```

Output

| Department | Average |
| ---------- | ------- |
| IT         | 60000   |
| HR         | 50000   |

Only **2 rows** remain because `GROUP BY` combines rows.

---

# Example 2: ROW_NUMBER()

Assigns a unique number.

```sql
SELECT
    Name,
    Salary,
    ROW_NUMBER() OVER(ORDER BY Salary DESC) AS RowNum
FROM Employees;
```

Output

| Name  | Salary | RowNum |
| ----- | ------ | ------ |
| Emma  | 70000  | 1      |
| Alice | 60000  | 2      |
| David | 55000  | 3      |
| John  | 50000  | 4      |
| Bob   | 45000  | 5      |

---

# Example 3: RANK()

```sql
SELECT
    Name,
    Salary,
    RANK() OVER(ORDER BY Salary DESC) AS Rank
FROM Employees;
```

If salaries are

| Name  | Salary |
| ----- | ------ |
| Emma  | 70000  |
| Alice | 60000  |
| David | 60000  |
| John  | 50000  |

Result

| Name  | Salary | Rank |
| ----- | ------ | ---- |
| Emma  | 70000  | 1    |
| Alice | 60000  | 2    |
| David | 60000  | 2    |
| John  | 50000  | 4    |

Notice:

Rank **3 is skipped**.

---

# Example 4: DENSE_RANK()

```sql
SELECT
    Name,
    Salary,
    DENSE_RANK() OVER(ORDER BY Salary DESC) AS Rank
FROM Employees;
```

Output

| Name  | Salary | Rank |
| ----- | ------ | ---- |
| Emma  | 70000  | 1    |
| Alice | 60000  | 2    |
| David | 60000  | 2    |
| John  | 50000  | 3    |

No skipped numbers.

---

# Example 5: Running Total

```sql
SELECT
    Name,
    Salary,
    SUM(Salary) OVER(ORDER BY EmployeeID) AS RunningTotal
FROM Employees;
```

Output

| Employee | Salary | Running Total |
| -------- | ------ | ------------- |
| John     | 50000  | 50000         |
| Alice    | 60000  | 110000        |
| Bob      | 45000  | 155000        |
| David    | 55000  | 210000        |
| Emma     | 70000  | 280000        |

---

# Example 6: Highest Salary in Each Department

```sql
SELECT
    Name,
    Department,
    Salary,
    MAX(Salary) OVER(PARTITION BY Department) AS HighestSalary
FROM Employees;
```

Output

| Name  | Dept | Salary | Highest Salary |
| ----- | ---- | ------ | -------------- |
| John  | IT   | 50000  | 70000          |
| Alice | IT   | 60000  | 70000          |
| Emma  | IT   | 70000  | 70000          |
| Bob   | HR   | 45000  | 55000          |
| David | HR   | 55000  | 55000          |

---

# Common Window Functions

| Function        | Purpose                 |
| --------------- | ----------------------- |
| `ROW_NUMBER()`  | Unique row numbers      |
| `RANK()`        | Ranking with gaps       |
| `DENSE_RANK()`  | Ranking without gaps    |
| `NTILE()`       | Divide rows into groups |
| `LEAD()`        | Access next row         |
| `LAG()`         | Access previous row     |
| `FIRST_VALUE()` | First value in window   |
| `LAST_VALUE()`  | Last value in window    |
| `SUM()`         | Running total           |
| `AVG()`         | Running average         |
| `COUNT()`       | Count rows              |
| `MIN()`         | Minimum value           |
| `MAX()`         | Maximum value           |

---

# GROUP BY vs Window Function

| Feature           | GROUP BY | Window Function |
| ----------------- | -------- | --------------- |
| Returns all rows? | ❌ No     | ✅ Yes           |
| Aggregates data?  | ✅ Yes    | ✅ Yes           |
| Can rank rows?    | ❌ No     | ✅ Yes           |
| Running totals?   | ❌ No     | ✅ Yes           |
| Uses `OVER()`?    | ❌ No     | ✅ Yes           |

---

# Interview Question

**Q: What is the difference between `RANK()`, `DENSE_RANK()`, and `ROW_NUMBER()`?**

Suppose the salaries are:

| Salary |
| ------ |
| 100    |
| 90     |
| 90     |
| 80     |

| Function       | Result     |
| -------------- | ---------- |
| `ROW_NUMBER()` | 1, 2, 3, 4 |
| `RANK()`       | 1, 2, 2, 4 |
| `DENSE_RANK()` | 1, 2, 2, 3 |

* **`ROW_NUMBER()`**: Every row gets a unique number.
* **`RANK()`**: Equal values share the same rank, and the next rank is skipped.
* **`DENSE_RANK()`**: Equal values share the same rank, but no ranks are skipped.

---

## Quick Memory Trick

* **`OVER()`** → Makes a function a **window function**.
* **`PARTITION BY`** → Splits rows into groups **without reducing the number of rows**.
* **`ORDER BY`** → Defines the order within each group.
* **`GROUP BY`** → One result per group.
* **Window Functions** → One result **per row**, with calculations based on related rows.

> **Remember:** *`GROUP BY` groups rows into fewer results; window functions analyze groups while keeping every original row visible.*

---
---

# 1. What is a Window Function?

**Answer:**
A window function performs calculations across a set of rows related to the current row without collapsing the rows into a single result.

It always uses the `OVER()` clause.

Example:

```sql
SELECT Name,
       Salary,
       AVG(Salary) OVER() AS AvgSalary
FROM Employees;
```

---

# 2. Why is it called a "Window" Function?

**Answer:**

Because SQL creates a **window (subset of rows)** around the current row and performs calculations within that window.

For example:

```
Entire Table

John
Alice
Bob
David
Emma

Current Row = Bob

Window = All rows (or partition)
```

---

# 3. What is the difference between `GROUP BY` and Window Functions?

| GROUP BY                 | Window Function                    |
| ------------------------ | ---------------------------------- |
| Reduces rows             | Keeps all rows                     |
| One row per group        | One row per original row           |
| Uses aggregate functions | Uses aggregate + ranking functions |
| No `OVER()`              | Requires `OVER()`                  |

Example:

```sql
SELECT Department,
       AVG(Salary)
FROM Employees
GROUP BY Department;
```

returns

```
IT   60000
HR   50000
```

Whereas

```sql
SELECT Name,
       Department,
       Salary,
       AVG(Salary) OVER(PARTITION BY Department)
FROM Employees;
```

returns every employee.

---

# 4. What is the purpose of the `OVER()` clause?

**Answer:**

`OVER()` tells SQL **which rows should be considered for the calculation**.

Without `OVER()`, functions like `ROW_NUMBER()` or `RANK()` cannot be used.

---

# 5. What does `PARTITION BY` do?

**Answer:**

It divides rows into groups but **does not reduce the number of rows**.

Example:

```sql
AVG(Salary)
OVER(PARTITION BY Department)
```

calculates the average salary separately for each department.

---

# 6. What is the purpose of `ORDER BY` inside `OVER()`?

**Answer:**

It determines the order of rows within each partition.

Example:

```sql
ROW_NUMBER()
OVER(ORDER BY Salary DESC)
```

assigns row numbers based on salary in descending order.

---

# 7. Difference between `ROW_NUMBER()`, `RANK()`, and `DENSE_RANK()`?

Suppose salaries are

| Salary |
| ------ |
| 100    |
| 90     |
| 90     |
| 80     |

| Function     | Result  |
| ------------ | ------- |
| ROW_NUMBER() | 1 2 3 4 |
| RANK()       | 1 2 2 4 |
| DENSE_RANK() | 1 2 2 3 |

**Key points:**

* `ROW_NUMBER()` → unique numbers
* `RANK()` → skips rank after ties
* `DENSE_RANK()` → no skipped ranks

---

# 8. What is `NTILE()`?

It divides rows into a specified number of groups.

Example

```sql
SELECT Name,
       Salary,
       NTILE(4) OVER(ORDER BY Salary DESC)
FROM Employees;
```

Output

```
Quartile 1
Quartile 2
Quartile 3
Quartile 4
```

---

# 9. What is `LAG()`?

Returns the **previous row's value**.

Example

```sql
SELECT Name,
       Salary,
       LAG(Salary) OVER(ORDER BY Salary) AS PreviousSalary
FROM Employees;
```

Output

| Salary | Previous |
| ------ | -------- |
| 40000  | NULL     |
| 50000  | 40000    |
| 60000  | 50000    |

---

# 10. What is `LEAD()`?

Returns the **next row's value**.

```sql
SELECT Name,
       Salary,
       LEAD(Salary) OVER(ORDER BY Salary)
FROM Employees;
```

---

# 11. Difference between `LEAD()` and `LAG()`?

| LAG          | LEAD     |
| ------------ | -------- |
| Previous row | Next row |

---

# 12. How do you calculate a Running Total?

```sql
SELECT
    Name,
    Salary,
    SUM(Salary)
    OVER(ORDER BY EmployeeID) AS RunningTotal
FROM Employees;
```

---

# 13. How do you find the highest salary in each department?

```sql
SELECT
    Name,
    Department,
    Salary,
    MAX(Salary)
    OVER(PARTITION BY Department) AS HighestSalary
FROM Employees;
```

---

# 14. How do you find the second highest salary using a window function?

```sql
SELECT Salary
FROM
(
    SELECT Salary,
           DENSE_RANK() OVER(ORDER BY Salary DESC) AS Rnk
    FROM Employees
) t
WHERE Rnk = 2;
```

---

# 15. How do you find the top 3 salaries in each department?

```sql
SELECT *
FROM
(
    SELECT *,
           ROW_NUMBER() OVER
           (
             PARTITION BY Department
             ORDER BY Salary DESC
           ) AS RN
    FROM Employees
) t
WHERE RN <= 3;
```

---

# 16. Can aggregate functions be used as window functions?

Yes.

Examples:

* `SUM()`
* `AVG()`
* `COUNT()`
* `MIN()`
* `MAX()`

Example

```sql
SUM(Salary)
OVER(PARTITION BY Department)
```

---

# 17. Is every aggregate function a window function?

No.

An aggregate function becomes a window function **only when used with `OVER()`**.

Example

Aggregate

```sql
SELECT AVG(Salary)
FROM Employees;
```

Window Function

```sql
SELECT AVG(Salary)
OVER()
FROM Employees;
```

---

# 18. Can a Window Function be used in the `WHERE` clause?

**No.**

❌ Incorrect

```sql
SELECT *
FROM Employees
WHERE ROW_NUMBER() OVER(ORDER BY Salary) = 1;
```

Use a subquery or CTE instead:

```sql
WITH RankedEmployees AS
(
    SELECT *,
           ROW_NUMBER() OVER(ORDER BY Salary DESC) AS RN
    FROM Employees
)
SELECT *
FROM RankedEmployees
WHERE RN = 1;
```

---

# 19. Can multiple Window Functions be used in one query?

Yes.

```sql
SELECT
    Name,
    Salary,
    ROW_NUMBER() OVER(ORDER BY Salary) AS RN,
    RANK() OVER(ORDER BY Salary) AS Rnk,
    AVG(Salary) OVER() AS AvgSalary
FROM Employees;
```

---

# 20. What are common real-world uses of Window Functions?

* Employee ranking
* Sales leaderboards
* Running totals
* Monthly revenue trends
* Comparing current and previous values
* Finding duplicates
* Pagination
* Top N records per group
* Calculating moving averages

---

# Coding Questions

### Q1. Find the highest-paid employee in each department.

```sql
WITH Ranked AS
(
    SELECT *,
           ROW_NUMBER() OVER
           (
               PARTITION BY Department
               ORDER BY Salary DESC
           ) AS RN
    FROM Employees
)
SELECT *
FROM Ranked
WHERE RN = 1;
```

---

### Q2. Find duplicate records.

```sql
SELECT *,
       COUNT(*) OVER(PARTITION BY Email) AS DuplicateCount
FROM Users;
```

---

### Q3. Display each employee's salary difference from the previous employee.

```sql
SELECT
    Name,
    Salary,
    Salary - LAG(Salary)
        OVER(ORDER BY Salary) AS Difference
FROM Employees;
```

---

### Q4. Show cumulative sales.

```sql
SELECT
    OrderDate,
    Amount,
    SUM(Amount)
        OVER(ORDER BY OrderDate) AS RunningTotal
FROM Orders;
```

---

### Q5. Find the top 2 employees from every department.

```sql
WITH Ranked AS
(
    SELECT *,
           DENSE_RANK() OVER
           (
               PARTITION BY Department
               ORDER BY Salary DESC
           ) AS Rnk
    FROM Employees
)
SELECT *
FROM Ranked
WHERE Rnk <= 2;
```

---

# Quick Interview Cheat Sheet

| Question                                        | Short Answer                                                                        |
| ----------------------------------------------- | ----------------------------------------------------------------------------------- |
| What is a Window Function?                      | Calculates across related rows without collapsing them.                             |
| Which clause makes it a Window Function?        | `OVER()`                                                                            |
| What does `PARTITION BY` do?                    | Divides rows into logical groups while keeping all rows.                            |
| What does `ORDER BY` do in `OVER()`?            | Defines the order within each partition.                                            |
| Difference between `RANK()` and `DENSE_RANK()`? | `RANK()` skips numbers after ties; `DENSE_RANK()` does not.                         |
| Difference between `ROW_NUMBER()` and `RANK()`? | `ROW_NUMBER()` always assigns unique numbers; `RANK()` gives the same rank to ties. |
| What does `LAG()` do?                           | Returns the previous row's value.                                                   |
| What does `LEAD()` do?                          | Returns the next row's value.                                                       |
| Can Window Functions be used in `WHERE`?        | No, use a CTE or subquery.                                                          |
| Can `SUM()` and `AVG()` be window functions?    | Yes, when used with `OVER()`.                                                       |

For **SQL Server interviews (2–5 years experience)**, the most frequently asked window functions are:

* `ROW_NUMBER()`
* `RANK()`
* `DENSE_RANK()`
* `LAG()`
* `LEAD()`
* `SUM() OVER()` (running totals)
* `AVG() OVER()`
* Top-N-per-group problems using `ROW_NUMBER()` or `DENSE_RANK()`
* Differences between `GROUP BY` and window functions
* Practical use of `PARTITION BY` and `ORDER BY` within `OVER()`.
