// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.FileLockHandler
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using MonoDevelop.Core;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CocoStudio.Core
{
  internal class FileLockHandler : IDisposable
  {
    private string lockfilepath = string.Empty;

    public string CurrLockFilePath
    {
      get
      {
        return this.lockfilepath;
      }
    }

    protected FileLockHandler()
    {
    }

    public static FileLockHandler Create()
    {
      if (Platform.IsWindows)
        return (FileLockHandler) new WinFileLockHandler();
      return (FileLockHandler) new UnixFileLockHandler();
    }

    public bool LockFile(string filepath)
    {
      bool flag = this.OnLockFile(filepath);
      this.lockfilepath = filepath;
      return flag;
    }

    protected virtual bool OnLockFile(string filepath)
    {
      return false;
    }

    public bool IsFileLocked(string filePath)
    {
      if (!File.Exists(filePath))
        throw new FileNotFoundException(filePath);
      return this.OnIsFileLocked(filePath);
    }

    protected virtual bool OnIsFileLocked(string filePath)
    {
      return false;
    }

    public void ReleaseLock()
    {
      if (!File.Exists(this.lockfilepath))
        throw new FileNotFoundException("Locked File in Handler Not Found: ", this.lockfilepath);
      this.OnReleaseLock();
      File.Delete(this.lockfilepath);
      this.lockfilepath = string.Empty;
    }

    protected virtual void OnReleaseLock()
    {
    }

    public static string GetMD5String(string filepath)
    {
      filepath = Path.Combine(filepath);
      byte[] hash = MD5.Create().ComputeHash(Encoding.Default.GetBytes(filepath));
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < hash.Length; ++index)
        stringBuilder.Append(hash[index].ToString("x2"));
      return stringBuilder.ToString();
    }

    public void Dispose()
    {
      try
      {
        this.ReleaseLock();
      }
      catch (Exception ex)
      {
      }
    }
  }
}
