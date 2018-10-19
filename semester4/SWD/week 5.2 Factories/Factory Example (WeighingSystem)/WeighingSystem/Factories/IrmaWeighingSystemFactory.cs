using WeighingSystem.Displays;
using WeighingSystem.Printers;
using WeighingSystem.Weights;

namespace WeighingSystem.Factories
{
    public class IrmaWeighingSystemFactory : IWeighingSystemFactory
    {
        public IDisplay CreateDisplay()
        {
            return new IrmaDisplay();
        }

        public IPrinter CreatePrinter()
        {
            return new IrmaPrinter();
        }

        public IWeight CreateWeight()
        {
            return new IrmaWeight();
        }
    }
}