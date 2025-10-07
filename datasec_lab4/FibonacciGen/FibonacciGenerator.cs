using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datasec_lab4.FibonacciGen
{
    public class FibonacciGenerator
    {
        private decimal[] buffer;
        private int a = default;
        private int b = default;
        private int index = default;
        private int size = default;

        public FibonacciGenerator(List<decimal> startingNumbers, int a_, int b_)
        {
            if (startingNumbers == null || startingNumbers.Count < 2)
            {
                throw new InvalidOperationException("Starting numbers must contain at least two elements.");
            }

            a = a_;
            b = b_;
            size = Math.Max(a_, b_);
            buffer = new decimal[size];

            for (int i = 0; i < startingNumbers.Count; i++)
            {
                buffer[i] = startingNumbers[i];
            }

            index = 0;
        }

        public decimal Next()
        {
            int i1 = (index + buffer.Length - a) % buffer.Length;
            int i2 = (index + buffer.Length - b) % buffer.Length;

            decimal nextNumber = default;
            if (buffer[i1] >= buffer[i2])
            {
                nextNumber = buffer[i1] - buffer[i2];
                if (nextNumber < 0)
                    nextNumber *= -1;
            }
            else
            {
                nextNumber = buffer[i1] - buffer[i2] + 1;
                if(nextNumber < 0)
                    nextNumber *= -1;
            }

            buffer[index] = nextNumber;
            index = (index + 1) % buffer.Length;

            return nextNumber;
        }
    }
}
