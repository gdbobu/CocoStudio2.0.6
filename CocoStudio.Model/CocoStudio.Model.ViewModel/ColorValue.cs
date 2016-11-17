using System;
using System.Drawing;

namespace CocoStudio.Model.ViewModel
{
	public struct ColorValue
	{
		private int comboBoxIndex;

		private Color singleColor;

		private Color firstColor;

		private Color endColor;

		private float vectorX;

		private float vectorY;

		public int ComboBoxIndex
		{
			get
			{
				return this.comboBoxIndex;
			}
			set
			{
				if (this.comboBoxIndex != value)
				{
					this.comboBoxIndex = value;
				}
			}
		}

		public Color SingleColor
		{
			get
			{
				return this.singleColor;
			}
			set
			{
				if (!(this.singleColor == value))
				{
					this.singleColor = value;
				}
			}
		}

		public Color FirstColor
		{
			get
			{
				return this.firstColor;
			}
			set
			{
				if (!(this.firstColor == value))
				{
					this.firstColor = value;
				}
			}
		}

		public Color EndColor
		{
			get
			{
				return this.endColor;
			}
			set
			{
				if (!(this.endColor == value))
				{
					this.endColor = value;
				}
			}
		}

		public float VectorX
		{
			get
			{
				return this.vectorX;
			}
			set
			{
				if (this.vectorX != value)
				{
					this.vectorX = value;
				}
			}
		}

		public float VectorY
		{
			get
			{
				return this.vectorY;
			}
			set
			{
				if (this.vectorY != value)
				{
					this.vectorY = value;
				}
			}
		}

		public ColorValue(int comboBoxIndex, Color singleColor, Color firstColor, Color endColor, float VectorX, float VectorY)
		{
			this = default(ColorValue);
			this.ComboBoxIndex = comboBoxIndex;
			this.SingleColor = singleColor;
			this.FirstColor = firstColor;
			this.EndColor = endColor;
			this.VectorX = VectorX;
			this.VectorY = VectorY;
		}

		public ColorValue(Color singleColor)
		{
			this = default(ColorValue);
			this.SingleColor = singleColor;
		}

		public ColorValue(Color firstColor, Color endColor)
		{
			this = default(ColorValue);
			this.FirstColor = firstColor;
			this.EndColor = endColor;
		}

		public bool Equal(ColorValue vColor)
		{
			return this.ComboBoxIndex == vColor.ComboBoxIndex && this.SingleColor == vColor.SingleColor && this.FirstColor == vColor.FirstColor && this.EndColor == vColor.EndColor && this.VectorX == vColor.VectorX && this.VectorY == vColor.VectorY;
		}
	}
}
