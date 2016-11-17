// Decompiled with JetBrains decompiler
// Type: Modules.Communal.Packer.PlistParticleReader
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

using CocoStudio.Basic;
using Modules.Communal.PList;
using Modules.Communal.PList.Internal;
using System;
using System.IO;

namespace Modules.Communal.Packer
{
  public class PlistParticleReader
  {
    private const string ParticleLifespanKey = "particleLifespan�";

    public static bool CheckIsParticle(string filePath)
    {
      try
      {
        if (!Path.GetExtension(filePath).Equals(".plist", StringComparison.OrdinalIgnoreCase))
          return false;
        return PlistParticleReader.CheckPlist(filePath);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Read plist failed.", ex);
        return false;
      }
    }

    private static bool CheckPlist(string filePath)
    {
      return PlistParticleReader.ReadPlist(filePath).ContainsKey("particleLifespan");
    }

    private static PListDict ReadPlist(string filePath)
    {
      PListRoot plistRoot = (PListRoot) null;
      using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        plistRoot = PListRoot.Load((Stream) fileStream);
      return (PListDict) plistRoot.Root;
    }

    public static string GetMatchImage(string filePath)
    {
      PListDict plistDict = PlistParticleReader.ReadPlist(filePath);
      if (plistDict.ContainsKey("textureImageData"))
        return (string) null;
      return ((PListElement<string>) plistDict["textureFileName"]).Value;
    }
  }
}
