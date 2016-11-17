// Decompiled with JetBrains decompiler
// Type: Gtk.Cursors
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gdk;
using MonoDevelop.Core;

namespace Gtk
{
  public class Cursors
  {
    private static Cursor arrow;
    private static Cursor cross;
    private static Cursor link;
    private static Cursor hand;
    private static Cursor fist;
    private static Cursor input;
    private static Cursor arrowMove;
    private static Cursor arrowForbid;
    private static Cursor stretchVertical;
    private static Cursor stretchHorizon;
    private static Cursor arrowMoveAnchor;
    private static Cursor stretchRightDown;
    private static Cursor stretchLeftDown;
    private static Cursor chamferHorizon;
    private static Cursor chamferVertical;
    private static Cursor rotateUp;
    private static Cursor rotateDown;
    private static Cursor rotateLeft;
    private static Cursor rotateRight;
    private static Cursor rotateRightUp;
    private static Cursor rotateRightDown;
    private static Cursor rotateLeftUp;
    private static Cursor rotateLeftDown;

    public static Cursor Arrow
    {
      get
      {
        return Cursors.arrow;
      }
    }

    public static Cursor Cross
    {
      get
      {
        return Cursors.cross;
      }
    }

    public static Cursor Link
    {
      get
      {
        return Cursors.link;
      }
    }

    public static Cursor Hand
    {
      get
      {
        return Cursors.hand;
      }
    }

    public static Cursor Fist
    {
      get
      {
        return Cursors.fist;
      }
    }

    public static Cursor Input
    {
      get
      {
        return Cursors.input;
      }
    }

    public static Cursor ArrowMove
    {
      get
      {
        return Cursors.arrowMove;
      }
    }

    public static Cursor ArrowForbid
    {
      get
      {
        return Cursors.arrowForbid;
      }
    }

    public static Cursor StretchVertical
    {
      get
      {
        return Cursors.stretchVertical;
      }
    }

    public static Cursor StretchHorizon
    {
      get
      {
        return Cursors.stretchHorizon;
      }
    }

    public static Cursor ArrowMoveAnchor
    {
      get
      {
        return Cursors.arrowMoveAnchor;
      }
    }

    public static Cursor StretchRightDown
    {
      get
      {
        return Cursors.stretchRightDown;
      }
    }

    public static Cursor StretchLeftDown
    {
      get
      {
        return Cursors.stretchLeftDown;
      }
    }

    public static Cursor ChamferHorizon
    {
      get
      {
        return Cursors.chamferHorizon;
      }
    }

    public static Cursor ChamferVertical
    {
      get
      {
        return Cursors.chamferVertical;
      }
    }

    public static Cursor RotateUp
    {
      get
      {
        return Cursors.rotateUp;
      }
    }

    public static Cursor RotateDown
    {
      get
      {
        return Cursors.rotateDown;
      }
    }

    public static Cursor RotateLeft
    {
      get
      {
        return Cursors.rotateLeft;
      }
    }

    public static Cursor RotateRight
    {
      get
      {
        return Cursors.rotateRight;
      }
    }

    public static Cursor RotateRightUp
    {
      get
      {
        return Cursors.rotateRightUp;
      }
    }

    public static Cursor RotateRightDown
    {
      get
      {
        return Cursors.rotateRightDown;
      }
    }

    public static Cursor RotateLeftUp
    {
      get
      {
        return Cursors.rotateLeftUp;
      }
    }

    public static Cursor RotateLeftDown
    {
      get
      {
        return Cursors.rotateLeftDown;
      }
    }

    static Cursors()
    {
      Display display = Display.Default;
      if (Platform.IsWindows)
        Cursors.arrow = new Cursor(CursorType.Arrow);
      else if (Platform.IsMac)
        Cursors.arrow = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.Arrow.png"), 4, 1);
      Cursors.arrowForbid = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.ArrowForbid.png"), 2, 1);
      Cursors.arrowMove = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.ArrowMove.png"), 2, 1);
      Cursors.arrowMoveAnchor = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.ArrowMoveAnchor.png"), 2, 1);
      Cursors.chamferHorizon = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.ChamferHorizon.png"), 7, 7);
      Cursors.chamferVertical = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.ChamferVertical.png"), 7, 7);
      Cursors.cross = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.Cross.png"), 7, 7);
      Cursors.fist = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.Fist.png"), 7, 7);
      Cursors.hand = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.Hand.png"), 7, 7);
      Cursors.input = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.Input.png"), 7, 7);
      Cursors.link = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.Link.png"), 6, 2);
      Cursors.rotateDown = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.RotateDown.png"), 7, 7);
      Cursors.rotateLeft = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.RotateLeft.png"), 7, 7);
      Cursors.rotateLeftDown = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.RotateLeftDown.png"), 7, 7);
      Cursors.rotateLeftUp = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.RotateLeftUp.png"), 7, 7);
      Cursors.rotateRight = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.RotateRight.png"), 7, 7);
      Cursors.rotateRightDown = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.RotateRightDown.png"), 7, 7);
      Cursors.rotateRightUp = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.RotateRightUp.png"), 7, 7);
      Cursors.rotateUp = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.RotateUp.png"), 7, 7);
      Cursors.stretchHorizon = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.StretchHorizon.png"), 7, 7);
      Cursors.stretchLeftDown = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.StretchLeftDown.png"), 7, 7);
      Cursors.stretchRightDown = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.StretchRightDown.png"), 7, 7);
      Cursors.stretchVertical = new Cursor(display, ImageIcon.GetPixbuf("CocoStudio.DefaultResource.CursorImage.StretchVertical.png"), 7, 7);
    }
  }
}
