// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.UnixFileLockHandler
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using Mono.Unix.Native;
using System;

namespace CocoStudio.Core
{
  internal class UnixFileLockHandler : FileLockHandler
  {
    private int flockfd = 0;
    private Flock flockhandle;

    public UnixFileLockHandler()
    {
      this.flockhandle.l_len = 0L;
      this.flockhandle.l_pid = Syscall.getpid();
      this.flockhandle.l_start = 0L;
      this.flockhandle.l_type = LockType.F_WRLCK;
      this.flockhandle.l_whence = SeekFlags.SEEK_SET;
    }

    protected override bool OnLockFile(string filepath)
    {
      this.flockhandle.l_type = LockType.F_WRLCK;
      this.flockfd = Syscall.open(filepath, OpenFlags.O_RDWR | OpenFlags.O_CREAT, FilePermissions.DEFFILEMODE);
      if (Syscall.fcntl(this.flockfd, FcntlCommand.F_SETLK, ref this.flockhandle) != -1)
        return true;
      throw new InvalidOperationException(filepath + "has already been locked!");
    }

    protected override bool OnIsFileLocked(string filePath)
    {
      bool flag = true;
      if (filePath == this.CurrLockFilePath)
        return flag;
      this.flockhandle.l_type = LockType.F_WRLCK;
      int fd = Syscall.open(filePath, OpenFlags.O_RDWR, FilePermissions.DEFFILEMODE);
      if (Syscall.fcntl(fd, FcntlCommand.F_SETLK, ref this.flockhandle) != -1)
        flag = false;
      this.flockhandle.l_type = LockType.F_UNLCK;
      Syscall.fcntl(fd, FcntlCommand.F_SETLK, ref this.flockhandle);
      return flag;
    }

    protected override void OnReleaseLock()
    {
      this.flockhandle.l_type = LockType.F_UNLCK;
      if (Syscall.fcntl(this.flockfd, FcntlCommand.F_SETLK, ref this.flockhandle) == -1)
        throw new InvalidOperationException("Release Lock File failed: " + this.CurrLockFilePath);
      Syscall.close(this.flockfd);
    }
  }
}
