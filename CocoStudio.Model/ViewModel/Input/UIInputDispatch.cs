// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.Input.UIInputDispatch
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.Interface;
using CocoStudio.UndoManager;
using Gtk;
using System.Collections.Generic;

namespace CocoStudio.Model.ViewModel.Input
{
  internal class UIInputDispatch : BaseInputDispatch
  {
    private bool bMouseValid = false;

    public UIInputDispatch(IUndoManager undoManager, IRenderUC renderUC)
      : base(undoManager, renderUC)
    {
    }

    protected override void inputDispatch_BeforeMouseDown(MouseEventArgsExtend args, IEnumerable<VisualObject> selectedParentObject)
    {
      if (TimelineActionManager.Instance.IsPlaying)
        TimelineActionManager.Instance.Play(false);
      base.inputDispatch_BeforeMouseDown(args, selectedParentObject);
      if (args.Button == MouseButton.Left)
      {
        this.bMouseValid = true;
        selectedParentObject.ForEach<VisualObject>((System.Action<VisualObject>) (a => a.MouseDown(args)));
      }
      args.Handled = true;
    }

    protected override void inputDispatch_BeforeMouseMove(MouseEventArgsExtend args, IEnumerable<VisualObject> selectedParentObject)
    {
      base.inputDispatch_BeforeMouseMove(args, selectedParentObject);
      VisualObject visualObject = (VisualObject) null;
      if (args != null && args.HitResult != null)
        visualObject = args.HitResult.HitVisual;
      if (this.bMouseValid)
        selectedParentObject.ForEach<VisualObject>((System.Action<VisualObject>) (a => a.MouseMove(args)));
      args.Handled = true;
    }

    protected override void inputDispatch_AfterMouseUp(MouseEventArgsExtend args, IEnumerable<VisualObject> selectedParentObject)
    {
      base.inputDispatch_AfterMouseUp(args, selectedParentObject);
      if (this.bMouseValid)
        selectedParentObject.ForEach<VisualObject>((System.Action<VisualObject>) (a => a.MouseUp(args)));
      this.bMouseValid = false;
      args.Handled = true;
    }
  }
}
