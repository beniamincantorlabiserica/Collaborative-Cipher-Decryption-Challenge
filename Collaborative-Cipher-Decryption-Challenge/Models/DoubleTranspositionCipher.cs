using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Collaborative_Cipher_Decryption_Challenge.Interfaces;

namespace Collaborative_Cipher_Decryption_Challenge.Models;

public class DoubleTranspositionCipher : ICipher
{
   public string Encrypt(List<string> args)
    {
        return Process(args, true);
    }

    public string Decrypt(List<string> args)
    {
        return Process(args, false);
    }

    private string Process(List<string> args, bool encrypt)
    {
        if (args == null || args.Count != 3)
            throw new ArgumentException("Arguments must contain exactly three items: the input string and two keys.");

        string input = args[0];
        if (!TryParseKey(args[1], out List<int> firstKey) || !TryParseKey(args[2], out List<int> secondKey))
            throw new ArgumentException("Keys must be comma-separated lists of integers representing column indices.");

        // Normalize keys
        firstKey = NormalizeKey(firstKey, input.Length);
        secondKey = NormalizeKey(secondKey, input.Length);

        // Perform double transposition
        string firstPass = Transpose(input, firstKey, encrypt);
        string secondPass = Transpose(firstPass, secondKey, encrypt);

        return secondPass;
    }

    private List<int> NormalizeKey(List<int> key, int length)
    {
        if (key.Count > length)
        {
            throw new ArgumentException("Key length cannot exceed the length of the input text.");
        }
        return key.Concat(Enumerable.Range(1, length).Except(key)).ToList();
    }

    private string Transpose(string input, List<int> key, bool encrypt)
    {
        StringBuilder result = new StringBuilder(input);
        if (encrypt)
        {
            for (int i = 0; i < key.Count; i++)
            {
                for (int j = 0; j < input.Length / key.Count; j++)
                {
                    result[j * key.Count + i] = input[j * key.Count + key[i] - 1];
                }
            }
        }
        else
        {
            for (int i = 0; i < key.Count; i++)
            {
                for (int j = 0; j < input.Length / key.Count; j++)
                {
                    result[j * key.Count + key[i] - 1] = input[j * key.Count + i];
                }
            }
        }
        return result.ToString();
    }

    private bool TryParseKey(string keyString, out List<int> key)
    {
        key = new List<int>();
        var parts = keyString.Split(',');
        foreach (var part in parts)
        {
            if (int.TryParse(part.Trim(), out int value) && value > 0)
                key.Add(value);
            else
                return false;
        }
        return true;
    }
}