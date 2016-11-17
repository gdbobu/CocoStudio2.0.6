using System;

namespace CocoStudio.Model.DataModel
{
	public interface IDataConvert
	{
		object CreateViewModel();

		void SetData(object viewObject);
	}
}
