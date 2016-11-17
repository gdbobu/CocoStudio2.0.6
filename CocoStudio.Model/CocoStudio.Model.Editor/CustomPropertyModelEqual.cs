using System;
using System.Collections.Generic;

namespace CocoStudio.Model.Editor
{
	public class CustomPropertyModelEqual : IEqualityComparer<CustomPropertyModel>
	{
		public bool Equals(CustomPropertyModel x, CustomPropertyModel y)
		{
			return x.Name == y.Name;
		}

		public int GetHashCode(CustomPropertyModel obj)
		{
			return obj.Name.GetHashCode();
		}
	}
}
