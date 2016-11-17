// Decompiled with JetBrains decompiler
// Type: CocoStudio.UserStatistics.FeatureInfo
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

namespace CocoStudio.UserStatistics
{
  public class FeatureInfo
  {
    private int count = 1;

    public ViewRegions Region { get; private set; }

    public string FeatureName { get; private set; }

    public string MethodName { get; private set; }

    public string NewValue { get; private set; }

    public int Count
    {
      get
      {
        return this.count;
      }
      set
      {
        this.count = value;
      }
    }

    public bool IsAutoSend { get; set; }

    public FeatureInfo(string featureName, string methodName, bool isAutoSend = true)
      : this(ViewRegions.None, featureName, methodName, (object) null)
    {
      this.IsAutoSend = isAutoSend;
    }

    public FeatureInfo(ViewRegions region, string featureName, string methodName)
      : this(region, featureName, methodName, (object) null)
    {
    }

    public FeatureInfo(ViewRegions region, string featureName, string methodName, object newValue)
    {
      this.Region = region;
      this.FeatureName = featureName;
      this.MethodName = methodName;
      if (newValue == null)
        return;
      this.NewValue = newValue.ToString();
    }

    public bool Equals(FeatureInfo obj)
    {
      return this.Region.Equals((object) obj.Region) && this.FeatureName.Equals(obj.FeatureName);
    }

    public string ToString(string editorType)
    {
      return string.Format("{0}_{1}_{2}_{3}_{4}", (object) editorType, (object) this.Region, (object) this.FeatureName, (object) this.MethodName, (object) this.NewValue);
    }
  }
}
