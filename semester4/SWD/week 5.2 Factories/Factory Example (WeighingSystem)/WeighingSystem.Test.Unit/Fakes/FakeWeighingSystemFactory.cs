using WeighingSystem.Displays;
using WeighingSystem.Factories;
using WeighingSystem.Printers;
using WeighingSystem.Weights;

namespace WeighingSystem.Test.Unit.Fakes
{
    internal class FakeWeighingSystemFactory : IWeighingSystemFactory
    {
        // Properties are read by test suite
        public MockDisplay Display { get; }
        public MockPrinter Printer { get; }
        public StubWeight Weight { get; }

        // Create sub versions of all fabricated items
        public FakeWeighingSystemFactory()
        {
            Display = new MockDisplay();
            Printer = new MockPrinter();
            Weight = new StubWeight();
        }

        // From IWeighingSystemFactory
        public IDisplay CreateDisplay() {   return Display; }
        public IPrinter CreatePrinter() {   return Printer; }
        public IWeight CreateWeight()   {   return Weight;  }
    }

}