using System;
using System.Collections.Generic;
using System.Text;
using datasec_kurs.IDEA;

namespace datasec_kurs.CFB
{
    public class CFBIDEA
    {
        private readonly IDEACore core;
        private byte[] iv;  // length = 8 bytes

        public CFBIDEA(IDEACore core, byte[] iv)
        {
            if (iv == null || iv.Length != 8) throw new ArgumentException("IV must be 8 bytes");
            this.core = core;
            this.iv = new byte[8];
            Array.Copy(iv, this.iv, 8);
        }


        /// <summary>
        /// Encrypts the given plaintext using CFB mode with IDEA block cipher.
        /// </summary>
        /// <param name="plaintext">Input byte array containing the data to encrypt.</param>
        /// <returns>
        /// Encrypted byte array of the same length as the input plaintext.
        /// </returns>
        public byte[] Encrypt(byte[] plaintext)
        {
            byte[] output = new byte[plaintext.Length];
            byte[] shiftReg = new byte[8];
            Array.Copy(iv, shiftReg, 8);

            for (int i = 0; i < plaintext.Length; i += 8)
            {
                byte[] block = new byte[8];
                int len = Math.Min(8, plaintext.Length - i);
                Array.Copy(plaintext, i, block, 0, len);

#if DEBUG
                Console.WriteLine($"\n\t----- '{Encoding.ASCII.GetString(block)}' encryption -----\n");
                Console.WriteLine($"\tCurrent gamma: \n{Encoding.ASCII.GetString(shiftReg)}");
#endif 

                // encrypting IV
                byte[] enc = new byte[8];
                core.EncryptBlock(shiftReg, 0, enc, 0);

                // XOR with plaintext (gamming)
                byte[] cipherBlock = new byte[8];
                for (int j = 0; j < len; j++)
                {
                    cipherBlock[j] = (byte)(enc[j] ^ block[j]);
                }

#if DEBUG
                Console.WriteLine($"\tCurrent encrypted block: \n{Encoding.ASCII.GetString(cipherBlock)}");
#endif

                Array.Copy(cipherBlock, 0, output, i, len);


#if DEBUG
                Console.WriteLine($"\tCurrent cipher text: \n{Encoding.ASCII.GetString(output)}");
#endif

                // creating a new gamma (shifting the old data and adding an encrypted part of the text)
                int shiftBytes = len;
                if (shiftBytes < 8)
                {
                    Array.Copy(shiftReg, shiftBytes, shiftReg, 0, 8 - shiftBytes);
                    Array.Copy(cipherBlock, 0, shiftReg, 8 - shiftBytes, shiftBytes);
                }
                else
                {
                    Array.Copy(cipherBlock, 0, shiftReg, 0, 8);
                }
            }

            return output;
        }

        /// <summary>
        /// Encrypts the given ciphertext using CFB mode with IDEA block cipher.
        /// </summary>
        /// <param name="ciphertext">Input byte array containing the data to decrypt.</param>
        /// <returns>
        /// Decrypted byte array of the same length as the input ciphertext.
        /// </returns>
        public byte[] Decrypt(byte[] ciphertext)
        {
            byte[] output = new byte[ciphertext.Length];
            byte[] shiftReg = new byte[8];
            Array.Copy(iv, shiftReg, 8);

            for (int i = 0; i < ciphertext.Length; i += 8)
            {
                byte[] block = new byte[8];
                int len = Math.Min(8, ciphertext.Length - i);
                Array.Copy(ciphertext, i, block, 0, len);

#if DEBUG
                Console.WriteLine($"\n\t----- '{Encoding.ASCII.GetString(block)}' decryption -----\n");
                Console.WriteLine($"\tCurrent gamma: \n{Encoding.ASCII.GetString(shiftReg)}");
#endif 

                // encrypting IV
                byte[] enc = new byte[8];
                core.EncryptBlock(shiftReg, 0, enc, 0);

                // XOR with ciphertext (gamming)
                byte[] plainBlock = new byte[8];
                for (int j = 0; j < len; j++)
                {
                    plainBlock[j] = (byte)(enc[j] ^ block[j]);
                }

#if DEBUG
                Console.WriteLine($"\tCurrent decrypted block: \n{Encoding.ASCII.GetString(plainBlock)}");
#endif

                Array.Copy(plainBlock, 0, output, i, len);

#if DEBUG
                Console.WriteLine($"\tCurrent decrypted text: \n{Encoding.ASCII.GetString(output)}");
#endif

                // creating a new gamma (shifting the old data and adding a decrypted part of the text)
                int shiftBytes = len;
                if (shiftBytes < 8)
                {
                    Array.Copy(shiftReg, shiftBytes, shiftReg, 0, 8 - shiftBytes);
                    Array.Copy(block, 0, shiftReg, 8 - shiftBytes, shiftBytes);
                }
                else
                {
                    Array.Copy(block, 0, shiftReg, 0, 8);
                }
            }

            return output;
        }
    }
}
