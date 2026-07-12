✅🔥 Controller vs ControllerBase
Both Base classes are provided by the Microsoft.AspNetCore.Mvc namespace, but they are designed for different application types.
    ControllerBase is intended for Web APIs (REST APIs).
    Controller is intended for ASP.NET Core MVC applications that return Views (HTML).


✅🔥Class Hierarchy:
The inheritance hierarchy is:

System.Object
      │
      ▼
ControllerBase
      │
      ▼
Controller

This means:
Every Controller is also a ControllerBase.
Controller inherits all the functionality of ControllerBase and adds additional MVC features.

========================================================================

✅🔥 What is ControllerBase?
ControllerBase is the base class for API controllers.
Definition: public abstract class ControllerBase

It contains everything required to build REST APIs, including:
   Routing support
   Model Binding
   Model Validation
   Action Results
   HTTP Status Codes
   Dependency Injection support

Since it is designed only for APIs, it does not include MVC view features.
The following members are not available:
❌ View()
❌ PartialView()
❌ ViewBag
❌ ViewData
❌ TempData


✅🔥 Why was ControllerBase introduced?
In older ASP.NET MVC versions, developers used the Controller class for both MVC applications and Web APIs.
That meant every API controller inherited features it never used, such as:

View()
PartialView()
ViewBag
ViewData
TempData
These features increase the size of the base class and are unnecessary for APIs that only return JSON or XML.
To solve this, ASP.NET Core introduced ControllerBase, which provides only API-related functionality.


✅🔥 When should you use ControllerBase?
Use ControllerBase when:
     You are building a REST API, Web APIs
     Your application returns JSON or XML.
     There are no Razor Views.
     You want a lightweight base class.
Whenever your controller does not return HTML Views, ControllerBase is usually the right choice.


✅🔥 Features Available in ControllerBase:
ControllerBase includes many useful members for API development.
1. Ok(): Returns HTTP 200 (OK).
2. Created(): Returns HTTP 201 (Created).
3. NoContent(): Returns HTTP 204.
3. BadRequest(): Returns HTTP 400.
4. NotFound(): Returns HTTP 404.
5. Unauthorized(): Returns HTTP 401.
6. Forbid(): Returns HTTP 403.
7. File(): Returns a file.

===================================================================================================================


✅🔥 What is Controller ?
Controller is the base class used for ASP.NET Core MVC applications.
Definition: public abstract class Controller : ControllerBase

Since it inherits from ControllerBase, it has:
   All API functionality
   Plus MVC View functionality

✅ Why use Controller? Use Controller when your application returns HTML pages using Razor Views.
Typical MVC applications:
   E-commerce websites
   Banking portals
   Admin dashboards
   Company websites
   Blogs
   CMS applications
These applications need to render HTML using Razor.


✅ Example: MVC Controller
using Microsoft.AspNetCore.Mvc;
namespace DemoApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

✅🔥Additional Methods and Features(properties) Provided by Controller:
✅1. View(): Returns a Razor View (.cshtml) to the browser.
public IActionResult Index()
{
    return View();
}
-----------------------------------------------
✅2. View(object model): Passes a model to the View.
public IActionResult Details()
{
    Product product = new Product
    {
        Id = 1,
        Name = "Laptop"
    };
    return View(product);
}
--------------------------------------------
✅3. PartialView(): Returns only a portion of a page.
return PartialView("_ProductCard");
Useful for reusable UI components.
--------------------------------------------
✅4. ViewBag
A dynamic object used to pass data from the controller to the view.
Note: ViewBag is dynamic and is not type-safe.
Controller:
public IActionResult Index()
{
    ViewBag.Message = "Welcome";
    return View();
}
--------------------------------------------
✅5. ViewData
Stores data using key-value pairs.
Controller:
public IActionResult Index()
{
    ViewData["Message"] = "Hello MVC";

    return View();
}
----------------------------------------------
✅6. TempData
Stores data for the current request and the next request, making it useful for redirects.
Controller:
public IActionResult Save()
{
    TempData["Success"] = "Product Saved";
    return RedirectToAction("Index");
}
public IActionResult Index()
{
    return View();
}

---------------------------------------
✅7. Json()
Purpose: Returns JSON.
Example:
public IActionResult GetProduct()
{
    return Json(new
    {
        Id = 1,
        Name = "Laptop"
    });
}
Output:
{
  "id": 1,
  "name": "Laptop"
}
------------------------------------------
✅8. Content()
Purpose: Returns plain text.
Example:
public IActionResult About()
{
    return Content("Welcome to ASP.NET Core MVC");
}
Output: Welcome to ASP.NET Core MVC

---------------------------------------------

✅9. File()
Purpose: Returns a file to the browser.
Example:
public IActionResult Download()
{
    byte[] fileBytes = System.IO.File.ReadAllBytes("Files/Report.pdf");
    return File(fileBytes, "application/pdf", "Report.pdf");
}
Browser downloads: Report.pdf
----------------------------------------------

✅ 10. PhysicalFile()
Purpose: Returns a file using its physical path.
Example:
public IActionResult Download()
{
    string path = @"C:\Files\Resume.pdf";
    return PhysicalFile(path, "application/pdf");
}
-------------------------------------------------

✅ 11. Redirect()
Instead of returning HTML or JSON, Redirect() sends an HTTP Redirect Response to the browser to make a new HTTP request to another URL.
public IActionResult GoGoogle()
{
    return Redirect("https://www.google.com");
}

===================================================================================================================

| Helper Method / Property | Purpose                              |
| ------------------------ | ------------------------------------ |
| `View()`                 | Return Razor View                    |
| `PartialView()`          | Return Partial View                  |
| `Json()`                 | Return JSON                          |
| `Content()`              | Return plain text                    |
| `File()`                 | Return file                          |
| `PhysicalFile()`         | Return physical file                 |
| `VirtualFile()`          | Return virtual file                  |
| `Redirect()`             | Redirect to URL                      |
| `RedirectToAction()`     | Redirect to another action           |
| `RedirectToRoute()`      | Redirect using route values          |
| `LocalRedirect()`        | Redirect to a local URL              |
| `Ok()`                   | Return HTTP 200                      |
| `Created()`              | Return HTTP 201                      |
| `CreatedAtAction()`      | Return HTTP 201 with action location |
| `Accepted()`             | Return HTTP 202                      |
| `BadRequest()`           | Return HTTP 400                      |
| `Unauthorized()`         | Return HTTP 401                      |
| `Forbid()`               | Return HTTP 403                      |
| `NotFound()`             | Return HTTP 404                      |
| `NoContent()`            | Return HTTP 204                      |
| `StatusCode()`           | Return any HTTP status code          |
| `ViewBag`                | Pass dynamic data to a View          |
| `ViewData`               | Pass key-value data to a View        |
| `TempData`               | Pass data across a redirect          |
| `ModelState`             | Access model validation state        |
| `HttpContext`            | Access the current HTTP context      |
| `Request`                | Access incoming request details      |
| `Response`               | Modify the outgoing response         |
| `User`                   | Access the authenticated user        |
| `RouteData`              | Access route values                  |

