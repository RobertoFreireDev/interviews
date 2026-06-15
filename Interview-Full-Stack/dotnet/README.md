## DotNet and Object-Oriented Programming (OOP) in C#

_____________________________

### DotNet

#### Web servers 

##### Internet Information Services (IIS)

Internet Information Services (IIS) for Windows Server is a flexible, secure and manageable Web server for hosting anything on the Web

##### Kestrel

Kestrel is a cross-platform web server built for ASPNET Core based on libuv – a cross-platform asynchronous I/O library.
It is secure and good enough to use it without a reverse proxy server (IIS, Nginx or Apache)

##### WebListener

WebListener is also a web server for ASPNET Core that runs only on Windows. It’s built on the Http.Sys kernel mode driver. WebListener is an alternative to Kestrel that can be used for direct connection to the Internet without relying on IIS as a reverse proxy server.

#### Common Language Runtime (CLR)

A CLR handles memory allocation and management. A CLR is also a virtual machine that not only executes apps but also generates and compiles code on-the-fly using a JIT compiler.

#### Core Common Language Runtime (Core CLR)

The Common Language Runtime for .NET 5 (and .NET Core) and later versions. Core CLR is a runtime for .NET Core. It includes JIT, GC and several low-level classes. 

#### Base Class Libraries (BCL)

A set of libraries that comprise the System.* 

#### Framework Class Library (FCL) 

FCL is the wider library that contains the totality: ASPNET, WinForms, the XML stack, ADONET and more. You could say that the FCL includes the BCL.

#### CoreFX

CoreFX is the foundational class libraries for .NET Core. It includes types for collections, file systems, console, JSON, XML, async and many others.

#### Common Intermediate Language (CIL)

Higher-level .NET languages, such as C#, compile down to a hardware-agnostic instruction set, which is called Common Intermediate Language (CIL). 

#### Just In Time Compiler (JIT)

JIT translates CIL to machine code that the processor understands. 

#### .NET Framework, .NET Core and .NET Standard

<p align="center">
  <img src="images/dotNET_Core_dotNET_CLI_Compilation.png?raw=true">
</p>

##### .NET Framework

* It can run applications on Windows platform only.
* Web applications built using this platform can only be hosted on IIS.
* It supports ASPNET Web Forms, WinForms, WCF, Silverlight, etc. 
* The building blocks of .NET Framework are Common Language Runtime (CLR) and Base Class Libraries (BCL) and Common Intermediate Language (CIL).
* The Code written in C#, F# or VB is converted by the compiler into CIL. The code is executed by CLR using JIT to machine-specific code.

<p align="center">
  <img src="./images/CLR_CIL_JIT.jpg?raw=true">
</p>

##### .NET Core

* .NET Core is the cross-platform and open-source implementation of .NET.
* It supports modern application frameworks such as gRPC, ASPNET Core Razor Pages, Blazor (for WebAssembly), UWP and etc.
* The building blocks of .NET Core are Core CLR and CoreFX. 

<p align="center">
  <img src="./images/dotnet_core_code_execution.jpg?raw=true">
</p>

##### .NET Standard

* NET Standard is a specification that can be used across all .NET implementations. 
* It is used for developing library projects only. This means if we are creating a library in .NET Standard we can use those in .NET Framework and .NET Core.

<p align="center">
  <img src="./images/NET_Core_NET%20Framework.png?raw=true">
</p>

#### Features provided by ASPNET Core

* Cross-platform.
* Built-in supports for Dependency Injection.
* Fast and cross-platform web server – Kestrel.

#### Assembly

An assembly is a ".dll" or ".exe" file created by compiling one or more .cs files in a single compilation. It contains one or more than one Namespaces.

#### Namespace

Namespace is a way of grouping classes and reducing the chance of name collisions.

#### Process

A process is an executing application. 

#### Thread

A Thread is a small set of executable instructions. The operating system executes code within a thread. The operating system switches between threads, allowing each to execute in turn, thus giving the impression that multiple applications are running at the same time.

A single thread in a C# application is an independent execution path that can run simultaneously with the main application thread. A C# client program (Console, WPF, or Windows Forms) starts in a single thread created automatically by the CLR and operating system (the "main" thread), and is made multithreaded by creating additional threads.

#### Task

A Task is a higher level concept than Thread. We can easily implement Asynchronous using ’async’ and ‘await’ keywords. Task does use thread pool.

#### Thread vs Task

* Task can return a result. There is no direct mechanism to return the result from a thread.
* Task supports cancellation through the use of cancellation tokens. But Thread doesn't.
* A task can have multiple things happening at the same time. Threads can only have one thing running at a time.

<p align="center">
  <img src="./images/thread_task.png?raw=true">
</p>

#### Garbage collector.

The garbage collector is an implementation of automatic memory management. The GC frees memory occupied by objects in the **heap** that are no longer in use.

**Stack** performs its own management using battery resources, that is, the first one in is the last one out. (FIRST ENTRY / LAST EXIT)

