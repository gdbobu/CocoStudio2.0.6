// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.GameMapObjectData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;

namespace CocoStudio.Model.DataModel
{
  [DataModelExtension(typeof (GameMapObject))]
  public class GameMapObjectData : NodeObjectData
  {
    internal static readonly ResourceItemData DefaultFile = new ResourceItemData(EnumResourceType.Default, "Default/defaultMap.tmx");
    private static readonly PointF defaultMapSize = new PointF(128f, 64f);
    private ResourceItemData fileData;

    [ItemProperty]
    [JsonProperty]
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
        this.fileData = GameMapObjectData.DefaultFile;
        this.Size = GameMapObjectData.defaultMapSize;
      }
    }

    protected override void OnDataInitialize(VisualObject vObject)
    {
      GameMapObject gameMapObject = vObject as GameMapObject;
      if (gameMapObject == null || (!((ResourceData) this.FileData != (ResourceData) null) || gameMapObject.FileData.GetResourceData().Type == this.FileData.Type))
        return;
      gameMapObject.FileData = (ResourceFile) null;
    }
  }
}
