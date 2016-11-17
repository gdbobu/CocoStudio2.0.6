// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.CheckBoxObjectData
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
  [DataModelExtension(typeof (CheckBoxObject))]
  public class CheckBoxObjectData : WidgetObjectData
  {
    internal static readonly ResourceItemData Default_Normal = new ResourceItemData(EnumResourceType.Default, "Default/CheckBox_Normal.png");
    internal static readonly ResourceItemData Default_Press = new ResourceItemData(EnumResourceType.Default, "Default/CheckBox_Press.png");
    internal static readonly ResourceItemData Default_Disable = new ResourceItemData(EnumResourceType.Default, "Default/CheckBox_Disable.png");
    internal static readonly ResourceItemData Default_NodeNormal = new ResourceItemData(EnumResourceType.Default, "Default/CheckBoxNode_Normal.png");
    internal static readonly ResourceItemData Default_NodeDisable = new ResourceItemData(EnumResourceType.Default, "Default/CheckBoxNode_Disable.png");
    private static readonly PointF normalImageSize = new PointF(40f, 40f);
    private ResourceItemData normalBackFileData;
    private ResourceItemData pressedBackFileData;
    private ResourceItemData disableBackFileData;
    private ResourceItemData nodeNormalFileData;
    private ResourceItemData nodeDisableFileData;

    [ItemProperty(DefaultValue = false)]
    [DefaultValue(false)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public bool CheckedState { get; set; }

    [ItemProperty(DefaultValue = true)]
    [DefaultValue(true)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public bool DisplayState { get; set; }

    [ItemProperty]
    [JsonProperty]
    public ResourceItemData NormalBackFileData
    {
      get
      {
        return this.normalBackFileData;
      }
      set
      {
        this.normalBackFileData = value;
        if (!((ResourceData) this.normalBackFileData == (ResourceData) null))
          return;
        this.normalBackFileData = CheckBoxObjectData.Default_Normal;
        this.Size = CheckBoxObjectData.normalImageSize;
      }
    }

    [ItemProperty]
    [JsonProperty]
    public ResourceItemData PressedBackFileData
    {
      get
      {
        return this.pressedBackFileData;
      }
      set
      {
        this.pressedBackFileData = value;
        if (!((ResourceData) this.pressedBackFileData == (ResourceData) null))
          return;
        this.pressedBackFileData = CheckBoxObjectData.Default_Press;
      }
    }

    [ItemProperty]
    [JsonProperty]
    public ResourceItemData DisableBackFileData
    {
      get
      {
        return this.disableBackFileData;
      }
      set
      {
        this.disableBackFileData = value;
        if (!((ResourceData) this.disableBackFileData == (ResourceData) null))
          return;
        this.disableBackFileData = CheckBoxObjectData.Default_Disable;
      }
    }

    [ItemProperty]
    [JsonProperty]
    public ResourceItemData NodeNormalFileData
    {
      get
      {
        return this.nodeNormalFileData;
      }
      set
      {
        this.nodeNormalFileData = value;
        if (!((ResourceData) this.nodeNormalFileData == (ResourceData) null))
          return;
        this.nodeNormalFileData = CheckBoxObjectData.Default_NodeNormal;
      }
    }

    [JsonProperty]
    [ItemProperty]
    public ResourceItemData NodeDisableFileData
    {
      get
      {
        return this.nodeDisableFileData;
      }
      set
      {
        this.nodeDisableFileData = value;
        if (!((ResourceData) this.nodeDisableFileData == (ResourceData) null))
          return;
        this.nodeDisableFileData = CheckBoxObjectData.Default_NodeDisable;
      }
    }

    public CheckBoxObjectData()
    {
      this.DisplayState = true;
    }

    protected override void OnDataInitialize(VisualObject vObject)
    {
      CheckBoxObject checkBoxObject = vObject as CheckBoxObject;
      if (checkBoxObject == null || (!((ResourceData) this.NormalBackFileData != (ResourceData) null) || checkBoxObject.NormalBackFileData.GetResourceData().Type == this.NormalBackFileData.Type))
        return;
      checkBoxObject.NormalBackFileData = (ResourceFile) null;
    }
  }
}
