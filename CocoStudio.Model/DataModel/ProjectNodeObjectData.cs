// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.ProjectNodeObjectData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;

namespace CocoStudio.Model.DataModel
{
  [DataModelExtension(typeof (ProjectNodeObject))]
  public class ProjectNodeObjectData : NodeObjectData
  {
    [ItemProperty]
    [JsonProperty]
    public ResourceItemData FileData { get; set; }
  }
}
