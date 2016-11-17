using Mono.Addins;
using System;

namespace CocoStudio.Model
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public sealed class ModelExtensionAttribute : CustomExtensionAttribute
	{
		[NodeAttribute]
		public int Order
		{
			get;
			private set;
		}

		[NodeAttribute]
		public bool IsDefault
		{
			get;
			private set;
		}

		public ModelExtensionAttribute()
		{
		}

		public ModelExtensionAttribute([NodeAttribute("Order")] int order) : this(false, order)
		{
		}

		internal ModelExtensionAttribute([NodeAttribute("IsDefault")] bool isDefault, [NodeAttribute("Order")] int order)
		{
			this.Order = order;
			this.IsDefault = isDefault;
		}
	}
}
