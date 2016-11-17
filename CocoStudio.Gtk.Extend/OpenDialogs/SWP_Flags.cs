// Decompiled with JetBrains decompiler
// Type: OpenDialogs.SWP_Flags
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using System;

namespace OpenDialogs
{
  [Flags]
  public enum SWP_Flags
  {
    SWP_NOSIZE = 1,
    SWP_NOMOVE = 2,
    SWP_NOZORDER = 4,
    SWP_NOACTIVATE = 16,
    SWP_FRAMECHANGED = 32,
    SWP_SHOWWINDOW = 64,
    SWP_HIDEWINDOW = 128,
    SWP_NOOWNERZORDER = 512,
    SWP_DRAWFRAME = SWP_FRAMECHANGED,
    SWP_NOREPOSITION = SWP_NOOWNERZORDER,
  }
}
