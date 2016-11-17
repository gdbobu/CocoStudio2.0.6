// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.DataTypeCache
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CocoStudio.Model.DataModel
{
  internal static class DataTypeCache
  {
    private static Dictionary<Type, PropertyAccessorHandler[]> typeCollection = new Dictionary<Type, PropertyAccessorHandler[]>();

    public static PropertyAccessorHandler[] GetProperties(Type type)
    {
      if (type == (Type) null)
        return (PropertyAccessorHandler[]) null;
      PropertyAccessorHandler[] propertyAccessorHandlerArray;
      if (DataTypeCache.typeCollection.TryGetValue(type, out propertyAccessorHandlerArray))
        return propertyAccessorHandlerArray;
      PropertyAccessorHandler[] properties = DataTypeCache.CreateProperties(type);
      DataTypeCache.typeCollection.Add(type, properties);
      return properties;
    }

    public static PropertyAccessorHandler[] GetProperties(Type type, string propertyName)
    {
      PropertyAccessorHandler[] properties = DataTypeCache.GetProperties(type);
      if (properties == null)
        return properties;
      return ((IEnumerable<PropertyAccessorHandler>) properties).Where<PropertyAccessorHandler>((Func<PropertyAccessorHandler, bool>) (a => a.PropertyName == propertyName)).ToArray<PropertyAccessorHandler>();
    }

    public static PropertyAccessorHandler[] GetProperties<T>(Type type)
    {
      PropertyAccessorHandler[] properties = DataTypeCache.GetProperties(type);
      if (properties == null)
        return properties;
      return ((IEnumerable<PropertyAccessorHandler>) properties).Where<PropertyAccessorHandler>((Func<PropertyAccessorHandler, bool>) (a => a.PropertyType.Equals(typeof (T)))).ToArray<PropertyAccessorHandler>();
    }

    private static PropertyAccessorHandler[] CreateProperties(Type type)
    {
      PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
      PropertyAccessorHandler[] propertyAccessorHandlerArray = new PropertyAccessorHandler[properties.Length];
      for (int index = 0; index < propertyAccessorHandlerArray.Length; ++index)
        propertyAccessorHandlerArray[index] = new PropertyAccessorHandler(properties[index]);
      return propertyAccessorHandlerArray;
    }
  }
}
