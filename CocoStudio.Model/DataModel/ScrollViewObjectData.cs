// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.ScrollViewObjectData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.Editor;
using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;

namespace CocoStudio.Model.DataModel
{
  [DataInclude(typeof (ScrollViewDirectionType))]
  [DataModelExtension(typeof (ScrollViewObject))]
  public class ScrollViewObjectData : PanelObjectData
  {
    [DefaultValue(false)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = false)]
    public bool IsBounceEnabled { get; set; }

    [JsonProperty]
    [ItemProperty]
    public SizeValue InnerNodeSize { get; set; }

    [JsonProperty]
    [ItemProperty]
    public ScrollViewDirectionType ScrollDirectionType { get; set; }

    protected override void OnDataInitialize(VisualObject vObject)
    {
      ScrollViewObject scrollViewObject = vObject as ScrollViewObject;
      if (scrollViewObject == null)
        return;
      scrollViewObject.InnerNodeSize = this.InnerNodeSize;
    }
  }
}
