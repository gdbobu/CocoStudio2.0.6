using System;

namespace CocoStudio.Model.ViewModel
{
	public enum BlendType
	{
		[EnumType("正常")]
		BLEND_NORMAL,
		[EnumType("正片垫底")]
		BLEND_MULTIPLY = 3,
		[EnumType("滤色")]
		BLEND_SCREEN = 5,
		[EnumType("增加")]
		BLEND_ADD = 8
	}
}
