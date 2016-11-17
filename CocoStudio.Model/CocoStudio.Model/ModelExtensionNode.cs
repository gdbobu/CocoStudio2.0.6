using Mono.Addins;
using System;

namespace CocoStudio.Model
{
	public class ModelExtensionNode : TypeExtensionNode<ModelExtensionAttribute>, IComparable<ModelExtensionNode>
	{
		public int CompareTo(ModelExtensionNode other)
		{
			int result;
			if (base.Data.IsDefault && !other.Data.IsDefault)
			{
				result = -1;
			}
			else if (!base.Data.IsDefault && other.Data.IsDefault)
			{
				result = 1;
			}
			else
			{
				result = base.Data.Order.CompareTo(other.Data.Order);
			}
			return result;
		}
	}
}
