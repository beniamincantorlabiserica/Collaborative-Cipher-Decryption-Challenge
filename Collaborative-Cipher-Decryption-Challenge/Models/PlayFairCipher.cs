using Collaborative_Cipher_Decryption_Challenge.Interfaces;

namespace Collaborative_Cipher_Decryption_Challenge.Models;

using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

public class PlayfairCipher : ICipher
{
    private char[,] _matrix;
    
    private string _plaintext;
    private string _keyword;
    

    public PlayfairCipher()
    {
        
    }

    private void SetParamenters(List<string> args)
    {
        _plaintext = args[0];
        _keyword = args[1];
        _matrix = CreateMatrix(_keyword);
    } 

    private char[,] CreateMatrix(string keyword)
    {
        string defaultAlphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ"; // 'J' is merged with 'I'
        keyword = keyword.ToUpper().Replace("J", "I");
        keyword = new string(keyword.Distinct().ToArray()); // Remove duplicate letters
        var matrixAlphabet = keyword + string.Concat(defaultAlphabet.Where(c => !keyword.Contains(c)));

        char[,] matrix = new char[5, 5];
        for (int i = 0, k = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++, k++)
            {
                matrix[i, j] = matrixAlphabet[k];
            }
        }
        return matrix;
    }

    public string Encrypt(List<string> args)
    {
        SetParamenters(args);
        _plaintext = _plaintext.ToUpper().Replace("J", "I").Replace(" ", "");
        StringBuilder encryptedText = new StringBuilder();
        for (int i = 0; i < _plaintext.Length; i += 2)
        {
            if (i == _plaintext.Length - 1 || _plaintext[i] == _plaintext[i + 1])
                _plaintext = _plaintext.Insert(i + 1, "X");

            var (row1, col1, row2, col2) = FindPositions(_plaintext[i], _plaintext[i + 1]);
            if (row1 == row2)
            {
                encryptedText.Append(_matrix[row1, (col1 + 1) % 5]);
                encryptedText.Append(_matrix[row2, (col2 + 1) % 5]);
            }
            else if (col1 == col2)
            {
                encryptedText.Append(_matrix[(row1 + 1) % 5, col1]);
                encryptedText.Append(_matrix[(row2 + 1) % 5, col2]);
            }
            else
            {
                encryptedText.Append(_matrix[row1, col2]);
                encryptedText.Append(_matrix[row2, col1]);
            }
        }
        return encryptedText.ToString();
    }

    public string Decrypt(List<string> args)
    {
        SetParamenters(args);
        StringBuilder decryptedText = new StringBuilder();
        for (int i = 0; i < _plaintext.Length; i += 2)
        {
            var (row1, col1, row2, col2) = FindPositions(_plaintext[i], _plaintext[i + 1]);
            if (row1 == row2)
            {
                decryptedText.Append(_matrix[row1, (col1 + 4) % 5]); // 4 is used instead of -1 for left shift
                decryptedText.Append(_matrix[row2, (col2 + 4) % 5]);
            }
            else if (col1 == col2)
            {
                decryptedText.Append(_matrix[(row1 + 4) % 5, col1]);
                decryptedText.Append(_matrix[(row2 + 4) % 5, col2]);
            }
            else
            {
                decryptedText.Append(_matrix[row1, col2]);
                decryptedText.Append(_matrix[row2, col1]);
            }
        }
        return decryptedText.ToString().Replace("X", "");
    }

    private (int, int, int, int) FindPositions(char a, char b)
    {
        int row1 = 0, col1 = 0, row2 = 0, col2 = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (_matrix[i, j] == a)
                {
                    row1 = i;
                    col1 = j;
                }
                if (_matrix[i, j] == b)
                {
                    row2 = i;
                    col2 = j;
                }
            }
        }
        return (row1, col1, row2, col2);
    }
}
