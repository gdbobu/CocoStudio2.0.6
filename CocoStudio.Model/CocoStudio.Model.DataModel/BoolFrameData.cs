using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(BoolFrame)), DataItem(Name = "BoolFrame")]
	public class BoolFrameData : FrameData
	{
		[ItemProperty, JsonProperty]
		public bool Value
		{
			get;
			set;
		}

		public override bool FrameEquals(FrameData framedata)
		{
			BoolFrameData boolFrameData = framedata as BoolFrameData;
			bool flag = boolFrameData != null;
			return flag && base.FrameEquals(framedata) && this.Value == boolFrameData.Value;
		}
	}
}
