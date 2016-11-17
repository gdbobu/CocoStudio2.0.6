using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;

namespace CocoStudio.Model.Editor
{
	[DataModelExtension, JsonObject(MemberSerialization.OptIn)]
	public sealed class SizeValue
	{
		[ItemProperty, JsonProperty]
		public int Width
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public int Height
		{
			get;
			set;
		}

		public SizeValue()
		{
		}

		public SizeValue(int width, int height)
		{
			this.Width = width;
			this.Height = height;
		}
	}
}
