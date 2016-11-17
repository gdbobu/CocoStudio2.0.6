// Decompiled with JetBrains decompiler
// Type: OpenDialogs.WINDOWPOS
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using System;

namespace OpenDialogs
{
  public struct WINDOWPOS
  {
    public IntPtr hwnd;
    public IntPtr hwndAfter;
    public int x;
    public int y;
    public int cx;
    public int cy;
    public uint flags;

    public override string ToString()
    {
      return this.x.ToString() + ":" + (object) this.y + ":" + (object) this.cx + ":" + (object) this.cy + ":" + ((SWP_Flags) this.flags).ToString();
    }
  }
}
