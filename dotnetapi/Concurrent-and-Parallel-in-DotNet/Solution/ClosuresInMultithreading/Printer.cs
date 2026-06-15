using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClosuresInMultithreading
{
    public class Printer
    {
        /*
         * 
         * It prints the numbers 1 to 10.
         * 
        */
        public void Print() {
            Console.WriteLine("Printing...");
            for (int iteration = 1; iteration < 1000; iteration++)
            {
                Console.WriteLine("- Thread : {0} \t - iteration :  {1}", Thread.CurrentThread.ManagedThreadId, iteration);
            }
            Console.WriteLine();
        }
        /*
         * 
         * In theory, this program should work: you
         * expect the program to print the numbers 1 to 10. But in practice, this isn’t the case; the
         * program will print the number 10 ten times, because you’re using the same variable in
         * several lambda expressions, and these anonymous functions share the variable value.
         * 
        */
        public void PrintMultithreaded()
        {
            Console.WriteLine("Printing Multithreaded...");
            for (int iteration = 1; iteration < 1000; iteration++)
            {
                Task.Factory.StartNew(() => Console.WriteLine("- Thread : {0} \t - iteration :  {1}", Thread.CurrentThread.ManagedThreadId, iteration));
            }
        }
        /*
         * 
         * Even though the variable 'text' had a value "Test 1" at the time it was captured, it’s empty ("") at the time the code
         * 'Console.WriteLine...' is executed.The lifetime of captured variables is extended until all the closures referencing the variables 
         * become eligible for garbage collection. So, method PrintSingleValueMultithreaded was done before 'Console.WriteLine...'
         * was executed but garbage collection did not delete the captured variables 'text' yet.
         * 
        */
        public void PrintSingleValueMultithreaded()
        {
            Console.WriteLine("Printing Multithreaded...");

            string text = "Test 1";
            Task.Factory.StartNew(() => Console.WriteLine("Value : ({0})", text));
            text = "";
        }
        /*
         * 
         *  When a closure captures a mutable variable by a lambda expression, the lambda captures the
         *  reference of the variable instead of the current value of that variable.Consequently, if
         *  a task runs after the referenced value of the variable is changed, the value will be the
         *  latest in memory rather than the one at the time the variable was captured.
         *  
        */
        public void DisplayNumbersMultithreaded()
        {
            Console.WriteLine();
            int i = 5;
            Task taskOne = Task.Factory.StartNew(() => displayNumber(1,i,5));
            i = 7;
            Task taskTwo = Task.Factory.StartNew(() => displayNumber(2,i,7));
            Task.WaitAll(taskOne, taskTwo);
        }

        Action<int, int, int> displayNumber = (i, n, m) =>
        {
            Console.WriteLine("{0}° Task - Value: {1}. Expected Value was: {2}", i, n, m);
            n = 100; 
        };
        /*
         * 
         *  'Parallel.For' solves the previous issue
         *  
        */
        public void DisplayNumbersMultithreadedFixed()
        {
            Console.WriteLine();            
            int n = 5;

            Parallel.For(0, 2, (i) => {
                displayNumber(i, n, 5);
                n = 6;
            });
        }
    }
}
