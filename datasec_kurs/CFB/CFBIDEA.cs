using System;
using System.Collections.Generic;
using System.Text;
using IDEA.Core;

namespace IDEA.CFB
{
    public class CFBIDEA
    {
        private readonly IDEACore core;
        private byte[] iv;  // length = 8 bytes
        private readonly int segmentBytes; // segment size in bytes (1, 2, 4, 8)

        /// <summary>
        /// Initializes a new instance of the CFBIDEA class with specified segment size.
        /// </summary>
        /// <param name="core">Initialized IDEACore instance.</param>
        /// <param name="iv">Initialization vector (8 bytes).</param>
        /// <param name="segmentBytes">Segment size in bytes (1, 2, 4, or 8). Default is 8.</param>
        /// <exception cref="ArgumentException">Thrown when IV is not 8 bytes or segment size is invalid.</exception>
        public CFBIDEA(IDEACore core, byte[] iv, int segmentBytes = 8)
        {
            if (iv == null || iv.Length != 8) throw new ArgumentException("IV must be 8 bytes");
            if (segmentBytes <= 0 || segmentBytes > 8) throw new ArgumentException("Segment must be 1, 2, 4, or 8 for IDEA");
            this.core = core;
            this.iv = new byte[8];
            this.segmentBytes = segmentBytes;
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
            if(plaintext == null) return Array.Empty<byte>();

            byte[] output = new byte[plaintext.Length];
            byte[] shiftReg = new byte[8];
            Array.Copy(iv, shiftReg, 8);

            for (int i = 0; i < plaintext.Length; i += segmentBytes)
            {
                int bytesToProcess = Math.Min(segmentBytes, plaintext.Length - i);

#if DEBUG
                Console.WriteLine($"\n\t----- 'Block {i / segmentBytes + 1}' encryption -----\n");
                Console.WriteLine($"\tSegment bytes: {bytesToProcess}");
                Console.WriteLine($"\tShift register: {BitConverter.ToString(shiftReg)}");
                Console.WriteLine($"\tShift register (ASCII): {Encoding.ASCII.GetString(shiftReg)}");
#endif 

                // encrypting IV
                byte[] gamma = new byte[8];
                core.EncryptBlock(shiftReg, 0, gamma, 0);
#if DEBUG
                Console.WriteLine($"\tCurrent gamma: {BitConverter.ToString(gamma)}");
#endif

                for(int j = 0; j < bytesToProcess; j++)
                {
                    output[i + j] = (byte)(gamma[j] ^ plaintext[i + j]);
                }

#if DEBUG
                byte[] processedBlock = new byte[bytesToProcess];
                Array.Copy(plaintext, i, processedBlock, 0, bytesToProcess);
                Console.WriteLine($"\tPlaintext block: {BitConverter.ToString(processedBlock)}");
                Console.WriteLine($"\tPlaintext block (ASCII): '{Encoding.ASCII.GetString(processedBlock)}'");

                Array.Copy(output, i, processedBlock, 0, bytesToProcess);
                Console.WriteLine($"\tCiphertext block: {BitConverter.ToString(processedBlock)}");
                Console.WriteLine($"\tTotal ciphertext so far: {BitConverter.ToString(output, 0, i + bytesToProcess)}");
                Console.WriteLine($"\tTotal ciphertext so far (ASCII): '{Encoding.ASCII.GetString(output, 0, i + bytesToProcess)}'");
#endif

                // creating a new gamma (shifting the old data and adding an encrypted part of the text)
                UpdateShiftRegister(shiftReg, output, i, bytesToProcess);
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
            if (ciphertext == null) return Array.Empty<byte>();

            byte[] output = new byte[ciphertext.Length];
            byte[] shiftReg = new byte[8];
            Array.Copy(iv, shiftReg, 8);

            for (int i = 0; i < ciphertext.Length; i += segmentBytes)
            {
                int bytesToProcess = Math.Min(segmentBytes, ciphertext.Length - i);

#if DEBUG
                Console.WriteLine($"\n\t----- Block {i / segmentBytes + 1} decryption -----");
                Console.WriteLine($"\tSegment bytes: {bytesToProcess}");
                Console.WriteLine($"\tShift register: {BitConverter.ToString(shiftReg)}");
                Console.WriteLine($"\tShift register (ASCII): '{Encoding.ASCII.GetString(shiftReg)}'");
#endif 

                // encrypting IV
                byte[] gamma = new byte[8];
                core.EncryptBlock(shiftReg, 0, gamma, 0);
#if DEBUG
                Console.WriteLine($"\tGamma: {BitConverter.ToString(gamma)}");
#endif

                // XOR with ciphertext (gamming)
                for (int j = 0; j < bytesToProcess; j++)
                {
                    output[i + j] = (byte)(gamma[j] ^ ciphertext[i + j]);
                }

#if DEBUG
                byte[] processedBlock = new byte[bytesToProcess];
                Array.Copy(ciphertext, i, processedBlock, 0, bytesToProcess);
                Console.WriteLine($"\tCiphertext block: {BitConverter.ToString(processedBlock)}");

                Array.Copy(output, i, processedBlock, 0, bytesToProcess);
                Console.WriteLine($"\tDecrypted block: {BitConverter.ToString(processedBlock)}");
                Console.WriteLine($"\tDecrypted block (ASCII): '{Encoding.ASCII.GetString(processedBlock)}'");

                Console.WriteLine($"\tTotal decrypted so far: {BitConverter.ToString(output, 0, i + bytesToProcess)}");
                Console.WriteLine($"\tTotal decrypted so far (ASCII): '{Encoding.ASCII.GetString(output, 0, i + bytesToProcess)}'");
#endif

                // creating a new gamma (shifting the old data and adding a decrypted part of the text)
                UpdateShiftRegister(shiftReg, ciphertext, i, bytesToProcess);
            }

            return output;
        }

        /// <summary>
        /// Updates the shift register by shifting left and adding new bytes.
        /// </summary>
        /// <param name="shiftReg">Shift register to update (8 bytes).</param>
        /// <param name="newData">Array containing new data to add.</param>
        /// <param name="offset">Offset in newData array.</param>
        /// <param name="bytesToAdd">Number of bytes to add from newData.</param>
        private void UpdateShiftRegister(byte[] shiftReg, byte[] newData, int offset, int bytesToAdd)
        {
            if (bytesToAdd == 8)
            {
                // Full block: replace entire shift register
                Array.Copy(newData, offset, shiftReg, 0, 8);
            }
            else
            {
                // Partial block: shift left and add new bytes to the end
                Array.Copy(shiftReg, bytesToAdd, shiftReg, 0, 8 - bytesToAdd);
                Array.Copy(newData, offset, shiftReg, 8 - bytesToAdd, bytesToAdd);
            }

#if DEBUG
            Console.WriteLine($"\tUpdated shift register: {BitConverter.ToString(shiftReg)}");
            Console.WriteLine($"\tUpdated shift register (ASCII): '{Encoding.ASCII.GetString(shiftReg)}'");
#endif
        }
    }
}
