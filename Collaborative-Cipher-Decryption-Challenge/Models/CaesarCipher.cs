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

    // Overall I think a better bethod than the previous one, WIP    
    static string Encrypt(List<string> args)
    {

        char[] buffer = _plaintext.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            // Letter.
            char letter = buffer[i];
            // Add shift to all.
            letter = (char)(letter + _shift);
            // Subtract 26 if past z.
            // ... Add 26 if below a.
            if (letter > 'z')
            {
                letter = (char)(letter - 26);
            }
            else if (letter < 'a')
            {
                letter = (char)(letter + 26);
            }
            // Store.
            buffer[i] = letter;
        }
        return new string(buffer);
    }

    static string Decrypt(List<string> args)
    {

        char[] buffer = _plaintext.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            // Letter.
            char letter = buffer[i];
            // Remove shift from all.
            letter = (char)(letter - _shift);
            // Subtract 26 if past z.
            // ... Add 26 if below a.
            if (letter > 'z')
            {
                letter = (char)(letter - 26);
            }
            else if (letter < 'a')
            {
                letter = (char)(letter + 26);
            }
            // Store.
            buffer[i] = letter;
        }
        return new string(buffer);
    }

    /*public string Encrypt(List<string> args)
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
    }*/
}