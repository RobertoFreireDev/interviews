namespace after;

public static class Code
{
    public static void Run()
    {
        var chicagoPizzaStore = new ChicagoPizzaStore();

        var pizza = chicagoPizzaStore.CreatePizza("Cheese");

        Console.WriteLine(pizza.Name);        
    }
}

public abstract class Pizza {
	public string Name;
}

public class NYStyleCheesePizza : Pizza {
	public NYStyleCheesePizza() { 
		Name = "NY Style Sauce and Cheese Pizza";
	}
}

public class NYStylePepperoniPizza : Pizza {
	public NYStylePepperoniPizza() {
		Name = "NY Style Pepperoni Pizza";
	}
}

public class ChicagoStyleCheesePizza : Pizza {
	public ChicagoStyleCheesePizza() { 
		Name = "Chicago Style Deep Dish Cheese Pizza";
    }
}

public abstract class PizzaStore {
 
	public abstract Pizza CreatePizza(string type); // Factory Method
 
	public Pizza OrderPizza(string type) { // An Operation
		return CreatePizza(type);
	}
}

public class ChicagoPizzaStore : PizzaStore {
	public override Pizza CreatePizza(string type) {
        if (type == "Cheese") {
            return new ChicagoStyleCheesePizza();
        } else return null;
	}
}

public class NYPizzaStore : PizzaStore {
	public override Pizza CreatePizza(string type) {
        if (type == "Cheese") {
            return new NYStyleCheesePizza();
        } else if (type == "Pepperoni") {
            return new NYStylePepperoniPizza();
        } else return null;
	}
}