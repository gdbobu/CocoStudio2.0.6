using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension]
	public class TimelineActionData : BaseObjectData, ICustomDataItem
	{
		[ItemProperty, JsonProperty]
		public int Duration
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public float Speed
		{
			get;
			set;
		}

		[JsonProperty]
		public List<TimelineData> Timelines
		{
			get;
			set;
		}

		public TimelineActionData()
		{
			this.Timelines = new List<TimelineData>();
			this.Speed = 1f;
		}

		public DataCollection Serialize(ITypeSerializer handler)
		{
			DataCollection dataCollection = handler.Serialize(this);
			foreach (TimelineData current in this.Timelines)
			{
				DataNode entry = handler.SerializationContext.Serializer.Serialize(current);
				dataCollection.Add(entry);
			}
			return dataCollection;
		}

		public void Deserialize(ITypeSerializer handler, DataCollection data)
		{
			handler.Deserialize(this, data);
			foreach (DataNode dataNode in data)
			{
				DataItem dataItem = dataNode as DataItem;
				if (dataItem != null)
				{
					DataType configurationDataType = handler.SerializationContext.Serializer.DataContext.GetConfigurationDataType(dataNode.Name);
					TimelineData item = configurationDataType.Deserialize(handler.SerializationContext, null, dataItem) as TimelineData;
					this.Timelines.Add(item);
				}
			}
			base.ExtendedProperties.Clear();
		}
	}
}
