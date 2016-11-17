// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.PlistImageFile
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Model;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;

namespace CocoStudio.Projects
{
  public class PlistImageFile : ResourceFile
  {
    [JsonProperty(PropertyName = "Key")]
    [ItemProperty(Name = "Key")]
    private string key;

    public override ResourceItem Parent
    {
      get
      {
        return base.Parent;
      }
      internal set
      {
        if (value == null)
        {
          base.Parent = value;
        }
        else
        {
          if (!(value is PlistImageFolder))
            throw new ArgumentException("PListSubImageItem的父类必须是PlistFileItem类型");
          base.Parent = value;
        }
      }
    }

    public override string Name
    {
      get
      {
        return this.key;
      }
      protected set
      {
        throw new InvalidOperationException("Can not set name of plistImageFile.");
      }
    }

    internal override string PreviewImagePath
    {
      get
      {
        return (string) this.FileName;
      }
    }

    public override string FullPath
    {
      get
      {
        return this.Parent.FullPath;
      }
    }

    private PlistImageFile()
    {
    }

    public PlistImageFile(FilePath info, string subImageName, PlistImageFolder plistFileFolder)
    {
      this.FileName = info;
      this.Parent = (ResourceItem) plistFileFolder;
      this.key = subImageName;
    }

    public override ResourceData GetResourceData()
    {
      return new ResourceData(EnumResourceType.PlistSubImage, this.key, this.Parent.GetResourceData().Path);
    }

    protected override bool OnCheckValid()
    {
      PlistImageFolder parent = this.Parent as PlistImageFolder;
      if (parent != null)
        return parent.IsValid;
      return false;
    }
  }
}
