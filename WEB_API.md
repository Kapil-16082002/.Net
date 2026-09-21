
<a href="https://youtu.be/0pcM6teVdKk?si=HWS6EyqUFF8hw7fS"> Playlist for Web API </a>

**ASP.NET Core Web API** is a framework from **Microsoft** used to build **RESTful APIs**. These APIs allow different applications (such as web apps, mobile apps, desktop apps, and other services) to communicate over HTTP.

### What is a Web API?

A Web API is like a **waiter in a restaurant**:

* **Client** (browser/mobile app) → Places an order (HTTP request)
* **Web API** → Receives the request, processes it, and interacts with the database if needed
* **Database** → Stores or retrieves data
* **Web API** → Returns the result (HTTP response) to the client

Example:

```
Mobile App
     |
     | HTTP Request
     v
ASP.NET Core Web API
     |
     | Reads/Writes
     v
Database
     |
     v
HTTP Response (JSON)
```

### Features of ASP.NET Core Web API

* Cross-platform (Windows, Linux, macOS)
* High performance
* Supports REST architecture
* Returns data in JSON (default) or XML
* Built-in dependency injection
* Authentication and authorization support
* Easy integration with databases using Entity Framework Core

### Example API

Suppose you have a Student API.

**GET** - Retrieve all students

```
GET /api/students
```

Response:

```json
[
  {
    "id": 1,
    "name": "John",
    "course": "Computer Science"
  },
  {
    "id": 2,
    "name": "Sarah",
    "course": "Mathematics"
  }
]
```

**POST** - Add a new student

```
POST /api/students
```

Request Body:

```json
{
  "name": "Alice",
  "course": "Physics"
}
```

### Sample Controller

```csharp
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetStudents()
    {
        return Ok(new[]
        {
            new { Id = 1, Name = "John" },
            new { Id = 2, Name = "Sarah" }
        });
    }
}
```

When you run the application and navigate to:

```
https://localhost:5001/api/students
```

you'll receive a JSON response.

### HTTP Methods Used

| Method | Purpose                 |
| ------ | ----------------------- |
| GET    | Retrieve data           |
| POST   | Create new data         |
| PUT    | Update all data         |
| PATCH  | Update part of the data |
| DELETE | Remove data             |

### Where ASP.NET Core Web API is used

* Mobile application backends
* E-commerce websites
* Banking systems
* Inventory and ERP systems
* Social media applications
* Microservices
* Cloud applications

### Example Architecture

```
React / Angular / Mobile App
            |
            | HTTP (GET, POST, PUT, DELETE)
            |
ASP.NET Core Web API
            |
Business Logic
            |
Entity Framework Core
            |
SQL Server / MySQL / PostgreSQL
```

In short, **ASP.NET Core Web API** is a framework for building HTTP-based services that expose data and functionality to client applications. It is one of the most common technologies for creating backend services in the .NET ecosystem.

If you're new to it, I can also show you how to build a **complete CRUD (Create, Read, Update, Delete) Web API** step by step in ASP.NET Core.

Since you're learning **ASP.NET Core Web API**, understanding **RESTful services** is essential because **ASP.NET Core Web API is commonly used to build RESTful services**.

# What is a RESTful Service?

A **RESTful service** is a **Web API that follows the REST (Representational State Transfer) architectural principles** to allow different applications to communicate over HTTP.

In simple terms:

> A RESTful service is a web service that lets clients (browser, mobile app, desktop app, etc.) **Create, Read, Update, and Delete (CRUD)** data using standard HTTP methods.

---

# Real-Life Example

Imagine an online shopping application.

There are three components:

```
Customer (Mobile App)
        |
        | HTTP Request
        v
RESTful Web API
        |
        | Read/Write Data
        v
SQL Server Database
```

When the customer wants to view products:

```
GET /api/products
```

The RESTful service retrieves the data from the database and returns it as JSON.

---

# What does REST mean?

REST stands for:

**R**epresentational
**S**tate
**T**ransfer

Let's understand each word.

### Representational

The server doesn't send the actual database—it sends a **representation** of the resource.

Example database record:

| Id | Name   | Price |
| -- | ------ | ----- |
| 1  | Laptop | 60000 |

The API returns it as JSON:

```json
{
    "id":1,
    "name":"Laptop",
    "price":60000
}
```

