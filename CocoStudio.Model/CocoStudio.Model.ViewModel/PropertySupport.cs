using System;
using System.Linq.Expressions;
using System.Reflection;

namespace CocoStudio.Model.ViewModel
{
	public static class PropertySupport
	{
		public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
		{
			return PropertySupport.ExtractPropertyInfo<T>(propertyExpression).Name;
		}

		public static PropertyInfo ExtractPropertyInfo<T>(Expression<Func<T>> propertyExpression)
		{
			if (propertyExpression == null)
			{
				throw new ArgumentNullException("propertyExpression");
			}
			MemberExpression memberExpression = propertyExpression.Body as MemberExpression;
			if (memberExpression == null)
			{
				throw new ArgumentException("PropertySupport_NotMemberAccessExpression_Exception", "propertyExpression");
			}
			PropertyInfo propertyInfo = memberExpression.Member as PropertyInfo;
			if (propertyInfo == null)
			{
				throw new ArgumentException("PropertySupport_ExpressionNotProperty_Exception", "propertyExpression");
			}
			MethodInfo getMethod = propertyInfo.GetGetMethod(true);
			if (getMethod.IsStatic)
			{
				throw new ArgumentException("PropertySupport_StaticExpression_Exception", "propertyExpression");
			}
			return propertyInfo;
		}
	}
}
