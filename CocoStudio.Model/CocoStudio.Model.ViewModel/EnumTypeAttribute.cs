using System;

namespace CocoStudio.Model.ViewModel
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
	public class EnumTypeAttribute : Attribute
	{
		private string description;

		public string Description
		{
			get
			{
				return this.description;
			}
		}

		public EnumTypeAttribute(string Description_in)
		{
			this.description = Description_in;
		}
	}
}
