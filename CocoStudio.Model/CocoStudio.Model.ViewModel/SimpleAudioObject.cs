using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.Editor;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using Gtk;
using System;
using System.ComponentModel;
using System.Drawing;

namespace CocoStudio.Model.ViewModel
{
	[ModelExtension(true, 12), Catagory("Control_BaseControl", 0, 0), DisplayName("Display_Component_Audio")]
	public class SimpleAudioObject : NodeObject, IPlayControl, ISingleNode
	{
		private ResourceFile file = null;

		[DefaultValue(1)]
		public virtual float Volume
		{
			get
			{
				return this.GetInnerWidget().GetVolume();
			}
			set
			{
				if (value >= 0f && value <= 1f)
				{
					this.GetInnerWidget().SetVolume(value);
					this.RaisePropertyChanged<float>(() => this.Volume);
				}
			}
		}

		[Browsable(false)]
		public override ScaleValue Scale
		{
			get
			{
				return base.Scale;
			}
			set
			{
				base.Scale = value;
			}
		}

		[Browsable(false)]
		public override float Rotation
		{
			get
			{
				return base.Rotation;
			}
			set
			{
				base.Rotation = value;
			}
		}

		[Browsable(false)]
		public override ScaleValue RotationSkew
		{
			get
			{
				return base.RotationSkew;
			}
			set
			{
				base.RotationSkew = value;
			}
		}

		[Browsable(false)]
		public override int Alpha
		{
			get
			{
				return base.Alpha;
			}
			set
			{
				base.Alpha = value;
			}
		}

		[Browsable(false)]
		public override Color CColor
		{
			get
			{
				return base.CColor;
			}
			set
			{
				base.CColor = value;
			}
		}

		[Browsable(false)]
		public override CocoStudio.Model.PointF Size
		{
			get
			{
				return base.Size;
			}
			set
			{
				base.Size = value;
			}
		}

		[Browsable(false)]
		public override bool VisibleForFrame
		{
			get
			{
				return base.VisibleForFrame;
			}
			set
			{
				base.VisibleForFrame = value;
			}
		}

		[Browsable(false)]
		public override ScaleValue AnchorPoint
		{
			get
			{
				return base.AnchorPoint;
			}
			set
			{
				base.AnchorPoint = value;
			}
		}

		[PropertyOrder(79), Browsable(true), Category("Group_Feature"), DefaultValue(false), DisplayName("Display_Loop")]
		public virtual bool Loop
		{
			get
			{
				return this.GetInnerWidget().GetIsLoop();
			}
			set
			{
				this.GetInnerWidget().SetIsLoop(value);
				this.Stop();
				this.RaisePropertyChanged<bool>(() => this.Loop);
			}
		}

		[ResourceFilter(new string[]
		{
			"wav",
			"mp3"
		}), PropertyOrder(78), UndoProperty, Browsable(true), Category("Group_Feature"), DefaultValue(null), Description("Description_File"), DisplayName("Display_File"), Editor(typeof(ResourceFileEditor), typeof(ResourceFileEditor))]
		public ResourceFile FileData
		{
			get
			{
				return this.file;
			}
			set
			{
				if (this.file != value)
				{
					this.file = value;
					if (this.file == null || !this.file.IsValid)
					{
						this.GetInnerWidget().SetFileData(new ResourceData(string.Empty));
					}
					else
					{
						this.GetInnerWidget().SetFileData(this.file.GetResourceData());
					}
					this.RaisePropertyChanged<ResourceFile>(() => this.FileData);
				}
			}
		}

		[Browsable(true), Category("Group_Feature"), DisplayName("Display_AudioPlay"), Editor(typeof(PlayControlEditor), typeof(PlayControlEditor))]
		public SimpleAudioObject Instance
		{
			get
			{
				return this;
			}
		}

		private CSSimpleAudio GetInnerWidget()
		{
			return (CSSimpleAudio)this.innerNode;
		}

		public SimpleAudioObject()
		{
		}

		public SimpleAudioObject(ResourceFile resourceFile) : this()
		{
			this.FileData = resourceFile;
		}

		public SimpleAudioObject(CSSimpleAudio customWidget) : base(customWidget)
		{
		}

		protected override void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSSimpleAudio();
			}
		}

		protected override void InitData()
		{
			base.InitData();
			this.IsAddToCurrent = false;
			this.Name = "Audio_" + this.ObjectIndex;
			this.OperationFlag = OperationMask.MoveFlag;
		}

		public void Start()
		{
			if (this.file != null)
			{
				this.GetInnerWidget().Stop();
				this.GetInnerWidget().Start();
			}
		}

		public void Stop()
		{
			this.GetInnerWidget().Stop();
		}

		public void PlayOnce()
		{
			this.GetInnerWidget().Stop();
			this.GetInnerWidget().Start();
		}

		internal override void AfterAdded()
		{
			base.AfterAdded();
		}

		internal override void BeforeRemoved()
		{
			base.BeforeRemoved();
			this.Stop();
		}

		public override bool CanDrop(object node, DropPosition mode, bool copy)
		{
			return mode != DropPosition.Add && base.CanDrop(node, mode, copy);
		}

		protected override void SetValue(object cObject, object cInnerObject)
		{
			base.SetValue(cObject, cInnerObject);
			SimpleAudioObject simpleAudioObject = cObject as SimpleAudioObject;
			if (simpleAudioObject != null)
			{
				simpleAudioObject.FileData = this.FileData;
				simpleAudioObject.Loop = this.Loop;
			}
		}

		public bool HasData()
		{
			return this.FileData != null;
		}
	}
}
