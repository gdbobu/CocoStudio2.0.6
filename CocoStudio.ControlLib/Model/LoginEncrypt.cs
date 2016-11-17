// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.Model.LoginEncrypt
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

using System;
using System.Security.Cryptography;
using System.Text;

namespace CocoStudio.ControlLib.Model
{
  public class LoginEncrypt
  {
    public const string key = "E99F9354-BC29-48A2-9839-F3D0DD83CCE5";

    public static byte[] Encrypt(byte[] original, byte[] key)
    {
      TripleDESCryptoServiceProvider cryptoServiceProvider = new TripleDESCryptoServiceProvider();
      cryptoServiceProvider.Key = LoginEncrypt.MakeMD5(key);
      cryptoServiceProvider.Mode = CipherMode.ECB;
      return cryptoServiceProvider.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);
    }

    public static byte[] Decrypt(byte[] encrypted, byte[] key)
    {
      TripleDESCryptoServiceProvider cryptoServiceProvider = new TripleDESCryptoServiceProvider();
      cryptoServiceProvider.Key = LoginEncrypt.MakeMD5(key);
      cryptoServiceProvider.Mode = CipherMode.ECB;
      return cryptoServiceProvider.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
    }

    public static byte[] MakeMD5(byte[] original)
    {
      return new MD5CryptoServiceProvider().ComputeHash(original);
    }

    public static string Encrypt(string original, string key)
    {
      return Convert.ToBase64String(LoginEncrypt.Encrypt(Encoding.Default.GetBytes(original), Encoding.Default.GetBytes(key)));
    }

    public static string Decrypt(string encrypted, string key, Encoding encoding)
    {
      byte[] encrypted1 = Convert.FromBase64String(encrypted);
      byte[] bytes = Encoding.Default.GetBytes(key);
      return encoding.GetString(LoginEncrypt.Decrypt(encrypted1, bytes));
    }
  }
}
