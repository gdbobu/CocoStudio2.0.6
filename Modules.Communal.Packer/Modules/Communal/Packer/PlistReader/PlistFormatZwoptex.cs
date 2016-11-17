// Decompiled with JetBrains decompiler
// Type: Modules.Communal.Packer.PlistReader.PlistFormatZwoptex
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

using Modules.Communal.PList;
using Modules.Communal.PList.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Modules.Communal.Packer.PlistReader
{
  internal class PlistFormatZwoptex : PlistImageFormat
  {
    protected override List<ImageInfo> OnToImageList(PListDict plistDict)
    {
      List<ImageInfo> imageInfoList = new List<ImageInfo>();
      foreach (KeyValuePair<string, IPListElement> keyValuePair in (Dictionary<string, IPListElement>) (plistDict["frames"] as PListDict))
      {
        string key = keyValuePair.Key;
        PListDict plistDict1 = keyValuePair.Value as PListDict;
        Rectangle rect1 = PlistFormatHelp.ConvertToRect(((PListElement<string>) plistDict1["spriteColorRect"]).Value);
        Rectangle rect2 = PlistFormatHelp.ConvertToRect(((PListElement<string>) plistDict1["textureRect"]).Value);
        Size size = PlistFormatHelp.ConvertToSize(((PListElement<string>) plistDict1["spriteSourceSize"]).Value);
        bool isRotation = ((PListElement<bool>) plistDict1["textureRotated"]).Value;
        if (isRotation)
        {
          int width = rect2.Width;
          rect2.Width = rect2.Height;
          rect2.Height = width;
        }
        ImageInfo imageInfo = new ImageInfo(key, rect2, size, rect1.Location, isRotation);
        imageInfoList.Add(imageInfo);
      }
      return imageInfoList;
    }

    protected override PListRoot OnToPlist(List<ImageInfo> imageList, Size size, string imageKey)
    {
      throw new NotImplementedException();
    }
  }
}
