using CocoStudio.UndoManager;
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace CocoStudio.Model.ViewModel
{
	[DataContract]
	public class ConditionMode : BaseInfo
	{
		private ObservableCollection<DataItem> _DataItems;

		private string _ClassName;

		[DataMember(Name = "classname")]
		public string ClassName
		{
			get
			{
				return this._ClassName;
			}
			set
			{
				this._ClassName = value;
				this.RaisePropertyChanged<string>(() => this.ClassName);
			}
		}

		[UndoProperty, DataMember(Name = "dataitems")]
		public ObservableCollection<DataItem> DataItems
		{
			get
			{
				return this._DataItems;
			}
			set
			{
				this._DataItems = value;
				this.RaisePropertyChanged<ObservableCollection<DataItem>>(() => this.DataItems);
			}
		}

		public ConditionMode()
		{
			this.BindingRecorder("TriggerUndoAndRedo");
		}
	}
}
