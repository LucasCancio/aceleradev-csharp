using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Math
    {
        private const int CHALENGE_MAX_NUMBER = 350;
        //0, 1, 1, 2, 3, 5, 8, 13, etc…
        public List<int> Fibonacci(int maxNumber = CHALENGE_MAX_NUMBER)
        {
            int last = 0;
            int secondToLast = 1;

            List<int> fibonacciNumbers = new List<int>() { last, secondToLast };

            while ((last + secondToLast) <= maxNumber)
            {
                int sum = (last + secondToLast);
                last = secondToLast;
                secondToLast = sum;

                fibonacciNumbers.Add(secondToLast);
            }

            return fibonacciNumbers;
        }


        public bool IsFibonacci(int numberToTest)
        {
            return Fibonacci(maxNumber: numberToTest).Contains(numberToTest);
        }
    }
}
