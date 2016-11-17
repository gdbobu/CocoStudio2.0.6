using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(Timeline)), DataItem(Name = "Timeline")]
	public class TimelineData : BaseObjectData, ICustomDataItem
	{
		[ItemProperty, JsonProperty]
		public int ActionTag
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public string FrameType
		{
			get;
			set;
		}

		[JsonProperty]
		public List<FrameData> Frames
		{
			get;
			set;
		}

		public TimelineData()
		{
			this.Frames = new List<FrameData>();
		}

		public DataCollection Serialize(ITypeSerializer handler)
		{
			DataCollection dataCollection = handler.Serialize(this);
			foreach (FrameData current in this.Frames)
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
				MonoDevelop.Core.Serialization.DataItem dataItem = dataNode as MonoDevelop.Core.Serialization.DataItem;
				if (dataItem != null)
				{
					DataType configurationDataType = handler.SerializationContext.Serializer.DataContext.GetConfigurationDataType(dataNode.Name);
					FrameData item = configurationDataType.Deserialize(handler.SerializationContext, null, dataItem) as FrameData;
					this.Frames.Add(item);
				}
			}
			base.ExtendedProperties.Clear();
		}
	}
}
