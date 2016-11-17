using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using MonoDevelop.Core.Serialization;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.DataModel
{
	[DataModelExtension(typeof(CheckBoxObject))]
	public class CheckBoxObjectData : WidgetObjectData
	{
		internal static readonly ResourceItemData Default_Normal = new ResourceItemData(EnumResourceType.Default, "Default/CheckBox_Normal.png");

		internal static readonly ResourceItemData Default_Press = new ResourceItemData(EnumResourceType.Default, "Default/CheckBox_Press.png");

		internal static readonly ResourceItemData Default_Disable = new ResourceItemData(EnumResourceType.Default, "Default/CheckBox_Disable.png");

		internal static readonly ResourceItemData Default_NodeNormal = new ResourceItemData(EnumResourceType.Default, "Default/CheckBoxNode_Normal.png");

		internal static readonly ResourceItemData Default_NodeDisable = new ResourceItemData(EnumResourceType.Default, "Default/CheckBoxNode_Disable.png");

		private static readonly PointF normalImageSize = new PointF(40f, 40f);

		private ResourceItemData normalBackFileData;

		private ResourceItemData pressedBackFileData;

		private ResourceItemData disableBackFileData;

		private ResourceItemData nodeNormalFileData;

		private ResourceItemData nodeDisableFileData;

		[ItemProperty(DefaultValue = false), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(false)]
		public bool CheckedState
		{
			get;
			set;
		}

		[ItemProperty(DefaultValue = true), JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate), DefaultValue(true)]
		public bool DisplayState
		{
			get;
			set;
		}

		[ItemProperty, JsonProperty]
		public ResourceItemData NormalBackFileData
		{
			get
			{
				return this.normalBackFileData;
			}
			set
			{
				this.normalBackFileData = value;
				if (this.normalBackFileData == null)
				{
					this.normalBackFileData = CheckBoxObjectData.Default_Normal;
					base.Size = CheckBoxObjectData.normalImageSize;
				}
			}
		}

		[ItemProperty, JsonProperty]
		public ResourceItemData PressedBackFileData
		{
			get
			{
				return this.pressedBackFileData;
			}
			set
			{
				this.pressedBackFileData = value;
				if (this.pressedBackFileData == null)
				{
					this.pressedBackFileData = CheckBoxObjectData.Default_Press;
				}
			}
		}

		[ItemProperty, JsonProperty]
		public ResourceItemData DisableBackFileData
		{
			get
			{
				return this.disableBackFileData;
			}
			set
			{
				this.disableBackFileData = value;
				if (this.disableBackFileData == null)
				{
					this.disableBackFileData = CheckBoxObjectData.Default_Disable;
				}
			}
		}

		[ItemProperty, JsonProperty]
		public ResourceItemData NodeNormalFileData
		{
			get
			{
				return this.nodeNormalFileData;
			}
			set
			{
				this.nodeNormalFileData = value;
				if (this.nodeNormalFileData == null)
				{
					this.nodeNormalFileData = CheckBoxObjectData.Default_NodeNormal;
				}
			}
		}

		[ItemProperty, JsonProperty]
		public ResourceItemData NodeDisableFileData
		{
			get
			{
				return this.nodeDisableFileData;
			}
			set
			{
				this.nodeDisableFileData = value;
				if (this.nodeDisableFileData == null)
				{
					this.nodeDisableFileData = CheckBoxObjectData.Default_NodeDisable;
				}
			}
		}

		public CheckBoxObjectData()
		{
			this.DisplayState = true;
		}

		protected override void OnDataInitialize(VisualObject vObject)
		{
			CheckBoxObject checkBoxObject = vObject as CheckBoxObject;
			if (checkBoxObject != null)
			{
				if (this.NormalBackFileData != null && checkBoxObject.NormalBackFileData.GetResourceData().Type != this.NormalBackFileData.Type)
				{
					checkBoxObject.NormalBackFileData = null;
				}
			}
		}
	}
}
