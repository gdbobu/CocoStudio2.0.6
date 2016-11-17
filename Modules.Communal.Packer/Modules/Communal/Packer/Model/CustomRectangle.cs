// Decompiled with JetBrains decompiler
// Type: Modules.Communal.Packer.Model.CustomRectangle
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

using Gdk;

namespace Modules.Communal.Packer.Model
{
  public class CustomRectangle
  {
    private Rectangle inner;

    public object UserData { get; set; }

    public bool Rotated { get; set; }

    public int X
    {
      get
      {
        return this.inner.X;
      }
      set
      {
        this.inner.X = value;
      }
    }

    public int Y
    {
      get
      {
        return this.inner.Y;
      }
      set
      {
        this.inner.Y = value;
      }
    }

    public int Width
    {
      get
      {
        return this.inner.Width;
      }
      set
      {
        this.inner.Width = value;
      }
    }

    public int Height
    {
      get
      {
        return this.inner.Height;
      }
      set
      {
        this.inner.Height = value;
      }
    }

    public Size Size
    {
      get
      {
        return this.inner.Size;
      }
      set
      {
        this.inner.Size = value;
      }
    }

    public Point Location
    {
      get
      {
        return this.inner.Location;
      }
      set
      {
        this.inner.Location = value;
      }
    }

    public int Right
    {
      get
      {
        return this.inner.Right;
      }
    }

    public int Top
    {
      get
      {
        return this.inner.Top;
      }
    }

    public int Bottom
    {
      get
      {
        return this.inner.Bottom;
      }
    }

    public int Left
    {
      get
      {
        return this.inner.Left;
      }
    }

    public CustomRectangle(object userData = null)
    {
      this.UserData = userData;
      this.inner = new Rectangle();
    }

    public CustomRectangle(Point loc, Size sz, object userData = null)
    {
      this.UserData = userData;
      this.inner = new Rectangle(loc, sz);
    }

    public CustomRectangle(int x, int y, int width, int height, object userData = null)
    {
      this.UserData = userData;
      this.inner = new Rectangle(x, y, width, height);
    }

    public CustomRectangle(int x, int y, int width, int height, bool rotated, object userData = null)
    {
      this.Rotated = rotated;
      this.UserData = userData;
      this.inner = new Rectangle(x, y, width, height);
    }

    public bool Contains(CustomRectangle other)
    {
      return this.inner.Contains(other.inner);
    }

    public CustomRectangle Copy()
    {
      return new CustomRectangle(this.X, this.Y, this.Width, this.Height, this.Rotated, this.UserData);
    }
  }
}
