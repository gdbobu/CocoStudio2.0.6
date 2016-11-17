using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.DataModel;
using CocoStudio.Model.Editor;
using CocoStudio.Model.Interface;
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
using System.Runtime.CompilerServices;

namespace CocoStudio.Model.ViewModel
{
	[ModelExtension(true, 7), Catagory("Control_BaseControl", 0, 0), DisplayName("Display_Component_UISlider")]
	public class SliderObject : WidgetObject, IDisplayState, ICallBackEvent
	{
		[CompilerGenerated]
		private sealed class <Scale9Enable>c__Binding : LocationBinding<bool>
		{
			public static SliderObject.<Scale9Enable>c__Binding singleton = new SliderObject.<Scale9Enable>c__Binding();

			[DebuggerNonUserCode]
			private <Scale9Enable>c__Binding()
			{
			}

			public override DeclarationIdentifier get_DeclarationIdentifier()
			{
				return new DeclarationIdentifier(-4582977439098404855L);
			}

			public override LocationInfo get_LocationInfo()
			{
				return <>z__a_6._2;
			}

			public override void SetValue(ref object instance, Arguments index, bool value, object aspectArgs)
			{
				SliderObject sliderObject = (SliderObject)instance;
				sliderObject._scale9Enabled = value;
				sliderObject.GetInnerWidget().SetScale9Enabled(value);
				string compositeTaskName = sliderObject.GetType().Name + "Scale9Enable";
				using (CompositeTask.Run(compositeTaskName))
				{
					sliderObject.RefreshBoundingBox(false);
					sliderObject.RaisePropertyChanged<PointF>(() => sliderObject.Size);
					sliderObject.RaisePropertyChanged<bool>(() => sliderObject.Scale9Enable);
				}
			}

			public override bool GetValue(ref object instance, Arguments index, object aspectArgs)
			{
				return ((SliderObject)instance).<get_Scale9Enable>z__OriginalMethod();
			}
		}

		private bool isNormal = true;

		private ResourceFile backGroundFile = null;

		private ResourceFile progressBarFile = null;

		private ResourceFile ballNormalFile = null;

		private ResourceFile ballPressedFile = null;

		private ResourceFile ballDisableFile = null;

		private bool _scale9Enabled = false;

		private int _left = 0;

		private int _right = 0;

		private int _top = 0;

		private int _bottom = 0;

		[PropertyOrder(48), UndoProperty, Category("Group_Feature"), DefaultValue(true), DisplayName("Display_State"), Editor(typeof(CheckBoxEditor), typeof(CheckBoxEditor))]
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

		[PropertyOrder(43), Category("Group_Feature"), DefaultValue(null), DisplayName("Display_ImageResources"), Editor(typeof(ResourceGroupEditor), typeof(ResourceGroupEditor))]
		public virtual List<string> ResourceValue
		{
			get
			{
				return new List<string>
				{
					"BackGroundData",
					"ProgressBarData"
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
		}), UndoProperty, DefaultValue(null), DisplayName("ContexMenu_BackgroundStyle"), Editor(typeof(ResourceImageEditor), typeof(ResourceImageEditor))]
		public virtual ResourceFile BackGroundData
		{
			get
			{
				return this.backGroundFile;
			}
			set
			{
				this.backGroundFile = value;
				if (this.backGroundFile == null || !this.backGroundFile.IsValid)
				{
					this.backGroundFile = new ImageFile(SliderObjectData.DefaultBackgroundFile);
				}
				this.GetInnerWidget().SetGroundBarTexture(this.backGroundFile.GetResourceData());
				this.RefreshScale9();
				string compositeTaskName = base.GetType().Name + "BackGroundData";
				using (CompositeTask.Run(compositeTaskName))
				{
					this.RefreshBoundingBox(false);
					this.RaisePropertyChanged<PointF>(() => this.Size);
					this.RaisePropertyChanged<ResourceFile>(() => this.BackGroundData);
				}
			}
		}

		[ResourceFilter(new string[]
		{
			"png",
			"jpg"
		}), UndoProperty, DefaultValue(null), DisplayName("ContexMenu_InnerSliderStyle"), Editor(typeof(ResourceImageEditor), typeof(ResourceImageEditor))]
		public virtual ResourceFile ProgressBarData
		{
			get
			{
				return this.progressBarFile;
			}
			set
			{
				this.progressBarFile = value;
				if (this.progressBarFile == null || !this.progressBarFile.IsValid)
				{
					this.progressBarFile = new ImageFile(SliderObjectData.DefaultProgressBarFile);
				}
				this.RefreshScale9();
				this.GetInnerWidget().SetProgressBarTexture(this.progressBarFile.GetResourceData());
				this.RaisePropertyChanged<ResourceFile>(() => this.ProgressBarData);
			}
		}

