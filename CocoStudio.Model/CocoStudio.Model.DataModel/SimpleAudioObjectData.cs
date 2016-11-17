using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(SimpleAudioObject))]
	public class SimpleAudioObjectData : NodeObjectData
	{
		[ItemProperty(DefaultValue = 0f), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0f)]
		public float Volume
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = false), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(false)]
		public bool Loop
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public ResourceItemData FileData
		{
			get;
			set;
		}
	}
}
