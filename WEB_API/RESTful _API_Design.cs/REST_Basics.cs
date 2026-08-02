Rest principles?
✅🔥 What is REST ?
REST (Representational State Transfer) is an architectural style used for designing distributed systems and Web APIs.
It was introduced by Roy Fielding in his Ph.D. dissertation in 2000.

REST is:
  Not a protocol
  Not a programming language
  Not a framework
  Not a standard
REST is a set of architectural principles that tells developers how to design Web APIs ,
 so that clients and servers can communicate in a simple, scalable, maintainable, and efficient way.

-----------------------------------------------------------

✅🔥 What Does "Representational State Transfer" Mean ?
Let's understand each word.
✅Representation:
The server does not send the actual resource (such as a database row). 
Instead, it sends a representation of that resource.
For example, an Employee stored in a database may be represented as JSON.

Database Record:
Employee Table
ID    Name     Department
--------------------------
1     John     IT


JSON Representation:
{
    "id": 1,
    "name": "John",
    "department": "IT"
}
The JSON is the representation of the employee.

----------------------------------------------------

✅State:
State means the current condition or data of a resource.
Example:
Before update
{
    "id": 1,
    "name": "John"
}
After update
{
    "id": 1,
    "name": "John Smith"
}
The resource's state has changed.

-----------------------------------------------------

✅Transfer:
Transfer means sending the representation from:
Server → Client
Client → Server
Example:

Browser
   |
HTTP Request
   |
Server
   |
HTTP Response (JSON)
   |
Browser
The representation is transferred over HTTP.


================================================================================================================

✅🔥Real Life Example:
The important idea of REST is this:
REST itself does not define actions like Create, Read, Update, or Delete. 
REST says that every important thing in your application should be represented as a resource (identified by a URL), and HTTP methods should define what action to perform on that resource.
// Resource is any object or information that can be uniquely identified and accessed.

Online Shopping Application:
Suppose you have an online shopping website like Amazon or Flipkart.
There are different types of data in the system.
    Products
    Customers
    Orders
    Payments
Each of these is a resource
    /api/products
    /api/customers
    /api/orders
    /api/payments
Operations are performed using HTTP methods.
     GET    /api/products
     POST   /api/products
     PUT    /api/products/1
     DELETE /api/products/1
Notice that the URL identifies the resource, while the HTTP method identifies the action.

| HTTP Method | URL             | Meaning          |
| ----------- | --------------- | ---------------- |
| GET         | /api/products   | Get all products |
| POST        | /api/products   | Create product   |
| GET         | /api/products/1 | Get product 1    |
| PUT         | /api/products/1 | Update product 1 |
| DELETE      | /api/products/1 | Delete product 1 |







































