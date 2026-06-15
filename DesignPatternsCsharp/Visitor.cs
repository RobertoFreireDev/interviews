using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;					
public class RunVisitor : IDesingPattern
{
  public void Run()
	{
        // Procura usuários numa lista e usa taxista padrão.
        CustomerListStructure listCustomers = new CustomerListStructure();
        Customer customerBasic = listCustomers.GetCustomer("Joao");
        Customer customerPremier = listCustomers.GetCustomer("Ana");
        RideVisitor visitor = new CabRide();

        //Adiciona os endereços
        customerBasic.enderecoAtual = "Rua Padre Assis, numero 200";
        customerPremier.enderecoAtual = "Rua Chão de giz, numero 230";

        //Usuários aceitam taxi.
        Console.WriteLine(customerBasic.accept(visitor));
        Console.WriteLine(customerPremier.accept(visitor));
    }
}

public class CustomerListStructure
{
    List<Customer> customerList = new List<Customer>();
    public CustomerListStructure()
    {
        customerList.Add(new CustomerBasic("Joao"));
        customerList.Add(new CustomerPremier("Ana"));
        customerList.Add(new CustomerBasic("Pedro"));
    }

    public Customer GetCustomer(string nome){
        Customer customer = customerList.Where(c => c.nome == nome).FirstOrDefault();
        return customer;
    }
}

public abstract class Customer
{ 
    public string nome;
    public string enderecoAtual;

    public Customer(string nome)
    {
        this.nome = nome;
    }
    public abstract string accept(RideVisitor visitor); 
}
public class CustomerBasic : Customer
{
    public CustomerBasic(string nome) : base(nome)
    {
    }

    public override string accept(RideVisitor visitor)
    {
        return visitor.visit(this);
    }
}

public class CustomerPremier : Customer
{
    public CustomerPremier(string nome) : base(nome)
    {
    }

    public override string accept(RideVisitor visitor)
    {
        return visitor.visit(this);
    }
}

public interface RideVisitor  
{ 
    string visit(CustomerPremier customer); 
    string visit(CustomerBasic customer); 
}

public class CabRide : RideVisitor
{
    public string visit(CustomerPremier customer)
    {   
        int desconto = 3;
        int calculoCorrida = 10 - desconto;
        return "Motorista está indo encontrar usuário "+customer.nome+" no endereço "+customer.enderecoAtual+".Preço: " + calculoCorrida + " R$.";
    }

    public string visit(CustomerBasic customer)
    {
        int desconto = 0;
        int calculoCorrida = 10 - desconto;
        return "Motorista está indo encontrar usuário "+customer.nome+" no endereço "+customer.enderecoAtual+".Preço: " + calculoCorrida + " R$.";
    }
}