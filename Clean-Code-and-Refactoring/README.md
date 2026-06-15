# Clean Code and Refactoring

### Clean Code

* Maintainability 
* Readability 
* Testability

### Meaningful Names

* **Use intention-revealing names**: The name of a variable, function or class should answer all the big questions. If a name requires a comment, then the name does not reveal its intent.

**Consider using refactoring**: Rename Method

```cs
// Avoid name of a method which doesn’t explain what the method does.

Getsnm();

// Rename method instead

GetSecondName();

```

**Consider using refactoring**: Extract Variable

```cs
// Avoid having an expression that’s hard to understand

void RenderBanner() 
{
  if ((platform.ToUpper().IndexOf("MAC") > -1) &&
       (browser.ToUpper().IndexOf("IE") > -1) &&
        wasInitialized() && resize > 0 )
  {
    // do something
  }
}

// Use place the result of the expression or its parts in separate variables that are self-explanatory.

void RenderBanner() 
{
  var isMacOs = platform.ToUpper().IndexOf("MAC") > -1;
  var isIE = browser.ToUpper().IndexOf("IE") > -1;
  var wasResized = resize > 0;

  if (isMacOs && isIE && wasInitialized() && wasResized) 
  {
    // do something
  }
}

```

**Consider using refactoring**: Split Temporary Variable

```cs
// Avoid having a local variable that’s used to store various intermediate values inside a method

var temp = 2 * (height + width);
Console.WriteLine(temp);
temp = height * width;
Console.WriteLine(temp);

// Use different variables for different values instead

var perimeter = 2 * (height + width);
Console.WriteLine(perimeter);
var area = height * width;
Console.WriteLine(area);

```

* **Make Meaningful Distinctions**: If names must be different, then they should also mean something different.

* **Use Pronounceable Names**: If you can’t pronounce it, you can’t discuss it. This matters because programming is a social activity.
Use Searchable Names: The length of a name should correspond to the size of its scope.

* **Avoid Mental Mapping**: Professionals use their powers for good and write code that others can understand.

* **Class Names**: Classes and objects should have noun or noun phrase names. A class name should **not** be a verb.

* **Method Names**: Methods should have verb or verb phrase names.

* **Pick One Word per Concept**: Pick one word for one abstract concept and stick with it. For instance, it’s confusing to have fetch , retrieve, and get as equivalent methods of different classes.

* **Don’t Pun**: Avoid using the same word for two purposes.

* **Use Problem Domain Names**: Separating solution and problem domain concepts is part of the job of a good programmer and designer. The code that has more to do with problem domain concepts should have names drawn from the problem domain.

* **Add Meaningful Context**: There are a few names which are meaningful in and of themselves-most are not. Instead, you need to place names in context for your reader by enclosing them in well-named classes, functions, or namespaces. When all else fails, then prefixing the name may be necessary as a last resort.

* **Don’t Add Gratuitous Context**: Shorter names are generally better than longer ones, so long as they are clear. Add no more context to a name than is necessary.

* **Team Rules**: A team of developers should agree upon name conventions

### Functions

* **Small**: The first rule of functions is that they should be small.

**Consider using refactoring**: Consolidate Conditional Expression

```cs
// Avoid having multiple conditionals that lead to the same result or action

double DisabilityAmount() 
{
  if (seniority < 2) 
  {
    return 0;
  }
  if (monthsDisabled > 12) 
  {
    return 0;
  }
  if (isPartTime) 
  {
    return 0;
  }
  // Compute the disability amount.
}

// Consolidate all these conditionals in a single expression instead

double DisabilityAmount()
{
  if (IsNotEligibleForDisability())
  {
    return 0;
  }
  // Compute the disability amount.
}

```

**Consider using refactoring**: Consolidate Duplicate Conditional Fragments

```cs
// Avoid having identical code in all branches of a conditional

if (IsSpecialDeal()) 
{
  total = price * 0.95;
  Send();
}
else 
{
  total = price * 0.98;
  Send();
}

// Move the code outside of the conditional instead

if (IsSpecialDeal())
{
  total = price * 0.95;
}
else
{
  total = price * 0.98;
}
Send();

```

