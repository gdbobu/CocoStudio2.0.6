using Mono.Addins;
using System;

namespace CocoStudio.Model
{
	[TypeExtensionPoint(ExtensionAttributeType = typeof(ModelExtensionAttribute), NodeType = typeof(ModelExtensionNode))]
	public interface IModel
	{
	}
}
