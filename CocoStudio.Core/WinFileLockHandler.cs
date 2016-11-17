// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.WinFileLockHandler
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using System;
using System.IO;

namespace CocoStudio.Core
{
  internal class WinFileLockHandler : FileLockHandler
  {
    private FileStream lockwritehandle = (FileStream) null;

    protected override bool OnLockFile(string filePath)
    {
      try
      {
        this.lockwritehandle = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
      }
      catch (Exception ex)
      {
        throw new Exception("can not lock file: ", ex);
      }
      return true;
    }

    protected override bool OnIsFileLocked(string filePath)
    {
      bool flag = false;
      try
      {
        using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.None))
        {
          flag = false;
          fileStream.Close();
        }
      }
      catch (IOException ex)
      {
        flag = true;
      }
      catch (Exception ex)
      {
        throw new Exception("can not be a lock file:", ex);
      }
      return flag;
    }

    protected override void OnReleaseLock()
    {
      using (this.lockwritehandle)
      {
        if (this.lockwritehandle == null)
          throw new FileNotFoundException("no lock to release");
        this.lockwritehandle.Close();
        this.lockwritehandle.Dispose();
      }
    }
  }
}