		[PropertyOrder(47), Category("Group_Feature"), DisplayName("Display_NodeResource"), Editor(typeof(ResourceGroupEditor), typeof(ResourceGroupEditor))]
		public virtual List<string> ResourceNodeValue
		{
			get
			{
				return new List<string>
				{
					"BallNormalData",
					"BallPressedData",
					"BallDisabledData"
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
		}), UndoProperty, DefaultValue(null), DisplayName("ContexMenu_NodeNormalStyle"), Editor(typeof(ResourceImageEditor), typeof(ResourceImageEditor))]
		public virtual ResourceFile BallNormalData
		{
			get
			{
				return this.ballNormalFile;
			}
			set
			{
				this.ballNormalFile = value;
				if (this.ballNormalFile == null || !this.ballNormalFile.IsValid)
				{
					this.ballNormalFile = new ImageFile(SliderObjectData.DefaultBallNormalFile);
				}
				this.GetInnerWidget().SetBallNormalTexture(this.ballNormalFile.GetResourceData());
				this.RaisePropertyChanged<ResourceFile>(() => this.BallNormalData);
			}
		}

		[ResourceFilter(new string[]
		{
			"png",
			"jpg"
		}), UndoProperty, DefaultValue(null), DisplayName("ContexMenu_NodePressedStyle"), Editor(typeof(ResourceImageEditor), typeof(ResourceImageEditor))]
		public virtual ResourceFile BallPressedData
		{
			get
			{
				return this.ballPressedFile;
			}
			set
			{
				this.ballPressedFile = value;
				if (this.ballPressedFile == null || !this.ballNormalFile.IsValid)
				{
					this.ballPressedFile = new ImageFile(SliderObjectData.DefaultBallPressedFile);
				}
				this.GetInnerWidget().SetBallPressedTexture(this.ballPressedFile.GetResourceData());
				this.RaisePropertyChanged<ResourceFile>(() => this.BallPressedData);
			}
		}

		[ResourceFilter(new string[]
		{
			"png",
			"jpg"
		}), UndoProperty, DefaultValue(null), DisplayName("ContexMenu_NodeDisabledStyle"), Editor(typeof(ResourceImageEditor), typeof(ResourceImageEditor))]
		public virtual ResourceFile BallDisabledData
		{
			get
			{
				return this.ballDisableFile;
			}
			set
			{
				this.ballDisableFile = value;
				if (this.ballDisableFile == null || !this.ballDisableFile.IsValid)
				{
					this.ballDisableFile = new ImageFile(SliderObjectData.DefaultBallDisabledFile);
				}
				this.GetInnerWidget().SetBallDisabledTexture(this.ballDisableFile.GetResourceData());
				this.RaisePropertyChanged<ResourceFile>(() => this.BallDisabledData);
			}
		}

		[PropertyOrder(49), ValueRange(0, 100, 1.0), UndoProperty, Category("Group_Feature"), DefaultValue(50), DisplayName("Display_SliderProgress"), Editor(typeof(SliderEditor), typeof(SliderEditor))]
		public virtual int PercentInfo
		{
			get
			{
				return this.GetInnerWidget().GetPercent();
			}
			set
			{
				int num = value;
				if (num < 0)
				{
					num = 0;
				}
				else if (num > 100)
				{
					num = 100;
				}
				this.GetInnerWidget().SetPercent(num);
				this.RaisePropertyChanged<int>(() => this.PercentInfo);
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
				locationInterceptionArgsImpl.DeclarationIdentifier = new DeclarationIdentifier(-4582977439098404840L);
				locationInterceptionArgsImpl.TypedBinding = SliderObject.<Scale9Enable>c__Binding.singleton;
				locationInterceptionArgsImpl.TypedValue = value;
				locationInterceptionArgsImpl.LocationName = "Scale9Enable";
				<>z__a_6.a5.OnSetValue(locationInterceptionArgsImpl);
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

		private CSSlider GetInnerWidget()
		{
			return (CSSlider)this.innerNode;
		}

		public SliderObject()
		{
		}

		public SliderObject(CSSlider customWidget) : base(customWidget)
		{
		}

		protected override void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSSlider();
			}
		}

		protected override void InitData()
		{
			base.InitData();
			this.BallPressedData = null;
			this.BallDisabledData = null;
			this.ProgressBarData = null;
			this.BackGroundData = null;
			this.BallNormalData = null;
			this.PercentInfo = 50;
			this.TouchEnable = true;
		}

		private void RefreshScale9()
		{
			Size widgetAutoSize = this.GetInnerWidget().GetWidgetAutoSize();
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
			SliderObject sliderObject = cObject as SliderObject;
			if (sliderObject != null)
			{
				sliderObject.BackGroundData = this.BackGroundData;
				sliderObject.ProgressBarData = this.ProgressBarData;
				sliderObject.BallNormalData = this.BallNormalData;
				sliderObject.BallPressedData = this.BallPressedData;
				sliderObject.BallDisabledData = this.BallDisabledData;
				sliderObject.Scale9Enable = this.Scale9Enable;
				sliderObject.LeftEage = this.LeftEage;
				sliderObject.RightEage = this.RightEage;
				sliderObject.TopEage = this.TopEage;
				sliderObject.BottomEage = this.BottomEage;
				sliderObject.PercentInfo = this.PercentInfo;
				sliderObject.Size = this.Size;
				sliderObject.DisplayState = this.DisplayState;
			}
		}

		private bool <get_Scale9Enable>z__OriginalMethod()
		{
			return this._scale9Enabled;
		}
	}
}