This JSON is the **representation**.

---

### State

State means the current condition of a resource.

Example:

```
Product
```

Current state:

```
Id = 1
Name = Laptop
Price = 60000
```

After an update:

```
Id = 1
Name = Laptop
Price = 55000
```

The resource's **state** has changed.

---

### Transfer

Transfer means sending that representation over HTTP.

Client

↓

HTTP Request

↓

Server

↓

JSON Response

---

# REST Architecture

```
Client
   |
HTTP Request
   |
REST API
   |
Business Logic
   |
Database
```

---

# Resource

Everything in REST is treated as a **resource**.

Examples:

```
Student

Employee

Product

Order

Customer

Book
```

Each resource has its own URL.

Example:

```
/api/students

/api/products

/api/orders
```

---

# HTTP Methods

REST uses standard HTTP methods.

| HTTP Method | Operation               | SQL Equivalent |
| ----------- | ----------------------- | -------------- |
| GET         | Read data               | SELECT         |
| POST        | Create new data         | INSERT         |
| PUT         | Update entire resource  | UPDATE         |
| PATCH       | Update part of resource | UPDATE         |
| DELETE      | Delete data             | DELETE         |

Example:

Get all students

```
GET /api/students
```

Get one student

```
GET /api/students/5
```

Create student

```
POST /api/students
```

Update student

```
PUT /api/students/5
```

Delete student

```
DELETE /api/students/5
```

---

# CRUD Mapping

```
Create  -> POST

Read    -> GET

Update  -> PUT/PATCH

Delete  -> DELETE
```

---

# Why REST is Popular

* Simple and easy to understand
* Uses standard HTTP methods
* Platform-independent (clients can be written in any language)
* Stateless, making it easier to scale
* Lightweight, especially when using JSON

---

# JSON Response Example

Request:

```
GET /api/students
```

Response:

```json
[
    {
        "id":1,
        "name":"John"
    },
    {
        "id":2,
        "name":"Alice"
    }
]
```

---

# RESTful Service in ASP.NET Core

Example controller:

```csharp
[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetStudents()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetStudent(int id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult CreateStudent(Student student)
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStudent(int id, Student student)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        return Ok();
    }
}
```

Each action corresponds to one HTTP method.

---

# Characteristics of a RESTful Service

A service is considered RESTful if it follows these principles:

1. **Client-Server Architecture**: The client and server have separate responsibilities.
2. **Stateless**: Each request contains all the information needed to process it. The server does not remember previous requests.
3. **Resource-Based URLs**: Resources are identified by nouns such as `/api/students` instead of verbs like `/getStudents`.
4. **Standard HTTP Methods**: Use `GET`, `POST`, `PUT`, `PATCH`, and `DELETE` appropriately.
5. **Uniform Interface**: Resources are accessed consistently through URIs, HTTP methods, headers, and status codes.
6. **Representations**: Resources are exchanged in formats such as JSON or XML (JSON is most common).
7. **Cacheable**: Responses can indicate whether they may be cached to improve performance.
8. **Layered System**: Clients do not need to know whether they are communicating directly with the server or through intermediaries like gateways or load balancers.

---

# REST vs RESTful

| REST                   | RESTful                                       |
| ---------------------- | --------------------------------------------- |
| An architectural style | A service or API that follows REST principles |
| Defines the rules      | Implements those rules                        |
| Concept                | Implementation                                |

**Example:**

* **REST** is the set of architectural guidelines.
* An **ASP.NET Core Web API** that follows those guidelines is a **RESTful service**.

### Interview Definition (Easy to Remember)

> **A RESTful service is a web service that follows REST architectural principles. It exposes resources through URLs, uses standard HTTP methods (GET, POST, PUT, PATCH, DELETE), is stateless, and typically exchanges data in JSON format.**

This is the definition interviewers commonly expect from beginners and intermediate .NET developers.

You likely mean **HATEOAS**, or **HATEOS**.

**HATEOAS** stands for:

> **H**ypermedia **A**s **T**he **E**ngine **O**f **A**pplication **S**tate

It is **one of the principles of the REST Uniform Interface constraint**.

---

# What is HATEOAS?

HATEOAS means that **the server provides links in its responses that tell the client what actions are available next**.

Instead of the client hardcoding all API URLs, it **discovers** them from the API response.

