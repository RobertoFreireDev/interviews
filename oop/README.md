RULE: CODE ALWAYS CHANGE and you should implement code in a way that you can implement these changes without breaking what already works. You should not need to remember all the places you need to adjust either because of duplicate logic or coupling (a code that in order to work, another class or module needs to behave in a certain way)	

## OOP

### Class

Class can keep data and behaviours at the same place
Constructor is a way to initialize an object in a valid state

### Interface
	It only contains the contracts that some class(es) will implement. A class can implement multiple interfaces

### Abstract Class
	An abstract class provides a partial implementation that other classes can build on. When a class is declared as abstract, it means that the class can contain incomplete members that must be implemented in derived classes. A class can only extend one abstract class.

## The four pillars of Object-Oriented Programming (OOP) 

- Encapsulation -> protects data by not exposing outside its class
- Abstraction -> manages complexity inside its class
- Inheritance -> build on top of a base class
- Polymorphism -> one contract -> many implementations

### Encapsulation
	Encapsulation is not about making properties private and exposing them through getters and setters. This just adds an extra step for another class to manipulate its data unsafely. Example: Class Bank Account with Balance property private and SetBalance(balance) method. Instead, create method Withdraw(amount) and internally, validate amount, record transaction and deduct balance.
### Abstraction
	A class should hide its complexity for the rest of the system. Example: when you do a Send() function from an Email object, you only send simple parameters; sender, subject, body, etc. You don’t send infrastructure details like connection settings, retry logic, etc.
### Inheritance
	When you have classes that have the same data and behavior (duplicated code), it is a good sign that you probably can create another class and move those duplicated properties and methods to the base class. It should have a clear IS relationship. Example: BookProduct, FoodProduct and a base class Product. BookProduct IS a Product and FoodProduct IS a Product. The base class contains a SKU property and TaxCalculation method and each subclass can have its own specific non-shared properties and methods like Author for BookProduct and IsExpired method for FoodProduct.
### Polymorphism
	It allows different object types to be accessed through the same interface/contract but have different behaviors.

Method Overriding: A subclass can override its parent method implementation. In the previous product example, if a specific subclass can have its own specific TaxCalculation implementation.
Method Overloading: A subclass can implement the same method but with different parameters (different data types or a different number of arguments)
 
## Composition vs Inheritance
	Inheritance makes the code rigid. The implementations are defined on compile time. Structure can be good as long as it is simple and it hardly changes.
	Composition gives flexibility in the code. A class can have different behaviors just like changing in run time its properties. Flexibility is generally good but can lead to unexpected changes.

## SOLID

S — Single Responsibility Principle (SRP) - One class, one job 
A class should have only one reason to change.
O — Open/Closed Principle (OCP) - Extend code without modifying existing code
Code should be open for extension but closed for modification.
L — Liskov Substitution Principle (LSP) - Child classes must behave like their parents
Classes can have a clear IS relationship between them but you should not implement using inheritance if a child class can not be replaced where its parent class is expected. Usually because of the mismatching in the method's contract.
I — Interface Segregation Principle (ISP) - Small focused interfaces
	Don't force classes to implement methods they don't need. 
D — Dependency Inversion Principle (DIP) - Depend on abstractions, not concrete classes
High-level components should not depend on our low-level components. Instead, they should both depend on abstractions
