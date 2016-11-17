// Decompiled with JetBrains decompiler
// Type: Modules.Communal.Packer.PlistReader.PlistImageFormatFactory
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

using CocoStudio.Basic;
using Modules.Communal.Packer.PlistReader.Formates;
using Modules.Communal.PList;
using Modules.Communal.PList.Internal;
using System;

namespace Modules.Communal.Packer.PlistReader
{
  public static class PlistImageFormatFactory
  {
    public const string MetaDataName = "metadata�";

    public static PlistImageFormat CreatePlistFormat(PListDict rootPlistDict)
    {
      if (!rootPlistDict.ContainsKey("metadata"))
        return (PlistImageFormat) null;
      switch ((int) ((PListElement<long>) (rootPlistDict["metadata"] as PListDict)["format"]).Value)
      {
        case 0:
          return (PlistImageFormat) new PlistFormatCocos2d_Original();
        case 1:
          return (PlistImageFormat) new PlistFormatCocos2d_0994();
        case 2:
          return (PlistImageFormat) new PlistFormatCocos2d();
        case 3:
          return (PlistImageFormat) new PlistFormatZwoptex();
        default:
          return (PlistImageFormat) null;
      }
    }

    public static PlistImageFormat CreatePlistFormat(string plistFilePath)
    {
      try
      {
        return PlistImageFormatFactory.CreatePlistFormat(PListRoot.Load(plistFilePath).Root as PListDict);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) ex);
        return (PlistImageFormat) null;
      }
    }

    public static PlistImageFormat CreatePlistFormat(PlistFormats formate)
    {
      switch (formate)
      {
        case PlistFormats.Cocos2d:
          return (PlistImageFormat) new PlistFormatCocos2d();
        case PlistFormats.Cocos2d_0994:
          return (PlistImageFormat) new PlistFormatCocos2d_0994();
        case PlistFormats.Cocos2d_Original:
          return (PlistImageFormat) new PlistFormatCocos2d_Original();
        case PlistFormats.Zwoptex:
          return (PlistImageFormat) new PlistFormatZwoptex();
        default:
          return (PlistImageFormat) new PlistFormatCocos2d();
      }
    }
  }
}
