# Notes

## Ch. 1 - Intro

_interfaces_ - provide a way to specific a set of related behaviors that can be used by different classes
    
* They describe _behaviors_ instead of objects.
* A class _implements_ an interface
* "This class knows how to perform this kind of behavior." 
* Like a contract
* A C# class can implment multiple interfaces

> All the calling object needs to know is that, if some object implements some interface, then that object can perform the capabilities specified in that interface.

_generics_ - give you a way of defining type-safe data structures in your application without commiting to a specific data type ahead of time

* Commonly used with collection types 
* Enforces that data structure only be filled with one type of data

## Ch. 2 - Interfaces

### Conventions

* Put an `I` in front of the interface name to convey that it's an interface
* able/ible is often used as a suffix for interfaces. 
* Ex: `IStorable`

### Defining Interfaces

Defining an interface:

```C#
interface IStorable
{
    void Save();
    void Load();
}
```

Notice, in an interface definition there are no access modifiers. It's actually a compiler error if you include access modifiers. Interfaces are designed to expose information to other classes so their contents are required to be `public`.

It's not possible to declare member variables in an interface (although, properties essentially accomplish the same thing).

Implement an interface:

```C#
class Document : IStorable 
{
    void Save () {...}
    void Load () {...}
}
```

> Using interfaces gives you a way to separate out common sets of behavior in your application and then consume them in multiple places, usually between different types of objects. 

* There are built-in C# interfaces
* You can define custom interfaces
* You can't use the `new` operator to instantiate interfaces

### Calling Interface Methods

`is` operator - can be used to determine if a given object is an instance of a class or base class.

`as` operator - can be used to perform a cast to an object type. If the cast can be performed, the operation will return an object of the specified type. If the cast cannot be performed, it will return `null`.

```C#
interface ISomeInterface
{
    void SomeInterfaceMethod ();
}

class MyClass : ISomeInterface {...}

MyClass mc = new MyClass();

// Using the `is` operator to call interface methods
if (mc is ISomeInterface) 
    mc.SomeInterfaceMethod();

// Using the `as` operator to call interface methods
ISomeInterface i = mc as ISomeInterface;

i.SomeInterfaceMethod();
```

### Multiple Interfaces

```C#
class MyClass : ISomeInterface, IAnotherInterface {...}
```

### Explicit Interface Implementation

Explicit interfaces solve the potential problem of there being a collision between multiple interfaces. Ex: more than one interface has a method with the same name. 

```C#
// say `MyClass` implements `SomeMethod`
class MyClass : ISomeInterface, IAnotherInterface 
{
    public void SomeMethod () {...}    
}

// and `ISomeInterface` has `SomeMethod`
interface ISomeInterface
{
    void SomeMethod ();
}

// and `IAnotherInterface` has `SomeMethod`
interface IAnotherInterface 
{
    void SomeMethod ();
}
```

Then you need to explicitly denote which method is which, like this: 

```C#
class MyClass : ISomeInterface, IAnotherInterface 
{
    public void SomeMethod () {...}

    void ISomeInterface.SomeMethod () {...}

    void IAnotherInterface.SomeMethod () {...}
}
```

To call the different versions of the methods, you cast to the interface types:

```C#
static void Main (string[] args) 
{
    MyClass obj = new MyClass();

    obj.SomeMethod(); // calls MyClass' SomeMethod

    ISomeInterface i1 = obj as ISomeInterface;
    i1.SomeMethod(); // calls MyClass' ISomeInterface.SomeMethod
    
    IAnotherInterface i2 = obj as IAnotherInterface;
    i2.SomeMethod(); // calls MyClass' IAnotherInterface.SomeMethod
}
```

### Useful Built-In .NET Interfaces

* `IComparable`, `IComparer` - Used to compare objects of the same type
* `IDisposable` - Gives callers a way to safely dispose of your object and release resources 
* `IEquatable` - Used to determine equality of two objects of the same type 
* `INotifyPropertyChanged` - Broadcast changes to property values on your object [Docs](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=net-8.0)

## Ch. 3 - Generics

Anti-example: .NET's `ArrayList` 

* `System.Collections.ArrayList` allows data of any type to the list. This can cause problems in the program. 

```C#
ArrayList arrayList = new ArrayList();
arrayList.Add(1);
arrayList.Add("two");
```

The above code compiles, but, at runtime...

```bash
$ dotnet run
Unhandled exception. System.InvalidCastException: Unable to cast object of type 'System.String' to type 'System.Int32'...
```

By contrast, this won't compile:

```C#
List<int> list = new List<int>();
list.Add(1);
list.Add("two");
```

### [System.Collections.Generic](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-8.0)

#### Classes
* `Dictionary<TKey, TValue>`
* `HashSet<T>`
* `LinkedList<T>`
* `List<T>`
* `PriorityQueue<TElement, TPriority>`
* `Queue<T>`
* `SortedDictionary<TKey, TValue>`
* `SortedList<TKey, TValue>`
* `SortedSet<T>`
* `Stack<T>`
* and more

#### Interfaces
* `IEnumerable<T>`
* `IAsyncEnumerable<T>`
* `IEnumerator<T>`
* `ICollection<T>`
* `IEqualityComparer<T>`
* and more 

### Using Lists

Creating a new list:

```C#
List<Person> people = new List<Person>();
```

Adding items to the list: 

```C#
people.Add(new Person("Bob", "Smith"));
```

Get the length of the list: 

```C#
int headcount = people.Count();
```

See if an item is in the list:

```C#
if (people.Exists((p) => p.FirstName == "Bob"))
```

Find an item in the list: 

```C#
Person bob = people.Find((p) => p.FirstName == "Bob");
```

Iterate through the list:

```C#
foreach (Person person in people) {...}
```

### Stacks and Queues

Stacks

* `Count` 
* `Clear`
* `Contains`
* `Peek` - returns the top item in the stack but does not remove it
* `Push`
* `Pop`

Queues

* `Count`
* `Clear`
* `Contains`
* `Peek` - Returns the item in the front of the queue, but does not remove it 
* `Enqueue` - adds a new item to the end of the queue
* `Dequeue` - remove the front item from the queue

### Dictionaries 

* `Count`
* `Clear`
* `ContainsKey`
* `ContainsValue`
* `Add` - throws an exception if a given key already exists
* `Remove`

Working with key-value pairs:

```C#
foreach (KeyValuePair<int, string> kvp in myDict) {
    int key = kvp.Key;
    string value = kvp.Value;
}
```