using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Trisemus
{
    public class Trisemus
    {
        public List<char> Alphabet;
        public List<char> keyword;
        public int columns;
        public int rows;

        public Trisemus(string filename)
        {
            Alphabet = [];
            keyword = [];
            try
            {
                using StreamReader streamReader = new StreamReader(filename);

                string alphabetLine = streamReader.ReadLine();
                if (alphabetLine != null) Alphabet = alphabetLine.ToCharArray().ToList();

                string keywordLine = streamReader.ReadLine();
                if (keywordLine != null) keyword = keywordLine.ToCharArray().ToList();

                string columnsLine = streamReader.ReadLine();
                if (columnsLine != null) int.TryParse(columnsLine, out columns);

                string rowsLine = streamReader.ReadLine();
                if (rowsLine != null) int.TryParse(rowsLine, out rows);

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }        
        }

        public List<char> ClearAlphabet()
        {
            var result = Alphabet.Except(keyword).ToList();

            string cleanAlphabet = new string(result.ToArray());
            Console.WriteLine("\nThe alphabet with no keyword chars:\n" + cleanAlphabet);

            return result;
        }

        public List<char> Encrypt(Message message)
        {
            List<char> CleanAlphabet = ClearAlphabet();

            List<char> table = keyword.Concat(CleanAlphabet).ToList();

            PrintTable(table);

            List<char> result = [];
            foreach(char originalChar in message.msg)
            {
                int originalIndex = table.IndexOf(originalChar);
                char encryptedChar = table[(originalIndex + columns) % (columns * rows)];
                result.Add(encryptedChar);
            }
            return result;
        }

        public List<char> Decrypt(Message message)
        {
            Alphabet = ClearAlphabet();

            List<char> table = keyword.Concat(Alphabet).ToList();

            Console.WriteLine("\nTable:");
            PrintTable(table);

            List<char> result = [];
            foreach (char encryptedChar in message.msg)
            {
                int encryptedIndex = table.IndexOf(encryptedChar);
                char decryptedChar = table[((encryptedIndex - columns) + (columns * rows)) % (columns * rows)];
                result.Add(decryptedChar);
            }
            return result;
        }

        public void PrintTable(List<char> table)
        {
            for(int i = 0; i < table.Count; i++)
            {
                if ((i != 0) && (i % columns == 0)) Console.WriteLine();
                Console.Write(table[i]);            
            }
        }

        public void PrintData()
        {
            string alphabet_ = new string(Alphabet.ToArray());
            string keyword_ = new string(keyword.ToArray());

            Console.WriteLine(
                alphabet_ + '\n' + 
                keyword_ + '\n' + 
                columns + ' ' + rows
            );
        }
    }
}
