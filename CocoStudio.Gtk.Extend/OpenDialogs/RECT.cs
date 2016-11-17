// Decompiled with JetBrains decompiler
// Type: OpenDialogs.RECT
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

namespace OpenDialogs
{
  public struct RECT
  {
    public uint left;
    public uint top;
    public uint right;
    public uint bottom;

    public POINT Location
    {
      get
      {
        return new POINT((int) this.left, (int) this.top);
      }
      set
      {
        this.right -= this.left - (uint) value.x;
        this.bottom -= this.bottom - (uint) value.y;
        this.left = (uint) value.x;
        this.top = (uint) value.y;
      }
    }

    public uint Width
    {
      get
      {
        return this.right - this.left;
      }
      set
      {
        this.right = this.left + value;
      }
    }

    public uint Height
    {
      get
      {
        return this.bottom - this.top;
      }
      set
      {
        this.bottom = this.top + value;
      }
    }

    public override string ToString()
    {
      return ((int) this.left).ToString() + ":" + (object) this.top + ":" + (object) this.right + ":" + (object) this.bottom;
    }
  }
}
