using WeighingSystem.Displays;
using WeighingSystem.Printers;
using WeighingSystem.Weights;

namespace WeighingSystem.Factories
{
    public interface IWeighingSystemFactory
    {
        IDisplay CreateDisplay();
        IPrinter CreatePrinter();
        IWeight CreateWeight();
    }
}