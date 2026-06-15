namespace before;

public static class Code
{
    public static void Run()
    {
        Tea tea = new Tea(true);
        Coffee coffee = new Coffee(false);
        Console.WriteLine("Making tea...");
        tea.PrepareRecipe();
        Console.WriteLine("Making coffee...");
        coffee.PrepareRecipe();
    }
}

public class Coffee {
	private bool _addSugarAndMilk;
	public Coffee(bool addSugarAndMilk = false) { _addSugarAndMilk = addSugarAndMilk;}
	public void PrepareRecipe() {
		BoilWater();
		BrewCoffeeGrinds();
		PourInCup();
		if (_addSugarAndMilk){
			AddSugarAndMilk();
		}		
	} 
	public void BoilWater() { Console.WriteLine("Boiling water"); } 
	public void BrewCoffeeGrinds() { Console.WriteLine("Dripping Coffee through filter"); } 
	public void PourInCup() { Console.WriteLine("Pouring into cup"); } 
	public void AddSugarAndMilk() { Console.WriteLine("Adding Sugar and Milk"); }
}

public class Tea {
	private bool _addLemon;
	public Tea(bool addLemon = false) { _addLemon = addLemon; }
	public void PrepareRecipe() {
		BoilWater();
		SteepTeaBag();
		PourInCup();
		if (_addLemon){
			AddLemon();
		}		
	} 
	public void BoilWater() { Console.WriteLine("Boiling water"); }
	public void SteepTeaBag() { Console.WriteLine("Steeping the tea"); } 
	public void AddLemon() { Console.WriteLine("Adding Lemon"); }
	public void PourInCup() { Console.WriteLine("Pouring into cup"); }
}