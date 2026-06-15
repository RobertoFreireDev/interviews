namespace after;

public static class Code
{
    public static void Run()
    {
        var chicagoPizzaStore = new ChicagoPizzaStore();

        var pizza = chicagoPizzaStore.CreatePizza("cheese");

		pizza.Prepare();
    }
}

public abstract class Pizza {
	public string Name;
	public Cheese Cheese;

	public abstract void Prepare();
}

public class CheesePizza : Pizza {
	PizzaIngredientFactory ingredientFactory;
 
	public CheesePizza(PizzaIngredientFactory ingredientFactory) {
		this.ingredientFactory = ingredientFactory;
	}
 
	public override void Prepare() {		
		Cheese = ingredientFactory.CreateCheese();
		Console.WriteLine("Pizza: " + Name + ". Cheese: " + Cheese.ToString());
	}
}


public abstract class PizzaStore {
 
	public abstract Pizza CreatePizza(string item);
 
	public Pizza OrderPizza(string type) {
		return CreatePizza(type);
	}
}

public class ChicagoPizzaStore : PizzaStore {
	public override Pizza CreatePizza(string item)
	{
		Pizza pizza = null;
		PizzaIngredientFactory ingredientFactory = new ChicagoPizzaIngredientFactory();

		if (item == "cheese") {

			pizza = new CheesePizza(ingredientFactory);
			pizza.Name = "Chicago Style Cheese Pizza";

		}

		return pizza;
	}
}

public interface Cheese {
	public string ToString();
}

public class MozzarellaCheese : Cheese {
	public override string ToString() {
		return "Shredded Mozzarella";
	}
}

public class ReggianoCheese : Cheese {
	public override string ToString() {
		return "Reggiano Cheese";
	}
}

public interface PizzaIngredientFactory {
	public Cheese CreateCheese();
}

public class ChicagoPizzaIngredientFactory : PizzaIngredientFactory {
	public Cheese CreateCheese() {
		return new MozzarellaCheese();
	}
}

public class NYPizzaIngredientFactory : PizzaIngredientFactory {
	public Cheese CreateCheese() {
		return new ReggianoCheese();
	}
}