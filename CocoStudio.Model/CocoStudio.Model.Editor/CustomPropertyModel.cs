using CocoStudio.Model.ViewModel;
using System;
using System.Runtime.Serialization;

namespace CocoStudio.Model.Editor
{
	[DataContract]
	public class CustomPropertyModel : NotificationObject
	{
		private string _Name;

		private string _Type;

		private object _Value;

		[DataMember(Name = "key")]
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

		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				this._Type = value;
				if (this.Value == null || this.Value == "")
				{
					this.SetDefuleValue(value);
				}
				this.RaisePropertyChanged<string>(() => this.Type);
			}
		}

		[DataMember(Name = "value")]
		public object Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				this._Value = value;
				this.RaisePropertyChanged<object>(() => this.Value);
			}
		}

		private void SetDefuleValue(string typeString)
		{
			if (typeString == "Double")
			{
				this.Value = 0.0;
			}
			else if (typeString == "Int")
			{
				this.Value = 0;
			}
			else if (typeString == "Boolean")
			{
				this.Value = false;
			}
		}
	}
}
