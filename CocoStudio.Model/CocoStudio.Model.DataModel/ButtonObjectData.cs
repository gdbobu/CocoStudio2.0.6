using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(ButtonObject))]
	public class ButtonObjectData : WidgetObjectData
	{
		internal static readonly ResourceItemData Default_NormalFile = new ResourceItemData(EnumResourceType.Default, "Default/Button_Normal.png");

		internal static readonly ResourceItemData Default_PressedFile = new ResourceItemData(EnumResourceType.Default, "Default/Button_Press.png");

		internal static readonly ResourceItemData Default_DisabledFile = new ResourceItemData(EnumResourceType.Default, "Default/Button_Disable.png");

		private static readonly PointF normalImageSize = new PointF(46f, 36f);

		private ResourceItemData disabledFileData;

		private ResourceItemData pressedFileData;

		private ResourceItemData normalFileData;

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
		public string ButtonText
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

		[ItemProperty, JsonProperty]
		public ColorData TextColor
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public ResourceItemData DisabledFileData
		{
			get
			{
				return this.disabledFileData;
			}
			set
			{
				this.disabledFileData = value;
				if (this.disabledFileData == null)
				{
					this.disabledFileData = ButtonObjectData.Default_DisabledFile;
				}
			}
		}

		[ItemProperty, JsonProperty]
		public ResourceItemData PressedFileData
		{
			get
			{
				return this.pressedFileData;
			}
			set
			{
				this.pressedFileData = value;
				if (this.pressedFileData == null)
				{
					this.pressedFileData = ButtonObjectData.Default_PressedFile;
				}
			}
		}

		[ItemProperty, JsonProperty]
		public ResourceItemData NormalFileData
		{
			get
			{
				return this.normalFileData;
			}
			set
			{
				this.normalFileData = value;
				if (this.normalFileData == null)
				{
					this.normalFileData = ButtonObjectData.Default_NormalFile;
					if (!this.Scale9Enable)
					{
						base.Size = ButtonObjectData.normalImageSize;
					}
				}
			}
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

		[ItemProperty(DefaultValue = true), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(true)]
		public bool DisplayState
		{
			get;
			set;
		}

		public ButtonObjectData()
		{
			this.DisplayState = true;
		}

		protected override void OnDataInitialize(VisualObject vObject)
		{
			ButtonObject buttonObject = vObject as ButtonObject;
			if (buttonObject != null)
			{
				if (this.NormalFileData != null && buttonObject.NormalFileData.GetResourceData().Type != this.NormalFileData.Type)
				{
					buttonObject.NormalFileData = null;
				}
			}
		}
	}
}
