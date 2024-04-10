using System.Collections.Generic;

namespace Collaborative_Cipher_Decryption_Challenge.Interfaces;

public interface ICipher
{
    // Keep in mind that the args list is a list of all the arguments that the user has inputted
    // the structure of the list is as follows:
    // args[0] = the input from the user (text to be encrypted/decrypted)
    // args[1] = the first argument of the algorithm (use only if needed, otherwise ignore)
    // args[2] = the second argument of the algorithm (use only if needed, otherwise ignore)
    public string Decrypt(List<string> args);
    public string Encrypt(List<string> args);
}