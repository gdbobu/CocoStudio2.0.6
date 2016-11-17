// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.PrimitiveObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.EngineAdapterWrap;
using System.ComponentModel;

namespace CocoStudio.Model.ViewModel
{
  [DisplayName("Display_Component_Primitive")]
  public class PrimitiveObject : NodeObject
  {
    protected override void CreateCSObject()
    {
      this.innerNode = (CSNode) new CSPrimitive();
    }

    private CSPrimitive GetCom()
    {
      return this.GetCSVisual() as CSPrimitive;
    }

    public void AddASBox(string boxName, float width, float height, float centerX, float centerY)
    {
      this.GetCom().AddASBox(boxName, width, height, centerX, centerY);
    }

    public void ResetBoxSize(string boxName, float width, float height, float centerX, float centerY)
    {
      this.GetCom().ResetBoxSize(boxName, width, height, centerX, centerY);
    }

    public void SetVisible(bool isVisible)
    {
      this.GetCom().SetVisible(isVisible);
    }

    public override object Clone()
    {
      PrimitiveObject primitiveObject = new PrimitiveObject();
      primitiveObject.Name = this.Name;
      return (object) primitiveObject;
    }
  }
}
