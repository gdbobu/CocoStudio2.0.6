// Decompiled with JetBrains decompiler
// Type: Modules.Communal.Packer.PackerSprite
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

using CocoStudio.Basic;
using Gdk;
using Gtk;
using System;
using System.Drawing;
using System.IO;

namespace Modules.Communal.Packer
{
  internal class PackerSprite
  {
    public float x = 0.0f;
    public float y = 0.0f;
    public float width = 0.0f;
    public float height = 0.0f;
    public float offsetX = 0.0f;
    public float offsetY = 0.0f;
    public float originalWidth = 0.0f;
    public float originalHeight = 0.0f;
    private float fScale = 1f;
    private Bitmap image;
    public string name;
    private string pathName;
    private float originX;
    private float originY;
    public bool dataOnly;

    public PackerSprite(Bitmap _map, string _name, bool bClip, bool bDataOnly, float scale)
    {
      this.image = _map;
      this.pathName = _name.Replace('\\', '/');
      if (Path.IsPathRooted(this.pathName))
        this.name = this.pathName.Replace(Option.EditorDefaultResourcePath, "").Trim('/');
      else
        this.name = this.pathName.Trim('/');
      this.dataOnly = bDataOnly;
      this.fScale = scale;
      this.CutEmpty(this.image, bClip);
    }

    private void CutEmpty(Bitmap _map, bool bclip)
    {
      int num1 = _map.Width - 1;
      int num2 = _map.Height - 1;
      int val1_1 = 0;
      int val1_2 = 0;
      if (bclip)
      {
        for (int index1 = 0; index1 < _map.Height; ++index1)
        {
          for (int index2 = 0; index2 < _map.Width; ++index2)
          {
            if ((int) _map.GetPixel(index2, index1).A != 0)
            {
              num1 = Math.Min(num1, index2);
              val1_1 = Math.Max(val1_1, index2);
              num2 = Math.Min(num2, index1);
              val1_2 = Math.Max(val1_2, index1);
            }
          }
        }
        int num3 = Math.Max(val1_1, num1);
        int num4 = Math.Max(val1_2, num2);
        this.originX = (float) num1;
        this.originY = (float) num2;
        this.width = (float) (num3 - num1 + 1);
        this.height = (float) (num4 - num2 + 1);
      }
      else
      {
        this.originX = 0.0f;
        this.originY = 0.0f;
        this.width = (float) _map.Width;
        this.height = (float) _map.Height;
      }
      this.width *= this.fScale;
      this.height *= this.fScale;
      this.originalWidth = (float) _map.Width * this.fScale;
      this.originalHeight = (float) _map.Height * this.fScale;
      this.offsetX = (float) ((double) this.originX + (double) this.width / 2.0 - (double) this.originalWidth / 2.0);
      this.offsetY = (float) ((double) this.originalHeight / 2.0 - ((double) this.originY + (double) this.height / 2.0));
      if (!this.dataOnly)
        return;
      this.image.Dispose();
      this.image = (Bitmap) null;
    }

    public void SetPosition(System.Drawing.Point targetPos)
    {
      this.x = (float) targetPos.X;
      this.y = (float) targetPos.Y;
    }

    public void DrawToImage(Graphics gDraw, string resourcePath)
    {
      this.GetImage(resourcePath);
      System.Drawing.Rectangle destRect = new System.Drawing.Rectangle((int) this.x, (int) this.y, (int) this.width, (int) this.height);
      System.Drawing.Rectangle srcRect = new System.Drawing.Rectangle((int) this.originX, (int) this.originY, (int) ((double) this.width / (double) this.fScale), (int) ((double) this.height / (double) this.fScale));
      gDraw.DrawImage((System.Drawing.Image) this.image, destRect, srcRect, GraphicsUnit.Pixel);
      this.image.Dispose();
      this.image = (Bitmap) null;
    }

    private Bitmap GetImage(string resourcePath)
    {
      if (this.image == null)
      {
        string str = this.pathName;
        if (!Path.IsPathRooted(this.pathName))
          str = Path.Combine(resourcePath, this.pathName);
        try
        {
          if (File.Exists(str))
          {
            string lower = Path.GetExtension(str).ToLower();
            Pixbuf pixbuf = PixbufHelper.Load(str);
            this.image = new Bitmap((Stream) new MemoryStream(pixbuf.SaveToBuffer(lower.Trim('.'))));
            pixbuf.Dispose();
          }
        }
        catch (Exception ex)
        {
          MessageBox.Show("Ex : " + ex.Message, (Gtk.Window) null, (string) null, MessageBoxImage.Info);
          return (Bitmap) null;
        }
      }
      return this.image;
    }
  }
}
