✅🔥Generic Collections (Modern & Preferred)
Generic collections are collections in C# that store elements of a specific type using generics (<T>).
Namespace: using System.Collections.Generic;
Features:
    Type-safe
    No boxing/unboxing
    Faster performance
    Compile-time checking

Example:
List<int> numbers = new List<int>();
numbers.Add(10);
numbers.Add(20);
numbers.Add(30);
Strong Type Safety: numbers.Add("Hello"); // ❌ Error


✅🔥Common Generic Collections:

| Collection                          | Type                                                 |
| ----------------------------------- | ---------------------------------------------------- |
| `List<T>`                           | Dynamic array                                        |
| `SortedList<TKey,TValue>`           | Sorted key-value pairs                               |
| `LinkedList<T>`                     | Doubly linked list                                   |


| `Dictionary<TKey,TValue>`           | Key-value pairs                                      |
| `SortedDictionary<TKey,TValue>`     | Sorted key-value pairs                               |


| `Queue<T>`                          | FIFO (First In, First Out)                           |
| `Stack<T>`                          | LIFO (Last In, First Out)                            |


| `HashSet<T>`                        | Unique values                                        |
| `SortedSet<T>`                      | Sorted unique values                                 |


| `PriorityQueue<TElement,TPriority>` | Priority-based queue                                 |

| `ObservableCollection<T>`           | Collection that notifies changes                     |
| `ConcurrentBag<T>`                  | Thread-safe unordered collection                     |
| `ConcurrentQueue<T>`                | Thread-safe FIFO queue                               |
| `ConcurrentStack<T>`                | Thread-safe LIFO stack                               |
| `ConcurrentDictionary<TKey,TValue>` | Thread-safe key-value pairs                          |
| `ConcurrentLinkedQueue<T>`          | Thread-safe queue *(not a standard .NET collection)* |

---------------------------------------------------------------------

✅🔥Why Do We Need Generic Collections?
Before generics, C# had non-generic collections such as:
  ArrayList
  Hashtable
They store elements as object.
Example:
ArrayList list = new ArrayList();
list.Add(10);
list.Add("Hello");
list.Add(20.5);
This allows different types to be stored together.n That can cause problems.


✅🔥 With generic collections:
List<int> numbers = new List<int>();
numbers.Add(10);
numbers.Add(20);
// numbers.Add("Hello"); // ❌ Compile-time error
The compiler knows that this collection should contain only int.

------------------------------------------------------------------

✅🔥 Main Advantages of Generic Collections:

1. Type safety:
List<int> numbers = new List<int>();
numbers.Add(10);
numbers.Add(20);
// numbers.Add("Hello"); // ❌

2. No unnecessary boxing/unboxing for value types:
List<int> numbers = new List<int>();
numbers.Add(10);

3. Better performance
Because generic collections avoid many boxing/unboxing operations and runtime type conversions.

4. Compile-time checking
Errors are caught earlier.
List<string> names = new List<string>();

names.Add("Kapil");
names.Add(100); // ❌ compile-time error
