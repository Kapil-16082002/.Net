
✅🔥 Encapsulation:
Encapsulation is defined as the wrapping up of data and information in a single unit. 
Encapsulation is the process of hiding internal data by making variables private and exposing controlled access through public methods.

Example:
/*
In a company, there are different sections like the accounts section, finance section, sales section, etc. Now,
1.The finance section handles all the financial related transactions and keeps records of all the data related to finance.
2.Similarly, the sales section handles all the sales-related activities and keeps records of all the sales.

Now there may arise a situation when for some reason an official from the finance section needs 
all the data about sales in a particular month.
In this case, he is not allowed to directly access the data of the sales section.
He will first have to contact some other officer in the sales section and then request him to give the particular data.
This is what Encapsulation is. Here the data of the sales section and the employees that can manipulate them are wrapped under a single name “sales section”. 
*/
Key Features of Encapsulation:
1.Data Hiding: The internal state of an object is hidden from outside interference and misuse.
  Only the class's own methods can directly access and modify its fields.
2.Access Control: Access to the class members is controlled through access modifiers: private, public, and protected.
                   Private: Members declared as private are only accessible within the class itself.
                   Public: Members declared as public are accessible from outside the class.
                   Protected: Members declared as protected are accessible within the class and its derived classes

✅🔥Data hiding
Means: Preventing direct access to implementation details.

------------------------------------------------------------

✅🔥 Why Do We Need Encapsulation ?
Consider this class:
class BankAccount
{
    public double balance;
}
BankAccount account = new BankAccount();  
account.balance = -50000;  // Now outside code can do this, This is the problem

There is nothing stopping the caller from putting an invalid value into balance.



✅🔥Without Encapsulation:
Let's see a complete example.

using System;
class BankAccount
{
    private double balance;
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
        }
        else
        {
            Console.WriteLine("Invalid amount");
        }
    }
    public double GetBalance()
    {
        return balance;
    }
}
class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();
        Console.Write("Enter deposit amount: ");
        double amount = Convert.ToDouble(Console.ReadLine());
        account.Deposit(amount);
        Console.WriteLine("Balance: " + account.GetBalance());
    }
}
Instead of: public double balance;
we make the field: private double balance;
Then provide controlled methods: public void Deposit(double amount)


✅Without encapsulation:
Outside Code
     |
     | directly modifies
     v
  balance


✅With encapsulation:
Outside Code
     |
     v
 Deposit()
     |
     v
 Validation
     |
     v
 balance
So the object controls how its internal state can change.

-------------------------------------------------------------------

✅🔥 Getter and Setter Methods
A traditional way to encapsulate a field is:
Example:
using System;
class Employee
{
    private string name;
    public string GetName()
    {
        return name;
    }
    public void SetName(string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            name = value;
        }
    }
}
class Program
{
    static void Main()
    {
        Employee employee = new Employee();

        Console.Write("Enter employee name: ");
        string name = Console.ReadLine();

        employee.SetName(name);
        Console.WriteLine("Employee Name: " + employee.GetName());
    }
}
Input
Enter employee name: Kapil
Output
Employee Name: Kapil
10. What Problem Does the Setter Solve?

------------------------------------------------------

✅🔥 Encapsulation Using Properties:
C# provides a much cleaner mechanism than traditional getter/setter methods: Properties
Instead of:
private int marks;
public int GetMarks()
{
    return marks;
}
public void SetMarks(int value)
{
    marks = value
}


✅ You can write:
using System;
class Student
{
    private int marks;
    public int Marks
    {
        get {return marks;}
        set
        {
            if (value >= 0 && value <= 100)
            {
                marks = value;
            }
            else
            {
                Console.WriteLine("Invalid marks");
            }
        }
    }
}
class Program
{
    static void Main()
    {
        Student student = new Student();

        Console.Write("Enter marks: ");
        int marks = Convert.ToInt32(Console.ReadLine());

        student.Marks = marks;

        Console.WriteLine("Marks: " + student.Marks);
    }
}






















