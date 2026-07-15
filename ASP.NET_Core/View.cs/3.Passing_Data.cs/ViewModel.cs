
✅🔥 Passing Data to Views in ASP.NET Core MVC:
A controller often needs to send data to a Razor View (.cshtml) so that it can be displayed to the user.
ASP.NET Core MVC provides three primary approaches for passing data from a controller to a view:
    1. Strongly Typed Data (ViewModel / Model) ✅ Recommended
    2. ViewData (Weakly Typed)
    3. ViewBag (Weakly Typed)

--------------------------------------------------------

✅🔥What is a Model ?
A Model is a C# class that represents the data and business information of an application.
In ASP.NET Core MVC, a model is responsible for:
    Representing application data
    Storing business information
    Transferring data between the controller and the view
    Receiving data from the database or user input
Simply put,
A Model is a C# object that contains the data that a View needs to display or that a Controller needs to process.


✅Real-World Example:
Imagine a class Employee, containing Employee Information
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
}
This class is called a Model.

--------------------------------------------------------

✅🔥 What is Passing Models ?
Passing Models is the process of sending a model object (or a collection of model objects) from a Controller to a View so that the view can display the data to the user.
The Controller creates or retrieves a model object and passes it to the View using the View(model) method.


✅🔥 Why Passing Models is Needed ? 

Consider the following controller:
public IActionResult Details()
{
    return View();
}
The view receives no data.
The controller returns the Details.cshtml view.
No model object is passed.
The View receives null as its model.

-------------------------------------------------------------------

✅🔥 How MVC Passes Data from Controller to View :
public IActionResult Details()
{
    Product product = new Product
    {
        Id = 1,
        Name = "Laptop",
        Price = 65000
    };
    return View(product);
}
✅Step 1 – Browser Sends Request
Browser: GET /Product/Details

✅Step 2 – Routing Finds Controller
Routing: ProductController -> Details()

✅Step 3 – Controller Creates Model
Product product = new Product();
Memory:
Product Object
Id = 1
Name = Laptop
Price = 65000

✅Step 4 – Controller Calls View()
return View(product);
The controller passes the object to View().

✅Step 5 – MVC Creates ViewResult
Internally,
View(product) -> ViewResult
The ViewResult object stores:
   View Name
   Model Object
   ViewData
   ViewBag
   TempData

✅Step 6 – Razor Receives Model
The view contains: @model Product
MVC assigns: Model -> Product Object

✅Step 7 – Razor Generates HTML
<h2>@Model.Name</h2>
<p>@Model.Price</p>
becomes->
<h2>Laptop</h2>
<p>65000</p>

✅Step 8 – Browser Receives HTML
Browser -> HTML -> Visible Web Page

-------------------------------------------------

✅ View Model Syntax:

Syntax 1 – Passing a Single Model
public IActionResult ActionName()
{
    ModelName model = new ModelName();
    return View(model);
}

✅ Complete Example:
Step 1 – Model
Product.cs
namespace DemoMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
Step 2 – Controller
ProductController.cs

using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;
namespace DemoMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Details()
        {
            Product product = new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 65000,
                Quantity = 10
            };
            return View(product);
        }
    }
}






































































































