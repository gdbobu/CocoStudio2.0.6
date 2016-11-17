using CocoStudio.Basic;
using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(NodeObject))]
	public class NodeObjectData : VisualObjectData
	{
		[ItemProperty(DefaultValue = EnumCallBack.None), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(EnumCallBack.None)]
		public EnumCallBack CallBackType
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = ""), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue("")]
		public string CallBackName
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = ""), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue("")]
		public string CustomClassName
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 0), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0)]
		public int Tag
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 0), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0)]
		public int ObjectIndex
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = false), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(false)]
		public bool IconVisible
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = true), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(true)]
		public bool CascadeColor
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = true), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(true)]
		public bool CascadeAlpha
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = false), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(false)]
		public bool PrePositionEnabled
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = LayoutRefrencePoint.BOTTOM_LEFT), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(LayoutRefrencePoint.BOTTOM_LEFT)]
		public LayoutRefrencePoint RefrencePoint
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public PointF PrePosition
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = false), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(false)]
		public bool PreSizeEnable
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public PointF PreSize
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public List<NodeObjectData> Children
		{
			get;
			set;
		}

		public NodeObjectData()
		{
			this.CascadeColor = true;
			this.CascadeAlpha = true;
			this.CallBackType = EnumCallBack.None;
		}
	}
}
