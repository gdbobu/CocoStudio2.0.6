using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace CocoStudio.Model.ViewModel
{
	public abstract class NotificationObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChanged(PropertyInfo propertyInfo)
		{
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged != null)
			{
				propertyChanged(this, new PropertyChangedEventArgs(propertyInfo.Name));
			}
		}

		private void RaisePropertyChanged(params string[] propertyNames)
		{
			if (propertyNames == null)
			{
				throw new ArgumentNullException("propertyNames");
			}
			for (int i = 0; i < propertyNames.Length; i++)
			{
				string text = propertyNames[i];
				this.RaisePropertyChanged(new string[]
				{
					text
				});
			}
		}

		protected virtual void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
		{
			PropertyInfo propertyInfo = PropertySupport.ExtractPropertyInfo<T>(propertyExpression);
			this.RaisePropertyChanged(propertyInfo);
		}
	}
}
