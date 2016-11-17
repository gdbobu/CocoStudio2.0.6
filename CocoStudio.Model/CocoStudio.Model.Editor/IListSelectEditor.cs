using System;
using System.Collections.Generic;

namespace CocoStudio.Model.Editor
{
	public interface IListSelectEditor
	{
		List<object> GetItems(string propertyName);

		string GetDisplayBindingPath(string propertyName);
	}
}
