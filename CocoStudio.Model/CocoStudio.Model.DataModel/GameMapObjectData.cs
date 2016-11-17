using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(GameMapObject))]
	public class GameMapObjectData : NodeObjectData
	{
		internal static readonly ResourceItemData DefaultFile = new ResourceItemData(EnumResourceType.Default, "Default/defaultMap.tmx");

		private static readonly PointF defaultMapSize = new PointF(128f, 64f);

		private ResourceItemData fileData;

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
					this.fileData = GameMapObjectData.DefaultFile;
					base.Size = GameMapObjectData.defaultMapSize;
				}
			}
		}

		protected override void OnDataInitialize(VisualObject vObject)
		{
			GameMapObject gameMapObject = vObject as GameMapObject;
			if (gameMapObject != null)
			{
				if (this.FileData != null && gameMapObject.FileData.GetResourceData().Type != this.FileData.Type)
				{
					gameMapObject.FileData = null;
				}
			}
		}
	}
}
