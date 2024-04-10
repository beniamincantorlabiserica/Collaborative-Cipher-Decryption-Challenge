using System.Collections.Generic;

namespace Collaborative_Cipher_Decryption_Challenge.Interfaces;

public interface ICipher
{
    public string Decrypt(List<string> args);
    public string Encrypt(List<string> args);
}