using CocoStudio.Basic;
using CocoStudio.Model.ViewModel;
using Mono.Addins;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CocoStudio.Model
{
	public class ModelManager
	{
		public IEnumerable<ModelMetaData> ModelCollection
		{
			get;
			private set;
		}

		public static ModelManager Instance
		{
			get;
			private set;
		}

		static ModelManager()
		{
			ModelManager.Instance = new ModelManager();
		}

		private ModelManager()
		{
			this.LoadModelType();
		}

		private void LoadModelType()
		{
			try
			{
				ExtensionNodeList<ModelExtensionNode> extensionNodes = AddinManager.GetExtensionNodes<ModelExtensionNode>(typeof(IModel));
				List<ModelExtensionNode> list = extensionNodes.ToList<ModelExtensionNode>();
				list.Sort();
				List<ModelMetaData> list2 = new List<ModelMetaData>();
				foreach (ModelExtensionNode current in list)
				{
					if (current.Type.IsSubclassOf(typeof(NodeObject)))
					{
						ModelMetaData item = new ModelMetaData(current);
						list2.Add(item);
					}
				}
				this.ModelCollection = list2;
			}
			catch (Exception exception)
			{
				LogConfig.Logger.Error("Load model type failed.", exception);
			}
		}
	}
}
