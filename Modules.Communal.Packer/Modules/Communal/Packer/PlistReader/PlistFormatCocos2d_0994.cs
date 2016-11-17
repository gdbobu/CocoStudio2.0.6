// Decompiled with JetBrains decompiler
// Type: Modules.Communal.Packer.PlistReader.PlistFormatCocos2d_0994
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
  internal class PlistFormatCocos2d_0994 : PlistImageFormat
  {
    protected override List<ImageInfo> OnToImageList(PListDict plistDict)
    {
      List<ImageInfo> imageInfoList = new List<ImageInfo>();
      foreach (KeyValuePair<string, IPListElement> keyValuePair in (Dictionary<string, IPListElement>) (plistDict["frames"] as PListDict))
      {
        string key = keyValuePair.Key;
        PListDict plistDict1 = keyValuePair.Value as PListDict;
        Rectangle rect = PlistFormatHelp.ConvertToRect(((PListElement<string>) plistDict1["frame"]).Value);
        Point point = PlistFormatHelp.ConvertToPoint(((PListElement<string>) plistDict1["offset"]).Value);
        Size size = PlistFormatHelp.ConvertToSize(((PListElement<string>) plistDict1["sourceSize"]).Value);
        int x = (size.Width - rect.Width) / 2 + point.X;
        int y = (size.Height - rect.Height) / 2 - point.Y;
        ImageInfo imageInfo = new ImageInfo(key, rect, size, new Point(x, y));
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
