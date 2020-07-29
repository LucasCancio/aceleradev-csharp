using Codenation.Challenge;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            State[] states = new Country().Top10StatesByArea();
            foreach (var state in states)
            {
                Console.WriteLine(state.Name);
            }
        }
    }
}
