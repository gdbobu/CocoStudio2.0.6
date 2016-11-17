// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Workspace
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using System.Collections.ObjectModel;

namespace CocoStudio.Projects
{
  public class Workspace : WorkspaceItem
  {
    private Workspace parent;
    private ObservableCollection<WorkspaceItem> items;

    public ObservableCollection<WorkspaceItem> Items
    {
      get
      {
        return this.items;
      }
      set
      {
        this.items = value;
      }
    }
  }
}
