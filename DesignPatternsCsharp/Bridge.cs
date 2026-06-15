public class DesignPatterns
{
    // Esta é a ponte entre a classe programa e os DesignPatterns.
    private static IDesingPattern dp = null;
    public static void Choose(string designpattern)
    {
        switch (designpattern)
        {
            case DesignPatternsEnum.Singleton:
                dp = new RunSingleton(); break;
            case DesignPatternsEnum.FactoryMethod:
                dp = new RunFactoryMethod(); break;
            case DesignPatternsEnum.AbstractFactory:
                dp = new RunAbstractFactory(); break; 
            case DesignPatternsEnum.Prototype: 
                dp = new RunPrototype(); break;
            case DesignPatternsEnum.Adapter:
                dp = new RunAdapter(); break;
            case DesignPatternsEnum.Facade:
                dp = new RunFacade(); break;
            case DesignPatternsEnum.Proxy:
                dp = new RunProxy(); break;
            case DesignPatternsEnum.Composite:
                dp = new RunComposite(); break;
            case DesignPatternsEnum.Decorator:
                dp = new RunDecorator(); break;
            case DesignPatternsEnum.Flyweight:
                dp = new RunFlyweight(); break;
            case DesignPatternsEnum.ChainofResponsibility:
                dp = new RunChainofResponsibility(); break;
            case DesignPatternsEnum.State:
                dp = new RunState(); break;  
            case DesignPatternsEnum.Command:
                dp = new RunCommand(); break;
            case DesignPatternsEnum.Visitor:
                dp = new RunVisitor(); break;
        }
        dp.Run();           
    }
}

public interface IDesingPattern {
    void Run();
}

public static class DesignPatternsEnum
{
    public const string Singleton = "Singleton";
    public const string FactoryMethod = "FactoryMethod";
    public const string AbstractFactory = "AbstractFactory";
    public const string Builder = "Builder";
    public const string Prototype = "Prototype";
    public const string Adapter = "Adapter";
    public const string Bridge = "Bridge";
    public const string Composite = "Composite";
    public const string Decorator = "Decorator";
    public const string Facade = "Facade";
    public const string Flyweight = "Flyweight";
    public const string Proxy = "Proxy";
    public const string ChainofResponsibility = "ChainofResponsibility";
    public const string Command = "Command";
    public const string Interpreter = "Interpreter";
    public const string Iterator = "Iterator";
    public const string Mediator = "Mediator";
    public const string Memento = "Memento";
    public const string Observer = "Observer";
    public const string State = "State";
    public const string Strategy = "Strategy";
    public const string TemplateMethod = "TemplateMethod";
    public const string Visitor = "Visitor";
}