// Decompiled with JetBrains decompiler
// Type: Gtk.Controls.ColorEditorGtk
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

namespace Gtk.Controls
{
  public class ColorEditorGtk : CcsColorButton
  {
    public object Value
    {
      get
      {
        return (object) System.Drawing.Color.FromArgb((int) byte.MaxValue, (int) ((double) byte.MaxValue * (double) this.CurrentColor.Red / (double) ushort.MaxValue), (int) ((double) byte.MaxValue * (double) this.CurrentColor.Green / (double) ushort.MaxValue), (int) ((double) byte.MaxValue * (double) this.CurrentColor.Blue / (double) ushort.MaxValue));
      }
      set
      {
        System.Drawing.Color color = (System.Drawing.Color) value;
        this.CurrentColor = new Gdk.Color(color.R, color.G, color.B);
      }
    }
  }
}
