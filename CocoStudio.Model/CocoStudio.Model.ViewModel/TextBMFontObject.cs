using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.DataModel;
using CocoStudio.Model.Editor;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.ViewModel
{
	[ModelExtension(true, 5), Catagory("Control_BaseControl", 0, 0), DisplayName("Display_Component_UILableBMFont")]
	public class TextBMFontObject : WidgetObject
	{
		private string _labelText = "";

		private ResourceFile filePath = null;

		[PropertyOrder(58), UndoProperty, Category("Group_Feature"), DefaultValue(""), DisplayName("Display_Text")]
		public string LabelText
		{
			get
			{
				return this._labelText;
			}
			set
			{
				if (this._labelText != value)
				{
					this._labelText = value;
					this.GetInnerWidget().SetText(value);
					this.RaisePropertyChanged<string>(() => this.LabelText);
				}
			}
		}

		[ResourceFilter(new string[]
		{
			"fnt"
		}), PropertyOrder(53), UndoProperty, Category("Group_Feature"), DefaultValue(null), DisplayName("Display_FNTFile"), Editor(typeof(ResourceImageEditor), typeof(ResourceImageEditor))]
		public ResourceFile LabelBMFontFile_CNB
		{
			get
			{
				return this.filePath;
			}
			set
			{
				this.filePath = value;
				if (this.filePath == null || !this.filePath.IsValid)
				{
					this.filePath = new FntFile(TextBMFontObjectData.DefaultFntFont);
				}
				ResourceData resourceData = this.filePath.GetResourceData();
				this.GetInnerWidget().SetFntFile(this.filePath.GetResourceData());
				string compositeTaskName = base.GetType().Name + "LabelBMFontFile_CNB";
				using (CompositeTask.Run(compositeTaskName))
				{
					this.RefreshBoundingBox(false);
					this.RaisePropertyChanged<PointF>(() => this.Size);
					this.RaisePropertyChanged<ResourceFile>(() => this.LabelBMFontFile_CNB);
				}
			}
		}

		private CSTextBMFont GetInnerWidget()
		{
			return (CSTextBMFont)this.innerNode;
		}

		public TextBMFontObject()
		{
		}

		public TextBMFontObject(CSTextBMFont customWidget) : base(customWidget)
		{
		}

		protected override void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSTextBMFont();
			}
		}

		protected override void InitData()
		{
			base.InitData();
			this.LabelBMFontFile_CNB = null;
			this.LabelText = "Fnt Text Label";
			this.Name = "BitmapFontLabel_" + this.ObjectIndex;
		}

		protected override void SetValue(object cObject, object cInnerObject)
		{
			base.SetValue(cObject, cInnerObject);
			TextBMFontObject textBMFontObject = cObject as TextBMFontObject;
			if (textBMFontObject != null)
			{
				textBMFontObject.LabelBMFontFile_CNB = this.LabelBMFontFile_CNB;
				textBMFontObject.LabelText = this.LabelText;
			}
		}

		protected override void OnMouseDoubleClick(MouseEventArgsExtend args)
		{
			TextEditorWindow textEditorWindow = new TextEditorWindow(this, "LabelText", "CColor", null, false);
		}
	}
}
