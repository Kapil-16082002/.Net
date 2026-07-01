✅🔥Interlocked Class:
The Interlocked class provides atomic(indivisible) operations on shared variables.
That means no two threads can interfere with each other during a read-modify-write operation.
Namespace: using System.Threading;
It ensures that reads and writes to a variable are atomic — i.e., they happen completely or not at all. 


✅🔥 Why was Interlocked introduced : To overcome the Race Condition problem
Full code:
using System;
using System.Threading;
class Program
{
    static int count = 0;
    static void Increment()
    {
        for (int i = 0; i < 100000; i++)
        {
            Interlocked.Increment(ref count);
        }
    }
    static void Main()
    {
        Thread t1 = new Thread(Increment);
        Thread t2 = new Thread(Increment);
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
        Console.WriteLine("Final Count = " + count);
    }
}
Interlocked methods? 
1. Interlocked.Increment()
2. Interlocked.Decrement()
3. Interlocked.Add()
4. Interlocked.Exchange()
5.. Interlocked.Read()

Why is Interlocked so fast?
Why doesn't Interlocked require lock?