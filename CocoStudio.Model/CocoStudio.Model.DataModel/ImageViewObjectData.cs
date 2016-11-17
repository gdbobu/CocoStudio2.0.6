using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(ImageViewObject))]
	public class ImageViewObjectData : WidgetObjectData
	{
		internal static readonly ResourceItemData DefaultFile = new ResourceItemData(EnumResourceType.Default, "Default/ImageFile.png");

		private static readonly PointF defaultImageSize = new PointF(46f, 46f);

		private ResourceItemData fileData;

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
		public ResourceItemData FileData
		{
			get
			{
				return this.fileData;
			}
			set
			{
				this.fileData = value;
				if (this.fileData == null)
				{
					this.fileData = ImageViewObjectData.DefaultFile;
					if (!this.Scale9Enable)
					{
						base.Size = ImageViewObjectData.defaultImageSize;
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

		protected override void OnDataInitialize(VisualObject vObject)
		{
			ImageViewObject imageViewObject = vObject as ImageViewObject;
			if (imageViewObject != null)
			{
				if (this.FileData != null && imageViewObject.FileData.GetResourceData().Type != this.FileData.Type)
				{
					imageViewObject.FileData = null;
				}
			}
		}
	}
}
