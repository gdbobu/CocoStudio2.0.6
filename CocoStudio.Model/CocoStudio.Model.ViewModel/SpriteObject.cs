using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.DataModel;
using CocoStudio.Model.Editor;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.ViewModel
{
	[ModelExtension(true, 2), Catagory("Control_BaseControl", 0, 0), DisplayName("Display_Component_Sprite")]
	public class SpriteObject : NodeObject
	{
		private ResourceFile file = null;

		[ResourceFilter(new string[]
		{
			"png",
			"jpg"
		}), PropertyOrder(59), UndoProperty, Browsable(true), Category("Group_Feature"), DefaultValue(null), Description("Description_File"), DisplayName("Display_ImageResource"), Editor(typeof(ResourceImageEditor), typeof(ResourceImageEditor))]
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
					this.file = new ImageFile(SpriteObjectData.DefaultFile);
				}
				this.GetInnerWidget().SetFileData(this.file.GetResourceData());
				string compositeTaskName = base.GetType().Name + "FileData";
				using (CompositeTask.Run(compositeTaskName))
				{
					this.RefreshBoundingBox(false);
					this.RaisePropertyChanged<PointF>(() => this.Size);
					this.RaisePropertyChanged<ResourceFile>(() => this.FileData);
				}
			}
		}

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

		private CSSprite GetInnerWidget()
		{
			return (CSSprite)this.innerNode;
		}

		public SpriteObject()
		{
		}

		public SpriteObject(CSSprite customWidget) : base(customWidget)
		{
		}

		public SpriteObject(ResourceFile resourceFile) : this()
		{
			this.FileData = resourceFile;
			this.Name = this.FileData.FileName.FileNameWithoutExtension;
		}

		protected override void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSSprite();
			}
		}

		protected override void InitData()
		{
			base.InitData();
			this.FileData = null;
			this.Filp = new FilpValue(false, false);
			this.IsAddToCurrent = false;
		}

		protected override void SetValue(object cObject, object cInnerObject)
		{
			base.SetValue(cObject, cInnerObject);
			SpriteObject spriteObject = cObject as SpriteObject;
			if (spriteObject != null)
			{
				spriteObject.FileData = this.FileData;
				spriteObject.FlipX = this.FlipX;
				spriteObject.FlipY = this.FlipY;
			}
		}
	}
}