**Consider using refactoring**: Inline Method

```cs
// Avoid having a method body that is more obvious than the method itself, so it can avoid too much methods

class PizzaDelivery 
{
  // ...
  int GetRating() 
  {
    return MoreThanFiveLateDeliveries() ? 2 : 1;
  }
  bool MoreThanFiveLateDeliveries() 
  {
    return numberOfLateDeliveries > 5;
  }
}

// Instead, replace calls to the method with the method’s content and delete the method itself 

class PizzaDelivery 
{
  // ...
  int GetRating() 
  {
    return numberOfLateDeliveries > 5 ? 2 : 1;
  }
}

```

**Consider using refactoring**: Inline Temp

```cs
// Avoid having a temporary variable that’s assigned the result of a simple expression and nothing more.

bool HasDiscount(Order order)
{
  double basePrice = order.BasePrice();
  return basePrice > 1000;
}

// Replace the references to the variable with the expression itself instead

bool HasDiscount(Order order)
{
  return order.BasePrice() > 1000;
}

```

**Consider using refactoring**: Substitute Algorithm

```cs
// Avoid repetitive algorithm 

string FoundPerson(string[] people)
{
  for (int i = 0; i < people.Length; i++) 
  {
    if (people[i].Equals("Don"))
    {
      return "Don";
    }
    if (people[i].Equals("John"))
    {
      return "John";
    }
    if (people[i].Equals("Kent"))
    {
      return "Kent";
    }
  }
  return String.Empty;
}

// Simplify algorithm instead

string FoundPerson(string[] people)
{
  List<string> candidates = new List<string>() {"Don", "John", "Kent"};
  
  for (int i = 0; i < people.Length; i++) 
  {
    if (candidates.Contains(people[i])) 
    {
      return people[i];
    }
  }
  
  return String.Empty;
}

```

* **Avoid indentations**: It makes harder to read

**Consider using refactoring**: Replace Nested Conditional with Guard Clauses

```cs
// Avoid having a group of nested conditionals. It’s hard to determine the normal flow of code execution.

public double GetPayAmount()
{
  double result;
  
  if (isDead)
  {
    result = DeadAmount();
  }
  else 
  {
    if (isSeparated)
    {
      result = SeparatedAmount();
    }
    else 
    {
      if (isRetired)
      {
        result = RetiredAmount();
      }
      else
      {
        result = NormalPayAmount();
      }
    }
  }
  
  return result;
}

// Instead, isolate all special checks and edge cases into separate clauses and place them before the main checks. 
// Ideally, you should have a “flat” list of conditionals, one after the other.

public double GetPayAmount() 
{
  if (isDead)
  {
    return DeadAmount();
  }
  if (isSeparated)
  {
    return SeparatedAmount();
  }
  if (isRetired)
  {
    return RetiredAmount();
  }
  return NormalPayAmount();
}

```

* **Avoid assignments to parameters**: This is a parameter, not a local variable.
First, if a parameter is passed via reference, then after the parameter value is changed inside the method, this value is passed to the argument that requested calling this method. Very often, this occurs accidentally and leads to unfortunate effects. Even if parameters are usually passed by value (and not by reference) in your programming language, this coding quirk may alienate those who are unaccustomed to it.
Second, multiple assignments of different values to a single parameter make it difficult for you to know what data should be contained in the parameter at any particular point in time. The problem worsens if your parameter and its contents are documented but the actual value is capable of differing from what’s expected inside the method.

**Consider using refactoring**: Remove Assignments to Parameters

```cs
// Avoid having some value assigned to a parameter inside method’s body

int Discount(int inputVal, int quantity) 
{
  if (quantity > 50) 
  {
    inputVal -= 2;
  }
  // ...
}

// Use a local variable instead of a parameter instead

int Discount(int inputVal, int quantity) 
{
  int result = inputVal;
  
  if (quantity > 50) 
  {
    result -= 2;
  }
  // ...
}

```

