// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.BlendType
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

namespace CocoStudio.Model.ViewModel
{
  public enum BlendType
  {
    [EnumType("正常")] BLEND_NORMAL = 0,
    [EnumType("正片垫底")] BLEND_MULTIPLY = 3,
    [EnumType("滤色")] BLEND_SCREEN = 5,
    [EnumType("增加")] BLEND_ADD = 8,
  }
}
