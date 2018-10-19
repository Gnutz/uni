using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractClass ac = new ConcreteClass1();
            ac.TemplateMethod();

            AbstractClass ac2 = new ConcreteClass2();
            ac2.TemplateMethod();
        }
    }
}
