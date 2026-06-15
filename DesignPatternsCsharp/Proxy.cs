using System.ComponentModel;
using System;
using System.Collections.Generic;

public class RunProxy : IDesingPattern
{
    public void Run()
	{    
            Console.WriteLine("Accessing site without protection proxy: ");
            RealInternet ri = new RealInternet();
            ri.connectTo("www.badsite.com");
            ri.connectTo("www.google.com");
            ri.connectTo("www.virussite.com");
            Console.WriteLine("Accessing site with protection proxy: ");
            ProtectionProxy pp = new ProtectionProxy();
            pp.connectTo("www.badsite.com");
            pp.connectTo("www.google.com");
            pp.connectTo("www.virussite.com");
    }
}

public interface Internet 
{
    void connectTo(string url);
}

public class RealInternet : Internet 
{
    public void connectTo(string url) => Console.WriteLine("\t Connecting to " + url + "...");
}
public class ProtectionProxy : Internet
{
    private RealInternet realinternet = new RealInternet();
    private List<string> bannedsites = new List<string>{
        "www.badsite.com",
        "www.virussite.com"
    };
    public void connectTo(string url)
    {
        if(!bannedsites.Contains(url)){
            realinternet.connectTo(url);
        } else
        {
            Console.WriteLine("\t Access denied");
        }
    }
}








