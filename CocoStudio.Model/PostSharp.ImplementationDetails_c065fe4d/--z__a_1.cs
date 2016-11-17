using CocoStudio.Model.ViewModel;
using CocoStudio.UserStatistics;
using PostSharp.Reflection;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PostSharp.ImplementationDetails_c065fe4d
{
	[DebuggerNonUserCode, CompilerGenerated]
	internal sealed class <>z__a_1
	{
		internal static readonly TracePropertyCallAttribute a0;

		internal static LocationInfo _2;

		[CompilerGenerated]
		static <>z__a_1()
		{
			<>z__a_1._2 = ReflectionHelper.GetLocation(typeof(WidgetObject), methodof(WidgetObject.get_TouchEnable()), methodof(WidgetObject.set_TouchEnable(bool)));
			<>z__a_1.a0 = (TracePropertyCallAttribute)<>z__a_7.aspects1[0];
		}
	}
}