Think of it like a website:

* You open a page.
* The page contains links ("Home", "Profile", "Logout").
* You click the links to navigate.

HATEOAS applies the same idea to APIs.

---

# Without HATEOAS

Suppose you request a student:

```http
GET /api/students/1
```

Response:

```json
{
    "id": 1,
    "name": "John",
    "course": "C#"
}
```

The client now has to **guess or already know** how to:

* Update the student
* Delete the student
* View all students

Those URLs are not included in the response.

---

# With HATEOAS

The server returns both the data **and** the available actions.

```http
GET /api/students/1
```

Response:

```json
{
    "id": 1,
    "name": "John",
    "course": "C#",
    "links": [
        {
            "rel": "self",
            "href": "/api/students/1",
            "method": "GET"
        },
        {
            "rel": "update",
            "href": "/api/students/1",
            "method": "PUT"
        },
        {
            "rel": "delete",
            "href": "/api/students/1",
            "method": "DELETE"
        },
        {
            "rel": "allStudents",
            "href": "/api/students",
            "method": "GET"
        }
    ]
}
```

The client doesn't need prior knowledge of these URLs—it follows the links returned by the server.

---

# Understanding the Links

| Field    | Meaning                                             |
| -------- | --------------------------------------------------- |
| `rel`    | Relationship or action (e.g., self, update, delete) |
| `href`   | The URL to use                                      |
| `method` | The HTTP method to call                             |

Example:

```json
{
    "rel": "delete",
    "href": "/api/students/1",
    "method": "DELETE"
}
```

This tells the client:

> "If you want to delete this student, send a `DELETE` request to `/api/students/1`."

---

# Real-Life Analogy

Imagine you're using an ATM.

After withdrawing cash, the ATM screen shows:

```text
1. Withdraw Again
2. Check Balance
3. Deposit Money
4. Exit
```

The ATM is guiding you on what you can do next.

HATEOAS works the same way: the API response tells the client what actions are available next.

---

# Why Use HATEOAS?

### 1. Self-Discoverable APIs

Clients don't need to hardcode every endpoint.

### 2. Easier API Evolution

If an endpoint changes, the server can return the new link without requiring client changes.

### 3. Loose Coupling

Clients depend less on fixed URL structures.

### 4. Better API Documentation

Responses themselves help clients understand available actions.

---

# HATEOAS Flow

```text
Client
   |
GET /api/students/1
   |
   v
Server
   |
Returns Student + Links
   |
   v
Client follows one of the links
```

---

# HATEOAS in ASP.NET Core

ASP.NET Core Web API **does not enable HATEOAS automatically**.

You typically build it by adding link objects to your response models.

Example:

```csharp
public class Link
{
    public string Rel { get; set; }
    public string Href { get; set; }
    public string Method { get; set; }
}
```

Then return:

```csharp
return Ok(new
{
    Id = 1,
    Name = "John",
    Links = new[]
    {
        new Link
        {
            Rel = "self",
            Href = "/api/students/1",
            Method = "GET"
        }
    }
});
```

---

# Does Every REST API Use HATEOAS?

**No.**

Many production REST APIs (including many built with ASP.NET Core Web API) do **not** implement HATEOAS because it adds complexity and many clients already know the API endpoints from documentation (such as OpenAPI/Swagger).

However, according to Roy Fielding's original REST architecture, HATEOAS is an important aspect of the **Uniform Interface** constraint.

---

# Interview Answer (1 Minute)

> **HATEOAS (Hypermedia As The Engine Of Application State)** is a REST principle where the server includes hyperlinks in API responses that tell the client what actions can be performed next. Instead of hardcoding API URLs, the client discovers available operations by following the links returned in the response. This makes APIs more self-descriptive, loosely coupled, and easier to evolve. Although HATEOAS is part of the original REST architecture, many modern REST APIs do not implement it in practice.

---

In **.NET**, **configuration** is the process of storing and reading application settings **without hardcoding them into your source code**.

Instead of writing values like database connection strings, API keys, or logging settings directly in your code, you place them in configuration files or other configuration sources.

---

# Why do we need configuration?

### ❌ Hardcoded values (Not Recommended)

```csharp
string connectionString =
    "Server=.;Database=ShopDB;User Id=sa;Password=12345;";
```

