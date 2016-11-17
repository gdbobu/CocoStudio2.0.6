using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CocoStudio.Model.DataModel
{
	internal static class DataTypeCache
	{
		private static Dictionary<Type, PropertyAccessorHandler[]> typeCollection;

		static DataTypeCache()
		{
			DataTypeCache.typeCollection = new Dictionary<Type, PropertyAccessorHandler[]>();
		}

		public static PropertyAccessorHandler[] GetProperties(Type type)
		{
			PropertyAccessorHandler[] result;
			PropertyAccessorHandler[] array;
			if (type == null)
			{
				result = null;
			}
			else if (DataTypeCache.typeCollection.TryGetValue(type, out array))
			{
				result = array;
			}
			else
			{
				array = DataTypeCache.CreateProperties(type);
				DataTypeCache.typeCollection.Add(type, array);
				result = array;
			}
			return result;
		}

		public static PropertyAccessorHandler[] GetProperties(Type type, string propertyName)
		{
			PropertyAccessorHandler[] properties = DataTypeCache.GetProperties(type);
			PropertyAccessorHandler[] result;
			if (properties == null)
			{
				result = properties;
			}
			else
			{
				result = (from a in properties
				where a.PropertyName == propertyName
				select a).ToArray<PropertyAccessorHandler>();
			}
			return result;
		}

		public static PropertyAccessorHandler[] GetProperties<T>(Type type)
		{
			PropertyAccessorHandler[] properties = DataTypeCache.GetProperties(type);
			PropertyAccessorHandler[] result;
			if (properties == null)
			{
				result = properties;
			}
			else
			{
				result = (from a in properties
				where a.PropertyType.Equals(typeof(T))
				select a).ToArray<PropertyAccessorHandler>();
			}
			return result;
		}

		private static PropertyAccessorHandler[] CreateProperties(Type type)
		{
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			PropertyAccessorHandler[] array = new PropertyAccessorHandler[properties.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new PropertyAccessorHandler(properties[i]);
			}
			return array;
		}
	}
}
