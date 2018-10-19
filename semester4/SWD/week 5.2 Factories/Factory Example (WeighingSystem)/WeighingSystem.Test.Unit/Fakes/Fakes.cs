using WeighingSystem.Displays;
using WeighingSystem.Printers;
using WeighingSystem.Weights;

namespace WeighingSystem.Test.Unit.Fakes
{
    internal class MockDisplay : IDisplay
    {
        public double LastMass { get; set; }

        public void ShowMass(double mass)
        {
            LastMass = mass;
        }
        
    }

    internal class StubWeight : IWeight
    {
        public double Reading = 2.05;
        public double GetReading()
        {
            return Reading;
        }
    }

    internal class MockPrinter : IPrinter
    {
        public double LastMass { get; set; }
        public void Print(double mass)
        {
            LastMass = mass;
        }

        
    }
}