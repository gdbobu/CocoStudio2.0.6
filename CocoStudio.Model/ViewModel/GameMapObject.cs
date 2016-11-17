// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.GameMapObject
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
  [DisplayName("Display_Component_Map")]
  [ModelExtension(true, 11)]
  [Catagory("Control_BaseControl", 0, 0)]
  public class GameMapObject : NodeObject, ISingleNode
  {
    private ResourceFile file = (ResourceFile) null;

    [Description("Description_File")]
    [DisplayName("Display_File")]
    [PropertyOrder(81)]
    [Browsable(true)]
    [UndoProperty]
    [Category("Group_Feature")]
    [ResourceFilter(new string[] {"tmx"})]
    [System.ComponentModel.Editor(typeof (ResourceFileEditor), typeof (ResourceFileEditor))]
    [DefaultValue(null)]
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
          this.file = (ResourceFile) new TmxFile((ResourceData) GameMapObjectData.DefaultFile);
        this.GetInnerWidget().SetFileData(this.file.GetResourceData());
        using (CompositeTask.Run(this.GetType().Name + "FileData"))
        {
          this.RefreshBoundingBox(false);
          this.RaisePropertyChanged<CocoStudio.Model.PointF>((Expression<Func<CocoStudio.Model.PointF>>) (() => this.Size));
          this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.FileData));
        }
      }
    }

    [Browsable(false)]
    [UndoProperty]
    public override ScaleValue AnchorPoint
    {
      get
      {
        return this.GetCSVisual().GetAnchorPoint();
      }
      set
      {
        this.GetCSVisual().SetAnchorPoint(value);
        this.RaisePropertyChanged<ScaleValue>((Expression<Func<ScaleValue>>) (() => this.AnchorPoint));
      }
    }

    [Browsable(false)]
    [UndoProperty]
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
    [UndoProperty]
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

    public GameMapObject()
    {
    }

    public GameMapObject(CSGameMap customWidget)
      : base((CSNode) customWidget)
    {
    }

    private CSGameMap GetInnerWidget()
    {
      return (CSGameMap) this.innerNode;
    }

    protected override void CreateCSObject()
    {
      if (this.innerNode != null)
        return;
      this.innerNode = (CSNode) new CSGameMap();
    }

    protected override void InitData()
    {
      base.InitData();
      this.FileData = (ResourceFile) null;
      this.Name = "Map_" + (object) this.ObjectIndex;
      this.IsAddToCurrent = false;
      this.OperationFlag &= ~OperationMask.AnchorMoveFlag;
    }

    protected override void SetValue(object cObject, object cInnerObject)
    {
      base.SetValue(cObject, cInnerObject);
      GameMapObject gameMapObject = cObject as GameMapObject;
      if (gameMapObject == null)
        return;
      gameMapObject.FileData = this.FileData;
    }
  }
}
