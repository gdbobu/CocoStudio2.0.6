using CocoStudio.EngineAdapterWrap;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.ViewModel
{
	[DisplayName("Display_Component_Entity")]
	public class LayerObject : NodeObject
	{
		private string customClassName;

		[PropertyOrder(2), UndoProperty, Category("Group_Routine"), DefaultValue(false), DisplayName("Display_CanUse")]
		public virtual bool TouchEnable
		{
			get
			{
				return this.GetInnerObject().IsTouchEnabled();
			}
			set
			{
				if (this.GetInnerObject().IsTouchEnabled() != value)
				{
					this.GetInnerObject().SetTouchEnabled(value);
					this.RaisePropertyChanged<bool>(() => this.TouchEnable);
				}
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

		private CSLayer GetInnerObject()
		{
			return (CSLayer)this.innerNode;
		}

		public LayerObject()
		{
		}

		public LayerObject(CSLayer customWidget) : base(customWidget)
		{
		}

		protected override void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSLayer();
			}
		}

		protected override void InitData()
		{
			base.InitData();
			this.TouchEnable = true;
		}

		protected override bool CanReceiveModelObject(ModelDragData objectData)
		{
			return objectData != null && base.Parent == null;
		}
	}
}
