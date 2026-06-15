namespace after;

public static class Code
{
    public static void Run()
    {
        var thickcrustPizza = new ThickcrustPizza();        
        Console.WriteLine(thickcrustPizza.GetDescription());
        Console.WriteLine(thickcrustPizza.Cost());

        var secondThickcrustPizza = new ThickcrustPizza();
        var thickcrustPizzaWithCheese = new Cheese(secondThickcrustPizza);

        Console.WriteLine(thickcrustPizzaWithCheese.GetDescription());
        Console.WriteLine(thickcrustPizzaWithCheese.Cost());
    }
}

public abstract class Pizza {
	protected string _description;
  
	public virtual string GetDescription()
    {
        return _description;
    }
 
	public abstract double Cost();
}

public class ThickcrustPizza : Pizza
{
	public ThickcrustPizza() {
        _description = "Thick crust pizza, with tomato sauce";		
	}

    public override double Cost()
    {
        return 7.60;
    }
}

public class ThincrustPizza : Pizza {
  
	public ThincrustPizza() {
		_description = "Thin crust pizza, with tomato sauce";
	}
  
	public override double Cost()
    {
		return 7.99;
	}
}

public abstract class ToppingDecorator : Pizza {
	protected Pizza pizza;
}

public class Olives : ToppingDecorator
{
    public Olives(Pizza pizza) {
		this.pizza = pizza;
	}

    public override double Cost()
    {
        return pizza.Cost() + 1.20;
    }

    public override string GetDescription()
    {
        return pizza.GetDescription()+ ", Olives";
    }
}

public class Cheese : ToppingDecorator
{
    public Cheese(Pizza pizza) {
		this.pizza = pizza;
	}

    public override double Cost()
    {
        return pizza.Cost() + 0.50;
    }

    public override string GetDescription()
    {
        return pizza.GetDescription() + ", Cheese";
    }
}