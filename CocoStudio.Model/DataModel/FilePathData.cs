// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.FilePathData
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Core;
using CocoStudio.Projects;
using Mono.Addins;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace CocoStudio.Model.DataModel
{
  [Extension(typeof (ISolutionPropertyData))]
  [DataModelExtension]
  public class FilePathData : BaseObjectData, ICustomDataItem, ISolutionPropertyData
  {
    [ItemProperty("Path")]
    [JsonProperty(PropertyName = "Path")]
    private string relativePath;

    public ResourceFile File { get; set; }

    private FilePathData()
    {
    }

    public FilePathData(ResourceFile resourceFile)
    {
      this.File = resourceFile;
    }

    public static implicit operator FilePathData(ResourceFile file)
    {
      return new FilePathData(file);
    }

    public DataCollection Serialize(ITypeSerializer handler)
    {
      SerializationContext serializationContext = handler.SerializationContext;
      if (this.File == null)
      {
        this.relativePath = (string) null;
      }
      else
      {
        this.relativePath = (string) this.File.FileName.ToRelative(Services.ProjectOperations.CurrentSelectedSolution.ItemDirectory);
        if ((int) Path.DirectorySeparatorChar != (int) serializationContext.DirectorySeparatorChar)
          this.relativePath = this.relativePath.Replace(Path.DirectorySeparatorChar, serializationContext.DirectorySeparatorChar);
      }
      return handler.Serialize((object) this);
    }

    public void Deserialize(ITypeSerializer handler, DataCollection data)
    {
      handler.Deserialize((object) this, data);
      this.File = Services.ProjectOperations.CurrentResourceGroup.FindResourceItem(this.relativePath) as ResourceFile;
    }
  }
}
