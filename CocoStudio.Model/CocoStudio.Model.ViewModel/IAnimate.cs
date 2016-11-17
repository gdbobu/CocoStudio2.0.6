using System;
using System.Drawing;

namespace CocoStudio.Model.ViewModel
{
	public interface IAnimate
	{
		int ActionTag
		{
			get;
			set;
		}

		int Alpha
		{
			get;
			set;
		}

		Color CColor
		{
			get;
			set;
		}

		string FrameEvent
		{
			get;
			set;
		}
	}
}
