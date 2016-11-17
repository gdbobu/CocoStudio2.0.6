using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.DataModel;
using CocoStudio.Model.Editor;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using System;
using System.ComponentModel;
using System.Drawing;

namespace CocoStudio.Model.ViewModel
{
	[ModelExtension(true, 11), Catagory("Control_BaseControl", 0, 0), DisplayName("Display_Component_Map")]
	public class GameMapObject : NodeObject, ISingleNode
	{
		private ResourceFile file = null;

		[ResourceFilter(new string[]
		{
			"tmx"
		}), PropertyOrder(81), UndoProperty, Browsable(true), Category("Group_Feature"), DefaultValue(null), Description("Description_File"), DisplayName("Display_File"), Editor(typeof(ResourceFileEditor), typeof(ResourceFileEditor))]
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
					this.file = new TmxFile(GameMapObjectData.DefaultFile);
				}
				this.GetInnerWidget().SetFileData(this.file.GetResourceData());
				string compositeTaskName = base.GetType().Name + "FileData";
				using (CompositeTask.Run(compositeTaskName))
				{
					this.RefreshBoundingBox(false);
					this.RaisePropertyChanged<CocoStudio.Model.PointF>(() => this.Size);
					this.RaisePropertyChanged<ResourceFile>(() => this.FileData);
				}
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

		private CSGameMap GetInnerWidget()
		{
			return (CSGameMap)this.innerNode;
		}

		public GameMapObject()
		{
		}

		public GameMapObject(CSGameMap customWidget) : base(customWidget)
		{
		}

		protected override void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSGameMap();
			}
		}

		protected override void InitData()
		{
			base.InitData();
			this.FileData = null;
			this.Name = "Map_" + this.ObjectIndex;
			this.IsAddToCurrent = false;
			this.OperationFlag &= ~OperationMask.AnchorMoveFlag;
		}

		protected override void SetValue(object cObject, object cInnerObject)
		{
			base.SetValue(cObject, cInnerObject);
			GameMapObject gameMapObject = cObject as GameMapObject;
			if (gameMapObject != null)
			{
				gameMapObject.FileData = this.FileData;
			}
		}
	}
}
