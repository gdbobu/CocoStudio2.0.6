// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.VisualObjectData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Basic;
using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.DataModel
{
  [DataModelExtension(typeof (VisualObject))]
  public class VisualObjectData : BaseObjectData, IDataInitialize
  {
    [ItemProperty]
    [JsonProperty]
    public string InnerClassName { get; set; }

    [DefaultValue(true)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = true)]
    public bool CanEdit { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 0)]
    [DefaultValue(0)]
    public int ActionTag { get; set; }

    [JsonProperty]
    [ItemProperty]
    public PointF Position { get; set; }

    [ItemProperty]
    [JsonProperty]
    public ScaleValue Scale { get; set; }

    [ItemProperty(DefaultValue = 0.0f)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [DefaultValue(0.0f)]
    public float Rotation { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 0.0f)]
    [DefaultValue(0.0f)]
    public float RotationSkewX { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 0.0f)]
    [DefaultValue(0.0f)]
    public float RotationSkewY { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [DefaultValue(0)]
    [ItemProperty(DefaultValue = 0)]
    public int ZOrder { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = true)]
    [DefaultValue(true)]
    public bool Visible { get; set; }

    [ItemProperty]
    [JsonProperty]
    public ScaleValue AnchorPoint { get; set; }

    [DefaultValue(255)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 255)]
    public int Alpha { get; set; }

    [JsonProperty]
    [ItemProperty]
    public ColorData CColor { get; set; }

    [DefaultValue(false)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = false)]
    public bool IsAutoSize { get; set; }

    [JsonProperty]
    [ItemProperty]
    public PointF Size { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = true)]
    [DefaultValue(true)]
    public bool VisibleForFrame { get; set; }

    [ItemProperty]
    [JsonProperty]
    public string FrameEvent { get; set; }

    public VisualObjectData()
    {
      this.Alpha = (int) byte.MaxValue;
      this.CanEdit = true;
      this.Visible = true;
      this.VisibleForFrame = true;
      this.Scale = new ScaleValue(1f, 1f, 0.1, -99999999.0, 99999999.0);
      this.Rotation = 0.0f;
      this.RotationSkewX = 0.0f;
      this.RotationSkewY = 0.0f;
      this.CColor = new ColorData(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
      this.Position = new PointF(0.0f, 0.0f);
    }

    public void DataInitialize(VisualObject vObject)
    {
      try
      {
        this.OnDataInitialize(vObject);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "VisualObject can not be initialize directly");
      }
    }

    protected virtual void OnDataInitialize(VisualObject vObject)
    {
    }
  }
}
