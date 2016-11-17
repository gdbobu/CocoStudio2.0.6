// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.CanvasSizes
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using Gdk;
using Modules.Communal.MultiLanguage;
using System;
using System.Collections.Generic;

namespace CocoStudio.Model
{
  public static class CanvasSizes
  {
    private static List<string> sizeList;
    public static Dictionary<string, string> SizeDirctionary;

    public static List<string> SizeList
    {
      get
      {
        return CanvasSizes.sizeList;
      }
    }

    static CanvasSizes()
    {
      CanvasSizes.InitSizeList();
      CanvasSizes.SizeDirctionary = new Dictionary<string, string>();
    }

    private static void InitSizeList()
    {
      CanvasSizes.sizeList = new List<string>();
      CanvasSizes.sizeList.Add("480 * 320");
      CanvasSizes.sizeList.Add("320 * 480");
      CanvasSizes.sizeList.Add("960 * 640");
      CanvasSizes.sizeList.Add("640 * 960");
      CanvasSizes.sizeList.Add("1024 * 768");
      CanvasSizes.sizeList.Add("768 * 1024");
      CanvasSizes.sizeList.Add(LanguageInfo.MainTool_itemCustomSize);
    }

    public static string FormatString(this Size size)
    {
      return string.Format("{0} * {1}", (object) size.Width, (object) size.Height);
    }

    public static Size ConvertToSize(this string sizeStr)
    {
      return new Size((int) Convert.ToDouble(sizeStr.Substring(0, sizeStr.IndexOf("*") - 1)), (int) Convert.ToDouble(sizeStr.Substring(sizeStr.IndexOf("*") + 1)));
    }

    public static bool IsDefaultSize(string size)
    {
      return CanvasSizes.SizeList.Contains(size);
    }
  }
}