Problems:

* Difficult to change
* Security risk
* Requires recompiling the application
* Different environments (Development, Testing, Production) need different values

---

### ✅ Using Configuration (Recommended)

**appsettings.json**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=ShopDB;Trusted_Connection=True;"
  }
}
```

Read it in code:

```csharp
string connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");
```

Now if the connection string changes, you only update **appsettings.json**, not your code.

---

# What can we configure?

Common settings include:

* Database connection strings
* API keys
* Email settings
* Logging levels
* JWT settings
* Application URLs
* Feature flags
* Third-party service credentials

Example:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  },
  "Jwt": {
    "Key": "MySecretKey",
    "Issuer": "MyApi"
  }
}
```

---

# Where does .NET read configuration from?

ASP.NET Core supports multiple configuration providers.

```text
Configuration
       |
-----------------------------------------
|         |        |         |           |
JSON   Environment User     Command    Azure
Files  Variables  Secrets   Line       Key Vault
```

Common sources are:

* `appsettings.json`
* `appsettings.Development.json`
* Environment variables
* Command-line arguments
* User Secrets (for local development)
* Azure Key Vault (for production secrets)

---

# Configuration in ASP.NET Core

In `Program.cs`:

```csharp
var builder = WebApplication.CreateBuilder(args);
```

The `builder.Configuration` object is automatically created and loads configuration from the default providers.

Example:

```csharp
string appName = builder.Configuration["ApplicationName"];
```

If `appsettings.json` contains:

```json
{
  "ApplicationName": "Shop API"
}
```

Then:

```csharp
Console.WriteLine(appName);
```

Output:

```text
Shop API
```

---

# Reading Nested Values

**appsettings.json**

```json
{
  "EmailSettings": {
    "Host": "smtp.gmail.com",
    "Port": 587
  }
}
```

Read values:

```csharp
string host = builder.Configuration["EmailSettings:Host"];
string port = builder.Configuration["EmailSettings:Port"];
```

Notice the `:` used to access nested sections.

---

# Binding to a Class (Options Pattern)

Instead of reading values one by one, you can bind them to a class.

**appsettings.json**

```json
{
  "Jwt": {
    "Key": "MySecretKey",
    "Issuer": "ShopAPI"
  }
}
```

**Class**

```csharp
public class JwtSettings
{
    public string Key { get; set; }
    public string Issuer { get; set; }
}
```

Register it:

```csharp
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("Jwt"));
```

This is known as the **Options Pattern**, and it's the recommended approach for related configuration values.

---

# Environment-Specific Configuration

You can have different configuration files for different environments.

```text
appsettings.json
appsettings.Development.json
appsettings.Production.json
```

For example:

**Development**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "DevelopmentDB"
  }
}
```

**Production**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "ProductionDB"
  }
}
```

The appropriate file is loaded based on the current environment.

---

# Interview Answer

> **Configuration in .NET** is a mechanism for storing application settings outside the source code. It allows developers to manage values such as connection strings, API keys, logging settings, and feature flags without recompiling the application. ASP.NET Core can read configuration from multiple sources like `appsettings.json`, environment variables, command-line arguments, User Secrets, and Azure Key Vault. This makes applications more secure, flexible, and easier to maintain.

---

## Quick Revision

| Concept                    | Purpose                                               |
| -------------------------- | ----------------------------------------------------- |
| `appsettings.json`         | Store application settings                            |
| `builder.Configuration`    | Read configuration values                             |
| `GetConnectionString()`    | Read a database connection string                     |
| `GetSection()`             | Read a configuration section                          |
| Options Pattern            | Bind configuration to strongly typed classes          |
| Environment-specific files | Use different settings for Development and Production |

**Remember:** Configuration is about **separating settings from code**, making your application easier to configure, deploy, and maintain.

These are **authentication and authorization mechanisms** used to secure an ASP.NET Core Web API. They answer two questions:

* **Authentication:** *Who are you?*
* **Authorization:** *What are you allowed to do?*

The three most common approaches are **API Keys**, **JWT**, and **OAuth 2.0**.

---

# 1. API Key Authentication

An **API Key** is a unique secret string that a client sends with every request to identify itself.

### How it works

```text
Client
   |
GET /api/products
X-API-Key: abc123xyz
   |
ASP.NET Core Web API
   |
Validates API Key
   |
Returns Response
```

