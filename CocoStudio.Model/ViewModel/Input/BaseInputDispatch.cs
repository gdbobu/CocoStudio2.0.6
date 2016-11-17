// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.Input.BaseInputDispatch
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.Interface;
using CocoStudio.UndoManager;
using Gtk;
using System.Collections.Generic;

namespace CocoStudio.Model.ViewModel.Input
{
  internal abstract class BaseInputDispatch
  {
    private IEnumerable<VisualObject> mouseDownObjectList = (IEnumerable<VisualObject>) null;
    protected bool isMouseDowned;
    protected bool isMouseUped;
    protected IUndoManager undoManager;

    public BaseInputDispatch(IUndoManager undoManger, IRenderUC renderUC)
    {
      this.undoManager = undoManger;
      this.Init(renderUC.InputDispatch);
    }

    private void Init(IInputDispatch inputDispatch)
    {
      inputDispatch.AfterKeyDown += new InputDispatchHandler<KeyPressEventArgs>(this.inputDispatch_AfterKeyDown);
      inputDispatch.AfterKeyUp += new InputDispatchHandler<KeyReleaseEventArgs>(this.inputDispatch_AfterKeyUp);
      inputDispatch.AfterMouseDown += new InputDispatchHandler<MouseEventArgsExtend>(this.inputDispatch_AfterMouseDown);
      inputDispatch.AfterMouseMove += new InputDispatchHandler<MouseEventArgsExtend>(this.inputDispatch_AfterMouseMove);
      inputDispatch.AfterMouseUp += new InputDispatchHandler<MouseEventArgsExtend>(this.inputDispatch_AfterMouseUp);
      inputDispatch.BeforeKeyDown += new InputDispatchHandler<KeyPressEventArgs>(this.inputDispatch_BeforeKeyDown);
      inputDispatch.BeforeKeyUp += new InputDispatchHandler<KeyReleaseEventArgs>(this.inputDispatch_BeforeKeyUp);
      inputDispatch.BeforeMouseDown += new InputDispatchHandler<MouseEventArgsExtend>(this.inputDispatch_BeforeMouseDown);
      inputDispatch.BeforeMouseMove += new InputDispatchHandler<MouseEventArgsExtend>(this.inputDispatch_BeforeMouseMove);
      inputDispatch.BeforeMouseUp += new InputDispatchHandler<MouseEventArgsExtend>(this.inputDispatch_BeforeMouseUp);
    }

    protected virtual void inputDispatch_BeforeMouseUp(MouseEventArgsExtend args, IEnumerable<VisualObject> selectedParentObject)
    {
    }

    protected virtual void inputDispatch_BeforeMouseMove(MouseEventArgsExtend args, IEnumerable<VisualObject> selectedParentObject)
    {
    }

    protected virtual void inputDispatch_BeforeMouseDown(MouseEventArgsExtend args, IEnumerable<VisualObject> selectedParentObject)
    {
      if (this.isMouseDowned)
      {
        this.isMouseDowned = false;
        foreach (BaseObject mouseDownObject in this.mouseDownObjectList)
          mouseDownObject.Recorder.Start(true, false);
        this.undoManager.EndCompositeTask();
      }
      else
      {
        this.isMouseUped = false;
        this.undoManager.BeginCompositeTask((string) null);
        foreach (BaseObject baseObject in selectedParentObject)
          baseObject.Recorder.Stop(false);
        this.isMouseDowned = true;
        this.mouseDownObjectList = selectedParentObject;
      }
    }

    protected virtual void inputDispatch_BeforeKeyUp(KeyReleaseEventArgs args, IEnumerable<VisualObject> selectedParentObject)
    {
    }

    protected virtual void inputDispatch_BeforeKeyDown(KeyPressEventArgs args, IEnumerable<VisualObject> selectedParentObject)
    {
    }

    protected virtual void inputDispatch_AfterMouseUp(MouseEventArgsExtend args, IEnumerable<VisualObject> selectedParentObject)
    {
      if (this.isMouseUped || !this.isMouseDowned)
        return;
      this.isMouseDowned = false;
      foreach (BaseObject baseObject in selectedParentObject)
        baseObject.Recorder.Start(true, false);
      this.undoManager.EndCompositeTask();
      this.isMouseUped = true;
    }

    protected virtual void inputDispatch_AfterMouseMove(MouseEventArgsExtend args, IEnumerable<VisualObject> selectedParentObject)
    {
    }

    protected virtual void inputDispatch_AfterMouseDown(MouseEventArgsExtend args, IEnumerable<VisualObject> selectedParentObject)
    {
    }

    protected virtual void inputDispatch_AfterKeyUp(KeyReleaseEventArgs args, IEnumerable<VisualObject> selectedParentObject)
    {
    }

    protected virtual void inputDispatch_AfterKeyDown(KeyPressEventArgs args, IEnumerable<VisualObject> selectedParentObject)
    {
    }
  }
}
