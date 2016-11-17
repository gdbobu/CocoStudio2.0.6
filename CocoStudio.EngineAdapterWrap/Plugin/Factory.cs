// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.Plugin.Factory
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CocoStudio.EngineAdapterWrap.Plugin
{
  public class Factory
  {
    public const string headSetMethod = "CS_Set";
    public const string headGetMethod = "CS_Get";
    public const string CustomWidgetProperName = "CustomWidgetInstance";
    private static MethodInfo[] methods;
    private static List<MethodType> MethodValueList;

    public static List<MethodType> CreateMethodList(object model)
    {
      try
      {
        Factory.MethodValueList = new List<MethodType>();
        PropertyInfo property = model.GetType().GetProperty("CustomWidgetInstance");
        if (property != (PropertyInfo) null)
        {
          object model1 = property.GetValue(model, (object[]) null);
          if (model1 != null)
          {
            Factory.methods = model1.GetType().GetMethods();
            foreach (MethodInfo method in Factory.methods)
              Factory.TypeDetection(method, model1);
          }
        }
      }
      catch (Exception)
      {
      }
      return Factory.MethodValueList;
    }

    public static void TypeDetection(MethodInfo method, object model)
    {
      method.GetParameters();
      Type returnType1 = method.ReturnType;
      int num = ((IEnumerable<ParameterInfo>) method.GetParameters()).Count<ParameterInfo>();
      bool genericParameters = method.ContainsGenericParameters;
      string name = method.Name;
      if (name.Length <= "CS_Set".Length || (!(name.Substring(0, "CS_Set".Length) == "CS_Set") || num != 1 || genericParameters))
        return;
      string getName = string.Format("{0}{1}", (object) "CS_Get", (object) name.Substring("CS_Set".Length, name.Length - "CS_Set".Length));
      List<MethodInfo> list = ((IEnumerable<MethodInfo>) Factory.methods).Where<MethodInfo>((Func<MethodInfo, bool>) (n => n.Name == getName)).ToList<MethodInfo>();
      if (list.Count > 0)
      {
        Type returnType2 = list[0].ReturnType;
        Type parameterType = method.GetParameters()[0].ParameterType;
        if (returnType2 == parameterType)
        {
          object obj = model.GetType().GetMethod(getName).Invoke(model, (object[]) null);
          Factory.MethodValueList.Add(new MethodType()
          {
            MethodName = name.Substring("CS_Set".Length, name.Length - "CS_Set".Length),
            Type = returnType2,
            MethodValue = obj,
            MethodObject = model
          });
        }
      }
    }
  }
}
