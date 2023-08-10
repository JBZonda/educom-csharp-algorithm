using System;
using System.Collections.Generic;

namespace Organizer
{
	public class RotateSort
	{

        private List<int> array = new List<int>();

        /// <summary>
        /// Sort an array using the functions below
        /// </summary>
        /// <param name="input">The unsorted array</param>
        /// <returns>The sorted array</returns>
        public List<int> Sort(List<int> input)
        {
            array = new List<int>(input);

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
            if (high - low >= 1) {
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
            int splitValue = array[splitPoint];

            List<int> smaller = new List<int>();
            List<int> higher = new List<int>();

            for (int i = low; i <= high; i++)
            {
                if (array[i] > array[splitPoint])
                {
                    higher.Add(array[i]);
                } else if (i == splitPoint) {
                    splitValue = array[i];
                }
                else
                {
                    smaller.Add(array[i]);
                }
            }

            int lowHigh = 0;
            int highLow = 0;

            int listItterator = 0;

            for (int i = low; i <= high; i++)
            {
                if (i < smaller.Count + low)
                {
                    array[i] = smaller[listItterator];
                    listItterator += 1;
                } else if (i == smaller.Count + low)
                {
                    listItterator = 0;
                    lowHigh = i - 1;
                    array[i] = splitValue;
                    highLow = i + 1;
                }
                else
                {             
                    array[i] = higher[listItterator];
                    listItterator += 1;
                }
            }

            SortFunction(low, lowHigh);
            SortFunction(highLow, high);


        }
    }
}
