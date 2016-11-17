// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.Model.ProjectViewModel
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

using System.Text.RegularExpressions;

namespace CocoStudio.ControlLib.Model
{
  public class ProjectViewModel
  {
    public static bool IsMatchToName(string name)
    {
      return !Regex.IsMatch(name, "[\\*\\\\/:?<>|\"]") && !string.IsNullOrEmpty(name);
    }

    public static bool IsMatchToLogin(string name)
    {
      string pattern = "[\\u4e00-\\u9fa5]";
      return !Regex.IsMatch(name, pattern) && !string.IsNullOrEmpty(name);
    }
  }
}
