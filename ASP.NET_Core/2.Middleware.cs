/* 
Part 2: Middleware
What is Middleware?
Why Middleware?
Built-in Middleware
Custom Middleware
Use()
Run()
Map()
UseWhen()
MapWhen()
Terminal Middleware
Middleware ordering
Complete custom middleware examples
*/

✅🔥 What is Middleware ?
Middleware is a software component that sits inside the ASP.NET Core Request Pipeline and processes every incoming HTTP request and outgoing HTTP response.
For example:
   Logging
   Authentication
   Authorization
   Exception Handling
   Routing
   Static Files
   CORS
   Session
   Response Compression

✅Each middleware performs one specific responsibility.
      Process the request and pass it to the next middleware
      Process the request and stop the pipeline
Browser
   │
HTTP Request
   │
   ▼
+-------------------------+
| Logging Middleware      |
+-------------------------+
           │
           ▼
+-------------------------+
| Authentication          |
+-------------------------+
           │
           ▼
+-------------------------+
| Authorization           |
+-------------------------+
           │
           ▼
+-------------------------+
| Routing                 |
+-------------------------+
           │
           ▼
+-------------------------+
| MVC Controller          |
+-------------------------+
           │
HTTP Response
           ▲
           │
Browser

==================================================================================================================
✅🔥 Why Middleware?
Suppose middleware didn't exist. Every controller would have to write:
public IActionResult Index()
{
    LogRequest();
    AuthenticateUser();
    CheckPermission();
    HandleErrors();
    // Business Logic
    return View();
}
Now imagine 300 controllers. Every controller repeats the same code.
❌Problems:
   Code duplication
   Difficult maintenance
   Difficult debugging
   Security issues
   Poor scalability

✅With Middleware
Request
↓
Logging Middleware
↓
Authentication Middleware
↓
Authorization Middleware
↓
Controller
Now every request automatically gets:
   Logging
   Authentication
   Authorization
   Exception Handling
without writing code inside every controller.

✅Benefits:
✔ Separation of concerns
✔ Reusable
✔ Easy maintenance
✔ Better performance
✔ Highly modular
✔ Easy to insert/remove middleware
✔ Consistent request processing

=================================================================================================================

✅🔥 Built-in Middleware:
ASP.NET Core already provides many middleware components.

✅1. Exception Middleware  // Handles exceptions globally.
app.UseExceptionHandler("/Home/Error");
Purpose: Instead of crashing Program Return Friendly Error Page

✅2. HTTPS Redirection:
app.UseHttpsRedirection();
Request http://example.com
Automatically becomes https://example.com

✅3. Static Files Middleware
app.UseStaticFiles();
Serves:
  logo.png
  style.css
  script.js
  favicon.ico
without reaching MVC.

✅4. Routing Middleware
app.UseRouting();
Matches URL /Products/Details/5  to  ProductsController -> Details()

✅5. Authentication Middleware
app.UseAuthentication();
Determines: Who is the user?

✅5. Authorization Middleware
app.UseAuthorization();
Determines: Can this user access this resource?

✅6. Session Middleware
app.UseSession();
Enables session storage.

===============================================================================================================
✅🔥 Request Delegates
A Request Delegate is a method that processes an HTTP request.
Its signature is: Task RequestDelegate(HttpContext context)
A request delegate receives the current HttpContext and can produce a response or pass the request to the next middleware.

Example:
app.Run(async context =>
{
    await context.Response.WriteAsync("Hello ASP.NET Core");
});
Here, the lambda expression is the request delegate.


Another example:
app.Use(async (context, next) =>
{
    Console.WriteLine("Before Next");
    await next();
    Console.WriteLine("After Next");
});
context contains request and response information.
next() passes control to the next middleware.

==================================================================================================================

✅🔥 Use()
Use() registers middleware that can execute code before and after the next middleware.
Signature:
app.Use(async (context, next) =>
{
});
Example:
app.Use(async (context, next) =>
{
    Console.WriteLine("Before");
    await next();
    Console.WriteLine("After");
});
Output:

