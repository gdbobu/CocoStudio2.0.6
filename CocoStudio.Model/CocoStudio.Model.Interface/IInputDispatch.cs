using CocoStudio.Model.ViewModel;
using Gtk;
using System;

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
