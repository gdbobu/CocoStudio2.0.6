// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.Event.NewProjectEventArgs
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

using System;

namespace CocoStudio.ControlLib.Event
{
  public class NewProjectEventArgs : EventArgs
  {
    public string ProjectDir { get; private set; }

    public string Name { get; private set; }

    public string ProjectFilePath { get; private set; }

    public bool IsCanceled { get; set; }

    public NewProjectEventArgs(string name, string projectDir)
    {
      this.Name = name;
      this.ProjectDir = projectDir;
      this.IsCanceled = false;
    }

    public NewProjectEventArgs(string name, string projectDir, string flashProjectFilePath)
      : this(name, projectDir)
    {
      this.ProjectFilePath = flashProjectFilePath;
      this.IsCanceled = false;
    }
  }
}
