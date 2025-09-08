using datasec_lab1;
using datasec_lab2.Wheatstone;

Message message = new Message("../../../../message.txt");
Console.WriteLine("Message:");
message.PrintMessage();

Wheatstone wheatstone = new Wheatstone("wheatstone.txt");
Console.WriteLine("\nData:");
wheatstone.PrintData();

//List<int> firstKey = wheatstone.GenerateAlphabetPositions();
//List<int> secondKey = wheatstone.GenerateAlphabetPositions();
List<int> firstKey = new List<int> { 1, 30, 7, 34, 28, 31, 11, 32, 20, 2, 19, 26, 6, 5, 4, 33, 29, 12, 3, 10, 0, 23, 8, 21, 27, 9, 24, 17, 22, 16, 25, 13, 18, 15, 14 };
List<int> secondKey = new List<int> { 15, 2, 31, 4, 27, 11, 29, 30, 18, 19, 25, 6, 32, 9, 8, 34, 12, 10, 13, 14, 5, 0, 24, 1, 16, 22, 17, 28, 3, 20, 33, 26, 21, 23, 7 };

#region ШИФРОВКА
//Message encryptedMessage = new Message(wheatstone.Encrypt(message, firstKey, secondKey));
//Console.WriteLine("\nEncrypted message:");
//encryptedMessage.PrintMessage();
//encryptedMessage.ToFile();
#endregion

#region РАСШИФРОВКА
Message decryptedMessage = new Message(wheatstone.Decrypt(message, firstKey, secondKey));
Console.WriteLine("\nDecrypted message:");
decryptedMessage.PrintMessage();
decryptedMessage.ToFile();
#endregion