using System;					
public class RunAbstractFactory : IDesingPattern
{
    public void Run()
	{
		Console.WriteLine("loja tem promoção numero 1");
		Concretepromo1 c = new Concretepromo1();
		LojaSalgadoeVitaminapromo lojapromo1 = c.run();
		Console.WriteLine("Loja tem promoção com salgado: {0} ({2}) e vitamina: {1} ({3})",
						lojapromo1.salgado.nome,lojapromo1.vitamina.nome,
						lojapromo1.salgado.preco,lojapromo1.vitamina.preco);

		Console.WriteLine("loja tem promoção numero 2");
		Concretepromo2 c2 = new Concretepromo2();
		LojaSalgadoeVitaminapromo lojapromo2 = c2.run();
		Console.WriteLine("Loja tem promoção com salgado: {0} ({2}) e vitamina: {1} ({3})",
						lojapromo2.salgado.nome,lojapromo2.vitamina.nome,
						lojapromo2.salgado.preco,lojapromo2.vitamina.preco);
	}
}

public class LojaSalgadoeVitaminapromo
{
	public AbstractSalgado salgado;
	public AbstractVitamina vitamina;
}

public abstract class Abstractpromo
{
	public abstract LojaSalgadoeVitaminapromo run();
	public abstract void escolhersalgado();

	public abstract void escolhervitamina();
}

public class Concretepromo1 : Abstractpromo
{
	LojaSalgadoeVitaminapromo lojaSV = new LojaSalgadoeVitaminapromo();

    public override void escolhersalgado()
    {
        Pastel pastel = new Pastel("Pastel","3.50 R$");
		lojaSV.salgado = pastel;
    }

    public override void escolhervitamina()
    {
        VitaminadeBanana vitBan = new VitaminadeBanana("Vitamina de banana","1.50 R$");
		lojaSV.vitamina = vitBan;
    }

    public override LojaSalgadoeVitaminapromo run()
	{
		escolhersalgado();
		escolhervitamina();
		return lojaSV;
	}
}

public class Concretepromo2 : Abstractpromo
{
	LojaSalgadoeVitaminapromo lojaSV = new LojaSalgadoeVitaminapromo();

    public override void escolhersalgado()
    {
        PaodeQueijo paodequeijo = new PaodeQueijo("Pão de queijo","2.00 R$");
		lojaSV.salgado = paodequeijo;
    }

    public override void escolhervitamina()
    {
       VitaminadeMorango vitMoran = new VitaminadeMorango("Vitamina de morango","2.00 R$");
		lojaSV.vitamina = vitMoran;
    }

    public override LojaSalgadoeVitaminapromo run()
	{
		escolhersalgado();
		escolhervitamina();
		return lojaSV;
	}
}

public abstract class AbstractSalgado
{
	public string nome;
	public string preco;
}

public class Pastel : AbstractSalgado
{
	public Pastel(string nomedosalgado, string precodosalgado)
	{
		nome = nomedosalgado;
		preco = precodosalgado;
	}
}

public class PaodeQueijo : AbstractSalgado
{
	public PaodeQueijo(string nomedosalgado, string precodosalgado)
	{
		nome = nomedosalgado;
		preco = precodosalgado;
	}
}

public abstract class AbstractVitamina
{
	public string nome;
	public string preco;
}

public class VitaminadeBanana : AbstractVitamina
{
	public VitaminadeBanana(string nomedavitamina, string precodavitamina)
	{
		nome = nomedavitamina;
		preco = precodavitamina;
	}
}
public class VitaminadeMorango : AbstractVitamina
{
	public VitaminadeMorango(string nomedavitamina, string precodavitamina)
	{
		nome = nomedavitamina;
		preco = precodavitamina;
	}
}

public class Vitaminademamao : AbstractVitamina
{
	public Vitaminademamao(string nomedavitamina, string precodavitamina)
	{
		nome = nomedavitamina;
		preco = precodavitamina;
	}
}