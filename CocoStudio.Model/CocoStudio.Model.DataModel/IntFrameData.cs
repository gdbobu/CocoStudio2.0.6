using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(IntFrame)), DataItem(Name = "IntFrame")]
	public class IntFrameData : FrameData
	{
		[ItemProperty, JsonProperty]
		public int Value
		{
			get;
			set;
		}

		public override bool FrameEquals(FrameData framedata)
		{
			IntFrameData intFrameData = framedata as IntFrameData;
			bool flag = intFrameData != null;
			return flag && base.FrameEquals(framedata) && this.Value == intFrameData.Value;
		}
	}
}
