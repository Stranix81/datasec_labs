using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datasec_kurs.IDEA
{
    using System;
    using System.Numerics;

    public class IDEACore
    {
        private const int ROUNDS = 8;
        private const int SUBKEYS = 52;
        private const uint MOD_ADD = 0x10000;        // 2^16 (65536)
        private const uint MOD_MUL = 0x10001;        // (2^16)+1 (65537)

        private ushort[] encryptSubKeys = new ushort[SUBKEYS];
        private ushort[] decryptSubKeys = new ushort[SUBKEYS];

        public void Init(byte[] key)
        {
            if (key == null || key.Length != 16) throw new ArgumentException("IDEA key must be 16 bytes (128 bits)");

            GenerateEncryptSubKeys(key);
            GenerateDecryptSubKeys();

        }

        #region WRAPPERS
        /// <summary>
        /// Encrypts a single 8-byte block using IDEA.
        /// This method is a wrapper for the <see cref="ProcessBlock(byte[], int, byte[], int, ushort[])"/>.
        /// </summary>
        /// <param name="input">Input byte array containing the data to encrypt. Must have at least 8 bytes starting from <paramref name="inOff"/>.</param>
        /// <param name="inOff">Offset in the input array where the 8-byte block starts.</param>
        /// <param name="output">Output byte array to write the encrypted block. Must have at least 8 bytes starting from <paramref name="outOff"/>.</param>
        /// <param name="outOff">Offset in the output array where the encrypted block will be written.</param>
        public void EncryptBlock(byte[] input, int inOff, byte[] output, int outOff)
        {
            ProcessBlock(input, inOff, output, outOff, encryptSubKeys);
        }

        /// <summary>
        /// Decrypts a single 8-byte block using IDEA.
        /// This method is a wrapper for the <see cref="ProcessBlock(byte[], int, byte[], int, ushort[])"/>.
        /// </summary>
        /// <param name="input">Input byte array containing the data to decrypt. Must have at least 8 bytes starting from <paramref name="inOff"/>.</param>
        /// <param name="inOff">Offset in the input array where the 8-byte block starts.</param>
        /// <param name="output">Output byte array to write the decrypted block. Must have at least 8 bytes starting from <paramref name="outOff"/>.</param>
        /// <param name="outOff">Offset in the output array where the decrypted block will be written.</param>
        public void DecryptBlock(byte[] input, int inOff, byte[] output, int outOff)
        {
            ProcessBlock(input, inOff, output, outOff, decryptSubKeys);
        }
        #endregion WRAPPERS

        /// <summary>
        /// The core method processing function for IDEA.
        /// Performs 8 rounds plus a final half-round using the provided subkeys.
        /// </summary>
        /// <param name="input">Input byte array containing the data. Must have at least 8 bytes starting from <paramref name="inOff"/>.</param>
        /// <param name="inOff">Offset in the input array where the 8-byte block starts.</param>
        /// <param name="output">Output byte array to write a new block. Must have at least 8 bytes starting from <paramref name="outOff"/>.</param>
        /// <param name="outOff">Offset in the output array where the new block will be written.</param>
        /// <param name="subKeys">Ushort array containing subkeys used in processing</param>
        /// <exception cref="ArgumentNullException">When <paramref name="input"/> or <paramref name="output"/> params are <see langword="null"/>.</exception>
        private void ProcessBlock(byte[] input, int inOff, byte[] output, int outOff, ushort[] subKeys)
        {
            if (input == null || output == null) throw new ArgumentNullException();
            // 16-bit length words (big-endian)
            ushort x1 = (ushort)((input[inOff] << 8) | (input[inOff + 1] & 0xff));  
            ushort x2 = (ushort)((input[inOff + 2] << 8) | (input[inOff + 3] & 0xff));
            ushort x3 = (ushort)((input[inOff + 4] << 8) | (input[inOff + 5] & 0xff));
            ushort x4 = (ushort)((input[inOff + 6] << 8) | (input[inOff + 7] & 0xff));

            int keyIndex = 0;
            for (int round = 0; round < ROUNDS; round++)
            {
                // round subkeys (6 for 1-8 rounds)
                ushort k1 = subKeys[keyIndex++];
                ushort k2 = subKeys[keyIndex++];
                ushort k3 = subKeys[keyIndex++];
                ushort k4 = subKeys[keyIndex++];
                ushort k5 = subKeys[keyIndex++];
                ushort k6 = subKeys[keyIndex++];

                // round transformations
                x1 = MulMod(x1, k1);
                x2 = AddMod(x2, k2);
                x3 = AddMod(x3, k3);
                x4 = MulMod(x4, k4);

                ushort t0 = (ushort)(x1 ^ x3);
                ushort t1 = (ushort)(x2 ^ x4);

                t0 = MulMod(t0, k5);
                t1 = AddMod(t1, t0);
                t1 = MulMod(t1, k6);
                t0 = AddMod(t0, t1);

                x1 = (ushort)(x1 ^ t1);
                x4 = (ushort)(x4 ^ t0);
                // exchange x2 and x3
                ushort tmp = (ushort)(x2 ^ t1);
                x2 = (ushort)(x3 ^ t0);
                x3 = tmp;
            }

            // half-round subkeys (4)
            ushort fk1 = subKeys[keyIndex++];
            ushort fk2 = subKeys[keyIndex++];
            ushort fk3 = subKeys[keyIndex++];
            ushort fk4 = subKeys[keyIndex++];

            ushort y1 = MulMod(x1, fk1);
            ushort y2 = AddMod(x3, fk2);
            ushort y3 = AddMod(x2, fk3);
            ushort y4 = MulMod(x4, fk4);

            // write output results (big-endian)
            output[outOff] = (byte)(y1 >> 8);
            output[outOff + 1] = (byte)(y1 & 0xff);
            output[outOff + 2] = (byte)(y2 >> 8);
            output[outOff + 3] = (byte)(y2 & 0xff);
            output[outOff + 4] = (byte)(y3 >> 8);
            output[outOff + 5] = (byte)(y3 & 0xff);
            output[outOff + 6] = (byte)(y4 >> 8);
            output[outOff + 7] = (byte)(y4 & 0xff);
        }

        /// <summary>
        /// Generates 52 subkeys required for IDEA encryption from the provided 16-byte key.
        /// </summary>
        /// <param name="keyBytes">Byte array containing the key data.</param>
        private void GenerateEncryptSubKeys(byte[] keyBytes)
        {
            ushort[] sub = new ushort[SUBKEYS];
            byte[] k = new byte[16];
            Array.Copy(keyBytes, 0, k, 0, 16);

            int pos = 0;
            while (pos < SUBKEYS)
            {
                // Take 8 words of 16-bits each on each iteration (big-endian)
                for (int i = 0; i < 8 && pos < SUBKEYS; i++)
                {
                    sub[pos++] = (ushort)((k[2 * i] << 8) | (k[2 * i + 1] & 0xff));
                }
                if (pos >= SUBKEYS) break;

                // Cyclic left shift of the 128-bit key by 25 bits
                k = RotateLeft128(k, 25);
            }

            encryptSubKeys = sub;
        }

        /// <summary>
        /// Generates the decryption subkeys from the encryption subkeys.
        /// </summary>
        private void GenerateDecryptSubKeys()
        {
            // According to IDEA specs:
            // D[0] = inv(EK[48]), D[1] = -EK[49], D[2] = -EK[50], D[3] = inv(EK[51]),
            // D[4] = EK[46], D[5] = EK[47], затем далее для раундов...
            ushort[] d = new ushort[SUBKEYS];

            int ei = 48;
            d[0] = MulInv(encryptSubKeys[ei++]);   // EK[48]
            d[1] = AddInv(encryptSubKeys[ei++]);   // EK[49]
            d[2] = AddInv(encryptSubKeys[ei++]);   // EK[50]
            d[3] = MulInv(encryptSubKeys[ei++]);   // EK[51]
            d[4] = encryptSubKeys[46];
            d[5] = encryptSubKeys[47];

            int di = 6;
            // 7 rounds, 6 keys each (the rounds are going backwards)
            for (int round = 1; round <= 7; round++)
            {
                ei = 48 - 6 * round;
                d[di++] = MulInv(encryptSubKeys[ei++]); // EK[j]
                d[di++] = AddInv(encryptSubKeys[ei + 1]); // EK[j+2]
                d[di++] = AddInv(encryptSubKeys[ei]); // EK[j+1]
                ei++; ei++;
                d[di++] = MulInv(encryptSubKeys[ei++]); // EK[j+3]
                d[di++] = encryptSubKeys[ei++]; // EK[j+4]
                d[di++] = encryptSubKeys[ei++]; // EK[j+5]
            }

            // final half-round
            d[48] = MulInv(encryptSubKeys[0]);
            d[49] = AddInv(encryptSubKeys[1]);
            d[50] = AddInv(encryptSubKeys[2]);
            d[51] = MulInv(encryptSubKeys[3]);

            decryptSubKeys = d;
        }

        #region low-level opeartions (add, mul, inv, rot)
        /// <summary>
        /// Addition modulo 2^16 (result is 16-bit).
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>
        /// The sum of <paramref name="a"/> and <paramref name="b"/> modulo 2^16.
        /// </returns>
        private static ushort AddMod(ushort a, ushort b)
        {
            return (ushort)((a + b) & 0xFFFF);
        }

        /// <summary>
        /// Additive inverse modulo 2^16 (result is 16-bit)
        /// </summary>
        /// <param name="x">Number</param>
        /// <returns>
        /// The additive inverse of <paramref name="x"/> modulo 2^16.
        /// </returns>
        private static ushort AddInv(ushort x)
        {
            return (ushort)((MOD_ADD - x) & 0xFFFF);
        }

        /// <summary>
        /// Multiplication modulo 65537, 0 is 65536 (result is 16-bit)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>
        /// The product of <paramref name="a"/> and <paramref name="b"/> modulo 65537.
        /// </returns>
        private static ushort MulMod(ushort a, ushort b)
        {
            uint av = (a == 0) ? 65536u : (uint)a;
            uint bv = (b == 0) ? 65536u : (uint)b;
            ulong prod = (ulong)av * (ulong)bv;
            uint res = (uint)(prod % MOD_MUL);
            return (res == 65536) ? (ushort)0 : (ushort)res;
        }

        /// <summary>
        /// Multiplicative inverse modulo 65537, 0 is 65536 (result is 16-bit)
        /// </summary>
        /// <param name="x"></param>
        /// <returns>
        /// The multiplicative inverse of <paramref name="x"/> modulo 65537.
        /// </returns>
        private static ushort MulInv(ushort x)
        {
            if (x == 0) return 0; // coz 0 is 65536, inv(65536) = 65536 = 0 

            int modulus = 65537;
            int a = x;
            int m0 = modulus;

            // extended Euclidean Algorithm
            int aa = x, bb = modulus;
            int u0 = 1, u1 = 0;
            while (bb != 0)
            {
                int q = aa / bb;
                int t = aa - q * bb; aa = bb; bb = t;
                t = u0 - q * u1; u0 = u1; u1 = t;
            }
            // aa == gcd == 1, u0 == inverse modulo 65537
            int inv = u0;
            if (inv < 0) inv += modulus;
            // to make inv in [1;65536]
            inv %= modulus;
            if (inv == 65536) return 0;
            return (ushort)inv;
        }

        /// <summary>
        /// Rotates a 128-bit (16-byte) array left by the specified number of bits (0-127) to get subkeys (52 for IDEA).
        /// </summary>
        /// <param name="k">Byte array containing the key data.</param>
        /// <param name="bits">The number of bits to rotate the  array by.</param>
        /// <returns>
        /// Array <paramref name="k"/> rotated by <paramref name="bits"/>.
        /// </returns>
        /// <exception cref="ArgumentException"> When the key length is not 16.</exception>
        private static byte[] RotateLeft128(byte[] k, int bits)
        {
            if (k.Length != 16) throw new ArgumentException("key length must be 16");
            bits &= 127;
            if (bits == 0) 
            { 
                var copy = new byte[16]; 
                Array.Copy(k, copy, 16); 
                return copy; 
            }

            // convert to BigInteger, considering byte order (coz BigInteger uses little-endian)
            byte[] little = new byte[17];
            for (int i = 0; i < 16; i++) 
                little[i] = k[15 - i]; // reverse -> little-endian
            little[16] = 0; // to ensure positive
            BigInteger val = new BigInteger(little);

            BigInteger mask = (BigInteger.One << 128) - 1;
            BigInteger rotated = ((val << bits) | (val >> (128 - bits))) & mask;    // rotate and keep only 128 bits

            // convert back to big-endian 16 bytes
            byte[] outLittle = rotated.ToByteArray(); // little-endian, may be shorter
            byte[] outBytes = new byte[16];
            // copy and reverse (to make it big-endian again)
            for (int i = 0; i < 16; i++)
            {
                outBytes[15 - i] = (i < outLittle.Length) ? outLittle[i] : (byte)0;
            }
            return outBytes;
        }
        #endregion low-level opeartions (add, mul, inv, rot)
    }

}
