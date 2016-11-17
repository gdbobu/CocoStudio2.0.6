// Decompiled with JetBrains decompiler
// Type: Modules.Communal.Packer.ImageInfo
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

using System;
using System.Drawing;

namespace Modules.Communal.Packer
{
  public struct ImageInfo
  {
    private string fileName;

    public string Name { get; private set; }

    public Rectangle Bounding { get; private set; }

    public bool IsRotation { get; private set; }

    public Size SourceSize { get; private set; }

    public Point SourceLocation { get; private set; }

    public string FileName
    {
      get
      {
        if (string.IsNullOrEmpty(this.fileName))
          this.fileName = ImageInfo.ConvertNameToFileName(this.Name);
        return this.fileName;
      }
    }

    public ImageInfo(string name, Rectangle bounding, Size sourceSize, Point sourceLocation, bool isRotation)
    {
      this = new ImageInfo(name, bounding, sourceSize, sourceLocation);
      this.IsRotation = isRotation;
    }

    public ImageInfo(string name, Rectangle bounding, Size sourceSize, Point sourceLocation)
    {
      this = new ImageInfo();
      this.Name = name;
      this.Bounding = bounding;
      this.SourceSize = sourceSize;
      this.SourceLocation = sourceLocation;
    }

    private static string ConvertNameToFileName(string name)
    {
      if (string.IsNullOrEmpty(name))
        throw new ArgumentException("名称不能为空");
      return name.Replace('/', '_').Replace(':', '_');
    }
  }
}
