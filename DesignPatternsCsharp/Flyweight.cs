using System;
using System.Collections.Generic;

public class RunFlyweight : IDesingPattern
{
    public void Run()
	{
        carroFactory carroFact = new carroFactory();
        List<carro> listadecarros = new List<carro>();
        clientObject client = new clientObject();

        listadecarros.Add(carroFact.Getcarropelamarca(ModeloEnum.gol));
        //forma errada
        listadecarros[0].AtribuiCor(CorEnum.azul);
        //forma certa
        client.Adicionacarro(ModeloEnum.gol,CorEnum.azul);
        listadecarros.Add(carroFact.Getcarropelamarca(ModeloEnum.uno));
        //forma errada
        listadecarros[1].AtribuiCor(CorEnum.branca);
        //forma certa
        client.Adicionacarro(ModeloEnum.gol,CorEnum.branca);
        listadecarros.Add(carroFact.Getcarropelamarca(ModeloEnum.gol));
        //forma errada
        listadecarros[2].AtribuiCor(CorEnum.prata);
        //forma certa
        client.Adicionacarro(ModeloEnum.gol,CorEnum.prata);
        listadecarros.Add(carroFact.Getcarropelamarca(ModeloEnum.uno));
        //forma errada
        listadecarros[3].AtribuiCor(CorEnum.preta);
        //forma certa
        client.Adicionacarro(ModeloEnum.gol,CorEnum.preta);
    }
}

public class clientObject
{
    List<carro> listadecarros;
    carro carro;
    public clientObject()
    {
        listadecarros = new List<carro>();
    }
    public void Adicionacarro(string modelo, string cor){
        
        switch (modelo)
            {
                case ModeloEnum.gol: 
                    carro = new carroGol();
                    carro.AtribuiCor(cor);
                break;
                case ModeloEnum.uno: 
                    carro = new carroUno();
                    carro.AtribuiCor(cor); 
                break;
            }
        listadecarros.Add(carro);
    }
}

public class carroFactory
{
    private Dictionary<string, carro> listacarros = new Dictionary<string, carro>();
    public carro Getcarropelamarca(string  modelo)
    {
        carro carro = null;
        if(listacarros. ContainsKey(modelo)){
            carro = listacarros[modelo];
        } else{
            switch (modelo)
            {
                case ModeloEnum.gol: 
                    carro = new carroGol();
                break;
                case ModeloEnum.uno: 
                    carro = new carroUno(); 
                break;
            }
            listacarros.Add(modelo,carro);
        }
        return carro;
    }
}

public interface carro
{
    void AtribuiCor(string cor);
    void DescricaoCarro();
}

public class carroGol : carro
{
    private string modelo;
    public string curiosidades {get;}
    private string cor;
    public carroGol()
    {
        this.modelo = ModeloEnum.gol;
        this.curiosidades = "Gol é um automóvel da Volkswagen, desenhado no Brasil e " +
                "comercializado em vários países sob diversas designações, dentre eles México e Argentina.";
    }
    public void AtribuiCor(string cor)
    {
        this.cor = cor;
    }
    public void DescricaoCarro()
    {
        Console.WriteLine("Nome: {0}. Cor: {1}",this.modelo,this.cor);
    }
}

public class carroUno : carro
{
    private string modelo;
    public string curiosidades {get;}
    private string cor;
    public carroUno()
    {
        this.modelo = ModeloEnum.uno;
        this.curiosidades = "O Uno é um automóvel compacto fabricado pela Fiat, lançado na Europa em 1983. " +  
                        "Foi lançado no Brasil no ano seguinte, e sua nova geração (projetada no Brasil) " + 
                        "só foi lançada em 2010, direcionada aos países da América Latina. A versão antiga " + 
                        "foi produzida até dezembro de 2013 sendo vendida como Fiat Mille, nome adotado " +
                        "inicialmente em 1990, quando adotou um motor com menos de 1000 cc no Brasil.";
    }
    public void AtribuiCor(string cor)
    {
        this.cor = cor;
    }
    public void DescricaoCarro()
    {
        Console.WriteLine("Nome: {0}. Cor: {1}",this.modelo,this.cor);
    }
}

public class CorEnum
{
    public const string verde = "verde";
    public const string preta = "preta";
    public const string branca = "branca";
    public const string prata = "prata";
    public const string azul = "azul";
}

public class ModeloEnum
{
    public const string gol = "gol";
    public const string uno = "uno";

}