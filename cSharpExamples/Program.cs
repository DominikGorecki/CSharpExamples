using System;
using System.Collections.Generic;

namespace CSharpExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            ConstructorOrder.InitOrderDerived test = new ConstructorOrder.InitOrderDerived("-- Passed in parameter --");
            ConstructorOrder.OrderTracker.DisplayTrackStringAndClear();
            Console.ReadKey();
        }
    }
}
