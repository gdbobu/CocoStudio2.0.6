using CocoStudio.Model.Editor;
using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(BaseObject)), DataInclude(typeof(PointF)), DataInclude(typeof(SizeValue)), DataInclude(typeof(ScaleValue)), JsonObject(MemberSerialization.OptIn)]
	public class BaseObjectData : IExtendedDataItem, IDataModel
	{
		private Hashtable hashtable;

		[ItemProperty, JsonProperty]
		public string Name
		{
			get;
			set;
		}

		public IDictionary ExtendedProperties
		{
			get
			{
				if (this.hashtable == null)
				{
					this.hashtable = new Hashtable();
				}
				return this.hashtable;
			}
		}

		internal PropertyAccessorHandler[] GetProperties()
		{
			return DataTypeCache.GetProperties(base.GetType());
		}

		internal PropertyAccessorHandler[] GetResourceProperties()
		{
			return DataTypeCache.GetProperties<ResourceItemData>(base.GetType());
		}
	}
}
