using System;
using System.Collections.Generic;

namespace CocoStudio.Model.Editor
{
	public class ResourceGroupValue
	{
		private List<ResourceData> resourceDataList;

		public List<ResourceData> ResourceDataList
		{
			get
			{
				return this.resourceDataList;
			}
			set
			{
				this.resourceDataList = value;
			}
		}

		public ResourceGroupValue(List<ResourceData> resourceDataList)
		{
			this.ResourceDataList = resourceDataList;
		}
	}
}