* **Do One Thing**: Functions should do one thing. 

**Consider using refactoring**: Replace Constructor with Factory Method

```cs
// Avoid having a complex constructor that does something more than just setting parameter values in object fields

public class Employee 
{
  public Employee(int type) 
  {
    this.type = type;    
    // Do some heavy lifting.
  }
  // ...
}

// Create a factory method and use it to replace constructor calls instead

public class Employee
{
  public static Employee Create(int type)
  {
    employee = new Employee(type);
    // Do some heavy lifting.
    return employee;
  }
  // ...
}

```

* **One Level of Abstraction per Function**: In order to make sure our functions are doing “one thing,” we need to make sure that the statements within our function are all at the same level of abstraction.
All statements of a method should belong to the same level of abstraction. If there is a statement which belongs to a lower level of abstraction, it should go to a private method which comprises statements on this level or a new class.

**Consider using refactoring**: Extract method

```ts
// Avoid having a code fragment that can be grouped together

void PrintOwing() 
{
  this.PrintBanner();

  // Print details.
  Console.WriteLine("name: " + this.name);
  Console.WriteLine("amount: " + this.GetOutstanding());
}

// Use this instead

void PrintOwing()
{
  this.PrintBanner();
  this.PrintDetails();
}

void PrintDetails()
{
  Console.WriteLine("name: " + this.name);
  Console.WriteLine("amount: " + this.GetOutstanding());
}

```

**Consider using refactoring**: Replace Method with Method Object

```cs
// A long method in which the local variables are so intertwined that you can’t apply Extract Method 

public class Account
{
    double GetGama(int inputValue, int quantity, int currentYear)
    {
        int importantValue1 = (inputValue * quantity)  + GetDelta();
        int importantValue2 = (inputValue * quantity)  + 100;
        if ((currentYear - importantValue1) > 100)
        {
            importantValue2 -= 20;
        }
        int importantValue3 = importantValue2 * 7;
        return importantValue3 - importantValue2 * importantValue1;
    }

    public int GetDelta()
    {
        return new Random().Next();
    }
}

// Instead, transform the method into a separate class so that the local variables become fields of the class. Then you can split the method into several methods within the same class.

public class Account
{
    public double GetGama(int inputValue, int quantity, int currentYear)
    {
        return new Gama(this, inputValue, quantity, currentYear)
                    .Calculate();
    }    

    public int GetDelta()
    {
        return new Random().Next();
    }
}

public class Gama
{
    private readonly Account _account;
    private int _inputValue;
    private int _quantity;
    private int _currentYear;

    public Gama(Account account,int inputValue, int quantity, int currentYear)
    {
        _account = account;
        _inputValue = inputValue;
        _quantity = quantity;
        _currentYear = currentYear;
    }

    public double Calculate()
    {
        // Apply another refactor techniques here
        int importantValue1 = (_inputValue * _quantity)  + _account.GetDelta();
        int importantValue2 = (_inputValue * _quantity)  + 100;
        if ((_currentYear - importantValue1) > 100)
        {
            importantValue2 -= 20;
        }
        int importantValue3 = importantValue2 * 7;
        return importantValue3 - importantValue2 * importantValue1;
    }
}

```

**Consider using refactoring**: Extract class

```cs
// Avoid having one class does the work of two.

class Person {
    string Name;
    string OfficeAreCode;
    string OfficeNumber;
    
    string GetTelephoneNumber(){
        return OfficeAreCode + OfficeNumber;
    }
}

// Instead, create a new class and place the fields and methods responsible for the relevant functionality in it.

class Person {
    string Name;
    TelephoneNumber telephoneNumber;

    string GetTelephoneNumber(){
        return telephoneNumber.GetTelephoneNumber();
    }
}

class TelephoneNumber {
    string OfficeAreCode;
    string OfficeNumber;

    string GetTelephoneNumber(){
        return OfficeAreCode + OfficeNumber;
    }
}

```

**Consider using refactoring**: Decompose Conditional

