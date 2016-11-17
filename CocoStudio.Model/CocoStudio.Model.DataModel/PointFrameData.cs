using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(PointFrame)), DataItem(Name = "PointFrame")]
	public class PointFrameData : FrameData
	{
		[ItemProperty, JsonProperty]
		public float X
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public float Y
		{
			get;
			set;
		}

		public override bool FrameEquals(FrameData framedata)
		{
			PointFrameData pointFrameData = framedata as PointFrameData;
			bool flag = pointFrameData != null;
			return flag && base.FrameEquals(framedata) && FrameData.IsFloatEqual(this.X, pointFrameData.X, 0.0001f) && FrameData.IsFloatEqual(this.Y, pointFrameData.Y, 0.0001f);
		}
	}
}
