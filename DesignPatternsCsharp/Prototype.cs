using System;					
public class RunPrototype : IDesingPattern
{    public void Run()
	{
        ClienteBasic cb = new ClienteBasic();
        cb.nome = "João";
        cb.idade = 35;
        cb.endereco.bairro = "Cantinho do céu";
        cb.endereco.cidade = "Viçosa";
        cb.endereco.logradouro = "Rua A, numero 201";

        ClienteBasic clone = (ClienteBasic) cb.ShallowCopy();
        ClienteBasic cloneDeepcopy = (ClienteBasic) cb.DeepCopy();
        
        cloneDeepcopy.nome = "Andrea";
        cloneDeepcopy.endereco.logradouro = "Rua C, numero 102";   
        
        Console.WriteLine("Cliente: {0}. Idade: {1}. Endereço: {2},{3}-{4}.",
                    cb.nome,cb.idade,cb.endereco.logradouro,cb.endereco.bairro,cb.endereco.cidade);
        Console.WriteLine("Cliente: {0}. Idade: {1}. Endereço: {2},{3}-{4}.",
                    cloneDeepcopy.nome,cloneDeepcopy.idade,cloneDeepcopy.endereco.logradouro,
                    cloneDeepcopy.endereco.bairro,cloneDeepcopy.endereco.cidade);

        clone.nome = "Pedro";
        clone.endereco.logradouro = "Rua B, numero 340";
        Console.WriteLine("Cliente: {0}. Idade: {1}. Endereço: {2},{3}-{4}.",
                    cb.nome,cb.idade,cb.endereco.logradouro,cb.endereco.bairro,cb.endereco.cidade);
        Console.WriteLine("Cliente: {0}. Idade: {1}. Endereço: {2},{3}-{4}.",
                    clone.nome,clone.idade,clone.endereco.logradouro,clone.endereco.bairro,clone.endereco.cidade);
	}
}

public class ClienteVIP : ICliente
{
    public string nome;
    public int idade;
    public EnderecoCliente endereco;

    public ClienteVIP()
    {
        endereco = new EnderecoCliente();
    }
    public ICliente ShallowCopy()
    {
        return this.MemberwiseClone() as ICliente;
    }
    public ICliente DeepCopy()
    {
        ClienteVIP deepcopy = (ClienteVIP) ShallowCopy();
        deepcopy.endereco = new EnderecoCliente();
        deepcopy.endereco.bairro = this.endereco.bairro;
        deepcopy.endereco.logradouro = this.endereco.logradouro;
        deepcopy.endereco.cidade = this.endereco.cidade;
        return deepcopy;
    }
}
public class ClienteBasic : ICliente
{
    public string nome;
    public int idade;
    public EnderecoCliente endereco;

    public ClienteBasic()
    {
        endereco = new EnderecoCliente();
    }
    public ICliente ShallowCopy()
    {
        return this.MemberwiseClone() as ICliente;
    }

    public ICliente DeepCopy()
    {
        ClienteBasic deepcopy = (ClienteBasic) ShallowCopy();
        deepcopy.endereco = new EnderecoCliente();
        deepcopy.endereco.bairro = this.endereco.bairro;
        deepcopy.endereco.logradouro = this.endereco.logradouro;
        deepcopy.endereco.cidade = this.endereco.cidade;
        return deepcopy;
    }
}

public class EnderecoCliente
{
    public string cidade;
    public string bairro;
    public string logradouro;
}

public interface ICliente{
    ICliente ShallowCopy();
    ICliente DeepCopy();
}

