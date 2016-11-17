using CocoStudio.Model.ViewModel;
using System;
using System.ComponentModel;

namespace CocoStudio.Model
{
	public class ModelMetaData
	{
		private ModelExtensionNode extensionNode;

		public string DisplayName
		{
			get;
			private set;
		}

		internal bool IsDefault
		{
			get
			{
				return this.extensionNode.Data.IsDefault;
			}
		}

		public Type Type
		{
			get
			{
				return this.extensionNode.Type;
			}
		}

		internal ModelMetaData(ModelExtensionNode extensionNode)
		{
			this.extensionNode = extensionNode;
			Type type = extensionNode.Type;
			DisplayNameAttribute[] array = type.GetCustomAttributes(typeof(DisplayNameAttribute), true) as DisplayNameAttribute[];
			if (array.Length > 0)
			{
				this.DisplayName = array[0].DisplayName;
			}
			else
			{
				this.DisplayName = type.Name;
			}
		}

		public NodeObject CreateObject()
		{
			return this.extensionNode.CreateInstance() as NodeObject;
		}
	}
}
