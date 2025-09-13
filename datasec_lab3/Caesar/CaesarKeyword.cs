using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace datasec_lab3.Caesar
{
    public class CaesarKeyword
    {
        public List<char> alphabet;
        public List<char> keyword;
        public int k;

        private int replTableRows = 2;

        public CaesarKeyword(string filename)
        {
            alphabet = [];
            keyword = [];
            k = default;
            
            try
            {
                using StreamReader streamReader = new StreamReader(filename);

                string alphabetLine = streamReader.ReadLine();
                if (alphabetLine != null) alphabet = alphabetLine.ToCharArray().ToList();

                string keywordLine = streamReader.ReadLine();
                if(keywordLine != null) keyword = keywordLine.ToCharArray().ToList();

                string kLine = streamReader.ReadLine();
                if(kLine != null) int.TryParse(kLine, out k);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public List<char> ClearAlphabet()
        {
            var result = alphabet.Except(keyword).ToList();

            string cleanAlphabet = new string(result.ToArray());
            Console.WriteLine("\nThe alphabet with no keyword chars:\n" + cleanAlphabet);

            return result;
        }

        public List<char> Encrypt(Message message)
        {
            char[,] replTable = new char[replTableRows, alphabet.Count];

            FillTable(replTable, alphabet, ClearAlphabet());

            Console.WriteLine("\nReplacement table:");
            PrintTable(replTable);

            List<char> result = [];
            for(int i = 0; i < message.msg.Count; i++)
            {
                var charPos = FindLettersPos(message.msg[i], replTable, true);
                result.Add(replTable[charPos.row + 1, charPos.col]);
            }

            return result;
        }

        public List<char> Decrypt(Message message)
        {
            char[,] replTable = new char[replTableRows, alphabet.Count];

            FillTable(replTable, alphabet, ClearAlphabet());

            Console.WriteLine("\nReplacement table:");
            PrintTable(replTable);

            List<char> result = [];
            for (int i = 0; i < message.msg.Count; i++)
            {
                var charPos = FindLettersPos(message.msg[i], replTable, false);
                result.Add(replTable[charPos.row - 1, charPos.col]);
            }

            return result;
        }

        public (int row, int col) FindLettersPos(char letter, char[,] table, bool encrypt)
        {            
            (int row, int col) pos = default;

            int row = encrypt ? 0 : 1;
            for (int j = 0; j < alphabet.Count; j++)
            {
                if (table[row, j] == letter)
                {
                        pos.row = row;
                        pos.col = j;
                }
            }
            return pos;
        }

        public char[,] FillTable(char[,] table, List<char> alphabet, List<char> cleanAlphabet)
        {
            for(int j = 0; j < alphabet.Count; j++)
            {
                table[0, j] = alphabet[j];
            }

            int offset = k;
            int keywordIndex = 0;
            for(int j = 0; j < alphabet.Count; j++)
            {
                if(j < k)
                {
                    table[1, j] = cleanAlphabet[cleanAlphabet.Count - offset];
                    offset--;
                }
                else if(j < keyword.Count + k)
                {
                    table[1, j] = keyword[keywordIndex];
                    keywordIndex++;
                }
                else
                    table[1, j] = cleanAlphabet[j - k - keyword.Count];
            }

            return table;
        }

        public void PrintTable(char[,] table)
        {
            for (int i = 0; i < replTableRows; i++)
            {
                for (int j = 0; j < alphabet.Count; j++)
                {
                    Console.Write(table[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void PrintData()
        {

            string alphabet_ = new string(alphabet.ToArray());
            Console.WriteLine("Alphabet: " + alphabet_);

            string keyword_ = new string(keyword.ToArray());
            Console.WriteLine("Keyword: " + keyword_);

            int k_ = k;
            Console.WriteLine("k: " + k_);
        }
    }
}
