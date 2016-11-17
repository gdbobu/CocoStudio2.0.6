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
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CocoStudio.Model.ViewModel
{
	[ModelExtension(true, 6), Catagory("Control_BaseControl", 0, 0), DisplayName("Display_Component_UILoadingBar")]
	public class LoadingBarObject : WidgetObject
	{
		[CompilerGenerated]
		private sealed class <Scale9Enable>c__Binding : LocationBinding<bool>
		{
			public static LoadingBarObject.<Scale9Enable>c__Binding singleton = new LoadingBarObject.<Scale9Enable>c__Binding();

			[DebuggerNonUserCode]
			private <Scale9Enable>c__Binding()
			{
			}

			public override DeclarationIdentifier get_DeclarationIdentifier()
			{
				return new DeclarationIdentifier(-4582977439098601469L);
			}

			public override LocationInfo get_LocationInfo()
			{
				return <>z__a_5._2;
			}

			public override void SetValue(ref object instance, Arguments index, bool value, object aspectArgs)
			{
				LoadingBarObject loadingBarObject = (LoadingBarObject)instance;
				loadingBarObject._scale9Enabled = value;
				loadingBarObject.GetInnerWidget().SetScale9Enabled(value);
				string compositeTaskName = loadingBarObject.GetType().Name + "Scale9Enable";
				using (CompositeTask.Run(compositeTaskName))
				{
					loadingBarObject.RefreshBoundingBox(false);
					loadingBarObject.RaisePropertyChanged<PointF>(() => loadingBarObject.Size);
					loadingBarObject.RaisePropertyChanged<bool>(() => loadingBarObject.Scale9Enable);
				}
			}

			public override bool GetValue(ref object instance, Arguments index, object aspectArgs)
			{
				return ((LoadingBarObject)instance).<get_Scale9Enable>z__OriginalMethod();
			}
		}

		private ResourceFile file = null;

		private bool _scale9Enabled = false;

		private int _left = 0;

		private int _right = 0;

		private int _top = 0;

		private int _bottom = 0;

		[ResourceFilter(new string[]
		{
			"png",
			"jpg"
		}), PropertyOrder(50), UndoProperty, Category("Group_Feature"), DefaultValue(null), DisplayName("Display_ImageResources"), Editor(typeof(ResourceImageEditor), typeof(ResourceImageEditor))]
		public ResourceFile ImageFileData
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
					this.file = new ImageFile(LoadingBarObjectData.DefaultFile);
				}
				this.GetInnerWidget().SetFileData(this.file.GetResourceData());
				this.RefreshScale9();
				string compositeTaskName = base.GetType().Name + "ImageFileData";
				using (CompositeTask.Run(compositeTaskName))
				{
					this.RefreshBoundingBox(false);
					this.RaisePropertyChanged<PointF>(() => this.Size);
					this.RaisePropertyChanged<ResourceFile>(() => this.ImageFileData);
				}
			}
		}

		[PropertyOrder(51), ValueRange(0, 100, 1.0), UndoProperty, Category("Group_Feature"), DisplayName("Display_Progress"), Editor(typeof(SliderEditor), typeof(SliderEditor))]
		public int ProgressInfo
		{
			get
			{
				return this.GetInnerWidget().GetProgressPercent();
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
				this.GetInnerWidget().SetProgressPercent(num);
				this.RaisePropertyChanged<int>(() => this.ProgressInfo);
			}
		}

		[PropertyOrder(52), UndoProperty, Category("Group_Feature"), DefaultValue(null), DisplayName("Display_ProgressType")]
		public LoadingBarDirectionType ProgressType
		{
			get
			{
				return (LoadingBarDirectionType)this.GetInnerWidget().GetProgressType();
			}
			set
			{
				this.GetInnerWidget().SetProgressType((int)value);
				this.RaisePropertyChanged<LoadingBarDirectionType>(() => this.ProgressType);
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
				locationInterceptionArgsImpl.DeclarationIdentifier = new DeclarationIdentifier(-4582977439098601460L);
				locationInterceptionArgsImpl.TypedBinding = LoadingBarObject.<Scale9Enable>c__Binding.singleton;
				locationInterceptionArgsImpl.TypedValue = value;
				locationInterceptionArgsImpl.LocationName = "Scale9Enable";
				<>z__a_5.a4.OnSetValue(locationInterceptionArgsImpl);
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

		private CSLoadingBar GetInnerWidget()
		{
			return (CSLoadingBar)this.innerNode;
		}

		public LoadingBarObject()
		{
		}

		public LoadingBarObject(CSLoadingBar customWidget) : base(customWidget)
		{
		}

		protected override void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSLoadingBar();
			}
		}

		protected override void InitData()
		{
			base.InitData();
			this.ImageFileData = null;
			this.ProgressInfo = 80;
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
			LoadingBarObject loadingBarObject = cObject as LoadingBarObject;
			if (loadingBarObject != null)
			{
				loadingBarObject.ImageFileData = this.ImageFileData;
				loadingBarObject.ProgressInfo = this.ProgressInfo;
				loadingBarObject.ProgressType = this.ProgressType;
				loadingBarObject.Scale9Enable = this.Scale9Enable;
				loadingBarObject.LeftEage = this.LeftEage;
				loadingBarObject.RightEage = this.RightEage;
				loadingBarObject.TopEage = this.TopEage;
				loadingBarObject.BottomEage = this.BottomEage;
				loadingBarObject.Size = this.Size;
			}
		}

		private bool <get_Scale9Enable>z__OriginalMethod()
		{
			return this._scale9Enabled;
		}
	}
}
