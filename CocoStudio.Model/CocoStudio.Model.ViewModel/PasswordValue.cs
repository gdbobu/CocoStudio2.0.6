using System;

namespace CocoStudio.Model.ViewModel
{
	public class PasswordValue
	{
		private bool passwordEnable;

		private string passwordStyleText;

		public bool PasswordEnable
		{
			get
			{
				return this.passwordEnable;
			}
			set
			{
				if (this.passwordEnable != value)
				{
					this.passwordEnable = value;
				}
			}
		}

		public string PasswordStyleText
		{
			get
			{
				return this.passwordStyleText;
			}
			set
			{
				if (!(this.passwordStyleText == value))
				{
					this.passwordStyleText = value;
				}
			}
		}

		public PasswordValue(bool passwordEnable, string passwordStyleText)
		{
			this.PasswordEnable = passwordEnable;
			this.PasswordStyleText = passwordStyleText;
		}

		public bool Equals(PasswordValue others)
		{
			return !(others == null) && (this.PasswordEnable == others.PasswordEnable && this.PasswordStyleText == others.PasswordStyleText);
		}

		public override bool Equals(object obj)
		{
			return obj is PasswordValue && this.Equals((PasswordValue)obj);
		}

		public override int GetHashCode()
		{
			int hashCode = this.PasswordEnable.GetHashCode();
			return hashCode ^ this.PasswordStyleText.GetHashCode();
		}

		public static bool operator ==(PasswordValue leftValue, PasswordValue rightValue)
		{
			bool result;
			if (object.ReferenceEquals(leftValue, null))
			{
				result = object.ReferenceEquals(rightValue, null);
			}
			else
			{
				result = leftValue.Equals(rightValue);
			}
			return result;
		}

		public static bool operator !=(PasswordValue leftValue, PasswordValue rightValue)
		{
			return !(leftValue == rightValue);
		}
	}
}
