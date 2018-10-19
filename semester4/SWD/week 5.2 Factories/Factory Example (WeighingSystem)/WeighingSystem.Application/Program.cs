using WeighingSystem.Factories;

namespace WeighingSystem.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create two different weighing systems. Not that they ONLY differ in the kind of factory used.
            var nettoWeighingSystem = new WeightControl(new NettoWeighingSystemFactory());
            var irmaWeighingSystem = new WeightControl(new IrmaWeighingSystemFactory());


            nettoWeighingSystem.ItemPlacedOnWeight();
            irmaWeighingSystem.ItemPlacedOnWeight();
        }
    }

}
