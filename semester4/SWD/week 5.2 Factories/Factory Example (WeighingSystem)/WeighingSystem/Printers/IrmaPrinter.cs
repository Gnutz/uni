using System;

namespace WeighingSystem.Printers
{
    class IrmaPrinter : IPrinter
    {
        public void Print(double mass)
        {
            Console.WriteLine($"IRMA printer prints {mass}");
        }
    }
}