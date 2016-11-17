// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.TimelineActionData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CocoStudio.Model.DataModel
{
  [DataModelExtension]
  public class TimelineActionData : BaseObjectData, ICustomDataItem
  {
    [ItemProperty]
    [JsonProperty]
    public int Duration { get; set; }

    [JsonProperty]
    [ItemProperty]
    public float Speed { get; set; }

    [JsonProperty]
    public List<TimelineData> Timelines { get; set; }

    public TimelineActionData()
    {
      this.Timelines = new List<TimelineData>();
      this.Speed = 1f;
    }

    public DataCollection Serialize(ITypeSerializer handler)
    {
      DataCollection dataCollection = handler.Serialize((object) this);
      foreach (TimelineData timeline in this.Timelines)
      {
        DataNode entry = handler.SerializationContext.Serializer.Serialize((object) timeline);
        dataCollection.Add(entry);
      }
      return dataCollection;
    }

    public void Deserialize(ITypeSerializer handler, DataCollection data)
    {
      handler.Deserialize((object) this, data);
      foreach (DataNode dataNode in data)
      {
        DataItem dataItem = dataNode as DataItem;
        if (dataItem != null)
          this.Timelines.Add(handler.SerializationContext.Serializer.DataContext.GetConfigurationDataType(dataNode.Name).Deserialize(handler.SerializationContext, (object) null, (DataNode) dataItem) as TimelineData);
      }
      this.ExtendedProperties.Clear();
    }
  }
}
