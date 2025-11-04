using datasec_lab6.Diffie_Hellman;

var (p, g) = Diffie_Hellman.GenerateParameters();
Console.WriteLine($"p = {p} (correct: {Diffie_Hellman.IsPrime(p)}), g = {g} (correct: {Diffie_Hellman.IsPrimitiveRootModulo(g, p)})");

Diffie_Hellman alice = new Diffie_Hellman(p, g, 15); // a = 15
Diffie_Hellman bob = new Diffie_Hellman(p, g, 13);   // b = 13

Console.WriteLine($"Alice's public key (A): {alice.PublicKey}\nBob's public key (B): {bob.PublicKey}");

alice.ComputeSharedKey(bob.PublicKey);
bob.ComputeSharedKey(alice.PublicKey);

Console.WriteLine($"Alice's shared key (s): {alice.SharedKey}\nBob's shared key (s): {bob.SharedKey}");