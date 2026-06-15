namespace before;

public static class Code
{
    public static void Run()
    {
        var style = "Chicago";
        var type = "Cheese";

        var pizza = PizzaStore.CreatePizza(style,type);

        Console.WriteLine(pizza.Name);        
    }
}

public class PizzaStore { 
	public static Pizza CreatePizza(string style, string type){
        if (style == "NYStyle"){
            if (type == "Cheese") {
                return new NYStyleCheesePizza();
            } else if (type == "Pepperoni") {
                return new NYStylePepperoniPizza();
            } else return null;
        } else if (style == "Chicago") {
        	if (type == "Cheese") {
            	return new ChicagoStyleCheesePizza();
        	} else return null;
	    } else return null;
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