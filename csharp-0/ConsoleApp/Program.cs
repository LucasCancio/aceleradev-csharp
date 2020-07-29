using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var math = new Codenation.Challenge.Math();
            math.Fibonacci().ForEach(number => Console.WriteLine(number));
            var numberToTest = 2584;
            Console.WriteLine($"{numberToTest} é do fibonacci {math.IsFibonacci(numberToTest)}");
        }
    }
}
