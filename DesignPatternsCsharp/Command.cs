using System.Linq;
using System;
using System.Collections.Generic;

public class RunCommand : IDesingPattern
{
    public void Run()
	{
        // Criação de objetos
        dataBaseCores dB = new dataBaseCores();
        KeyValuePair<int,string> cor = new KeyValuePair<int,string>(1,"preto");
        string corbuscada = "amarelo";
        invokerDb invoker = new invokerDb();
        
        //Commandos
        command exibircores = new ExibirTodasasCores(dB);
        command mudarvalor = new Mudarvalor(dB,cor);
        command buscarcor = new BuscarCor(dB,corbuscada);

        //Setar commandos
        invoker.AddCommand(exibircores);
        invoker.AddCommand(mudarvalor);
        invoker.AddCommand(exibircores);
        invoker.AddCommand(buscarcor);
        
        //Executar lista de commandos
        invoker.ExcuteCommandsList();
    }
}
public abstract class command{

    protected dataBaseCores _db;
    protected KeyValuePair<int,string> _cor;
    protected string _corNome;
    public command(dataBaseCores db)
    {
        this._db = db;
    }
    public command(dataBaseCores db,string cor)
    {
        this._db = db;
        this._cor = new KeyValuePair<int,string>();
        this._corNome = cor;
    }
    public command(dataBaseCores db,KeyValuePair<int,string> cor)
    {
        this._db = db;
        this._cor = cor;
    }
    public abstract void Execute();
}

public class Mudarvalor : command
{
    public Mudarvalor(dataBaseCores db,KeyValuePair<int,string> cor) : base(db,cor){}

    public override void Execute()
    {
        _db.Mudarvalor(_cor.Key,_cor.Value);
    }
}
public class BuscarCor : command
{
    public BuscarCor(dataBaseCores db,string cor) : base(db,cor){}

    public override void Execute()
    {
        _db.BuscarCor(_corNome);
    }
}

public class ExibirTodasasCores : command
{
    public ExibirTodasasCores(dataBaseCores db) : base(db){}

    public override void Execute()
    {
        _db.ExibirTodasasCores();
    }
}

public class invokerDb
{
    private List<command> _commandList = new List<command>();
    public void AddCommand(command command)
    {
        this._commandList.Add(command);
    }
    public void ExcuteCommandsList()
    {
        foreach(command comando in this._commandList)
        {
            comando.Execute();
        }
        this._commandList.Clear();
    }
}
public class dataBaseCores
{
    private Dictionary<int,string> listadecores = new Dictionary<int,string>();
    
    public dataBaseCores()
    {
        listadecores.Add(1,coresEnum.verde); 
        listadecores.Add(2,coresEnum.vermelho); 
        listadecores.Add(3,coresEnum.amarelo); 
        listadecores.Add(4,coresEnum.azul); 
        listadecores.Add(5,coresEnum.rosa); 
        listadecores.Add(6,coresEnum.branco);
        listadecores.Add(7,coresEnum.preto); 
    }
    public void BuscarCorPorId(int corId)
    {   
        string cor = listadecores.FirstOrDefault(c => c.Key == corId).Value;
        if (!string.IsNullOrEmpty(cor))
        {
            Console.WriteLine("Cor {0} encontrada.",cor);
        }
    }
    public void BuscarCor(string cor)
    {
        string corNome = listadecores.FirstOrDefault(c => c.Value == cor).Value;
        int corId = listadecores.FirstOrDefault(c => c.Value == cor).Key;
        Console.WriteLine("Cor {0} encontrada no Id: {1}.",corNome,corId);
    }
    public void ExibirTodasasCores(){
        Console.WriteLine("Todas as cores no banco de dados: {0}",DateTime.Now);
        foreach(KeyValuePair<int,string> cor in listadecores)
        {
            Console.WriteLine("Cor: {0}.",cor);
        }
    }
    public void Mudarvalor(int corId, string novaCor)
    {
        int chave = listadecores.FirstOrDefault(c => c.Key == corId).Key;
        string antigaCor = listadecores.FirstOrDefault(c => c.Key == corId).Value;
        if (chave != 0 && !string.IsNullOrEmpty(novaCor))
        {
            listadecores.Remove(corId);
            listadecores.Add(corId,novaCor);
            Console.WriteLine("Cor {0} alterada para cor: {1}. Id: {2}.",
                            antigaCor,novaCor,corId);
        }
    }
}

public class coresEnum{
    public const string verde = "verde";
    public const string rosa = "rosa";
    public const string vermelho = "vermelho";
    public const string amarelo = "amarelo";
    public const string branco = "branco";
    public const string preto = "preto";
    public const string azul = "azul";
}