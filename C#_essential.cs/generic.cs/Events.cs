
✅🔥 What is an Event?
An Event is a mechanism that allows one object (Publisher) to notify other objects (Subscribers) when something interesting happens.
Definition:
An Event is a special delegate that provides a controlled way for one class to notify other classes when a specific action occurs.


✅🔥Real World Analogy
Imagine YouTube.
Publisher(YouTuber): uploads a new video on YouTube Channel.
Subscribers: People who subscribed to the channel get notifications.
Important Point: The channel doesn't know who the subscribers are.
It simply says: "A new video has been uploaded."
Anyone who subscribed receives the notification.
This is exactly how Events work.

-------------------------------------------------------------------

✅🔥 Why Do We Need Events?
Without events, objects would need continuous polling.
Example:
while(true)
{
    if(button.IsClicked)
    {
        // do something
    }
}
This wastes CPU.
Instead: button.Click += HandleClick;
When click occurs: HandleClick(), is automatically executed.
This is efficient and loosely coupled.

---------------------------------------------------------

✅🔥 Publisher and Subscriber
Publisher: Raises the event.
Example:
  Button
  Timer
  FileWatcher
  OrderService

Subscriber: Listens to the event.
Example:
   EmailService
   SMSService
   Logger
   UI Component
---------------------------------------------------------


✅🔥 Event Internally Uses Delegate

Example: public delegate void MyDelegate();
Event declaration: public event MyDelegate ProcessCompleted;
An event cannot exist without a delegate.


✅🔥Basic Event Example:
✅ Step 1: Create Delegate
public delegate void Notify(); // here Notify is delegate name

✅ Step 2: Publisher
class Process
{
    public event Notify ProcessCompleted; //  event keyword converts the delegate into an event.
    public void Start()
    {
        Console.WriteLine("Process Started");
        ProcessCompleted?.Invoke();
    }
}
✅ Step 3: Subscriber
class Subscriber
{
    public void ShowMessage()
    {
        Console.WriteLine("Process Finished");
    }
}
✅ Step 4: Main
class Program
{
    static void Main()
    {
        Process process = new Process();
        Subscriber subscriber = new Subscriber();
        process.ProcessCompleted += subscriber.ShowMessage;

        process.Start();
    }
}
/*  Interview Question:
With event:
public event Notify ProcessCompleted;
Other classes may subscribe, but they cannot ❌invoke or ❌overwrite it. This is called Encapsulation.
Outside classes ✔ can subscribe, ✔ can unsubscribe

Without event: 
public Notify ProcessCompleted; someone could write, process.ProcessCompleted();from outside.
That is dangerous.

*/
✅🔥 Why Events Were Introduced?
Suppose we use only delegates.
public delegate void Notify();
class Process
{
    public Notify ProcessCompleted;
}
Another class can do:
Process p = new Process();
p.ProcessCompleted = null;
or
p.ProcessCompleted();
or
p.ProcessCompleted = SomeOtherMethod;
This breaks encapsulation because any external code can overwrite, clear, or invoke the delegate.

With event:
public event Notify ProcessCompleted;
Other classes may subscribe, but they cannot ❌invoke or ❌overwrite it. This is called Encapsulation.


---------------------------------------------------------

✅🔥Differences Between Delegates and Events in C#

Delegate = A type-safe function pointer that can reference one or more methods.
Event = A notification mechanism built on top of delegates that follows the Publisher-Subscriber pattern and restricts who can invoke it.

✅Real-Life Analogy
Imagine a TV Channel.

Delegate:
Think of a TV Remote Control.
Anyone holding the remote can:
   Turn the TV on/off
   Change channels
   Adjust volume
There are no restrictions.



Event
Think of a TV Broadcast.
The TV channel decides when to broadcast a program.
Viewers can:
  Subscribe (watch)
  Stop watching (unsubscribe)
But viewers cannot start the broadcast.
This is exactly how Events work.













