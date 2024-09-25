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

Defining an interface:

```C#
interface IStorable
{
    void Save();
    void Load();
}
```

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

