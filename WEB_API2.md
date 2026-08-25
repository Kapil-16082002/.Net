# Web API and REST with ASP.NET Core — Complete Learning Guide

> A practical, beginner-friendly guide covering REST principles, ASP.NET Core Web API setup, routing, EF Core integration, middleware, JWT authentication, Swagger, and global error handling — with real-world examples throughout, written for junior .NET developers.

---

## Table of Contents

1. [Introduction to REST and HTTP](#1-introduction-to-rest-and-http)
2. [RESTful API Design Guidelines](#2-restful-api-design-guidelines)
3. [Setting Up an ASP.NET Core Web API Project](#3-setting-up-an-aspnet-core-web-api-project)
4. [Understanding Routing and Controller Actions](#4-understanding-routing-and-controller-actions)
5. [Setting Up Entity Framework Core](#5-setting-up-entity-framework-core)
6. [ASP.NET Core Middleware](#6-aspnet-core-middleware)
7. [Implementing JWT and OAuth2 Authentication](#7-implementing-jwt-and-oauth2-authentication)
8. [Setting Up Swagger for API Documentation](#8-setting-up-swagger-for-api-documentation)
9. [Global Error Handling and Logging](#9-global-error-handling-and-logging)
10. [Summary Cheat Sheet](#10-summary-cheat-sheet)

---

## 1. Introduction to REST and HTTP

### What Is REST?

**REST (Representational State Transfer)** is an architectural style for designing web APIs. It defines a set of rules for how clients (browsers, mobile apps, other services) communicate with servers over HTTP. A system following these rules is called a **RESTful API**.

REST was defined by Roy Fielding in his 2000 PhD dissertation. It is now the dominant standard for web APIs — most cloud services (GitHub, Stripe, Google, Azure) expose RESTful APIs.

### Real-World Analogy 🍔

A restaurant menu is a RESTful interface:
- The **menu** = the API documentation (what resources exist, what you can do)
- **Ordering food** = sending a request to a resource (POST /orders)
- **Your table number** = the URL (the address of the resource you're acting on)
- **The waiter** = HTTP (the transport delivering your request and response)
- **The meal arriving** = the server's response (with data and a status code)

You don't go into the kitchen — you use the defined interface (the menu) to interact with the restaurant's resources.

### HTTP — The Foundation of REST

HTTP (HyperText Transfer Protocol) is the communication protocol REST is built on. Every REST API call is an HTTP request-response cycle.

```
HTTP REQUEST structure:
─────────────────────────────────────────────────────────
METHOD  URL                              HTTP Version
GET     /api/products/5                  HTTP/1.1
─────────────────────────────────────────────────────────
Headers:
  Host: api.myshop.com
  Authorization: Bearer eyJhbGci...
  Content-Type: application/json
  Accept: application/json
─────────────────────────────────────────────────────────
Body: (optional — used with POST, PUT, PATCH)
  {
    "name": "Wireless Keyboard",
    "price": 49.99
  }
─────────────────────────────────────────────────────────

HTTP RESPONSE structure:
─────────────────────────────────────────────────────────
Status Line:   HTTP/1.1  200  OK
─────────────────────────────────────────────────────────
Headers:
  Content-Type: application/json
  Content-Length: 128
─────────────────────────────────────────────────────────
Body:
  {
    "productId": 5,
    "name": "Wireless Keyboard",
    "price": 49.99,
    "stock": 42
  }
─────────────────────────────────────────────────────────
```

### HTTP Methods (Verbs)

```
GET     → Retrieve data. Read-only. Never modifies anything.
          Example: GET /api/products         → list all products
                   GET /api/products/5       → get product with id=5

POST    → Create a new resource.
          Example: POST /api/products        → create a new product
                   Body contains the new product data

PUT     → Replace an entire resource (full update).
          Example: PUT /api/products/5       → replace product 5 completely
                   Body must contain ALL fields

PATCH   → Partially update a resource (only what changed).
          Example: PATCH /api/products/5     → update just the price of product 5
                   Body contains only changed fields

DELETE  → Remove a resource.
          Example: DELETE /api/products/5    → delete product 5
```

### HTTP Status Codes — What Every Junior Dev Must Know

```
2xx — SUCCESS
  200 OK           → request succeeded, response body contains data
  201 Created      → resource created successfully (returned after POST)
  204 No Content   → success but nothing to return (common for DELETE, PUT)

3xx — REDIRECTION
  301 Moved Permanently → resource has a new permanent URL
  304 Not Modified      → client's cached version is still current

4xx — CLIENT ERRORS (the caller did something wrong)
  400 Bad Request       → malformed request, validation failed, bad JSON
  401 Unauthorized      → not logged in / no valid token provided
  403 Forbidden         → logged in but not allowed to do this action
  404 Not Found         → resource doesn't exist at this URL
  405 Method Not Allowed → wrong HTTP verb for this endpoint
  409 Conflict          → request conflicts with current state (duplicate email)
  422 Unprocessable Entity → validation errors (often used instead of 400)
  429 Too Many Requests → rate limit exceeded

5xx — SERVER ERRORS (something went wrong on the server)
  500 Internal Server Error → unhandled exception, bug in server code
  502 Bad Gateway           → upstream service (DB, third-party API) failed
  503 Service Unavailable   → server too busy or down for maintenance
  504 Gateway Timeout       → upstream service took too long to respond
```

### The Six REST Constraints

```
1. CLIENT-SERVER SEPARATION:
   The UI (client) and business logic (server) are separate.
   The API doesn't care what client is calling it — browser, mobile, CLI.

2. STATELESS:
   Each request contains ALL the information the server needs to process it.
   The server stores NO client session state between requests.
   Authentication token must be sent with EVERY request.

3. CACHEABLE:
   Responses should indicate whether they can be cached and for how long.
   GET responses are usually cacheable; POST/PUT/DELETE usually aren't.

4. UNIFORM INTERFACE:
   Resources are identified by URLs.
   Representation (JSON/XML) is separate from the resource.
   Self-descriptive messages (Content-Type headers).

5. LAYERED SYSTEM:
   The client doesn't know if it's talking to the real server, a load balancer,
   a cache, or a gateway — the interface remains the same.

6. CODE ON DEMAND (optional):
   Server can send executable code to clients (JavaScript).
   Rarely applied in REST APIs.
```

---

## 2. RESTful API Design Guidelines

### Resource Naming — The Golden Rules

```
RESOURCES ARE NOUNS, NOT VERBS:
  ✅ GET  /api/products          → get all products
  ✅ POST /api/products          → create a product
  ❌ GET  /api/getProducts       → wrong! verbs don't belong in URLs
  ❌ POST /api/createProduct     → wrong! the HTTP method is the verb

USE PLURAL NOUNS:
  ✅ /api/products          (not /api/product)
  ✅ /api/orders            (not /api/order)
  ✅ /api/customers         (not /api/customer)

USE LOWERCASE AND HYPHENS:
  ✅ /api/product-categories
  ❌ /api/ProductCategories
  ❌ /api/product_categories

HIERARCHICAL RELATIONSHIPS:
  GET /api/customers/42/orders         → all orders for customer 42
  GET /api/customers/42/orders/101     → order 101 belonging to customer 42
  POST /api/customers/42/orders        → create an order for customer 42

FILTERING, SORTING, PAGING — USE QUERY STRINGS:
  GET /api/products?category=electronics&minPrice=10&maxPrice=100
  GET /api/products?sortBy=price&order=desc
  GET /api/products?page=2&pageSize=20
  GET /api/products?search=keyboard
```

### Complete REST Resource Design — E-Commerce Example

```
RESOURCE: Products

  GET    /api/products              → list all products (with optional query filters)
  GET    /api/products/{id}         → get one product by id
  POST   /api/products              → create a new product (body: product data)
  PUT    /api/products/{id}         → replace product entirely (body: full product)
  PATCH  /api/products/{id}         → update partial product (body: changed fields)
  DELETE /api/products/{id}         → delete a product

RESOURCE: Orders (nested under customer)

  GET    /api/customers/{id}/orders          → all orders for a customer
  GET    /api/customers/{id}/orders/{orderId}→ specific order for a customer
  POST   /api/customers/{id}/orders          → place a new order
  PATCH  /api/orders/{orderId}/status        → update order status

RESOURCE: Authentication (not a typical resource but a REST convention)

  POST   /api/auth/register         → register a new user
  POST   /api/auth/login            → get a JWT token
  POST   /api/auth/refresh          → refresh an expired token
  POST   /api/auth/logout           → invalidate the current token
```

### Response Design Best Practices

```json
// ── Successful single resource (GET /api/products/5) ──────────────────
{
  "productId": 5,
  "name": "Wireless Keyboard",
  "price": 49.99,
  "stock": 42,
  "category": {
    "categoryId": 2,
    "name": "Electronics"
  }
}

// ── Successful list with pagination (GET /api/products?page=1&pageSize=20) ─
{
  "data": [
    { "productId": 1, "name": "Laptop", "price": 799.99 },
    { "productId": 2, "name": "Mouse",  "price": 24.99  }
  ],
  "pagination": {
    "page": 1,
    "pageSize": 20,
    "totalCount": 150,
    "totalPages": 8,
    "hasNextPage": true,
    "hasPreviousPage": false
  }
}

// ── Validation error (400 Bad Request) ───────────────────────────────
{
  "status": 400,
  "title": "Validation Failed",
  "errors": {
    "name": ["Name is required", "Name cannot exceed 100 characters"],
    "price": ["Price must be greater than 0"]
  }
}

// ── Not found (404) ───────────────────────────────────────────────────
{
  "status": 404,
  "title": "Not Found",
  "detail": "Product with id 999 was not found"
}

// ── Server error (500) ───────────────────────────────────────────────
{
  "status": 500,
  "title": "Internal Server Error",
  "detail": "An unexpected error occurred. Please try again later.",
  "traceId": "00-a1b2c3d4-e5f6g7h8-01"
}
```

### API Versioning

```
WHY: Once you publish a public API, you can't break existing clients.
     Adding fields is safe; removing or renaming them is a BREAKING CHANGE.

HOW: Introduce a new version for breaking changes:

  URL versioning (most common, most visible):
    /api/v1/products
    /api/v2/products   ← new version with breaking changes

  Header versioning (cleaner URLs, harder to test in browser):
    GET /api/products
    Accept: application/vnd.myapi.v2+json

  Query string versioning:
    GET /api/products?api-version=2.0
```

---

## 3. Setting Up an ASP.NET Core Web API Project

### Creating the Project

```bash
# Create a new Web API project
dotnet new webapi -n ShopApi
cd ShopApi

# Or with minimal API style (ASP.NET Core 6+)
dotnet new webapi -n ShopApi --use-minimal-apis

# Restore packages
dotnet restore

# Run the project
dotnet run
# API is now available at https://localhost:5001 or http://localhost:5000
```

### The Modern Minimal Program.cs (ASP.NET Core 6+)

```csharp
// Program.cs — the ENTIRE application setup in one file (no Startup.cs needed)
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ── 1. Register services ───────────────────────────────────────────────
builder.Services.AddControllers();

// Swagger / OpenAPI documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Entity Framework Core
builder.Services.AddDbContext<ShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS — allow a specific front-end origin to call this API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.WithOrigins("http://localhost:3000", "https://myshop.com")
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// ── 2. Build the application ───────────────────────────────────────────
var app = builder.Build();

// ── 3. Configure the HTTP request pipeline (middleware order matters!) ─
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");    // CORS before auth
app.UseAuthentication();          // who are you?
app.UseAuthorization();           // what can you do?

app.MapControllers();             // map attribute-routed controllers

app.Run();
```

### Project Folder Structure (Best Practice)

```
ShopApi/
├── Controllers/              ← API controllers
│   ├── ProductsController.cs
│   ├── OrdersController.cs
│   └── AuthController.cs
│
├── Models/                   ← domain/database entities
│   ├── Product.cs
│   ├── Order.cs
│   └── Customer.cs
│
├── DTOs/                     ← Data Transfer Objects (what the API receives/returns)
│   ├── Products/
│   │   ├── CreateProductDto.cs
│   │   ├── UpdateProductDto.cs
│   │   └── ProductResponseDto.cs
│   └── Auth/
│       ├── LoginRequestDto.cs
│       └── LoginResponseDto.cs
│
├── Services/                 ← business logic
│   ├── IProductService.cs
│   └── ProductService.cs
│
├── Repositories/             ← data access (optional if using EF directly in services)
│   ├── IProductRepository.cs
│   └── ProductRepository.cs
│
├── Data/                     ← EF Core DbContext and configurations
│   ├── ShopDbContext.cs
│   └── Configurations/
│       └── ProductConfiguration.cs
│
├── Middleware/               ← custom middleware
│   ├── ExceptionHandlingMiddleware.cs
│   └── RequestLoggingMiddleware.cs
│
├── appsettings.json
├── appsettings.Development.json
└── Program.cs
```

### Why Use DTOs (Data Transfer Objects)?

```csharp
// ❌ BAD: Returning your database entity directly
// This exposes internal fields (PasswordHash!), couples your API to your DB schema,
// and makes it impossible to shape the response independently of the entity

[HttpGet("{id}")]
public async Task<User> GetUser(int id) => await _db.Users.FindAsync(id)!;
// Response would include PasswordHash, InternalNotes, and any future DB columns

// ✅ GOOD: Return a DTO shaped for the API consumer
public class UserResponseDto
{
    public int    UserId   { get; set; }
    public string Username { get; set; } = "";
    public string Email    { get; set; } = "";
    // PasswordHash excluded — never exposed!
}

[HttpGet("{id}")]
public async Task<UserResponseDto?> GetUser(int id)
{
    var user = await _db.Users.FindAsync(id);
    if (user == null) return null;
    return new UserResponseDto { UserId = user.Id, Username = user.Username, Email = user.Email };
}

// ── Separate DTOs for Create vs Response ──────────────────────────────
public class CreateProductDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = "";

    [Required]
    [Range(0.01, 100000)]
    public decimal Price { get; set; }

    [Required]
    public int CategoryId { get; set; }
}

public class ProductResponseDto
{
    public int     ProductId    { get; set; }
    public string  Name         { get; set; } = "";
    public decimal Price        { get; set; }
    public int     Stock        { get; set; }
    public string  CategoryName { get; set; } = "";  // flattened for convenience
    public DateTime CreatedAt   { get; set; }
}
```

---

## 4. Understanding Routing and Controller Actions

### What Is a Controller?

A **Controller** in ASP.NET Core Web API is a class that handles HTTP requests. Each public method (called an **action**) handles a specific endpoint. The `[ApiController]` attribute enables many helpful behaviours automatically.

### A Complete REST Controller

```csharp
using Microsoft.AspNetCore.Mvc;

[ApiController]                          // enables automatic model validation, binding errors
[Route("api/[controller]")]              // route = "api/products" (from class name minus "Controller")
public class ProductsController : ControllerBase   // ControllerBase — no View support (API only)
{
    private readonly IProductService _productService;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IProductService productService, ILogger<ProductsController> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    // GET api/products
    // GET api/products?category=electronics&minPrice=10&page=1&pageSize=20
    [HttpGet]
    public async Task<ActionResult<PagedResponse<ProductResponseDto>>> GetAll(
        [FromQuery] string?  category  = null,
        [FromQuery] decimal? minPrice  = null,
        [FromQuery] decimal? maxPrice  = null,
        [FromQuery] int      page      = 1,
        [FromQuery] int      pageSize  = 20)
    {
        var result = await _productService.GetPagedAsync(category, minPrice, maxPrice, page, pageSize);
        return Ok(result);
    }

    // GET api/products/5
    [HttpGet("{id:int}")]                // route constraint: id must be an integer
    [ProducesResponseType(typeof(ProductResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductResponseDto>> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null)
            return NotFound(new { message = $"Product with id {id} was not found" });

        return Ok(product);
    }

    // POST api/products
    [HttpPost]
    [ProducesResponseType(typeof(ProductResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductResponseDto>> Create([FromBody] CreateProductDto dto)
    {
        // [ApiController] automatically returns 400 if model validation fails
        // so if we reach here, the model is valid
        var created = await _productService.CreateAsync(dto);

        // 201 Created with Location header pointing to the new resource
        return CreatedAtAction(nameof(GetById), new { id = created.ProductId }, created);
    }

    // PUT api/products/5
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto dto)
    {
        if (id != dto.ProductId)
            return BadRequest(new { message = "URL id and body id do not match" });

        var success = await _productService.UpdateAsync(id, dto);
        if (!success) return NotFound();

        return NoContent();   // 204 — success, nothing to return
    }

    // PATCH api/products/5/price
    [HttpPatch("{id:int}/price")]
    public async Task<IActionResult> UpdatePrice(int id, [FromBody] decimal newPrice)
    {
        if (newPrice <= 0) return BadRequest(new { message = "Price must be positive" });
        var success = await _productService.UpdatePriceAsync(id, newPrice);
        return success ? NoContent() : NotFound();
    }

    // DELETE api/products/5
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _productService.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}
```

### Routing Deep Dive

```csharp
// ── Route Templates ───────────────────────────────────────────────────

[Route("api/[controller]")]    // [controller] replaced with class name minus "Controller"
                               // ProductsController → api/products

[Route("api/v1/products")]     // fully explicit route

[HttpGet("{id}")]              // adds segment: api/products/{id}
[HttpGet("{id:int}")]          // route constraint: only matches integers
[HttpGet("{name:alpha}")]      // only alphabetic characters
[HttpGet("{id:int:min(1)}")]   // int AND must be >= 1
[HttpGet("{id:guid}")]         // must be a valid GUID

// ── Multiple routes on one action ─────────────────────────────────────
[HttpGet]
[HttpGet("list")]              // responds to BOTH /api/products AND /api/products/list
public IActionResult GetAll() => Ok();

// ── Nested resource routing ───────────────────────────────────────────
[Route("api/customers/{customerId:int}/orders")]
[ApiController]
public class CustomerOrdersController : ControllerBase
{
    // GET api/customers/42/orders
    [HttpGet]
    public async Task<IActionResult> GetOrders(int customerId) => Ok();

    // GET api/customers/42/orders/101
    [HttpGet("{orderId:int}")]
    public async Task<IActionResult> GetOrder(int customerId, int orderId) => Ok();

    // POST api/customers/42/orders
    [HttpPost]
    public async Task<IActionResult> CreateOrder(int customerId, [FromBody] CreateOrderDto dto) => Ok();
}
```

### Parameter Binding Sources

```csharp
// Where does ASP.NET Core get action parameter values from?

[HttpGet("{id}")]
public IActionResult Get(
    int id,                              // [FromRoute]   — from URL path segment {id}
    [FromQuery] string? search,          // [FromQuery]   — from ?search=value in URL
    [FromHeader(Name="X-API-Key")] string? apiKey,  // [FromHeader] — from HTTP header
    [FromBody] CreateProductDto dto)     // [FromBody]    — from JSON request body (POST/PUT)

// [ApiController] auto-infers:
// — Complex types (classes) → [FromBody]
// — Simple types (int, string) with a matching route param → [FromRoute]
// — Simple types without a matching route param → [FromQuery]

// [FromServices] — inject directly from DI container into the action (rarely needed)
public IActionResult Action([FromServices] IProductService svc) => Ok();
```

### Returning Correct Response Types

```csharp
// Helper methods on ControllerBase that set both status code AND body:
return Ok(data);              // 200 + body
return Created(uri, data);    // 201 + Location header + body
return CreatedAtAction(nameof(GetById), new { id = 5 }, data); // 201 with route Location
return NoContent();           // 204 — no body (DELETE success, PUT success)
return BadRequest();          // 400
return BadRequest(new { error = "message" });  // 400 + error body
return Unauthorized();        // 401
return Forbid();              // 403
return NotFound();            // 404
return NotFound(new { message = "..." }); // 404 + body
return Conflict(new { message = "Email already exists" }); // 409
return StatusCode(500, new { message = "..." }); // custom status code
return Problem("Detail", statusCode: 503); // RFC7807 ProblemDetails format
```

---

## 5. Setting Up Entity Framework Core

### Install Packages

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### Define Entities and DbContext

```csharp
// Models/Product.cs
public class Product
{
    public int     ProductId  { get; set; }
    public string  Name       { get; set; } = "";
    public decimal Price      { get; set; }
    public int     Stock      { get; set; }
    public bool    IsActive   { get; set; } = true;
    public int     CategoryId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Category? Category { get; set; }
}

// Models/Category.cs
public class Category
{
    public int    CategoryId { get; set; }
    public string Name       { get; set; } = "";
    public List<Product> Products { get; set; } = new();
}

// Data/ShopDbContext.cs
using Microsoft.EntityFrameworkCore;

public class ShopDbContext : DbContext
{
    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

    public DbSet<Product>  Products   { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Order>    Orders     { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopDbContext).Assembly);

        // Seed initial category data
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Electronics" },
            new Category { CategoryId = 2, Name = "Clothing"    },
            new Category { CategoryId = 3, Name = "Books"       }
        );
    }
}
```

### Register EF Core in Program.cs

```csharp
// Program.cs
builder.Services.AddDbContext<ShopDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 3,
            maxRetryDelay: TimeSpan.FromSeconds(5),
            errorNumbersToAdd: null)));
```

```json
// appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ShopDb;Integrated Security=True;TrustServerCertificate=True;"
  }
}
```

```json
// appsettings.Development.json — override for local dev
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=ShopDb_Dev;Integrated Security=True;TrustServerCertificate=True;"
  }
}
```

### Migrations and Database Setup

```bash
# Create the initial migration
dotnet ef migrations add InitialCreate

# Apply to the database
dotnet ef database update

# Useful for seeding development data
# Or in Program.cs:
```

```csharp
// Program.cs — apply migrations and seed automatically in development
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ShopDbContext>();
    await db.Database.MigrateAsync();   // creates DB + applies migrations
}
```

### A Complete Repository Pattern with EF Core

```csharp
// Services/ProductService.cs — business logic and EF Core usage
public interface IProductService
{
    Task<PagedResponse<ProductResponseDto>> GetPagedAsync(
        string? category, decimal? minPrice, decimal? maxPrice, int page, int pageSize);
    Task<ProductResponseDto?> GetByIdAsync(int id);
    Task<ProductResponseDto>  CreateAsync(CreateProductDto dto);
    Task<bool>                UpdateAsync(int id, UpdateProductDto dto);
    Task<bool>                UpdatePriceAsync(int id, decimal newPrice);
    Task<bool>                DeleteAsync(int id);
}

public class ProductService : IProductService
{
    private readonly ShopDbContext _db;

    public ProductService(ShopDbContext db) => _db = db;

    public async Task<PagedResponse<ProductResponseDto>> GetPagedAsync(
        string? category, decimal? minPrice, decimal? maxPrice, int page, int pageSize)
    {
        var query = _db.Products
            .Include(p => p.Category)
            .AsNoTracking()
            .Where(p => p.IsActive);

        if (!string.IsNullOrWhiteSpace(category))
            query = query.Where(p => p.Category!.Name == category);

        if (minPrice.HasValue) query = query.Where(p => p.Price >= minPrice);
        if (maxPrice.HasValue) query = query.Where(p => p.Price <= maxPrice);

        int totalCount = await query.CountAsync();

        var items = await query
            .OrderBy(p => p.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(p => new ProductResponseDto
            {
                ProductId    = p.ProductId,
                Name         = p.Name,
                Price        = p.Price,
                Stock        = p.Stock,
                CategoryName = p.Category!.Name,
                CreatedAt    = p.CreatedAt
            })
            .ToListAsync();

        return new PagedResponse<ProductResponseDto>(items, page, pageSize, totalCount);
    }

    public async Task<ProductResponseDto?> GetByIdAsync(int id)
    {
        return await _db.Products
            .Include(p => p.Category)
            .AsNoTracking()
            .Where(p => p.ProductId == id)
            .Select(p => new ProductResponseDto
            {
                ProductId    = p.ProductId,
                Name         = p.Name,
                Price        = p.Price,
                Stock        = p.Stock,
                CategoryName = p.Category!.Name,
                CreatedAt    = p.CreatedAt
            })
            .FirstOrDefaultAsync();
    }

    public async Task<ProductResponseDto> CreateAsync(CreateProductDto dto)
    {
        var product = new Product
        {
            Name       = dto.Name,
            Price      = dto.Price,
            CategoryId = dto.CategoryId,
            Stock      = 0
        };
        _db.Products.Add(product);
        await _db.SaveChangesAsync();

        return (await GetByIdAsync(product.ProductId))!;
    }

    public async Task<bool> UpdateAsync(int id, UpdateProductDto dto)
    {
        var product = await _db.Products.FindAsync(id);
        if (product == null) return false;

        product.Name       = dto.Name;
        product.Price      = dto.Price;
        product.CategoryId = dto.CategoryId;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdatePriceAsync(int id, decimal newPrice)
    {
        int rows = await _db.Products
            .Where(p => p.ProductId == id)
            .ExecuteUpdateAsync(s => s.SetProperty(p => p.Price, newPrice));
        return rows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        int rows = await _db.Products
            .Where(p => p.ProductId == id)
            .ExecuteDeleteAsync();
        return rows > 0;
    }
}
```

```csharp
// Register in Program.cs
builder.Services.AddScoped<IProductService, ProductService>();
```

### Reusable Paged Response Model

```csharp
public class PagedResponse<T>
{
    public List<T> Data            { get; set; }
    public int     Page            { get; set; }
    public int     PageSize        { get; set; }
    public int     TotalCount      { get; set; }
    public int     TotalPages      => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public bool    HasNextPage     => Page < TotalPages;
    public bool    HasPreviousPage => Page > 1;

    public PagedResponse(List<T> data, int page, int pageSize, int totalCount)
    {
        Data = data; Page = page; PageSize = pageSize; TotalCount = totalCount;
    }
}
```

---

## 6. ASP.NET Core Middleware

### What Is Middleware?

**Middleware** is software that's assembled into an application pipeline to handle requests and responses. Each piece of middleware can:
1. Run code **before** the next middleware
2. Pass the request to the next middleware (call `next()`)
3. Run code **after** the next middleware returns

### Real-World Analogy 🏭

Think of middleware as an **assembly line**. Each station (middleware) handles the item passing through, does its job, and passes it to the next station. At the end, the response travels back through the same stations in reverse order.

```
REQUEST  →  [Logging] → [HTTPS Redirect] → [Auth] → [Authorization] → [Controller]
RESPONSE ←  [Logging] ← [HTTPS Redirect] ← [Auth] ← [Authorization] ← [Controller]
```

### Built-in Middleware — Order Matters!

```csharp
// Program.cs — middleware ORDER is critical!
var app = builder.Build();

// 1. Exception handling — FIRST so it catches exceptions from ALL other middleware
app.UseExceptionHandler("/error");

// 2. HTTPS redirection — early in the pipeline
app.UseHttpsRedirection();

// 3. Static files — serve wwwroot files without hitting controllers
app.UseStaticFiles();

// 4. Routing — must come before auth
app.UseRouting();

// 5. CORS — must come after routing, before auth
app.UseCors("AllowFrontend");

// 6. Authentication — who are you?
app.UseAuthentication();

// 7. Authorization — what can you do?
app.UseAuthorization();

// 8. Controllers — actual API handlers (last in the pipeline)
app.MapControllers();
```

### Writing a Custom Middleware — Request Logging

```csharp
// Middleware/RequestLoggingMiddleware.cs
public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;  // the next middleware in the pipeline
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next   = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // ── Code BEFORE the next middleware (incoming request) ────────
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        _logger.LogInformation(
            "HTTP {Method} {Path} started",
            context.Request.Method,
            context.Request.Path);

        // ── Pass to next middleware ───────────────────────────────────
        await _next(context);

        // ── Code AFTER the next middleware (outgoing response) ────────
        stopwatch.Stop();

        _logger.LogInformation(
            "HTTP {Method} {Path} responded {StatusCode} in {ElapsedMs}ms",
            context.Request.Method,
            context.Request.Path,
            context.Response.StatusCode,
            stopwatch.ElapsedMilliseconds);
    }
}

// Extension method for clean registration in Program.cs
public static class RequestLoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder app)
        => app.UseMiddleware<RequestLoggingMiddleware>();
}
```

```csharp
// Register in Program.cs
app.UseRequestLogging();   // clean and readable thanks to the extension method
```

### Writing a Custom Middleware — API Key Validation

```csharp
// Middleware/ApiKeyMiddleware.cs
public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private const string ApiKeyHeaderName = "X-API-Key";

    public ApiKeyMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context, IConfiguration config)
    {
        // Allow Swagger UI to work without an API key in development
        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            await _next(context);
            return;
        }

        if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var providedKey))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(new { message = "API key missing" });
            return;
        }

        string? validKey = config["ApiKey"];
        if (!string.Equals(providedKey, validKey, StringComparison.OrdinalIgnoreCase))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(new { message = "Invalid API key" });
            return;
        }

        await _next(context);
    }
}
```

### Middleware vs Filter vs Action — When to Use What

```
MIDDLEWARE:
  Runs for EVERY request, even those that don't hit a controller.
  Best for: global logging, HTTPS redirection, CORS, authentication,
            rate limiting, request/response compression.

FILTER (Action/Result/Exception/Resource):
  Runs only for requests that match a controller action.
  Can be applied globally, per-controller, or per-action.
  Best for: validation, model transformation, response caching,
            action-specific logging, exception handling per controller.

ACTION METHOD CODE:
  Runs only for that specific action.
  Best for: business logic specific to that endpoint.
```

---

## 7. Implementing JWT and OAuth2 Authentication

### What Is JWT?

**JWT (JSON Web Token)** is a compact, self-contained way to securely transmit information as a JSON object. In Web APIs, a JWT token is issued after login and the client sends it with every subsequent request to prove its identity.

### Real-World Analogy 🎫

Think of JWT like a **cinema ticket**. When you buy a ticket (log in), you receive a ticket (JWT token) that:
- Contains your seat number, movie, time (claims — who you are, what you can do)
- Has the cinema's stamp (signature — proves it's genuine, not forged)
- Has an expiry time (you can't use yesterday's ticket today)

At the door (every API request), the usher (middleware) checks your ticket — if it's valid and not expired, you're let in. The usher doesn't need to call the box office (database) to verify you — the ticket itself proves your identity.

### JWT Structure

```
A JWT has three parts separated by dots:

eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9   ← HEADER  (algorithm + token type)
.
eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkFsaWNlIiwicm9sZSI6IkFkbWluIiwiaWF0IjoxNTE2MjM5MDIyfQ
                                          ← PAYLOAD (claims: userId, name, role, expiry)
.
SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c
                                          ← SIGNATURE (server-generated, prevents tampering)

DECODED PAYLOAD:
{
  "sub":   "42",            // subject (user id)
  "name":  "Alice Johnson", // display name
  "email": "alice@shop.com",
  "role":  "Admin",         // role for authorization
  "iat":   1516239022,      // issued at
  "exp":   1516242622       // expires at (1 hour later)
}
```

### Setting Up JWT Authentication

```bash
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
```

```json
// appsettings.json
{
  "Jwt": {
    "SecretKey": "your-secret-key-at-least-32-characters-long!",
    "Issuer":    "ShopApi",
    "Audience":  "ShopApiClients",
    "ExpiryHours": 1
  }
}
```

```csharp
// Program.cs — configure JWT authentication
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer           = true,
            ValidateAudience         = true,
            ValidateLifetime         = true,   // reject expired tokens
            ValidateIssuerSigningKey = true,

            ValidIssuer      = builder.Configuration["Jwt:Issuer"],
            ValidAudience    = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]!)),

            ClockSkew = TimeSpan.Zero  // no tolerance for expiry (default is 5 minutes!)
        };

        // Return 401 as JSON, not HTML
        options.Events = new JwtBearerEvents
        {
            OnChallenge = context =>
            {
                context.HandleResponse();
                context.Response.StatusCode  = 401;
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsJsonAsync(new
                    { message = "Authentication required. Please provide a valid Bearer token." });
            },
            OnForbidden = context =>
            {
                context.Response.StatusCode  = 403;
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsJsonAsync(new
                    { message = "You do not have permission to perform this action." });
            }
        };
    });

builder.Services.AddAuthorization();
```

### Token Service — Generating JWT Tokens

```csharp
// Services/TokenService.cs
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

public interface ITokenService
{
    string GenerateToken(User user);
}

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    public TokenService(IConfiguration config) => _config = config;

    public string GenerateToken(User user)
    {
        // Claims — facts about the user embedded in the token
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub,   user.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Name,  user.FullName),
            new Claim(JwtRegisteredClaimNames.Jti,   Guid.NewGuid().ToString()),  // unique token ID
            new Claim(ClaimTypes.Role, user.Role)                                  // role
        };

        var key   = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer:             _config["Jwt:Issuer"],
            audience:           _config["Jwt:Audience"],
            claims:             claims,
            expires:            DateTime.UtcNow.AddHours(double.Parse(_config["Jwt:ExpiryHours"]!)),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
```

### Auth Controller — Login and Register

```csharp
// DTOs/Auth
public class RegisterDto
{
    [Required, MaxLength(50)]  public string FirstName { get; set; } = "";
    [Required, MaxLength(50)]  public string LastName  { get; set; } = "";
    [Required, EmailAddress]   public string Email     { get; set; } = "";
    [Required, MinLength(8)]   public string Password  { get; set; } = "";
}

public class LoginDto
{
    [Required, EmailAddress]  public string Email    { get; set; } = "";
    [Required]                public string Password { get; set; } = "";
}

public class AuthResponseDto
{
    public string Token     { get; set; } = "";
    public string FullName  { get; set; } = "";
    public string Email     { get; set; } = "";
    public string Role      { get; set; } = "";
    public DateTime ExpiresAt { get; set; }
}
```

```csharp
// Controllers/AuthController.cs
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly ShopDbContext  _db;
    private readonly ITokenService  _tokenService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(ShopDbContext db, ITokenService tokenService,
        ILogger<AuthController> logger)
    {
        _db           = db;
        _tokenService = tokenService;
        _logger       = logger;
    }

    // POST api/auth/register
    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDto>> Register([FromBody] RegisterDto dto)
    {
        // Check email is not already used
        if (await _db.Users.AnyAsync(u => u.Email == dto.Email))
            return Conflict(new { message = "An account with this email already exists" });

        // Hash the password — NEVER store plain text!
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var user = new User
        {
            FirstName    = dto.FirstName,
            LastName     = dto.LastName,
            Email        = dto.Email,
            PasswordHash = passwordHash,
            Role         = "Customer",
            CreatedAt    = DateTime.UtcNow
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        _logger.LogInformation("New user registered: {Email}", dto.Email);

        var token = _tokenService.GenerateToken(user);
        return Ok(new AuthResponseDto
        {
            Token     = token,
            FullName  = user.FullName,
            Email     = user.Email,
            Role      = user.Role,
            ExpiresAt = DateTime.UtcNow.AddHours(1)
        });
    }

    // POST api/auth/login
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginDto dto)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
        {
            // Generic message — don't reveal whether email or password was wrong!
            _logger.LogWarning("Failed login attempt for {Email}", dto.Email);
            return Unauthorized(new { message = "Invalid email or password" });
        }

        var token = _tokenService.GenerateToken(user);
        _logger.LogInformation("User logged in: {Email}", dto.Email);

        return Ok(new AuthResponseDto
        {
            Token     = token,
            FullName  = user.FullName,
            Email     = user.Email,
            Role      = user.Role,
            ExpiresAt = DateTime.UtcNow.AddHours(1)
        });
    }
}
```

### Protecting Endpoints with [Authorize]

```csharp
// Protect all actions in a controller
[ApiController]
[Route("api/products")]
[Authorize]                              // ALL actions require authentication
public class ProductsController : ControllerBase
{
    [HttpGet]                            // requires authentication (from controller)
    public IActionResult GetAll() => Ok();

    [AllowAnonymous]                     // override — this one is public
    [HttpGet("featured")]
    public IActionResult GetFeatured() => Ok();

    [Authorize(Roles = "Admin")]         // requires "Admin" role
    [HttpPost]
    public IActionResult Create() => Ok();

    [Authorize(Roles = "Admin,Manager")] // Admin OR Manager
    [HttpDelete("{id}")]
    public IActionResult Delete(int id) => Ok();
}

// Reading the current user's identity inside an action
[HttpGet("me")]
[Authorize]
public IActionResult GetCurrentUser()
{
    // ClaimsPrincipal — the current authenticated user
    string? userId   = User.FindFirstValue(ClaimTypes.NameIdentifier); // "sub" claim
    string? email    = User.FindFirstValue(ClaimTypes.Email);
    string? role     = User.FindFirstValue(ClaimTypes.Role);
    bool isAdmin     = User.IsInRole("Admin");

    return Ok(new { userId, email, role, isAdmin });
}
```

### Policy-Based Authorization

```csharp
// Program.cs — define custom policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly",     policy => policy.RequireRole("Admin"));
    options.AddPolicy("StaffOrAbove",  policy => policy.RequireRole("Admin", "Manager", "Staff"));
    options.AddPolicy("MinAge18",      policy => policy.RequireClaim("age", "18", "19", "20", "21"));

    // Custom requirement-based policy
    options.AddPolicy("CanManageProducts", policy =>
        policy.RequireAssertion(ctx =>
            ctx.User.IsInRole("Admin") ||
            ctx.User.HasClaim("permission", "manage-products")));
});

// Usage on actions
[Authorize(Policy = "AdminOnly")]
[HttpDelete("{id}")]
public IActionResult Delete(int id) => Ok();

[Authorize(Policy = "CanManageProducts")]
[HttpPost]
public IActionResult Create() => Ok();
```

---

## 8. Setting Up Swagger for API Documentation

### What Is Swagger?

**Swagger (OpenAPI)** automatically generates interactive API documentation from your code. It produces a web page where developers can browse all endpoints, see request/response schemas, and even test the API directly from the browser — without writing any documentation manually.

### Basic Swagger Setup

```bash
dotnet add package Swashbuckle.AspNetCore
```

```csharp
// Program.cs
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title       = "Shop API",
        Version     = "v1",
        Description = "A RESTful API for managing products, orders, and customers",
        Contact     = new OpenApiContact
        {
            Name  = "API Support",
            Email = "api@myshop.com"
        }
    });

    // Include XML comments from code (requires EnableGenerateDocumentationFile in .csproj)
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
        options.IncludeXmlComments(xmlPath);
});

// In the pipeline:
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop API v1");
        options.RoutePrefix = string.Empty;  // serve Swagger at the root URL "/"
    });
}
```

```xml
<!-- .csproj — generate XML documentation file for Swagger comments -->
<PropertyGroup>
  <GenerateDocumentationFile>true</GenerateDocumentationFile>
  <NoWarn>$(NoWarn);1591</NoWarn>  <!-- suppress missing XML comment warnings -->
</PropertyGroup>
```

### Adding JWT Support to Swagger UI

```csharp
// Program.cs — allow Swagger UI to send JWT tokens in requests
builder.Services.AddSwaggerGen(options =>
{
    // ... existing options ...

    // Define the JWT security scheme
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name         = "Authorization",
        Type         = SecuritySchemeType.Http,
        Scheme       = "Bearer",
        BearerFormat = "JWT",
        In           = ParameterLocation.Header,
        Description  = "Enter your JWT token. Example: Bearer eyJhbGci..."
    });

    // Require the JWT scheme globally (Swagger UI shows the Authorize button)
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                    { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});
```

### Documenting Endpoints with XML Comments

```csharp
/// <summary>
/// Retrieves a paged list of products with optional filtering.
/// </summary>
/// <param name="category">Filter by category name (optional)</param>
/// <param name="minPrice">Minimum price filter (optional)</param>
/// <param name="maxPrice">Maximum price filter (optional)</param>
/// <param name="page">Page number (default: 1)</param>
/// <param name="pageSize">Items per page (default: 20, max: 100)</param>
/// <returns>A paged list of products</returns>
/// <response code="200">Returns the paged product list</response>
/// <response code="400">Invalid filter parameters</response>
[HttpGet]
[ProducesResponseType(typeof(PagedResponse<ProductResponseDto>), StatusCodes.Status200OK)]
[ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
public async Task<ActionResult<PagedResponse<ProductResponseDto>>> GetAll(
    [FromQuery] string?  category = null,
    [FromQuery] decimal? minPrice = null,
    [FromQuery] decimal? maxPrice = null,
    [FromQuery] int      page     = 1,
    [FromQuery][Range(1, 100)] int pageSize = 20)
{
    // ...
}

/// <summary>
/// Creates a new product (Admin only).
/// </summary>
/// <param name="dto">The product details</param>
/// <returns>The newly created product</returns>
/// <response code="201">Product created successfully</response>
/// <response code="400">Validation failed</response>
/// <response code="401">Not authenticated</response>
/// <response code="403">Not authorized (requires Admin role)</response>
[HttpPost]
[Authorize(Roles = "Admin")]
[ProducesResponseType(typeof(ProductResponseDto), StatusCodes.Status201Created)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public async Task<ActionResult<ProductResponseDto>> Create([FromBody] CreateProductDto dto)
{
    // ...
}
```

---

## 9. Global Error Handling and Logging

### Why Global Error Handling?

Without it, unhandled exceptions expose raw stack traces to clients (security risk) and return HTML error pages instead of JSON (breaks API clients). A global handler catches ALL exceptions in one place, logs them, and returns a consistent JSON error response.

### Option 1 — Custom Exception Middleware (Full Control)

```csharp
// Middleware/ExceptionHandlingMiddleware.cs
using System.Net;
using System.Text.Json;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next   = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Choose status code and message based on exception type
        (int statusCode, string title, string detail) = exception switch
        {
            NotFoundException e      => (404, "Not Found",              e.Message),
            ValidationException e    => (400, "Validation Failed",      e.Message),
            UnauthorizedException e  => (401, "Unauthorized",           e.Message),
            ForbiddenException e     => (403, "Forbidden",              e.Message),
            ConflictException e      => (409, "Conflict",               e.Message),
            _                        => (500, "Internal Server Error",
                                         "An unexpected error occurred. Please try again later.")
        };

        // Log unexpected errors with full details (never log 4xx as errors)
        if (statusCode >= 500)
            _logger.LogError(exception, "Unhandled exception: {Message}", exception.Message);
        else
            _logger.LogWarning("Handled exception ({Status}): {Message}", statusCode, exception.Message);

        // Return RFC 7807 ProblemDetails format — standard for HTTP API errors
        var problemDetails = new
        {
            status  = statusCode,
            title   = title,
            detail  = detail,
            traceId = context.TraceIdentifier  // helps correlate with server logs
        };

        context.Response.StatusCode  = statusCode;
        context.Response.ContentType = "application/problem+json";
        await context.Response.WriteAsJsonAsync(problemDetails);
    }
}
```

```csharp
// Custom exception classes
public class NotFoundException      : Exception { public NotFoundException(string msg) : base(msg) {} }
public class ValidationException    : Exception { public ValidationException(string msg) : base(msg) {} }
public class UnauthorizedException  : Exception { public UnauthorizedException(string msg) : base(msg) {} }
public class ForbiddenException     : Exception { public ForbiddenException(string msg) : base(msg) {} }
public class ConflictException      : Exception { public ConflictException(string msg) : base(msg) {} }
```

```csharp
// Register in Program.cs — MUST be first in the pipeline!
app.UseMiddleware<ExceptionHandlingMiddleware>();
```

### Using Custom Exceptions in Services

```csharp
// ProductService.cs — throw domain exceptions; middleware handles the response
public async Task<ProductResponseDto> GetByIdAsync(int id)
{
    var product = await _db.Products.FindAsync(id);
    if (product == null)
        throw new NotFoundException($"Product with id {id} was not found");  // middleware → 404

    return MapToDto(product);
}

public async Task<ProductResponseDto> CreateAsync(CreateProductDto dto)
{
    bool nameExists = await _db.Products.AnyAsync(p => p.Name == dto.Name);
    if (nameExists)
        throw new ConflictException($"A product named '{dto.Name}' already exists");  // → 409

    // ...
}
```

### Option 2 — UseExceptionHandler (Built-in, Simpler)

```csharp
// Program.cs — simpler built-in approach
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exception = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>()?.Error;

        context.Response.StatusCode  = 500;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new
        {
            status  = 500,
            title   = "Internal Server Error",
            detail  = "An unexpected error occurred.",
            traceId = context.TraceIdentifier
        });
    });
});
```

### Structured Logging with Serilog

```bash
dotnet add package Serilog.AspNetCore
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.File
dotnet add package Serilog.Sinks.Seq           # optional: structured log viewer
```

```csharp
// Program.cs — configure Serilog
using Serilog;

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)  // reads from appsettings.json
    .Enrich.FromLogContext()                          // adds context like TraceId
    .Enrich.WithMachineName()
    .WriteTo.Console(outputTemplate:
        "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties}{NewLine}{Exception}")
    .WriteTo.File(
        path:             "logs/shopapi-.txt",
        rollingInterval:  RollingInterval.Day,        // new file each day
        retainedFileCountLimit: 30,                   // keep 30 days of logs
        outputTemplate:
            "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj} {Properties}{NewLine}{Exception}")
    .CreateLogger();

builder.Host.UseSerilog();  // replace default logger with Serilog
```

```json
// appsettings.json — control log levels per namespace
{
  "Serilog": {
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft":                 "Warning",
        "Microsoft.EntityFrameworkCore": "Information",
        "System":                    "Warning"
      }
    }
  }
}
```

### Using ILogger in Controllers and Services

```csharp
// Structured logging — use message templates, not string interpolation!

// ❌ BAD — string interpolation loses structured data
_logger.LogInformation($"Order {orderId} placed by user {userId}");

// ✅ GOOD — message template: orderId and userId are searchable properties
_logger.LogInformation("Order {OrderId} placed by user {UserId}", orderId, userId);

// Log levels — use the right one!
_logger.LogTrace("Entering GetProductById with id={Id}", id);       // very detailed
_logger.LogDebug("Cache miss for product {Id}", id);                 // debug info
_logger.LogInformation("Product {Id} retrieved successfully", id);  // normal operations
_logger.LogWarning("Product {Id} has low stock: {Stock}", id, stock); // something to watch
_logger.LogError(ex, "Failed to process order {OrderId}", orderId);  // error with exception
_logger.LogCritical(ex, "Database connection lost");                  // system is failing

// Logging with scope — adds context to all logs within the scope
using (_logger.BeginScope("OrderProcessing {OrderId}", orderId))
{
    _logger.LogInformation("Starting order validation");
    // ...
    _logger.LogInformation("Order validated, processing payment");
    // All logs in this using block have OrderId attached automatically
}
```

### Complete Request-Response Log Output

```
[14:23:01 INF] HTTP GET /api/products started
[14:23:01 INF] Executing DbCommand [Parameters=[@__category_0='Electronics'], CommandText='SELECT...']
[14:23:01 INF] HTTP GET /api/products responded 200 in 45ms

[14:23:15 WRN] Handled exception (404): Product with id 999 was not found
[14:23:15 INF] HTTP GET /api/products/999 responded 404 in 12ms

[14:24:01 ERR] Unhandled exception: Connection refused
System.Data.SqlClient.SqlException: A network-related or instance-specific error...
   at Microsoft.EntityFrameworkCore...
[14:24:01 INF] HTTP POST /api/orders responded 500 in 5001ms
```

---

## 10. Summary Cheat Sheet

### REST Quick Reference

```
GET    /resources          → list all
GET    /resources/{id}     → get one
POST   /resources          → create (body: full data, returns 201 + Location)
PUT    /resources/{id}     → full replace (body: full data, returns 204)
PATCH  /resources/{id}     → partial update (body: changed fields, returns 204)
DELETE /resources/{id}     → delete (returns 204)

200 OK              → success with body
201 Created         → resource created (POST)
204 No Content      → success no body (PUT, PATCH, DELETE)
400 Bad Request     → validation error or bad input
401 Unauthorized    → not logged in
403 Forbidden       → logged in but no permission
404 Not Found       → resource doesn't exist
409 Conflict        → duplicate / state conflict
500 Server Error    → something broke on the server
```

### The Request Pipeline

```
Request → ExceptionHandler → HTTPS → StaticFiles → Routing → CORS
        → Authentication → Authorization → Controllers → Response
```

### JWT Flow

```
1. POST /api/auth/login  { email, password }
2. Server verifies password → issues JWT token
3. Client stores token (localStorage, httpOnly cookie)
4. Every subsequent request: Authorization: Bearer <token>
5. Middleware validates token → extracts claims → populates User principal
6. [Authorize] checks User.Identity.IsAuthenticated
7. [Authorize(Roles="Admin")] checks User.IsInRole("Admin")
```

### Program.cs Service Registration Checklist

```csharp
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ShopDbContext>(...);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(...);
builder.Services.AddAuthorization();
builder.Services.AddCors(...);
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ITokenService, TokenService>();
```

### Middleware Pipeline Checklist

```csharp
app.UseMiddleware<ExceptionHandlingMiddleware>();   // 1st — catches everything
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("PolicyName");
app.UseAuthentication();     // before Authorization!
app.UseAuthorization();
app.MapControllers();
```

### 💼 Interview Quick-Fire

> **Q: "What is the difference between 401 and 403?"**
>
> A: 401 Unauthorized means the request has no valid authentication — the client hasn't logged in or the token is missing/expired. 403 Forbidden means the client IS authenticated (we know who they are) but they don't have permission to perform that specific action — for example, a logged-in customer trying to access an Admin-only endpoint.

> **Q: "Why is middleware order important in ASP.NET Core?"**
>
> A: Each middleware wraps the next one — they form a pipeline where the first middleware added is the first to process requests and the last to process responses. If you put `UseAuthorization` before `UseAuthentication`, the user's identity won't be established yet when authorization runs, so all protected endpoints would fail. Exception handling must be first so it can catch exceptions from all subsequent middleware.

> **Q: "What is the difference between authentication and authorization?"**
>
> A: Authentication answers "who are you?" — verifying identity via a JWT token, API key, or cookie. Authorization answers "what are you allowed to do?" — checking whether the authenticated identity has the required role or permission to perform the requested action. In ASP.NET Core, `UseAuthentication` populates the `User` principal from the token, and `UseAuthorization` checks `[Authorize]` attributes against that principal.

> **Q: "Why use DTOs instead of returning entity classes directly from the API?"**
>
> A: Several reasons. First, entities often contain sensitive fields (PasswordHash, InternalNotes) that should never leave the server. Second, the API contract (what fields you expose) should be stable and intentional — if you add a column to a database table, you don't necessarily want it auto-exposed in every API response. Third, DTOs let you shape the response optimally for the client — combining fields from multiple entities, computing display values, and controlling serialization — independently of how data is stored in the database.

---

## Reference Links

- [ASP.NET Core Web API — Microsoft Docs](https://learn.microsoft.com/en-us/aspnet/core/web-api/)
- [Routing in ASP.NET Core — Microsoft Docs](https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/routing)
- [ASP.NET Core Middleware — Microsoft Docs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/)
- [Authentication and Authorization — Microsoft Docs](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/)
- [JWT Bearer Authentication — Microsoft Docs](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/jwt-authn)
- [Swagger / OpenAPI with ASP.NET Core — Microsoft Docs](https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger)
- [Logging in ASP.NET Core — Microsoft Docs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/)
- [Serilog for ASP.NET Core](https://github.com/serilog/serilog-aspnetcore)
- [Entity Framework Core — Microsoft Docs](https://learn.microsoft.com/en-us/ef/core/)
- [REST API Design Guidelines — Microsoft](https://learn.microsoft.com/en-us/azure/architecture/best-practices/api-design)
- [RFC 7807 — Problem Details for HTTP APIs](https://datatracker.ietf.org/doc/html/rfc7807)
- [OWASP API Security Top 10](https://owasp.org/www-project-api-security/)
