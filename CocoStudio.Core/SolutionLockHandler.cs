// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.SolutionLockHandler
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Basic;
using System;
using System.IO;

namespace CocoStudio.Core
{
  public class SolutionLockHandler
  {
    private static string lockFolderDir = string.Empty;
    private static SolutionLockHandler solutionlockhander = (SolutionLockHandler) null;
    private FileLockHandler filelockhandler = (FileLockHandler) null;

    public string LockFolderDir
    {
      get
      {
        return SolutionLockHandler.lockFolderDir;
      }
    }

    public static SolutionLockHandler Instance
    {
      get
      {
        if (SolutionLockHandler.solutionlockhander == null)
          SolutionLockHandler.solutionlockhander = new SolutionLockHandler();
        return SolutionLockHandler.solutionlockhander;
      }
    }

    protected SolutionLockHandler()
    {
      SolutionLockHandler.lockFolderDir = Path.Combine(Option.UserCustomerConfigFolder, "LockTemp");
      if (!Directory.Exists(SolutionLockHandler.lockFolderDir))
        Directory.CreateDirectory(SolutionLockHandler.lockFolderDir);
      if (this.filelockhandler != null)
        return;
      this.filelockhandler = FileLockHandler.Create();
    }

    public bool TryLockSolution(string slnFilePath)
    {
      bool flag = false;
      string slnLockFilePath = SolutionLockHandler.getSlnLockFilePath(slnFilePath);
      try
      {
        flag = this.filelockhandler.LockFile(slnLockFilePath);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) string.Format("can not lock solution {0}", (object) slnFilePath));
      }
      return flag;
    }

    public bool IsSolutionLocked(string slnFilePath)
    {
      bool flag = false;
      string slnLockFilePath = SolutionLockHandler.getSlnLockFilePath(slnFilePath);
      try
      {
        flag = this.filelockhandler.IsFileLocked(slnLockFilePath);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Info((object) string.Format("solution {0} didn't locked ", (object) slnFilePath));
      }
      return flag;
    }

    public bool TryLockFile(string filePath)
    {
      bool flag = false;
      try
      {
        flag = this.filelockhandler.LockFile(filePath);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) string.Format("can not lock file: {0}\r\n{1}", (object) filePath, (object) ex.ToString()));
      }
      return flag;
    }

    public bool IsFileLocked(string filePath)
    {
      return this.filelockhandler.IsFileLocked(filePath);
    }

    public bool ReleaseLock()
    {
      bool flag = true;
      try
      {
        this.filelockhandler.ReleaseLock();
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) " Current solution  release lock failed!");
        flag = false;
      }
      return flag;
    }

    private static string getSlnLockFilePath(string slnFilePath)
    {
      if (!File.Exists(slnFilePath))
        throw new FileNotFoundException(string.Format("solution {0} not exists: ", (object) slnFilePath));
      slnFilePath = Path.Combine(slnFilePath);
      string md5String = FileLockHandler.GetMD5String(slnFilePath);
      return Path.Combine(SolutionLockHandler.lockFolderDir, md5String);
    }
  }
}
