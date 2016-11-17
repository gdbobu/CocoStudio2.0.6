// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Interface.IInputDispatch
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using Gtk;

namespace CocoStudio.Model.Interface
{
  public interface IInputDispatch
  {
    event InputDispatchHandler<MouseEventArgsExtend> BeforeMouseDown;

    event InputDispatchHandler<MouseEventArgsExtend> BeforeMouseUp;

    event InputDispatchHandler<MouseEventArgsExtend> BeforeMouseMove;

    event InputDispatchHandler<MouseEventArgsExtend> BeforeMouseDoubleClick;

    event InputDispatchHandler<KeyPressEventArgs> BeforeKeyDown;

    event InputDispatchHandler<KeyReleaseEventArgs> BeforeKeyUp;

    event InputDispatchHandler<MouseEventArgsExtend> AfterMouseDown;

    event InputDispatchHandler<MouseEventArgsExtend> AfterMouseUp;

    event InputDispatchHandler<MouseEventArgsExtend> AfterMouseMove;

    event InputDispatchHandler<MouseEventArgsExtend> AfterMouseDoubleClick;

    event InputDispatchHandler<KeyPressEventArgs> AfterKeyDown;

    event InputDispatchHandler<KeyReleaseEventArgs> AfterKeyUp;
  }
}
