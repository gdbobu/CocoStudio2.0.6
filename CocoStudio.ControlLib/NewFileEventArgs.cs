// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.NewFileEventArgs
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

using System;

namespace CocoStudio.ControlLib
{
  public class NewFileEventArgs : EventArgs
  {
    public FileTypeInfo FileTypeInfo { get; private set; }

    public string FileName { get; private set; }

    public NewFileEventArgs(string fileName, FileTypeInfo info)
    {
      this.FileName = fileName;
      this.FileTypeInfo = info;
    }
  }
}
