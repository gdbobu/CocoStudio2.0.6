// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.GameProjectLoadResult
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using System;
using System.Collections.Generic;

namespace CocoStudio.Model.DataModel
{
  public class GameProjectLoadResult
  {
    public NodeObject RootObject { get; set; }

    public TimelineAction TimelineAction { get; set; }

    public Dictionary<Type, int> TypeIndex { get; set; }

    public GameProjectLoadResult()
    {
      this.TypeIndex = new Dictionary<Type, int>();
    }
  }
}
