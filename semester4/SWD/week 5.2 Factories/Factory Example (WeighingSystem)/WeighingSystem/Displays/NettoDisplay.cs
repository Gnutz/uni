using System;

namespace WeighingSystem.Displays
{
    public class NettoDisplay : IDisplay
    {
        public void ShowMass(double mass)
        {
            Console.WriteLine($"NETTO display shows {mass}");
        }
    }
}