// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Plugins.PluginEngine
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Basic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CocoStudio.Model.Plugins
{
  public static class PluginEngine
  {
    private const string pathName = "Path�";

    public static bool IsLoaded { get; private set; }

    public static List<Assembly> AssemblyList { get; private set; }

    public static List<string> CppDLLList { get; private set; }

    public static List<Assembly> LoadPlugins()
    {
      if (!Directory.Exists(Option.AddinLocationFolder))
        throw new ArgumentNullException("The plugin path is null or the plugin path directory does not exist.");
      if (PluginEngine.IsLoaded)
        return PluginEngine.AssemblyList;
      PluginEngine.IsLoaded = true;
      PluginEngine.SetEnvironmentPath();
      string[] files = Directory.GetFiles(Option.AddinLocationFolder, "*.dll");
      PluginEngine.AssemblyList = new List<Assembly>();
      PluginEngine.CppDLLList = new List<string>();
      PluginEngine.LoadAssembly(files, PluginEngine.AssemblyList, PluginEngine.CppDLLList);
      return PluginEngine.AssemblyList;
    }

    private static void LoadAssembly(string[] fileArray, List<Assembly> assemblyList, List<string> cppdllList)
    {
      foreach (string file in fileArray)
      {
        try
        {
          if (PluginEngine.IsManagedAssembly(file))
          {
            Assembly assembly = Assembly.LoadFrom(file);
            assemblyList.Add(assembly);
          }
          else
          {
            DllAPIWrap.LoadLibrary(file);
            cppdllList.Add(file);
          }
        }
        catch (Exception ex)
        {
          LogConfig.Output.Error((object) ("load managed dll failed. The file is " + file), ex);
        }
      }
    }

    private static bool IsManagedAssembly(string fileName)
    {
      using (Stream input = (Stream) new FileStream(fileName, FileMode.Open, FileAccess.Read))
      {
        using (BinaryReader binaryReader = new BinaryReader(input))
        {
          if (input.Length < 64L)
            return false;
          input.Position = 60L;
          uint num1 = binaryReader.ReadUInt32();
          if ((int) num1 == 0)
            num1 = 128U;
          if ((long) num1 > input.Length - 256L)
            return false;
          input.Position = (long) num1;
          if ((int) binaryReader.ReadUInt32() != 17744)
            return false;
          input.Position += 20L;
          ushort num2 = binaryReader.ReadUInt16();
          if ((int) num2 != 267 && (int) num2 != 523)
            return false;
          ushort num3 = (ushort) ((long) num1 + ((int) num2 == 267 ? 232L : 248L));
          input.Position = (long) num3;
          return (int) binaryReader.ReadUInt32() != 0;
        }
      }
    }

    private static void SetEnvironmentPath()
    {
      Environment.SetEnvironmentVariable("Path", Environment.GetEnvironmentVariable("Path") + ";" + Option.AddinLocationFolder);
    }
  }
}
