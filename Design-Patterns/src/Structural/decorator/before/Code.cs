namespace before;

public static class Code
{
    public static void Run()
    {
        var thickcrustPizza = new ThickcrustPizza();
        Console.WriteLine(thickcrustPizza.GetDescription());
        Console.WriteLine(thickcrustPizza.Cost());

        var thickcrustPizzaWithCheese = new ThickcrustPizzaWithCheese();
        Console.WriteLine(thickcrustPizzaWithCheese.GetDescription());
        Console.WriteLine(thickcrustPizzaWithCheese.Cost());
    }
}

public abstract class Pizza {
	protected string _description;
  
	public string GetDescription() {
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

public class ThickcrustPizzaWithOlives : ThickcrustPizza
{
	public ThickcrustPizzaWithOlives() {
		_description = _description + ", Olives";
	}

    public override double Cost()
    {
        return base.Cost() + 1.20;
    }
}

public class ThickcrustPizzaWithCheese : ThickcrustPizza
{
	public ThickcrustPizzaWithCheese() {
		_description = _description + ", Cheese";
	}

    public override double Cost()
    {
        return base.Cost() + 0.50;
    }
}