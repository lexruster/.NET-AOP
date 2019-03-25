using System;

namespace Aop
{
    class Program
    {
        static void Main(string[] args)
        {
            var runner = new Runner();
            runner.RunAccount();

            Console.WriteLine("Press Any Key");
            Console.ReadKey();
        }
    }
}