using System;
using System.Collections;
using System.Linq;

namespace SimpleNumsEnumerator
{
    /// <summary>
    /// 
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    class SimpleNums
    {
        private int[] innerArray { get; set; }

        public SimpleNums(int[] array)
        {
            if (array.Any(a => a <= 0))
                throw new ArgumentException("Simple numbers must be a natural. It means that array must contains only greater than 0 numbers.");
            innerArray = new int[array.Length];
            Array.Copy(array, innerArray, array.Length);
        }
        public IEnumerator GetEnumerator()
        {
            return new SimpleNumsEnumerator(innerArray);
        }
    }

    class SimpleNumsEnumerator : IEnumerator
    {
        private int[] innerArray { get; set; }
        int position = -1;

        public SimpleNumsEnumerator(int[] nums)
        {
            innerArray = nums.Where(n => IsSimple(n)).ToArray();
        }       

        object IEnumerator.Current => innerArray[position];

        public bool MoveNext() => ++position < innerArray.Length;

        public void Reset() => position = -1;

        private static bool IsSimple(int number)
        {
            int start = 2;
            while (start < number)
            {
                if (number % start++ == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
