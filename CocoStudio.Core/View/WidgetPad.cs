// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.View.WidgetPad
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using Gtk;

namespace CocoStudio.Core.View
{
  public static class WidgetPad
  {
    public static Widget CurrentWidget(this Pad pad)
    {
      if (pad == null || pad.Window == null || pad.Window.Content == null)
        return (Widget) null;
      return pad.Window.Content.Control;
    }
  }
}
