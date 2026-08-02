
✅🔥 REST and HTTP:
Modern web and mobile applications communicate over a network. For example:
   Amazon App ↔ Amazon Server
   Flipkart Website ↔ Database Server
   Banking App ↔ Banking Server
   ASP.NET Core MVC Application ↔ SQL Server
Whenever a client (browser/mobile application) wants some data, it sends a request to the server, and the server sends back a response.
This communication is mainly based on HTTP, while most modern Web APIs follow the REST architectural style. 
REST is an architectural style, whereas HTTP is a communication protocol.

-------------------------------------------------------------

✅🔥2. What is HTTP ?
HTTP (HyperText Transfer Protocol) is an application-layer communication protocol used for transferring data between a client and a server over the Internet.
In simple words,
HTTP is the language or protocol that allows clients and servers to communicate with each other.

For example:
   Browser requests a web page.
   Mobile app requests product details.
   ASP.NET Core application requests employee information.
All these communications happen using HTTP.

=--------------------------------------------------------------

✅🔥 Why Do We Need HTTP ?
Without HTTP,
    Browsers cannot request web pages.
    Mobile apps cannot communicate with servers.
    APIs cannot send or receive data.
    Clients and servers would have no standard way to communicate.
HTTP provides a standard communication mechanism.

Example:
Suppose you open:  https://example.com/products
The browser sends HTTP Request
The server processes the request and sends HTTP Response

Flow:
Client (Browser/Postman)
        |
        | HTTP Request
        |
        V
--------------------------
|      Web Server        |
--------------------------
        |
        | Process Request
        |
        V
Database / Business Logic
        |
        | HTTP Response
        |
        V
Client

==================================================================================================================

✅🔥 Components of an HTTP Request
An HTTP request mainly consists of four parts:
HTTP Request
│
├── 1. Request Method
├── 2. URL
├── 3. Headers
└── 4. Body (Optional)

✅🔥 1. Request Method
The Request Method tells the server what action the client wants to perform.
It is the first word in the request.

Common HTTP Methods:
| Method  | Purpose                    |
| ------- | -------------------------- |
| GET     | Retrieve data              |
| POST    | Create new data            |
| DELETE  | Delete data                |
| PUT     | Replace existing data      |
| PATCH   | Partially update data      |
| HEAD    | Retrieve only headers      |
| OPTIONS | Discover supported methods |
Example:
GET means "Server, please send me the requested resource."
POST means "Server, please create a new resource."

----------------------------------------------------------------

✅🔥 2. URL (Uniform Resource Locator)
The URL indicates the address of the resource that the client wants to access.
A URL consists of multiple parts.
Example:
https://localhost:5000/api/employees/10

| Part     | Value             | Description            |
| -------- | ----------------- | ---------------------- |
| Protocol | https             | Communication protocol |
| Host     | localhost         | Server name            |
| Port     | 5000              | Server port            |
| Path     | /api/employees/10 | Requested resource     |

--------------------------------------------------------------------

✅🔥 3. Headers
Headers provide additional information about the request.
They help the server understand:
    What type of data is being sent
    What type of response is expected
    Authentication information
    Caching preferences
    Language preferences
    Cookies and session information
Headers are sent as key-value pairs.

Syntax:
Header-Name: Header-Value
Example: Content-Type: application/json



✅🔥 Common HTTP Request Headers
✅1. Host:
Specifies the server receiving the request.
Host: localhost:5000

✅2.Accept:
Specifies the response format the client can handle.
Accept: application/json
Meaning: "Please return the response in JSON format."
Other examples:
Accept: text/html
Accept: application/xml

✅3.Content-Type:
Specifies the format of the request body.
Content-Type: application/json
Meaning: "The body contains JSON data."

✅4.Authorization:
Carries authentication credentials.
Example: Authorization: Bearer eyJhbGciOiJIUzI1NiIs...
Used with JWT or OAuth tokens.

✅5. User-Agent
Identifies the client making the request.
Example: User-Agent: Mozilla/5.0
or
User-Agent: PostmanRuntime/7.39.0


✅6. Content-Length
Indicates the size of the request body in bytes.
Example
Content-Length: 120

-----------------------------------------------------------------------


✅🔥4. Body (Optional)
The Body contains the actual data sent from the client to the server.
It is mainly used with:
   POST
   PUT
   PATCH
GET requests typically do not include a request body.

Example JSON Body
{
    "id": 1,
    "name": "Kapil",
    "department": "IT",
    "salary": 70000
}

The server reads this JSON and performs the requested operation.

=======================================================================

✅🔥Complete HTTP Request Example (POST)
POST /api/employees HTTP/1.1
Host: localhost:5000
Content-Type: application/json
Accept: application/json
Authorization: Bearer <token>

{
    "name": "Kapil",
    "department": "IT",
    "salary": 70000
}
Explanation
POST: Create a new employee.
Host: Specifies the server.
Content-Type: Indicates the body is JSON.
Accept: Requests a JSON response.
Authorization: Includes a bearer token for authentication.
Body: Contains the employee details to create.

==========================================================================

✅🔥 Complete HTTP Request Example (GET)
GET /api/employees HTTP/1.1
Host: localhost:5000
Accept: application/json
User-Agent: Mozilla/5.0

| Line           | Meaning             |
| -------------- | ------------------- |
| GET            | Retrieve data       |
| /api/employees | Requested resource  |
| HTTP/1.1       | HTTP version        |
| Host           | Target server       |
| Accept         | Client expects JSON |
| User-Agent     | Client information  |
Since this is a GET request, there is no request body.



==================================================================================================================


✅🔥 HTTP Response
An HTTP Response consists of:
   Status Code
   Headers
   Body
Example:  HTTP/1.1 200 OK
[
   {
      "id":1,
      "name":"John"
   }
]
Common HTTP Status Codes:
| Status Code               | Meaning                      |
| ------------------------- | ---------------------------- |
| 200 OK                    | Request successful           |
| 201 Created               | Resource created             |
| 204 No Content            | Success but no data returned |
| 400 Bad Request           | Invalid request              |
| 401 Unauthorized          | Authentication required      |
| 403 Forbidden             | Access denied                |
| 404 Not Found             | Resource not found           |
| 500 Internal Server Error | Server error                 |








































