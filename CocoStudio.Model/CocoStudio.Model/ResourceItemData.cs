using CocoStudio.Core;
using CocoStudio.Model.DataModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using System;

namespace CocoStudio.Model
{
	[DataModelExtension, DataInclude(typeof(ResourceData))]
	public class ResourceItemData : ResourceData, IDataModel, IDataConvert
	{
		private ResourceItemData()
		{
		}

		public ResourceItemData(string path) : base(path)
		{
		}

		public ResourceItemData(EnumResourceType type, string path) : base(type, path)
		{
		}

		public ResourceItemData(EnumResourceType type, string path, string plistFile) : base(type, path, plistFile)
		{
		}

		public object CreateViewModel()
		{
			return Services.ProjectOperations.CurrentResourceGroup.FindResourceItem(this);
		}

		public void SetData(object viewObject)
		{
			if (!(viewObject is ResourceItem))
			{
				throw new ArgumentException("Only support ResourceFile type.");
			}
			ResourceItem resourceItem = viewObject as ResourceItem;
			ResourceData resourceData = resourceItem.GetResourceData();
			base.Path = resourceData.Path;
			base.Type = resourceData.Type;
			base.Plist = resourceData.Plist;
		}

		internal void Update(ResourceData data)
		{
			base.Type = data.Type;
			base.Path = data.Path;
			base.Plist = data.Plist;
		}
	}
}
