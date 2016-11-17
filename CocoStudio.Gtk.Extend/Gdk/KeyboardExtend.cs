// Decompiled with JetBrains decompiler
// Type: Gdk.KeyboardExtend
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using GLib;
using Gtk;
using System.Collections.Generic;
using Xwt.GtkBackend;

namespace Gdk
{
  public static class KeyboardExtend
  {
    private static HashSet<Key> pressKeys = new HashSet<Key>();
    private static Gtk.Window mainWindow;

    internal static Gtk.Window MainWindow
    {
      get
      {
        return KeyboardExtend.mainWindow;
      }
      set
      {
        KeyboardExtend.SetMainWindow(KeyboardExtend.mainWindow, value);
        KeyboardExtend.mainWindow = value;
      }
    }

    public static bool IsKeyDown(Key key)
    {
      return KeyboardExtend.pressKeys.Contains(key);
    }

    public static bool IsModifyKeyDown(ModifierType modifierKey)
    {
      ModifierType currentKeyModifiers = GtkWorkarounds.GetCurrentKeyModifiers();
      return (modifierKey & currentKeyModifiers) == modifierKey;
    }

    private static void SetMainWindow(Gtk.Window oldWindow, Gtk.Window newWindow)
    {
      if (oldWindow != null)
      {
        oldWindow.KeyPressEvent -= new KeyPressEventHandler(KeyboardExtend.HandleKeyPressEvent);
        oldWindow.KeyReleaseEvent -= new KeyReleaseEventHandler(KeyboardExtend.HandleKeyReleaseEvent);
        oldWindow.FocusOutEvent -= new FocusOutEventHandler(KeyboardExtend.HandleFocusOutEvent);
      }
      if (newWindow == null)
        return;
      newWindow.KeyPressEvent += new KeyPressEventHandler(KeyboardExtend.HandleKeyPressEvent);
      newWindow.KeyReleaseEvent += new KeyReleaseEventHandler(KeyboardExtend.HandleKeyReleaseEvent);
      newWindow.FocusOutEvent += new FocusOutEventHandler(KeyboardExtend.HandleFocusOutEvent);
    }

    [ConnectBefore]
    private static void HandleFocusOutEvent(object o, FocusOutEventArgs args)
    {
      KeyboardExtend.pressKeys.Clear();
    }

    [ConnectBefore]
    private static void HandleKeyReleaseEvent(object o, KeyReleaseEventArgs args)
    {
      KeyboardExtend.pressKeys.Remove(args.Event.Key);
    }

    [ConnectBefore]
    private static void HandleKeyPressEvent(object o, KeyPressEventArgs args)
    {
      if (KeyboardExtend.pressKeys.Contains(args.Event.Key))
        return;
      KeyboardExtend.pressKeys.Add(args.Event.Key);
    }
  }
}
