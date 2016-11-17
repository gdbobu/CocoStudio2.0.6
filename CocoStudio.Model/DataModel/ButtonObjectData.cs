// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.ButtonObjectData
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
  [DataModelExtension(typeof (ButtonObject))]
  public class ButtonObjectData : WidgetObjectData
  {
    internal static readonly ResourceItemData Default_NormalFile = new ResourceItemData(EnumResourceType.Default, "Default/Button_Normal.png");
    internal static readonly ResourceItemData Default_PressedFile = new ResourceItemData(EnumResourceType.Default, "Default/Button_Press.png");
    internal static readonly ResourceItemData Default_DisabledFile = new ResourceItemData(EnumResourceType.Default, "Default/Button_Disable.png");
    private static readonly PointF normalImageSize = new PointF(46f, 36f);
    private ResourceItemData disabledFileData;
    private ResourceItemData pressedFileData;
    private ResourceItemData normalFileData;

    [DefaultValue(false)]
    [ItemProperty(DefaultValue = false)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public bool FlipX { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = false)]
    [DefaultValue(false)]
    public bool FlipY { get; set; }

    [JsonProperty]
    [ItemProperty]
    public int FontSize { get; set; }

    [JsonProperty]
    [ItemProperty]
    public string ButtonText { get; set; }

    [ItemProperty]
    [JsonProperty]
    public ResourceItemData FontResource { get; set; }

    [ItemProperty]
    [JsonProperty]
    public ColorData TextColor { get; set; }

    [JsonProperty]
    [ItemProperty]
    public ResourceItemData DisabledFileData
    {
      get
      {
        return this.disabledFileData;
      }
      set
      {
        this.disabledFileData = value;
        if (!((ResourceData) this.disabledFileData == (ResourceData) null))
          return;
        this.disabledFileData = ButtonObjectData.Default_DisabledFile;
      }
    }

    [ItemProperty]
    [JsonProperty]
    public ResourceItemData PressedFileData
    {
      get
      {
        return this.pressedFileData;
      }
      set
      {
        this.pressedFileData = value;
        if (!((ResourceData) this.pressedFileData == (ResourceData) null))
          return;
        this.pressedFileData = ButtonObjectData.Default_PressedFile;
      }
    }

    [JsonProperty]
    [ItemProperty]
    public ResourceItemData NormalFileData
    {
      get
      {
        return this.normalFileData;
      }
      set
      {
        this.normalFileData = value;
        if (!((ResourceData) this.normalFileData == (ResourceData) null))
          return;
        this.normalFileData = ButtonObjectData.Default_NormalFile;
        if (!this.Scale9Enable)
          this.Size = ButtonObjectData.normalImageSize;
      }
    }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = false)]
    [DefaultValue(false)]
    public bool Scale9Enable { get; set; }

    [DefaultValue(0)]
    [ItemProperty(DefaultValue = 0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public int LeftEage { get; set; }

    [ItemProperty(DefaultValue = 0)]
    [DefaultValue(0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public int RightEage { get; set; }

    [DefaultValue(0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 0)]
    public int TopEage { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [DefaultValue(0)]
    [ItemProperty(DefaultValue = 0)]
    public int BottomEage { get; set; }

    [DefaultValue(0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 0)]
    public int Scale9OriginX { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 0)]
    [DefaultValue(0)]
    public int Scale9OriginY { get; set; }

    [DefaultValue(0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 0)]
    public int Scale9Width { get; set; }

    [DefaultValue(0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 0)]
    public int Scale9Height { get; set; }

    [ItemProperty(DefaultValue = true)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [DefaultValue(true)]
    public bool DisplayState { get; set; }

    public ButtonObjectData()
    {
      this.DisplayState = true;
    }

    protected override void OnDataInitialize(VisualObject vObject)
    {
      ButtonObject buttonObject = vObject as ButtonObject;
      if (buttonObject == null || (!((ResourceData) this.NormalFileData != (ResourceData) null) || buttonObject.NormalFileData.GetResourceData().Type == this.NormalFileData.Type))
        return;
      buttonObject.NormalFileData = (ResourceFile) null;
    }
  }
}
