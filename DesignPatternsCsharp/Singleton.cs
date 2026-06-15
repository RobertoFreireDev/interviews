using System;					
public class RunSingleton : IDesingPattern
{
    public void Run()
	{
		ClassSingleton a = ClassSingleton.Getinstancia;
        ClassSingleton b = new ClassSingleton();
        ClassSingleton c = ClassSingleton.Getinstancia;
	}
}

public sealed class ClassSingleton
{
	private Guid id;
	private static ClassSingleton instancia = null;
	
	public static ClassSingleton Getinstancia
	{
		get
		{
			if (instancia == null)
				{
					instancia = new ClassSingleton();
					instancia.id = Guid.NewGuid();
					Console.WriteLine("ClassSingleton foi instanciada");
				}
			return instancia;
		}
	}
}