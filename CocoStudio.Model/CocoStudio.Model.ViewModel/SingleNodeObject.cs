using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.Editor;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using System;
using System.ComponentModel;
using System.Drawing;

namespace CocoStudio.Model.ViewModel
{
	[ModelExtension(true, 13), Catagory("Control_BaseControl", 0, 0), DisplayName("Display_Component_Entity")]
	public class SingleNodeObject : NodeObject, ISingleNode
	{
		private string customClassName;

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
				this.innerNode.RefreshLayout();
				this.RefreshBoundingBox(false);
				this.RaisePropertyChanged<CocoStudio.Model.PointF>(() => this.Size);
			}
		}

		[UndoProperty, Browsable(false)]
		public override ScaleValue AnchorPoint
		{
			get
			{
				return this.GetCSVisual().GetAnchorPoint();
			}
			set
			{
				this.GetCSVisual().SetAnchorPoint(value);
				this.RaisePropertyChanged<ScaleValue>(() => this.AnchorPoint);
			}
		}

		[UndoProperty, Browsable(false)]
		public override int Alpha
		{
			get
			{
				return this.GetCSVisual().GetAlpha();
			}
			set
			{
				this.GetCSVisual().SetAlpha(value);
				this.RaisePropertyChanged<int>(() => this.Alpha);
			}
		}

		[UndoProperty, Browsable(false)]
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

		[UndoProperty, Browsable(true)]
		public override string CustomClassName
		{
			get
			{
				return this.customClassName;
			}
			set
			{
				this.customClassName = value;
				this.RaisePropertyChanged<string>(() => this.CustomClassName);
			}
		}

		public SingleNodeObject()
		{
		}

		public SingleNodeObject(CSNode customWidget) : base(customWidget)
		{
		}

		protected override void InitData()
		{
			base.InitData();
			this.Name = "Node_" + this.ObjectIndex;
			this.IsAddToCurrent = false;
			this.OperationFlag &= ~OperationMask.AnchorMoveFlag;
		}

		protected override bool CanReceiveModelObject(ModelDragData objectData)
		{
			return objectData != null && base.Parent == null;
		}
	}
}
