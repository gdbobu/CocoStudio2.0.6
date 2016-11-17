// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.WrapperFactory
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.Basic;
using System;
using System.IO;
using System.Reflection;

namespace CocoStudio.EngineAdapterWrap
{
  public class WrapperFactory
  {
    private const string wraperNameSpace = "CocoStudio.EngineAdapterWrap.";
    private const string wraperPrefix = "CS";
    private const string wraperAssemblyName = "CocoStudio.EngineAdapterWrap.dll";
    private static Assembly wraperAssembly;

    static WrapperFactory()
    {
      try
      {
        WrapperFactory.wraperAssembly = Assembly.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CocoStudio.EngineAdapterWrap.dll"));
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Load wraper model assembly failed.", ex);
      }
    }

    public static CSObject CreateWarper(Type modelType)
    {
      string name = "CocoStudio.EngineAdapterWrap.CS" + modelType.Name;
      try
      {
        return Activator.CreateInstance(WrapperFactory.wraperAssembly.GetType(name)) as CSObject;
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Create CSObject failed.", ex);
        return (CSObject) null;
      }
    }
  }
}
