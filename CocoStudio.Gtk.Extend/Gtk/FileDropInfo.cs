// Decompiled with JetBrains decompiler
// Type: Gtk.FileDropInfo
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace Gtk
{
  [Serializable]
  public class FileDropInfo
  {
    public IEnumerable<string> FileArray { get; private set; }

    public FileDropInfo(string fileArray)
    {
      if (string.IsNullOrEmpty(fileArray))
        return;
      this.FileArray = (IEnumerable<string>) ((IEnumerable<string>) fileArray.Split(new string[3]
      {
        "file:///",
        "\r\n",
        "\0"
      }, StringSplitOptions.RemoveEmptyEntries)).ToList<string>();
    }

    public FileDropInfo(IEnumerable<string> filearray)
    {
      this.FileArray = filearray;
    }
  }
}
