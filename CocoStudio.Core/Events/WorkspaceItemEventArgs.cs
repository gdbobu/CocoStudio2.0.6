// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.Events.WorkspaceItemEventArgs
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Projects;
using System;

namespace CocoStudio.Core.Events
{
  public class WorkspaceItemEventArgs : EventArgs
  {
    private WorkspaceItem item;

    public WorkspaceItem Item
    {
      get
      {
        return this.item;
      }
    }

    public WorkspaceItemEventArgs(WorkspaceItem item)
    {
      this.item = item;
    }
  }
}
