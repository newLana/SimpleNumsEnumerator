using System;
using System.Collections;
using System.Collections.Generic;
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

        public IEnumerator<int> GetEnumerator() => new SimpleNumsEnumerator(innerArray);
    }

    class SimpleNumsEnumerator : IEnumerator<int>
    {
        private int[] innerArray { get; set; }
        
        int position = -1;

        public int Current => innerArray[position];

        object IEnumerator.Current => innerArray[position];

        public SimpleNumsEnumerator(IEnumerable<int> nums)
        {
            innerArray = nums.Where(n => IsSimple(n)).ToArray();
        }       

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

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SimpleNumsEnumerator() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
