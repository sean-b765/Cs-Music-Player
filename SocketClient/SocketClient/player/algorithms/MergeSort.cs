using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  MergeSort.cs
 *   generic merge sort algorithm which incorporates custom comparers
 * Author: Sean Boaden | 30010353
 */

namespace SocketClient.player.algorithms
{
    public class MergeSort<T> where T : IComparable
    {
        private IComparer<T>    comparer;
        private bool    ascending;

        // Default constructor
        public MergeSort() { }

        // Overloaded - sets comparer and ascending
        public MergeSort(IComparer<T> comparer, bool ascending)
        {
            Ascending = ascending;
            Comparer = comparer;
        }

        // Merge 
        void merge(T[] array, int low, int mid, int n)
        {
            int L = mid - low + 1;
            int R = n - mid;

            // temporary sub arrays
            T[] leftArr  = new T[L];
            T[] rightArr = new T[R];

            // copy array into sub arrays
            for (int i = 0; i < L; ++i)
                leftArr[i] = array[low + i];
            for (int j = 0; j < R; ++j)
                rightArr[j] = array[mid + 1 + j];

            // merge the arrays

            int left = 0, right = 0;
            int current = low;

            while (left < L && right < R)
            {
                int cmp = Comparer.Compare(leftArr[left], rightArr[right]);
                // flip the comparer if user selected descending
                if (!ascending)
                    cmp *= -1;

                if (cmp <= 0)
                {
                    // i comes before j, or is equal
                    array[current] = leftArr[left];
                    left++;
                } else
                {
                    // i comes after j
                    array[current] = rightArr[right];
                    right++;
                }
                current++;
            } // end while loop

            // copy remaining elements into array
            while (left < L)
                array[current++] = leftArr[left++];

            while (right < R)
                array[current++] = rightArr[right++];

        } // void merge()

        // Recursive sort function calls merge after sorting sub arrays
        void sort(T[] array, int low, int n)
        {
            if (Comparer != null)
            {
                if (low < n)
                {
                    int mid = (low + n) / 2;

                    // sort first half
                    sort(array, low, mid);
                    // sort second half
                    sort(array, mid + 1, n);

                    // merge the sorted halves
                    merge(array, low, mid, n);
                }
            }
            else
                return;
        }


        // public method calls recursive sort method
        public void sort(T[] array, IComparer<T> comparer, bool ascending)
        {
            Ascending = ascending;
            Comparer = comparer;
            sort(array, 0, array.Length - 1);
        }

        public IComparer<T> Comparer { get => comparer; set => comparer = value; }
        public bool Ascending { get => ascending; set => ascending = value; }

    }
}
