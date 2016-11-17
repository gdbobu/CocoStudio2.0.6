using CocoStudio.Projects;
using System;
using System.IO;
using System.Linq;

namespace CocoStudio.Model.Editor
{
	internal static class ResourceFilterAttributeExtend
	{
		public static bool CheckResource(this ResourceFilterAttribute attribute, ResourceFile resourceFile)
		{
			bool result;
			if (resourceFile == null)
			{
				result = false;
			}
			else
			{
				ResourceData resourceData = resourceFile.GetResourceData();
				if (attribute.ResourceTypeFilter != null)
				{
					if (!attribute.ResourceTypeFilter.Contains(resourceData.Type))
					{
						result = false;
						return result;
					}
				}
				string text = Path.GetExtension(resourceData.Path);
				if (text.Length > 1)
				{
					text = text.Substring(1);
				}
				result = attribute.FileFilter.Contains(text);
			}
			return result;
		}
	}
}
