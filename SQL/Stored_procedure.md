# SQL Server Stored Procedure - Interview Questions & Notes

---

# What is a Stored Procedure?

A **Stored Procedure** is a precompiled collection of one or more SQL statements stored inside the database.

It is used to execute business logic, perform CRUD operations, improve performance, and enhance security.

---

# Basic Syntax

```sql
CREATE PROCEDURE ProcedureName
AS
BEGIN
    -- SQL Statements
END;
```

Execute Procedure

```sql
EXEC ProcedureName;
```

---

# Stored Procedure with Parameters

```sql
CREATE PROCEDURE GetEmployeeById
    @Id INT
AS
BEGIN
    SELECT *
    FROM Employee
    WHERE Id=@Id;
END;
```

Execute

```sql
EXEC GetEmployeeById 5;
```

---

# Insert using Stored Procedure

```sql
CREATE PROCEDURE AddEmployee
(
    @Name VARCHAR(100),
    @Department VARCHAR(50),
    @Salary INT
)
AS
BEGIN
    INSERT INTO Employee(Name,Department,Salary)
    VALUES(@Name,@Department,@Salary);
END;
```

Execute

```sql
EXEC AddEmployee
'Rahul',
'IT',
60000;
```

---

# Update using Stored Procedure

```sql
CREATE PROCEDURE UpdateSalary
(
    @Id INT,
    @Salary INT
)
AS
BEGIN
    UPDATE Employee
    SET Salary=@Salary
    WHERE Id=@Id;
END;
```

---

# Delete using Stored Procedure

```sql
CREATE PROCEDURE DeleteEmployee
(
    @Id INT
)
AS
BEGIN
    DELETE FROM Employee
    WHERE Id=@Id;
END;
```

---

# Stored Procedure with IF

```sql
CREATE PROCEDURE CheckSalary
(
    @Salary INT
)
AS
BEGIN

    IF @Salary>50000
        PRINT 'High Salary'

    ELSE
        PRINT 'Low Salary'

END;
```

---

# Stored Procedure with Transaction

```sql
CREATE PROCEDURE TransferMoney
AS
BEGIN

    BEGIN TRANSACTION

    UPDATE Account
    SET Balance=Balance-1000
    WHERE Id=1

    UPDATE Account
    SET Balance=Balance+1000
    WHERE Id=2

    COMMIT

END;
```

---

# Stored Procedure with TRY CATCH

```sql
CREATE PROCEDURE SafeInsert
AS
BEGIN

BEGIN TRY

    INSERT INTO Employee
    VALUES(1,'John')

END TRY

BEGIN CATCH

    PRINT ERROR_MESSAGE()

END CATCH

END;
```

---

# Output Parameter

```sql
CREATE PROCEDURE EmployeeCount
(
    @Total INT OUTPUT
)
AS
BEGIN

SELECT @Total=COUNT(*)
FROM Employee

END;
```

Execute

```sql
DECLARE @Count INT

EXEC EmployeeCount @Count OUTPUT

SELECT @Count;
```

---

# Interview Theory Questions

## 1. What is a Stored Procedure?

A precompiled collection of SQL statements stored inside the database.

---

## 2. Why do we use Stored Procedures?

- Reusable code
- Better Performance
- Security
- Business Logic
- Reduce Network Traffic

---

## 3. What are the advantages of Stored Procedures?

- Faster execution
- Execution Plan Caching
- Code Reusability
- Easy Maintenance
- Security
- Centralized Business Logic

---

## 4. What are the disadvantages?

- Database dependent
- Harder debugging
- Large procedures become difficult to maintain

---

## 5. Difference between View and Stored Procedure?

| View | Stored Procedure |
|------|------------------|
| Virtual Table | Database Program |
| Mainly SELECT | CRUD Operations |
| No Parameters | Parameters Supported |
| Cannot contain IF/WHILE | Supports Logic |
| Used with SELECT | Used with EXEC |

---

## 6. Difference between Function and Stored Procedure?

