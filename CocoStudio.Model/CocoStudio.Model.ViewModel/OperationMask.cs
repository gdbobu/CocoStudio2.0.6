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
		AllFlag = 65535
	}
}
