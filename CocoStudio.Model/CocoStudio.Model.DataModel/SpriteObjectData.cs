using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(SpriteObject))]
	public class SpriteObjectData : NodeObjectData
	{
		internal static readonly ResourceItemData DefaultFile = new ResourceItemData(EnumResourceType.Default, "Default/Sprite.png");

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
					this.fileData = SpriteObjectData.DefaultFile;
					base.Size = SpriteObjectData.defaultImageSize;
				}
			}
		}

		protected override void OnDataInitialize(VisualObject vObject)
		{
			SpriteObject spriteObject = vObject as SpriteObject;
			if (spriteObject != null)
			{
				if (this.FileData != null && spriteObject.FileData.GetResourceData().Type != this.FileData.Type)
				{
					spriteObject.FileData = null;
				}
			}
		}
	}
}
