// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.Events.WorkspaceItemChangeEventArgs
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Projects;

namespace CocoStudio.Core.Events
{
  public class WorkspaceItemChangeEventArgs : WorkspaceItemEventArgs
  {
    private bool reloading;

    public bool Reloading
    {
      get
      {
        return this.reloading;
      }
    }

    public WorkspaceItemChangeEventArgs(WorkspaceItem item, bool reloading)
      : base(item)
    {
      this.reloading = reloading;
    }
  }
}
