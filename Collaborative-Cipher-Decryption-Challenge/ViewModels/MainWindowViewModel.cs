using System;
using System.Collections.Generic;
using Collaborative_Cipher_Decryption_Challenge.Interfaces;
using Collaborative_Cipher_Decryption_Challenge.Models;

namespace Collaborative_Cipher_Decryption_Challenge.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    
    private ICipher? _cipher;
    private readonly CypherManager _cypherManager = new CypherManager();
    public int CurrentTab { get; set; }
    public MainWindowViewModel()
    {
       
        
    }
    
    public void Encrypt()
    {
        _cipher = _cypherManager.GetCipher(CurrentTab + 1);
        List<string> args = new List<string>();
        args.Add("instruments");
        args.Add("monarchy");
        Console.WriteLine(_cipher.Encrypt(args));
    }   
    
    public void Decrypt()
    {
        _cipher = _cypherManager.GetCipher(CurrentTab + 1);
        List<string> args = new List<string>();
        args.Add("GATLMZCLRQXA");
        args.Add("monarchy");
        Console.WriteLine(_cipher.Decrypt(args));
    }
    
    private List<string> GetArgs()
    {
        List<string> args = new List<string>();
        args.Add("instruments");
        args.Add("monarchy");
        return args;
    }
    
}