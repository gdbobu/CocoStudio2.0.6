using CocoStudio.Model.Editor;
using CocoStudio.UndoManager;
using CocoStudio.UndoManager.Recorder;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace CocoStudio.Model.ViewModel
{
	public abstract class BaseObject : NotificationObject, INotifyStateChanged, INotifyPropertyChanged
	{
		protected string name;

		public event EventHandler<StateChangedEventArgs> StateChanged;

		[Browsable(false)]
		public bool IsRaiseStateChanged
		{
			get;
			set;
		}

		[Browsable(false)]
		public BaseRecorder Recorder
		{
			get;
			protected set;
		}

		[UndoProperty, Category("Group_Routine"), DisplayName("Display_Name"), Editor(typeof(NameEditor), typeof(NameEditor))]
		public virtual string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
				this.RaisePropertyChanged<string>(() => this.Name);
				this.RaisePropertyChanged<string>(() => this.DisplayName);
			}
		}

		[Browsable(false)]
		public virtual string DisplayName
		{
			get
			{
				string result;
				if (!string.IsNullOrEmpty(this.Name))
				{
					result = this.Name;
				}
				else
				{
					result = "[Node]";
				}
				return result;
			}
		}

		public BaseObject()
		{
			this.IsRaiseStateChanged = true;
		}

		public BaseObject(string name) : this()
		{
			this.name = name;
		}

		protected void RaisePropertyChanged(PropertyInfo propertyInfo, bool isNotifyStateChanged)
		{
			if (isNotifyStateChanged)
			{
				this.RaiseStateChanged(propertyInfo.Name);
			}
			base.RaisePropertyChanged(propertyInfo);
		}

		protected override void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
		{
			this.RaisePropertyChanged<T>(propertyExpression, this.IsRaiseStateChanged);
		}

		protected virtual void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression, bool isNotifyStateChanged)
		{
			PropertyInfo propertyInfo = PropertySupport.ExtractPropertyInfo<T>(propertyExpression);
			this.RaisePropertyChanged(propertyInfo, isNotifyStateChanged);
		}

		private void RaiseStateChanged(StateChangedEventArgs args)
		{
			if (this.StateChanged != null)
			{
				this.StateChanged(this, args);
			}
		}

		private void RaiseStateChanged(string propertyName)
		{
			this.RaiseStateChanged(new StateChangedEventArgs(propertyName));
		}

		public virtual void BindingRecorder(string taskGroupName = null)
		{
			if (this.Recorder == null && BaseRecorder.IsCreateDefaultRecorder)
			{
				this.Recorder = new DefaultRecorder(this, taskGroupName);
			}
		}
	}
}
