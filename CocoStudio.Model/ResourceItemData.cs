// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ResourceItemData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Core;
using CocoStudio.Model.DataModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using System;

namespace CocoStudio.Model
{
  [DataModelExtension]
  [DataInclude(typeof (ResourceData))]
  public class ResourceItemData : ResourceData, IDataModel, IDataConvert
  {
    private ResourceItemData()
    {
    }

    public ResourceItemData(string path)
      : base(path)
    {
    }

    public ResourceItemData(EnumResourceType type, string path)
      : base(type, path)
    {
    }

    public ResourceItemData(EnumResourceType type, string path, string plistFile)
      : base(type, path, plistFile)
    {
    }

    public object CreateViewModel()
    {
      return (object) Services.ProjectOperations.CurrentResourceGroup.FindResourceItem((ResourceData) this);
    }

    public void SetData(object viewObject)
    {
      if (!(viewObject is ResourceItem))
        throw new ArgumentException("Only support ResourceFile type.");
      ResourceData resourceData = (viewObject as ResourceItem).GetResourceData();
      this.Path = resourceData.Path;
      this.Type = resourceData.Type;
      this.Plist = resourceData.Plist;
    }

    internal void Update(ResourceData data)
    {
      this.Type = data.Type;
      this.Path = data.Path;
      this.Plist = data.Plist;
    }
  }
}
