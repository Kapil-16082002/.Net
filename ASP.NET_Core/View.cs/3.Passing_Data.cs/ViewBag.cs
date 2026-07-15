✅🔥 Passing Data Using ViewBag in ASP.NET Core MVC:
ViewBag is one of the three built-in mechanisms used to pass data from a Controller to a View in ASP.NET Core MVC.
The three approaches are:
    Strongly Typed Model (Recommended) ✅
    ViewBag
    ViewData
Although Strongly Typed Models are recommended for most scenarios, ViewBag is useful for passing small amounts of temporary data such as page titles, messages, or dropdown values.

-----------------------------------------------------

✅🔥 What is ViewBag?
ViewBag is a dynamic object provided by ASP.NET Core MVC that allows a controller to pass data to a view using dynamic properties.
Unlike a strongly typed model, ViewBag does not require creating a model class.

It allows you to write: 
ViewBag.Message = "Welcome"; instead of, ViewData["Message"] = "Welcome";

Simple Definition:
Think of ViewBag as a temporary bag.
The controller puts data into the bag.
The view takes data out of the bag.


✅ViewBag is declared as a dynamic object.
This means:
   Properties do not need to be declared beforehand.
   The compiler does not check whether a property exists.
   Properties are resolved at runtime.

Example:
ViewBag.Name = "Kapil";
There is no Name property declared anywhere.
The dynamic type allows it.

-------------------------------------------------------

✅🔥 Why do we use ViewBag?
Suppose you only need to display:
   Page Title
   Welcome Message
   Username
   Total Items
   Notification
Creating an entire model class would be unnecessary.
Instead:
ViewBag.Title = "Home";
The view can directly display it.

--------------------------------------------------------


✅🔥 
Syntax: ViewBag.PropertyName = value;
View: @ViewBag.PropertyName

Example:Controller
public IActionResult Index()
{
    ViewBag.Message = "Welcome to ASP.NET Core MVC";
    return View();
}
View: <h2>@ViewBag.Message</h2>
Output: Welcome to ASP.NET Core MVC


✅Internally What Happens?
Suppose we write: ViewBag.Name = "Kapil";
Internally it behaves like: ViewData["Name"] = "Kapil";
Similarly, ViewBag.City = "Delhi"; becomes  ViewData["City"] = "Delhi";
This is why ViewBag and ViewData always share the same underlying data.


--------------------------------------------------------------------------

✅🔥 Advantages of ViewBag
1. Simple Syntax:
ViewBag.Name = "Kapil";
Very easy to write.

✅2. No Model Class Required
For small values, there is no need to create a separate class.

✅3. Good for Temporary Data
Useful for:
   Page Title
   Welcome Message
   Notification
   Success Message
   Dropdown Lists (alongside a model)

✅4. Shares Data with ViewData
Internally both use the same ViewDataDictionary.


✅5. Flexible
Can store values of different types.
ViewBag.Name = "Kapil";
ViewBag.Age = 23;
ViewBag.IsAdmin = true;

----------------------------------------------------------------

✅🔥Disadvantages of ViewBag
1. Weakly Typed: No compile-time type checking.
2. No IntelliSense: The IDE cannot reliably suggest dynamic property names.
3. Runtime Errors:
      Typos are detected only when the application runs.
      Example: @ViewBag.Nmae
      Instead of: @ViewBag.Name
4. Difficult to Maintain:
   Large applications with many ViewBag properties become harder to understand and maintain because there is no explicit contract between the controller and the view.

5. Not Suitable for Complex Objects: 
   For forms, CRUD operations, and business entities, strongly typed models are a much better choice.




























