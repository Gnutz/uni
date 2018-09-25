using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            MethodX();
            MethodA();
            MethodB();
            MethodY();
        }

        protected abstract void MethodA();
        protected abstract void MethodB();

        private void MethodX()
        {
            System.Console.WriteLine("MethodX called");
        }

        private void MethodY()
        {
            System.Console.WriteLine("MethodY called");
        }
    }
}
