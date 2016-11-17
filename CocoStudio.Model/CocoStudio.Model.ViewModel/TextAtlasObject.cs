using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.DataModel;
using CocoStudio.Model.Editor;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.ViewModel
{
	[ModelExtension(true, 4), Catagory("Control_Deprecated", 2, 0), DisplayName("Display_Component_UILableAtlas")]
	public class TextAtlasObject : WidgetObject
	{
		private ResourceFile file = null;

		private string _startChar = "";

		private string _labelText = "";

		[ResourceFilter(EnumResourceType.Normal, new string[]
		{
			"png",
			"jpg"
		}), PropertyOrder(53), UndoProperty, Category("Group_Feature"), DefaultValue(null), DisplayName("Display_TagImage"), Editor(typeof(ResourceImageEditor), typeof(ResourceImageEditor))]
		public virtual ResourceFile LabelAtlasFileImage_CNB
		{
			get
			{
				return this.file;
			}
			set
			{
				if (value == null || value is ImageFile)
				{
					this.file = value;
					if (this.file == null || !this.file.IsValid)
					{
						this.file = new ImageFile(TextAtlasObjectData.DefaultFile);
					}
					using (CompositeTask.Run("刷新数字标签的资源"))
					{
						this.GetInnerWidget().SetAtlasFile(this.file.GetResourceData());
						this.RaisePropertyChanged<int>(() => this.CharWidth);
						this.RaisePropertyChanged<int>(() => this.CharHeight);
						this.RaisePropertyChanged<ResourceFile>(() => this.LabelAtlasFileImage_CNB);
						this.RaisePropertyChanged<PointF>(() => this.Size);
					}
				}
			}
		}

		[PropertyOrder(55), UndoProperty, Browsable(false), Category("Group_Feature"), DefaultValue(""), DisplayName("Display_LabelFirstChar")]
		public virtual string StartChar
		{
			get
			{
				return this.GetInnerWidget().GetStartChar();
			}
			set
			{
				if (this.GetInnerWidget().GetStartChar() != value)
				{
					this._startChar = value;
					this.GetInnerWidget().SetStartChar(value);
					using (CompositeTask.Run("刷新数字标签的起始字符"))
					{
						this.RaisePropertyChanged<string>(() => this.StartChar);
						this.RaisePropertyChanged<PointF>(() => this.Size);
					}
				}
			}
		}

		[PropertyOrder(56), ValueRange(0, 2147483647, 1.0), UndoProperty, Browsable(false), Category("Group_Feature"), DefaultValue(12), DisplayName("Display_LabelCharWidth")]
		public virtual int CharWidth
		{
			get
			{
				return this.GetInnerWidget().GetCharacterWidth();
			}
			set
			{
				if (this.GetInnerWidget().GetCharacterWidth() != value && value >= 0)
				{
					this.GetInnerWidget().SetCharacterWidth(value);
					using (CompositeTask.Run("刷新数字标签的字符宽"))
					{
						this.RaisePropertyChanged<int>(() => this.CharWidth);
						this.RaisePropertyChanged<PointF>(() => this.Size);
					}
				}
			}
		}

		[PropertyOrder(57), ValueRange(0, 2147483647, 1.0), UndoProperty, Browsable(false), Category("Group_Feature"), DefaultValue(12), DisplayName("Display_LabelCharHeight")]
		public virtual int CharHeight
		{
			get
			{
				return this.GetInnerWidget().GetCharacterHeight();
			}
			set
			{
				if (this.GetInnerWidget().GetCharacterHeight() != value && value >= 0)
				{
					this.GetInnerWidget().SetCharacterHeight(value);
					using (CompositeTask.Run("刷新数字标签的字符高"))
					{
						this.RaisePropertyChanged<int>(() => this.CharHeight);
						this.RaisePropertyChanged<PointF>(() => this.Size);
					}
				}
			}
		}

		[PropertyOrder(58), UndoProperty, Category("Group_Feature"), DefaultValue(""), DisplayName("Display_Text"), Editor(typeof(NumberEntryEditor), typeof(NumberEntryEditor))]
		public virtual string LabelText
		{
			get
			{
				return this.GetInnerWidget().GetText();
			}
			set
			{
				if (this.GetInnerWidget().GetText() != value)
				{
					this._labelText = value;
					this.GetInnerWidget().SetText(value);
					using (CompositeTask.Run("刷新数字标签的文本"))
					{
						if (string.IsNullOrEmpty(value))
						{
							this.Size = new PointF(0f, this.Size.Y);
						}
						this.RaisePropertyChanged<string>(() => this.LabelText);
						this.RaisePropertyChanged<PointF>(() => this.Size);
					}
				}
			}
		}

		[PropertyOrder(54), Category("Group_Feature"), DefaultValue(""), DisplayName(""), Editor(typeof(LabelTooltipEditor), typeof(LabelTooltipEditor))]
		public string LabelToop
		{
			get
			{
				return LanguageInfo.TextAtlasResourceExplain;
			}
		}

		private CSTextAtlas GetInnerWidget()
		{
			return (CSTextAtlas)this.innerNode;
		}

		public TextAtlasObject()
		{
		}

		public TextAtlasObject(CSTextAtlas customWidget) : base(customWidget)
		{
		}

		protected override void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSTextAtlas();
			}
		}

		protected override void InitData()
		{
			base.InitData();
			this.LabelAtlasFileImage_CNB = null;
			this.StartChar = ".";
			this.LabelText = "./0123456789";
			this.CharWidth = 14;
			this.CharHeight = 18;
			this.Name = "AtlasLabel_" + this.ObjectIndex;
		}

		protected override void SetValue(object cObject, object cInnerObject)
		{
			base.SetValue(cObject, cInnerObject);
			TextAtlasObject textAtlasObject = cObject as TextAtlasObject;
			if (textAtlasObject != null)
			{
				textAtlasObject.LabelAtlasFileImage_CNB = this.LabelAtlasFileImage_CNB;
				textAtlasObject.StartChar = this.StartChar;
				textAtlasObject.CharWidth = this.CharWidth;
				textAtlasObject.CharHeight = this.CharHeight;
				textAtlasObject.LabelText = this.LabelText;
			}
		}

		protected override void OnMouseDoubleClick(MouseEventArgsExtend args)
		{
			TextEditorWindow textEditorWindow = new TextEditorWindow(this, "LabelText", null, null, false);
		}
	}
}
