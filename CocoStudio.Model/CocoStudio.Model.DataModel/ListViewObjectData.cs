using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(ListViewObject)), DataInclude(typeof(ListViewDirectionType)), DataInclude(typeof(ListViewHorizontal)), DataInclude(typeof(ListViewVertical))]
	public class ListViewObjectData : ScrollViewObjectData
	{
		[ItemProperty(DefaultValue = 0), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(0)]
		public int ItemMargin
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = ListViewDirectionType.Horizontal), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(ListViewDirectionType.Horizontal)]
		public ListViewDirectionType DirectionType
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = ListViewHorizontal.Align_Left), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(ListViewHorizontal.Align_Left)]
		public ListViewHorizontal HorizontalType
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = ListViewVertical.Align_Top), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(ListViewVertical.Align_Top)]
		public ListViewVertical VerticalType
		{
			get;
			set;
		}

		public ListViewObjectData()
		{
			this.DirectionType = ListViewDirectionType.Horizontal;
		}
	}
}
