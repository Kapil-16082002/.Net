✅🔥Controller Naming Convention
Every MVC Controller should end with the word
Controller:
   HomeController
   ProductController
   EmployeeController



✅🔥Creating Your First Controller:
using Microsoft.AspNetCore.Mvc; // This imports the ASP.NET Core MVC namespace. Without this namespace, the compiler won't recognize classes such as: Controller, ControllerBase, IActionResult, Ok(), View(), JSON(), Rdeirect().
public class ProductsController : Controller// By inheriting from Controller, your controller automatically gets many useful features: return View(), return ok(), return JSON(), return Redirect(), ViewBag, ViewData, TempData.
{
    public ProductsController() // Constructor runs every time a request creates a new controller instance.
    {
        Console.WriteLine("Controller Created");
    }
    public IActionResult Index()
    {
        return Ok();
    }
}
/* 
✅public IActionResult Index()
✅public: The method can be accessed by ASP.NET Core routing.
✅IActionResult: This is the return type. It means: "This action will return some kind of HTTP response."
Example:
              return Ok();
              return View();
              return Json();
              return Redirect();
              return NotFound();
              return BadRequest();
✅Index: This is the Action Method name.
When the browser requests: /Products/Index
ASP.NET Core executes this method.

✅return Ok() Method: Ok() creates an HTTP 200 OK response.
Since no data is passed to Ok(), the response body is empty.
You can also return data: return Ok("Hello"); // response Hello


return Ok(new Product { Id = 1,Name = "Laptop" });
Response:
{
    "id": 1,
    "name": "Laptop"
}
*/

✅🔥Another  Example:
using Microsoft.AspNetCore.Mvc;
namespace DemoMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Welcome to ASP.NET Core MVC");
        }
    }
}
Run: /Home/Index
Output: Welcome to ASP.NET Core MVC













