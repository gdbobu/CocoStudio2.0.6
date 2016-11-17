// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSVisualObjectEmpty
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.Model;
using Gdk;
using System;

namespace CocoStudio.EngineAdapterWrap
{
  public class CSVisualObjectEmpty : CSVisualObject
  {
    private PointF absolutePosition = (PointF) new Point(0, 0);
    private float absoluteRotation = 0.0f;
    private ScaleValue absoluteScale = ScaleValue.Empty;
    private float actualHeight = 0.0f;
    private float actualWidth = 0.0f;
    private int orderOfArrival = 0;
    private ScaleValue anchorPoint;
    private float height;
    private PointF position;
    private float rotation;
    private ScaleValue scale;
    private int tag;
    private bool visible;
    private float width;
    private int zOrder;

    public static CSVisualObjectEmpty Instance { get; private set; }

    static CSVisualObjectEmpty()
    {
      CSVisualObjectEmpty.Instance = new CSVisualObjectEmpty();
    }

    private CSVisualObjectEmpty()
    {
    }

    public override void AddChild(CSVisualObject child)
    {
      throw new NotImplementedException();
    }

    public override void RemoveChild(CSVisualObject child)
    {
      throw new NotImplementedException();
    }

    public override ScaleValue GetAnchorPoint()
    {
      return this.anchorPoint;
    }

    public override void SetAnchorPoint(ScaleValue anchorPoint)
    {
      this.anchorPoint = anchorPoint;
    }

    public override int GetOrderOfArrival()
    {
      return this.orderOfArrival;
    }

    public override PointF GetPosition()
    {
      return this.position;
    }

    public override void SetPosition(PointF position)
    {
      this.position = position;
    }

    public override float GetRotation()
    {
      return this.rotation;
    }

    public override void SetRotation(float rotation)
    {
      this.rotation = rotation;
    }

    public override ScaleValue GetScale()
    {
      return this.scale;
    }

    public override void SetScale(ScaleValue scale)
    {
      this.scale = scale;
    }

    public override int GetTag()
    {
      return this.tag;
    }

    public override void SetTag(int tag)
    {
      this.tag = tag;
    }

    public override bool GetVisible()
    {
      return this.visible;
    }

    public override void SetVisible(bool visible)
    {
      this.visible = visible;
    }

    public override int GetZOrder()
    {
      return this.zOrder;
    }

    public override void SetZOrder(int zOrder)
    {
      this.zOrder = zOrder;
    }

    public override int HitTest(PointF point)
    {
      throw new NotImplementedException();
    }

    public override bool RectTest(Rectangle rect)
    {
      throw new NotImplementedException();
    }

    public override PointF TransformToParent(PointF selfPoint)
    {
      throw new NotImplementedException();
    }

    public override PointF TransformToScene(PointF selfPoint)
    {
      throw new NotImplementedException();
    }

    public override PointF TransformToSelf(PointF scenePoint)
    {
      throw new NotImplementedException();
    }
  }
}
