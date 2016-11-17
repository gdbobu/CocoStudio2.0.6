using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(Frame)), DataItem(Name = "Frame")]
	public class FrameData : BaseObjectData
	{
		[ItemProperty, JsonProperty]
		public int FrameIndex
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = true), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(true)]
		public bool Tween
		{
			get;
			set;
		}

		public FrameData()
		{
			this.Tween = true;
		}

		public virtual bool FrameEquals(FrameData framedata)
		{
			return this.Tween == framedata.Tween;
		}

		public static bool IsFloatEqual(float a, float b, float digit = 0.0001f)
		{
			return Math.Abs(a - b) < digit;
		}
	}
}
