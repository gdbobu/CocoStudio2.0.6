using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.DataModel;
using CocoStudio.Model.Editor;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using Gdk;
using PostSharp.Aspects;
using PostSharp.Aspects.Internals;
using PostSharp.ImplementationDetails_c065fe4d;
using PostSharp.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace CocoStudio.Model.ViewModel
{
	[ModelExtension(true, 0), Catagory("Control_BaseControl", 0, 0), DisplayName("Display_Component_UIButton")]
	public class ButtonObject : WidgetObject, IScale9, IDisplayState
	{
		[CompilerGenerated]
		private sealed class <Scale9Enable>c__Binding : LocationBinding<bool>
		{
			public static ButtonObject.<Scale9Enable>c__Binding singleton = new ButtonObject.<Scale9Enable>c__Binding();

			[DebuggerNonUserCode]
			private <Scale9Enable>c__Binding()
			{
			}

			public override DeclarationIdentifier get_DeclarationIdentifier()
			{
				return new DeclarationIdentifier(-4582977439099191284L);
			}

			public override LocationInfo get_LocationInfo()
			{
				return <>z__a_2._2;
			}

			public override bool GetValue(ref object instance, Arguments index, object aspectArgs)
			{
				return ((ButtonObject)instance).<get_Scale9Enable>z__OriginalMethod();
			}

			public override void SetValue(ref object instance, Arguments index, bool value, object aspectArgs)
			{
				ButtonObject buttonObject = (ButtonObject)instance;
				buttonObject._scale9Enabled = value;
				buttonObject.GetInnerWidget().SetScale9Enabled(value);
				string compositeTaskName = buttonObject.GetType().Name + "Scale9Enable";
				using (CompositeTask.Run(compositeTaskName))
				{
					if (!value)
					{
						buttonObject.PreSizeEnable = false;
					}
					buttonObject.RefreshBoundingBox(false);
					buttonObject.RaisePropertyChanged<CocoStudio.Model.PointF>(() => buttonObject.Size);
					buttonObject.RaisePropertyChanged<bool>(() => buttonObject.Scale9Enable);
				}
			}
		}

		private bool isNormal = true;

		private ResourceFile normalFile = null;

		private ResourceFile pressedFile = null;

		private ResourceFile disabledFile = null;

		private ResourceFile fontFile = null;

		private string text;

		private System.Drawing.Color _textColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);

		private bool _scale9Enabled = false;

		private int _left = 0;

		private int _right = 0;

		private int _top = 0;

		private int _bottom = 0;

		[PropertyOrder(73), UndoProperty, Category("Group_Feature"), DefaultValue(true), DisplayName("Display_State"), Editor(typeof(CheckBoxEditor), typeof(CheckBoxEditor))]
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

		[PropertyOrder(72), Category("Group_Feature"), DisplayName("Display_ImageResources"), Editor(typeof(ResourceGroupEditor), typeof(ResourceGroupEditor))]
		public virtual List<string> ResourceValue
		{
			get
			{
				return new List<string>
				{
					"NormalFileData",
					"PressedFileData",
					"DisabledFileData"
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
		}), UndoProperty, DefaultValue(null), DisplayName("Display_NormalState"), Editor(typeof(ResourceImageEditor), typeof(ResourceImageEditor))]
		public ResourceFile NormalFileData
		{
			get
			{
				return this.normalFile;
			}
			set
			{
				this.normalFile = value;
				if (this.normalFile == null || !this.normalFile.IsValid)
				{
					this.normalFile = new ImageFile(ButtonObjectData.Default_NormalFile);
				}
				this.GetInnerWidget().SetNormalFilePath(this.normalFile.GetResourceData());
				this.RefreshScale9();
				string compositeTaskName = base.GetType().Name + "NormalFileData";
				using (CompositeTask.Run(compositeTaskName))
				{
					this.RefreshBoundingBox(false);
					this.RaisePropertyChanged<CocoStudio.Model.PointF>(() => this.Size);
					this.RaisePropertyChanged<ResourceFile>(() => this.NormalFileData);
				}
			}
		}

		[ResourceFilter(new string[]
		{
			"png",
			"jpg"
		}), UndoProperty, DefaultValue(null), DisplayName("Display_BtnDown"), Editor(typeof(ResourceImageEditor), typeof(ResourceImageEditor))]
		public ResourceFile PressedFileData
		{
			get
			{
				return this.pressedFile;
			}
			set
			{
				this.pressedFile = value;
				if (this.pressedFile == null || !this.pressedFile.IsValid)
				{
					this.pressedFile = new ImageFile(ButtonObjectData.Default_PressedFile);
				}
				this.GetInnerWidget().SetPressedFilePath(this.pressedFile.GetResourceData());
				this.RaisePropertyChanged<ResourceFile>(() => this.PressedFileData);
			}
		}

		[ResourceFilter(new string[]
		{
			"png",
			"jpg"
		}), UndoProperty, DefaultValue(null), DisplayName("Display_Disable"), Editor(typeof(ResourceImageEditor), typeof(ResourceImageEditor))]
		public ResourceFile DisabledFileData
		{
			get
			{
				return this.disabledFile;
			}
			set
			{
				this.disabledFile = value;
				if (this.disabledFile == null || !this.disabledFile.IsValid)
				{
					this.disabledFile = new ImageFile(ButtonObjectData.Default_DisabledFile);
				}
				this.GetInnerWidget().SetDisabledFilePath(this.disabledFile.GetResourceData());
				this.RaisePropertyChanged<ResourceFile>(() => this.DisabledFileData);
			}
		}

		[ResourceFilter(new string[]
		{
			"ttf",
			"ttc"
		}), PropertyOrder(77), UndoProperty, Category("Group_Feature"), DefaultValue(null), DisplayName("Display_FontStyle"), Editor(typeof(PropertyColorEditor), typeof(PropertyColorEditor))]
		public ResourceFile FontResource
		{
			get
			{
				return this.fontFile;
			}
			set
			{
				this.fontFile = value;
				if (this.fontFile == null || !this.fontFile.IsValid)
				{
					this.GetInnerWidget().SetFontName(WidgetObjectData.DefaultFont);
					this.GetInnerWidget().SetFontSize(this.FontSize);
				}
				else
				{
					this.GetInnerWidget().SetFontName(this.fontFile.GetResourceData().Path);
				}
				string compositeTaskName = base.GetType().Name + "FontResource";
				using (CompositeTask.Run(compositeTaskName))
				{
					this.RefreshBoundingBox(false);
					this.RaisePropertyChanged<ResourceFile>(() => this.FontResource);
					this.RaisePropertyChanged<CocoStudio.Model.PointF>(() => this.Size);
				}
			}
		}

		[PropertyOrder(76), ValueRange(5, 100, 1.0), UndoProperty, Browsable(false), Category("Group_Feature"), DefaultValue(24), DisplayName("Display_FontSize")]
		public int FontSize
		{
			get
			{
				return this.GetInnerWidget().GetFontSize();
			}
			set
			{
				if (value < 1)
				{
					value = 1;
				}
				if (this.GetInnerWidget().GetFontSize() != value)
				{
					this.GetInnerWidget().SetFontSize(value);
					string compositeTaskName = base.GetType().Name + "FontSize";
					using (CompositeTask.Run(compositeTaskName))
					{
						this.RefreshBoundingBox(false);
						this.RaisePropertyChanged<int>(() => this.FontSize);
						this.RaisePropertyChanged<CocoStudio.Model.PointF>(() => this.Size);
					}
				}
			}
		}

		[PropertyOrder(74), UndoProperty, Category("Group_Feature"), DisplayName("Display_Text")]
		public string ButtonText
		{
			get
			{
				return this.text;
			}
			set
			{
				if (value != this.text)
				{
					this.text = value;
					if (value == null)
					{
						value = "";
					}
					this.GetInnerWidget().SetText(value);
					this.RaisePropertyChanged<string>(() => this.ButtonText);
					string compositeTaskName = base.GetType().Name + "ButtonText";
					using (CompositeTask.Run(compositeTaskName))
					{
						this.RefreshBoundingBox(false);
						this.RaisePropertyChanged<string>(() => this.ButtonText);
						this.RaisePropertyChanged<CocoStudio.Model.PointF>(() => this.Size);
					}
				}
			}
		}

		[PropertyOrder(75), UndoProperty, Browsable(false), Category("Group_Feature"), DisplayName("Display_TextColor"), Editor(typeof(ColorsEditor), typeof(ColorsEditor))]
		public System.Drawing.Color TextColor
		{
			get
			{
				return this._textColor;
			}
			set
			{
				if (this._textColor.B != value.B || this._textColor.G != value.G || this._textColor.R != value.R)
				{
					this._textColor = value;
					this.GetInnerWidget().SetTextColor(value);
					this.RaisePropertyChanged<System.Drawing.Color>(() => this.TextColor);
				}
			}
		}

		[PropertyOrder(14), UndoProperty, Browsable(true), Category("Group_Routine"), DefaultValue(false), DisplayName("Display_Flip"), Editor(typeof(FilpEditor), typeof(FilpEditor))]
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

		[UndoProperty]
		public virtual bool Scale9Enable
		{
			get
			{
				return this.<get_Scale9Enable>z__OriginalMethod();
			}
			set
			{
				Arguments empty = Arguments.Empty;
				LocationInterceptionArgsImpl<bool> locationInterceptionArgsImpl = new LocationInterceptionArgsImpl<bool>(this, empty);
				locationInterceptionArgsImpl.DeclarationIdentifier = new DeclarationIdentifier(-4582977439099191266L);
				locationInterceptionArgsImpl.TypedBinding = ButtonObject.<Scale9Enable>c__Binding.singleton;
				locationInterceptionArgsImpl.TypedValue = value;
				locationInterceptionArgsImpl.LocationName = "Scale9Enable";
				<>z__a_2.a1.OnSetValue(locationInterceptionArgsImpl);
			}
		}

		[UndoProperty]
		public virtual int LeftEage
		{
			get
			{
				return this._left;
			}
			set
			{
				this._left = value;
				this.RefreshScale9();
				this.RaisePropertyChanged<int>(() => this.LeftEage);
			}
		}

		[UndoProperty]
		public virtual int RightEage
		{
			get
			{
				return this._right;
			}
			set
			{
				this._right = value;
				this.RefreshScale9();
				this.RaisePropertyChanged<int>(() => this.RightEage);
			}
		}

		[UndoProperty]
		public virtual int TopEage
		{
			get
			{
				return this._top;
			}
			set
			{
				this._top = value;
				this.RefreshScale9();
				this.RaisePropertyChanged<int>(() => this.TopEage);
			}
		}

		[UndoProperty]
		public virtual int BottomEage
		{
			get
			{
				return this._bottom;
			}
			set
			{
				this._bottom = value;
				this.RefreshScale9();
				this.RaisePropertyChanged<int>(() => this.BottomEage);
			}
		}

		public virtual int Scale9OriginX
		{
			get;
			set;
		}

		public virtual int Scale9OriginY
		{
			get;
			set;
		}

		public virtual int Scale9Width
		{
			get;
			set;
		}

		public virtual int Scale9Height
		{
			get;
			set;
		}

		private CSButton GetInnerWidget()
		{
			return (CSButton)this.innerNode;
		}

		public ButtonObject()
		{
		}

		public ButtonObject(CSButton customWidget) : base(customWidget)
		{
		}

		protected override void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSButton();
			}
		}

		protected override void InitData()
		{
			base.InitData();
			this.FontResource = null;
			this.ButtonText = "Button";
			this.FontSize = 14;
			this.TextColor = System.Drawing.Color.FromArgb(255, 65, 65, 70);
			this.PressedFileData = null;
			this.DisabledFileData = null;
			this.TouchEnable = true;
			this.Filp = new FilpValue(false, false);
			this.NormalFileData = null;
		}

		private void RefreshScale9()
		{
			Gdk.Size widgetAutoSize = this.GetInnerWidget().GetWidgetAutoSize();
			int num = (this._left < widgetAutoSize.Width - this._right) ? this._left : (widgetAutoSize.Width - this._right);
			int num2 = (this._left > widgetAutoSize.Width - this._right) ? this._left : (widgetAutoSize.Width - this._right);
			int num3 = (this._bottom < widgetAutoSize.Height - this._top) ? this._bottom : (widgetAutoSize.Height - this._top);
			int num4 = (this._bottom > widgetAutoSize.Height - this._top) ? this._bottom : (widgetAutoSize.Height - this._top);
			this.Scale9OriginX = num;
			this.Scale9OriginY = widgetAutoSize.Height - num4;
			this.Scale9Width = num2 - num;
			this.Scale9Height = num4 - num3;
			this.GetInnerWidget().SetScale9Rect(this.Scale9OriginX, this.Scale9OriginY, this.Scale9Width, this.Scale9Height);
		}

		protected override void SetValue(object cObject, object cInnerObject)
		{
			base.SetValue(cObject, cInnerObject);
			ButtonObject buttonObject = cObject as ButtonObject;
			if (buttonObject != null)
			{
				buttonObject.NormalFileData = this.NormalFileData;
				buttonObject.PressedFileData = this.PressedFileData;
				buttonObject.DisabledFileData = this.DisabledFileData;
				buttonObject.FontSize = this.FontSize;
				buttonObject.ButtonText = this.ButtonText;
				buttonObject.TextColor = this.TextColor;
				buttonObject.FlipX = this.FlipX;
				buttonObject.FlipY = this.FlipY;
				buttonObject.Scale9Enable = this.Scale9Enable;
				buttonObject.LeftEage = this.LeftEage;
				buttonObject.RightEage = this.RightEage;
				buttonObject.TopEage = this.TopEage;
				buttonObject.BottomEage = this.BottomEage;
				buttonObject.DisplayState = this.DisplayState;
				buttonObject.FontResource = this.FontResource;
				buttonObject.Size = this.Size;
				buttonObject.PreSizeEnable = this.PreSizeEnable;
				buttonObject.PreSize = this.PreSize;
				buttonObject.DisplayState = this.DisplayState;
			}
		}

		protected override void OnMouseDoubleClick(MouseEventArgsExtend args)
		{
			TextEditorWindow textEditorWindow = new TextEditorWindow(this, "ButtonText", "TextColor", "FontSize", false);
		}

		private bool <get_Scale9Enable>z__OriginalMethod()
		{
			return this._scale9Enabled;
		}
	}
}
