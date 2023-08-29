using System;
using System.Collections.Generic;

namespace Organizer
{
	public class RotateSort<T>
	{

        private List<T> array = new List<T>();
        private IComparer<T> Comparer;

        /// <summary>
        /// Sort an array using the functions below
        /// </summary>
        /// <param name="input">The unsorted array</param>
        /// <returns>The sorted array</returns>
        public List<T> Sort(List<T> input, IComparer<T> comparer)
        {
            array = new List<T>(input);
            this.Comparer = comparer;

            if (array.Count <= 1) { return array; }

            SortFunction(0, array.Count - 1);
            return array;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="low">De index within this.array to start with</param>
        /// <param name="high">De index within this.array to stop with</param>
        private void SortFunction(int low, int high)
        {
            // only sort if list has more than 2 items
            if ( high - low >= 1) {
                Partitioning(low, high);
            }

        }

        /// 
        /// Partition the array in a group 'low' digits (e.a. lower than a choosen pivot) and a group 'high' digits
        /// </summary>
        /// <param name="low">De index within this.array to start with</param>
        /// <param name="high">De index within this.array to stop with</param>
        /// <returns>The index in the array of the first of the 'high' digits</returns>
        private void Partitioning(int low, int high)
        {
            Random rnd = new Random();
            int splitPoint = rnd.Next(low, high);
            var splitValue = array[splitPoint];

            // put smaller numbers in front of the list and larger numbers at the end
            for (int i = low; i <= high; i++)
            {
                if (Comparer.Compare(array[i], array[splitPoint]) > 0)
                {
                    if (splitPoint > i)
                    {
                        MoveItemInList(i, high);
                        splitPoint -= 1;
                        i -= 1;
                    }

                }  else if (Comparer.Compare(array[i], array[splitPoint]) < 0)
                {
                    if (splitPoint < i)
                    {
                        MoveItemInList(i, low);
                        splitPoint += 1;
                    }
                }
                
            }


            // sort the front and back side of the list again
            SortFunction(low, splitPoint-1);
            SortFunction(splitPoint + 1, high);


        }

        private void MoveItemInList(int indexItemToMove,int locationIndex)
        {
            var valueToMove = array[indexItemToMove];
            array.RemoveAt(indexItemToMove);
            array.Insert(locationIndex, valueToMove);
        }

    }
}
