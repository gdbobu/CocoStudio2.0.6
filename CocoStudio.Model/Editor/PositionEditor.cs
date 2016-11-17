// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.PositionEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.ToolKit;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;
using System.Reflection;

namespace CocoStudio.Model.Editor
{
  public class PositionEditor : BaseEditor, ITypeEditor
  {
    private bool isCheck = false;
    private NumberEditorWidget widget;

    public PositionEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public PositionEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem propertyItem = null)
    {
      this.widget = new NumberEditorWidget(false, false, 30);
      this.widget.SetEntryPRoperty(false, 2, 1.0);
      this.widget.SetLabel(LanguageInfo.RotationX, LanguageInfo.RotationY);
      this.SetControl();
      this.widget.PointX += new EventHandler<PointEvent>(this.widget_PointX);
      this.widget.PointY += new EventHandler<PointEvent>(this.widget_PointY);
      this.widget.PerCentChanged += new EventHandler<UIControlEvent>(this.widget_PerCentChanged);
      if (this._propertyItem.IsEnable)
        this.widget.Sensitive = false;
      return (Widget) this.widget;
    }

    private void SetControl()
    {
      PointF pointF = (PointF) this._propertyItem.PropertyData.GetValue(this._propertyItem.Instance, (object[]) null);
      if (this._propertyItem.InstanceCount > 1)
      {
        Func<bool, bool, bool> func = (Func<bool, bool, bool>) ((a, b) => a == b);
        // ISSUE: reference to a compiler-generated field
        bool isPrecent = (this.IsWhip<bool>(PositionEditor.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate4, "PrePositionEnabled") || this.isMultiValue != null) && (bool) this.isMultiValue;
        Func<PointF, PointF, bool> Func1 = (Func<PointF, PointF, bool>) ((a, b) => (double) a.X == (double) b.X);
        Func<PointF, PointF, bool> Func2 = (Func<PointF, PointF, bool>) ((a, b) => (double) a.Y == (double) b.Y);
        if (this.IsWhip<PointF>(Func1, ""))
          this.widget.SetWhipX(isPrecent);
        else
          this.widget.SetX((double) pointF.X);
        if (this.IsWhip<PointF>(Func2, ""))
          this.widget.SetWhipY(isPrecent);
        else
          this.widget.SetY((double) pointF.Y);
      }
      else
        this.widget.SetValue((System.Action) (() =>
        {
          NodeObject instance = this._propertyItem.Instance as NodeObject;
          this.isCheck = instance.PrePositionEnabled;
          this.widget.X.SetValue((double) instance.Position.X, (double) instance.PrePosition.X * 100.0, instance.PrePositionEnabled);
          this.widget.Y.SetValue((double) instance.Position.Y, (double) instance.PrePosition.Y * 100.0, instance.PrePositionEnabled);
        }));
    }

    private void widget_PerCentChanged(object sender, UIControlEvent e)
    {
      this.UpDateData((System.Action) (() =>
      {
        this._propertyItem.SetValue("PrePositionEnabled", (object) e.IsCheck, (object[]) null);
        this.isCheck = e.IsCheck;
        this.SetControl();
      }));
    }

    private void widget_PointY(object sender, PointEvent e)
    {
      this.UpDateData((System.Action) (() =>
      {
        PropertyInfo property = this._propertyItem.Instance.GetType().GetProperty("PrePosition");
        for (int index = this._propertyItem.InstanceList.Count - 1; index >= 0; --index)
        {
          object instance = this._propertyItem.InstanceList[index];
          if (this.isCheck)
          {
            PointF pointF = (PointF) property.GetValue(instance, (object[]) null);
            property.SetValue(instance, (object) new PointF(pointF.X, (float) e.PointY * 0.01f), (object[]) null);
          }
          else
          {
            PointF pointF = (PointF) this._propertyItem.PropertyData.GetValue(instance, (object[]) null);
            this._propertyItem.PropertyData.SetValue(instance, (object) new PointF(pointF.X, (float) e.PointY), (object[]) null);
          }
        }
      }));
    }

    private void widget_PointX(object sender, PointEvent e)
    {
      this.UpDateData((System.Action) (() =>
      {
        PropertyInfo property = this._propertyItem.Instance.GetType().GetProperty("PrePosition");
        for (int index = this._propertyItem.InstanceList.Count - 1; index >= 0; --index)
        {
          object instance = this._propertyItem.InstanceList[index];
          if (this.isCheck)
          {
            PointF pointF = (PointF) property.GetValue(instance, (object[]) null);
            property.SetValue(instance, (object) new PointF((float) e.PointX * 0.01f, pointF.Y), (object[]) null);
          }
          else
          {
            PointF pointF = (PointF) this._propertyItem.PropertyData.GetValue(instance, (object[]) null);
            this._propertyItem.PropertyData.SetValue(instance, (object) new PointF((float) e.PointX, pointF.Y), (object[]) null);
          }
        }
      }));
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      this.SetChildWidget((Widget) this.widget, e.PropertyName);
      if (!(e.PropertyName == "RelativePosition") && !(e.PropertyName == "PrePosition") && !(e.PropertyName == "PrePositionEnabled") && !(e.PropertyName == "IsTransformEnabled"))
        return;
      this.SetControl();
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
