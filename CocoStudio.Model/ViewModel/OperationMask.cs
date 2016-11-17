// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.OperationMask
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using System;

namespace CocoStudio.Model.ViewModel
{
  [Flags]
  public enum OperationMask
  {
    NoneFlag = 0,
    MoveFlag = 1,
    ScaleFlag = 2,
    RotationFlag = 4,
    AnchorMoveFlag = 8,
    AllFlag = 65535,
  }
}
