using System;

namespace CocoStudio.Model.ViewModel
{
	public enum TweenType
	{
		Custom = -1,
		[EnumType("Linear")]
		Linear,
		[EnumType("Sine_EaseIn")]
		Sine_EaseIn,
		[EnumType("Sine_EaseOut")]
		Sine_EaseOut,
		[EnumType("Sine_EaseInOut")]
		Sine_EaseInOut,
		[EnumType("Quad_EaseIn")]
		Quad_EaseIn,
		[EnumType("Quad_EaseOut")]
		Quad_EaseOut,
		[EnumType("Quad_EaseInOut")]
		Quad_EaseInOut,
		[EnumType("Cubic_EaseIn")]
		Cubic_EaseIn,
		[EnumType("Cubic_EaseOut")]
		Cubic_EaseOut,
		[EnumType("Cubic_EaseInOut")]
		Cubic_EaseInOut,
		[EnumType("Quart_EaseIn")]
		Quart_EaseIn,
		[EnumType("Quart_EaseOut")]
		Quart_EaseOut,
		[EnumType("Quart_EaseInOut")]
		Quart_EaseInOut,
		[EnumType("Quint_EaseIn")]
		Quint_EaseIn,
		[EnumType("Quint_EaseOut")]
		Quint_EaseOut,
		[EnumType("Quint_EaseInOut")]
		Quint_EaseInOut,
		[EnumType("Expo_EaseIn")]
		Expo_EaseIn,
		[EnumType("Expo_EaseOut")]
		Expo_EaseOut,
		[EnumType("Expo_EaseInOut")]
		Expo_EaseInOut,
		[EnumType("Circ_EaseIn")]
		Circ_EaseIn,
		[EnumType("Circ_EaseOut")]
		Circ_EaseOut,
		[EnumType("Circ_EaseInOut")]
		Circ_EaseInOut,
		[EnumType("Elastic_EaseIn"), EnumType("Elastic_EaseInOut"), EnumType("Elastic_EaseOut"), EnumType("Back_EaseIn")]
		Back_EaseIn,
		[EnumType("Back_EaseOut")]
		Back_EaseOut,
		[EnumType("Back_EaseInOut")]
		Back_EaseInOut,
		[EnumType("Bounce_EaseIn")]
		Bounce_EaseIn,
		[EnumType("Bounce_EaseOut")]
		Bounce_EaseOut,
		[EnumType("Bounce_EaseInOut")]
		Bounce_EaseInOut,
		TWEEN_EASING_MAX = 10000
	}
}
