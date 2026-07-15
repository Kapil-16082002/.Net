✅🔥 Passing Data Using ViewData in ASP.NET Core MVC
ViewData is one of the built-in mechanisms used to pass data from a Controller to a View in ASP.NET Core MVC.
ASP.NET Core MVC provides three primary ways to pass data from a controller to a view:
   1. Strongly Typed Model (Recommended)
   2. ViewData
   3. ViewBag
Among these, Strongly Typed Models are recommended for business data, while ViewData is commonly used for passing small pieces of temporary information, such as page titles, messages, or counters.


✅🔥 What is ViewData ?
ViewData is a dictionary-based object (ViewDataDictionary) that allows a controller to pass data to a view using key-value pairs.
Internally, it stores values as object, allowing different data types to be stored in the same dictionary.
ViewData is a dictionary (ViewDataDictionary) that stores data as key-value pairs and transfers that data from a Controller to a View during the current request.


Think of ViewData as a dictionary (or a map).
   The key identifies the data.
   The value stores the actual information.
Example:
Key          Value
-------------------------
Name         Kapil
Age          23
City         Hyderabad

The controller stores values in the dictionary.
The view retrieves them using the same keys.

--------------------------------------------------------------


✅🔥 Why do we use ViewData?
Suppose we only need to send:
   Page Title
   Welcome Message
   Total Products
   Current Date
Creating a complete model class would be unnecessary. Instead, we can simply write: ViewData["Title"] = "Home Page";
The view can display it directly.

----------------------------------------------------------------

✅🔥 Internal Type of ViewData:
The Controller class contains a property:   public ViewDataDictionary ViewData
ViewDataDictionary internally behaves like:  Dictionary<string, object>
This means:
Key → string
Value → object


Example:
Controller
public IActionResult Index()
{
    ViewData["Message"] = "Welcome to ASP.NET Core MVC";
    return View();
}
View:   <h2>@ViewData["Message"]</h2>
Output: Welcome to ASP.NET Core MVC

------------------------------------------------------------

✅🔥 Type Casting:
Why Type Casting is Required ?
ViewData stores every value as an object.
Consider: ViewData["Age"] = 23;

internally:
Key = Age
Value = object
Although 23 is an integer, it is stored as an object.
Therefore, when using the value in C# code inside a Razor block, you may need to cast it back to its original type.


Example 1: 
Controller
public IActionResult Index()
{
    ViewData["Age"] = 23;
    return View();
}
View:
@{
    int age = (int)ViewData["Age"];
}
<p>Age : @age</p>

Output:     Age : 23































