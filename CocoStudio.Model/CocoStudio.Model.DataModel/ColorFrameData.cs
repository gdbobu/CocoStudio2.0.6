using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(ColorFrame)), DataItem(Name = "ColorFrame")]
	public class ColorFrameData : FrameData
	{
		[ItemProperty, JsonProperty]
		public int Alpha
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public ColorData Color
		{
			get;
			set;
		}

		public override bool FrameEquals(FrameData framedata)
		{
			ColorFrameData colorFrameData = framedata as ColorFrameData;
			bool flag = colorFrameData != null;
			return flag && base.FrameEquals(framedata) && this.Alpha == colorFrameData.Alpha && this.Color.Equals(colorFrameData.Color);
		}
	}
}
