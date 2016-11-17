using CocoStudio.Basic;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Lib.Prism;
using CocoStudio.Model.Editor;
using CocoStudio.Model.Event;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace CocoStudio.Model.ViewModel
{
	[ModelExtension(true, 52), Catagory("Control_ContainerControl", 1, 0), DisplayName("Display_Component_UIListview")]
	public class ListViewObject : PanelObject, IListViewType
	{
		private ListViewHorizontal horizontalType = ListViewHorizontal.Align_Left;

		private ListViewVertical verticalType = ListViewVertical.Align_Top;

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

		[PropertyOrder(22), ValueRange(-10000, 10000, 1.0), UndoProperty, Browsable(true), Category("Group_Feature"), DisplayName("Category_Component_Children_Interval")]
		public int ItemMargin
		{
			get
			{
				return this.GetInnerWidget().GetItemSpace();
			}
			set
			{
				if (this.GetInnerWidget().GetItemSpace() != value)
				{
					this.GetInnerWidget().SetItemSpace(value);
					this.RaisePropertyChanged<int>(() => this.ItemMargin);
				}
			}
		}

		[PropertyOrder(22), UndoProperty, Browsable(true), Category("Group_Feature"), DisplayName("Display_Component_Layout"), Editor(typeof(UIListViewEditor), typeof(UIListViewEditor))]
		public ListViewDirectionType DirectionType
		{
			get
			{
				return (ListViewDirectionType)this.GetInnerWidget().GetDirectionType();
			}
			set
			{
				this.GetInnerWidget().SetDirectionType((int)value);
				if (value == ListViewDirectionType.Horizontal)
				{
					this.GetInnerWidget().SetGravityType((int)this.verticalType);
				}
				else if (value == ListViewDirectionType.Vertical)
				{
					this.GetInnerWidget().SetGravityType((int)this.horizontalType);
				}
				this.RaisePropertyChanged<ListViewDirectionType>(() => this.DirectionType);
			}
		}

		[UndoProperty]
		public ListViewHorizontal HorizontalType
		{
			get
			{
				return this.horizontalType;
			}
			set
			{
				this.horizontalType = value;
				if (this.DirectionType == ListViewDirectionType.Vertical)
				{
					this.GetInnerWidget().SetGravityType((int)value);
				}
				this.RaisePropertyChanged<ListViewHorizontal>(() => this.HorizontalType);
			}
		}

		[UndoProperty]
		public ListViewVertical VerticalType
		{
			get
			{
				return this.verticalType;
			}
			set
			{
				this.verticalType = value;
				if (this.DirectionType == ListViewDirectionType.Horizontal)
				{
					this.GetInnerWidget().SetGravityType((int)value);
				}
				this.RaisePropertyChanged<ListViewVertical>(() => this.VerticalType);
			}
		}

		private CSListView GetInnerWidget()
		{
			return (CSListView)this.innerNode;
		}

		public ListViewObject()
		{
		}

		public ListViewObject(CSListView customWidget) : base(customWidget)
		{
		}

		protected override void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSListView();
			}
		}

		protected override void InitData()
		{
			base.InitData();
			base.SingleColor = System.Drawing.Color.FromArgb(255, 150, 150, 255);
			base.FirstColor = System.Drawing.Color.FromArgb(255, 150, 150, 255);
			base.EndColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
			base.ComboBoxIndex = 1;
			this.DirectionType = ListViewDirectionType.Vertical;
			this.HorizontalType = ListViewHorizontal.Align_Left;
			this.VerticalType = ListViewVertical.Align_Top;
		}

		internal override void RefreshBoundingBox(bool bRefresh = false)
		{
			if (bRefresh)
			{
				this.RaisePropertyChanged<CocoStudio.Model.PointF>(() => this.Size, false);
			}
			this.innerNode.RefreshBoundingObjects();
			foreach (NodeObject current in base.Children)
			{
				current.RefreshBoundingBox(true);
			}
		}

		protected override void SetValue(object cObject, object cInnerObject)
		{
			base.SetValue(cObject, cInnerObject);
			ListViewObject listViewObject = cObject as ListViewObject;
			if (listViewObject != null)
			{
				listViewObject.IsBounceEnabled = this.IsBounceEnabled;
				listViewObject.DirectionType = this.DirectionType;
				listViewObject.HorizontalType = this.HorizontalType;
				listViewObject.VerticalType = this.VerticalType;
				listViewObject.ItemMargin = this.ItemMargin;
			}
		}

		private void ChildPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Size")
			{
				foreach (NodeObject current in base.Children)
				{
					current.PropertyChanged -= new PropertyChangedEventHandler(this.ChildPropertyChanged);
				}
				this.RefreshBoundingBox(false);
				foreach (NodeObject current in base.Children)
				{
					current.PropertyChanged += new PropertyChangedEventHandler(this.ChildPropertyChanged);
				}
			}
		}

		internal override void InsertChild(int index, NodeObject nObject)
		{
			base.InsertChild(index, nObject);
			nObject.IsTransformEnabled = false;
			nObject.PropertyChanged += new PropertyChangedEventHandler(this.ChildPropertyChanged);
		}

		internal override void RemoveChild(NodeObject nObject)
		{
			base.RemoveChild(nObject);
			nObject.IsTransformEnabled = true;
			nObject.PropertyChanged -= new PropertyChangedEventHandler(this.ChildPropertyChanged);
		}

		protected override bool CanReceiveModelObject(ModelDragData objectData)
		{
			bool result;
			if (!base.CanReceiveModelObject(objectData))
			{
				result = false;
			}
			else if (!typeof(WidgetObject).IsAssignableFrom(objectData.MetaData.Type))
			{
				if (this.CanShowMessage)
				{
					LogConfig.Output.Info(LanguageInfo.ListViewOutputMessage);
					this.CanShowMessage = false;
				}
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		protected override bool CanReceiveResourceObject(ResourceInfoDragData objectData)
		{
			if (this.CanShowMessage)
			{
				LogConfig.Output.Info(LanguageInfo.ListViewOutputMessage);
				this.CanShowMessage = false;
			}
			return false;
		}

		protected override bool OnDragOver(DragMotionArgs e)
		{
			bool result;
			if (e.Context.GetDataPresent(typeof(ModelDragData)))
			{
				ModelDragData modelDragData = e.Context.GetDragData() as ModelDragData;
				if (!typeof(WidgetObject).IsAssignableFrom(modelDragData.MetaData.Type))
				{
					e.SetAllowDragAction((DragAction)0);
					result = false;
					return result;
				}
			}
			result = base.OnDragOver(e);
			return result;
		}

		protected override void OnDragDrop(DragDropArgs e)
		{
			using (CompositeTask.Run("ChangeParent"))
			{
				ModelDragData modelDragData = e.Context.GetDragData() as ModelDragData;
				if (modelDragData != null && modelDragData.MetaData != null)
				{
					if (typeof(WidgetObject).IsAssignableFrom(modelDragData.MetaData.Type))
					{
						List<VisualObject> list = new List<VisualObject>();
						NodeObject nodeObject = modelDragData.MetaData.CreateObject();
						CocoStudio.Model.PointF sencePoint = SceneTransformHelp.ConvertControlToScene(new CocoStudio.Model.PointF((float)e.X, (float)e.Y));
						nodeObject.Position = this.TransformToSelf(sencePoint);
						base.Children.Add(nodeObject);
						list.Add(nodeObject);
						EventAggregator.Instance.GetEvent<SelectedVisualObjectsChangeEvent>().Publish(new SelectedVisualObjectsChangeEventArgs(list, list, false));
					}
					else
					{
						LogConfig.Output.Info(LanguageInfo.ListViewOutputMessage);
					}
				}
				this.SetObjectState(CSNode.ObjectState.Default);
			}
		}

		public override bool CanDrop(object node, DropPosition mode, bool copy)
		{
			bool result;
			if (mode == DropPosition.Add)
			{
				if (!(node is WidgetObject))
				{
					LogConfig.Output.Info(LanguageInfo.ListViewOutputMessage);
					result = false;
					return result;
				}
			}
			result = base.CanDrop(node, mode, copy);
			return result;
		}
	}
}