Example: Local variables (i.e. those that are declared inside methods) are stored on the stack.

**Note:** in the case of multi-threading, each thread has its Stack. However, Heap is consistently shared among all the threads. That is why when writing a multi-threading application, developers must be aware of thread safeness to avoid race condition.

#### Value types

bool, byte,char,decimal, double, float, int, long, short, struct, enum, tuples,...

#### Value types vs Reference type

**Value types** are allocated either on the stack or the heap depending on where they are created.

**Reference types** are always allocated on the heap and garbage-collected. 

##### Memory allocation for value types

Value type inside a function has **zero memory heap** allocation. It is allocate in the **stack**.

```cs
public class Class 
{ 
    // "d.a" is allocate in the parent "d" (Reference type) which is in the heap
    public int a = 123; 

    public void Method(int number) // argument value type is allocate in the stack 
    {
        var c = new ClassC();
        int b = 123; // "b" is allocate in the stack 
    }
}
...
var d = new Class(); 
d.Method(45);
```

#### Nullable types

- All reference types are nullable
- With Nullable<T> Struct, we can apply null to value types

```cs
// 
public partial struct Nullable<T> where T : struct
{
    private readonly bool hasValue; 
    internal T value; 
    ...
}
```

```cs
int? a = null;

if (a.HasValue)
{
    Console.WriteLine("1:" + a.Value);
}

a = 10;

if (a.HasValue)
{
    Console.WriteLine("2:" + a.Value);
}

//output
//2:10
```

##### Null-conditional operators ?. and ?[]

A null-conditional operator applies a member access (?.) or element access (?[]) operation to its operand only if that operand evaluates to non-null; otherwise, it returns null

```cs
var person = new Person() { Name = "Raul" };
var people = new Person[]{ null, new Person() { Name = "Sarah"} };

Console.WriteLine("1:" + person?.Name);
Console.WriteLine("2:" + people?[0]?.Name);
Console.WriteLine("3:" + people?[1]?.Name);

person = null;
people = null;

Console.WriteLine("4:" + person?.Name);
Console.WriteLine("5:" + people?[0]?.Name);
Console.WriteLine("6:" + people?[1]?.Name);

//output
1:Raul
2:
3:Sarah
4:
5:
6:
```

##### Null coalescing operator

TO DO: Null coalescing operator

https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator

#### Equality operators

Reference-type operands are equal if they refer to the same object
```cs
var person1 = new Person() { Name = "Raul" };
var person2 = new Person() { Name = "Raul" };

Console.WriteLine("1:" + (person1 == person2));
person2 = person1;
Console.WriteLine("2:" + (person1 == person2));
//output
//1:False
//2:True
```

#### ReferenceEquals

```cs
var person1 = new Person() { Name = "Raul" };
var person2 = new Person() { Name = "Raul" };

Console.WriteLine("1:" + ReferenceEquals(person1,person2));
person2 = person1;
Console.WriteLine("2:" + ReferenceEquals(person1, person2));
person2.Name = "Sanchez";
Console.WriteLine("3:" + ReferenceEquals(person1, person2));

//output
//1:False
//2:True
//3:True
```

#### Exception Handling Statements

<p align="center">
  <img src="./images/trycatchfinaaly.png?raw=true">
</p>

TO DO: General Exception Handling Statements

https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/exception-handling-statements

TO DO: Best practices

https://www.bytehide.com/blog/5-good-practices-for-error-handling-in-c

https://learn.microsoft.com/en-us/dotnet/standard/exceptions/best-practices-for-exceptions

#### String

In C#, a string is a sequence of characters. Strings are immutable, which means their content cannot be modified after creation. Any operation that appears to modify a string actually creates a new string with the desired changes.

```cs
// string is a sequence of characters
string text = "some word";

Console.WriteLine("1:" + text[0]);
Console.WriteLine("2:" + text[1]);
Console.WriteLine("3:" + text.Length);

//output
//1:s
//2:o
//3:9
```
String equality: Two string operands are equal when both of them are null or both string instances are of the same length and have identical characters in each character position

TO DO: Strings operations

https://medium.com/@praveen.rao.g.1990/working-with-strings-in-c-a-comprehensive-guide-242ca55934b0#:~:text=In%20C%23%2C%20a%20string%20is,string%20with%20the%20desired%20changes.

TO DO: Use String Builder instead of string concatenation for performance improvement

https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/string-concatenation

#### Metapackages

The framework .NET Core 2.0 introduced Metapackage that includes all the supported packages code with their dependencies into one package. It helps us to do fast development as we don’t require to include the individual packages. Example: Microsoft.AspNetCore.All.

<p align="center">
  <img src="./images/Metapackages.png?raw=true">
</p>

#### Middleware

##### ASPNET Core Middleware vs ASPNET Core Filters?

##### What is the difference between IApplicationBuilder.Use() and IApplicationBuilder.Run()

