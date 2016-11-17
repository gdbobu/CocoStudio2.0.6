// Decompiled with JetBrains decompiler
// Type: Modules.Communal.Packer.PlistReader.PlistFormatCocos2d
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

using Modules.Communal.PList;
using Modules.Communal.PList.Internal;
using System.Collections.Generic;
using System.Drawing;

namespace Modules.Communal.Packer.PlistReader
{
  internal class PlistFormatCocos2d : PlistImageFormat
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
        bool isRotation = ((PListElement<bool>) plistDict1["rotated"]).Value;
        Size size = PlistFormatHelp.ConvertToSize(((PListElement<string>) plistDict1["sourceSize"]).Value);
        int x = (size.Width - rect.Width) / 2 + point.X;
        int y = (size.Height - rect.Height) / 2 - point.Y;
        ImageInfo imageInfo = new ImageInfo(key, rect, size, new Point(x, y), isRotation);
        imageInfoList.Add(imageInfo);
      }
      return imageInfoList;
    }

    protected override PListRoot OnToPlist(List<ImageInfo> imageList, Size size, string imageKey)
    {
      PListRoot plistRoot = new PListRoot();
      PListDict plistDict1 = new PListDict();
      plistRoot.Root = (IPListElement) plistDict1;
      PListDict plistDict2 = new PListDict();
      plistDict1.Add("frames", (IPListElement) plistDict2);
      foreach (ImageInfo image in imageList)
      {
        PListDict plistDict3 = new PListDict();
        plistDict2.Add(image.Name, (IPListElement) plistDict3);
        string str1 = PlistFormatHelp.ConvertToString(image.Bounding);
        plistDict3.Add("frame", (IPListElement) new PListString(str1));
        string str2 = PlistFormatHelp.ConvertToString(new Point(image.SourceLocation.X + image.Bounding.Width / 2 - image.SourceSize.Width / 2, image.SourceSize.Height / 2 - (image.SourceLocation.Y + image.Bounding.Height / 2)));
        plistDict3.Add("offset", (IPListElement) new PListString(str2));
        plistDict3.Add("rotated", (IPListElement) new PListBool(image.IsRotation));
        string str3 = PlistFormatHelp.ConvertToString(image.SourceSize);
        plistDict3.Add("sourceSize", (IPListElement) new PListString(str3));
      }
      PListDict plistDict4 = new PListDict();
      plistDict1.Add("metadata", (IPListElement) plistDict4);
      plistDict4.Add("format", (IPListElement) new PListInteger(2L));
      plistDict4.Add("textureFileName", (IPListElement) new PListString(imageKey));
      plistDict4.Add("realTextureFileName", (IPListElement) new PListString(imageKey));
      string str = "{" + (object) size.Width + "," + (object) size.Height + "}";
      plistDict4.Add("size", (IPListElement) new PListString(str));
      PListDict plistDict5 = new PListDict();
      plistDict1.Add("texture", (IPListElement) plistDict5);
      plistDict5.Add("width", (IPListElement) new PListInteger((long) size.Width));
      plistDict5.Add("height", (IPListElement) new PListInteger((long) size.Height));
      return plistRoot;
    }
  }
}
