using ClosuresInMultithreading;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            RunDisplayNumbersMultithreadedExample();
            Console.ReadKey();
        }

        public static void RunPrintMultithreadedExample() 
        {
            var printer = new Printer();

            printer.Print();
            printer.PrintMultithreaded();
        }

        public static void RunPrintSingleValueMultithreadedExample()
        {
            var printer = new Printer();

            printer.PrintSingleValueMultithreaded();
        }

        public static void RunDisplayNumbersMultithreadedExample()
        {
            var printer = new Printer();

            Console.WriteLine("------ Issue ---------");
            printer.DisplayNumbersMultithreaded();
            Console.WriteLine("------ Fixed ----------");
            printer.DisplayNumbersMultithreadedFixed();
            Console.WriteLine("----------------------");
        }
    }
}