### Example Request

```http
GET /api/products
X-API-Key: abc123xyz
```

or

```http
GET /api/products?apiKey=abc123xyz
```

### Pros

* Very simple to implement
* Good for server-to-server communication
* Lightweight

### Cons

* Doesn't identify individual users
* If the key is leaked, anyone can use it
* No built-in expiration

### Common Use Cases

* Internal APIs
* Microservices
* Third-party integrations
* Weather or maps APIs

---

# 2. JWT (JSON Web Token)

JWT is a **token-based authentication** mechanism.

After a user logs in successfully, the server generates a signed token. The client sends this token with every request.

### How it works

```text
User
   |
Login (username/password)
   |
ASP.NET Core API
   |
Creates JWT
   |
Returns Token
   |
Client stores Token
   |
Future Requests
Authorization: Bearer <JWT>
```

### Login

```http
POST /api/login
```

```json
{
  "username": "john",
  "password": "password123"
}
```

### Response

```json
{
  "token": "eyJhbGciOiJIUzI1NiIs..."
}
```

### Future Requests

```http
GET /api/orders

Authorization: Bearer eyJhbGciOiJIUzI1NiIs...
```

### JWT Structure

A JWT has three parts:

```text
Header.Payload.Signature
```

Example:

```text
xxxxx.yyyyy.zzzzz
```

* **Header** – Algorithm and token type
* **Payload** – Claims (UserId, Role, Expiration, etc.)
* **Signature** – Prevents tampering

### Pros

