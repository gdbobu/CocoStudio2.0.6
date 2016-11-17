// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.SpriteObject
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
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  [ModelExtension(true, 2)]
  [Catagory("Control_BaseControl", 0, 0)]
  [DisplayName("Display_Component_Sprite")]
  public class SpriteObject : NodeObject
  {
    private ResourceFile file = (ResourceFile) null;

    [Browsable(true)]
    [DisplayName("Display_ImageResource")]
    [Category("Group_Feature")]
    [PropertyOrder(59)]
    [UndoProperty]
    [ResourceFilter(new string[] {"png", "jpg"})]
    [System.ComponentModel.Editor(typeof (ResourceImageEditor), typeof (ResourceImageEditor))]
    [DefaultValue(null)]
    [Description("Description_File")]
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
          this.file = (ResourceFile) new ImageFile((ResourceData) SpriteObjectData.DefaultFile);
        this.GetInnerWidget().SetFileData(this.file.GetResourceData());
        using (CompositeTask.Run(this.GetType().Name + "FileData"))
        {
          this.RefreshBoundingBox(false);
          this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Size));
          this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.FileData));
        }
      }
    }

    [Category("Group_Routine")]
    [Browsable(true)]
    [DefaultValue(false)]
    [PropertyOrder(14)]
    [UndoProperty]
    [System.ComponentModel.Editor(typeof (FilpEditor), typeof (FilpEditor))]
    [DisplayName("Display_Flip")]
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
        if (this.GetInnerWidget().GetFlipY() == value)
          return;
        this.GetInnerWidget().SetFlipY(value);
        this.RaisePropertyChanged<FilpValue>((Expression<Func<FilpValue>>) (() => this.Filp));
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
        if (this.GetInnerWidget().GetFlipX() == value)
          return;
        this.GetInnerWidget().SetFlipX(value);
        this.RaisePropertyChanged<FilpValue>((Expression<Func<FilpValue>>) (() => this.Filp));
      }
    }

    public SpriteObject()
    {
    }

    public SpriteObject(CSSprite customWidget)
      : base((CSNode) customWidget)
    {
    }

    public SpriteObject(ResourceFile resourceFile)
      : this()
    {
      this.FileData = resourceFile;
      this.Name = this.FileData.FileName.FileNameWithoutExtension;
    }

    private CSSprite GetInnerWidget()
    {
      return (CSSprite) this.innerNode;
    }

    protected override void CreateCSObject()
    {
      if (this.innerNode != null)
        return;
      this.innerNode = (CSNode) new CSSprite();
    }

    protected override void InitData()
    {
      base.InitData();
      this.FileData = (ResourceFile) null;
      this.Filp = new FilpValue(false, false);
      this.IsAddToCurrent = false;
    }

    protected override void SetValue(object cObject, object cInnerObject)
    {
      base.SetValue(cObject, cInnerObject);
      SpriteObject spriteObject = cObject as SpriteObject;
      if (spriteObject == null)
        return;
      spriteObject.FileData = this.FileData;
      spriteObject.FlipX = this.FlipX;
      spriteObject.FlipY = this.FlipY;
    }
  }
}
