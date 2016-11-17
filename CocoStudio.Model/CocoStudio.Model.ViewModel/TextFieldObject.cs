using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.DataModel;
using CocoStudio.Model.Editor;
using CocoStudio.Model.Interface;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using System;
using System.ComponentModel;
using System.Drawing;

namespace CocoStudio.Model.ViewModel
{
	[ModelExtension(true, 9), Catagory("Control_BaseControl", 0, 0), DisplayName("Display_Component_UIField")]
	public class TextFieldObject : WidgetObject, IAstrictLengthValue, IPasswordValue, ICallBackEvent
	{
		private ResourceFile file = null;

		private string _labelText = "";

		private string _placeText = "";

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
				this.RaisePropertyChanged<bool>(() => this.IsCustomSize);
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

		[PropertyOrder(37), ValueRange(5, 100, 1.0), UndoProperty, Browsable(false), Category("Group_Feature"), DisplayName("Display_FontSize")]
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
					this.GetInnerWidget().SetLabelText(this.LabelText);
					this.RaisePropertyChanged<int>(() => this.FontSize);
				}
			}
		}

		[PropertyOrder(34), UndoProperty, Category("Group_Feature"), DefaultValue("input words here"), DisplayName("Display_Text")]
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
				}
			}
		}

		[PropertyOrder(33), UndoProperty, Category("Group_Feature"), DefaultValue(""), DisplayName("Placeholder_Text")]
		public string PlaceHolderText
		{
			get
			{
				return this._placeText;
			}
			set
			{
				if (this._placeText != value)
				{
					this._placeText = value;
					this.GetInnerWidget().SetPlaceHolderText(value);
					this.RaisePropertyChanged<string>(() => this.PlaceHolderText);
				}
			}
		}

		[PropertyOrder(39), UndoProperty, Browsable(true), Category("Group_Feature"), DisplayName("ContexMenu_ShowCiphertext"), Editor(typeof(PasswordEditor), typeof(PasswordEditor))]
		public PasswordValue Password
		{
			get
			{
				return new PasswordValue(this.GetInnerWidget().GetPassWordEnabled(), this.GetInnerWidget().GetPasswordStyleText());
			}
			set
			{
				if (this.GetInnerWidget().GetPassWordEnabled() != value.PasswordEnable)
				{
					this.GetInnerWidget().SetPassWordEnabled(value.PasswordEnable);
				}
				if (value.PasswordStyleText != null)
				{
					this.GetInnerWidget().SetPasswordStyleText(value.PasswordStyleText);
				}
				this.RaisePropertyChanged<PasswordValue>(() => this.Password);
			}
		}

		[UndoProperty]
		public bool PasswordEnable
		{
			get
			{
				return this.GetInnerWidget().GetPassWordEnabled();
			}
			set
			{
				this.GetInnerWidget().SetPassWordEnabled(value);
				this.RaisePropertyChanged<bool>(() => this.PasswordEnable);
			}
		}

		[UndoProperty]
		public string PasswordStyleText
		{
			get
			{
				return this.GetInnerWidget().GetPasswordStyleText();
			}
			set
			{
				this.GetInnerWidget().SetPasswordStyleText(value);
				this.RaisePropertyChanged<string>(() => this.PasswordStyleText);
			}
		}

		[PropertyOrder(40), UndoProperty, Browsable(true), Category("Group_Feature"), DisplayName("Length_limit"), Editor(typeof(AstrictLengthEditor), typeof(AstrictLengthEditor))]
		public AstrictLengthValue AstrictLength
		{
			get
			{
				return new AstrictLengthValue(this.GetInnerWidget().GetLengthLimited(), this.GetInnerWidget().GetMaxLength());
			}
			set
			{
				if (this.GetInnerWidget().GetLengthLimited() != value.MaxLengthEnable)
				{
					this.GetInnerWidget().SetLengthLimited(value.MaxLengthEnable);
				}
				this.GetInnerWidget().SetMaxLength(value.MaxLengthText);
				this.GetInnerWidget().SetLabelText(this._labelText);
				this.RaisePropertyChanged<AstrictLengthValue>(() => this.AstrictLength);
			}
		}

		[UndoProperty]
		public bool MaxLengthEnable
		{
			get
			{
				return this.GetInnerWidget().GetLengthLimited();
			}
			set
			{
				this.GetInnerWidget().SetLengthLimited(value);
				this.RaisePropertyChanged<bool>(() => this.MaxLengthEnable);
			}
		}

		[UndoProperty]
		public int MaxLengthText
		{
			get
			{
				return this.GetInnerWidget().GetMaxLength();
			}
			set
			{
				this.GetInnerWidget().SetMaxLength(value);
				this.GetInnerWidget().SetLabelText(this._labelText);
				this.RaisePropertyChanged<int>(() => this.MaxLengthText);
			}
		}

		private CSTextField GetInnerWidget()
		{
			return (CSTextField)this.innerNode;
		}

		public TextFieldObject()
		{
		}

		public TextFieldObject(CSTextField customWidget) : base(customWidget)
		{
		}

		protected override void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSTextField();
			}
		}

		protected override void InitData()
		{
			base.InitData();
			this.IsCustomSize = true;
			this.FontResource = null;
			this.FontSize = 20;
			this.LabelText = "";
			this.PlaceHolderText = "Text Field";
			this.Password = new PasswordValue(false, "*");
			this.AstrictLength = new AstrictLengthValue(false, this.LabelText.Length);
			this.TouchEnable = true;
			this.MaxLengthText = 10;
			this.Size = new CocoStudio.Model.PointF(100f, 27f);
		}

		protected override void SetValue(object cObject, object cInnerObject)
		{
			base.SetValue(cObject, cInnerObject);
			TextFieldObject textFieldObject = cObject as TextFieldObject;
			if (textFieldObject != null)
			{
				textFieldObject.Password = this.Password;
				textFieldObject.AstrictLength = this.AstrictLength;
				textFieldObject.FontResource = this.FontResource;
				textFieldObject.FontSize = this.FontSize;
				textFieldObject.LabelText = this.LabelText;
				textFieldObject.PlaceHolderText = this.PlaceHolderText;
				textFieldObject.Size = this.Size;
			}
		}

		protected override void OnMouseDoubleClick(MouseEventArgsExtend args)
		{
			TextEditorWindow textEditorWindow = new TextEditorWindow(this, "PlaceHolderText", null, "FontSize", false);
		}
	}
}
