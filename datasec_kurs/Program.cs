using ClassLibrary;
using datasec_kurs.CFB;
using datasec_kurs.IDEA;
using System.Text;
using System.Security.Cryptography;

Message message = new Message("../../../../message.txt");
Console.WriteLine("Original message:");
message.PrintMessage();

byte[] msgBytes = Encoding.ASCII.GetBytes(message.ToString());
Console.WriteLine("\nMessage in bytes (and binary):");
for (int i = 0; i < msgBytes.Length; i++)
{
    byte b = msgBytes[i];
    Console.WriteLine($"{message.msg[i]} -> {b} -> {Convert.ToString(b, 2).PadLeft(8, '0')}");
}

//byte[] key = new byte[16] {
//    0x12, 0x34, 0x56, 0x78,
//    0x9A, 0xBC, 0xDE, 0xF0,
//    0x11, 0x22, 0x33, 0x44,
//    0x55, 0x66, 0x77, 0x88
//};

byte[] key = new byte[16];
RandomNumberGenerator.Fill(key);
//for (int i = 0; i < 16; i++) key[i] = (byte)i;
Console.WriteLine("\nKey (hex): " + BitConverter.ToString(key));

//byte[] iv = new byte[8] {
//    0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF 
//};

byte[] iv = new byte[8];
RandomNumberGenerator.Fill(iv);
//for (int i = 0; i < 8; i++) iv[i] = (byte)(i + 1);
Console.WriteLine("IV (hex): " + BitConverter.ToString(iv));

var core = new IDEACore();
core.Init(key);

var cfb = new CFBIDEA(core, iv);


ConsoleColor originalFore = Console.ForegroundColor;
ConsoleColor originalBack = Console.BackgroundColor;
#region ШИФРОВКА
Console.ForegroundColor = ConsoleColor.Black;
Console.BackgroundColor = ConsoleColor.Gray;
Console.WriteLine("\n\n\n--- Encryption steps ---");
byte[] cipher = cfb.Encrypt(msgBytes);
Console.WriteLine("\n--- End of encryption ---");

Console.ForegroundColor = originalFore;
Console.BackgroundColor = originalBack;
Console.WriteLine("Cipher bytes (hex): " + BitConverter.ToString(cipher));

Console.WriteLine("Cipher as ASCII (may be garbled):\n" + Encoding.ASCII.GetString(cipher));
#endregion ШИФРОВКА

#region РАСШИФРОВКА
Console.ForegroundColor = ConsoleColor.Black;
Console.BackgroundColor = ConsoleColor.Gray;
Console.WriteLine("\n\n\n--- Decryption steps ---");
byte[] recovered = cfb.Decrypt(cipher);
Console.WriteLine("\n--- End of decryption ---");

Console.ForegroundColor = originalFore;
Console.BackgroundColor = originalBack;
Console.WriteLine("Recovered bytes (hex): " + BitConverter.ToString(recovered));
string recMsg = Encoding.ASCII.GetString(recovered);
List<char> msg = new List<char>(recMsg.ToCharArray().ToList());
Message decryptedMessage = new Message(msg);
Console.WriteLine("Recovered message:\n" + decryptedMessage.ToString());
#endregion РАСШИФРОВКА