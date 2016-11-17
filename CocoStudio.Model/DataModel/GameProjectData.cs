// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.GameProjectData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;

namespace CocoStudio.Model.DataModel
{
  [DataModelExtension]
  public class GameProjectData : BaseObjectData
  {
    [ItemProperty]
    [JsonProperty]
    public TimelineActionData Animation { get; set; }

    [ItemProperty]
    [JsonProperty]
    public NodeObjectData ObjectData { get; set; }

    public GameProjectData()
    {
      this.ObjectData = (NodeObjectData) new SingleNodeObjectData();
      this.Animation = new TimelineActionData();
    }

    public GameProjectData(NodeType type)
    {
      this.Animation = new TimelineActionData();
      switch (type)
      {
        case NodeType.Scene:
          this.ObjectData = (NodeObjectData) new SingleNodeObjectData();
          break;
        case NodeType.Layer:
          this.ObjectData = (NodeObjectData) new LayerObjectData();
          break;
        case NodeType.Node:
          this.ObjectData = (NodeObjectData) new SingleNodeObjectData();
          break;
        default:
          this.ObjectData = (NodeObjectData) new SingleNodeObjectData();
          break;
      }
      this.ObjectData.Tag = VisualObject.tag;
      this.ObjectData.Name = type.ToString();
    }
  }
}
