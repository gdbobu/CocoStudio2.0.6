// Decompiled with JetBrains decompiler
// Type: Gtk.RegexModel
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Gtk
{
  public class RegexModel
  {
    public static string ResourcePathRegex = "^[A-Za-z0-9, ._-]+$";

    public static bool IsHaveChinese(string value)
    {
      return Regex.IsMatch(value, "[\\u4e00-\\u9fa5]");
    }

    public static bool IsHasSystemReserveName(string name)
    {
      return ((IEnumerable<string>) new string[14]{ "aux", "prn", "con", "nul", "com0", "com1", "com2", "com3", "com4", "com5", "com6", "com7", "com8", "com9" }).Contains<string>(name.ToLower());
    }
  }
}
