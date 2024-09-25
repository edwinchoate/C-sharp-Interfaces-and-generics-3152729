# Notes

## Ch. 1

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

## Ch. 2

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
