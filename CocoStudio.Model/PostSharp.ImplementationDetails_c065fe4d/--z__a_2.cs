using CocoStudio.Model.ViewModel;
using CocoStudio.UserStatistics;
using PostSharp.Reflection;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PostSharp.ImplementationDetails_c065fe4d
{
	[DebuggerNonUserCode, CompilerGenerated]
	internal sealed class <>z__a_2
	{
		internal static readonly TracePropertyCallAttribute a1;

		internal static LocationInfo _2;

		[CompilerGenerated]
		static <>z__a_2()
		{
			<>z__a_2._2 = ReflectionHelper.GetLocation(typeof(ButtonObject), methodof(ButtonObject.get_Scale9Enable()), methodof(ButtonObject.set_Scale9Enable(bool)));
			<>z__a_2.a1 = (TracePropertyCallAttribute)<>z__a_7.aspects1[1];
		}
	}
}
