using System.Collections.Generic;
using Collaborative_Cipher_Decryption_Challenge.Interfaces;

namespace Collaborative_Cipher_Decryption_Challenge.Models;

using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using DynamicData;

public class CaesarCipher : ICipher
{

    private string _plaintext;
    private string _shift;
    private string shifted;

    public CaesarCipher()
    {

    }

    private void SetParamenters(List<string> args)
    {
        _plaintext = args[0];
        _shift = args[1];
    } 
    

    public string Encrypt(List<string> args)
    {
        string encryptedText = "";
        foreach (char c in _plaintext)
        {
            if (char.IsLetter(c))
            {
                char lowerC = char.ToLower(c);
                char shifted = (char)(((lowerC + _shift - 'a') % 26) + "a");
                encryptedText += shifted;
            }
            else
            {
                encryptedText += c;
            }   
        }
        
        return encryptedText;
    }

    public string Decrypt(List<string> args)
    {
        string decryptedText = "";

        foreach(char c in _plaintext)
        {
            if(char.IsLetter(c))
            {
                char lowerC = char.ToLower(c);
                char shifted = (char)(((lowerC - _shift - 'a' + 26) % 26) + "a");
                decryptedText += shifted;
            }
            else
            {
                decryptedText += c;
            }
        }
    }
}