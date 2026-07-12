✅🔥 Controller Class & ControllerBase:
The Controller is one of the three core components of the Model-View-Controller (MVC) architecture. 
It acts as the brain of an ASP.NET Core MVC application, receiving requests from users, processing them, interacting with models or services, and returning the appropriate response.
Without controllers, the application would not know how to process user requests or decide what content to return.


✅🔥 What is a Controller?
A Controller is a C# class that receives incoming HTTP requests, processes them, interacts with the business layer or database if necessary, and returns an appropriate response to the client.
In MVC, the Controller acts as a bridge between the View (User Interface) and the Model (Business Logic/Data).


✅🔥Responsibilities of a Controller
A controller is responsible for:
    Receiving HTTP requests.
    Reading route values, query strings, form data, or request bodies.
    Validating incoming data.
    Calling business logic or services.
    Communicating with the database (usually through services/repositories).
    Selecting the appropriate View or returning data.
    Returning an HTTP response.
Important: A controller should coordinate work, not contain complex business logic. 
           Business logic should be placed in services or models.

MVC Relationship:
                 User
                  │
                  ▼
             HTTP Request
                  │
                  ▼
             Controller
          ┌────────┴────────┐
          ▼                 ▼
       Model            View
          │                 │
          └────────┬────────┘
                   ▼
            HTTP Response

==================================================================================================================

✅🔥Why Controllers are Needed ?
Imagine an application without controllers.
Every request would directly access the database.

Browser
↓
Database
↓
Browser
❌Problems:
   No validation
   No security
   No business rules
   Difficult maintenance
   Poor architecture

-------------------------------------------------------

✅🔥Controller Architecture: The Controller sits between the View and the Model.

             Browser
             Browser
                │
        HTTP Request
                │
                ▼
          Routing System
                │
                ▼
        ProductController
                │
                ▼
        ProductService
                │
                ▼
        ProductRepository
                │
                ▼
            Database
                │
                ▲
          Product Data
                │
                ▲
         ProductController
                │
                ▼
              View
                │
                ▼
         HTTP Response

✅🔥 Controller Lifecycle:
Every HTTP request creates a new controller instance.
Example:
Request 1: Browser -> Create ProductController -> Execute Details() -> Destroy Controller
Request 2: Browser -> Create ProductController -> Execute Index() -> Destroy Controller


✅Step 1 : Client Sends HTTP Request
Everything begins when a client sends a request. The browser sends an HTTP request to the server.

-----------------------------------------------
✅Step 2 : Kestrel Receives the Request
ASP.NET Core applications run on Kestrel, which is the built-in web server.

Browser -> Kestrel -> ASP.NET Core Application
Kestrel:
   Listens for incoming requests.
   Accepts TCP connections.
   Creates HttpContext.
   Passes request to Middleware.
------------------------------------------------
✅Step 3 : Middleware Pipeline
Every request travels through middleware.
RequestException Middleware->HTTPS Middleware->Static File Middleware ->Authentication -> Authorization -> Routing-> MVC

Each middleware can:
   Continue the request
   Modify the request
   Stop the request
   Return a response immediately
Example:
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

------------------------------------------------
✅Step 4 : Routing Finds the Controller
Routing determines:
    Which Controller
    Which Action Method
Example:
GET
/products/getall

will match:
public class ProductsController : Controller
{
    public IActionResult GetAll()
    {
    }
}
Routing identifies:
    Controller
    ProductsController
    Action
    GetAll
-------------------------------------------------

✅Step 5 : MVC Creates Controller
After routing,
MVC creates the controller object. This does NOT happen when the application starts.
A new controller instance is created for every request.
Request 1 -> ProductsController() -> Request Completed -> Object Destroyed

--------------------------------------------------

✅Step 6 : Dependency Injection
Before the controller constructor runs, ASP.NET Core resolves all dependencies.

