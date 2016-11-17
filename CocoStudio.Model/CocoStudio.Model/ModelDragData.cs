using System;

namespace CocoStudio.Model
{
	[Serializable]
	public class ModelDragData
	{
		public ModelMetaData MetaData
		{
			get;
			private set;
		}

		public ModelDragData(ModelMetaData MetaData)
		{
			this.MetaData = MetaData;
		}
	}
}
