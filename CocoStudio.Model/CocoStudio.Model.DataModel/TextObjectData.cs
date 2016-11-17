using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(TextObject)), DataInclude(typeof(TextHorizontalType)), DataInclude(typeof(TextVerticalType))]
	public class TextObjectData : WidgetObjectData
	{
		[ItemProperty(DefaultValue = false), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(false)]
		public bool FlipX
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = false), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(false)]
		public bool FlipY
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
		public string LabelText
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = false), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(false)]
		public bool IsCustomSize
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public ResourceItemData FontResource
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = false), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(false)]
		public bool TouchScaleChangeAble
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = TextHorizontalType.HT_Left), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(TextHorizontalType.HT_Left)]
		public TextHorizontalType HorizontalAlignmentType
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = TextVerticalType.VT_Top), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(TextVerticalType.VT_Top)]
		public TextVerticalType VerticalAlignmentType
		{
			get;
			set;
		}

		public TextObjectData()
		{
			this.IsCustomSize = false;
		}

		protected override void OnDataInitialize(VisualObject vObject)
		{
			TextObject textObject = vObject as TextObject;
			if (textObject != null)
			{
				if ((this.IsCustomSize && this.FontResource != null && textObject.FontResource.GetResourceData().Type == this.FontResource.Type) || !this.IsCustomSize)
				{
					textObject.Size = base.Size;
				}
			}
		}
	}
}
