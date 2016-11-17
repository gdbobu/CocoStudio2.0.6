using Modules.Communal.MultiLanguage;
using System;
using System.Runtime.Serialization;

namespace CocoStudio.Model.ViewModel
{
	[DataContract]
	public class BaseInfo : BaseObject, ICloneable
	{
		private string _Name;

		private EIdentify _Identify;

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

		public override string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if (this._Name != value)
				{
					this._Name = value;
					this.RaisePropertyChanged<string>(() => this.Name);
				}
			}
		}

		public EIdentify Identify
		{
			get
			{
				bool flag = 0 == 0;
				return this._Identify;
			}
			set
			{
				if (this._Identify != value)
				{
					this._Identify = value;
					this.RaisePropertyChanged<EIdentify>(() => this.Identify);
				}
			}
		}

		private EIdentify GetIdentify()
		{
			EIdentify result;
			if (this is EventModel)
			{
				result = EIdentify.Event;
			}
			else if (this is ConditionMode)
			{
				result = EIdentify.Condition;
			}
			else if (this is ActionModel)
			{
				result = EIdentify.Action;
			}
			else
			{
				result = EIdentify.None;
			}
			return result;
		}

		private void SetShowName()
		{
			LanguageType currentLanguage = LanguageOption.CurrentLanguage;
			if (currentLanguage == LanguageType.Chinese && !string.IsNullOrWhiteSpace(this.OtherName))
			{
				this.Name = this.OtherName;
			}
		}

		public object Clone()
		{
			return base.MemberwiseClone();
		}
	}
}
