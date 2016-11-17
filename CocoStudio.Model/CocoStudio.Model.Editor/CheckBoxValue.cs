using System;

namespace CocoStudio.Model.Editor
{
	public class CheckBoxValue
	{
		private bool isChecked;

		private bool isEnabled;

		public bool IsChecked
		{
			get
			{
				return this.isChecked;
			}
			set
			{
				if (this.isChecked != value)
				{
					this.isChecked = value;
				}
			}
		}

		public bool CanEnabled
		{
			get
			{
				return this.isEnabled;
			}
			set
			{
				if (this.isEnabled != value)
				{
					this.isEnabled = value;
				}
			}
		}

		public CheckBoxValue(bool isChecked, bool isEnabled)
		{
			this.IsChecked = isChecked;
			this.CanEnabled = isEnabled;
		}

		public bool Equals(CheckBoxValue others)
		{
			return !(others == null) && (this.IsChecked == others.IsChecked && this.CanEnabled == others.CanEnabled);
		}

		public override bool Equals(object obj)
		{
			return obj is CheckBoxValue && this.Equals((CheckBoxValue)obj);
		}

		public override int GetHashCode()
		{
			int hashCode = this.IsChecked.GetHashCode();
			return hashCode ^ this.CanEnabled.GetHashCode();
		}

		public static bool operator ==(CheckBoxValue leftValue, CheckBoxValue rightValue)
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

		public static bool operator !=(CheckBoxValue leftValue, CheckBoxValue rightValue)
		{
			return !(leftValue == rightValue);
		}
	}
}
