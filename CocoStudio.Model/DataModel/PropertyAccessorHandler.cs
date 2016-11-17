// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.PropertyAccessorHandler
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using System;
using System.Reflection;

namespace CocoStudio.Model.DataModel
{
  internal class PropertyAccessorHandler
  {
    public string PropertyName { get; private set; }

    public Type PropertyType { get; private set; }

    public Func<object, object[], object> GetValue { get; private set; }

    public Action<object, object, object[]> SetValue { get; private set; }

    public PropertyAccessorHandler(PropertyInfo propInfo)
    {
      this.PropertyName = propInfo.Name;
      this.PropertyType = propInfo.PropertyType;
      if (propInfo.CanRead)
        this.GetValue = new Func<object, object[], object>(propInfo.GetValue);
      if (!propInfo.CanWrite)
        return;
      this.SetValue = new Action<object, object, object[]>(propInfo.SetValue);
    }
  }
}
