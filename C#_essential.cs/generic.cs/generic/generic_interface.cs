✅🔥 What is a Generic Interface?
A Generic Interface is an interface that defines type parameters, allowing implementations to work with different data types in a type-safe and reusable way.
Instead of fixing a type inside the interface, we make it flexible using T.


✅ Why Do We Need Generic Interfaces?
Without generics, we often end up duplicating interfaces.

❌ Without Generics
public interface IRepository
{
    void Add(object item);
    object GetById(int id);
}
Problems:
No type safety (object → boxing/unboxing)
Runtime casting required
Easy to introduce bugs
Example:
IRepository repo;
repo.Add("Hello"); // string
repo.Add(100);     // int (invalid logically but allowed)


Solution: Generic Interface
✔ Type-safe version:
public interface IRepository<T>
{
    void Add(T item);
    T GetById(int id);
}
Now type is decided at compile time.




✅🔥Key Benefits of Generic Interfaces
1. Type Safety
IRepository<Student> // Only Student objects can be added.
❌ No accidental mixing of types.


2. Code Reusability
Same interface works for:
IRepository<Student>
IRepository<Employee>
IRepository<Product>
No need to rewrite logic.


3. No Casting Required
Without Generics:
Student s = (Student)repo.GetById(1);
With Generics:
Student s = repo.GetById(1);

4. Compile-time Safety
Errors are caught early:
repo.Add("string"); // ❌ compile error













