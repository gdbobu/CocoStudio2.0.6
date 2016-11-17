using CocoStudio.Basic;
using CocoStudio.EngineAdapterWrap;
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
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace CocoStudio.Model.ViewModel
{
	[ModelExtension(true, 50), Catagory("Control_ContainerControl", 1, 0), DisplayName("Display_Component_UIPanel")]
	public class PanelObject : WidgetObject, IColorValue, IScale9
	{
		[CompilerGenerated]
		private sealed class <Scale9Enable>c__Binding : LocationBinding<bool>
		{
			public static PanelObject.<Scale9Enable>c__Binding singleton = new PanelObject.<Scale9Enable>c__Binding();

			[DebuggerNonUserCode]
			private <Scale9Enable>c__Binding()
			{
			}

			public override DeclarationIdentifier get_DeclarationIdentifier()
			{
				return new DeclarationIdentifier(-4582977439098732535L);
			}

			public override LocationInfo get_LocationInfo()
			{
				return <>z__a_4._2;
			}

			public override void SetValue(ref object instance, Arguments index, bool value, object aspectArgs)
			{
				PanelObject panelObject = (PanelObject)instance;
				panelObject._scale9Enabled = value;
				panelObject.GetInnerWidget().SetScale9Enabled(value);
				panelObject.RefreshScale9();
				panelObject.RaisePropertyChanged<bool>(() => panelObject.Scale9Enable);
			}

			public override bool GetValue(ref object instance, Arguments index, object aspectArgs)
			{
				return ((PanelObject)instance).<get_Scale9Enable>z__OriginalMethod();
			}
		}

		private ResourceFile file = null;

		private float _colorAngle = 0f;

		private bool _scale9Enabled = false;

		private int _left = 0;

		private int _right = 0;

		private int _top = 0;

		private int _bottom = 0;

		private EnumCallBack callBackType = EnumCallBack.None;

		protected new string callBackName = "";

		[PropertyOrder(18), UndoProperty, Category("Group_Feature"), DisplayName("Display_Clip")]
		public virtual bool ClipAble
		{
			get
			{
				return this.GetInnerWidget().GetClipAble();
			}
			set
			{
				this.GetInnerWidget().SetClipAble(value);
				this.RaisePropertyChanged<bool>(() => this.ClipAble);
			}
		}

		[ResourceFilter(new string[]
		{
			"png",
			"jpg"
		}), PropertyOrder(23), UndoProperty, Category("Group_Feature"), DefaultValue(null), DisplayName("Display_BackgroundImage"), Editor(typeof(ResourceImageEditor), typeof(ResourceImageEditor))]
		public ResourceFile FileData
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
					this.GetInnerWidget().RemoveBackGroundFile();
				}
				else
				{
					this.GetInnerWidget().SetFilePath(this.file.GetResourceData());
					this.RefreshScale9();
				}
				string compositeTaskName = base.GetType().Name + "FileData";
				using (CompositeTask.Run(compositeTaskName))
				{
					this.RefreshBoundingBox(false);
					this.RaisePropertyChanged<CocoStudio.Model.PointF>(() => this.Size);
					this.RaisePropertyChanged<ResourceFile>(() => this.FileData);
				}
			}
		}

		[PropertyOrder(24), UndoProperty, Category("Group_Feature"), DisplayName("Fill_color"), Editor(typeof(ChangeColorEditor), typeof(ChangeColorEditor))]
		public int ComboBoxIndex
		{
			get
			{
				return this.GetInnerWidget().GetGroundColorType();
			}
			set
			{
				this.GetInnerWidget().SetGroundColorType(value);
				this.RaisePropertyChanged<int>(() => this.ComboBoxIndex);
			}
		}

		[UndoProperty]
		public System.Drawing.Color EndColor
		{
			get
			{
				return this.GetInnerWidget().GetGroundLineEndColor();
			}
			set
			{
				this.GetInnerWidget().SetGroundLineEndColor(value);
				this.RaisePropertyChanged<System.Drawing.Color>(() => this.EndColor);
			}
		}

		[UndoProperty]
		public System.Drawing.Color FirstColor
		{
			get
			{
				return this.GetInnerWidget().GetGroundLineStartColor();
			}
			set
			{
				this.GetInnerWidget().SetGroundSingleColor(value);
				this.GetInnerWidget().SetGroundLineStartColor(value);
				this.RaisePropertyChanged<System.Drawing.Color>(() => this.FirstColor);
			}
		}

		[UndoProperty]
		public System.Drawing.Color SingleColor
		{
			get
			{
				return this.GetInnerWidget().GetGroundSingleColor();
			}
			set
			{
				this.GetInnerWidget().SetGroundSingleColor(value);
				this.GetInnerWidget().SetGroundLineStartColor(value);
				this.RaisePropertyChanged<System.Drawing.Color>(() => this.SingleColor);
			}
		}

		[UndoProperty]
		public float ColorAngle
		{
			get
			{
				return this._colorAngle;
			}
			set
			{
				if (this._colorAngle != value)
				{
					this._colorAngle = value;
					float num = (float)(3.1415926535897931 * (double)(90f - this._colorAngle) / 180.0);
					float scaleX = (float)Math.Sin((double)num);
					float scaleY = (float)Math.Cos((double)num);
					this.ColorVector = new ScaleValue(scaleX, scaleY, 0.1, -99999999.0, 99999999.0);
					this.GetInnerWidget().SetGroundColorVector(this.ColorVector);
					this.RaisePropertyChanged<float>(() => this.ColorAngle);
				}
			}
		}

		public ScaleValue ColorVector
		{
			get;
			set;
		}

		[PropertyOrder(26), ValueRange(0, 255, 1.0), UndoProperty, Browsable(false), Category("Group_Feature"), DisplayName("Background_color_transparency"), Editor(typeof(SliderEditor), typeof(SliderEditor))]
		public virtual int BackColorAlpha
		{
			get
			{
				return this.GetInnerWidget().GetGroundAlpha();
			}
			set
			{
				if (this.GetInnerWidget().GetGroundAlpha() != value)
				{
					this.GetInnerWidget().SetGroundAlpha(value);
					this.RaisePropertyChanged<int>(() => this.BackColorAlpha);
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
				locationInterceptionArgsImpl.DeclarationIdentifier = new DeclarationIdentifier(-4582977439098732520L);
				locationInterceptionArgsImpl.TypedBinding = PanelObject.<Scale9Enable>c__Binding.singleton;
				locationInterceptionArgsImpl.TypedValue = value;
				locationInterceptionArgsImpl.LocationName = "Scale9Enable";
				<>z__a_4.a3.OnSetValue(locationInterceptionArgsImpl);
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

		[UndoProperty, Browsable(true)]
		public override EnumCallBack CallBackType
		{
			get
			{
				return this.callBackType;
			}
			set
			{
				this.callBackType = value;
				this.RaisePropertyChanged<EnumCallBack>(() => this.CallBackType);
			}
		}

		[UndoProperty]
		public override string CallBackName
		{
			get
			{
				return this.callBackName;
			}
			set
			{
				this.callBackName = value;
				this.RaisePropertyChanged<string>(() => this.CallBackName);
			}
		}

		private CSPanel GetInnerWidget()
		{
			return (CSPanel)this.innerNode;
		}

		public PanelObject()
		{
		}

		public PanelObject(CSPanel customWidget) : base(customWidget)
		{
		}

		protected override void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSPanel();
			}
		}

		protected override void InitData()
		{
			base.InitData();
			this.BackColorAlpha = 102;
			this.SingleColor = System.Drawing.Color.FromArgb(255, 150, 200, 255);
			this.FirstColor = System.Drawing.Color.FromArgb(255, 150, 200, 255);
			this.EndColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
			this.ComboBoxIndex = 1;
			this.ColorAngle = 90f;
			this.Size = new CocoStudio.Model.PointF(200f, 200f);
			this.TouchEnable = true;
			this.ClipAble = false;
			this.IsAddToCurrent = true;
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

		protected override bool CanReceiveModelObject(ModelDragData objectData)
		{
			return objectData != null;
		}

		protected override bool CanContinueTest()
		{
			return base.CanContinueTest() && !this.ClipAble;
		}

		protected override void SetValue(object cObject, object cInnerObject)
		{
			base.SetValue(cObject, cInnerObject);
			PanelObject panelObject = cObject as PanelObject;
			if (panelObject != null)
			{
				panelObject.FileData = this.FileData;
				panelObject.Alpha = this.Alpha;
				panelObject.CColor = this.CColor;
				panelObject.BackColorAlpha = this.BackColorAlpha;
				panelObject.ClipAble = this.ClipAble;
				panelObject.SingleColor = this.SingleColor;
				panelObject.FirstColor = this.FirstColor;
				panelObject.EndColor = this.EndColor;
				panelObject.ColorAngle = this.ColorAngle;
				panelObject.ComboBoxIndex = this.ComboBoxIndex;
				panelObject.Scale9Enable = this.Scale9Enable;
				panelObject.LeftEage = this.LeftEage;
				panelObject.RightEage = this.RightEage;
				panelObject.TopEage = this.TopEage;
				panelObject.BottomEage = this.BottomEage;
				panelObject.Size = this.Size;
			}
		}

		private bool <get_Scale9Enable>z__OriginalMethod()
		{
			return this._scale9Enabled;
		}
	}
}
