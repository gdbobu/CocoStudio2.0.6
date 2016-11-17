// Decompiled with JetBrains decompiler
// Type: Modules.Communal.CocoaChina.CocoaChinaKey
// Assembly: Modules.Communal.CocoaChina, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A2EC95C-DDE6-43D1-B2DC-127A321770D0
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocoaChina.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Modules.Communal.CocoaChina
{
  public static class CocoaChinaKey
  {
    public const string Key = "cocostudio";
    public const string Secret = "da6234c991159283c88b81ef29a3febe";
    public const string CocosKey = "f2fb1076691c445a46b25e1fcc9e95f2";
    public const string CocosSecret = "3f579e7429443a3ec0a9062e27766c72";
    public const string RedirectClientID = "10";

    public static string UniversalTime
    {
      get
      {
        return CocoaChinaKey.ConvertDateTimeInt(DateTime.Now).ToString();
      }
    }

    public static int ConvertDateTimeInt(DateTime time)
    {
      DateTime localTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
      return (int) (time - localTime).TotalSeconds - 60;
    }

    public static string GetCocoaUrlEncode(this string str)
    {
      if (string.IsNullOrWhiteSpace(str))
        return string.Empty;
      str = HttpUtility.UrlEncode(str, Encoding.UTF8);
      int num1 = str.Count<char>();
      List<char> charList1 = new List<char>();
      for (int index = 0; index < num1; ++index)
      {
        char ch1 = str[index];
        if ((int) ch1 == 37)
        {
          charList1.Add(ch1);
          char ch2 = str[index + 1];
          ch2.ToString();
          List<char> charList2 = charList1;
          ch2 = str[index + 1];
          int num2 = (int) ch2.ToString().ToUpper()[0];
          charList2.Add((char) num2);
          List<char> charList3 = charList1;
          ch2 = str[index + 2];
          int num3 = (int) ch2.ToString().ToUpper()[0];
          charList3.Add((char) num3);
          index += 2;
        }
        else
          charList1.Add(ch1);
      }
      return new string(charList1.ToArray());
    }
  }
}
