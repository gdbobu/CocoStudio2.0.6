// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.FixZoom
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using Cairo;
using Gdk;
using Gtk;

namespace CocoStudio.Model.Editor
{
  public class FixZoom : DrawingArea
  {
    private bool status = true;
    private double currentWidth = 30.0;
    private double currentHeight = 20.0;
    private const int begin = 5;
    private const int topBottom = 35;
    private const int leftRight = 80;
    private const int anthor = 6;
    private const int rectWidth = 92;
    private const int rectHeight = 52;

    public bool IsTop { get; set; }

    public bool IsBottom { get; set; }

    public bool IsLeft { get; set; }

    public bool IsRight { get; set; }

    public bool IsCenter { get; set; }

    protected override bool OnExposeEvent(EventExpose evnt)
    {
      using (Context context = CairoHelper.Create((Drawable) this.GdkWindow))
      {
        System.Drawing.Color color1 = System.Drawing.Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        context.SetSourceRGBA((double) color1.R / (double) byte.MaxValue, (double) color1.G / (double) byte.MaxValue, (double) color1.B / (double) byte.MaxValue, 1.0);
        context.Rectangle(0.0, 0.0, 92.0, 52.0);
        context.Fill();
        context.Stroke();
        context.SetSourceRGBA(0.0, 0.0, 0.0, 1.0);
        context.SetFontSize(15.0);
        context.Antialias = Antialias.None;
        context.LineWidth = 1.0;
        context.MoveTo(5.0, 5.0);
        context.LineTo(5.0, this.currentHeight);
        context.MoveTo(5.0, 5.0);
        context.LineTo(this.currentWidth, 5.0);
        context.MoveTo(this.currentWidth, 5.0);
        context.LineTo(this.currentWidth, this.currentHeight);
        context.MoveTo(5.0, this.currentHeight);
        context.LineTo(this.currentWidth, this.currentHeight);
        context.Stroke();
        System.Drawing.Color color2 = System.Drawing.Color.FromArgb((int) byte.MaxValue, 100, 100, 100);
        context.SetSourceRGBA((double) color2.R / (double) byte.MaxValue, (double) color2.G / (double) byte.MaxValue, (double) color2.B / (double) byte.MaxValue, 1.0);
        context.Rectangle(this.currentWidth / 2.0, this.currentHeight / 2.0, 6.0, 6.0);
        context.Fill();
        context.Stroke();
        context.Restore();
        if (this.status)
        {
          this.currentWidth += 4.0;
          this.currentHeight += 2.0;
        }
        else
        {
          this.currentWidth -= 4.0;
          this.currentHeight -= 2.0;
        }
        if (this.currentHeight >= (double) (evnt.Area.Height - 5))
          this.status = false;
        if (this.currentHeight < 30.0)
          this.status = true;
        this.GrabFocus();
        context.Dispose();
      }
      return base.OnExposeEvent(evnt);
    }
  }
}
