// Decompiled with JetBrains decompiler
// Type: Nuclex.Game.Packing.RectanglePacker
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

using System.Drawing;

namespace Nuclex.Game.Packing
{
  public abstract class RectanglePacker
  {
    private int packingAreaWidth;
    private int packingAreaHeight;

    protected int PackingAreaWidth
    {
      get
      {
        return this.packingAreaWidth;
      }
    }

    protected int PackingAreaHeight
    {
      get
      {
        return this.packingAreaHeight;
      }
    }

    protected RectanglePacker(int packingAreaWidth, int packingAreaHeight)
    {
      this.packingAreaWidth = packingAreaWidth;
      this.packingAreaHeight = packingAreaHeight;
    }

    public virtual Point Pack(int rectangleWidth, int rectangleHeight)
    {
      Point placement;
      if (!this.TryPack(rectangleWidth, rectangleHeight, out placement))
        throw new OutOfSpaceException("Rectangle does not fit in packing area");
      return placement;
    }

    public abstract bool TryPack(int rectangleWidth, int rectangleHeight, out Point placement);
  }
}
