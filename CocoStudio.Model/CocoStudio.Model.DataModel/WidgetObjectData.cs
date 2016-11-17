using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(WidgetObject)), DataInclude(typeof(UISizeType))]
	public class WidgetObjectData : NodeObjectData
	{
		internal static readonly string DefaultFont = "";

		[ItemProperty(DefaultValue = false), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(false)]
		public bool TouchEnable
		{
			get;
			set;
		}
	}
}
