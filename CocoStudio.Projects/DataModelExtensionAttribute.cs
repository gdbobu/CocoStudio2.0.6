// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.DataModelExtensionAttribute
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using Mono.Addins;
using System;

namespace CocoStudio.Projects
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
  public sealed class DataModelExtensionAttribute : CustomExtensionAttribute
  {
    public Type ModelType { get; private set; }

    public DataModelExtensionAttribute()
    {
    }

    public DataModelExtensionAttribute(Type modelType)
    {
      this.ModelType = modelType;
    }
  }
}
