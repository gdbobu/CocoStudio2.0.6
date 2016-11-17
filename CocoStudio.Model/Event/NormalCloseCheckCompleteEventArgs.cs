// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Event.NormalCloseCheckCompleteEventArgs
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

namespace CocoStudio.Model.Event
{
  public class NormalCloseCheckCompleteEventArgs
  {
    public bool IsNormalClose { get; private set; }

    public bool IsUseBackup { get; private set; }

    public string SelectedBackupDir { get; private set; }

    public NormalCloseCheckCompleteEventArgs()
    {
      this.IsNormalClose = true;
    }

    public NormalCloseCheckCompleteEventArgs(bool isNormalClose)
    {
      this.IsNormalClose = isNormalClose;
    }

    public NormalCloseCheckCompleteEventArgs(bool isNormalClose, bool isUseBackup, string selectedBackupDir)
      : this(isNormalClose)
    {
      this.IsUseBackup = isUseBackup;
      this.SelectedBackupDir = selectedBackupDir;
    }
  }
}
