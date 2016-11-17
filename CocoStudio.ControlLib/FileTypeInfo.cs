// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.FileTypeInfo
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

using Xwt;
using Xwt.Drawing;

namespace CocoStudio.ControlLib
{
  public class FileTypeInfo
  {
    public Image Icon { get; set; }

    public EFileType FileType { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Extension { get; set; }

    public Size Size { get; set; }

    public string DisplayName { get; private set; }

    public FileTypeInfo(Image img, string name, EFileType filetype, string extension, string displayName)
    {
      this.Icon = img;
      this.Name = name;
      this.FileType = filetype;
      this.Extension = extension;
      this.DisplayName = displayName;
    }
  }
}