* Stateless (server doesn't need to store sessions)
* Fast and scalable
* Widely used in modern APIs

### Cons

* Tokens can't easily be revoked before they expire
* Must protect the signing key

### Common Use Cases

* ASP.NET Core Web APIs
* Mobile applications
* Single Page Applications (React, Angular, Vue)

---

# 3. OAuth 2.0

OAuth 2.0 is an **authorization framework**, not an authentication protocol by itself.

It lets users grant one application limited access to resources owned by another service **without sharing their password**.

### Real-World Example

When you click:

```text
Continue with Google
```

or

```text
Sign in with Microsoft
```

OAuth 2.0 is typically involved.

### Flow

```text
User
   |
App
   |
Google Login
   |
User Grants Permission
   |
Google Returns Access Token
   |
App Uses Token
```

### Example

A photo-printing app wants access to your Google Photos.

Instead of asking for your Google password, it redirects you to Google.

Google asks:

> "Do you allow this application to access your photos?"

If you approve, Google issues an access token to the app.

### Pros

* Very secure
* No password sharing
* Supports delegated access
* Industry standard

### Cons

* More complex than API Keys or JWT
* Requires understanding OAuth flows

### Common Use Cases

* Login with Google
* Login with Microsoft
* Login with GitHub
* Login with Facebook

---

# Comparison

| Feature        | API Key                          | JWT                | OAuth 2.0                              |
| -------------- | -------------------------------- | ------------------ | -------------------------------------- |
| Purpose        | Identify the calling application | Authenticate users | Delegate authorization                 |
| Represents     | Application                      | User               | User granting access to another app    |
| Login Required | No                               | Yes                | Yes (via authorization server)         |
| Expires        | Usually No                       | Yes                | Yes                                    |
| Security       | Basic                            | High               | Very High                              |
| Complexity     | Easy                             | Medium             | Advanced                               |
| Common Usage   | Internal APIs                    | Web & Mobile APIs  | Third-party login and delegated access |

---

# Which One Should You Use?

### API Key

Use when:

* A backend service calls another backend service.
* You need simple application-level access.

### JWT

Use when:

* Users log in to your application.
* You're building an ASP.NET Core Web API for web or mobile clients.

### OAuth 2.0

Use when:

* You want users to sign in with Google, Microsoft, GitHub, etc.
* Your application needs permission to access another service on the user's behalf.

---

# ASP.NET Core Example

```text
React App
     |
Login
     |
ASP.NET Core Web API
     |
Generates JWT
     |
Returns Token
     |
React stores Token
     |
Authorization: Bearer <token>
     |
Protected API
```

---

# Interview Answer

> **API Key** is a simple authentication method where the client sends a secret key with each request to identify the application.
>
> **JWT (JSON Web Token)** is a stateless token-based authentication mechanism. After successful login, the server issues a signed token that the client includes in the `Authorization: Bearer` header for future requests.
>
> **OAuth 2.0** is an authorization framework that allows users to grant limited access to their resources without sharing passwords. It is commonly used for "Sign in with Google", "Sign in with Microsoft", and other third-party integrations.

## Easy Way to Remember

| Technology    | Think of it as                                                                |
| ------------- | ----------------------------------------------------------------------------- |
| **API Key**   | A building entry pass for an application                                      |
| **JWT**       | A temporary ID card issued after you log in                                   |
| **OAuth 2.0** | A permission letter allowing one app to access another service on your behalf |

### Important Interview Note

Many people say **"OAuth is authentication."** That's not strictly correct.

* **OAuth 2.0** is primarily an **authorization** framework.
* Authentication is often added using **OpenID Connect (OIDC)**, which is built on top of OAuth 2.0. This is why "Sign in with Google" commonly uses **OAuth 2.0 + OpenID Connect** behind the scenes.

Since you're learning **ASP.NET Core Web API**, **Swagger** is one of the first tools you should master. It is used in almost every modern ASP.NET Core Web API project.

---

# What is Swagger?

**Swagger** is a tool that automatically **documents, visualizes, and tests REST APIs**.

It provides a web page where you can:

* View all API endpoints
* Understand request and response formats
* Test APIs directly from the browser
* See HTTP status codes
* Learn how to call the API

Today, Swagger is part of the **OpenAPI Specification (OAS)**.

> **Swagger UI** = Interactive web interface to test APIs.
>
> **OpenAPI Specification** = Standard format describing your API.

---

# Why Do We Need Swagger?

Imagine you've created 50 API endpoints.

Without Swagger:

* You have to remember every endpoint.
* You need separate documentation.
* Testing becomes difficult.

With Swagger:

You open a browser and immediately see all available APIs.

Example:

```text
Student API

GET     /api/students

GET     /api/students/{id}

POST    /api/students

PUT     /api/students/{id}

DELETE  /api/students/{id}
```

You can click **Try it out**, send requests, and inspect responses.

---

# How Swagger Works

```text
ASP.NET Core Web API
        |
Controller Metadata
        |
Swagger Generator
        |
OpenAPI JSON
        |
Swagger UI
        |
Browser
```

Swagger reads your controllers and generates documentation automatically.

---

# Where Do We Use Swagger?

Swagger is commonly used during:

* API development
* API testing
* API documentation
* Team collaboration
* Frontend-backend integration
* Third-party API integration

For example:

Backend Developer
↓

Creates API

↓

Frontend Developer

↓

Opens Swagger

↓

Tests API

↓

Integrates with Angular/React

---

# Swagger in ASP.NET Core

Create a Web API project.

You'll usually find in `Program.cs`:

```csharp
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
```

Later:

```csharp
app.UseSwagger();

app.UseSwaggerUI();
```

That's all you need.

---

# What Do These Methods Do?

## 1. AddSwaggerGen()

```csharp
builder.Services.AddSwaggerGen();
```

Registers the Swagger/OpenAPI generator.

It scans:

* Controllers
* Endpoints
* HTTP methods
* Parameters
* Response types

---

## 2. AddEndpointsApiExplorer()

```csharp
builder.Services.AddEndpointsApiExplorer();
```

Allows ASP.NET Core to discover API endpoints so Swagger can document them.

---

## 3. UseSwagger()

```csharp
app.UseSwagger();
```

Generates the OpenAPI JSON document.

Usually available at:

```text
https://localhost:5001/swagger/v1/swagger.json
```

This JSON contains the complete API description.

---

## 4. UseSwaggerUI()

```csharp
app.UseSwaggerUI();
```

Creates the interactive web page.

Usually:

```text
https://localhost:5001/swagger
```

---

# Example Controller

```csharp
[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetStudents()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetStudent(int id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult CreateStudent(Student student)
    {
        return Ok();
    }
}
```

Swagger automatically shows:

```text
GET

/api/students

GET

/api/students/{id}

POST

/api/students
```

No extra documentation required.

---

# Testing APIs Using Swagger

Suppose:

```http
POST /api/students
```

Click:

```
Try it out
```

Enter:

```json
{
  "name": "John",
  "course": "C#"
}
```

Click:

```
Execute
```

Swagger sends the request and displays:

* Request
* Response
* Status Code
* Response Headers

---

# Swagger Interface

```
---------------------------------
Student API

GET /api/students

POST /api/students

PUT /api/students/{id}

DELETE /api/students/{id}

[ Try it Out ]
---------------------------------
```

---

# Benefits

### Automatic Documentation

No manual API documentation.

---

### Interactive Testing

No need for Postman for quick tests.

---

### Easy Learning

Frontend developers immediately know:

* URL
* Parameters
* JSON format

---

### Better Team Collaboration

Everyone uses the same documentation.

---

### Time Saving

Documentation stays synchronized with your code.

---

# Swagger vs Postman

| Swagger                   | Postman                                                          |
| ------------------------- | ---------------------------------------------------------------- |
| Browser-based             | Desktop/Web application                                          |
| Auto-generated from API   | Requests created manually                                        |
| Documentation + Testing   | Mainly testing and automation                                    |
| Best for exploring an API | Best for advanced testing, collections, environments, automation |

**Developers often use both**:

* **Swagger** for quick exploration and documentation.
* **Postman** for more advanced testing scenarios.

---

# Customizing Swagger

You can provide API information:

```csharp
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Shop API",
        Version = "v1",
        Description = "E-Commerce Web API"
    });
});
```

Swagger displays:

```
Shop API

Version 1

E-Commerce Web API
```

---

# Swagger with JWT Authentication

You can configure Swagger to send JWT tokens.

After configuration, Swagger shows:

```
Authorize 🔒
```

Click it:

```
Bearer eyJhbGciOiJIUzI1Ni...
```

Now all protected APIs can be tested directly from Swagger.

---

# When Do We Use Swagger?

During development:

✅ Testing APIs

✅ Learning APIs

✅ Documentation

✅ Sharing APIs

✅ Debugging

Production:

* Some organizations disable Swagger for security reasons.
* Others keep it enabled only for authenticated users or internal environments.

---

# Request Flow

```
Browser

↓

Swagger UI

↓

ASP.NET Core Web API

↓

Controller

↓

Database

↓

JSON Response

↓

Swagger UI
```

---

# Complete Flow in ASP.NET Core

```
Program.cs
     |
AddSwaggerGen()
     |
UseSwagger()
     |
UseSwaggerUI()
     |
Open Browser
     |
https://localhost:5001/swagger
     |
Test APIs
```

---

# Interview Questions

### Q1. What is Swagger?

**Answer:**

> Swagger is an OpenAPI-based tool that automatically generates interactive documentation for REST APIs. It allows developers to view, understand, and test API endpoints directly from a web browser.

---

### Q2. Why do we use Swagger?

* API documentation
* API testing
* Team collaboration
* Frontend integration
* Faster development

---

### Q3. Difference between Swagger and Postman?

| Swagger                          | Postman                                    |
| -------------------------------- | ------------------------------------------ |
| Auto-generated API documentation | Manual API testing tool                    |
| Browser-based                    | Standalone application                     |
| Good for discovering APIs        | Better for advanced testing and automation |

---

### Q4. Which NuGet package is commonly used?

The most common package is:

* **Swashbuckle.AspNetCore**

It provides:

* Swagger generation
* Swagger UI
* OpenAPI support

---

# Quick Revision

| Concept                       | Description                                  |
| ----------------------------- | -------------------------------------------- |
| **Swagger**                   | Tool for documenting and testing REST APIs   |
| **OpenAPI**                   | Standard specification describing REST APIs  |
| **AddSwaggerGen()**           | Registers Swagger services                   |
| **AddEndpointsApiExplorer()** | Discovers API endpoints                      |
| **UseSwagger()**              | Generates the OpenAPI JSON document          |
| **UseSwaggerUI()**            | Serves the interactive Swagger web interface |
| **URL**                       | `https://localhost:<port>/swagger`           |
| **Primary Use**               | API documentation, exploration, and testing  |

### Easy Way to Remember

Think of **Swagger as a live instruction manual for your API**. Instead of reading static documentation, you can:

1. See every endpoint.
2. Understand its request and response format.
3. Execute requests directly from your browser.
4. View the actual responses—all without writing a frontend application.