```cs
// Avoid having a complex conditional (if-then/else or switch).

if (date < SUMMER_START || date > SUMMER_END) 
{
  charge = quantity * winterRate + winterServiceCharge;
}
else 
{
  charge = quantity * summerRate;
}

// Instead, decompose the complicated parts of the conditional into separate methods: the condition, then and else.

if (isSummer(date))
{
  charge = SummerCharge(quantity);
}
else 
{
  charge = WinterCharge(quantity);
}

```

**Consider using refactoring**: Replace Conditional with Polymorphism

```cs
// Avoid having a conditional that performs various actions depending on object type or properties.

public class Bird 
{
  // ...
  public double GetSpeed() 
  {
    switch (type) 
    {
      case EUROPEAN:
        return GetBaseSpeed();
      case AFRICAN:
        return GetBaseSpeed() - GetLoadFactor() * numberOfCoconuts;
      case NORWEGIAN_BLUE:
        return isNailed ? 0 : GetBaseSpeed(voltage);
      default:
        throw new Exception("Should be unreachable");
    }
  }
}

// Instead, create subclasses matching the branches of the conditional. In them, create a shared method and move code from the corresponding branch of the conditional to it. Then replace the conditional with the relevant method call. The result is that the proper implementation will be attained via polymorphism depending on the object class.

public abstract class Bird 
{
  // ...
  public abstract double GetSpeed();
}

class European: Bird 
{
  public override double GetSpeed() 
  {
    return GetBaseSpeed();
  }
}
class African: Bird 
{
  public override double GetSpeed() 
  {
    return GetBaseSpeed() - GetLoadFactor() * numberOfCoconuts;
  }
}
class NorwegianBlue: Bird
{
  public override double GetSpeed() 
  {
    return isNailed ? 0 : GetBaseSpeed(voltage);
  }
}

// Somewhere in client code
speed = bird.GetSpeed();

```


* **Reading Code from Top to Bottom**: The Step-down Rule: We want the code to read like a top-down narrative. 5 We want every function to be followed by those at the next level of abstraction so that we can read the program, descending one level of abstraction at a time as we read down the list of functions.

* **Function Arguments**: The ideal number of arguments for a function is zero (niladic). Next comes one (monadic). 
There are two very common reasons to pass a single argument into a function. You may be asking a question about that argument, as in boolean fileExists(“MyFile”). Or you may be operating on that argument, transforming it into something else and returning it. For example, InputStream fileOpen(“MyFile”) transforms a file name String into an InputStream return value. A somewhat less common, but still very useful form for a single argument function, is an event. In this form there is an input argument but no output argument. The overall program is meant to interpret the function call as an event and use the argument to alter the state of the system, for example, void passwordAttemptFailedNtimes(int attempts).

**Consider using refactoring**: Replace Parameter with Explicit Methods

```cs
// Avoid having a method that is split into parts, each of which is run depending on the value of a parameter.

void SetValue(string name, int value) 
{
  if (name.Equals("height")) 
  {
    height = value;
    return;
  }
  if (name.Equals("width")) 
  {
    width = value;
    return;
  }
}

// Instead, extract the individual parts of the method into their own methods and call them instead of the original method.

void SetHeight(int arg) 
{
  height = arg;
}
void SetWidth(int arg) 
{
  width = arg;
}

```

**Consider using refactoring**: Replace Parameter with Method Call

```cs
// Avoid calling a query method and passing its results as the parameters of another method, while that method could call the query directly.
// Avoid series of cascades. If a parameter value can be calculated with the help of a method, do this inside the method itself and get rid of the parameter.

int basePrice = quantity * itemPrice;
double seasonDiscount = this.GetSeasonalDiscount();
double fees = this.GetFees();
double finalPrice = DiscountedPrice(basePrice, seasonDiscount, fees);

// Instead, remove the parameters and place a query call inside the method body.

int basePrice = quantity * itemPrice;
double finalPrice = DiscountedPrice(basePrice);
//..

double DiscountedPrice()
{
    double seasonDiscount = this.GetSeasonalDiscount();
    double fees = this.GetFees();
    //...
}
```

