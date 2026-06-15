using System.Net.Sockets;
using System;					
public class RunState : IDesingPattern
{
    public void Run()
	{
        Processo processo = new Processo(new inativo());
        processo.Info();
        processo.Request();
        processo.Info();
        processo.Request();

        processo = new Processo(new ativo());
        processo.Info();
        processo.Request();

        processo = new Processo(new inativo());
        processo.Info();
        processo.Request();
        processo.Info();
    }
}

public class Processo
{
    private estado _estado;
    public Processo(estado estado)
    {
        this._estado = estado;
    }
    public estado Estado
    {
        get {return _estado;}
        set { _estado = value;}
    }
    public void Request()
    {
        _estado.Handle(this);
    }
    public void Info() => Console.WriteLine("O processo está com estado {0}.", _estado.GetType().Name);
}
public abstract class estado
{
    public abstract void Handle(Processo processo);
}

public class ativo : estado
{
    public override void Handle(Processo processo)
    {
        // checa andamentos sempre que o estado está ativo
        Console.WriteLine("Checando por andamentos do processo.");
    }
}

public class inativo : estado
{
    public override void Handle(Processo processo)
    {
        Console.WriteLine("O processo está inativo. Deseja ativá-lo?");
        string texto = Console.ReadLine();
        char resposta;
        char.TryParse(texto, out resposta);
        if (resposta == 'S' || resposta == 's')
            processo.Estado = new ativo();
    }
}
