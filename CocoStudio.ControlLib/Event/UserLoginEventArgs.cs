// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.Event.UserLoginEventArgs
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

using System;

namespace CocoStudio.ControlLib.Event
{
  public class UserLoginEventArgs : EventArgs
  {
    public string UserTtitle { get; private set; }

    public string UserName { get; private set; }

    public string UserPassword { get; private set; }

    public UserLoginEventArgs(string title, string name, string password)
    {
      this.UserTtitle = title;
      this.UserName = name;
      this.UserPassword = password;
    }
  }
}
