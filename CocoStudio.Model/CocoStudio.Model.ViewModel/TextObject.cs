using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.DataModel;
using CocoStudio.Model.Editor;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using System;
using System.ComponentModel;
using System.Drawing;

namespace CocoStudio.Model.ViewModel
{
	[ModelExtension(true, 8), Catagory("Control_BaseControl", 0, 0), DisplayName("Display_Component_UILable")]
	public class TextObject : WidgetObject, ISizeType
	{
		private ResourceFile file = null;

		private string _labelText = "";

		[UndoProperty]
		public bool IsCustomSize
		{
			get
			{
				return this.GetInnerWidget().GetSizeCustomEnabled();
			}
			set
			{
				this.GetInnerWidget().SetSizeCustomEnabled(value);
				string compositeTaskName = base.GetType().Name + "IsCustomSize";
				using (CompositeTask.Run(compositeTaskName))
				{
					if (!value)
					{
						this.PreSizeEnable = false;
					}
					this.RefreshBoundingBox(false);
					this.RaisePropertyChanged<CocoStudio.Model.PointF>(() => this.Size);
					this.RaisePropertyChanged<bool>(() => this.IsCustomSize);
				}
			}
		}

		[PropertyOrder(32), UndoProperty, Category("Group_Feature"), DefaultValue(255), DisplayName("Display_Animation")]
		public virtual bool TouchScaleChangeAble
		{
			get
			{
				return this.GetInnerWidget().GetTouchScaleChangeEanbleState();
			}
			set
			{
				this.GetInnerWidget().SetTouchScaleChangeEanbleState(value);
				this.RaisePropertyChanged<bool>(() => this.TouchScaleChangeAble);
			}
		}

		[PropertyOrder(14), UndoProperty, Browsable(false), Category("Display_ControlLayout"), DefaultValue(false), DisplayName("Display_Flip"), Editor(typeof(FilpEditor), typeof(FilpEditor))]
		public virtual FilpValue Filp
		{
			get
			{
				return new FilpValue(this.FlipX, this.FlipY);
			}
			set
			{
				this.FlipX = value.FlipX;
				this.FlipY = value.FlipY;
			}
		}

		public virtual bool FlipY
		{
			get
			{
				return this.GetInnerWidget().GetFlipY();
			}
			set
			{
				if (this.GetInnerWidget().GetFlipY() != value)
				{
					this.GetInnerWidget().SetFlipY(value);
					this.RaisePropertyChanged<FilpValue>(() => this.Filp);
				}
			}
		}

		public virtual bool FlipX
		{
			get
			{
				return this.GetInnerWidget().GetFlipX();
			}
			set
			{
				if (this.GetInnerWidget().GetFlipX() != value)
				{
					this.GetInnerWidget().SetFlipX(value);
					this.RaisePropertyChanged<FilpValue>(() => this.Filp);
				}
			}
		}

		[ResourceFilter(new string[]
		{
			"ttf",
			"ttc"
		}), PropertyOrder(38), UndoProperty, Category("Group_Feature"), DefaultValue(null), DisplayName("Display_FontStyle"), Editor(typeof(PropertyColorEditor), typeof(PropertyColorEditor))]
		public ResourceFile FontResource
		{
			get
			{
				return this.file;
			}
			set
			{
				this.file = value;
				if (this.file == null || !this.file.IsValid)
				{
					this.GetInnerWidget().SetFontName(WidgetObjectData.DefaultFont);
					this.GetInnerWidget().SetFontSize(this.FontSize);
				}
				else
				{
					this.GetInnerWidget().SetFontName(this.file.GetResourceData().Path);
				}
				string compositeTaskName = base.GetType().Name + "FontResource";
				using (CompositeTask.Run(compositeTaskName))
				{
					this.RefreshBoundingBox(false);
					this.RaisePropertyChanged<CocoStudio.Model.PointF>(() => this.Size);
					this.RaisePropertyChanged<ResourceFile>(() => this.FontResource);
				}
			}
		}

