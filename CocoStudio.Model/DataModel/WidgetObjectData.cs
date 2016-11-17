// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.WidgetObjectData
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
  [DataModelExtension(typeof (WidgetObject))]
  [DataInclude(typeof (UISizeType))]
  public class WidgetObjectData : NodeObjectData
  {
    internal static readonly string DefaultFont = "";

    [DefaultValue(false)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = false)]
    public bool TouchEnable { get; set; }
  }
}
