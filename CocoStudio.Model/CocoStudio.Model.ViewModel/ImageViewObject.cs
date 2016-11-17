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
	[ModelExtension(true, 3), Catagory("Control_BaseControl", 0, 0), DisplayName("Display_Component_UIImageView")]
	public class ImageViewObject : WidgetObject, IScale9
	{
		[CompilerGenerated]
		private sealed class <Scale9Enable>c__Binding : LocationBinding<bool>
		{
			public static ImageViewObject.<Scale9Enable>c__Binding singleton = new ImageViewObject.<Scale9Enable>c__Binding();

			[DebuggerNonUserCode]
			private <Scale9Enable>c__Binding()
			{
			}

			public override DeclarationIdentifier get_DeclarationIdentifier()
			{
				return new DeclarationIdentifier(-4582977439098994684L);
			}

			public override LocationInfo get_LocationInfo()
			{
				return <>z__a_3._2;
			}

			public override bool GetValue(ref object instance, Arguments index, object aspectArgs)
			{
				return ((ImageViewObject)instance).<get_Scale9Enable>z__OriginalMethod();
			}

			public override void SetValue(ref object instance, Arguments index, bool value, object aspectArgs)
			{
				ImageViewObject imageViewObject = (ImageViewObject)instance;
				imageViewObject._scale9Enabled = value;
				imageViewObject.GetInnerWidget().SetScale9Enabled(value);
				string compositeTaskName = imageViewObject.GetType().Name + "Scale9Enable";
				using (CompositeTask.Run(compositeTaskName))
				{
					if (!value)
					{
						imageViewObject.PreSizeEnable = false;
					}
					imageViewObject.RefreshBoundingBox(false);
					imageViewObject.RaisePropertyChanged<PointF>(() => imageViewObject.Size);
					imageViewObject.RaisePropertyChanged<bool>(() => imageViewObject.Scale9Enable);
				}
			}
		}

		private ResourceFile file = null;

		private bool _scale9Enabled = false;

		private int _left = 0;

		private int _right = 0;

		private int _top = 0;

		private int _bottom = 0;

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

		[ResourceFilter(new string[]
		{
			"png",
			"jpg"
		}), PropertyOrder(59), UndoProperty, Category("Group_Feature"), DefaultValue(null), Description("Description_File"), DisplayName("Display_ImageResource"), Editor(typeof(ResourceImageEditor), typeof(ResourceImageEditor))]
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
					this.file = new ImageFile(ImageViewObjectData.DefaultFile);
				}
				this.GetInnerWidget().SetFileData(this.file.GetResourceData());
				this.RefreshScale9();
				string compositeTaskName = base.GetType().Name + "FileData";
				using (CompositeTask.Run(compositeTaskName))
				{
					this.RefreshBoundingBox(false);
					this.RaisePropertyChanged<PointF>(() => this.Size);
					this.RaisePropertyChanged<ResourceFile>(() => this.FileData);
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
				locationInterceptionArgsImpl.DeclarationIdentifier = new DeclarationIdentifier(-4582977439098994674L);
				locationInterceptionArgsImpl.TypedBinding = ImageViewObject.<Scale9Enable>c__Binding.singleton;
				locationInterceptionArgsImpl.TypedValue = value;
				locationInterceptionArgsImpl.LocationName = "Scale9Enable";
				<>z__a_3.a2.OnSetValue(locationInterceptionArgsImpl);
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

		private CSImageView GetInnerWidget()
		{
			return (CSImageView)this.innerNode;
		}

		public ImageViewObject()
		{
		}

		public ImageViewObject(CSImageView comEntiy) : base(comEntiy)
		{
		}

		protected override void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSImageView();
			}
		}

		protected override void InitData()
		{
			base.InitData();
			this.Filp = new FilpValue(false, false);
			this.FileData = null;
			this.Name = "Image_" + this.ObjectIndex;
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
			ImageViewObject imageViewObject = cObject as ImageViewObject;
			if (imageViewObject != null)
			{
				imageViewObject.FileData = this.FileData;
				imageViewObject.FlipX = this.FlipX;
				imageViewObject.FlipY = this.FlipY;
				imageViewObject.Scale9Enable = this.Scale9Enable;
				imageViewObject.LeftEage = this.LeftEage;
				imageViewObject.RightEage = this.RightEage;
				imageViewObject.TopEage = this.TopEage;
				imageViewObject.BottomEage = this.BottomEage;
				imageViewObject.Size = this.Size;
			}
		}

		private bool <get_Scale9Enable>z__OriginalMethod()
		{
			return this._scale9Enabled;
		}
	}
}
