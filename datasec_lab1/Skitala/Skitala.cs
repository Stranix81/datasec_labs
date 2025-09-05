using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datasec_lab1.Skitala
{
    public class Skitala
    {
        public int rows;
        public int columns;

        public Skitala(string filename)
        {
            using StreamReader streamReader = new StreamReader(filename);
            string rowsLine = streamReader.ReadLine();
            if (rowsLine != null) int.TryParse(rowsLine, out rows);
        }


        public List<char> Encrypt(Message message)
        {
            columns = ((message.msg.Count - 1) / rows) + 1;
            char[,] table = new char[rows, columns];

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    int index = i * columns + j;
                    if (index < message.msg.Count)
                        table[i, j] = message.msg[index];
                    else table[i, j] = ' ';
                }
            }

            Console.WriteLine("\nTable:");
            PrintTable(table);

            List<char> result = [];
            for(int j = 0; j < columns; j++)
            {
                for(int i = 0; i < rows; i++)
                {
                    result.Add(table[i, j]);
                }
            }
            return result;
        }

        public List<char> Decrypt(Message message)
        {
            columns = ((message.msg.Count - 1) / rows) + 1;
            char[,] table = new char[rows, columns];

            int index = 0;
            for (int j = 0; j < columns; j++)
            {
                for (int i = 0; i < rows; i++)
                {                    
                    if (index < message.msg.Count)
                        table[i, j] = message.msg[index];
                    else table[i, j] = ' ';
                    index++;
                }
            }

            Console.WriteLine("\nTable:");
            PrintTable(table);

            List<char> result = [];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result.Add(table[i, j]);
                }
            }
            return result;
        }

        public void PrintTable(char[,] table)
        {
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    Console.Write(table[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void PrintData()
        {
            Console.WriteLine(rows);
        }
    }
}
