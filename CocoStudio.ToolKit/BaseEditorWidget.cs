// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.BaseEditorWidget
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;

namespace CocoStudio.ToolKit
{
  public abstract class BaseEditorWidget : EventBox, IEditorWidget, IWidgetValueChanged
  {
    private bool isOutsideSetValue;

    public event System.Action BeforeValueChanged;

    public event System.Action AfterValueChanged;

    public event System.Action SetControlValue;

    protected void RaiseValueChanged(object value, System.Action action = null)
    {
      if (this.isOutsideSetValue)
        return;
      if (this.BeforeValueChanged != null)
        this.BeforeValueChanged();
      if (action != null)
        action();
      this.RaiseSelfEvent(value, 0);
      if (this.AfterValueChanged == null)
        return;
      this.AfterValueChanged();
    }

    protected virtual void RaiseSelfEvent(object value, int type = 0)
    {
    }

    public void SetValue(System.Action action = null)
    {
      this.isOutsideSetValue = true;
      if (action != null)
        action();
      this.isOutsideSetValue = false;
    }

    protected virtual void OnSetValue(object value)
    {
    }

    public abstract void ReadLanuageConfigFile();
  }
}
