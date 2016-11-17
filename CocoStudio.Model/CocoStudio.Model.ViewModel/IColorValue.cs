using System;
using System.Drawing;

namespace CocoStudio.Model.ViewModel
{
	internal interface IColorValue
	{
		int ComboBoxIndex
		{
			get;
			set;
		}

		Color EndColor
		{
			get;
			set;
		}

		Color FirstColor
		{
			get;
			set;
		}

		Color SingleColor
		{
			get;
			set;
		}

		ScaleValue ColorVector
		{
			get;
			set;
		}
	}
}
