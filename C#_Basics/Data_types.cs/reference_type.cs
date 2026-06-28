✅🔥Reference Types:
│     ├── string   // built-in reference types:
│     ├── object   // built-in reference types:
│     ├── class
│     ├── array
│     ├── interface
│     └── delegate
|     ├── dynamic

✅🔥A Reference Type stores the memory address(reference) of object which ultimately is stored on the Heap.
Think of it like this:
Heap → The actual house
Reference variable → The house address
The variable does not contain the object itself, it only points to it.


✅🔥Value Type vs Reference Type
Value Type
-----------
Stack
+-------+
| x=100 |
+-------+


Reference Type
---------------
Stack               Heap
+---------+      +------------------+
| obj ----|----->| Name = "Kapil"   |
+---------+      | Age = 23         |
                 +------------------+