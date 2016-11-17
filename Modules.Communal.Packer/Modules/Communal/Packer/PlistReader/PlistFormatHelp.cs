// Decompiled with JetBrains decompiler
// Type: Modules.Communal.Packer.PlistReader.PlistFormatHelp
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

using System;
using System.Drawing;

namespace Modules.Communal.Packer.PlistReader
{
  public static class PlistFormatHelp
  {
    public static Rectangle ConvertToRect(string plistString)
    {
      int num1 = plistString.IndexOf('{');
      int num2 = 0;
      int index;
      for (index = 0; index < plistString.Length; ++index)
      {
        if ((int) plistString[index] == 125)
          ++num2;
        if (num2 == 3)
          break;
      }
      int num3 = index;
      if (num1 < 0 || num2 != 3)
        throw new FormatException("大括号不匹配," + plistString);
      plistString = plistString.Substring(num1 + 1, num3 - num1 - 1);
      int startIndex = plistString.IndexOf('}');
      if (startIndex < 0)
        throw new FormatException("大括号不匹配," + plistString);
      int length = plistString.IndexOf(',', startIndex);
      if (length < 0)
        throw new FormatException("大括号不匹配," + plistString);
      return new Rectangle(PlistFormatHelp.ConvertToPoint(plistString.Substring(0, length)), PlistFormatHelp.ConvertToSize(plistString.Substring(length + 1, plistString.Length - length - 1)));
    }

    public static Point ConvertToPoint(string plistString)
    {
      string[] strArray = PlistFormatHelp.SplitWithForm(plistString);
      return new Point(Convert.ToInt32(strArray[0]), Convert.ToInt32(strArray[1]));
    }

    public static Size ConvertToSize(string plistString)
    {
      string[] strArray = PlistFormatHelp.SplitWithForm(plistString);
      return new Size(Convert.ToInt32(strArray[0]), Convert.ToInt32(strArray[1]));
    }

    private static string[] SplitWithForm(string plistString)
    {
      int num1 = plistString.IndexOf('{');
      int num2 = plistString.IndexOf('}');
      if (num1 < 0 || num2 < 0 || num1 > num2)
        throw new FormatException("大括号不匹配," + plistString);
      string str = plistString.Substring(num1 + 1, num2 - num1 - 1);
      if (str.Length == 0)
        throw new FormatException("大括号内没有内容," + plistString);
      if (str.IndexOf('{') != -1 || str.IndexOf('}') != -1)
        throw new FormatException("大括号不匹配," + plistString);
      string[] strArray = str.Split(',');
      if (strArray.Length != 2 || strArray[0].Length == 0 || strArray[1].Length == 0)
        throw new FormatException("," + plistString);
      return strArray;
    }

    public static string ConvertToString(Size size)
    {
      return "{" + (object) size.Width + "," + (object) size.Height + "}";
    }

    public static string ConvertToString(Point point)
    {
      return "{" + (object) point.X + "," + (object) point.Y + "}";
    }

    public static string ConvertToString(Rectangle rect)
    {
      return "{" + PlistFormatHelp.ConvertToString(rect.Location) + "," + PlistFormatHelp.ConvertToString(rect.Size) + "}";
    }
  }
}