* **Flag Arguments**: Flag arguments are ugly. Passing a boolean into a function is a truly terrible practice. It immediately complicates the signature of the method, loudly proclaiming that this function does more than one thing.

* **Argument Objects**: When a function seems to need more than two or three arguments, it is likely that some of those arguments ought to be wrapped into a class of their own.

**Consider using refactoring**: Introduce Parameter Object

```cs
// Avoid more than one parameter in method

public double GetAmountInvoicedIn(DateTime start, DateTime end)
{
    //...
}

// Replace these parameters with an object instead

public class DateRangeParam()
{
    public DateTime start;
    public DateTime end;
}

public double GetAmountInvoicedIn(DateRangeParam date)
{
    //...
}

```

**Consider using refactoring**: Preserve Whole Object

```cs
// Avoid having several values from an object and then pass them as parameters to a method.
// It is a consequence of the refactoring Introduce Parameter Object

int low = daysTempRange.GetLow();
int high = daysTempRange.GetHigh();
bool withinPlan = plan.WithinRange(low, high);

// Instead, try passing the whole object.

bool withinPlan = plan.WithinRange(daysTempRange);

```

* **Output Arguments**: In general output arguments should be avoided. If your function must change the state of something, have it change the state of its owning object.

* **Command Query Separation**: Functions should either do something or answer something, but not both.

**Consider using refactoring**: Separate Query from Modifier

```cs
// Avoid having a method that returns a value but also changes something inside an object

GetTotalOutStandingAndSetReadyForSummaries();

// Instead, split the method into two separate methods. As you would expect, one of them should return the value and the other one modifies the object.

GetTotalOutStanding();

SetReadyForSummaries();

```

* **Prefer Exceptions to Returning Error Codes**: Returning error codes from command functions is a subtle violation of command query separation.

* **Extract Try/Catch Blocks**: Try/catch blocks are ugly in their own right. They confuse the structure of the code and mix error processing with normal processing. So it is better to extract the bodies of the try and catch blocks out into functions of their own.

* **Don’t Repeat Yourself**: Duplication may be the root of all evil in software.

* **Hide Method**: If a method isn’t used by other classes or is used only inside its own class hierarchy, make the method private or protected.

**Consider using refactoring**: Hide Method

```cs
// Avoid having a method that isn’t used by other classes or is used only inside its own class hierarchy.

public AMethod();

// Make the method private or protected instead

private AMethod();

```

### Comments

* **Comments Do Not Make Up for Bad Code**: Clear and expressive code with few comments is far superior to cluttered and complex code with lots of comments.

* **Explain Yourself in Code**: In many cases it’s simply a matter of creating a function that says the same thing as the comment you want to write.

**Consider using refactoring**: Extract method

#### GOOD COMMENTS:

* **Legal Comments**: Sometimes our corporate coding standards force us to write certain comments for legal reasons. For example, copyright and authorship statements are necessary and reasonable things to put into a comment at the start of each source file.

* **Explanation of Intent**: Sometimes a comment goes beyond just useful information about the implementation and provides the intent behind a decision.

* **Clarification**: when its part of the standard library, or in code that you cannot alter, then a helpful clarifying comment can be useful.

#### BAD COMMENTS:

* **Don’t Use a Comment When You Can Use a Function or a Variable**: Just that!

* **Commented-Out Code**: Others who see commented-out code won’t have the courage to delete it.

* **Too Much Information**: Don’t put interesting historical discussions or irrelevant descriptions of details into your comments.

* **Redundant Comments**: The comment probably takes longer to read than the code itself.

### Formatting

* **Team Rules**: A team of developers should agree upon a single formatting style.

### Objects and Data Structures

* **Data Transfer Objects**: DTOs are very useful structures, especially when communicating with databases or parsing messages from sockets, and so on.

### Error Handling

* **Use Exceptions Rather Than Return Codes**: that’s it.

**Consider using refactoring**: Replace Error Code with Exception

