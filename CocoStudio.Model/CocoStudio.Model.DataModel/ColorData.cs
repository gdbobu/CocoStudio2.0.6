using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Drawing;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(Color))]
	public sealed class ColorData : BaseObjectData, IDataConvert
	{
		[ItemProperty(DefaultValue = 255), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(255)]
		public byte A
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 255), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(255)]
		public byte R
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 255), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(255)]
		public byte G
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = 255), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(255)]
		public byte B
		{
			get;
			set;
		}

		public ColorData()
		{
		}

		public ColorData(Color color) : this(color.A, color.R, color.G, color.B)
		{
		}

		public ColorData(byte a, byte r, byte g, byte b)
		{
			this.A = a;
			this.R = r;
			this.G = g;
			this.B = b;
		}

		public static implicit operator ColorData(Color color)
		{
			return new ColorData(color);
		}

		public static implicit operator Color(ColorData color)
		{
			return Color.FromArgb(255, (int)color.R, (int)color.G, (int)color.B);
		}

		public object CreateViewModel()
		{
			Color color = this;
			return color;
		}

		public void SetData(object viewObject)
		{
			if (!(viewObject is Color))
			{
				throw new ArgumentException("Can only receive System.Drawing.Color object to apply value.");
			}
			Color color = (Color)viewObject;
			this.A = color.A;
			this.R = color.R;
			this.G = color.G;
			this.B = color.B;
		}

		public override bool Equals(object obj)
		{
			ColorData colorData = obj as ColorData;
			return colorData != null && this.R == colorData.R && this.G == colorData.G && this.B == colorData.B && this.A == colorData.A;
		}
	}
}