		[PropertyOrder(12), UndoProperty, Browsable(false), Category("Group_Routine"), DisplayName("Display_ColorBlend"), Editor(typeof(ColorsEditor), typeof(ColorsEditor))]
		public override Color CColor
		{
			get
			{
				return this.GetCSVisual().GetColor();
			}
			set
			{
				this.GetCSVisual().SetColor(value);
				this.RaisePropertyChanged<Color>(() => this.CColor);
			}
		}

		[PropertyOrder(37), ValueRange(5, 100, 1.0), UndoProperty, Browsable(false), Category("Group_Feature"), DefaultValue(24), DisplayName("Display_FontSize")]
		public int FontSize
		{
			get
			{
				return this.GetInnerWidget().GetFontSize();
			}
			set
			{
				if (this.FontSize != value && value >= 1)
				{
					this.GetInnerWidget().SetFontSize(value);
					string compositeTaskName = base.GetType().Name + "FontSize";
					using (CompositeTask.Run(compositeTaskName))
					{
						this.RefreshBoundingBox(false);
						this.RaisePropertyChanged<CocoStudio.Model.PointF>(() => this.Size);
						this.RaisePropertyChanged<int>(() => this.FontSize);
					}
				}
			}
		}

		[PropertyOrder(34), UndoProperty, Category("Group_Feature"), DefaultValue(""), DisplayName("Display_Text"), Editor(typeof(EntryTextViewEditor), typeof(EntryTextViewEditor))]
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
					this.GetInnerWidget().SetLabelText(value);
					this.RaisePropertyChanged<string>(() => this.LabelText);
					this.RaisePropertyChanged<CocoStudio.Model.PointF>(() => this.Size);
				}
			}
		}

		[PropertyOrder(35), UndoProperty, Category("Group_Feature"), DefaultValue(""), DisplayName("Display_HAlign")]
		public TextHorizontalType HorizontalAlignmentType
		{
			get
			{
				return (TextHorizontalType)this.GetInnerWidget().GetHorizontalAlignmentType();
			}
			set
			{
				this.GetInnerWidget().SetHorizontalAlignmentType((int)value);
				this.RaisePropertyChanged<TextHorizontalType>(() => this.HorizontalAlignmentType);
			}
		}

		[PropertyOrder(36), UndoProperty, Category("Group_Feature"), DefaultValue(""), DisplayName("Display_VAlign")]
		public TextVerticalType VerticalAlignmentType
		{
			get
			{
				return (TextVerticalType)this.GetInnerWidget().GetVerticalAlignmentType();
			}
			set
			{
				this.GetInnerWidget().SetVerticalAlignmentType((int)value);
				this.RaisePropertyChanged<TextVerticalType>(() => this.VerticalAlignmentType);
			}
		}

		private CSText GetInnerWidget()
		{
			return (CSText)this.innerNode;
		}

		public TextObject()
		{
		}

		public TextObject(CSText customWidget) : base(customWidget)
		{
		}

		protected override void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSText();
			}
		}

		protected override void InitData()
		{
			base.InitData();
			this.FontResource = null;
			this.LabelText = "Text Label";
			this.FontSize = 20;
			this.Filp = new FilpValue(false, false);
			this.IsCustomSize = false;
		}

		protected override void SetValue(object cObject, object cInnerObject)
		{
			base.SetValue(cObject, cInnerObject);
			TextObject textObject = cObject as TextObject;
			if (textObject != null)
			{
				textObject.FontResource = this.FontResource;
				textObject.FontSize = this.FontSize;
				textObject.LabelText = this.LabelText;
				textObject.HorizontalAlignmentType = this.HorizontalAlignmentType;
				textObject.VerticalAlignmentType = this.VerticalAlignmentType;
				textObject.TouchScaleChangeAble = this.TouchScaleChangeAble;
				textObject.FlipX = this.FlipX;
				textObject.FlipY = this.FlipY;
				textObject.IsCustomSize = this.IsCustomSize;
				textObject.Size = this.Size;
			}
		}

		protected override void OnMouseDoubleClick(MouseEventArgsExtend args)
		{
			TextEditorWindow textEditorWindow = new TextEditorWindow(this, "LabelText", "CColor", "FontSize", true);
		}
	}
}
