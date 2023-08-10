using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Organizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> integers = generateRandomIntigerList(100000);
            ShowList("Generated List", integers);

            ShiftHighestSort shiftHighestSort = new ShiftHighestSort();

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            List<int> integersSorted = shiftHighestSort.Sort(integers);
            stopwatch.Stop();
            Console.WriteLine("Shift highest sort took  : {0}", stopwatch.Elapsed);

            Console.WriteLine(IsSortedLowHigh(integersSorted) ? "List is sorted" : "List is not sorted");
            ShowList("Sorted List", integersSorted);
            Console.WriteLine();

            RotateSort rotateSort = new RotateSort();
            stopwatch.Start();
            List<int> rotateSorted = rotateSort.Sort(integers);
            stopwatch.Stop();
            Console.WriteLine("Rotate sort took         : {0}", stopwatch.Elapsed);
            ShowList("Sorted List", rotateSorted);
            Console.WriteLine(IsSortedLowHigh(rotateSorted) ? "List is sorted" : "List is not sorted");
            

        }


        /* Example of a static function */

        /// <summary>
        /// Show the list in lines of 20 numbers each
        /// </summary>
        /// <param name="label">The label for this list</param>
        /// <param name="theList">The list to show</param>
        public static void ShowList(string label, List<int> theList)
        {
            int count = theList.Count;
            if (count > 100)
            {
                count = 300; // Do not show more than 300 numbers
            }
            Console.WriteLine();
            Console.Write(label);
            Console.Write(':');
            for (int index = 0; index < count; index++)
            {
                if (index % 20 == 0) // when index can be divided by 20 exactly, start a new line
                {
                    Console.WriteLine();
                }
                Console.Write(string.Format("{0,3}, ", theList[index]));  // Show each number right aligned within 3 characters, with a comma and a space
            }
            Console.WriteLine();
        }

        public static bool IsSortedLowHigh(List<int> list)
        {

            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        public static List<int> generateRandomIntigerList(int length)
        {
            List<int> ints = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                ints.Add(rnd.Next(198) - 99);
            }
            return ints;
        }
    }

    
}
