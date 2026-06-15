namespace after;

public static class Code
{
    public static void Run()
    {
        var tea = new Tea(true);
        var coffee = new Coffee(false);
        Console.WriteLine("Making tea...");
        tea.PrepareRecipe();
        Console.WriteLine("Making coffee...");
        coffee.PrepareRecipe();
    }
}

public abstract class Beverage {
    public void PrepareRecipe() { // Template Method
		BoilWater();
		Brew();
		PourInCup();
        if (ShouldAddCondiments()){
            AddCondiments();
        }		
	}
	public abstract void Brew(); 
	public abstract void AddCondiments();
    public void BoilWater() { Console.WriteLine("Boiling water"); } 
	public void PourInCup() { Console.WriteLine("Pouring into cup"); }
    public virtual bool ShouldAddCondiments() { return true; }
}

public class Coffee : Beverage {
    private bool _addSugarAndMilk;
	public Coffee(bool addSugarAndMilk = false) { _addSugarAndMilk = addSugarAndMilk;}
	public override void Brew() { Console.WriteLine("Dripping Coffee through filter"); } 
	public override void AddCondiments() { Console.WriteLine("Adding Sugar and Milk"); }
    public override bool ShouldAddCondiments() { return _addSugarAndMilk; }
}

public class Tea : Beverage {
    private bool _addLemon;
	public Tea(bool addLemon = false) { _addLemon = addLemon; }
	public override void Brew() { Console.WriteLine("Steeping the tea"); } 
	public override void AddCondiments() { Console.WriteLine("Adding Lemon"); }
    public override bool ShouldAddCondiments() { return _addLemon; }
}