##### What is the use of “Map” extension while adding middleware to the ASPNET Core pipeline

##### What is the Run extension?

##### How to enable Session in ASPNET Core?

#### ASPNET Core Dependency Injection

ASPNET Core has a native dependency injection resolution

```cs
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();
    
    services.AddScoped<StoreDataContext, StoreDataContext>();
    services.AddTransient<ProductRepository, ProductRepository>();
}
```

| Type  | Same request | Different request |
| ----- | -----  | -----  |
| Singleton | same instance | same instance | 
| Scoped | same instance  | new instance  |
| Transient | new instance | new instance | 

#### Managed and Unmanaged Code

**Managed** code is code whose execution is managed by a runtime (Common Language Runtime) which in turns looks after your applications by managing memory, handling security, allowing cross - language debugging, and so on.

The code, which is developed outside .NET, Framework is known as **unmanaged code**.
Applications that do not run under the control of the CLR are said to be unmanaged. Languages such as C or C++ or Visual Basic are unmanaged. The object creation, execution, and disposal of unmanaged code is directly managed by the programmers. If programmers write bad code, it may lead to memory leaks and unwanted resource allocations.
_____________________________

### Object-Oriented Programming (OOP) in C#

#### Properties

C# properties are members of a C# class that provide a flexible mechanism to read, write or compute the values of private fields, in other words, by using properties, we can access private fields and set their values. Properties in C# are always public data members. C# properties use get and set methods, also known as accessors, to access and assign values to private fields.

```cs
class ClassB
{  
    private int x;  

    public int X  
    {  
        get  
        {  
            return x;  
        }  
        set  
        {  
            x = value;  
        }  
    } 
} 
```

#### Access Modifiers

| Caller's location  | public | protected internal | protected | internal | private protected | private |
| ------------- | :---:  | :---:  |  :---:  | :---:  |  :---:  | :---:  |
| Within the class |✔️ |  ✔️ | ✔️ | ✔️ | ✔️ | ✔️ | 
| Derived class (same assembly) | ✔️ |  ✔️ | ✔️ | ✔️ | ✔️ | ❌ |
| Non-derived class (same assembly) | ✔️  | ✔️  | ❌ |✔️  |  ❌ | ❌ |
| Derived class (different assembly) | ✔️ |  ✔️  | ✔️  |  ❌ | ❌ | ❌ |
| Non-derived class (different assembly) | ✔️  | ❌ | ❌ | ❌ | ❌ | ❌ | ❌ |

#### Continue and break in loop

The **break** statement: terminates the closest enclosing iteration statement or switch statement.

The **continue** statement: starts a new iteration of the closest enclosing iteration statement.

```cs
int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
foreach (int number in numbers)
{
    if (number == 3) continue;    
    
    if (number == 3 || number == 5)
    {
        break;
    }

    Console.Write($"{number} ");
}
// Console output
// 0 1 2 4 
```

#### Constant vs readonly vs static

**Const** is initialized during compile-time. By default a const is static **Readonly** initialized is by the latest run-time. 

Use the **static** modifier to declare a static member, which belongs to the type itself rather than to a specific object.

```cs
public class ClassB
{
    public readonly string field1;
    public static string field2;
    public const string field3 = "Const_Field"; // it requires a value
}
...
var value1 = ClassB.field2; //  through "ClassName.VariableName"
var value2 = ClassB.field3; //  through "ClassName.VariableName"
```

##### Readonly

```cs
public class ClassB
{
    public readonly string field1 ="test";

    ClassB()
    {
        field1 = "test";
    }

    public void Method()
    {
        field1 = "test"; // Compiler Error: A readonly field can only take an assignment in a constructor or at declaration.
    }
}
```

##### Static

Static members
```cs
public class ClassB
{
    public static string field1 = "test1";

    public string field2 = "test2";

    public ClassB()
    {
        field1 = "test3";
        field2 = "test4";
    }

    public static void function1()
    {
        field1 = "test5";
        //field2 = "test6"; // An object reference is required for the nonstatic field, method, or property 'member'
    }
}

var b = new ClassB();

Console.WriteLine(ClassB.field1);
Console.WriteLine(b.field2);

// output
// test3
// test4
```

Static class, all members must be static
```cs
public static class ClassB
{
    public static string field1 ="test";

    public string field2 ="test"; // Compiler Error: Cannot declare instance members in a static class. The static keyword should be applied to all members of static classes.

    ClassB() {} // Compiler Error: A static class cannot be instantiated, hence it has no need for constructors.

    public void Method(){ } // Compiler Error: The static keyword should be applied to all members of static classes.
}
```

#### Sealed 

Sealed classes are used to restrict the inheritance

```cs
public sealed class ClassB {}

public class ClassC : ClassB // Compiler Error: A sealed class cannot act as a base class. Structs are sealed by default.
{
}
```

