using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Organizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input the number of elements must the list must have:");
            int listLenght = Convert.ToInt32(Console.ReadLine());
            List<int> integers = generateRandomIntigerList(listLenght);
            ShowList("Generated List", integers);
            

            ShiftHighestSort shiftHighestSort = new ShiftHighestSort();

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            List<int> integersSorted = shiftHighestSort.Sort(integers);
            stopwatch.Stop();
            
            ShowList("Sorted List", integersSorted);
            Console.WriteLine();
            Console.WriteLine(IsSortedLowHigh(integersSorted) ? "List is sorted" : "List is not sorted");
            Console.WriteLine("Shift highest sort took  : {0}", stopwatch.Elapsed);
            Console.WriteLine();


            var rotateSort = new RotateSort<int>();
            Console.WriteLine("Start rotatesort");

            stopwatch.Restart();
            stopwatch.Start();
            List<int> rotateSorted = rotateSort.Sort(integers, Comparer<int>.Default);
            stopwatch.Stop();
            Console.WriteLine(IsSortedLowHigh(rotateSorted) ? "List is sorted" : "List is not sorted");
            Console.WriteLine("Rotate sort took         : {0}", stopwatch.Elapsed);

            Console.WriteLine("------------doublesort--------------------");
            var rotateSortdouble = new RotateSort<double>();
            var doubles = generateRandomDoubleList(listLenght);
            var doublesSorted = rotateSortdouble.Sort(doubles, Comparer<double>.Default);
            ShowList("doubles:", doubles);
            ShowList("doubles sorted:", doublesSorted);



        }


        /* Example of a static function */

        /// <summary>
        /// Show the list in lines of 20 numbers each
        /// </summary>
        /// <param name="label">The label for this list</param>
        /// <param name="theList">The list to show</param>
        public static void ShowList<T>(string label, List<T> theList)
        {
            int count = theList.Count;
            if (count > 200)
            {
                count = 200; // Do not show more than 200 numbers
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


        public static List<double> generateRandomDoubleList(int length)
        {
            List<double> doubles = new List<double>();
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                doubles.Add(((double) rnd.Next(1980) - 990) / 10.0 );
            }
            return doubles;
        }
    }

    
}
