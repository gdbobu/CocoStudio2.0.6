// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.SliderObjectData
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
  [DataModelExtension(typeof (SliderObject))]
  public class SliderObjectData : WidgetObjectData
  {
    internal static readonly ResourceItemData DefaultBackgroundFile = new ResourceItemData(EnumResourceType.Default, "Default/Slider_Back.png");
    internal static readonly ResourceItemData DefaultProgressBarFile = new ResourceItemData(EnumResourceType.Default, "Default/Slider_PressBar.png");
    internal static readonly ResourceItemData DefaultBallNormalFile = new ResourceItemData(EnumResourceType.Default, "Default/SliderNode_Normal.png");
    internal static readonly ResourceItemData DefaultBallPressedFile = new ResourceItemData(EnumResourceType.Default, "Default/SliderNode_Press.png");
    internal static readonly ResourceItemData DefaultBallDisabledFile = new ResourceItemData(EnumResourceType.Default, "Default/SliderNode_Disable.png");
    private static readonly PointF defaultBackgroundSize = new PointF(200f, 14f);
    private ResourceItemData backGroundData;
    private ResourceItemData progressBarData;
    private ResourceItemData ballNormalData;
    private ResourceItemData ballPressedData;
    private ResourceItemData ballDisabledData;

    [JsonProperty]
    [ItemProperty]
    public ResourceItemData BackGroundData
    {
      get
      {
        return this.backGroundData;
      }
      set
      {
        this.backGroundData = value;
        if (!((ResourceData) this.backGroundData == (ResourceData) null))
          return;
        this.backGroundData = SliderObjectData.DefaultBackgroundFile;
        this.Size = SliderObjectData.defaultBackgroundSize;
      }
    }

    [JsonProperty]
    [ItemProperty]
    public ResourceItemData ProgressBarData
    {
      get
      {
        return this.progressBarData;
      }
      set
      {
        this.progressBarData = value;
        if (!((ResourceData) this.progressBarData == (ResourceData) null))
          return;
        this.progressBarData = SliderObjectData.DefaultProgressBarFile;
      }
    }

    [JsonProperty]
    [ItemProperty]
    public ResourceItemData BallNormalData
    {
      get
      {
        return this.ballNormalData;
      }
      set
      {
        this.ballNormalData = value;
        if (!((ResourceData) this.ballNormalData == (ResourceData) null))
          return;
        this.ballNormalData = SliderObjectData.DefaultBallNormalFile;
      }
    }

    [JsonProperty]
    [ItemProperty]
    public ResourceItemData BallPressedData
    {
      get
      {
        return this.ballPressedData;
      }
      set
      {
        this.ballPressedData = value;
        if (!((ResourceData) this.ballPressedData == (ResourceData) null))
          return;
        this.ballPressedData = SliderObjectData.DefaultBallPressedFile;
      }
    }

    [ItemProperty]
    [JsonProperty]
    public ResourceItemData BallDisabledData
    {
      get
      {
        return this.ballDisabledData;
      }
      set
      {
        this.ballDisabledData = value;
        if (!((ResourceData) this.ballDisabledData == (ResourceData) null))
          return;
        this.ballDisabledData = SliderObjectData.DefaultBallDisabledFile;
      }
    }

    [DefaultValue(0)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 0)]
    public int PercentInfo { get; set; }

    [DefaultValue(true)]
    [ItemProperty(DefaultValue = true)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public bool DisplayState { get; set; }

    public SliderObjectData()
    {
      this.DisplayState = true;
    }

    protected override void OnDataInitialize(VisualObject vObject)
    {
      SliderObject sliderObject = vObject as SliderObject;
      if (sliderObject == null || (!((ResourceData) this.BackGroundData != (ResourceData) null) || sliderObject.BackGroundData.GetResourceData().Type == this.BackGroundData.Type))
        return;
      sliderObject.BackGroundData = (ResourceFile) null;
    }
  }
}