What is a Dependency? A dependency is simply another object that your class requires to do its work.
public class ProductsController : Controller
{
    private readonly ILogger<ProductsController> _logger; // ILogger<ProductsController> is a dependency because the controller needs it for logging.
}
More Examples of Dependencies:
A controller may depend on many services.
public class ProductsController : Controller
{
    private readonly ILogger<ProductsController> _logger;
    private readonly ProductService _productService;
    private readonly EmailService _emailService;
    private readonly IConfiguration _configuration;
}
Dependencies are:
   Logger
   Product Service
   Email Service
   Configuration

Who Creates the Dependency ?
ASP.NET Core Dependency Injection Container. This is a built-in object factory.
It is responsible for
   Creating objects
   Managing object lifetime
   Injecting dependencies
   Reusing services when needed

What is Dependency Injection ?
Dependency Injection (DI) is a design pattern in which the objects that a class needs (dependencies) are provided from the outside instead of the class creating them itself.
In simple words,
A class should not create the objects it needs. Instead, ASP.NET Core creates those objects and gives them to the class.

--------------------------------------------------------

✅ Step 7 : Controller Constructor Executes
Once dependencies are available, the constructor executes.
Example:
public class ProductsController : Controller
{
    public ProductsController()
    {
        Console.WriteLine("Controller Created");
    }
    public IActionResult Index()
    {
        return Ok();
    }
}
Output: Controller Created
The constructor executes once per request.
---------------------------------------------------

✅Step 8 : Action Filters Execute (Before)
Before the action method runs, ASP.NET Core executes filters.
Example:
Authorization Filter
↓
Resource Filter
↓
Action Filter
Example:
public class MyFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine("Before Action");
    }
}
Apply:
[MyFilter]
public IActionResult Index()
{
    return Ok();
}
Output: Before Action
-----------------------------------------------

✅Step 9 : Action Method Executes
Now the requested action executes.
Example:
public IActionResult Index()
{
    return Ok("Hello");
}
Execution:
Controller -> Index() -> Business Logic -> Return Result

---------------------------------------------------

✅Step 10 : Action Returns Result
The action returns an IActionResult.
Examples:
return View();
return Ok();
return Json(product);
return RedirectToAction("Index");
return NotFound();
The controller does not directly send the response. Instead, it returns an action result that MVC processes.

--------------------------------------------------

✅Step 11 : Action Filters Execute (After)
After the action method completes, the action filters execute again.
Example:
public override void OnActionExecuted(ActionExecutedContext context)
{
    Console.WriteLine("After Action");
}
Output:
Before Action
Action Executed
After Action

--------------------------------------------------

✅ Step 12 : Result Execution
The returned IActionResult is executed.
Example: return Json(employee); becomes , Employee Object -> JSON Serializer -> JSON -> HTTP Response
If returning a View: ViewResult -> Razor Engine -> HTML -> Response
If returning Ok(): Object -> JSON -> Response


---------------------------------------------------

✅ Step 13 : Response Sent to Client
After the result executes, ASP.NET Core generates the final HTTP response.
Example: HTTP/1.1 200 OK
Content-Type: application/json
{
   "id":1,
   "name":"Laptop"
}
The response travels back through the middleware pipeline and is sent to the client.

----------------------------------------------------------

✅ Step 14 : Controller Disposal
Once the response is sent, the controller instance is no longer needed.
If the controller or its dependencies implement IDisposable or IAsyncDisposable, ASP.NET Core disposes of them appropriately.

Controller Created -> Action Executes -> Response Sent -> Controller Destroyed
A new controller object will be created for the next request.

----------------------------------------------------------------
✅🔥Complete code example:
using Microsoft.AspNetCore.Mvc;
namespace DemoApp.Controllers
{
    public class ProductsController : Controller
    {
        public ProductsController()
        {
            Console.WriteLine("1. Constructor Executed");
        }
        public IActionResult Index()
        {
            Console.WriteLine("2. Action Executed");

            return Ok("Hello ASP.NET Core");
        }
    }
}





