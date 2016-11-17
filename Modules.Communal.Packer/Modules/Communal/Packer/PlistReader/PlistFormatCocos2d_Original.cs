// Decompiled with JetBrains decompiler
// Type: Modules.Communal.Packer.PlistReader.PlistFormatCocos2d_Original
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
  internal class PlistFormatCocos2d_Original : PlistImageFormat
  {
    protected override List<ImageInfo> OnToImageList(PListDict plistDict)
    {
      List<ImageInfo> imageInfoList = new List<ImageInfo>();
      foreach (KeyValuePair<string, IPListElement> keyValuePair in (Dictionary<string, IPListElement>) (plistDict["frames"] as PListDict))
      {
        string key = keyValuePair.Key;
        PListDict plistDict1 = keyValuePair.Value as PListDict;
        int width = (int) ((PListElement<long>) plistDict1["width"]).Value;
        int height = (int) ((PListElement<long>) plistDict1["height"]).Value;
        Rectangle bounding = new Rectangle((int) ((PListElement<long>) plistDict1["x"]).Value, (int) ((PListElement<long>) plistDict1["y"]).Value, width, height);
        Size sourceSize = new Size((int) ((PListElement<long>) plistDict1["originalWidth"]).Value, (int) ((PListElement<long>) plistDict1["originalHeight"]).Value);
        int num1 = (int) ((PListElement<double>) plistDict1["offsetX"]).Value;
        int num2 = (int) ((PListElement<double>) plistDict1["offsetY"]).Value;
        Point sourceLocation = new Point((sourceSize.Width - bounding.Width) / 2 + num1, (sourceSize.Height - bounding.Height) / 2 - num2);
        ImageInfo imageInfo = new ImageInfo(key, bounding, sourceSize, sourceLocation);
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
