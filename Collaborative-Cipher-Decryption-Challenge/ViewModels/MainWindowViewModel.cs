using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Collaborative_Cipher_Decryption_Challenge.Interfaces;
using Collaborative_Cipher_Decryption_Challenge.Models;
using ReactiveUI;

namespace Collaborative_Cipher_Decryption_Challenge.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    
    private ICipher? _cipher;
    private readonly CypherManager _cypherManager = new CypherManager();
    public int CurrentTab { get; set; }
    public string Input { get; set; }
    
    private string _output = string.Empty;

    public string Output
    {
        get => _output;
        set => this.RaiseAndSetIfChanged(ref _output, value);
    }
    
    public string Data1 { get; set; }
    public string Data2 { get; set; }
    
    private string _error = string.Empty;
    public string Error
    {
        get => _error;
        set => this.RaiseAndSetIfChanged(ref _error, value);
    }

    public MainWindowViewModel()
    {
       
        
    }
    
    public void Encrypt()
    {
        _cipher = _cypherManager.GetCipher(CurrentTab + 1);
        Console.WriteLine("Encrypting..." + Input);

        if (GetArgs() != null)
        {
            Console.WriteLine(_cipher.Encrypt(GetArgs()));
            Output = _cipher.Encrypt(GetArgs());
        }
        Console.WriteLine(Error);
        
    }   
    
    public void Decrypt()
    {
        _cipher = _cypherManager.GetCipher(CurrentTab + 1);
        if (GetArgs() != null)
        {
            Console.WriteLine(_cipher.Decrypt(GetArgs()));
            Output = _cipher.Decrypt(GetArgs());
        }
    }
    
    private List<string>? GetArgs()
    {
        List<string>? args = new List<string>();
        
        if (Regex.IsMatch(Input, @"^[a-zA-Z]+$"))
        {
            Console.WriteLine("Input: " + Input);
            args.Add(Input);
        }
        else
        {
            Error = "Invalid input. Please enter only letters and spaces";
            return null;
        }
        
        switch (CurrentTab+1)
        {
            case 1:
                return args;
            case 2:
                if (Regex.IsMatch(Data1, @"[0-9]"))
                {
                    args.Add(Data1);
                    return args;
                }
                else
                {
                    Error = "Invalid input. Please enter only numbers.";
                    return null;
                }
                break;
            case 3:
                if (Regex.IsMatch(Data1, @"[0-9]") && Regex.IsMatch(Data2, @"[0-9]"))
                {
                    args.Add(Data1);
                    args.Add(Data2);
                    return args;
                }
                else
                {
                    Error = "Invalid input. Please enter only numbers.";
                    return null;
                }
                break;
            case 4:
                Console.WriteLine("Enteres Playfair");
                if (Regex.IsMatch(Data1, @"[a-zA-Z]"))
                {
                    Console.WriteLine("Data1: " + Data1);
                    args.Add(Data1);
                    return args;
                }
                else
                {
                    Error = "Invalid input. Please enter only letters.";
                    return null;
                }
                break;
        }
        return null;
    }
    
}