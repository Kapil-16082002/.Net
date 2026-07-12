✅🔥 Endpoint Routing in ASP.NET Core
Endpoint Routing is one of the core features of ASP.NET Core. Every request such as:
https://localhost:5001/Home/Index

must be mapped to the correct Controller and Action Method.
This mapping process is called Routing.
Without routing, ASP.NET Core would not know which piece of code should handle the incoming request.


✅🔥What is Routing ?
Routing is the process of matching an incoming HTTP request URL to a specific endpoint (Controller Action, Razor Page, Minimal API, etc.).
Simply put,
Routing tells ASP.NET Core which code should execute for a given URL.


For example:
User enters: https://localhost:5001/Home/Index
Routing determines:
Controller → HomeController
Action → Index()


❌ Without Routing:
Imagine an application with 100 controllers.
    HomeController
    ProductController
    OrderController
    EmployeeController
    CustomerController
    AdminController
...
User requests:  /products/details/5
How does ASP.NET Core know to execute ?
ProductController.Details(5)
Without Routing, It doesn't , Routing solves this problem.


Request Flow: Browser -> HTTP Request -> Kestrel -> Middleware -> Routing -> Controller -> Action -> View -> Browser

---------------------------------------------------------------------------------------

✅🔥 Why Routing?
✅ 1. URL Mapping
Maps URLs to Controllers.
Example:  /products -> ProductController.Index()


✅2. Clean URLs
Instead of: Product.aspx?id=10
We get :/products/details/10   Much cleaner.


✅3. SEO Friendly
Search engines prefer,  /products/laptop   instead of  ?id=45&type=3


✅ 4. Decouples URLs from Files
Unlike older ASP.NET Web Forms: Home.aspx
MVC URLs don't correspond to physical files.

=================================================================================================================

✅🔥 Endpoint Routing Architecture:
Beginning with ASP.NET Core 3.0, Microsoft introduced Endpoint Routing.
Before ASP.NET Core 3.0, MVC itself was responsible for matching URLs to controller actions.

After ASP.NET Core 3.0, Microsoft separated routing from MVC and created a centralized routing system called Endpoint Routing.
This means that routing is now handled by the ASP.NET Core framework before MVC executes.


✅ Why was Endpoint Routing Introduced ?
Before ASP.NET Core 3.0
Browser
    ↓
Kestrel
    ↓
Middleware
    ↓
MVC Routing
    ↓
Controller
Routing existed inside MVC.
Only MVC knew how to match URLs.
Other frameworks like Razor Pages, SignalR, gRPC had their own routing systems.
There was no common routing engine.


✅🔥 After ASP.NET Core 3.0
Browser
    ↓
Kestrel
    ↓
Middleware
    ↓
Endpoint Routing
    ↓
Selected Endpoint
    ↓
MVC / Razor Pages / Minimal API / SignalR / gRPC

Now every framework uses the same routing engine.
Advantages:
✔ Faster
✔ Centralized
✔ Extensible
✔ Middleware can inspect routing information
✔ Supports all endpoint types

==================================================================================================================

✅🔥Route Matching:
Route Matching is the process of comparing the incoming URL against all registered route templates until a match is found.
Suppose we registered route templates:
    Home/Index
    Home/About
    Products/List
    Products/Details/{id}
Incoming request is /products/details/25
Routing checks:
   Home/Index ❌
   Home/About ❌
   Products/List ❌
Products/Details/{id} ✔ Matches. Then executes: ProductsController.Details(25)



Example: Controller
public class ProductController : Controller
{
    public IActionResult Details(int id)
    {
        return Content($"Product Id = {id}");
    }
}
Route: /Product/Details/15
Output: Product Id = 15

============================================================================================

✅🔥 Conventional Routing:
Conventional Routing uses one centralized route template that applies to many controllers.
Advantages: 
One route -> Entire application
Easy maintenance

Example:
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

Understanding the Template:
{controller} -> Controller Name
{action} -> Method Name
{id?} -> Optional Parameter

URL :  /Product/Details/10  will match
Controller -> ProductController
Action -> Details()
Parameter -> 10


Controller:
public class ProductController : Controller
{
    public IActionResult Details(int id)
    {
        return Content($"ID = {id}");
    }
}
Output: ID = 10

=================================================================================


✅🔥 Attribute Routing:
Attribute Routing defines routes directly on Controllers or Actions using attributes.
Instead of configuring routes only in Program.cs, you place route information close to the code it applies to.
Example:
[Route("products")]
public class ProductController : Controller
{
    [Route("{id}")]
    public IActionResult Details(int id)
    {
        return Content($"Product = {id}");
    }
}
Request:  /products/25
Output: Product = 25

==================================================================================

Conventional Routing vs Attribute Routing:

| Conventional Routing              | Attribute Routing                       |
| --------------------------------- | --------------------------------------- |
| Defined in `Program.cs`           | Defined on controllers/actions          |
| Centralized                       | Distributed                             |
| Easy for MVC apps                 | Better for APIs                         |
| One template for many controllers | Each endpoint can have its own template |

==================================================================================

✅🔥 Route Parameters:
Route parameters allow values from the URL to be passed into an action method.
Example:
Route: /products/15
Controller
[Route("products")]
public class ProductController : Controller
{
    [HttpGet("{id}")]
    public IActionResult Details(int id)
    {
        return Content($"Product Id = {id}");
    }
}
Output: Product Id = 15


Multiple Parameters:
[HttpGet("{category}/{id}")]
public IActionResult Details(string category, int id)
{
    return Content($"{category} {id}");
}
Request: /products/electronics/100
Output: electronics 100


==================================================================


✅🔥 Route Constraints:
Constraints restrict which URLs match a route by requiring parameter values to satisfy specific rules.
Example:\\\
[HttpGet("{id:int}")]
public IActionResult Details(int id)
{
    return Content(id.ToString());
}

Valid

/products/15

Invalid

/products/abc

The second request does not match the route and usually results in a 404 Not Found because "abc" is not an integer.


















































































