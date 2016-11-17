// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.SizeValue
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;

namespace CocoStudio.Model.Editor
{
  [DataModelExtension]
  [JsonObject(MemberSerialization.OptIn)]
  public sealed class SizeValue
  {
    [JsonProperty]
    [ItemProperty]
    public int Width { get; set; }

    [JsonProperty]
    [ItemProperty]
    public int Height { get; set; }

    public SizeValue()
    {
    }

    public SizeValue(int width, int height)
    {
      this.Width = width;
      this.Height = height;
    }
  }
}
