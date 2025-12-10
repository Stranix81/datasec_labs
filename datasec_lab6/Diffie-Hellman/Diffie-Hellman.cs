using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace datasec_lab6.Diffie_Hellman
{
    public class Diffie_Hellman
    {
        private BigInteger p;
        private BigInteger g;
        private BigInteger privateKey; // a or b
        public BigInteger PublicKey { get; private set; } // A or B
        public BigInteger SharedKey { get; private set; } // s

        /// <summary>
        /// <para>
        /// Default class constructor.
        /// </para>
        /// Calculates PublicKey (A or B) based on provided p, g and privateKey (a or b).
        /// </summary>
        /// <param name="p_">Shared big prime number.</param>
        /// <param name="g_">Shared generator.</param>
        /// <param name="privateKey_">Participant's private key (a or b).</param>
        public Diffie_Hellman(BigInteger p_, BigInteger g_, BigInteger privateKey_)
        {
            if (IsPrime(p_))
                p = p_;
            else
                throw new ArgumentException("p must be a prime number.");
            
            if(IsPrimitiveRootModulo(g_, p_))
                g = g_;
            else
                throw new ArgumentException("g must be a primitive root modulo p.");
            privateKey = privateKey_;

            PublicKey = BigInteger.ModPow(g, privateKey, p);
        }

        /// <summary>
        /// Computes the shared secret key (s) based on the other participant's public key (A or B).
        /// </summary>
        /// <param name="otherPublicKey">Other participant's public key (A or B).</param>
        public void ComputeSharedKey(BigInteger otherPublicKey)
        {
            SharedKey = BigInteger.ModPow(otherPublicKey, privateKey, p);
        }

        /// <summary>
        /// Checks if a given <see cref="BigInteger"/> <paramref name="p"/> is prime using a simple trial division method.
        /// </summary>
        /// <param name="p">Number.</param>
        /// <returns><see langword="True"/> if <paramref name="p"/> is prime, else <see langword="False"/>.</returns>
        public static bool IsPrime(BigInteger p)
        {
            if (p < 2) return false;
            if (p == 2 || p == 3) return true;
            if (p % 2 == 0) return false;

            // up to sqrt(n)
            for (BigInteger i = 3; i * i <= p; i += 2)
            {
                if (p % i == 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if <paramref name="g"/> is a primitive root modulo <paramref name="p"/> using a simple method.
        /// </summary>
        /// <param name="g">Given g.</param>
        /// <param name="p">Modulo.</param>
        /// <returns><see langword="True"/> if <paramref name="g"/> is a primitive root modulo <paramref name="p"/>, else <see langword="False"/>.</returns>
        public static bool IsPrimitiveRootModulo(BigInteger g, BigInteger p)
        {
            if (g <= 1 || g >= p) return false;
            BigInteger phi = p - 1;

            // factors for phi
            var factors = new List<BigInteger>();
            BigInteger temp = phi;
            for (BigInteger i = 2; i * i <= temp; i++)
            {
                if (temp % i == 0)
                {
                    factors.Add(i);
                    while (temp % i == 0) temp /= i;
                }
            }
            if (temp > 1) factors.Add(temp);

            // check if g^(phi / q) mod p != 1 for all q
            foreach (var q in factors)
            {
                if (BigInteger.ModPow(g, phi / q, p) == 1)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Generates simple Diffie-Hellman parameters (<paramref name="p"/>, <paramref name="g"/>).
        /// </summary>
        /// <returns><see cref="Tuple"/> of <paramref name="p"/> and <paramref name="g"/> Diffie-Hellman parameters.</returns>
        public static (BigInteger p, BigInteger g) GenerateParameters()
        {
            BigInteger p, g;
            Random rnd = new();

            // generate an odd number in [1000, 10000]
            do
            {
                p = rnd.Next(1000, 10000);
                if (p % 2 == 0) p++;
            } while (!IsPrime(p));

            // find a primitive root modulo p
            for (g = 2; g < p; g++)
            {
                if (IsPrimitiveRootModulo(g, p))
                    break;
            }

            return (p, g);
        }
    }
}
