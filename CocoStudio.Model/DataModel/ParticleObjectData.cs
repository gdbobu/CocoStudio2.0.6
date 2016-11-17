// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.ParticleObjectData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;

namespace CocoStudio.Model.DataModel
{
  [DataModelExtension(typeof (ParticleObject))]
  public class ParticleObjectData : NodeObjectData
  {
    internal static readonly ResourceItemData DefaultFile = new ResourceItemData(EnumResourceType.Default, "Default/defaultParticle.plist");
    private static readonly PointF defaultParticleSize = new PointF(0.0f, 0.0f);
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
        this.fileData = ParticleObjectData.DefaultFile;
        this.Size = ParticleObjectData.defaultParticleSize;
      }
    }
  }
}
