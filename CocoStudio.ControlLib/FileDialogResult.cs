// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.FileDialogResult
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

using Xwt;

namespace CocoStudio.ControlLib
{
  public class FileDialogResult
  {
    private bool isSuccessful = true;

    public string FileName { get; set; }

    public EFileType FileType { get; set; }

    public Size Size { get; set; }

    public bool IsSuccessful
    {
      get
      {
        return this.isSuccessful;
      }
      set
      {
        this.isSuccessful = value;
      }
    }
  }
}
