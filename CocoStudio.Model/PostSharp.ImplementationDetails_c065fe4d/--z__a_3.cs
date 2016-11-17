using CocoStudio.Model.ViewModel;
using CocoStudio.UserStatistics;
using PostSharp.Reflection;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PostSharp.ImplementationDetails_c065fe4d
{
	[DebuggerNonUserCode, CompilerGenerated]
	internal sealed class <>z__a_3
	{
		internal static readonly TracePropertyCallAttribute a2;

		internal static LocationInfo _2;

		[CompilerGenerated]
		static <>z__a_3()
		{
			<>z__a_3._2 = ReflectionHelper.GetLocation(typeof(ImageViewObject), methodof(ImageViewObject.get_Scale9Enable()), methodof(ImageViewObject.set_Scale9Enable(bool)));
			<>z__a_3.a2 = (TracePropertyCallAttribute)<>z__a_7.aspects1[2];
		}
	}
}
