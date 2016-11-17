using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(TextureFrame)), DataItem(Name = "TextureFrame")]
	public class TextureFrameData : FrameData
	{
		[ItemProperty, JsonProperty]
		public ResourceItemData TextureFile
		{
			get;
			set;
		}

		public override bool FrameEquals(FrameData framedata)
		{
			TextureFrameData textureFrameData = framedata as TextureFrameData;
			bool flag = textureFrameData != null;
			return flag && base.FrameEquals(framedata) && this.TextureFile.Equals(textureFrameData.TextureFile);
		}
	}
}
