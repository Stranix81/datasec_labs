using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Message
    {

        public List<char> msg;

        public Message(string filename)
        {
            msg = [];
            try
            {
                using StreamReader streamReader = new StreamReader(filename);

                string messageLine = streamReader.ReadLine();
                if (messageLine != null) msg = messageLine.ToCharArray().ToList();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public Message(List<char> message)
        {
            this.msg = [.. message];
        }

        public void PrintMessage()
        {
            string message_ = new string(msg.ToArray());
            Console.WriteLine(message_);
        }

        public void ToFile()
        {
            using StreamWriter streamWriter = new StreamWriter("output.txt");
            string output = new string(msg.ToArray());
            streamWriter.Write(output);
        }
    };
}
