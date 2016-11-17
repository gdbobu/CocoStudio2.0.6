using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(LoadingBarObject)), DataInclude(typeof(LoadingBarDirectionType))]
	public class LoadingBarObjectData : WidgetObjectData
	{
		internal static readonly ResourceItemData DefaultFile = new ResourceItemData(EnumResourceType.Default, "Default/LoadingBarFile.png");

		private static readonly PointF defaultImageSize = new PointF(200f, 14f);

		private ResourceItemData imageFileData;

		[ItemProperty(DefaultValue = 80), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(80)]
		public int ProgressInfo
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = LoadingBarDirectionType.Left_To_Right), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(LoadingBarDirectionType.Left_To_Right)]
		public LoadingBarDirectionType ProgressType
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public ResourceItemData ImageFileData
		{
			get
			{
				return this.imageFileData;
			}
			set
			{
				this.imageFileData = value;
				if (this.imageFileData == null)
				{
					this.imageFileData = LoadingBarObjectData.DefaultFile;
					base.Size = LoadingBarObjectData.defaultImageSize;
				}
			}
		}

		public LoadingBarObjectData()
		{
			this.ProgressInfo = 80;
		}

		protected override void OnDataInitialize(VisualObject vObject)
		{
			LoadingBarObject loadingBarObject = vObject as LoadingBarObject;
			if (loadingBarObject != null)
			{
				if (this.ImageFileData != null && loadingBarObject.ImageFileData.GetResourceData().Type != this.ImageFileData.Type)
				{
					loadingBarObject.ImageFileData = null;
				}
			}
		}
	}
}
