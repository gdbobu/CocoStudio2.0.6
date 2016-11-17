// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.UIControlSizeEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.ToolKit;
using Gtk;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
  public class UIControlSizeEditor : BaseEditor, ITypeEditor
  {
    private UIControlSizeEditorWidget widget = (UIControlSizeEditorWidget) null;
    private IScale9 scale9 = (IScale9) null;
    private ISizeType sizeTypeObject = (ISizeType) null;

    public UIControlSizeEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public UIControlSizeEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.widget = new UIControlSizeEditorWidget();
      this.scale9 = this._propertyItem.Instance as IScale9;
      this.sizeTypeObject = this._propertyItem.Instance as ISizeType;
      this.SetControl();
      this.widget.SQuardValueChanged += new EventHandler<UIControlEvent>(this.widget_SQuardValueChanged);
      return (Widget) this.widget;
    }

    private void SetControl()
    {
      NodeObject data = this._propertyItem.Instance as NodeObject;
      bool isPrecent = data.PreSizeEnable;
      if (this._propertyItem.IsEnable)
      {
        this.widget.SetMenuEnable(!this._propertyItem.IsEnable);
        isPrecent = false;
      }
      this.widget.SetValue((System.Action) (() =>
      {
        if (this.sizeTypeObject != null)
          this.widget.SetSizeTypeMode(this.sizeTypeObject.IsCustomSize, isPrecent, (double) data.Size.X, (double) data.Size.Y, (double) data.PreSize.X * 100.0, (double) data.PreSize.Y * 100.0);
        else if (this.scale9 != null)
        {
          this.widget.SetScale9Mode(data is PanelObject, isPrecent, (double) data.Size.X, (double) data.Size.Y, (double) data.PreSize.X * 100.0, (double) data.PreSize.Y * 100.0);
          this.widget.SetSquard(this.scale9.Scale9Enable, (double) this.scale9.TopEage, (double) this.scale9.BottomEage, (double) this.scale9.LeftEage, (double) this.scale9.RightEage);
        }
        else
          this.widget.SetShowOnlyMode(data is TextFieldObject, isPrecent, (double) data.Size.X, (double) data.Size.Y, (double) data.PreSize.X * 100.0, (double) data.PreSize.Y * 100.0);
      }));
    }

    private void widget_SQuardValueChanged(object sender, UIControlEvent e)
    {
      this.UpDateData((System.Action) (() =>
      {
        NodeObject instance = this._propertyItem.Instance as NodeObject;
        switch (e.Name)
        {
          case "comboBox_modeType_Changed":
            if (this.sizeTypeObject == null)
              break;
            this.sizeTypeObject.IsCustomSize = !e.IsCheck;
            this.SetControl();
            break;
          case "preSizeEnabled_Clicked":
            instance.PreSizeEnable = e.IsCheck;
            this.SetControl();
            break;
          case "rectSize_PointX":
            if (instance.PreSizeEnable)
            {
              PointF preSize = instance.PreSize;
              preSize.X = (float) e.UIValue / 100f;
              instance.PreSize = preSize;
              break;
            }
            instance.Size = new PointF((float) (int) e.UIValue, instance.Size.Y);
            break;
          case "rectSize_PointY":
            if (instance.PreSizeEnable)
            {
              PointF preSize = instance.PreSize;
              preSize.Y = (float) e.UIValue / 100f;
              instance.PreSize = preSize;
              break;
            }
            instance.Size = new PointF(instance.Size.X, (float) (int) e.UIValue);
            break;
          case "scale9Enabled_Clicked":
            if (this.scale9 == null)
              break;
            this.scale9.Scale9Enable = e.IsCheck;
            this.SetControl();
            break;
          case "Left":
            if (this.scale9 == null)
              break;
            this.scale9.LeftEage = (int) e.UIValue;
            break;
          case "Right":
            if (this.scale9 == null)
              break;
            this.scale9.RightEage = (int) e.UIValue;
            break;
          case "Bottom":
            if (this.scale9 == null)
              break;
            this.scale9.BottomEage = (int) e.UIValue;
            break;
          case "Top":
            if (this.scale9 == null)
              break;
            this.scale9.TopEage = (int) e.UIValue;
            break;
        }
      }));
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case "PreSizeEnable":
        case "PreSize":
        case "Size":
        case "Scale9Enable":
        case "LeftEage":
        case "RightEage":
        case "BottomEage":
        case "TopEage":
        case "IsCustomSize":
          this.SetControl();
          break;
        case "IsTransformEnabled":
          ITransform instance = this._propertyItem.Instance as ITransform;
          if (instance != null)
            this.widget.SetMenuEnable(instance.IsTransformEnabled);
          this._propertyItem.IsEnable = !instance.IsTransformEnabled;
          this.SetControl();
          break;
      }
    }

    public void EditorDispose()
    {
      this.Dispose();
    }

    public void RefreshData()
    {
      this.SetControl();
    }
  }
}
