using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSorter
{
    public abstract class ArrayGenerator
    {
        protected Random _rnd;
        protected int Size { get; private set; }
        protected int Max { get; private set; }
        protected int Seed { get; private set; }

        public int[] GenerateArray(int size, int max, int seed)
        {
            Seed = seed;
            Max = max;
            Size = size;

            SetSeed(Seed);
            var ar = InitArray(Size, Max);
            Sort(ar);

            return ar;
        }

        private void SetSeed(int seed)
        {
            _rnd = new Random(seed);
        }

        private int[] InitArray(int size, int max)
        {
            var ar = new int[size];
            for (int i = 0; i < size; ++i)
                ar[i] = _rnd.Next(0, max);






            return ar;
        }

        protected virtual void Sort(int[] ar)
        {

        }
    }

    public class RandomArrayGenerator : ArrayGenerator
    {

    }

    public class NearlySortedArrayGen : ArrayGenerator
    {
        private ISort _sort = new BubbleSort();

        protected override void Sort(int[] ar)
        {
            _sort.Sort(ar);
            for (int i = 0; i < 2; ++i)
                Exchange.exchange(ar, _rnd.Next(Size), _rnd.Next(Size));
        }
    }

    public class ReversedArrayGen : ArrayGenerator
    {
        private ISort _sort = new BubbleSort();

        protected override void Sort(int[] ar)
        {
            _sort.Sort(ar);
            
        }
    }


}
   