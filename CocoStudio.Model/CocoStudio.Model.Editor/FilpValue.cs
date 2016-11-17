using System;

namespace CocoStudio.Model.Editor
{
	public class FilpValue
	{
		private bool filpX;

		private bool filpY;

		public bool FlipX
		{
			get
			{
				return this.filpX;
			}
			set
			{
				this.filpX = value;
			}
		}

		public bool FlipY
		{
			get
			{
				return this.filpY;
			}
			set
			{
				this.filpY = value;
			}
		}

		public FilpValue(bool filpX, bool filpY)
		{
			this.FlipX = filpX;
			this.FlipY = filpY;
		}

		public bool Equals(FilpValue others)
		{
			return !(others == null) && (this.FlipX == others.FlipX && this.FlipY == others.FlipY);
		}

		public override bool Equals(object obj)
		{
			return obj is FilpValue && this.Equals((FilpValue)obj);
		}

		public override int GetHashCode()
		{
			int hashCode = this.FlipX.GetHashCode();
			return hashCode ^ this.FlipY.GetHashCode();
		}

		public static bool operator ==(FilpValue leftValue, FilpValue rightValue)
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

		public static bool operator !=(FilpValue leftValue, FilpValue rightValue)
		{
			return !(leftValue == rightValue);
		}
	}
}
