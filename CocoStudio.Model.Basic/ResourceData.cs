// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ResourceData
// Assembly: CocoStudio.Model.Basic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F2DD704-EE75-4706-B9BE-2922DAFBF03F
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.Basic.dll

using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace CocoStudio.Model
{
  [JsonObject(MemberSerialization.OptIn)]
  [DataInclude(typeof (EnumResourceType))]
  public class ResourceData
  {
    public static readonly ResourceData Empty = new ResourceData(string.Empty);

    [JsonProperty]
    [ItemProperty]
    public EnumResourceType Type { get; protected internal set; }

    [JsonProperty]
    [ItemProperty]
    public string Path { get; protected set; }

    [DefaultValue("")]
    [ItemProperty(DefaultValue = "")]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public string Plist { get; protected set; }

    protected ResourceData()
      : this(EnumResourceType.Normal, (string) null, (string) null)
    {
    }

    public ResourceData(string path)
      : this(EnumResourceType.Normal, path)
    {
    }

    public ResourceData(EnumResourceType type, string path)
      : this(type, path, string.Empty)
    {
    }

    public ResourceData(EnumResourceType type, string path, string plist)
    {
      this.Type = type;
      this.Path = path == null ? string.Empty : path;
      this.Plist = plist == null ? string.Empty : plist;
    }

    public static bool operator ==(ResourceData leftValue, ResourceData rightValue)
    {
      if (object.ReferenceEquals((object) leftValue, (object) null))
        return object.ReferenceEquals((object) rightValue, (object) null);
      return leftValue.Equals(rightValue);
    }

    public static bool operator !=(ResourceData leftValue, ResourceData rightValue)
    {
      return !(leftValue == rightValue);
    }

    public override string ToString()
    {
      return this.Path;
    }

    public List<string> GetFiles()
    {
      switch (this.Type)
      {
        case EnumResourceType.None:
          return (List<string>) null;
        case EnumResourceType.Normal:
          return new List<string>() { this.Path };
        case EnumResourceType.PlistSubImage:
          return new List<string>() { this.Plist };
        case EnumResourceType.Default:
          return new List<string>() { this.Path };
        default:
          return (List<string>) null;
      }
    }

    public bool Equals(ResourceData others)
    {
      return !(others == (ResourceData) null) && this.Type == others.Type && (string.Equals(this.Path, others.Path) && string.Equals(this.Plist, others.Plist));
    }

    public override bool Equals(object obj)
    {
      if (obj is ResourceData)
        return this.Equals((ResourceData) obj);
      return false;
    }

    public override int GetHashCode()
    {
      return this.Type.GetHashCode() ^ this.Path.GetHashCode() | this.Plist.GetHashCode();
    }
  }
}