Sealed methods are used to prevent override
```cs
public class ClassA
{
    // cannot use sealed in base class
    public virtual void Method1(){}
}

public class ClassB : ClassA
{
    public sealed override void Method1(){}
}

public class ClassC : ClassB
{
    public override void Method1(){} // Compiler Error: A member cannot override a sealed inherited member.
}
```

#### Struct

**Struct** can’t be inherited.

**Structs** are value types while **classes** are reference types. 

```cs
public struct A { 
    public string b; 

    public void Method()
    {
        int a = 123;        
    }
}
```

#### Use enumeration classes instead of enum types

[TO DO]

https://docs.microsoft.com/pt-pt/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types


#### Why are strings in C# immutable?

[Draft]
Immutable means string values cannot be changed once they have been created. Any modification to a string value results in a completely new string instance, thus an inefficient use of memory and extraneous garbage collection. The mutable System.Text.StringBuilder class should be used when string values will change.

https://www.techrepublic.com/article/c-developer-interview-questions-and-answers/

#### Abstract Class vs Interfaces

##### Interfaces

Interface defines a contract between an object and its user. It can be implemented by a class or a struct that adheres to the contract.

**Cannot** create an instance of interface
```cs
public interface IA {}
... 
var classB = new IA(); // Compiler Error
```

An interface can contain methods and properties but **not fields**.
```cs
public interface Ib 
{
  public string Field1; // Compiler Error

  public string Property1 { get; set; }  

  // It is possible to create property like below.
  // But, it will not be acessable by the class which implements this interface.
  public string Property2 {
      get
      {
          return "text";
      }
      set
      {
          Console.WriteLine(value);
      }
  }
}
...
public class ClassB : Ib
{
    public string Property1 { get => "test ClassB"; set => Console.WriteLine(value); }
}
```

Class can implement multiple interfaces 

```cs
public interface IA {
    public void Function1();
}

public interface IB {
    public void Function2();
}

public class C : IA, IB
{
    public void Function1() { }

    public void Function2() { }
}
```

##### Abstract Class

An abstract class provides a partial implementation that other classes can build on. When a class is declared as abstract, it means that the class can contain incomplete members that must be implemented in derived classes, in addition to normal class members.


A method/property **cannot** be an abstract member of a nonabstract class.
```cs
public class ClassA 
{
    public abstract string Property1 { get; set; } // Compiler Error

    public abstract void Function1(); // Compiler Error
}
```

The modifier 'abstract' is not valid on fields. Try using a property instead
```cs
public abstract class ClassA 
{
    public abstract string Property1; // Compiler Error
}
```

- **Cannot** create a directly instance of an abstract class
- But, an abstract class is instantiated by creating a concrete class that is derived from it.
- So, when create a instance of a subclass of an abstract class, it also creates a instance of the abstract class.
- Because an abstract class can be instantiated, it must have a constructor.
- Even if we don’t provide any constructor, the compiler will add default constructor in an abstract class.

```cs

public abstract class ClassB
{
    public ClassB()
    {
        Property2 = "Value 1";
        Property1 = Property2 + Function2();
    }

    public abstract string Property1 { get; set; }

    public string Property2 { get; set; }

    public abstract string Function1();

    public string Function2()
    {
        return "test4";
    }        
}

public class ClassA : ClassB
{
    public override string Property1 { get; set; }

    public override string Function1()
    {
        return Property1;
    }
}


//var b = new ClassB(); // Cannot create an instance of the abstract class
var a = new ClassA();

Console.WriteLine(a.Function1());

// Output
// Value 1test4
```

Class **cannot** inherit multiple classes/abstract classes. 
```cs
public class A {}

public abstract class B {}

public class D : A, B // error 
{}
```

Implementation of an abstract class
```cs
public abstract class ClassA 
{
    public abstract string Property1 { get; set; }
    
    public abstract void Function1(); 

    public string Function2()
    {
        return "test2";
    }
}
...
public class ClassB : ClassA
{
    private string property;

    public override string Property1 { get => property; set => property = value; }

    public override void Function1()
    {
        property = property + " add value";
    }
}
...
var b = new ClassB();
b.Property1 = "test value";
b.Function1();
Console.WriteLine(b.Property1);
Console.WriteLine(b.Function2());

// Console Output
// test value add value
// test2
```

#### Virtual vs Abstract

- **Cannot** use virtual to class.
- **Virtual** methods **must** have a body.
- **Virtual** methods can optionally be overridden

- **Abstract** members must be in a abstract class.
- **Abstract** methods **can not** have a body.
- Classes that inherits a abstract class **must** implement its abstract members (like when a class implements a interface)

```cs
public class ClassA 
{
    public string Property1 { get; set; }

    public virtual string Property2 { get; set; }
    
    public void Function1()
    {
        // do something
    }

    public virtual string Function2()
    {
        return "test2";
    }
}

public abstract class ClassB
{
    public abstract string Property1 { get; set; }

    public string Property2 { get; set; }
    
    public abstract void Function1(); 

    public virtual string Function2()
    {
        return "test2";
    }

    public abstract string Function3();

    public string Function4()
    {
        return "test4";
    }
}

public class ClassC : ClassA
{
}

public class ClassD : ClassB
{
    public override string Property1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override void Function1()
    {
        //base.Function1(); // Error CS0205: Cannot call an abstract base member: 'method'
        throw new NotImplementedException();
    }

    public override string Function3()
    {
        throw new NotImplementedException();
    }
}
```

