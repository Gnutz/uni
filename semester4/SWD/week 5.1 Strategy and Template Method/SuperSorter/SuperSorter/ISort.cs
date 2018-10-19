using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSorter
{
    public interface ISort
    {
        void Sort(int[] ar);


    }

    public class Exchange
    {
       public static void exchange(int[] data, int m, int n)
        {
            int temporary;

            temporary = data[m];
            data[m] = data[n];
            data[n] = temporary;
        }
    }

    public class BubbleSort : ISort
    {
        public void Sort(int[] ar)
        {
            bubbleSort(ar);
        }

        void bubbleSort(int[] ar)
        {
            int i, j;
            int N = ar.Length;

            for (j = N - 1; j > 0; j--)
            {
                for (i = 0; i < j; i++)
                {
                    if (ar[i] > ar[i + 1])
                        Exchange.exchange(ar, i, i + 1);
                }
            }
        }
    }

















}
