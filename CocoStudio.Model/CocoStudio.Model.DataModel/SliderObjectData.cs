using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(SliderObject))]
	public class SliderObjectData : WidgetObjectData
	{
		internal static readonly ResourceItemData DefaultBackgroundFile = new ResourceItemData(EnumResourceType.Default, "Default/Slider_Back.png");

		internal static readonly ResourceItemData DefaultProgressBarFile = new ResourceItemData(EnumResourceType.Default, "Default/Slider_PressBar.png");

		internal static readonly ResourceItemData DefaultBallNormalFile = new ResourceItemData(EnumResourceType.Default, "Default/SliderNode_Normal.png");

		internal static readonly ResourceItemData DefaultBallPressedFile = new ResourceItemData(EnumResourceType.Default, "Default/SliderNode_Press.png");

		internal static readonly ResourceItemData DefaultBallDisabledFile = new ResourceItemData(EnumResourceType.Default, "Default/SliderNode_Disable.png");

		private static readonly PointF defaultBackgroundSize = new PointF(200f, 14f);

		private ResourceItemData backGroundData;

		private ResourceItemData progressBarData;

		private ResourceItemData ballNormalData;

		private ResourceItemData ballPressedData;

		private ResourceItemData ballDisabledData;

		[ItemProperty, JsonProperty]
		public ResourceItemData BackGroundData
		{
			get
			{
				return this.backGroundData;
			}
			set
			{
				this.backGroundData = value;
				if (this.backGroundData == null)
				{
					this.backGroundData = SliderObjectData.DefaultBackgroundFile;
					base.Size = SliderObjectData.defaultBackgroundSize;
				}
			}
		}

		[ItemProperty, JsonProperty]
		public ResourceItemData ProgressBarData
		{
			get
			{
				return this.progressBarData;
			}
			set
			{
				this.progressBarData = value;
				if (this.progressBarData == null)
				{
					this.progressBarData = SliderObjectData.DefaultProgressBarFile;
				}
			}
		}

		[ItemProperty, JsonProperty]
		public ResourceItemData BallNormalData
		{
			get
			{
				return this.ballNormalData;
			}
			set
			{
				this.ballNormalData = value;
				if (this.ballNormalData == null)
				{
					this.ballNormalData = SliderObjectData.DefaultBallNormalFile;
				}
			}
		}

		[ItemProperty, JsonProperty]
		public ResourceItemData BallPressedData
		{
			get
			{
				return this.ballPressedData;
			}
			set
			{
				this.ballPressedData = value;
				if (this.ballPressedData == null)
				{
					this.ballPressedData = SliderObjectData.DefaultBallPressedFile;
				}
			}
		}

		[ItemProperty, JsonProperty]
		public ResourceItemData BallDisabledData
		{
			get
			{
				return this.ballDisabledData;
			}
			set
			{
				this.ballDisabledData = value;
				if (this.ballDisabledData == null)
				{
					this.ballDisabledData = SliderObjectData.DefaultBallDisabledFile;
				}
			}
		}

		[ItemProperty(DefaultValue = 0), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0)]
		public int PercentInfo
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = true), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(true)]
		public bool DisplayState
		{
			get;
			set;
		}

		public SliderObjectData()
		{
			this.DisplayState = true;
		}

		protected override void OnDataInitialize(VisualObject vObject)
		{
			SliderObject sliderObject = vObject as SliderObject;
			if (sliderObject != null)
			{
				if (this.BackGroundData != null && sliderObject.BackGroundData.GetResourceData().Type != this.BackGroundData.Type)
				{
					sliderObject.BackGroundData = null;
				}
			}
		}
	}
}
