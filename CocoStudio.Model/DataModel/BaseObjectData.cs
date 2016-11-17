// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.BaseObjectData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.Editor;
using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System.Collections;

namespace CocoStudio.Model.DataModel
{
  [DataModelExtension(typeof (BaseObject))]
  [DataInclude(typeof (PointF))]
  [DataInclude(typeof (SizeValue))]
  [DataInclude(typeof (ScaleValue))]
  [JsonObject(MemberSerialization.OptIn)]
  public class BaseObjectData : IExtendedDataItem, IDataModel
  {
    private Hashtable hashtable;

    [JsonProperty]
    [ItemProperty]
    public string Name { get; set; }

    public IDictionary ExtendedProperties
    {
      get
      {
        if (this.hashtable == null)
          this.hashtable = new Hashtable();
        return (IDictionary) this.hashtable;
      }
    }

    internal PropertyAccessorHandler[] GetProperties()
    {
      return DataTypeCache.GetProperties(this.GetType());
    }

    internal PropertyAccessorHandler[] GetResourceProperties()
    {
      return DataTypeCache.GetProperties<ResourceItemData>(this.GetType());
    }
  }
}
