// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.PropertyGridUtilities
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using CocoStudio.Model;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace CocoStudio.ToolKit
{
  public class PropertyGridUtilities
  {
    public static T GetAttribute<T>(PropertyDescriptor property) where T : Attribute
    {
      return property.Attributes.OfType<T>().LastOrDefault<T>();
    }

    public static string GetDefaultPropertyName(object instance)
    {
      DefaultPropertyAttribute attribute = (DefaultPropertyAttribute) TypeDescriptor.GetAttributes(instance)[typeof (DefaultPropertyAttribute)];
      return attribute != null ? attribute.Name : (string) null;
    }

    public static PropertyDescriptorCollection GetPropertyDescriptors(object instance)
    {
      TypeConverter converter = TypeDescriptor.GetConverter(instance);
      return converter != null && converter.GetPropertiesSupported() ? converter.GetProperties(instance) : (!(instance is ICustomTypeDescriptor) ? TypeDescriptor.GetProperties(instance.GetType()) : ((ICustomTypeDescriptor) instance).GetProperties());
    }

    internal static PropertyItem CreatePropertyItem(PropertyDescriptor property, object instance)
    {
      if (property == null || (property.Attributes == null || property.Attributes.Count == 0) || (property.Attributes.OfType<CategoryAttribute>().FirstOrDefault<CategoryAttribute>() == null || string.IsNullOrEmpty(property.Attributes.OfType<CategoryAttribute>().FirstOrDefault<CategoryAttribute>().Category) || property.Attributes.OfType<BrowsableAttribute>().FirstOrDefault<BrowsableAttribute>() != null && !property.Attributes.OfType<BrowsableAttribute>().FirstOrDefault<BrowsableAttribute>().Browsable))
        return (PropertyItem) null;
      PropertyItem propertyItem = new PropertyItem();
      propertyItem.PropertyData = instance.GetType().GetProperty(property.Name, BindingFlags.Instance | BindingFlags.Public);
      foreach (Attribute attribute in property.Attributes)
      {
        if (attribute is CategoryAttribute)
          propertyItem.Calegory = (attribute as CategoryAttribute).Category;
        else if (attribute is EditorAttribute)
          propertyItem.Editor = attribute as EditorAttribute;
        else if (attribute is PropertyOrderAttribute)
          propertyItem.PropertyOrder = new int?((attribute as PropertyOrderAttribute).Order);
        else if (attribute is DisplayNameAttribute)
          propertyItem.DiaplayName = (attribute as DisplayNameAttribute).DisplayName;
        else if (attribute is DefaultValueAttribute)
          propertyItem.DefaultValueDescriptor = attribute as DefaultValueAttribute;
        else if (attribute is ValueRangeAttribute)
          propertyItem.ValueRangeDescriptor = attribute as ValueRangeAttribute;
        else if (attribute is ResourceFilterAttribute)
          propertyItem.ResourceFilterDescriptor = attribute as ResourceFilterAttribute;
      }
      propertyItem.PropertyDescriptor = property;
      propertyItem.Instance = instance;
      return propertyItem;
    }
  }
}
