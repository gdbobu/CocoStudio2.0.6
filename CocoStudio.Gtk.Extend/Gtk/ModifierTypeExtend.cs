// Decompiled with JetBrains decompiler
// Type: Gtk.ModifierTypeExtend
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gdk;

namespace Gtk
{
  public static class ModifierTypeExtend
  {
    public static MouseButton GetMouseButton(this ModifierType modifierType)
    {
      MouseButton mouseButton = MouseButton.None;
      switch (modifierType)
      {
        case ModifierType.Button3Mask:
          mouseButton = MouseButton.Right;
          break;
        case ModifierType.Button1Mask:
          mouseButton = MouseButton.Left;
          break;
        case ModifierType.Button2Mask:
          mouseButton = MouseButton.Middle;
          break;
      }
      return mouseButton;
    }
  }
}
