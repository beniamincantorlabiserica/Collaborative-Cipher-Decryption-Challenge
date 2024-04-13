using System.Collections.Generic;
using Collaborative_Cipher_Decryption_Challenge.Interfaces;

namespace Collaborative_Cipher_Decryption_Challenge.Models;

using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;


public class CaesarCipher : ICipher
{

    public string Encrypt(List<string> args)
    {
        return CaesarShift(args, true);
    }

    public string Decrypt(List<string> args)
    {
        return CaesarShift(args, false);
    }

    private string CaesarShift(List<string> args, bool encrypt)
    {
        if (args == null || args.Count != 2)
            throw new ArgumentException("Arguments must contain exactly two items: the input string and the shift value.");

        string input = args[0];
        if (!int.TryParse(args[1], out int shift))
            throw new ArgumentException("Second argument must be an integer representing the shift.");

        if (shift < 0)
            throw new ArgumentOutOfRangeException("Shift must be a non-negative integer.");

        // Normalize the shift to a range of 0-25
        shift %= 26;
        if (!encrypt)
        {
            shift = 26 - shift;
        }

        char[] buffer = input.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];

            if (char.IsLetter(letter))
            {
                char offset = char.IsUpper(letter) ? 'A' : 'a';
                buffer[i] = (char)(((letter + shift - offset) % 26) + offset);
            }
        }

        return new string(buffer);
    }
    
    // private string _plaintext;
    // private string _shift;
    //
    // // Overall I think a better bethod than the previous one, WIP    
    // public string Encrypt(List<string> args)
    // {
    //     if (Int32.TryParse(_shift, out int buffer_shift))
    //     {
    //         Console.WriteLine(buffer_shift);
    //     }
    //     else
    //     {
    //         Console.WriteLine($"Int32.TryParse could not parse '{_shift}' to an int.");
    //     }
    //
    //     char[] buffer = _plaintext.ToCharArray();
    //     for (int i = 0; i < buffer.Length; i++)
    //     {
    //         // Letter.
    //         char letter = buffer[i];
    //         // Add shift to all.
    //         letter = (char)(letter + buffer_shift);
    //         // Subtract 26 if past z.
    //         // ... Add 26 if below a.
    //         if (letter > 'z')
    //         {
    //             letter = (char)(letter - 26);
    //         }
    //         else if (letter < 'a')
    //         {
    //             letter = (char)(letter + 26);
    //         }
    //         // Store.
    //         buffer[i] = letter;
    //     }
    //     return new string(buffer);
    // }
    //
    // public string Decrypt(List<string> args)
    // {
    //     if (Int32.TryParse(_shift, out int buffer_shift))
    //     {
    //         Console.WriteLine(buffer_shift);
    //     }
    //     else
    //     {
    //         Console.WriteLine($"Int32.TryParse could not parse '{_shift}' to an int.");
    //     }
    //
    //     char[] buffer = _plaintext.ToCharArray();
    //     for (int i = 0; i < buffer.Length; i++)
    //     {
    //         // Letter.
    //         char letter = buffer[i];
    //         // Remove shift from all.
    //         letter = (char)(letter - buffer_shift);
    //         // Subtract 26 if past z.
    //         // ... Add 26 if below a.
    //         if (letter > 'z')
    //         {
    //             letter = (char)(letter - 26);
    //         }
    //         else if (letter < 'a')
    //         {
    //             letter = (char)(letter + 26);
    //         }
    //         // Store.
    //         buffer[i] = letter;
    //     }
    //     return new string(buffer);
    // }

}