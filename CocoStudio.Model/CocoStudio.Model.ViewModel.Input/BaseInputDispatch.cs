using CocoStudio.Model.Interface;
using CocoStudio.UndoManager;
using Gtk;
using System;
using System.Collections.Generic;

namespace CocoStudio.Model.ViewModel.Input
{
	internal abstract class BaseInputDispatch
	{
		protected bool isMouseDowned;

		protected bool isMouseUped;

		protected IUndoManager undoManager;

		private IEnumerable<VisualObject> mouseDownObjectList = null;

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
				foreach (VisualObject current in this.mouseDownObjectList)
				{
					current.Recorder.Start(true, false);
				}
				this.undoManager.EndCompositeTask();
			}
			else
			{
				this.isMouseUped = false;
				this.undoManager.BeginCompositeTask(null);
				foreach (VisualObject current in selectedParentObject)
				{
					current.Recorder.Stop(false);
				}
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
			if (!this.isMouseUped && this.isMouseDowned)
			{
				this.isMouseDowned = false;
				foreach (VisualObject current in selectedParentObject)
				{
					current.Recorder.Start(true, false);
				}
				this.undoManager.EndCompositeTask();
				this.isMouseUped = true;
			}
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
