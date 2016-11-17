using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(TextFieldObject))]
	public class TextFieldObjectData : WidgetObjectData
	{
		[ItemProperty, JsonProperty]
		public ResourceItemData FontResource
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public int FontSize
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public bool IsCustomSize
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public string LabelText
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public string PlaceHolderText
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = false), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(false)]
		public bool MaxLengthEnable
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 0), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0)]
		public int MaxLengthText
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = false), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(false)]
		public bool PasswordEnable
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = "*"), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue("*")]
		public string PasswordStyleText
		{
			get;
			set;
		}

		public TextFieldObjectData()
		{
			this.IsCustomSize = true;
		}
	}
}
