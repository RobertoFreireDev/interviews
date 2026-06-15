using System;

namespace DesignPattern
{
    class Program
    {
        static void Main()
        {
            DesignPatterns.Choose(DesignPatternsEnum.Visitor);
            Console.WriteLine("{0} design pattern finished.",DesignPatternsEnum.Visitor);
            Console.Read();
        }
    }
}