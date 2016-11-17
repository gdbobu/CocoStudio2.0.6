// Decompiled with JetBrains decompiler
// Type: Gtk.SelectionDataExtend
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gtk
{
  public static class SelectionDataExtend
  {
    public static FileDropInfo GetFileArray(this SelectionData selectionData)
    {
      Encoding.UTF8.GetString(selectionData.Data);
      return new FileDropInfo((IEnumerable<string>) ((IEnumerable<string>) Encoding.UTF8.GetString(selectionData.Data).Split(new string[3]{ "\0", "\0\n", "\n" }, StringSplitOptions.None)).Where<string>((Func<string, bool>) (u => !string.IsNullOrEmpty(u))).Select<string, Uri>((Func<string, Uri>) (u => new Uri(u))).Select<Uri, string>((Func<Uri, string>) (url => url.LocalPath)).ToArray<string>());
    }
  }
}
