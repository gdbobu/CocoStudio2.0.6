using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Drawing;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(PanelObject))]
	public class PanelObjectData : WidgetObjectData
	{
		[ItemProperty(DefaultValue = false), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(false)]
		public bool ClipAble
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 255), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(255)]
		public int BackColorAlpha
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

		[ItemProperty(DefaultValue = 0), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0)]
		public int ComboBoxIndex
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public ColorData SingleColor
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public ColorData FirstColor
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public ColorData EndColor
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public ScaleValue ColorVector
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 0), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0)]
		public float ColorAngle
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = false), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(false)]
		public bool Scale9Enable
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 0), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0)]
		public int LeftEage
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 0), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0)]
		public int RightEage
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 0), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0)]
		public int TopEage
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 0), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0)]
		public int BottomEage
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 0), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0)]
		public int Scale9OriginX
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 0), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0)]
		public int Scale9OriginY
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 0), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0)]
		public int Scale9Width
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 0), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0)]
		public int Scale9Height
		{
			get;
			set;
		}

		public PanelObjectData()
		{
			this.BackColorAlpha = 255;
			this.SingleColor = Color.FromArgb(255, 0, 0, 0);
		}

		public PanelObjectData(bool bWithColor) : this()
		{
			this.ComboBoxIndex = (bWithColor ? 1 : 0);
		}
	}
}
