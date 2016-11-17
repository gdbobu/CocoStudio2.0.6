using CocoStudio.Basic;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.Interface;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;
using System.Drawing;

namespace CocoStudio.Model.ViewModel
{
	[ModelExtension(true, 53), Catagory("Control_ContainerControl", 1, 0), DisplayName("Display_Component_UIPageView")]
	public class PageViewObject : PanelObject, ICallBackEvent
	{
		private EnumCallBack callBackType = EnumCallBack.None;

		protected new string callBackName = "";

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

		private CSPageView GetInnerWidget()
		{
			return (CSPageView)this.innerNode;
		}

		public PageViewObject()
		{
		}

		public PageViewObject(CSPageView customWidget) : base(customWidget)
		{
		}

		protected override void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSPageView();
			}
		}

		protected override void InitData()
		{
			base.InitData();
			base.SingleColor = System.Drawing.Color.FromArgb(255, 150, 150, 100);
			base.FirstColor = System.Drawing.Color.FromArgb(255, 150, 150, 100);
			base.EndColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
			base.ComboBoxIndex = 1;
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

		internal override void InsertChild(int index, NodeObject nObject)
		{
			base.InsertChild(index, nObject);
			nObject.IsTransformEnabled = false;
		}

		internal override void RemoveChild(NodeObject nObject)
		{
			base.RemoveChild(nObject);
			nObject.IsTransformEnabled = true;
		}

		protected override bool CanReceiveModelObject(ModelDragData objectData)
		{
			bool result;
			if (!base.CanReceiveModelObject(objectData))
			{
				result = false;
			}
			else if (!objectData.MetaData.Type.Equals(typeof(PanelObject)))
			{
				LogConfig.Logger.Error(LanguageInfo.OutputMessage);
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		protected override bool OnDragOver(DragMotionArgs e)
		{
			bool result;
			if (e.Context.GetDataPresent(typeof(ModelDragData)))
			{
				ModelDragData modelDragData = e.Context.GetDragData() as ModelDragData;
				if (modelDragData.MetaData.Type != typeof(PanelObject))
				{
					e.SetAllowDragAction((DragAction)0);
					result = false;
					return result;
				}
			}
			result = base.OnDragOver(e);
			return result;
		}

		public override bool CanDrop(object node, DropPosition mode, bool copy)
		{
			bool result;
			if (mode == DropPosition.Add)
			{
				if (!node.GetType().Equals(typeof(PanelObject)))
				{
					LogConfig.Logger.Error(LanguageInfo.OutputMessage);
					result = false;
					return result;
				}
			}
			result = base.CanDrop(node, mode, copy);
			return result;
		}

		protected override void OnDragDrop(DragDropArgs e)
		{
			using (CompositeTask.Run("ChangeParent"))
			{
				ModelDragData modelDragData = e.Context.GetDragData() as ModelDragData;
				if (modelDragData != null && modelDragData.MetaData != null)
				{
					if (modelDragData.MetaData.Type == typeof(PanelObject))
					{
						NodeObject nodeObject = modelDragData.MetaData.CreateObject();
						CocoStudio.Model.PointF sencePoint = SceneTransformHelp.ConvertControlToScene(new CocoStudio.Model.PointF((float)e.X, (float)e.Y));
						nodeObject.Position = this.TransformToSelf(sencePoint);
						base.Children.Add(nodeObject);
					}
					else
					{
						LogConfig.Output.Error(LanguageInfo.OutputMessage);
					}
				}
				this.SetObjectState(CSNode.ObjectState.Default);
			}
		}
	}
}
