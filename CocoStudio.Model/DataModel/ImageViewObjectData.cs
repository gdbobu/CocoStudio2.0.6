// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.ImageViewObjectData
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
  [DataModelExtension(typeof (ImageViewObject))]
  public class ImageViewObjectData : WidgetObjectData
  {
    internal static readonly ResourceItemData DefaultFile = new ResourceItemData(EnumResourceType.Default, "Default/ImageFile.png");
    private static readonly PointF defaultImageSize = new PointF(46f, 46f);
    private ResourceItemData fileData;

    [DefaultValue(false)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = false)]
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
        this.fileData = ImageViewObjectData.DefaultFile;
        if (!this.Scale9Enable)
          this.Size = ImageViewObjectData.defaultImageSize;
      }
    }

    [ItemProperty(DefaultValue = false)]
    [DefaultValue(false)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public bool Scale9Enable { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 0)]
    [DefaultValue(0)]
    public int LeftEage { get; set; }

    [ItemProperty(DefaultValue = 0)]
    [DefaultValue(0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public int RightEage { get; set; }

    [DefaultValue(0)]
    [ItemProperty(DefaultValue = 0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public int TopEage { get; set; }

    [DefaultValue(0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 0)]
    public int BottomEage { get; set; }

    [ItemProperty(DefaultValue = 0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [DefaultValue(0)]
    public int Scale9OriginX { get; set; }

    [ItemProperty(DefaultValue = 0)]
    [DefaultValue(0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public int Scale9OriginY { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [DefaultValue(0)]
    [ItemProperty(DefaultValue = 0)]
    public int Scale9Width { get; set; }

    [ItemProperty(DefaultValue = 0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [DefaultValue(0)]
    public int Scale9Height { get; set; }

    protected override void OnDataInitialize(VisualObject vObject)
    {
      ImageViewObject imageViewObject = vObject as ImageViewObject;
      if (imageViewObject == null || (!((ResourceData) this.FileData != (ResourceData) null) || imageViewObject.FileData.GetResourceData().Type == this.FileData.Type))
        return;
      imageViewObject.FileData = (ResourceFile) null;
    }
  }
}
