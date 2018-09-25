using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ConcreteClass2 : AbstractClass
    {
        protected override void MethodA()
        {
            System.Console.WriteLine("ConcreteClass2 MethodA called");
        }

        protected override void MethodB()
        {
            System.Console.WriteLine("ConcreteClass2 MethodB called");
        }
    }
}
