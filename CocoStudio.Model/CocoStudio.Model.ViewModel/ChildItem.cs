using Modules.Communal.MultiLanguage;
using System;

namespace CocoStudio.Model.ViewModel
{
	public class ChildItem : NotificationObject
	{
		private string _Name;

		private int _ID;

		private object _SaveValue;

		private string _OtherName;

		public string OtherName
		{
			get
			{
				return this._OtherName;
			}
			set
			{
				if (this._Name != value)
				{
					this._OtherName = value;
					this.SetShowName();
					this.RaisePropertyChanged<string>(() => this.OtherName);
				}
			}
		}

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

		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				this._Name = value;
				this.RaisePropertyChanged<string>(() => this.Name);
			}
		}

		public object SaveValue
		{
			get
			{
				return this._SaveValue;
			}
			set
			{
				this._SaveValue = value;
				this.RaisePropertyChanged<object>(() => this.SaveValue);
			}
		}

		private void SetShowName()
		{
			LanguageType currentLanguage = LanguageOption.CurrentLanguage;
			if (currentLanguage == LanguageType.Chinese && !string.IsNullOrWhiteSpace(this.OtherName))
			{
				this.Name = this.OtherName;
			}
		}
	}
}
