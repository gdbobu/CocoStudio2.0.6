using CocoStudio.Core;
using CocoStudio.Projects;
using Mono.Addins;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.IO;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension, Extension(typeof(ISolutionPropertyData))]
	public class FilePathData : BaseObjectData, ICustomDataItem, ISolutionPropertyData
	{
		[ItemProperty("Path"), JsonProperty(PropertyName = "Path")]
		private string relativePath;

		public ResourceFile File
		{
			get;
			set;
		}

		private FilePathData()
		{
		}

		public FilePathData(ResourceFile resourceFile)
		{
			this.File = resourceFile;
		}

		public DataCollection Serialize(ITypeSerializer handler)
		{
			SerializationContext serializationContext = handler.SerializationContext;
			if (this.File == null)
			{
				this.relativePath = null;
			}
			else
			{
				this.relativePath = this.File.FileName.ToRelative(Services.ProjectOperations.CurrentSelectedSolution.ItemDirectory);
				if (Path.DirectorySeparatorChar != serializationContext.DirectorySeparatorChar)
				{
					this.relativePath = this.relativePath.Replace(Path.DirectorySeparatorChar, serializationContext.DirectorySeparatorChar);
				}
			}
			return handler.Serialize(this);
		}

		public void Deserialize(ITypeSerializer handler, DataCollection data)
		{
			handler.Deserialize(this, data);
			this.File = (Services.ProjectOperations.CurrentResourceGroup.FindResourceItem(this.relativePath) as ResourceFile);
		}

		public static implicit operator FilePathData(ResourceFile file)
		{
			return new FilePathData(file);
		}
	}
}
