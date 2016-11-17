// Decompiled with JetBrains decompiler
// Type: CocoStudio.DefaultResource.Resources
// Assembly: CocoStudio.DefaultResource, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1C398E0B-0982-410D-8B2D-68AF8E81829B
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.DefaultResource.dll

using System.IO;
using System.Reflection;

namespace CocoStudio.DefaultResource
{
  public static class Resources
  {
    private static Assembly assembly = typeof (Resources).Assembly;

    public static Stream GetResourceStream(string resourceID)
    {
      return Resources.assembly.GetManifestResourceStream(resourceID);
    }
  }
}
