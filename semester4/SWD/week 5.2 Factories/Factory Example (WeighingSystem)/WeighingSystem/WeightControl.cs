using WeighingSystem.Displays;
using WeighingSystem.Factories;
using WeighingSystem.Printers;
using WeighingSystem.Weights;

namespace WeighingSystem
{
    public class WeightControl
    {
        private readonly IDisplay _display;
        private readonly IPrinter _printer;
        private readonly IWeight _weight;

        public WeightControl(IWeighingSystemFactory factory)
        {
            _display = factory.CreateDisplay();
            _printer = factory.CreatePrinter();
            _weight = factory.CreateWeight();
        }

        // Just something that a weight might do.
        public void ItemPlacedOnWeight()
        {
            var mass = _weight.GetReading();
            _display.ShowMass(mass);
            _printer.Print(mass);
        }
    }
}