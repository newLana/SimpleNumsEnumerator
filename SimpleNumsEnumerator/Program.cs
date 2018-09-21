using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace SimpleNumsEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                int[] array;
                
                do
                {
                    #region CustomArray
                    Console.WriteLine("Enter elements of integer array. Separates each element by whitespace.");
                    var strElements = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    array = new int[strElements.Length];
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (!int.TryParse(strElements[i], out array[i]))
                            throw new ArgumentException("Cannot convert string array to int array. There is unconvertible element.");
                    }
                    #endregion

                    #region HardCodedArray
                    //array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 23, 25, 27, 29, 31, 33 };
                    #endregion

                    var simpleNums = new SimpleNums(array);

                    foreach (var item in simpleNums)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();
                    foreach (var item in simpleNums)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();
                    foreach (var item in simpleNums)
                    {
                        Console.WriteLine(item);
                    }
                    Console.ReadKey();
                } while (true);
            }
            catch (ArgumentException e1)
            {
                Console.WriteLine(e1.Message);
            }
            Console.ReadKey();
        }
    }
}
