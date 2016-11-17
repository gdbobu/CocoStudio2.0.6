using CocoStudio.Basic;
using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(VisualObject))]
	public class VisualObjectData : BaseObjectData, IDataInitialize
	{
		[ItemProperty, JsonProperty]
		public string InnerClassName
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = true), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(true)]
		public bool CanEdit
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 0), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0)]
		public int ActionTag
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public PointF Position
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public ScaleValue Scale
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 0f), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0f)]
		public float Rotation
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 0f), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0f)]
		public float RotationSkewX
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 0f), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0f)]
		public float RotationSkewY
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 0), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0)]
		public int ZOrder
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = true), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(true)]
		public bool Visible
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public ScaleValue AnchorPoint
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 255), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(255)]
		public int Alpha
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public ColorData CColor
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = false), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(false)]
		public bool IsAutoSize
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public PointF Size
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = true), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(true)]
		public bool VisibleForFrame
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public string FrameEvent
		{
			get;
			set;
		}

		public VisualObjectData()
		{
			this.Alpha = 255;
			this.CanEdit = true;
			this.Visible = true;
			this.VisibleForFrame = true;
			this.Scale = new ScaleValue(1f, 1f, 0.1, -99999999.0, 99999999.0);
			this.Rotation = 0f;
			this.RotationSkewX = 0f;
			this.RotationSkewY = 0f;
			this.CColor = new ColorData(255, 255, 255, 255);
			this.Position = new PointF(0f, 0f);
		}

		public void DataInitialize(VisualObject vObject)
		{
			try
			{
				this.OnDataInitialize(vObject);
			}
			catch (Exception var_0_0D)
			{
				LogConfig.Logger.Error("VisualObject can not be initialize directly");
			}
		}

		protected virtual void OnDataInitialize(VisualObject vObject)
		{
		}
	}
}
