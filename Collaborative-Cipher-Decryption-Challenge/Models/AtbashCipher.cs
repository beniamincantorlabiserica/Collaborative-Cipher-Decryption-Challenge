using System;
using System.Collections.Generic;
using System.Linq;
using Collaborative_Cipher_Decryption_Challenge.Interfaces;
using DynamicData;

namespace Collaborative_Cipher_Decryption_Challenge.Models;

public class AtbashCipher : ICipher
{
    public string Decrypt(List<string> args)
    {
        string input = args[0];
        string[] letters =
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u",
            "v", "w", "x", "y", "z"  //26 letters
        };
        string output = string.Empty;

        for (int i = 0; i < input.Length; i++)
        {
            char letter = input[i];
            int indexOfLetter = letters.IndexOf(letter.ToString());
            if (letter.Equals(letter.ToString().ToLower()))
            {
                output += letters[25 - indexOfLetter];

            }
            else
            {
                output += letters[25 - indexOfLetter].ToUpper();
            }
        }

        return output;
    }

    public string Encrypt(List<string> args)
    {
        string input = args[0];
        string[] letters =
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u",
            "v", "w", "x", "y", "z"  //26 letters
        };
        string output = string.Empty;

        for (int i = 0; i < input.Length; i++)
        {
            char letter = input[i];
            int indexOfLetter = letters.IndexOf(letter.ToString());
            if (letter.Equals(letter.ToString().ToLower()))
            {
                output += letters[25 - indexOfLetter];

            }
            else
            {
                output += letters[25 - indexOfLetter].ToUpper();
            }

        }   

        return output;
    }
    
}