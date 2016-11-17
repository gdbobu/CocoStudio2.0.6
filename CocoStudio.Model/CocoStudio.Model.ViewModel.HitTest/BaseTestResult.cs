using System;

namespace CocoStudio.Model.ViewModel.HitTest
{
	public abstract class BaseTestResult : IComparable
	{
		public VisualObject HitVisual
		{
			get;
			private set;
		}

		public bool IsContinueTest
		{
			get;
			private set;
		}

		public BaseTestResult(VisualObject hitVisual, bool isContinueTest)
		{
			this.HitVisual = hitVisual;
			this.IsContinueTest = isContinueTest;
		}

		public int CompareTo(object obj)
		{
			int result;
			if (obj == null || !(obj is BaseTestResult))
			{
				result = 1;
			}
			else
			{
				BaseTestResult baseTestResult = obj as BaseTestResult;
				if (baseTestResult.HitVisual == null)
				{
					result = 1;
				}
				else if (this.HitVisual == null)
				{
					result = -1;
				}
				else
				{
					result = this.HitVisual.CompareTo(baseTestResult.HitVisual);
				}
			}
			return result;
		}
	}
}
