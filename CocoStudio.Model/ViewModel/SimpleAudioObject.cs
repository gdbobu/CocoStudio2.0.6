// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.SimpleAudioObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.Editor;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using Gtk;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  [Catagory("Control_BaseControl", 0, 0)]
  [ModelExtension(true, 12)]
  [DisplayName("Display_Component_Audio")]
  public class SimpleAudioObject : NodeObject, IPlayControl, ISingleNode
  {
    private ResourceFile file = (ResourceFile) null;

    [DefaultValue(1)]
    public virtual float Volume
    {
      get
      {
        return this.GetInnerWidget().GetVolume();
      }
      set
      {
        if ((double) value < 0.0 || (double) value > 1.0)
          return;
        this.GetInnerWidget().SetVolume(value);
        this.RaisePropertyChanged<float>((Expression<Func<float>>) (() => this.Volume));
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

    [Category("Group_Feature")]
    [Browsable(true)]
    [PropertyOrder(79)]
    [DisplayName("Display_Loop")]
    [DefaultValue(false)]
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
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.Loop));
      }
    }

    [Browsable(true)]
    [DefaultValue(null)]
    [UndoProperty]
    [ResourceFilter(new string[] {"wav", "mp3"})]
    [System.ComponentModel.Editor(typeof (ResourceFileEditor), typeof (ResourceFileEditor))]
    [DisplayName("Display_File")]
    [Description("Description_File")]
    [Category("Group_Feature")]
    [PropertyOrder(78)]
    public ResourceFile FileData
    {
      get
      {
        return this.file;
      }
      set
      {
        if (this.file == value)
          return;
        this.file = value;
        if (this.file == null || !this.file.IsValid)
          this.GetInnerWidget().SetFileData(new ResourceData(string.Empty));
        else
          this.GetInnerWidget().SetFileData(this.file.GetResourceData());
        this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.FileData));
      }
    }

    [Category("Group_Feature")]
    [Browsable(true)]
    [DisplayName("Display_AudioPlay")]
    [System.ComponentModel.Editor(typeof (PlayControlEditor), typeof (PlayControlEditor))]
    public SimpleAudioObject Instance
    {
      get
      {
        return this;
      }
    }

    public SimpleAudioObject()
    {
    }

    public SimpleAudioObject(ResourceFile resourceFile)
      : this()
    {
      this.FileData = resourceFile;
    }

    public SimpleAudioObject(CSSimpleAudio customWidget)
      : base((CSNode) customWidget)
    {
    }

    private CSSimpleAudio GetInnerWidget()
    {
      return (CSSimpleAudio) this.innerNode;
    }

    protected override void CreateCSObject()
    {
      if (this.innerNode != null)
        return;
      this.innerNode = (CSNode) new CSSimpleAudio();
    }

    protected override void InitData()
    {
      base.InitData();
      this.IsAddToCurrent = false;
      this.Name = "Audio_" + (object) this.ObjectIndex;
      this.OperationFlag = OperationMask.MoveFlag;
    }

    public void Start()
    {
      if (this.file == null)
        return;
      this.GetInnerWidget().Stop();
      this.GetInnerWidget().Start();
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
      if (mode != DropPosition.Add)
        return base.CanDrop(node, mode, copy);
      return false;
    }

    protected override void SetValue(object cObject, object cInnerObject)
    {
      base.SetValue(cObject, cInnerObject);
      SimpleAudioObject simpleAudioObject = cObject as SimpleAudioObject;
      if (simpleAudioObject == null)
        return;
      simpleAudioObject.FileData = this.FileData;
      simpleAudioObject.Loop = this.Loop;
    }

    public bool HasData()
    {
      return this.FileData != null;
    }
  }
}
