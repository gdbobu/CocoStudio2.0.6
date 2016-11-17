using System;
using System.Runtime.Serialization;

namespace CocoStudio.Model.ViewModel
{
	[DataContract]
	public class EventModel : BaseInfo
	{
		private int _ID;

		private string _ClassName;

		[DataMember(Name = "id")]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				this._ID = value;
				this.RaisePropertyChanged<int>(() => this.ID);
			}
		}

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

		public EventModel()
		{
			this.BindingRecorder("TriggerUndoAndRedo");
		}
	}
}
