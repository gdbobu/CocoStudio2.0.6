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
	[ModelExtension(true, 10), Catagory("Control_BaseControl", 0, 0), DisplayName("Display_Component_Particle")]
	public class ParticleObject : NodeObject, IPlayControl, ISingleNode
	{
		private bool isPlaying = true;

		private ResourceFile file = null;

		public virtual bool PlayState
		{
			get
			{
				return this.isPlaying;
			}
			set
			{
				this.isPlaying = value;
				if (this.isPlaying)
				{
					this.GetInnerWidget().Start();
				}
				else
				{
					this.GetInnerWidget().Stop();
				}
				this.RaisePropertyChanged<bool>(() => this.PlayState);
			}
		}

		[ResourceFilter(new string[]
		{
			"plist"
		}), PropertyOrder(80), UndoProperty, Browsable(true), Category("Group_Feature"), DefaultValue(null), Description("Description_File"), DisplayName("Display_File"), Editor(typeof(ResourceFileEditor), typeof(ResourceFileEditor))]
		public ResourceFile FileData
		{
			get
			{
				return this.file;
			}
			set
			{
				this.file = value;
				if (this.file == null || !this.file.IsValid || !(this.file is PlistParticleFile))
				{
					this.file = new PlistParticleFile(ParticleObjectData.DefaultFile);
				}
				this.GetInnerWidget().SetFileData(this.file.GetResourceData());
				string compositeTaskName = base.GetType().Name + "FileData";
				using (CompositeTask.Run(compositeTaskName))
				{
					this.RaisePropertyChanged<CocoStudio.Model.PointF>(() => this.Size);
					this.RaisePropertyChanged<ResourceFile>(() => this.FileData);
				}
			}
		}

		[Browsable(true), Category("Group_Feature"), DisplayName("Display_AudioPlay"), Editor(typeof(PlayControlEditor), typeof(PlayControlEditor))]
		public ParticleObject Instance
		{
			get
			{
				return this;
			}
		}

		[Browsable(false)]
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

		[Browsable(false)]
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

		private CSParticleSystem GetInnerWidget()
		{
			return (CSParticleSystem)this.innerNode;
		}

		public ParticleObject()
		{
		}

		public ParticleObject(CSParticleSystem customWidget) : base(customWidget)
		{
		}

		protected override void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSParticleSystem();
			}
		}

		protected override void InitData()
		{
			base.InitData();
			this.FileData = null;
			this.IsAddToCurrent = false;
			this.OperationFlag &= ~OperationMask.AnchorMoveFlag;
		}

		public void Start()
		{
			this.PlayState = true;
		}

		public void Stop()
		{
			this.PlayState = false;
		}

		public bool HasData()
		{
			return this.FileData != null;
		}

		protected override void SetValue(object cObject, object cInnerObject)
		{
			base.SetValue(cObject, cInnerObject);
			ParticleObject particleObject = cObject as ParticleObject;
			if (particleObject != null)
			{
				particleObject.FileData = this.FileData;
			}
		}
	}
}
