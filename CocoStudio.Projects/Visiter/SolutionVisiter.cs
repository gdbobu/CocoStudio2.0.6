// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Visiter.SolutionVisiter
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using Gdk;
using System;

namespace CocoStudio.Projects.Visiter
{
  public static class SolutionVisiter
  {
    public static Size GetSceneSize(this Solution solution)
    {
      string sizeStr = solution.UserProperties.GetValue<string>("SolutionSize");
      if (!string.IsNullOrWhiteSpace(sizeStr))
        return sizeStr.ConvertToSize();
      return Size.Empty;
    }

    public static string GetSceneSizeString(this Solution solution)
    {
      return solution.UserProperties.GetValue<string>("SolutionSize");
    }

    public static void SetSceneSize(this Solution solution, Size size)
    {
      solution.UserProperties.SetValue<string>("SolutionSize", SolutionVisiter.ConvertToString(size));
    }

    public static void SetSceneSize(this Solution solution, string size)
    {
      solution.UserProperties.SetValue<string>("SolutionSize", size);
    }

    private static Size ConvertToSize(this string sizeStr)
    {
      string[] strArray = sizeStr.Split('*');
      return new Size((int) Convert.ToDouble(strArray[0]), (int) Convert.ToDouble(strArray[1]));
    }

    private static string ConvertToString(Size size)
    {
      return string.Format("{0}*{1}", (object) size.Width, (object) size.Height);
    }
  }
}
