// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.Commands.CommandRunArgs
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using System;

namespace CocoStudio.Core.Commands
{
  public class CommandRunArgs : EventArgs
  {
    public object DataItem { get; private set; }

    internal CommandRunArgs(object data)
    {
      this.DataItem = data;
    }
  }
}
