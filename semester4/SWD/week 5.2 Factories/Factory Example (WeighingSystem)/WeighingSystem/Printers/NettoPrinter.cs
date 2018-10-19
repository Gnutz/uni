using System;

namespace WeighingSystem.Printers
{
    class NettoPrinter : IPrinter
    {
        public void Print(double mass)
        {
            Console.WriteLine($"NETTO printer prints {mass}");
        }
    }
}