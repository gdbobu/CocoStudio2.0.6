using CocoStudio.Model.Interface;
using CocoStudio.UndoManager;
using System;

namespace CocoStudio.Model.ViewModel.Input
{
	internal class SceneInputDispatch : BaseInputDispatch
	{
		public SceneInputDispatch(IUndoManager undoManager, IRenderUC renderUC) : base(undoManager, renderUC)
		{
		}
	}
}
