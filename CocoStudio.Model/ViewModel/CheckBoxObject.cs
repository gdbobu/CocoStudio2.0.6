// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.CheckBoxObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.DataModel;
using CocoStudio.Model.Editor;
using CocoStudio.Model.Interface;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  [DisplayName("Display_Component_UICheckBox")]
  [ModelExtension(true, 1)]
  [Catagory("Control_BaseControl", 0, 0)]
  public class CheckBoxObject : WidgetObject, IDisplayState, ICallBackEvent
  {
    private bool isNormal = true;
    private ResourceFile normalBackFile = (ResourceFile) null;
    private ResourceFile pressedBackFile = (ResourceFile) null;
    private ResourceFile disableBackFile = (ResourceFile) null;
    private ResourceFile nodeNormalFile = (ResourceFile) null;
    private ResourceFile nodeDisableFile = (ResourceFile) null;

    [System.ComponentModel.Editor(typeof (CheckBoxEditor), typeof (CheckBoxEditor))]
    [DisplayName("Display_State")]
    [DefaultValue(true)]
    [PropertyOrder(67)]
    [UndoProperty]
    [Category("Group_Feature")]
    public virtual bool DisplayState
    {
      get
      {
        return this.isNormal;
      }
      set
      {
        this.isNormal = value;
        this.GetInnerWidget().ChangeState(this.isNormal);
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.DisplayState));
      }
    }

    [DisplayName("Display_Select_UnSelect")]
    [UndoProperty]
    [Category("Group_Feature")]
    [PropertyOrder(68)]
    [DefaultValue(true)]
    public virtual bool CheckedState
    {
      get
      {
        return this.GetInnerWidget().GetChecked();
      }
      set
      {
        if (this.GetInnerWidget().GetChecked() == value)
          return;
        this.GetInnerWidget().SetChecked(value);
        this.GetInnerWidget().ChangeState(!this.isNormal);
        this.GetInnerWidget().ChangeState(this.isNormal);
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.CheckedState));
      }
    }

    [DisplayName("Display_ImageResources")]
    [System.ComponentModel.Editor(typeof (ResourceGroupEditor), typeof (ResourceGroupEditor))]
    [Category("Group_Feature")]
    [PropertyOrder(65)]
    public List<string> ResourceValue
    {
      get
      {
        return new List<string>()
        {
          "NormalBackFileData",
          "PressedBackFileData",
          "DisableBackFileData"
        };
      }
      set
      {
        throw new InvalidOperationException();
      }
    }

    [System.ComponentModel.Editor(typeof (ResourceGroupEditor), typeof (ResourceGroupEditor))]
    [PropertyOrder(66)]
    [DisplayName("Display_MarkResource")]
    [Category("Group_Feature")]
    public List<string> ResourceNodeValue
    {
      get
      {
        return new List<string>()
        {
          "NodeNormalFileData",
          "NodeDisableFileData"
        };
      }
      set
      {
        throw new InvalidOperationException();
      }
    }

    [ResourceFilter(new string[] {"png", "jpg"})]
    [DisplayName("ContexMenu_BackgroundNormal")]
    [UndoProperty]
    [DefaultValue(null)]
    [System.ComponentModel.Editor(typeof (ResourceImageEditor), typeof (ResourceImageEditor))]
    public ResourceFile NormalBackFileData
    {
      get
      {
        return this.normalBackFile;
      }
      set
      {
        this.normalBackFile = value;
        if (this.normalBackFile == null || !this.normalBackFile.IsValid)
          this.normalBackFile = (ResourceFile) new ImageFile((ResourceData) CheckBoxObjectData.Default_Normal);
        this.GetInnerWidget().SetNormalGroudFile(this.normalBackFile.GetResourceData());
        using (CompositeTask.Run(this.GetType().Name + "NormalBackFileData"))
        {
          this.RefreshBoundingBox(false);
          this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Size));
          this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.NormalBackFileData));
        }
      }
    }

    [DisplayName("ContexMenu_BackgroundPressed")]
    [DefaultValue(null)]
    [UndoProperty]
    [ResourceFilter(new string[] {"png", "jpg"})]
    [System.ComponentModel.Editor(typeof (ResourceImageEditor), typeof (ResourceImageEditor))]
    public ResourceFile PressedBackFileData
    {
      get
      {
        return this.pressedBackFile;
      }
      set
      {
        this.pressedBackFile = value;
        if (this.pressedBackFile == null || !this.pressedBackFile.IsValid)
          this.pressedBackFile = (ResourceFile) new ImageFile((ResourceData) CheckBoxObjectData.Default_Press);
        this.GetInnerWidget().SetPressedGroudFile(this.pressedBackFile.GetResourceData());
        this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.PressedBackFileData));
      }
    }

    [System.ComponentModel.Editor(typeof (ResourceImageEditor), typeof (ResourceImageEditor))]
    [DefaultValue(null)]
    [ResourceFilter(new string[] {"png", "jpg"})]
    [DisplayName("ContexMenu_BackgroundDisabled")]
    [UndoProperty]
    public ResourceFile DisableBackFileData
    {
      get
      {
        return this.disableBackFile;
      }
      set
      {
        this.disableBackFile = value;
        if (this.disableBackFile == null || !this.disableBackFile.IsValid)
          this.disableBackFile = (ResourceFile) new ImageFile((ResourceData) CheckBoxObjectData.Default_Disable);
        this.GetInnerWidget().SetDisabledGroudFile(this.disableBackFile.GetResourceData());
        this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.DisableBackFileData));
      }
    }

    [DefaultValue(null)]
    [UndoProperty]
    [ResourceFilter(new string[] {"png", "jpg"})]
    [System.ComponentModel.Editor(typeof (ResourceImageEditor), typeof (ResourceImageEditor))]
    [DisplayName("ContexMenu_CheckNormal")]
    public ResourceFile NodeNormalFileData
    {
      get
      {
        return this.nodeNormalFile;
      }
      set
      {
        this.nodeNormalFile = value;
        if (this.nodeNormalFile == null || !this.nodeNormalFile.IsValid)
          this.nodeNormalFile = (ResourceFile) new ImageFile((ResourceData) CheckBoxObjectData.Default_NodeNormal);
        this.GetInnerWidget().SetNormalNodeFile(this.nodeNormalFile.GetResourceData());
        this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.NodeNormalFileData));
      }
    }

    [DefaultValue(null)]
    [UndoProperty]
    [DisplayName("ContexMenu_CheckDisabled")]
    [System.ComponentModel.Editor(typeof (ResourceImageEditor), typeof (ResourceImageEditor))]
    [ResourceFilter(new string[] {"png", "jpg"})]
    public ResourceFile NodeDisableFileData
    {
      get
      {
        return this.nodeDisableFile;
      }
      set
      {
        this.nodeDisableFile = value;
        if (this.nodeDisableFile == null || !this.nodeNormalFile.IsValid)
          this.nodeDisableFile = (ResourceFile) new ImageFile((ResourceData) CheckBoxObjectData.Default_NodeDisable);
        this.GetInnerWidget().SetDisabledNodeFile(this.nodeDisableFile.GetResourceData());
        this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.NodeDisableFileData));
      }
    }

    public CheckBoxObject()
    {
    }

    public CheckBoxObject(CSCheckBox customWidget)
      : base((CSWidget) customWidget)
    {
    }

    private CSCheckBox GetInnerWidget()
    {
      return (CSCheckBox) this.innerNode;
    }

    protected override void CreateCSObject()
    {
      if (this.innerNode != null)
        return;
      this.innerNode = (CSNode) new CSCheckBox();
    }

    protected override void InitData()
    {
      base.InitData();
      this.PressedBackFileData = (ResourceFile) null;
      this.DisableBackFileData = (ResourceFile) null;
      this.NodeDisableFileData = (ResourceFile) null;
      this.NormalBackFileData = (ResourceFile) null;
      this.NodeNormalFileData = (ResourceFile) null;
      this.CheckedState = true;
      this.TouchEnable = true;
    }

    protected override void SetValue(object cObject, object cInnerObject)
    {
      base.SetValue(cObject, cInnerObject);
      CheckBoxObject checkBoxObject = cObject as CheckBoxObject;
      if (checkBoxObject == null)
        return;
      checkBoxObject.NormalBackFileData = this.NormalBackFileData;
      checkBoxObject.PressedBackFileData = this.PressedBackFileData;
      checkBoxObject.DisableBackFileData = this.DisableBackFileData;
      checkBoxObject.NodeNormalFileData = this.NodeNormalFileData;
      checkBoxObject.NodeDisableFileData = this.NodeDisableFileData;
      checkBoxObject.CheckedState = this.CheckedState;
      checkBoxObject.DisplayState = this.DisplayState;
    }
  }
}
