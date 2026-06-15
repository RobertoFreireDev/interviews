using System;					
public class RunAdapter : IDesingPattern
{
  public void Run()
	{
        tomadade3pinos tomada3pinos = new tomadade3pinos();
        tomadade2pinos tomada2pinos = new tomadade2pinos();

        Itomadade3pinos adaptador_tomada3pinos = new AdaptadorTomadade3pinospara2pinos(tomada2pinos);
        Console.WriteLine("tomada 3 pinos: ");
        tomada3pinos.Conectanatomadade3pinos();
        Console.WriteLine("tomada 2 pinos: ");
        tomada2pinos.Conectanatomadade2pinos();
        Console.WriteLine("Adaptador 3 pinos para 2 pinos: ");
        adaptador_tomada3pinos.Conectanatomadade3pinos();
    }
}

public interface Itomadade3pinos
{
        void Conectanatomadade3pinos();
}
public class tomadade2pinos 
{
    public void Conectanatomadade2pinos() => Console.WriteLine("Conecta na tomada de 2 pinos.");
}

public class tomadade3pinos : Itomadade3pinos
{
    public void Conectanatomadade3pinos() => Console.WriteLine("Conecta na tomada de 3 pinos.");
}

public class AdaptadorTomadade3pinospara2pinos : Itomadade3pinos
{
    tomadade2pinos tomada2pinos;
    public AdaptadorTomadade3pinospara2pinos(tomadade2pinos tomada2pinos) => this.tomada2pinos = tomada2pinos;
    public void Conectanatomadade3pinos()
    {
        this.tomada2pinos.Conectanatomadade2pinos();
    }
}
