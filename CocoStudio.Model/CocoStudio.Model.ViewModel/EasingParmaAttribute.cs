using System;

namespace CocoStudio.Model.ViewModel
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
	public class EasingParmaAttribute : Attribute
	{
		private string[] signName;

		public string[] SignNames
		{
			get
			{
				return this.signName;
			}
		}

		public EasingParmaAttribute(params string[] signNames)
		{
			this.signName = signNames;
		}
	}
}
