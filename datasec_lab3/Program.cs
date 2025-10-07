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
List<char> alphabet = new List<char>(caesar.keyword);
Message decryptedMessage;
Crypt analyzer = new Crypt();
List <(double w, Message decr, string keyword)> listW = new List<(double w, Message decr, string keyword)>();

int length = 7;
foreach (var combo in GeneratePermutations(alphabet, length))
{
    string result = combo;

    caesar.keyword = result.ToCharArray().ToList();
    //Console.WriteLine("Keyword:\n" + result);
    decryptedMessage = new Message(caesar.Decrypt(encryptedMessage));
    //Console.WriteLine("\nDecrypted message:\n");
    //decryptedMessage.PrintMessage();
    double w = analyzer.CalculateW(decryptedMessage);
    listW.Add((w, decryptedMessage, result));
    //Console.WriteLine("\nCalculated W: " + w + "\n\n");

    //Console.WriteLine(result); // тут у тебя уже string, можно использовать как аргумент
}


static IEnumerable<string> GeneratePermutations(List<char> alphabet, int length)
{
    return Permute(alphabet, new List<char>(), length);
}

static IEnumerable<string> Permute(List<char> remaining, List<char> prefix, int length)
{
    if (prefix.Count == length)
    {
        yield return new string(prefix.ToArray());
        yield break;
    }

    for (int i = 0; i < remaining.Count; i++)
    {
        char c = remaining[i];

        // создаём новый список без текущего символа
        var nextRemaining = new List<char>(remaining);
        nextRemaining.RemoveAt(i);

        var nextPrefix = new List<char>(prefix) { c };

        foreach (var s in Permute(nextRemaining, nextPrefix, length))
            yield return s;
    }
}

Console.WriteLine("\n\n\nCryptoanalyze:\n");

var top10 = listW
    .OrderBy(x => x.w)
    .Take(10);

foreach (var item in top10)
{
    Console.WriteLine($"Decrypted Message: \n{item.decr.ToString()}\n W: {item.w}\nKeyword: {item.keyword}\n");
}

//List<string> keywords = new List<string>()
//{
//    "АБВГДЕО",
//    "ПЕТУХИ.",
//    "ИШФРОВК",
//    "ШИФРОВК"
//};




//foreach (var keyword in keywords)
//{
//    caesar.keyword = keyword.ToCharArray().ToList();
//    Console.WriteLine("Keyword:\n" + keyword);
//    decryptedMessage = new Message(caesar.Decrypt(encryptedMessage));
//    Console.WriteLine("\nDecrypted message:\n");
//    decryptedMessage.PrintMessage();
//    double w = analyzer.CalculateW(decryptedMessage);
//    Console.WriteLine("\nCalculated W: " + w + "\n\n");
//    analyzer.ToFile(w, keyword);
//}

#endregion
