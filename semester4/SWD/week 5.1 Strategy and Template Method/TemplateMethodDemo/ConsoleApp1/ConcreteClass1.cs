namespace ConsoleApp1
{
    public class ConcreteClass1 : AbstractClass
    {
        protected override void MethodA()
        {
            System.Console.WriteLine("ConcreteClass1 MethodA called");
        }

        protected override void MethodB()
        {
            System.Console.WriteLine("ConcreteClass1 MethodB called");
        }
    }
}
