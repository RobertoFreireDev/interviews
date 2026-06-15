using System;					
public class RunDecorator : IDesingPattern
{
    public void Run()
	{
        margueritta pizza = new margueritta();
        freshtomato freshtomato = new freshtomato(pizza);

        chickenfiesta pizza2 = new chickenfiesta();
        Barbeque barbeque = new Barbeque(pizza2);

        Console.WriteLine("Preços:");
        Console.WriteLine("Pizza: {0}, {1} R$. Adicional: {2}, {3} R$.",
                        pizza.nome,pizza.GetCost(),freshtomato.nome,freshtomato.GetfreshtomatoCost());
        Console.WriteLine("Pizza: {0}, {1} R$. Adicional: {2}, {3} R$.",
                        pizza2.nome, pizza2.GetCost(),barbeque.nome,barbeque.GetBarbequeCost());

        Console.WriteLine("Pedidos:");
        Console.WriteLine("Pizza: {0} com adicional: {1}. Preço total: {2} R$.",
                        pizza.nome,freshtomato.nome,freshtomato.GetCost());
        Console.WriteLine("Pizza: {0} com adicional: {1}. Preço total: {2} R$.",
                        pizza2.nome,barbeque.nome,barbeque.GetCost());
    }
}

public abstract class pizza
{   
    public string nome;
    public abstract double GetCost();
}

public class margueritta : pizza
{
    private double preco = 8.00;
    public margueritta() => nome = "marguerita";
    public override double GetCost() {return preco;}
}

public class farmhouse : pizza
{
    private double preco = 7.00;
    public farmhouse() => nome = "farm house";
    public override double GetCost() {return preco;}
}

public class chickenfiesta : pizza
{
    private double preco = 6.00;
    public chickenfiesta() => nome = "chicken fiesta";
    public override double GetCost() {return preco;}
}

public abstract class Decoratorpizza : pizza
{
}

public class freshtomato : Decoratorpizza
{
    pizza pizza;
    private double preco = 1.00;
    public freshtomato(pizza pizza)
    {
        this.pizza = pizza;
        nome = "fresh tomato";
    }
    public override double GetCost() 
    {
        return preco + pizza.GetCost();
    }
    public double GetfreshtomatoCost() 
    {
        return preco;
    }
}
public class Barbeque : Decoratorpizza
{
    pizza pizza;
    private double preco = 2.00;
    public Barbeque(pizza pizza)
    {
        this.pizza = pizza;
        nome = "Barbeque";
    }
    public override double GetCost() 
    {
        return preco + pizza.GetCost();
    }
    public double GetBarbequeCost() 
    {
        return preco;
    }
}