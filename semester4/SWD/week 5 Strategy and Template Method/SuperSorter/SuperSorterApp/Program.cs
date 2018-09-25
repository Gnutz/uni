using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSorter;

namespace SuperSorterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayGenerator arGen = new RandomArrayGenerator();

            int[] ar = arGen.GenerateArray(10, 100, 4000);

            for (int i = 0; i < 10; ++i)
                System.Console.Write($"{ar[i]}, ");
            System.Console.WriteLine("");

            ar = arGen.GenerateArray(10, 100, 3000);

            for (int i = 0; i < 10; ++i)
                System.Console.Write($"{ar[i]}, ");
            System.Console.WriteLine("");

            arGen = new SuperSorter.NearlySortedArrayGen();

            ar = arGen.GenerateArray(10, 100, 4000);

            for (int i = 0; i < 10; ++i)
                System.Console.Write($"{ar[i]}, ");
            System.Console.WriteLine("");

            ar = arGen.GenerateArray(10, 100, 3000);

            for (int i = 0; i < 10; ++i)
                System.Console.Write($"{ar[i]}, ");
            System.Console.WriteLine("");



            System.Console.ReadKey();
        }
    }
}
