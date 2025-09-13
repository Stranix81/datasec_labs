using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datasec_lab3
{
    public class Crypt
    {
        //private List<string> keys;

        private List<char> alphabet;

        private readonly List<double> russianFrequencies =
            [
                0.062, 0.014, 0.038, 0.013, 0.025, // А, Б, В, Г, Д
                0.072, 0.072, 0.007, 0.016, 0.062, // Е, Ё, Ж, З, И
                0.010, 0.028, 0.035, 0.026, 0.053, // Й, К, Л, М, Н
                0.090, 0.023, 0.040, 0.045, 0.053, // О, П, Р, С, Т
                0.021, 0.002, 0.009, 0.004, 0.012, // У, Ф, Х, Ц, Ч
                0.006, 0.003, 0.014, 0.016, 0.014, // Ш, Щ, Ъ, Ы, Ь
                0.003, 0.006, 0.018, 0.012, 0.175  // Э, Ю, Я, ТОЧКА, ПРОБЕЛ
            ];

        public Crypt()
        {
            //keys = [];
            alphabet = [.. "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ. ".ToCharArray().ToList()];

            try
            {
                //keys = File.ReadAllLines(filename).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public double CalculateFrequency(char letter, Message message)
        {
            double freq = (double)message.msg.Count(c => c == letter) / message.msg.Count;

            return freq;
        }

        public double CalculateW(Message message)
        {
            double w = 0;

            List<double> frequencies = [];

            foreach(var letter in alphabet)
            {
                frequencies.Add(CalculateFrequency(letter, message));
            }

            
            for(int i = 0; i < frequencies.Count; i++)
            {
                w += Math.Pow((frequencies[i] - russianFrequencies[i]), 2);
            }

            return w;
        }

        public void ToFile(double w, string keyword)
        {
            using StreamWriter streamWriter = new StreamWriter("crypt_output.txt", append: true);
            string output = new string("Keyword: " + keyword + " W: " + w);
            streamWriter.WriteLine(output);
        }
    }
}
