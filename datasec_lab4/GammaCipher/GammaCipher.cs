using ClassLibrary;
using datasec_lab4.CongruentGen;
using datasec_lab4.FibonacciGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace datasec_lab4.GammaCipher
{
    public class GammaCipher
    {
        private List<decimal> congrGenNumbersDecimal;
        private List<byte> gamma;
        private List<ulong> fibNumbersUlong;
        private List<string> fibNumbersBinary;
        private byte[] msgBytes;
        private readonly int fibonacciLagA = 97;
        private readonly int fibonacciLagB = 33;

        public GammaCipher(byte[] msgBytes_)
        {
            gamma = [];
            msgBytes = msgBytes_;
         }

        public List<byte> CreateGamma()
        {
            CongruentGenerator congrGen = new CongruentGenerator(Math.Max(fibonacciLagA, fibonacciLagB));

            List<long> startNumbers = [.. congrGen.GenerateNumbers()];

            congrGenNumbersDecimal = new(startNumbers.Select(x => x / 1_000_000_000_000m).ToList());

            FibonacciGenerator fibGen = new(congrGenNumbersDecimal, fibonacciLagA, fibonacciLagB);

            gamma = new List<byte>();
            fibNumbersUlong = new List<ulong>();
            fibNumbersBinary = new List<string>();
            while (gamma.Count < msgBytes.Length)
            {
                decimal fibGenNumber = fibGen.Next();
                ulong fibGenNumberFinal = (ulong)(fibGenNumber * 1_000_000_000_000);

                fibNumbersUlong.Add(fibGenNumberFinal);

                string fibGenNumberBinary = Convert.ToString((long)fibGenNumberFinal, 2).PadLeft(40, '0');
                fibNumbersBinary.Add(fibGenNumberBinary);
                for (int i = 0; i < fibGenNumberBinary.Length; i += 8)
                {
                    string chunk = fibGenNumberBinary.Substring(i, Math.Min(8, fibGenNumberBinary.Length - i));
                    gamma.Add(Convert.ToByte(chunk, 2));
                }
            }
            return gamma;
        }

        public byte[] Encrypt(Message message)
        {
            if (gamma == null)
                throw new InvalidOperationException("Gamma has not been generated yet. Call CreateGamma() first.");

            byte[] cipher = new byte[msgBytes.Length];
            for (int i = 0; i < msgBytes.Length; i++)
            {
                cipher[i] = (byte)(msgBytes[i] ^ gamma[i]);
            }

            return cipher;
        }

        public List<char> Decrypt(byte[] encrMsgBytes)
        {
            if (gamma == null)
                throw new InvalidOperationException("Gamma has not been generated yet. Call CreateGamma() first.");


            byte[] cipher = new byte[encrMsgBytes.Length];
            for (int i = 0; i < encrMsgBytes.Length; i++)
            {
                cipher[i] = (byte)(encrMsgBytes[i] ^ gamma[i]);
            }
            string decryptedMessage = System.Text.Encoding.ASCII.GetString(cipher);

            return new List<char>(decryptedMessage);
        }

        #region getters
        public List<decimal> GetCongrGenNumbersDecimal()
        {
            if (congrGenNumbersDecimal == null)
                throw new InvalidOperationException("Gamma has not been generated yet. Call CreateGamma() first.");
            return [.. congrGenNumbersDecimal];
        }

        public List<ulong> GetFibNumbersUlong()
        {
            if (fibNumbersUlong == null)
                throw new InvalidOperationException("Gamma has not been generated yet. Call CreateGamma() first.");
            return [.. fibNumbersUlong];
        }

        public List<string> GetFibNumbersBinary()
        {
            if (fibNumbersBinary == null)
                throw new InvalidOperationException("Gamma has not been generated yet. Call CreateGamma() first.");
            return [.. fibNumbersBinary];
        }
        #endregion getters
    }
}
