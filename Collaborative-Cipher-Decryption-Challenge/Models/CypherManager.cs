using Collaborative_Cipher_Decryption_Challenge.Interfaces;

namespace Collaborative_Cipher_Decryption_Challenge.Models;

public class CypherManager
{
    private readonly AtbashCipher _atbashCipher = new AtbashCipher();
    private readonly CaesarCipher _caesarCipher = new CaesarCipher();
    private readonly DoubleTranspositionCipher _doubleTranspositionCipher = new DoubleTranspositionCipher();
    private readonly PlayfairCipher _playfairCipher = new PlayfairCipher();
  


    public CypherManager()
    {
    }

    public ICipher? GetCipher(int cipherType)
    {
        return cipherType switch
        {
            1 => _atbashCipher,
            2 => _caesarCipher, 
            3 => _doubleTranspositionCipher,
            4 => _playfairCipher,
            _ => null
        };
    }
    
    
}