using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(TextAtlasObject))]
	public class TextAtlasObjectData : WidgetObjectData
	{
		internal static readonly ResourceItemData DefaultFile = new ResourceItemData(EnumResourceType.Default, "Default/TextAtlas.png");

		private static readonly PointF defaultTextSize = new PointF(168f, 18f);

		private ResourceItemData labelAtlasFileImage_CNB;

		[ItemProperty, JsonProperty]
		public int CharWidth
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public int CharHeight
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public string LabelText
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public string StartChar
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public ResourceItemData LabelAtlasFileImage_CNB
		{
			get
			{
				return this.labelAtlasFileImage_CNB;
			}
			set
			{
				this.labelAtlasFileImage_CNB = value;
				if (this.labelAtlasFileImage_CNB == null)
				{
					this.labelAtlasFileImage_CNB = TextAtlasObjectData.DefaultFile;
					base.Size = TextAtlasObjectData.defaultTextSize;
				}
			}
		}

		protected override void OnDataInitialize(VisualObject vObject)
		{
			TextAtlasObject textAtlasObject = vObject as TextAtlasObject;
			if (textAtlasObject != null)
			{
				if ((this.LabelAtlasFileImage_CNB != null && textAtlasObject.LabelAtlasFileImage_CNB.GetResourceData().Type != this.LabelAtlasFileImage_CNB.Type) || textAtlasObject.LabelAtlasFileImage_CNB.GetResourceData().Type == EnumResourceType.Default)
				{
					textAtlasObject.LabelAtlasFileImage_CNB = null;
				}
			}
		}
	}
}
