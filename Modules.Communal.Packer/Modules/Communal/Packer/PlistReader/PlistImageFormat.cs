// Decompiled with JetBrains decompiler
// Type: Modules.Communal.Packer.PlistReader.PlistImageFormat
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

using CocoStudio.Basic;
using Modules.Communal.PList;
using Modules.Communal.PList.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Modules.Communal.Packer.PlistReader
{
  public abstract class PlistImageFormat
  {
    protected const string framesName = "frames�";

    public List<ImageInfo> ToImageList(PListDict plistDict)
    {
      try
      {
        return this.OnToImageList(plistDict);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) ("解析Plist文件出错:" + (object) ex));
        return (List<ImageInfo>) null;
      }
    }

    public PListRoot ToPlist(List<ImageInfo> imageList, Size size, string imageKey)
    {
      try
      {
        return this.OnToPlist(imageList, size, imageKey);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) ("转换为Plist文件出错:" + (object) ex));
        return (PListRoot) null;
      }
    }

    public string GetImageFilePath(string plistFilePath)
    {
      try
      {
        return this.OnGetImageFilePath(plistFilePath);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "GetImageFilePath failed", ex);
        return (string) null;
      }
    }

    protected abstract PListRoot OnToPlist(List<ImageInfo> imageList, Size size, string imageKey);

    protected abstract List<ImageInfo> OnToImageList(PListDict plistDict);

    protected virtual string OnGetImageFilePath(string plistFilePath)
    {
      return this.GetTextureFileName(plistFilePath) ?? this.GetSameNameImageFile(plistFilePath);
    }

    private string GetTextureFileName(string plistFilePath)
    {
      try
      {
        string path2 = ((PListElement<string>) ((PListRoot.Load(plistFilePath).Root as PListDict)["metadata"] as PListDict)["textureFileName"]).Value;
        return Path.Combine(Path.GetDirectoryName(plistFilePath), path2);
      }
      catch
      {
        return (string) null;
      }
    }

    private string GetSameNameImageFile(string plistFilePath)
    {
      string path1 = Path.ChangeExtension(plistFilePath, ".png");
      if (File.Exists(path1))
        return path1;
      string path2 = Path.ChangeExtension(plistFilePath, ".jpg");
      if (File.Exists(path2))
        return path2;
      return path1;
    }
  }
}
