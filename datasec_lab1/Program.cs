using ClassLibrary;
using ClassLibrary.Skitala;
using ClassLibrary.Trisemus;
using System.Data;

Message message = new Message("../../../../message.txt");
Console.WriteLine("Message:");
message.PrintMessage();



#region ТАБЛИЦА ТРИСЕМУСА

//Trisemus trisemus = new Trisemus("trisemus.txt");
//Console.WriteLine("\nData:");
//trisemus.PrintData();

//Message encryptedMessage = new Message(trisemus.Encrypt(message));
//Console.WriteLine("\n\nEncrypted message:");
//encryptedMessage.PrintMessage();
//encryptedMessage.ToFile();

////Message decryptedMessage = new Message(trisemus.Decrypt(message));
////Console.WriteLine("\n\nDecrypted message:");
////decryptedMessage.PrintMessage();
////decryptedMessage.ToFile();

#endregion

#region СКИТАЛА

Skitala skitala = new Skitala("skitala.txt");
Console.WriteLine("\nData:");
skitala.PrintData();

Message encryptedMessage = new Message(skitala.Encrypt(message));
Console.WriteLine("\n\nEncrypted message:");
encryptedMessage.PrintMessage();
encryptedMessage.ToFile();

//Message decryptedMessage = new Message(skitala.Decrypt(message));
//Console.WriteLine("\n\nDecrypted message:");
//decryptedMessage.PrintMessage();
//decryptedMessage.ToFile();

#endregion