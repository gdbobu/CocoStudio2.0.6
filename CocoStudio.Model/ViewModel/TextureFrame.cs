// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.TextureFrame
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.Interface;
using CocoStudio.Projects;
using System;
using System.Collections.Specialized;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  public class TextureFrame : Frame
  {
    private ResourceFile _textureFile = (ResourceFile) null;
    private CSTimelineTextureFrame innerTextureFrame;
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
        this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.TextureFile));
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
            TimelineActionManager.Instance.CurrentFrameIndexChangedEvent -= new CurrentFrameIndexChangedHandler(this.TimelineAction_CurrentFrameIndexChangedEvent);
          else
            TimelineActionManager.Instance.CurrentFrameIndexChangedEvent += new CurrentFrameIndexChangedHandler(this.TimelineAction_CurrentFrameIndexChangedEvent);
        }
        base.Timeline = value;
      }
    }

    public TextureFrame()
    {
      this.innerClass = (CSTimelineFrame) (this.innerTextureFrame = new CSTimelineTextureFrame());
      this.BindingRecorder((string) null);
      this.callback = new CSTimelineTextureFrame.FrameEnterCallBack(this.OnEnter);
      this.innerTextureFrame.SetFrameEnterCallBack(this.callback);
    }

    public override void UpdateProperty(NodeObject node)
    {
      SpriteObject spriteObject = node as SpriteObject;
      if (spriteObject == null)
        return;
      this.TextureFile = spriteObject.FileData;
    }

    private void TimelineAction_CurrentFrameIndexChangedEvent()
    {
      (this.Timeline as CocoStudio.Model.ViewModel.Timeline).Node.RefreshBoundingBox(false);
    }

    public override void Copy(Frame frame)
    {
      base.Copy(frame);
      TextureFrame textureFrame = frame as TextureFrame;
      if (textureFrame == null)
        return;
      this.TextureFile = textureFrame.TextureFile;
    }

    protected void OnEnter()
    {
      SpriteObject node = ((CocoStudio.Model.ViewModel.Timeline) this.Timeline).Node as SpriteObject;
      if (node == null)
        return;
      TimelineActionManager.Instance.CanAutoKey = false;
      node.IsRaiseStateChanged = false;
      node.FileData = this.TextureFile;
      node.IsRaiseStateChanged = true;
      TimelineActionManager.Instance.CanAutoKey = true;
    }

    internal override void AncestorObjectChanged(BaseObject sourceObj, NotifyCollectionChangedAction action)
    {
      if (action == NotifyCollectionChangedAction.Add)
      {
        this.CollectResources();
      }
      else
      {
        if (action != NotifyCollectionChangedAction.Remove)
          return;
        this.ClearResources();
      }
    }
  }
}
