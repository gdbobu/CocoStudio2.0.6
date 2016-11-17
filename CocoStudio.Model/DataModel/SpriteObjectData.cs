// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.SpriteObjectData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;

namespace CocoStudio.Model.DataModel
{
  [DataModelExtension(typeof (SpriteObject))]
  public class SpriteObjectData : NodeObjectData
  {
    internal static readonly ResourceItemData DefaultFile = new ResourceItemData(EnumResourceType.Default, "Default/Sprite.png");
    private static readonly PointF defaultImageSize = new PointF(46f, 46f);
    private ResourceItemData fileData;

    [ItemProperty(DefaultValue = false)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [DefaultValue(false)]
    public bool FlipX { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = false)]
    [DefaultValue(false)]
    public bool FlipY { get; set; }

    [JsonProperty]
    [ItemProperty]
    public ResourceItemData FileData
    {
      get
      {
        return this.fileData;
      }
      set
      {
        this.fileData = value;
        if (!((ResourceData) this.fileData == (ResourceData) null))
          return;
        this.fileData = SpriteObjectData.DefaultFile;
        this.Size = SpriteObjectData.defaultImageSize;
      }
    }

    protected override void OnDataInitialize(VisualObject vObject)
    {
      SpriteObject spriteObject = vObject as SpriteObject;
      if (spriteObject == null || (!((ResourceData) this.FileData != (ResourceData) null) || spriteObject.FileData.GetResourceData().Type == this.FileData.Type))
        return;
      spriteObject.FileData = (ResourceFile) null;
    }
  }
}
