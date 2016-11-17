using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.DataModel;
using CocoStudio.Model.Editor;
using CocoStudio.Model.Interface;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CocoStudio.Model.ViewModel
{
	[ModelExtension(true, 1), Catagory("Control_BaseControl", 0, 0), DisplayName("Display_Component_UICheckBox")]
	public class CheckBoxObject : WidgetObject, IDisplayState, ICallBackEvent
	{
		private bool isNormal = true;

		private ResourceFile normalBackFile = null;

		private ResourceFile pressedBackFile = null;

		private ResourceFile disableBackFile = null;

		private ResourceFile nodeNormalFile = null;

		private ResourceFile nodeDisableFile = null;

		[PropertyOrder(67), UndoProperty, Category("Group_Feature"), DefaultValue(true), DisplayName("Display_State"), Editor(typeof(CheckBoxEditor), typeof(CheckBoxEditor))]
		public virtual bool DisplayState
		{
			get
			{
				return this.isNormal;
			}
			set
			{
				this.isNormal = value;
				this.GetInnerWidget().ChangeState(this.isNormal);
				this.RaisePropertyChanged<bool>(() => this.DisplayState);
			}
		}

		[PropertyOrder(68), UndoProperty, Category("Group_Feature"), DefaultValue(true), DisplayName("Display_Select_UnSelect")]
		public virtual bool CheckedState
		{
			get
			{
				return this.GetInnerWidget().GetChecked();
			}
			set
			{
				if (this.GetInnerWidget().GetChecked() != value)
				{
					this.GetInnerWidget().SetChecked(value);
					this.GetInnerWidget().ChangeState(!this.isNormal);
					this.GetInnerWidget().ChangeState(this.isNormal);
					this.RaisePropertyChanged<bool>(() => this.CheckedState);
				}
			}
		}

		[PropertyOrder(65), Category("Group_Feature"), DisplayName("Display_ImageResources"), Editor(typeof(ResourceGroupEditor), typeof(ResourceGroupEditor))]
		public List<string> ResourceValue
		{
			get
			{
				return new List<string>
				{
					"NormalBackFileData",
					"PressedBackFileData",
					"DisableBackFileData"
				};
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		[PropertyOrder(66), Category("Group_Feature"), DisplayName("Display_MarkResource"), Editor(typeof(ResourceGroupEditor), typeof(ResourceGroupEditor))]
		public List<string> ResourceNodeValue
		{
			get
			{
				return new List<string>
				{
					"NodeNormalFileData",
					"NodeDisableFileData"
				};
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		[ResourceFilter(new string[]
		{
			"png",
			"jpg"
		}), UndoProperty, DefaultValue(null), DisplayName("ContexMenu_BackgroundNormal"), Editor(typeof(ResourceImageEditor), typeof(ResourceImageEditor))]
		public ResourceFile NormalBackFileData
		{
			get
			{
				return this.normalBackFile;
			}
			set
			{
				this.normalBackFile = value;
				if (this.normalBackFile == null || !this.normalBackFile.IsValid)
				{
					this.normalBackFile = new ImageFile(CheckBoxObjectData.Default_Normal);
				}
				this.GetInnerWidget().SetNormalGroudFile(this.normalBackFile.GetResourceData());
				string compositeTaskName = base.GetType().Name + "NormalBackFileData";
				using (CompositeTask.Run(compositeTaskName))
				{
					this.RefreshBoundingBox(false);
					this.RaisePropertyChanged<PointF>(() => this.Size);
					this.RaisePropertyChanged<ResourceFile>(() => this.NormalBackFileData);
				}
			}
		}

		[ResourceFilter(new string[]
		{
			"png",
			"jpg"
		}), UndoProperty, DefaultValue(null), DisplayName("ContexMenu_BackgroundPressed"), Editor(typeof(ResourceImageEditor), typeof(ResourceImageEditor))]
		public ResourceFile PressedBackFileData
		{
			get
			{
				return this.pressedBackFile;
			}
			set
			{
				this.pressedBackFile = value;
				if (this.pressedBackFile == null || !this.pressedBackFile.IsValid)
				{
					this.pressedBackFile = new ImageFile(CheckBoxObjectData.Default_Press);
				}
				this.GetInnerWidget().SetPressedGroudFile(this.pressedBackFile.GetResourceData());
				this.RaisePropertyChanged<ResourceFile>(() => this.PressedBackFileData);
			}
		}

		[ResourceFilter(new string[]
		{
			"png",
			"jpg"
		}), UndoProperty, DefaultValue(null), DisplayName("ContexMenu_BackgroundDisabled"), Editor(typeof(ResourceImageEditor), typeof(ResourceImageEditor))]
		public ResourceFile DisableBackFileData
		{
			get
			{
				return this.disableBackFile;
			}
			set
			{
				this.disableBackFile = value;
				if (this.disableBackFile == null || !this.disableBackFile.IsValid)
				{
					this.disableBackFile = new ImageFile(CheckBoxObjectData.Default_Disable);
				}
				this.GetInnerWidget().SetDisabledGroudFile(this.disableBackFile.GetResourceData());
				this.RaisePropertyChanged<ResourceFile>(() => this.DisableBackFileData);
			}
		}

		[ResourceFilter(new string[]
		{
			"png",
			"jpg"
		}), UndoProperty, DefaultValue(null), DisplayName("ContexMenu_CheckNormal"), Editor(typeof(ResourceImageEditor), typeof(ResourceImageEditor))]
		public ResourceFile NodeNormalFileData
		{
			get
			{
				return this.nodeNormalFile;
			}
			set
			{
				this.nodeNormalFile = value;
				if (this.nodeNormalFile == null || !this.nodeNormalFile.IsValid)
				{
					this.nodeNormalFile = new ImageFile(CheckBoxObjectData.Default_NodeNormal);
				}
				this.GetInnerWidget().SetNormalNodeFile(this.nodeNormalFile.GetResourceData());
				this.RaisePropertyChanged<ResourceFile>(() => this.NodeNormalFileData);
			}
		}

		[ResourceFilter(new string[]
		{
			"png",
			"jpg"
		}), UndoProperty, DefaultValue(null), DisplayName("ContexMenu_CheckDisabled"), Editor(typeof(ResourceImageEditor), typeof(ResourceImageEditor))]
		public ResourceFile NodeDisableFileData
		{
			get
			{
				return this.nodeDisableFile;
			}
			set
			{
				this.nodeDisableFile = value;
				if (this.nodeDisableFile == null || !this.nodeNormalFile.IsValid)
				{
					this.nodeDisableFile = new ImageFile(CheckBoxObjectData.Default_NodeDisable);
				}
				this.GetInnerWidget().SetDisabledNodeFile(this.nodeDisableFile.GetResourceData());
				this.RaisePropertyChanged<ResourceFile>(() => this.NodeDisableFileData);
			}
		}

		private CSCheckBox GetInnerWidget()
		{
			return (CSCheckBox)this.innerNode;
		}

		public CheckBoxObject()
		{
		}

		public CheckBoxObject(CSCheckBox customWidget) : base(customWidget)
		{
		}

		protected override void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSCheckBox();
			}
		}

		protected override void InitData()
		{
			base.InitData();
			this.PressedBackFileData = null;
			this.DisableBackFileData = null;
			this.NodeDisableFileData = null;
			this.NormalBackFileData = null;
			this.NodeNormalFileData = null;
			this.CheckedState = true;
			this.TouchEnable = true;
		}

		protected override void SetValue(object cObject, object cInnerObject)
		{
			base.SetValue(cObject, cInnerObject);
			CheckBoxObject checkBoxObject = cObject as CheckBoxObject;
			if (checkBoxObject != null)
			{
				checkBoxObject.NormalBackFileData = this.NormalBackFileData;
				checkBoxObject.PressedBackFileData = this.PressedBackFileData;
				checkBoxObject.DisableBackFileData = this.DisableBackFileData;
				checkBoxObject.NodeNormalFileData = this.NodeNormalFileData;
				checkBoxObject.NodeDisableFileData = this.NodeDisableFileData;
				checkBoxObject.CheckedState = this.CheckedState;
				checkBoxObject.DisplayState = this.DisplayState;
			}
		}
	}
}
