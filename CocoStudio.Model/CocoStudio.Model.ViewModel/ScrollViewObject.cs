using CocoStudio.Basic;
using CocoStudio.Core;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.Editor;
using CocoStudio.Model.Interface;
using CocoStudio.Model.Visiter;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using Gdk;
using System;
using System.ComponentModel;
using System.Drawing;

namespace CocoStudio.Model.ViewModel
{
	[ModelExtension(true, 51), Catagory("Control_ContainerControl", 1, 0), DisplayName("Display_Component_UIScrollview")]
	public class ScrollViewObject : PanelObject, ICallBackEvent
	{
		private EnumCallBack callBackType = EnumCallBack.None;

		protected new string callBackName = "";

		[PropertyOrder(16), UndoProperty, Browsable(true), Category("grid_sudoku"), DisplayName("grid_sudoku_size"), Editor(typeof(UIControlSizeEditor), typeof(UIControlSizeEditor))]
		public override CocoStudio.Model.PointF Size
		{
			get
			{
				return this.GetCSVisual().GetSize();
			}
			set
			{
				this.GetCSVisual().SetSize(value);
				using (CompositeTask.Run("InnerNodeSize"))
				{
					this.RefreshBoundingBox(false);
					this.RaisePropertyChanged<SizeValue>(() => this.InnerNodeSize);
					this.RaisePropertyChanged<CocoStudio.Model.PointF>(() => this.Size);
				}
			}
		}

		[PropertyOrder(19), UndoProperty, Browsable(true), Category("Group_Feature"), Description("Description_ScrollAreaWidth"), DisplayName("Description_ScrollAreaWidth"), Editor(typeof(SizeEditor), typeof(SizeEditor))]
		public virtual SizeValue InnerNodeSize
		{
			get
			{
				return new SizeValue(this.GetInnerWidget().GetInnerSize().Width, this.GetInnerWidget().GetInnerSize().Height);
			}
			set
			{
				if (this.GetInnerWidget().GetInnerSize().Width != value.Width || this.GetInnerWidget().GetInnerSize().Height != value.Height)
				{
					this.GetInnerWidget().SetInnerSize(new Gdk.Size(value.Width, value.Height));
					this.RaisePropertyChanged<SizeValue>(() => this.InnerNodeSize);
				}
			}
		}

		[PropertyOrder(21), UndoProperty, Category("Group_Feature"), Description("Description_ScrollDirection"), DisplayName("Description_ScrollDirection")]
		public virtual ScrollViewDirectionType ScrollDirectionType
		{
			get
			{
				return (ScrollViewDirectionType)this.GetInnerWidget().GetDirectionType();
			}
			set
			{
				this.GetInnerWidget().SetDirectionType((int)value);
				this.RaisePropertyChanged<ScrollViewDirectionType>(() => this.ScrollDirectionType);
			}
		}

		[PropertyOrder(20), UndoProperty, Category("Group_Feature"), Description("Display_OpenResilience"), DisplayName("Display_OpenResilience")]
		public bool IsBounceEnabled
		{
			get
			{
				return this.GetInnerWidget().GetBounceEnabled();
			}
			set
			{
				if (this.GetInnerWidget().GetBounceEnabled() != value)
				{
					this.GetInnerWidget().SetBounceEnabled(value);
					this.RaisePropertyChanged<bool>(() => this.IsBounceEnabled);
				}
			}
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

		private CSScrollView GetInnerWidget()
		{
			return (CSScrollView)this.innerNode;
		}

		public ScrollViewObject()
		{
		}

		public ScrollViewObject(CSScrollView customWidget) : base(customWidget)
		{
		}

		protected override void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSScrollView();
			}
		}

		protected override void InitData()
		{
			base.InitData();
			base.SingleColor = System.Drawing.Color.FromArgb(255, 255, 150, 100);
			base.FirstColor = System.Drawing.Color.FromArgb(255, 255, 150, 100);
			base.EndColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
			base.ComboBoxIndex = 1;
			this.ScrollDirectionType = ScrollViewDirectionType.Vertical;
			this.InnerNodeSize = new SizeValue(200, 300);
		}

		protected override void SetValue(object cObject, object cInnerObject)
		{
			base.SetValue(cObject, cInnerObject);
			ScrollViewObject scrollViewObject = cObject as ScrollViewObject;
			if (scrollViewObject != null)
			{
				scrollViewObject.ScrollDirectionType = this.ScrollDirectionType;
				scrollViewObject.InnerNodeSize = this.InnerNodeSize;
				scrollViewObject.IsBounceEnabled = this.IsBounceEnabled;
			}
		}

		protected virtual CocoStudio.Model.PointF TransFormToInner(CocoStudio.Model.PointF sencePoint)
		{
			return this.GetInnerWidget().TransformToSelfInner(sencePoint);
		}

		protected override void LoadNodeObject(NodeObject gObject, CocoStudio.Model.PointF coord)
		{
			if (gObject != null)
			{
				CocoStudio.Model.PointF sencePoint = SceneTransformHelp.ConvertControlToScene(coord);
				NodeObject nodeObject;
				CocoStudio.Model.PointF position;
				if (this.IsAddToCurrent)
				{
					nodeObject = this;
					position = this.TransFormToInner(sencePoint);
				}
				else
				{
					nodeObject = Services.ProjectOperations.CurrentSelectedProject.GetRootNode();
					position = nodeObject.TransformToSelf(sencePoint);
				}
				gObject.Position = position;
				nodeObject.Children.Add(gObject);
			}
		}
	}
}
