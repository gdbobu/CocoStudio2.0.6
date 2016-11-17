using CocoStudio.UserStatistics;
using PostSharp.Aspects;
using PostSharp.Reflection;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PostSharp.ImplementationDetails_c065fe4d
{
	[DebuggerNonUserCode, CompilerGenerated]
	internal sealed class <>z__MetadataDispenser : IMetadataDispenser
	{
		public static <>z__MetadataDispenser Instance;

		public override object GetMetadata(int index)
		{
			switch (index)
			{
			case 0:
				return null;
			case 1:
				return typeof(IAspect);
			case 2:
				return typeof(TracePropertyCallAttribute);
			case 3:
				return typeof(ViewRegions);
			default:
				throw new ArgumentException();
			}
		}

		static <>z__MetadataDispenser()
		{
			<>z__MetadataDispenser.Instance = new <>z__MetadataDispenser();
		}

		private <>z__MetadataDispenser()
		{
		}
	}
}
