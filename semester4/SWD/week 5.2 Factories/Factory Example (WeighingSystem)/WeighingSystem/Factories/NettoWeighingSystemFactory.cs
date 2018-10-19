using WeighingSystem.Displays;
using WeighingSystem.Printers;
using WeighingSystem.Weights;

namespace WeighingSystem.Factories
{
    public class NettoWeighingSystemFactory : IWeighingSystemFactory
    {
        public IDisplay CreateDisplay()
        {
            return new NettoDisplay();
        }

        public IPrinter CreatePrinter()
        {
            return new NettoPrinter();
        }

        public IWeight CreateWeight()
        {
            return new NettoWeight();
        }
    }
}