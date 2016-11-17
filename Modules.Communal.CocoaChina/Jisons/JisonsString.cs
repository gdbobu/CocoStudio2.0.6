// Decompiled with JetBrains decompiler
// Type: Jisons.JisonsString
// Assembly: Modules.Communal.CocoaChina, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A2EC95C-DDE6-43D1-B2DC-127A321770D0
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocoaChina.dll

using System;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace Jisons
{
  public static class JisonsString
  {
    public static byte[] ConvertToASCII(this string str)
    {
      return new ASCIIEncoding().GetBytes(str);
    }

    public static string EncryptMD5(this string str)
    {
      return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
    }

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
  }
}