#### Composition vs Inheritance

**Inheritance** is a hierarchical relationship between classes. Inheritance can denote a **"is - a"** relationship between classes.

**Composition** is the most commonly used relation in a class diagram. In general terms, composition allows a class to contain an object instance of another class. Composition can be denoted as being an "as a part" or a **"has a"** relationship between classes.

**Inheritance** comes with polymorphism.

**Inheritance** creates structure while **composition** creates flexibility. The derived class and base class are tightly coupled while in composition, class and its properties/fields can be loosely coupled.

**Inheritance** is static binding (compile time binding). In **inheritance**, there is an image of the base class in the derived class object, so the image of the base class is created when the derived class object is created. 

**Composition** is dynamic binding (run time binding). **Composition** allows late creation of the properties/fields until and unless they are not really required.

#### Overloading vs Overriding

**Overloading** is the ability to have multiple methods within the same class with the same name, but with different parameters. Each of these methods has their own implementation as well, meaning that they can behave differently depending on what is passed in.

**Overloading** happens during compile-time (it is static) because each of the different overloaded methods is resolved when the application is compiled.

**Overriding**, on the other hand, is the ability to redefine the implementation of a method in a class that inherits from a parent class. When a method is overridden, the name and the parameters stay the same, but the implementation that gets called depends on the type of the object that's calling it.

**Overriding** happens during runtime (it is dynamic) because the type of the calling object is not known until runtime, and therefore the method implementation that runs is determined at runtime.

**Cannot override** inherited member if it is not marked **"virtual"**, **"abstract"** or **"override"**.

#### The four pillars of Object-Oriented Programming (OOP)

##### Encapsulation: 

Encapsulation is defined as the wrapping up of data under a single unit. It is the mechanism that binds together code and the data it manipulates.
Encapsulation can be achieved by declaring all the variables in the class as private and using properties in the class to set and get the values of variables.

##### Inheritance: 

Inheritance allows a class to inherit the properties and behavior of another class, called the superclass or base class. The class that inherits from the superclass is called the subclass or derived class. Inheritance promotes code reuse, extensibility, and hierarchical organization of classes.

##### Polymorphism: 

Polymorphism means the ability of an object to take on many forms. It allows objects of different classes to be treated as objects of a common superclass. Polymorphism enables flexibility and extensibility in software design, as it allows the same code to be used for objects of different types.

##### Abstraction: 

Abstraction refers to the process of representing complex real-world entities as simplified models in code. It involves focusing on the essential characteristics of an object while hiding unnecessary details. Abstraction helps in managing complexity, enhancing code readability, and providing a clear interface for interacting with objects.

#### Late binding and early binding

#### IEnumerable vs IQueryable

#### IEnumerable<>

#### Yield

#### Equality Operator (==) vs Equals()

#### Is vs As

#### Indexers 

https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/

https://www.c-sharpcorner.com/uploadfile/puranindia/indexers-in-C-Sharp/

#### Ref vs out

#### Anonymous Types

#### Reflection 

#### LINQ 

#### Using statement

https://www.c-sharpcorner.com/UploadFile/manas1/usage-and-importance-of-using-in-C-Sharp472/

#### Operators and expressions (.? ?? :: )

https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/

#### Serialization

#### Lock and synchronization 

**Synchronization**

Synchronization is a technique that allows only one thread to access the resource for the particular time. No other thread can interrupt until the assigned thread finishes its task.

**Lock**

We can use C# lock keyword to execute program synchronously. It is used to get lock for the current thread, execute the task and then release the lock. It ensures that other thread does not interrupt the execution until the execution finish.

In this example, we are using lock. This example executes synchronously. In other words, there is no context-switching between the threads. In the output section, we can see that second thread starts working after first threads finishes its tasks.

```cs
using System;  
using System.Threading;  
class Printer  
{  
    public void PrintTable()  
    {  
        lock (this)  
        {  
            for (int i = 1; i <= 10; i++)  
            {  
                Thread.Sleep(100);  
                Console.WriteLine(i);  
            }  
        }  
    }  
}  
class Program  
{  
    public static void Main(string[] args)  
    {  
        Printer p = new Printer();  
        Thread t1 = new Thread(new ThreadStart(p.PrintTable));  
        Thread t2 = new Thread(new ThreadStart(p.PrintTable));  
        t1.Start();  
        t2.Start();  
    }  
}  

// Result using lock:
//1
//2
//3
//4
//5
//6
//7
//8
//9
//10
//1
//2
//3
//4
//5
//6
//7
//8
//9
//10


// Result NOT using lock:
//1
//1
//2
//2
//3
//3
//4
//4
//5
//5
//6
//6
//7
//7
//8
//8
//9
//9
//10
//10
```


