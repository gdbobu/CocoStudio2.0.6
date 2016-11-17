// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.ParticleObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.DataModel;
using CocoStudio.Model.Editor;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  [Catagory("Control_BaseControl", 0, 0)]
  [DisplayName("Display_Component_Particle")]
  [ModelExtension(true, 10)]
  public class ParticleObject : NodeObject, IPlayControl, ISingleNode
  {
    private bool isPlaying = true;
    private ResourceFile file = (ResourceFile) null;

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
          this.GetInnerWidget().Start();
        else
          this.GetInnerWidget().Stop();
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.PlayState));
      }
    }

    [System.ComponentModel.Editor(typeof (ResourceFileEditor), typeof (ResourceFileEditor))]
    [PropertyOrder(80)]
    [ResourceFilter(new string[] {"plist"})]
    [UndoProperty]
    [DefaultValue(null)]
    [Description("Description_File")]
    [DisplayName("Display_File")]
    [Category("Group_Feature")]
    [Browsable(true)]
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
          this.file = (ResourceFile) new PlistParticleFile((ResourceData) ParticleObjectData.DefaultFile);
        this.GetInnerWidget().SetFileData(this.file.GetResourceData());
        using (CompositeTask.Run(this.GetType().Name + "FileData"))
        {
          this.RaisePropertyChanged<CocoStudio.Model.PointF>((Expression<Func<CocoStudio.Model.PointF>>) (() => this.Size));
          this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.FileData));
        }
      }
    }

    [DisplayName("Display_AudioPlay")]
    [Category("Group_Feature")]
    [Browsable(true)]
    [System.ComponentModel.Editor(typeof (PlayControlEditor), typeof (PlayControlEditor))]
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
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.Alpha));
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
        this.RaisePropertyChanged<Color>((Expression<Func<Color>>) (() => this.CColor));
      }
    }

    public ParticleObject()
    {
    }

    public ParticleObject(CSParticleSystem customWidget)
      : base((CSNode) customWidget)
    {
    }

    private CSParticleSystem GetInnerWidget()
    {
      return (CSParticleSystem) this.innerNode;
    }

    protected override void CreateCSObject()
    {
      if (this.innerNode != null)
        return;
      this.innerNode = (CSNode) new CSParticleSystem();
    }

    protected override void InitData()
    {
      base.InitData();
      this.FileData = (ResourceFile) null;
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
      if (particleObject == null)
        return;
      particleObject.FileData = this.FileData;
    }
  }
}
