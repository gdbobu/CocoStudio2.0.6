// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.SolutionItem
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Basic;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using System;
using System.Collections;

namespace CocoStudio.Projects
{
  public abstract class SolutionItem : IExtendedDataItem, ILoadController, IPublish
  {
    private Hashtable extendedProperties;

    public IDictionary ExtendedProperties
    {
      get
      {
        if (this.extendedProperties == null)
          this.extendedProperties = new Hashtable();
        return (IDictionary) this.extendedProperties;
      }
    }

    public abstract string Name { get; set; }

    public Solution ParentSolution { get; internal set; }

    public SolutionFolder ParentFolder { get; internal set; }

    public void Publish(IProgressMonitor monitor, PublishInfo info)
    {
      try
      {
        this.OnPublish(monitor, info);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Run publish failed.", ex);
      }
    }

    protected virtual void OnPublish(IProgressMonitor monitor, PublishInfo info)
    {
    }

    void ILoadController.BeginLoad()
    {
      throw new NotImplementedException();
    }

    void ILoadController.EndLoad()
    {
      throw new NotImplementedException();
    }
  }
}