#### What happens if the inherited interfaces have conflicting method names?

#### Can “this” be used within a static method?

We can't use 'this' in a static method because the keyword 'this' returns a reference to the current instance of the class containing it. Static methods (or any static member) do not belong to a particular instance.

#### Extension methods

Extension methods are additional methods. Extension methods allow you to inject additional methods without modifying, deriving or recompiling the original class, struct or interface. Extension methods can be added to your own custom class, .NET framework classes, or third party classes or interfaces.

```cs
public static class IntExtensions
{
    public static bool IsGreaterThan(this int i, int value)
    {
        return i > value;
    }
}
```

#### Array.CopyTo() vs Array.Clone()

#### Array vs ArrayList

#### Dispose vs finalize 

#### Delegates and multicast delegate

#### Try catch finally and exception

#### Boxing vs unboxing 

Boxing and Unboxing both are used for type conversions.

**NOTE**: Boxing and unboxing are computationally expensive processes.

The process of converting from a value type to a reference type is called boxing. Boxing is an implicit conversion. Here is an example of boxing in C#.

```cs
// Boxing  
int anum = 123;  
Object obj = anum;  
Console.WriteLine(anum);  
Console.WriteLine(obj);
```

The process of converting from a reference type to a value type is called unboxing. Here is an example of unboxing in C#.

```cs
// Unboxing  
Object obj2 = 123;  
int anum2 = (int)obj;  
Console.WriteLine(anum2);  
Console.WriteLine(obj);  
```

#### Upcasting vs  Downcasting

Upcasting is an operation that creates a base class reference from a subclass reference. ( subclass -> superclass) (i.e. Manager -> Employee)
Downcasting is an operation that creates a subclass reference from a base class reference. ( superclass -> subclass) (i.e. Employee -> Manager)

#### Array

- Arrays are most useful for creating and working with a fixed number of strongly typed objects.

```cs
// Declare a single-dimensional array of 5 integers.
int[] array1 = new int[5];

// Declare and set array element values.
int[] array2 = new int[] { 1, 3, 5, 7, 9 };

// Alternative syntax.
int[] array3 = { 1, 2, 3, 4, 5 };
int lengthOfarray3 = array3.Length;

// Declare a two dimensional array.
int[,] multiDimensionalArray1 = new int[2, 3];
```

#### Collections

- The group of objects you work with can grow and shrink dynamically

##### Generic collections

- Generic collections are faster over non-generic collections. It has to do boxing/unboxing. 
- Generic collections are type-safe (lesser runtime exceptions). This is because most of the exceptions can be found and handled during the compile time. 

**List**

```cs
var salmons = new List<string>();
// var salmons = new List<string> { "chinook", "coho", "pink" };
salmons.Add("chinook");
salmons.Add("coho");
salmons.Add("pink");

foreach (var salmon in salmons)
{
    Console.Write(salmon + " ");
}
// Output: chinook coho pink
```

**Dictionary**

- It can hold multiple elements with a key and its respective value.
- It doesn't allow duplication of the keys that are getting stored. 

```cs
var exampleDictionary = new Dictionary<string,string>();
exampleDictionary.Add("Key1","Value1");
```

**HashSet**

- It is specifically used in scenarios where duplicates need to be avoided. 
- HashSet does not store the elements in any particular order.

```cs
HashSet<int> evenNumbers = new HashSet<int>();
HashSet<int> oddNumbers = new HashSet<int>();

for (int i = 0; i < 5; i++)
{
    // Populate numbers with just even numbers.
    evenNumbers.Add(i * 2);

    // Populate oddNumbers with just odd numbers.
    oddNumbers.Add((i * 2) + 1);
}

Console.Write("evenNumbers contains {0} elements: ", evenNumbers.Count);
DisplaySet(evenNumbers);

Console.Write("oddNumbers contains {0} elements: ", oddNumbers.Count);
DisplaySet(oddNumbers);

// Create a new HashSet populated with even numbers.
HashSet<int> numbers = new HashSet<int>(evenNumbers);
Console.WriteLine("numbers UnionWith oddNumbers...");
numbers.UnionWith(oddNumbers);

Console.Write("numbers contains {0} elements: ", numbers.Count);
DisplaySet(numbers);

void DisplaySet(HashSet<int> collection)
{
    Console.Write("{");
    foreach (int i in collection)
    {
        Console.Write(" {0}", i);
    }
    Console.WriteLine(" }");
}

/* This example produces output similar to the following:
* evenNumbers contains 5 elements: { 0 2 4 6 8 }
* oddNumbers contains 5 elements: { 1 3 5 7 9 }
* numbers UnionWith oddNumbers...
* numbers contains 10 elements: { 0 2 4 6 8 1 3 5 7 9 }
*/
```

