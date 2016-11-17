// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.RenderFrameIndexChangedEventArgs
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using System;

namespace CocoStudio.Model.ViewModel
{
  public class RenderFrameIndexChangedEventArgs : EventArgs
  {
    public Frame Frame { get; private set; }

    public RenderFrameIndexChangedEventArgs()
    {
    }

    public RenderFrameIndexChangedEventArgs(Frame frame)
    {
      this.Frame = frame;
    }
  }
}
