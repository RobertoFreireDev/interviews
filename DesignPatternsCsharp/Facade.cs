using System;					
public class RunFacade : IDesingPattern
{
    public void Run()
	{
        Facade facade = new Facade();
        Console.WriteLine("Testando celular SEM bluetooth");
        facade.celularSEMbluetooth();
        Console.WriteLine("Testando celular COM bluetooth");
        facade.celularCOMbluetooth();
    }
}

public class Facade
{
    private testebateria testebateria;
    private testebluetooth testebluetooth;
    private testequeda testequeda;

    public Facade()
    {
        this.testebateria = new testebateria();
        this.testebluetooth = new testebluetooth();
        this.testequeda = new testequeda();
    }

    public void celularCOMbluetooth()
    {
        testebateria.rodatestebateria();
        testebluetooth.rodatestebluetooth();
        testequeda.rodatestequeda();
    }

    public void celularSEMbluetooth()
    {
        testebateria.rodatestebateria();
        testequeda.rodatestequeda();
    }

}

public class testebluetooth
{
    public void rodatestebluetooth() => Console.WriteLine("\t Rodando teste bluetooth");
}

public class testebateria
{
    public void rodatestebateria() => Console.WriteLine("\t Rodando teste bateria");
}

public class testequeda
{
    public void rodatestequeda() => Console.WriteLine("\t Rodando teste queda");
}