##### Non-Generic collections

- It can handle any type of object and it is not type-safe. 
- Also, users will be able to add different data types of elements in a non-generic collection.

**ArrayList**

```cs
var exampleArraylist = new ArrayList();
exampleArraylist.Add(1);
exampleArraylist.Add(true);
```

**Hashtable**

- It can store data in the form of a key-value pair.

```cs
// Create a new hash table.
//
Hashtable openWith = new Hashtable();

// Add some elements to the hash table. There are no
// duplicate keys, but some of the values are duplicates.
openWith.Add("txt", "notepad.exe");
openWith.Add("bmp", "paint.exe");
openWith.Add("dib", "paint.exe");
openWith.Add("rtf", "wordpad.exe");

// The Add method throws an exception if the new key is already in the hash table.
try
{
    openWith.Add("txt", "winword.exe");
}
catch
{
    Console.WriteLine("An element with Key = \"txt\" already exists.");
}
```

**Stack**

- Represents a simple last-in-first-out (LIFO)

```cs
using System;
using System.Collections;
public class SamplesStack  {

   public static void Main()  {

      // Creates and initializes a new Stack.
      Stack myStack = new Stack();
      myStack.Push("Hello");
      myStack.Push("World");
      myStack.Push("!");

      // Displays the properties and values of the Stack.
      Console.WriteLine( "myStack" );
      Console.WriteLine( "\tCount:    {0}", myStack.Count );
      Console.Write( "\tValues:" );
      PrintValues( myStack );
   }

   public static void PrintValues( IEnumerable myCollection )  {
      foreach ( Object obj in myCollection )
         Console.Write( "    {0}", obj );
      Console.WriteLine();
   }
}

/*
This code produces the following output.

myStack
    Count:    3
    Values:    !    World    Hello
*/
```

**Queue**

- Represents a first-in, first-out

```cs
 using System;
 using System.Collections;
 public class SamplesQueue  {

    public static void Main()  {

       // Creates and initializes a new Queue.
       Queue myQ = new Queue();
       myQ.Enqueue("Hello");
       myQ.Enqueue("World");
       myQ.Enqueue("!");

       // Displays the properties and values of the Queue.
       Console.WriteLine( "myQ" );
       Console.WriteLine( "\tCount:    {0}", myQ.Count );
       Console.Write( "\tValues:" );
       PrintValues( myQ );
    }

    public static void PrintValues( IEnumerable myCollection )  {
       foreach ( Object obj in myCollection )
          Console.Write( "    {0}", obj );
       Console.WriteLine();
    }
 }
 /*
 This code produces the following output.

 myQ
     Count:    3
     Values:    Hello    World    !
*/
```

##### Concurrent Collections

- Provides several thread-safe collection whenever multiple threads are accessing the collection concurrently. However, access to elements of a collection object through extension methods or through explicit interface implementations are not guaranteed to be thread-safe and may need to be synchronized by the caller.

-  Multiple threads can safely and efficiently add or remove items from these collections, without requiring additional synchronization in user code.

**ConcurrentQueue<T>**

- Represents a thread-safe first in-first out (FIFO) collection

```cs
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

class CQ_EnqueueDequeuePeek
{
   // Demonstrates:
   // ConcurrentQueue<T>.Enqueue()
   // ConcurrentQueue<T>.TryPeek()
   // ConcurrentQueue<T>.TryDequeue()
   static void Main ()
   {
      // Construct a ConcurrentQueue.
      ConcurrentQueue<int> cq = new ConcurrentQueue<int>();

      // Populate the queue.
      for (int i = 0; i < 10000; i++)
      {
          cq.Enqueue(i);
      }

      // Peek at the first element.
      int result;
      if (!cq.TryPeek(out result))
      {
         Console.WriteLine("CQ: TryPeek failed when it should have succeeded");
      }
      else if (result != 0)
      {
         Console.WriteLine("CQ: Expected TryPeek result of 0, got {0}", result);
      }

      int outerSum = 0;
      // An action to consume the ConcurrentQueue.
      Action action = () =>
      {
         int localSum = 0;
         int localValue;
         while (cq.TryDequeue(out localValue)) localSum += localValue;
         Interlocked.Add(ref outerSum, localSum);
      };

      // Start 4 concurrent consuming actions.
      Parallel.Invoke(action, action, action, action);

      Console.WriteLine("outerSum = {0}, should be 49995000", outerSum);
   }
}
```

**ConcurrentDictionary<TKey,TValue>**

- Represents a thread-safe collection of key/value pairs that can be accessed by multiple threads concurrently.

