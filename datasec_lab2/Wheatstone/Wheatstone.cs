using datasec_lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace datasec_lab2.Wheatstone
{
    public class Wheatstone
    {
        public List<char> Alphabet;
        public int rows = 5;
        public int cols = 7;

        public Wheatstone(string filename)
        {
            Alphabet = [];
            try
            {
                using StreamReader streamReader = new StreamReader(filename);

                string alphabetLine = streamReader.ReadLine();
                if (alphabetLine != null) Alphabet = alphabetLine.ToCharArray().ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public List<int> GenerateAlphabetPositions()
        {
            var numbers = Enumerable.Range(0, 35).ToList();
            var random = new Random();

            int count = numbers.Count;
            while (count > 1)
            {
                count--;
                int k = random.Next(count + 1);
                (numbers[k], numbers[count]) = (numbers[count], numbers[k]);
            }

            return numbers;
        }

        public char[,] FillTable(char[,] table, List<int> alphabet)
        {
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    index = alphabet[i * cols + j];
                    table[i, j] = Alphabet[index];
                }
            }
            return table;
        }

        public List<char> Encrypt(Message message, List<int> firstKey, List<int> secondKey)
        {
            char[,] firstTable = new char[rows, cols];
            char[,] secondTable = new char[rows, cols];

            Console.WriteLine("\n\nFirst key:");
            foreach(int c in firstKey)
            {
                Console.Write(c + ", ");
            }
            Console.WriteLine("\n\nSecond key:");
            foreach (int c in secondKey)
            {
                Console.Write(c + ", ");
            }
            Console.WriteLine();

            FillTable(firstTable, firstKey);
            FillTable(secondTable, secondKey);

            Console.WriteLine("\nFirst table:");
            PrintTable(firstTable);
            Console.WriteLine("\nSecond table:");
            PrintTable(secondTable);

            List<char> result = [];
            int bigramIndex = 0;
            char firstChar;
            char secondChar;
            while(bigramIndex != message.msg.Count)
            {
                firstChar = message.msg[bigramIndex];
                secondChar = message.msg[bigramIndex + 1];

                //Console.WriteLine("\nBigram: " + firstChar + secondChar);

                var firstCharPos = FindLettersPos(firstChar, firstTable);
                var secondCharPos = FindLettersPos(secondChar, secondTable);

                //Console.WriteLine("Positions:" + firstCharPos.row + firstCharPos.col + " " + secondCharPos.row + secondCharPos.col);

                result.Add(secondTable[firstCharPos.row, secondCharPos.col]);
                result.Add(firstTable[secondCharPos.row, firstCharPos.col]);

                bigramIndex += 2;
            }

            return result;
        }

        public List<char> Decrypt(Message message, List<int> firstKey, List<int> secondKey)
        {
            char[,] firstTable = new char[rows, cols];
            char[,] secondTable = new char[rows, cols];

            Console.WriteLine("\n\nFirst key:");
            foreach (int c in firstKey)
            {
                Console.Write(c + ", ");
            }
            Console.WriteLine("\n\nSecond key:");
            foreach (int c in secondKey)
            {
                Console.Write(c + ", ");
            }
            Console.WriteLine();

            FillTable(firstTable, firstKey);
            FillTable(secondTable, secondKey);

            Console.WriteLine("\nFirst table:");
            PrintTable(firstTable);
            Console.WriteLine("\nSecond table:");
            PrintTable(secondTable);

            List<char> result = [];
            int bigramIndex = 0;
            char firstChar;
            char secondChar;
            while (bigramIndex != message.msg.Count)
            {
                firstChar = message.msg[bigramIndex];
                secondChar = message.msg[bigramIndex + 1];


                var firstCharPos = FindLettersPos(firstChar, secondTable);
                var secondCharPos = FindLettersPos(secondChar, firstTable);


                result.Add(firstTable[firstCharPos.row, secondCharPos.col]);
                result.Add(secondTable[secondCharPos.row, firstCharPos.col]);

                bigramIndex += 2;
            }

            return result;
        }

        public (int row, int col) FindLettersPos(char letter, char[,] table)
        {
            (int row, int col) pos = default;
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    if (table[i, j] == letter)
                    {
                        pos.row = i;
                        pos.col = j;
                    }
                }
            }
            return pos;
        }

        public void PrintTable(char[,] table)
        {
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    Console.Write(table[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void PrintData()
        {
            string alphabet_ = new string(Alphabet.ToArray());

            Console.WriteLine(alphabet_);
        }
    }
}
