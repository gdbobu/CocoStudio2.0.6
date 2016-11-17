using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(StringFrame)), DataItem(Name = "StringFrame")]
	public class StringFrameData : FrameData
	{
		[ItemProperty, JsonProperty]
		public string Value
		{
			get;
			set;
		}

		public override bool FrameEquals(FrameData framedata)
		{
			StringFrameData stringFrameData = framedata as StringFrameData;
			bool flag = stringFrameData != null;
			return flag && base.FrameEquals(framedata) && this.Value == stringFrameData.Value;
		}
	}
}
