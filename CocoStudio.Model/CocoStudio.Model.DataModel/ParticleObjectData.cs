using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(ParticleObject))]
	public class ParticleObjectData : NodeObjectData
	{
		internal static readonly ResourceItemData DefaultFile = new ResourceItemData(EnumResourceType.Default, "Default/defaultParticle.plist");

		private static readonly PointF defaultParticleSize = new PointF(0f, 0f);

		private ResourceItemData fileData;

		[ItemProperty, JsonProperty]
		public ResourceItemData FileData
		{
			get
			{
				return this.fileData;
			}
			set
			{
				this.fileData = value;
				if (this.fileData == null)
				{
					this.fileData = ParticleObjectData.DefaultFile;
					base.Size = ParticleObjectData.defaultParticleSize;
				}
			}
		}
	}
}
