// Decompiled with JetBrains decompiler
// Type: CocoStudio.Basic.StringExtend
// Assembly: CocoStudio.Basic, Version=2.0.6.0, Culture=neutral, PublicKeyToken=null
// MVID: C06ECAA5-74FB-4433-91A5-3F5D18AA51F0
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Basic.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CocoStudio.Basic
{
  public static class StringExtend
  {
    public static string ReplaceLast(this string str, string oldStr, string newStr, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase)
    {
      newStr = newStr ?? string.Empty;
      if (!string.IsNullOrWhiteSpace(str))
      {
        int count = str.LastIndexOf(oldStr, comparisonType);
        if (count != -1)
          return new string(str.Take<char>(count).ToArray<char>()) + newStr;
      }
      return str;
    }

    public static bool IsAnyEqual(this string str, params string[] parmas)
    {
      return str.IsAnyEqual(StringComparison.InvariantCultureIgnoreCase, parmas);
    }

    public static bool IsAnyEqual(this string str, StringComparison comparison, params string[] parmas)
    {
      if (str != null)
        return ((IEnumerable<string>) parmas).FirstOrDefault<string>((Func<string, bool>) (item => item != null && item.Equals(str, comparison))) != null;
      return false;
    }

    public static bool CheckForFileName(this string fileName)
    {
      return new Regex("^[a-zA-Z]:(((\\\\(?! )[^/:*?<>\\\"|\\\\]+)+\\\\?)|(\\\\)?)\\s*$").IsMatch("C:\\" + fileName);
    }
  }
}
