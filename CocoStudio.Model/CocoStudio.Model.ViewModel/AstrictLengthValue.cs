using System;

namespace CocoStudio.Model.ViewModel
{
	public class AstrictLengthValue
	{
		private bool maxLengthEnable;

		private int maxLengthText;

		public bool MaxLengthEnable
		{
			get
			{
				return this.maxLengthEnable;
			}
			set
			{
				if (this.maxLengthEnable != value)
				{
					this.maxLengthEnable = value;
				}
			}
		}

		public int MaxLengthText
		{
			get
			{
				return this.maxLengthText;
			}
			set
			{
				if (this.maxLengthText != value)
				{
					this.maxLengthText = value;
				}
			}
		}

		public AstrictLengthValue(bool maxLengthEnable, int maxLengthText)
		{
			this.MaxLengthEnable = maxLengthEnable;
			this.MaxLengthText = maxLengthText;
		}

		public bool Equals(AstrictLengthValue others)
		{
			return !(others == null) && (this.MaxLengthEnable == others.MaxLengthEnable && this.MaxLengthText == others.MaxLengthText);
		}

		public override bool Equals(object obj)
		{
			return obj is AstrictLengthValue && this.Equals((AstrictLengthValue)obj);
		}

		public override int GetHashCode()
		{
			int hashCode = this.MaxLengthEnable.GetHashCode();
			return hashCode ^ this.MaxLengthText.GetHashCode();
		}

		public static bool operator ==(AstrictLengthValue leftValue, AstrictLengthValue rightValue)
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

		public static bool operator !=(AstrictLengthValue leftValue, AstrictLengthValue rightValue)
		{
			return !(leftValue == rightValue);
		}
	}
}
