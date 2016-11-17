using System;
using System.Reflection;

namespace CocoStudio.Model.DataModel
{
	internal class PropertyAccessorHandler
	{
		public string PropertyName
		{
			get;
			private set;
		}

		public Type PropertyType
		{
			get;
			private set;
		}

		public Func<object, object[], object> GetValue
		{
			get;
			private set;
		}

		public Action<object, object, object[]> SetValue
		{
			get;
			private set;
		}

		public PropertyAccessorHandler(PropertyInfo propInfo)
		{
			this.PropertyName = propInfo.Name;
			this.PropertyType = propInfo.PropertyType;
			if (propInfo.CanRead)
			{
				this.GetValue = new Func<object, object[], object>(propInfo.GetValue);
			}
			if (propInfo.CanWrite)
			{
				this.SetValue = new Action<object, object, object[]>(propInfo.SetValue);
			}
		}
	}
}