```cs
class CD_Ctor
{
        // Demonstrates:
        //      ConcurrentDictionary<TKey, TValue> ctor(concurrencyLevel, initialCapacity)
        //      ConcurrentDictionary<TKey, TValue>[TKey]
        static void Main()
        {
            // We know how many items we want to insert into the ConcurrentDictionary.
            // So set the initial capacity to some prime number above that, to ensure that
            // the ConcurrentDictionary does not need to be resized while initializing it.
            int NUMITEMS = 64;
            int initialCapacity = 101;

            // The higher the concurrencyLevel, the higher the theoretical number of operations
            // that could be performed concurrently on the ConcurrentDictionary.  However, global
            // operations like resizing the dictionary take longer as the concurrencyLevel rises.
            // For the purposes of this example, we'll compromise at numCores * 2.
            int numProcs = Environment.ProcessorCount;
            int concurrencyLevel = numProcs * 2;

            // Construct the dictionary with the desired concurrencyLevel and initialCapacity
            ConcurrentDictionary<int, int> cd = new ConcurrentDictionary<int, int>(concurrencyLevel, initialCapacity);

            // Initialize the dictionary
            for (int i = 0; i < NUMITEMS; i++) cd[i] = i * i;

            Console.WriteLine("The square of 23 is {0} (should be {1})", cd[23], 23 * 23);
        }
}
```

#### Memory and span

https://docs.microsoft.com/en-us/dotnet/standard/memory-and-spans/

#### SOLID

- Single Responsiblity Principle
- Open-Closed Principle
- Liskov Substitution Principle
- Interface Segregation Principle
- Dependency Inversion Principle

##### 1 - Single Responsiblity Principle

Each software module, class or method should have only one reason to change. That does not mean your class should contain only one method or property, you can have multiple members (methods or properties) as long as they are related to a single responsibility or functionality.

##### 2 - Open-Closed Principle

Software entities (classes or methods) should be open for extension but closed for modification.

We can use composition, abstract classes, interfaces, inheritance and polymorphism to achieve this.

```cs
public class Wheel {}

public class LargeWheel : Wheel {}

// Composition that doesn't follow the OCP
public class Bike 
{
    Wheel wheel = new LargeWheel();

    public void go(){
        // do something with wheel
    }
}

// Composition that follows the OCP
// if new implementations or changes of wheel occurs, this class BikeWithOCP is closed for changes
public class BikeWithOCP
{
    private Wheel wheel;

    public Wheel Wheel { 
        get { 
            return wheel; 
        }
        set { 
            wheel = value;
        } 
    }

    public void go()
    {
        // do something with wheel
    }
}
```

##### 3 - Liskov Substitution Principle

Objects of a superclass should be replaceable with objects of its subclasses without breaking the application. In other words, what we want is to have the objects of our subclasses behaving the same way as the objects of our superclass.

##### 4 - Interface Segregation Principle

No code should be forced to depend on methods it does not use. Prefer more interfaces and more specific than fewer and more generic interfaces.

##### 5 - Dependency Inversion Principle

Depend upon abstractions. Do not depend upon concrete classes. high-level components should not depend on our low-level components. Instead, they should both depend on abstractions.

```cs
public class Service // high-level component
{
    public readonly Repository _repository; // low-level component

    public string Run()
    {
        return _repository.DoSomething();
    }
}

public class Repository // concrete class/implementation
{
    public string DoSomething(){
        return "something";
    }
}
```

Service now depend on the IRepository (abstraction of the repository) and the repository depend on the IRepository because implement the interface IRepository, so both depend on abstractions

```cs
public class Service
{
    public readonly IRepository _repository;

    Service(IRepository repository) // pass actual value during runtime as a dependency
    {
        _repository = repository;
    }
    
    public string Run()
    {
        return _repository.DoSomething();
    }
}

public interface IRepository
{
    string DoSomething();
}

public class Repository : IRepository
{    
    public string DoSomething(){
        return "something";
    }
}
```

#### Performance

https://docs.microsoft.com/en-us/dotnet/framework/performance/performance-tips

### Reference:

https://docs.microsoft.com/en-us/dotnet/csharp/

https://www.c-sharpcorner.com/UploadFile/puranindia/C-Sharp-interview-questions/

https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing

https://docs.microsoft.com/en-us/dotnet/framework/performance/performance-tips

https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/

https://www.partech.nl/nl/publicaties/2020/11/collections-in-c-sharp---everything-you-need-to-know#

https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections

https://docs.microsoft.com/en-us/dotnet/standard/collections/commonly-used-collection-types

https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/

https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/statements/lock



# TODO

### try catch

https://youtu.be/LSkbnpjCEkk?si=uUxUGEvLdeciLqnR

###  Dispose and IDispose

###  async await in web API

https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices?view=aspnetcore-7.0

https://stackoverflow.com/questions/61153553/should-i-always-use-async-await-in-asp-net-core-api-controller

https://stackoverflow.com/questions/59031685/why-we-need-async-task-any-way-default-web-api-request-will-be-running-by-creati

### using for memory deallocation

https://stackoverflow.com/questions/35063768/how-the-using-keyword-improves-performance-memory-or-speed-wise

### httpclient wrong

https://www.aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/

https://andrewlock.net/exporing-the-code-behind-ihttpclientfactory/

