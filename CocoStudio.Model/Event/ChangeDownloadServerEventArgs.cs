// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Event.ChangeDownloadServerEventArgs
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

namespace CocoStudio.Model.Event
{
  public class ChangeDownloadServerEventArgs
  {
    public string projName { get; private set; }

    public int width { get; private set; }

    public int height { get; private set; }

    public string downloadPath { get; private set; }

    public ChangeDownloadServerEventArgs(string pName, int w, int h, string dPath)
    {
      this.projName = pName;
      this.width = w;
      this.height = h;
      this.downloadPath = dPath;
    }
  }
}