| Function | Stored Procedure |
|----------|------------------|
| Returns Value/Table | Returns Result Set(s) |
| Used inside SELECT | Executed using EXEC |
| Cannot modify database state (generally) | Can perform INSERT UPDATE DELETE |

---

## 7. Can Stored Procedures return values?

Yes.

- Result Set
- Output Parameter
- Return Value

---

## 8. Can Stored Procedures accept parameters?

Yes.

Input Parameters

Output Parameters

---

## 9. Can Stored Procedures call another Stored Procedure?

Yes.

```sql
EXEC AnotherProcedure;
```

---

## 10. Can Stored Procedures contain Transactions?

Yes.

BEGIN TRANSACTION

COMMIT

ROLLBACK

---

## 11. Can Stored Procedures contain Loops?

Yes.

WHILE

---

## 12. Can Stored Procedures contain IF ELSE?

Yes.

---

## 13. Can Stored Procedures contain Cursors?

Yes.

---

## 14. Can Stored Procedures contain Temporary Tables?

Yes.

```sql
CREATE TABLE #Temp
```

---

## 15. Can Stored Procedures return multiple result sets?

Yes.

```sql
SELECT * FROM Employee

SELECT * FROM Department
```

---

## 16. What is EXEC?

Command used to execute Stored Procedures.

```sql
EXEC GetEmployee;
```

---

## 17. What is ALTER PROCEDURE?

Used to modify an existing Stored Procedure.

```sql
ALTER PROCEDURE GetEmployee
AS
BEGIN
SELECT *
FROM Employee
END
```

---

## 18. What is DROP PROCEDURE?

Deletes Stored Procedure.

```sql
DROP PROCEDURE GetEmployee;
```

---

## 19. What is WITH ENCRYPTION?

Encrypts Stored Procedure definition.

---

## 20. What is WITH RECOMPILE?

Forces SQL Server to generate a new execution plan every execution.

Useful when parameter values vary significantly.

---

# Syntax Questions

## Create Procedure

```sql
CREATE PROCEDURE ProcedureName
AS
BEGIN

END;
```

---

## Execute Procedure

```sql
EXEC ProcedureName;
```

---

## Alter Procedure

```sql
ALTER PROCEDURE ProcedureName
AS
BEGIN

END;
```

---

## Drop Procedure

```sql
DROP PROCEDURE ProcedureName;
```

---

# Scenario Based Interview Questions

### Q1

You have a query used in 15 different applications.

What should you do?

Answer:

Create a Stored Procedure.

---

### Q2

You don't want users accessing tables directly.

What will you use?

Answer:

Stored Procedure.

---

### Q3

You want to reuse business logic.

Answer:

Stored Procedure.

---

### Q4

You need better security.

Answer:

Stored Procedure.

---

### Q5

You need faster execution.

Answer:

Stored Procedure because SQL Server caches execution plans.

---

# Frequently Asked Interview Questions ⭐⭐⭐⭐⭐

| Question | Answer |
|----------|--------|
| What is Stored Procedure? | Precompiled SQL Program |
| Why use Stored Procedure? | Reusability Performance Security |
| How to execute Stored Procedure? | EXEC |
| Can it accept parameters? | Yes |
| Can it return values? | Yes |
| Can it perform CRUD? | Yes |
| Can it call another SP? | Yes |
| Can it contain IF ELSE? | Yes |
| Can it contain Loops? | Yes |
| Can it contain Transactions? | Yes |
| Can it contain TRY CATCH? | Yes |
| Difference between View and SP? | View is virtual table, SP is executable program |
| Difference between Function and SP? | Function returns value, SP performs operations |
| Can SP improve performance? | Yes, through execution plan caching |
| Can SP return multiple result sets? | Yes |

---

# One-Line Interview Summary

> A Stored Procedure is a precompiled, reusable SQL program stored inside the database. It supports parameters, CRUD operations, transactions, loops, conditions, exception handling, and execution plan caching, making applications faster, more secure, and easier to maintain.
