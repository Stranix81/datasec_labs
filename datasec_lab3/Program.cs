using ClassLibrary;
using datasec_lab3;
using datasec_lab3.Caesar;

Message message = new Message("../../../../message.txt");
Console.WriteLine("Message:");
message.PrintMessage();

CaesarKeyword caesar = new CaesarKeyword("caesar.txt");
Console.WriteLine("\nData:");
caesar.PrintData();

#region ШИФРОВКА
Message encryptedMessage = new Message(caesar.Encrypt(message));
Console.WriteLine("\nEncrypted message:");
encryptedMessage.PrintMessage();
encryptedMessage.ToFile();
#endregion

#region РАСШИФРОВКА
//Message decryptedMessage = new Message(caesar.Decrypt(message));
//Console.WriteLine("\nDecrypted message:");
//decryptedMessage.PrintMessage();
//decryptedMessage.ToFile();
#endregion

#region КРИПТОАНАЛИЗ
Console.WriteLine("\n\n\nCryptoanalyze:\n");
List<string> keywords = new List<string>()
{
    "АБВГДЕО",
    "ПЕТУХИ.",
    "ЖАЛОСТЬ",
    "ШИФРОВК"
};
Crypt analyzer = new Crypt();

Message decryptedMessage;
foreach (var keyword in keywords)
{
    caesar.keyword = keyword.ToCharArray().ToList();
    Console.WriteLine("Keyword:\n" + keyword);
    decryptedMessage = new Message(caesar.Decrypt(encryptedMessage));
    Console.WriteLine("\nDecrypted message:\n");
    decryptedMessage.PrintMessage();
    double w = analyzer.CalculateW(decryptedMessage);
    Console.WriteLine("\nCalculated W: " + w + "\n\n");
    analyzer.ToFile(w, keyword);
}

#endregion
