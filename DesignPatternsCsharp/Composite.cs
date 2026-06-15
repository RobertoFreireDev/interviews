using System;
using System.Collections.Generic;

public class RunComposite : IDesingPattern
{
    public void Run()
	{
        // Funcionários.
        Coordenadordevendas coordVendas = new Coordenadordevendas("João");
        Vendedor vendedor = new Vendedor("Pedro");
        Vendedor vendedor2 = new Vendedor("Carla");
        Vendedor vendedor3 = new Vendedor("Antônio");
        Contador contador = new Contador("Lucas");
        Funcionariodalimpeza funcionariodalimpeza = new Funcionariodalimpeza("Augusto");
        Gerente gerente = new Gerente("Carol");

        // Cadastro de hierarquias.
        gerente.addFuncionario(coordVendas);
        gerente.addFuncionario(funcionariodalimpeza);
        gerente.addFuncionario(contador);

        coordVendas.addFuncionario(vendedor);
        coordVendas.addFuncionario(vendedor2);
        coordVendas.addFuncionario(vendedor3);

        //Mostrar hierarquia da empresa.
        gerente.FuncionarioInfo();
    }
}

public interface IFuncionario
{
    void FuncionarioInfo();
    void Addnivel(int nivelsuperior);
}

#region leafs
    public class Vendedor : IFuncionario
    {
        private string funcao = FuncaoEnum.vendedor;
        public string nome { get; set; }
        public Vendedor(string nome) => this.nome = nome;
        private int nivel;
        public void Addnivel(int nivelsuperior) => this.nivel = nivelsuperior + 1;
        public void FuncionarioInfo() 
        {
            for(int i=0; i<nivel;i++)
            {
                Console.Write("   ");
            }
                Console.WriteLine("{0} é {1}.",nome,funcao);
        }
    }
    public class Funcionariodalimpeza : IFuncionario
    {
        private string funcao = FuncaoEnum.funcionariodalimpeza;
        public string nome { get; set; }
        private int nivel;
        public void Addnivel(int nivelsuperior) => this.nivel = nivelsuperior + 1;
        public Funcionariodalimpeza(string nome) => this.nome = nome;
        public void FuncionarioInfo() 
        {
            for(int i=0; i<nivel;i++)
            {
                Console.Write("   ");
            }
                Console.WriteLine("{0} é {1}.",nome,funcao);
        }
    }
    public class Contador : IFuncionario
    {
        private string funcao = FuncaoEnum.contador;
        public string nome { get; set; }
        private int nivel;
        public void Addnivel(int nivelsuperior) => this.nivel = nivelsuperior + 1;
        public Contador(string nome) => this.nome = nome;
        public void FuncionarioInfo()
        {
            for(int i=0; i<nivel;i++)
            {
                Console.Write("   ");
            }
                Console.WriteLine("{0} é {1}.",nome,funcao);
            }
        
    }
#endregion

#region Composites
    public class Gerente : IFuncionario
    {
        private string funcao = FuncaoEnum.gerente;
        public string nome { get; set; }
        private List<IFuncionario> funcionarioLista = new List<IFuncionario>();
        public Gerente(string nome) => this.nome = nome;
        private int nivel; 
        public void Addnivel(int nivelsuperior) => this.nivel = nivelsuperior + 1;
        public void FuncionarioInfo()
        {   
            for(int i=0; i<nivel;i++)
            {
                Console.Write("   ");
            }
            Console.WriteLine("{0} é {1}.",nome,funcao);
            foreach(IFuncionario funcionario in funcionarioLista)
            {
                funcionario.FuncionarioInfo();
            }
        }
        public void addFuncionario(IFuncionario funcionario)
        {
            funcionario.Addnivel(nivel);
            funcionarioLista.Add(funcionario);
        }
        public void removeFuncionario(IFuncionario funcionario) => funcionarioLista.Remove(funcionario);
}

    public class Coordenadordevendas : IFuncionario
    {
        private string funcao = FuncaoEnum.coordenadordevendas;
        public string nome { get; set; }
        private List<IFuncionario> funcionarioLista = new List<IFuncionario>();
        public Coordenadordevendas(string nome) => this.nome = nome;
        private int nivel; 
        public void Addnivel(int nivelsuperior) => this.nivel = nivelsuperior + 1;
        public void FuncionarioInfo()
        {   
            for(int i=0; i<nivel;i++)
            {
                Console.Write("   ");
            }
            Console.WriteLine("{0} é {1}.",nome,funcao);
            foreach(IFuncionario funcionario in funcionarioLista)
            {
                funcionario.FuncionarioInfo();
            }
        }
        public void addFuncionario(IFuncionario funcionario)
        {
            funcionario.Addnivel(nivel);
            funcionarioLista.Add(funcionario);
        } 
        public void removeFuncionario(IFuncionario funcionario) => funcionarioLista.Remove(funcionario);
    }
#endregion
public class FuncaoEnum
{
    public const string vendedor = "Vendedor(a)";
    public const string coordenadordevendas = "Coordenador(a) de vendas";
    public const string contador = "Contador(a)";
    public const string gerente = "Gerente";
    public const string funcionariodalimpeza = "Funcionário(a) da limpeza";
}