using System;

namespace WeighingSystem.Displays
{
    class IrmaDisplay : IDisplay
    {
        public void ShowMass(double mass)
        {
            Console.WriteLine($"IRMA display shows {mass}");
        }
    }
}