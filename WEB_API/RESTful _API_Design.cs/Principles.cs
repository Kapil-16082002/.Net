✅🔥 REST Principles (REST Architectural Constraints)

REST defines a set of architectural principles (constraints) that help developers build scalable, maintainable, and high-performance web services.
There are 6 REST principles (constraints):
   Client-Server Architecture
   Statelessness
   Cacheability
   Uniform Interface
   Layered System
   Code on Demand (Optional)



✅🔥1. Client-Server Architecture:
REST requires that the client and the server are separate and independent.
The client should not worry about how data is stored, and the server should not worry about how the UI is displayed.
Client → Sends requests (browser, mobile app, desktop app)
Server → Processes requests and returns responses


Real-Life Example:
Think of a restaurant.
Customer → Client
Waiter → Communication
Kitchen → Server
The customer orders food but doesn't know how it's cooked. The kitchen prepares the food without knowing how the customer will eat it.

Why is it needed ?
Separating responsibilities makes both sides easier to develop and maintain.
    Client Responsibilities
    Display data
    Take user input
    Send requests
    Show responses
    Server Responsibilities
    Store data
    Process business logic
    Authenticate users
    Return responses

------------------------------------------------------------------

✅🔥 2. Statelessness
Every request from the client must contain all the information the server needs to process it.
The server does not store client session information between requests.

Real-Life Example:
ATM Machine
Every time you perform an operation, the ATM verifies your card and PIN. 
It doesn't rely on what you did previously.

Why is it needed?
Statelessness provides:
   Better scalability
   Easier load balancing
   Simpler server management
   Higher reliability

------------------------------------------------------------------

✅🔥 3. Cacheability
REST responses should indicate whether they can be cached (stored temporarily).
If data doesn't change often, clients or intermediaries can reuse cached responses instead of requesting them again.
Why is it needed?
Benefits include:
    Faster responses
    Reduced server load
    Less network traffic
    Better user experience











































