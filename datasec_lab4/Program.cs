using ClassLibrary;
using datasec_lab4.CongruentGen;
using datasec_lab4.FibonacciGen;
using datasec_lab4.GammaCipher;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;

Message message = new Message("../../../../message.txt");
Console.WriteLine("Message:");
message.PrintMessage();
byte[] msgBytes = System.Text.Encoding.ASCII.GetBytes(message.ToString());

Console.WriteLine("Message in bytes:");
for(int i = 0; i < message.msg.Count; i++)
{
    Console.WriteLine($"{message.msg[i]} -> {msgBytes[i]} -> {Convert.ToString(msgBytes[i], 2).PadLeft(8, '0')}");
}

#region СОЗДАНИЕ ГАММЫ
GammaCipher gammaCipher = new GammaCipher(msgBytes);

List<byte> gamma = [.. gammaCipher.CreateGamma()];

Console.WriteLine("\nCongruent generator numbers:");
List<decimal> congrGenNumbersDecimal = [.. gammaCipher.GetCongrGenNumbersDecimal()];
foreach (decimal number in congrGenNumbersDecimal)
{
    Console.Write(number + " ");
}
Console.WriteLine();

Console.WriteLine("\nFibonacci generator numbers (decimal gamma):");
List<ulong> fibGenNumbersUlong = [.. gammaCipher.GetFibNumbersUlong()];
foreach (var fibGenNumberUlong in fibGenNumbersUlong)
{
    Console.WriteLine(fibGenNumberUlong);
}

Console.WriteLine("\nFibonacci generator binary numbers (binary gamma):");
List<string> fibGenNumbersBinary = [.. gammaCipher.GetFibNumbersBinary()];
foreach (var fibGenNumberBinary in fibGenNumbersBinary)
{
    Console.WriteLine(fibGenNumberBinary);
}

Console.WriteLine("\nBinary gamma byte-by-byte:");
for (int i = 0; i < gamma.Count; i++)
{
    string bits = Convert.ToString(gamma[i], 2).PadLeft(8, '0');
    Console.WriteLine(bits);
}

#endregion СОЗДАНИЕ ГАММЫ

#region ШИФРОВКА
byte[] encrMsgBytes = gammaCipher.Encrypt(message);
Message encryptedMessage = new Message(System.Text.Encoding.ASCII.GetString(encrMsgBytes).ToCharArray().ToList());
//Message encryptedMessage = new Message(gammaCipher.Encrypt(message));
Console.WriteLine("\nEncrypted message:");
encryptedMessage.PrintMessage();
#endregion ШИФРОВКА

#region РАСШИФРОВКА
Message decryptedMessage = new Message(gammaCipher.Decrypt(encrMsgBytes));
//Message decryptedMessage = new Message(gammaCipher.Decrypt(encryptedMessage));
Console.WriteLine("\nDecrypted message:");
decryptedMessage.PrintMessage();
#endregion РАСШИФРОВКА