```cs
// Avoid having a method that returns a special value that indicates an error

int Withdraw(int amount) 
{
  if (amount > _balance) 
  {
    return -1;
  }
  else 
  {
    balance -= amount;
    return 0;
  }
}

// Throw an exception instead.

void Withdraw(int amount)
{
  if (amount > _balance) 
  {
    throw new BalanceException();
  }
  balance -= amount;
}
```


* **Write Your Try-Catch-Finally Statement First**: In a way, try blocks are like transactions. Your catch has to leave your program in a consistent state, no matter what happens in the try . For this reason it is good practice to start with a try — catch — finally statement when you are writing code that could throw exceptions.

* **Provide Context with Exceptions**: Create informative error messages and pass them along with your exceptions. Mention the operation that failed and the type of failure.

* **Don’t Return Null**: When we return null , we are essentially creating work for ourselves and foisting problems upon our callers.

* **Don’t Pass Null**: Unless you are working with an API which expects you to pass null, you should avoid passing null in your code whenever possible.

**Consider using refactoring**: Introduce Null Object

```cs
// Avoid return null object otherwise you will have many checks for null in your code.

if (customer == null) 
{
  plan = BillingPlan.Basic();
}
else 
{
  plan = customer.GetPlan();
}

// Instead of null, return a null object that exhibits the default behavior.

public sealed class NullCustomer: Customer 
{
  public override bool IsNull 
  {
    get { return true; }
  }
  
  public override Plan GetPlan() 
  {
    return new NullPlan();
  }
  // Some other NULL functionality.
}

// Replace null values with Null-object.
customer = order.customer ?? new NullCustomer();

// Use Null-object as if it's normal subclass.
plan = customer.GetPlan();

```

### Unit Tests

* **The Three Laws of TDD**: You may not write production code until you have written a failing unit test. : You may not write more of a unit test than is sufficient to fail, and not compiling is failing. : You may not write more production code than is sufficient to pass the currently failing test.

* **Keeping Tests Clean**: Having dirty tests is equivalent to having no tests.

* **Tests Enable the -ilities**: It is unit tests that keep our code flexible, maintainable, and reusable.

* **Clean Tests**: Readability.

* **Single Concept per Test**: We want to test a single concept in each test function.

* **F.I.R.S.T.**: Clean tests follow five other rules that form the above acronym: Fast, Independent, Repeatable, Self-Validating, Timely.

### Classes

* **Tight Encapsulation**: Tight encapsulation is about ensuring that **all** data attributes are on the same objects as the relevant methods, and that only data attributes which need to be public are made public via getter/setter/properties. Lose encapsulation is always a last resort.

```cs
// Avoid lose encapsulation

copter.engine_speed = 1000;
copter.start(); 
.... 
copter.height = 500 ;
copter.hover(); 

// Use this instead

copter.start_engine(1000)
.... 
copter.hover(500) 

```

* **Classes Should Be Small**: that’s it.

* **The Single Responsibility Principle**: A class or module should have one, and only one, reason to change.

* **Highly cohesive**: Cohesion is used to indicate the degree to which a class has a single, well-focused purpose. Maintaining Cohesion Results in Many Small Classes.

* **Loosely coupled**: Coupling is the degree to which one class knows about another class. Let us consider two classes class A and class B. If class A knows class B through its interface only i.e it interacts with class B through its API then class A and class B are said to be loosely coupled.

### Pending topics:

Refactor
* Dealing with Generalization
* Organizing Data
* Moving Features between Objects

### References:


Markdown Guide[^1] 
[^1]: https://gist.github.com/cuonggt/9b7d08a597b167299f0d

Single Level Of Abstraction[^2] 
[^2]: https://www.c-sharpcorner.com/article/clean-code-single-level-of-abstraction/

Clean Code Key Topics[^3] 
[^3]: https://tiagoamp.medium.com/clean-code-key-topics-2aaeb188a4bb

Refactoring Techniques[^4] 
[^4]: https://refactoring.guru/refactoring/techniques