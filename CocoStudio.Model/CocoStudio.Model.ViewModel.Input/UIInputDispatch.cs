using CocoStudio.Model.Interface;
using CocoStudio.UndoManager;
using Gtk;
using System;
using System.Collections.Generic;

namespace CocoStudio.Model.ViewModel.Input
{
	internal class UIInputDispatch : BaseInputDispatch
	{
		private bool bMouseValid = false;

		public UIInputDispatch(IUndoManager undoManager, IRenderUC renderUC) : base(undoManager, renderUC)
		{
		}

		protected override void inputDispatch_BeforeMouseDown(MouseEventArgsExtend args, IEnumerable<VisualObject> selectedParentObject)
		{
			if (TimelineActionManager.Instance.IsPlaying)
			{
				TimelineActionManager.Instance.Play(false);
			}
			base.inputDispatch_BeforeMouseDown(args, selectedParentObject);
			if (args.Button == MouseButton.Left)
			{
				this.bMouseValid = true;
				selectedParentObject.ForEach(delegate(VisualObject a)
				{
					a.MouseDown(args);
				});
			}
			args.Handled = true;
		}

		protected override void inputDispatch_BeforeMouseMove(MouseEventArgsExtend args, IEnumerable<VisualObject> selectedParentObject)
		{
			base.inputDispatch_BeforeMouseMove(args, selectedParentObject);
			if (args != null && args.HitResult != null)
			{
				VisualObject hitVisual = args.HitResult.HitVisual;
			}
			if (this.bMouseValid)
			{
				selectedParentObject.ForEach(delegate(VisualObject a)
				{
					a.MouseMove(args);
				});
			}
			args.Handled = true;
		}

		protected override void inputDispatch_AfterMouseUp(MouseEventArgsExtend args, IEnumerable<VisualObject> selectedParentObject)
		{
			base.inputDispatch_AfterMouseUp(args, selectedParentObject);
			if (this.bMouseValid)
			{
				selectedParentObject.ForEach(delegate(VisualObject a)
				{
					a.MouseUp(args);
				});
			}
			this.bMouseValid = false;
			args.Handled = true;
		}
	}
}
