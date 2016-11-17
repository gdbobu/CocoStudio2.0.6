using CocoStudio.EngineAdapterWrap;
using Gdk;
using System;
using System.Collections.Generic;

namespace CocoStudio.Model.ViewModel
{
	public class EasingData
	{
		private TweenType tweenType = TweenType.Custom;

		private List<Point> proportionPoints;

		public TweenType TweenType
		{
			get
			{
				return this.tweenType;
			}
			set
			{
				this.tweenType = value;
			}
		}

		public List<Point> ProportionPoints
		{
			get
			{
				return this.proportionPoints;
			}
			set
			{
				this.proportionPoints = value;
			}
		}

		public EasingData(TweenType tweentype)
		{
			this.tweenType = tweentype;
			this.ProportionPoints = new List<Point>();
		}

		public EasingData(TweenType tweentype, params Point[] points) : this(tweentype)
		{
			this.ProportionPoints.AddRange(points);
		}

		public static EasingData CreatEasingData(TweenType tweenType, CSVectorFloat easingparma)
		{
			EasingData easingData = new EasingData(tweenType);
			if (easingparma != null)
			{
				if (tweenType == TweenType.Custom)
				{
					int count = easingparma.Count;
					if (count == 8)
					{
						for (int i = 0; i < count; i += 2)
						{
							easingData.ProportionPoints.Add(new Point((int)easingparma[i], (int)easingparma[i + 1]));
						}
					}
				}
				else
				{
					int count = easingparma.Count;
					for (int i = 0; i < count; i++)
					{
						easingData.ProportionPoints.Add(new Point((int)easingparma[i], 0));
					}
				}
			}
			return easingData;
		}

		public static implicit operator CSVectorFloat(EasingData easingparma)
		{
			CSVectorFloat retParma = new CSVectorFloat();
			if (easingparma != null && easingparma.ProportionPoints != null)
			{
				if (easingparma.TweenType == TweenType.Custom)
				{
					easingparma.ProportionPoints.ForEach(delegate(Point point)
					{
						retParma.AddRange(new CSVectorFloat
						{
							(float)point.X,
							(float)point.Y
						});
					});
				}
				else
				{
					easingparma.ProportionPoints.ForEach(delegate(Point point)
					{
						retParma.AddRange(new CSVectorFloat
						{
							(float)point.X
						});
					});
				}
			}
			return retParma;
		}

		public static EasingData CreatEasingData(TweenType tweenType, List<float> easingparma)
		{
			EasingData easingData = new EasingData(tweenType);
			if (easingparma != null)
			{
				if (tweenType == TweenType.Custom)
				{
					int count = easingparma.Count;
					if (count == 8)
					{
						for (int i = 0; i < count; i += 2)
						{
							easingData.ProportionPoints.Add(new Point((int)easingparma[i], (int)easingparma[i + 1]));
						}
					}
				}
				else
				{
					int count = easingparma.Count;
					for (int i = 0; i < count; i++)
					{
						easingData.ProportionPoints.Add(new Point((int)easingparma[i], 0));
					}
				}
			}
			return easingData;
		}

		public static implicit operator List<float>(EasingData easingparma)
		{
			List<float> retParma = new List<float>();
			if (easingparma != null && easingparma.ProportionPoints != null)
			{
				if (easingparma.TweenType == TweenType.Custom)
				{
					easingparma.ProportionPoints.ForEach(delegate(Point point)
					{
						retParma.AddRange(new CSVectorFloat
						{
							(float)point.X,
							(float)point.Y
						});
					});
				}
				else
				{
					easingparma.ProportionPoints.ForEach(delegate(Point point)
					{
						retParma.AddRange(new CSVectorFloat
						{
							(float)point.X
						});
					});
				}
			}
			return retParma;
		}

		public override int GetHashCode()
		{
			int result;
			if (this.ProportionPoints != null && this.ProportionPoints.Count == 4)
			{
				result = (this.ProportionPoints[0].GetHashCode() ^ this.ProportionPoints[1].GetHashCode() ^ this.ProportionPoints[2].GetHashCode() ^ this.ProportionPoints[3].GetHashCode());
			}
			else
			{
				result = this.ProportionPoints.GetHashCode();
			}
			return result;
		}

		public override bool Equals(object obj)
		{
			bool flag = false;
			bool result;
			if (obj is EasingData)
			{
				EasingData easingData = obj as EasingData;
				if (easingData != null && easingData.ProportionPoints != null && easingData.ProportionPoints.Count == 4 && this.ProportionPoints != null && this.ProportionPoints.Count == 4)
				{
					result = (this.ProportionPoints[0].Equals(easingData.ProportionPoints[0]) && this.ProportionPoints[1].Equals(easingData.ProportionPoints[1]) && this.ProportionPoints[2].Equals(easingData.ProportionPoints[2]) && this.ProportionPoints[3].Equals(easingData.ProportionPoints[3]));
					return result;
				}
			}
			result = flag;
			return result;
		}
	}
}
