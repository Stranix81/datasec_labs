using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datasec_lab4.CongruentGen
{
    public class CongruentGenerator
    {
        private int numbersCount = default;

        public CongruentGenerator(int count)
        {
            numbersCount = count;
        }

        public List<long> GenerateNumbers()
        {
            List<long> numbers = new List<long>();
            long a = 1664525;
            long b = 1013904223;
            long m = 1L << 32;    //2^32
            long x0 = (long)DateTime.Now.Ticks % (1L << 32);
            int n = numbersCount;
            numbers.Add(x0);
            for (int i = 1; i < n; i++)
            {
                long xi = (a * numbers[i - 1] + b) % m;
                if(xi < 0)
                    xi *= -1;
                numbers.Add(xi);
            }
            return numbers;
        }
    }
}
