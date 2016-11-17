// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.LoadingBarObjectData
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
  [DataInclude(typeof (LoadingBarDirectionType))]
  [DataModelExtension(typeof (LoadingBarObject))]
  public class LoadingBarObjectData : WidgetObjectData
  {
    internal static readonly ResourceItemData DefaultFile = new ResourceItemData(EnumResourceType.Default, "Default/LoadingBarFile.png");
    private static readonly PointF defaultImageSize = new PointF(200f, 14f);
    private ResourceItemData imageFileData;

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = 80)]
    [DefaultValue(80)]
    public int ProgressInfo { get; set; }

    [DefaultValue(LoadingBarDirectionType.Left_To_Right)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
    [ItemProperty(DefaultValue = LoadingBarDirectionType.Left_To_Right)]
    public LoadingBarDirectionType ProgressType { get; set; }

    [JsonProperty]
    [ItemProperty]
    public ResourceItemData ImageFileData
    {
      get
      {
        return this.imageFileData;
      }
      set
      {
        this.imageFileData = value;
        if (!((ResourceData) this.imageFileData == (ResourceData) null))
          return;
        this.imageFileData = LoadingBarObjectData.DefaultFile;
        this.Size = LoadingBarObjectData.defaultImageSize;
      }
    }

    public LoadingBarObjectData()
    {
      this.ProgressInfo = 80;
    }

    protected override void OnDataInitialize(VisualObject vObject)
    {
      LoadingBarObject loadingBarObject = vObject as LoadingBarObject;
      if (loadingBarObject == null || (!((ResourceData) this.ImageFileData != (ResourceData) null) || loadingBarObject.ImageFileData.GetResourceData().Type == this.ImageFileData.Type))
        return;
      loadingBarObject.ImageFileData = (ResourceFile) null;
    }
  }
}
