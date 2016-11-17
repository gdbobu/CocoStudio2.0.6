using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension]
	public class GameProjectData : BaseObjectData
	{
		[ItemProperty, JsonProperty]
		public TimelineActionData Animation
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public NodeObjectData ObjectData
		{
			get;
			set;
		}

		public GameProjectData()
		{
			this.ObjectData = new SingleNodeObjectData();
			this.Animation = new TimelineActionData();
		}

		public GameProjectData(NodeType type)
		{
			this.Animation = new TimelineActionData();
			switch (type)
			{
			case NodeType.Scene:
				this.ObjectData = new SingleNodeObjectData();
				break;
			case NodeType.Layer:
				this.ObjectData = new LayerObjectData();
				break;
			case NodeType.Node:
				this.ObjectData = new SingleNodeObjectData();
				break;
			default:
				this.ObjectData = new SingleNodeObjectData();
				break;
			}
			this.ObjectData.Tag = VisualObject.tag;
			this.ObjectData.Name = type.ToString();
		}
	}
}
