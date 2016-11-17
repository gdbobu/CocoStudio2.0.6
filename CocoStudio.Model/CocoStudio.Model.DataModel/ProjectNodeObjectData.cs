using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(ProjectNodeObject))]
	public class ProjectNodeObjectData : NodeObjectData
	{
		[ItemProperty, JsonProperty]
		public ResourceItemData FileData
		{
			get;
			set;
		}
	}
}
