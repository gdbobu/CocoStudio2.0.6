// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.PropertySupport
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using System;
using System.Linq.Expressions;
using System.Reflection;

namespace CocoStudio.Model.ViewModel
{
  public static class PropertySupport
  {
    public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
    {
      return PropertySupport.ExtractPropertyInfo<T>(propertyExpression).Name;
    }

    public static PropertyInfo ExtractPropertyInfo<T>(Expression<Func<T>> propertyExpression)
    {
      if (propertyExpression == null)
        throw new ArgumentNullException("propertyExpression");
      MemberExpression body = propertyExpression.Body as MemberExpression;
      if (body == null)
        throw new ArgumentException("PropertySupport_NotMemberAccessExpression_Exception", "propertyExpression");
      PropertyInfo member = body.Member as PropertyInfo;
      if (member == (PropertyInfo) null)
        throw new ArgumentException("PropertySupport_ExpressionNotProperty_Exception", "propertyExpression");
      if (member.GetGetMethod(true).IsStatic)
        throw new ArgumentException("PropertySupport_StaticExpression_Exception", "propertyExpression");
      return member;
    }
  }
}
