// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.ListViewObjectData
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
  [DataInclude(typeof (ListViewDirectionType))]
  [DataModelExtension(typeof (ListViewObject))]
  [DataInclude(typeof (ListViewHorizontal))]
  [DataInclude(typeof (ListViewVertical))]
  public class ListViewObjectData : ScrollViewObjectData
  {
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [DefaultValue(0)]
    [ItemProperty(DefaultValue = 0)]
    public int ItemMargin { get; set; }

    [DefaultValue(ListViewDirectionType.Horizontal)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = ListViewDirectionType.Horizontal)]
    public ListViewDirectionType DirectionType { get; set; }

    [ItemProperty(DefaultValue = ListViewHorizontal.Align_Left)]
    [DefaultValue(ListViewHorizontal.Align_Left)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    public ListViewHorizontal HorizontalType { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = ListViewVertical.Align_Top)]
    [DefaultValue(ListViewVertical.Align_Top)]
    public ListViewVertical VerticalType { get; set; }

    public ListViewObjectData()
    {
      this.DirectionType = ListViewDirectionType.Horizontal;
    }
  }
}
