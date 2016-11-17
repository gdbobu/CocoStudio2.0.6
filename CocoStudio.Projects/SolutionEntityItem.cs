// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.SolutionEntityItem
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using System;

namespace CocoStudio.Projects
{
  public abstract class SolutionEntityItem : SolutionItem, IWorkspaceObject, IExtendedDataItem, IFoldeItem, IDisposable
  {
    public override string Name
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    public FilePath ItemDirectory { get; set; }

    public FilePath BaseDirectory { get; set; }

    public void Save(IProgressMonitor monitor)
    {
      try
      {
        this.OnSave(monitor);
      }
      catch (Exception ex)
      {
        monitor.ReportError("Save failed.", ex);
      }
    }

    protected virtual void OnSave(IProgressMonitor monitor)
    {
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }
  }
}
