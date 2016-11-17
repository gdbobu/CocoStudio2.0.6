// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ResourceFilterAttribute
// Assembly: CocoStudio.Model.Basic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F2DD704-EE75-4706-B9BE-2922DAFBF03F
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.Basic.dll

using System;

namespace CocoStudio.Model
{
  [AttributeUsage(AttributeTargets.Property)]
  public sealed class ResourceFilterAttribute : Attribute
  {
    public string[] FileFilter { get; private set; }

    public EnumResourceType[] ResourceTypeFilter { get; private set; }

    public ResourceFilterAttribute(params string[] fileFilter)
    {
      this.FileFilter = fileFilter;
    }

    public ResourceFilterAttribute(EnumResourceType resouceType, params string[] fileFilter)
      : this(fileFilter)
    {
      this.ResourceTypeFilter = new EnumResourceType[1]
      {
        resouceType
      };
    }

    public ResourceFilterAttribute(EnumResourceType[] resoureTypeFilter, params string[] fileFilter)
      : this(fileFilter)
    {
      this.ResourceTypeFilter = resoureTypeFilter;
    }
  }
}
