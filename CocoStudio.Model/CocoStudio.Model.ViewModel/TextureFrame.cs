using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.Interface;
using CocoStudio.Projects;
using System;
using System.Collections.Specialized;

namespace CocoStudio.Model.ViewModel
{
	public class TextureFrame : Frame
	{
		private CSTimelineTextureFrame innerTextureFrame;

		private ResourceFile _textureFile = null;

		private CSTimelineTextureFrame.FrameEnterCallBack callback;

		public virtual ResourceFile TextureFile
		{
			get
			{
				return this._textureFile;
			}
			set
			{
				this._textureFile = value;
				if (this._textureFile == null)
				{
					this.innerTextureFrame.SetTexture(string.Empty);
					this.innerTextureFrame.SetPlist(string.Empty);
				}
				else
				{
					this.innerTextureFrame.SetTexture(value.GetResourceData().Path);
					this.innerTextureFrame.SetPlist(value.GetResourceData().Plist);
				}
				this.RaisePropertyChanged<ResourceFile>(() => this.TextureFile);
			}
		}

		public override ITimeline Timeline
		{
			get
			{
				return base.Timeline;
			}
			set
			{
				if (this.Timeline != value)
				{
					if (value == null)
					{
						TimelineActionManager.Instance.CurrentFrameIndexChangedEvent -= new CurrentFrameIndexChangedHandler(this.TimelineAction_CurrentFrameIndexChangedEvent);
					}
					else
					{
						TimelineActionManager.Instance.CurrentFrameIndexChangedEvent += new CurrentFrameIndexChangedHandler(this.TimelineAction_CurrentFrameIndexChangedEvent);
					}
				}
				base.Timeline = value;
			}
		}

		public override void UpdateProperty(NodeObject node)
		{
			SpriteObject spriteObject = node as SpriteObject;
			if (spriteObject != null)
			{
				this.TextureFile = spriteObject.FileData;
			}
		}

		public TextureFrame()
		{
			this.innerClass = (this.innerTextureFrame = new CSTimelineTextureFrame());
			this.BindingRecorder(null);
			this.callback = new CSTimelineTextureFrame.FrameEnterCallBack(this.OnEnter);
			this.innerTextureFrame.SetFrameEnterCallBack(this.callback);
		}

		private void TimelineAction_CurrentFrameIndexChangedEvent()
		{
			Timeline timeline = this.Timeline as Timeline;
			timeline.Node.RefreshBoundingBox(false);
		}

		public override void Copy(Frame frame)
		{
			base.Copy(frame);
			TextureFrame textureFrame = frame as TextureFrame;
			if (textureFrame != null)
			{
				this.TextureFile = textureFrame.TextureFile;
			}
		}

		protected void OnEnter()
		{
			SpriteObject spriteObject = ((Timeline)this.Timeline).Node as SpriteObject;
			if (spriteObject != null)
			{
				TimelineActionManager.Instance.CanAutoKey = false;
				spriteObject.IsRaiseStateChanged = false;
				spriteObject.FileData = this.TextureFile;
				spriteObject.IsRaiseStateChanged = true;
				TimelineActionManager.Instance.CanAutoKey = true;
			}
		}

		internal override void AncestorObjectChanged(BaseObject sourceObj, NotifyCollectionChangedAction action)
		{
			if (action == NotifyCollectionChangedAction.Add)
			{
				((IResourceObject)this).CollectResources();
			}
			else if (action == NotifyCollectionChangedAction.Remove)
			{
				((IResourceObject)this).ClearResources();
			}
		}
	}
}
