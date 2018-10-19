using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WeighingSystem;
using WeighingSystem.Printers;
using WeighingSystem.Test.Unit.Fakes;
using WeighingSystem.Weights;



namespace WeighingSystem.Test.Unit
{
    [TestFixture]
    public class WeightControlUnitTests
    {
        private WeightControl _uut;
        private FakeWeighingSystemFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new FakeWeighingSystemFactory();
            _uut = new WeightControl(_factory);
        }

        [Test]
        public void ItemPlacedOnWeight_CorrectWeightDisplayed()
        {
            _uut.ItemPlacedOnWeight();
            Assert.That(_factory.Display.LastMass, Is.EqualTo(_factory.Weight.Reading));
        }

        [Test]
        public void ItemPlacedOnWeight_CorrectWeightPrinted()
        {
            _uut.ItemPlacedOnWeight();
            Assert.That(_factory.Printer.LastMass, Is.EqualTo(_factory.Weight.Reading));
        }

    }


}
