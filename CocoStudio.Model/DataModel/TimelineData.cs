// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.TimelineData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CocoStudio.Model.DataModel
{
  [MonoDevelop.Core.Serialization.DataItem(Name = "Timeline")]
  [DataModelExtension(typeof (Timeline))]
  public class TimelineData : BaseObjectData, ICustomDataItem
  {
    [JsonProperty]
    [ItemProperty]
    public int ActionTag { get; set; }

    [ItemProperty]
    [JsonProperty]
    public string FrameType { get; set; }

    [JsonProperty]
    public List<FrameData> Frames { get; set; }

    public TimelineData()
    {
      this.Frames = new List<FrameData>();
    }

    public DataCollection Serialize(ITypeSerializer handler)
    {
      DataCollection dataCollection = handler.Serialize((object) this);
      foreach (FrameData frame in this.Frames)
      {
        DataNode entry = handler.SerializationContext.Serializer.Serialize((object) frame);
        dataCollection.Add(entry);
      }
      return dataCollection;
    }

    public void Deserialize(ITypeSerializer handler, DataCollection data)
    {
      handler.Deserialize((object) this, data);
      foreach (DataNode dataNode in data)
      {
        MonoDevelop.Core.Serialization.DataItem dataItem = dataNode as MonoDevelop.Core.Serialization.DataItem;
        if (dataItem != null)
          this.Frames.Add(handler.SerializationContext.Serializer.DataContext.GetConfigurationDataType(dataNode.Name).Deserialize(handler.SerializationContext, (object) null, (DataNode) dataItem) as FrameData);
      }
      this.ExtendedProperties.Clear();
    }
  }
}