Before
↓
Controller
↓
After
Think of Use() as a wrapper around everything that comes after it.

================================================================================================================

✅🔥 Run()
Run() creates terminal middleware.
It does not receive a next delegate, so it cannot pass the request further.
Example:
app.Run(async context =>
{
    await context.Response.WriteAsync("Hello");
});
Flow:
Request
↓
Run()
↓
Response
↓
End
Nothing after Run() executes.

Example:
app.Run(async context =>
{
    await context.Response.WriteAsync("Hello");
});
app.UseRouting();
UseRouting() is never reached because Run() ends the pipeline.

================================================================================================================

✅🔥 Map()
Map() creates a branch in the middleware pipeline based on the request path.
Syntax:
app.Map("/admin", adminApp =>
{
    adminApp.Run(async context =>
    {
        await context.Response.WriteAsync("Admin Area");
    });
});
Requests: /admin
Output: Admin Area

Requests: /home
Skip this branch and continue through the main pipeline.

Visualization:
Request
   │
   ├── "/admin" ──► Admin Branch
   │                  │
   │                  ▼
   │              Response
   │
   └── Other URLs ──► Main Pipeline

================================================================================================================

✅🔥UseWhen()
UseWhen() conditionally adds middleware but returns to the main pipeline afterward.
Example:
app.UseWhen(
    context => context.Request.Path.StartsWithSegments("/api"),
    appBuilder =>
    {
        appBuilder.Use(async (context, next) =>
        {
            Console.WriteLine("API Request");
            await next();
        });
    });
Request: /api/products
Flow:
UseWhen
↓
API Middleware
↓
Back to Main Pipeline
↓
Controller

Request: /home
Skips the conditional middleware and continues normally.

==================================================================================================================

✅🔥 MapWhen()
MapWhen() creates a conditional branch. 
If the condition is true, the request enters the branch and does not return to the main pipeline unless you explicitly configure it.
Example:
app.MapWhen(
    context => context.Request.Query.ContainsKey("debug"),
    appBuilder =>
    {
        appBuilder.Run(async context =>
        {
            await context.Response.WriteAsync("Debug Mode");
        });
    });
Request: /home?debug=true
Flow:
Condition True
↓
Branch Pipeline
↓
Response
Request: /home
Condition is false, so the request stays in the main pipeline.



✅Difference Between UseWhen() and MapWhen()
| Feature                  | `UseWhen()`                        | `MapWhen()`                                                   |
| ------------------------ | ---------------------------------- | ------------------------------------------------------------- |
| Purpose                  | Add middleware conditionally       | Create a separate conditional branch                          |
| Returns to main pipeline | Yes                                | No (unless explicitly configured)                             |
| Typical use              | Logging, metrics, extra validation | Separate application behavior, diagnostics, special endpoints |


==============================================================================================================


✅🔥 Terminal Middleware
A terminal middleware ends the request pipeline.
It generates the response and does not call next().

Example using Run():
app.Run(async context =>
{
    await context.Response.WriteAsync("Pipeline Ended");
});
Flow:
Request
↓
Terminal Middleware
↓
Response
↓
End
Examples of terminal middleware:
   app.Run(...)
   Static Files (when a file is found)
   MVC endpoint
   Minimal API endpoint
===============================================================================================================

✅🔥 Middleware Ordering
Middleware order is extremely important because ASP.NET Core executes middleware in the order you register it.

Correct order:
app.UseExceptionHandler("/Home/Error");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

Flow:
Exception
↓
HTTPS
↓
Static Files
↓
Routing
↓
Authentication
↓
Authorization
↓
Controller


===============================================================================================================


Use Use() when you need to execute code before and after the next middleware.
Use Run() only when you intentionally want to terminate the pipeline.
Use Map() to create path-based branches (e.g., /admin).
Use UseWhen() for conditional middleware that should continue through the main pipeline.
Use MapWhen() for conditional branches that have their own processing pipeline.


























































